using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnPS.Other
{
    class Updater
    {
        public EventHandler UpdateAvailable;
        public const String URL = "http://onpsapp.com/update.json";
        public Updater()
        {
            String data;
            try
            {
                data = Network.HTTP_GET(URL, "", "");
            }
            catch(Exception e)
            {
                //Update Halted!
                return;
            }
            JObject updateData = JObject.Parse(data);
            if(updateData["version"].ToString() != Program.VERSION)
            {
                UpdateAvailable(this, new EventArgs());
            }
        }

    }
}
