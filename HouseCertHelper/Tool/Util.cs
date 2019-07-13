using Newtonsoft.Json;
using System;
using System.Drawing;
using System.IO;

namespace HouseCertHelper.Tool
{
    public static class Util
    {
        //json字符串信息抓取
        public static string JsonResultAnalysis(string jsonResult)
        {
            return "";
        }

        //将Json字符串转为对象
        public static T ToJson<T>(string content)
        {
            content = content.Replace('/', '_');
            T result = JsonConvert.DeserializeObject<T>(content);
            return result;
        }

        //将图片转为base64
        public static string ImageToBase64(string fileFullName)
        {
            try
            {
                Bitmap bmp = new Bitmap(fileFullName);
                MemoryStream ms = new MemoryStream();
                bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] arr = new byte[ms.Length]; ms.Position = 0;
                ms.Read(arr, 0, (int)ms.Length); ms.Close();
                return Convert.ToBase64String(arr);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
