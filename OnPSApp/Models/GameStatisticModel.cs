using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnPS.Models
{
    class GameStatisticModel
    {
        private String filePath = null;
        private String onlineId = null;
        private String titleName = null;
        private String npTitleId = null;
        private String npTitleIconUrl = null;
        private String platform = null;
        private Dictionary<string, dynamic> date;

        public GameStatisticModel(String onlineId, String platform, String npTitleId, String titleName, String npTitleIconUrl)
        {
            string folderPath = Application.StartupPath + "/profiles/"+ onlineId + "/"+platform+"/";

            bool exists = System.IO.Directory.Exists(folderPath);

            if (!exists)
                System.IO.Directory.CreateDirectory(folderPath);

            string filePath = folderPath + npTitleId + ".json";
            this.filePath = filePath;

            this.onlineId = onlineId;
            this.npTitleId = npTitleId;
            this.titleName = titleName;
            this.npTitleIconUrl = npTitleIconUrl;
            this.platform = platform;
            if (!File.Exists(filePath))
            {
                this.date = new Dictionary<string, dynamic>();
                FileStream file = File.Create(filePath);
                file.Close();
                SaveData();
            }
            else
            {
                String jsonString = File.ReadAllText(filePath);
                Dictionary<string, dynamic> data = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(jsonString);
                try
                {
                    data["date"] = JObject.FromObject(data["date"]).ToObject<Dictionary<string, object>>();
                }
                catch(Exception)
                {
                    data["date"] = new Dictionary<string, dynamic>();
                }
                this.date = data["date"];
            }
        }

        public void AddMinute()
        {
            String date = DateTime.Now.ToString("M/d/yy");
            try
            {
                if(this.date[date] != null)
                {

                }
            }
            catch(Exception)
            {
                Dictionary<string, dynamic> dictionaryList = new Dictionary<string, dynamic>();
                dictionaryList["playTime"] = 0;
                this.date[date] = dictionaryList;
            }
            this.date[date]["playTime"] += 1;
            /*Dictionary<string, dynamic> date2 = new Dictionary<string, dynamic>();
            date2.Add("thisday", "3");
            this.date.Add(date2);*/


        }

        public Dictionary<String, dynamic> GetData()
        {
            var dict = new Dictionary<string, dynamic>();
            var result = this.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
            foreach (var item in result)
            {
                if (item.FieldType.ToString().Contains("EventHandler"))
                {
                    continue;
                }
                switch(item.Name)
                {
                    case "filePath":
                        //Block filePath.
                        break;
                    default:
                        dict[item.Name] = item.GetValue(this);
                        break;
                }
            }
                
            return dict;
        }

        public void SaveData()
        {
            File.WriteAllText(filePath, JsonConvert.SerializeObject(this.GetData()));
        }

        public static ArrayList GetAvailablePlatforms(String onlineId)
        {
            String Path = Application.StartupPath + @"\profiles\" + onlineId;
            if (!Directory.Exists(Path))
            {
                Directory.CreateDirectory(Path);
            }
            ArrayList availablePlatformList = new ArrayList();
            var directories = Directory.GetDirectories(Path);
            foreach (var directory in directories)
            {
                String[] arr = directory.Split('\\');
                String platform = arr[arr.Length - 1];
                if (PlatformModel.GetPlatformName(platform) != null)
                    availablePlatformList.Add(platform);
            }
            return availablePlatformList;
        }

        public static ArrayList GetFiles(String onlineId, String platform)
        {
            String Path = Application.StartupPath + @"\profiles\" + onlineId + @"\" + platform + @"\";
            if (!Directory.Exists(Path))
            {
                Directory.CreateDirectory(Path);
            }
            ArrayList fileList = new ArrayList();
            var files = Directory.GetFiles(Path);
            foreach (var file in files)
            {
                if (!file.ToString().EndsWith(".json"))
                    continue;
                /*String[] arr = file.Split('\\');
                String fileName = arr[arr.Length - 1];*/
                fileList.Add(file);
            }
            return fileList;
        }
    }
}
