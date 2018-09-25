using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OnPS.Models;
using OnPS.Other;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnPS
{
    public partial class GameStatistic : Form
    {
        private ImageList imageList = new ImageList();
        private string onlineId;
        private string platform
        {
            get
            {
                return _platform;
            }
            set
            {
                toolStripComboBox1.Text = value;
                _platform = value;
            }
        }
        public string _platform;
        public GameStatistic(String onlineId)
        {
            InitializeComponent();
            this.onlineId = onlineId;
        }

        private void GameStatistic_Load(object sender, EventArgs e)
        {
            ArrayList availablePlatforms = GameStatisticModel.GetAvailablePlatforms(onlineId);
            try
            {
                platform = availablePlatforms[0].ToString();
            }
            catch(Exception)
            {
                //Platform not found!
                return;
            }
            string defaultPlatform = IniModel.GetPSNPlatform();
            /*if (availablePlatforms.IndexOf(defaultPlatform) > -1)
            {
                availablePlatforms
            }*/
            foreach (String platform in availablePlatforms)
            {
                if(defaultPlatform == platform)
                    toolStripComboBox1.Items.Insert(0, platform);
                else
                    toolStripComboBox1.Items.Add(platform);
            }
            toolStripComboBox1.SelectedIndex = 0;
        }

        private async Task LoadListAsync(String platform)
        {
            imageList.Images.Clear();
            imageList.ImageSize = new Size(128, 128);
            imageList.ColorDepth = ColorDepth.Depth16Bit;
            listView1.Clear();
            ArrayList files = GameStatisticModel.GetFiles(onlineId, platform);
            foreach(String file in files)
            {
                String jsonString = File.ReadAllText(file);
                Dictionary<string, dynamic> data = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(jsonString);

                /* Variables */
                String titleName = data["titleName"];
                String npTitleId = data["npTitleId"];
                String npTitleIconUrl = data["npTitleIconUrl"];
                int totalPlayTime = 0;
                data["date"] = JObject.FromObject(data["date"]).ToObject<Dictionary<string, dynamic>>();
                foreach (KeyValuePair<string, dynamic> date in data["date"])
                {
                    totalPlayTime += Convert.ToInt16(date.Value.playTime);
                }

                /* Variables */
                Image bitmap = null;
                if (npTitleIconUrl == "")
                {
                    bitmap = new Bitmap(Properties.Resources.NoGameImage);
                }
                else
                {
                    bitmap = await Task.Run(() => GetImageAsync(npTitleIconUrl));
                }
                imageList.Images.Add("itemImageKey", bitmap);
                ListViewItem listViewItem = new ListViewItem();
                listViewItem.Text = titleName + "\n" + Utils.CalculateMinuteToTime(totalPlayTime) + "on records.";
                listViewItem.ImageIndex = listView1.Items.Count;
                listView1.LargeImageList = imageList;
                listView1.Items.Add(listViewItem);
            }
        }

        public async Task<Image> GetImageAsync(string url)
        {
            var tcs = new TaskCompletionSource<Image>();
            Image webImage = null;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            await Task.Factory.FromAsync<WebResponse>(request.BeginGetResponse, request.EndGetResponse, null)
                .ContinueWith(task =>
                {
                    var webResponse = (HttpWebResponse)task.Result;
                    Stream responseStream = webResponse.GetResponseStream();
                    if (webResponse.ContentEncoding.ToLower().Contains("gzip"))
                        responseStream = new GZipStream(responseStream, CompressionMode.Decompress);
                    else if (webResponse.ContentEncoding.ToLower().Contains("deflate"))
                        responseStream = new DeflateStream(responseStream, CompressionMode.Decompress);

                    if (responseStream != null) webImage = Image.FromStream(responseStream);
                    tcs.TrySetResult(webImage);
                    webResponse.Close();
                    responseStream.Close();
                });
            return tcs.Task.Result;
        }

        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (toolStripComboBox1.SelectedText == _platform)
                return;
            this.platform = toolStripComboBox1.Text;
            LoadListAsync(platform);
        }
    }
}
