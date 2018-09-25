using Newtonsoft.Json.Linq;
using OnPS.Models;
using OnPS.Models.Data;
using OnPS.Other;
using System;
using System.Collections;
using System.IO;
using System.Net;

namespace OnPS.Platforms
{
    class PSN
    {
        public static JObject getUserDataByAccessToken(String token)
        {
            JObject o = null; //initialize variable!
            try
            {
                o = JObject.Parse(Network.HTTP_GET("https://auth.api.sonyentertainmentnetwork.com/2.0/oauth/token/" + token.ToString(), ""));
            }
            catch (Exception)
            {
                return null;
            }
            return o;
        }

        public static ActivityModel GetUserActivity(String oauth, bool isMain = false)
        {
            JObject o;
            try
            {
                o = JObject.Parse(Network.HTTP_GET("https://us-prof.np.community.playstation.net/userProfile/v1/users/me/profile2?fields=npId,onlineId,avatarUrls,plus,primaryOnlineStatus,presences(@titleInfo,hasBroadcastData)&avatarSizes=m,xl&profilePictureSizes=m,xl&languagesUsedLanguageSet=set3&psVitaTitleIcon=circled&titleIconSize=s", null, "Bearer " + oauth));
            }
            catch(Exception)
            {
                return null;
            }
            ActivityModel activityModel = new ActivityModel(isMain);
            activityModel.onlineId = o.GetValue("profile")["onlineId"].ToString();
            activityModel.npId = o.GetValue("profile")["npId"].ToString();
            activityModel.plus = Convert.ToInt16(o.GetValue("profile")["plus"]);
            activityModel.primaryOnlineStatus = o.GetValue("profile")["primaryOnlineStatus"].ToString();
            activityModel.avatarUrl = o.GetValue("profile")["avatarUrls"][0]["avatarUrl"].ToString();
            activityModel.onlineStatus = OnlineStatusModel.OFFLINE;
            activityModel.platform = IniModel.GetPSNPlatform();
            var presences = o.GetValue("profile")["presences"];
            bool SelectedPlatformAvailable = false;
            foreach(var data in presences)
            {
                if (data["platform"] == null)
                {
                    continue;
                }
                
                if (data["platform"].ToString() == activityModel.platform)
                {
                    SelectedPlatformAvailable = true;
                    try
                    {
                        activityModel.npTitleIconUrl = data["npTitleIconUrl"].ToString();
                    }
                    catch (Exception)
                    {
                        activityModel.npTitleIconUrl = null;
                    }
                    try
                    {
                        activityModel.onlineStatus = data["onlineStatus"].ToString();
                    }
                    catch (Exception)
                    {
                        activityModel.onlineStatus = OnlineStatusModel.OFFLINE;
                    }
                    try
                    {
                        activityModel.titleName = data["titleName"].ToString();
                        activityModel.npTitleId = data["npTitleId"].ToString();
                        
                    }
                    catch(Exception)
                    {
                        activityModel.titleName = null;
                        activityModel.npTitleId = null;
                    }
                    try
                    {
                        activityModel.gameStatus = data["gameStatus"].ToString();
                    }
                    catch (Exception)
                    {
                        activityModel.gameStatus = null;
                    }
                }
                if(data["platform"] != null && data["titleName"] != null && data["npTitleId"] != null)
                {
                    GameData gameData = new GameData();
                    gameData.platform = data["platform"].ToString();
                    gameData.titleName = data["titleName"].ToString();
                    gameData.npTitleId = data["npTitleId"].ToString();
                    try
                    {
                        gameData.npTitleIconUrl = data["npTitleIconUrl"].ToString();
                    }
                    catch(Exception)
                    {
                        gameData.npTitleIconUrl = "";
                    }
                    activityModel.RunningGames.Add(gameData);
                }
            }
            if(SelectedPlatformAvailable == false)
            {
                activityModel.onlineStatus = OnlineStatusModel.OFFLINE;
            }
            return activityModel;
        }

        public static PSNAuthData AuthWithCode(String code)
        {

            String postData = "grant_type=authorization_code&code=" + code + "&redirect_uri=com.playstation.remoteplay.sceappcall://redirect&";
            JObject o = null; //initialize variable!
            try
            {
                o = JObject.Parse(Network.HTTP_POST("https://auth.api.sonyentertainmentnetwork.com/2.0/oauth/token", postData));
            }
            catch (Exception)
            {
                return null;
            }
            PSNAuthData AuthModel = new PSNAuthData();
            AuthModel.access_token = o.GetValue("access_token").ToString();
            AuthModel.refresh_token = o.GetValue("refresh_token").ToString();
            return AuthModel;
        }

        public static String[] AuthWithRefreshToken(String RefreshToken)
        {
            String postData = "grant_type=refresh_token&refresh_token=" + RefreshToken + "&scope=psn:clientapp&";
            JObject o = null; //initialize variable!
            try
            {
                String post = Network.HTTP_POST("https://auth.api.sonyentertainmentnetwork.com/2.0/oauth/token", postData);
                Console.WriteLine(post);
                o = JObject.Parse(post);
            }
            catch (Exception)
            {
                throw new Exception();
            }
            String AccessToken = o.GetValue("access_token").ToString();
            Console.WriteLine("AccessToken: " + AccessToken);
            String RefreshTkn = o.GetValue("refresh_token").ToString();
            Console.WriteLine("RefreshToken: " + RefreshTkn);
            String[] output = new string[2];
            output[0] = AccessToken;
            output[1] = RefreshTkn;
            return output;
        }
    }
}
