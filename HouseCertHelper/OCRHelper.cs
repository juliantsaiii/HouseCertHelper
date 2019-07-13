using System;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace HouseCertHelper
{
    class OCRHelper
    {
        private const String host = "https://ocrapi-house-cert.taobao.com";
        private const String path = "/ocrservice/houseCert";
        private const String method = "POST";
        private const String appcode = "050c7ce3b063469a901206281171900662";

        public static string CertHelper(string filepath)
        {
            String querys = "";
            String img_file = filepath;
            FileStream fs = new FileStream(img_file, FileMode.Open);
            BinaryReader br = new BinaryReader(fs);
            byte[] contentBytes = br.ReadBytes(Convert.ToInt32(fs.Length));
            String base64 = System.Convert.ToBase64String(contentBytes);
            String bodys = "{\"image\":\"" + base64 + "\"";  //对图片内容进行Base64编码


            String url = host + path;
            HttpWebRequest httpRequest = null;
            HttpWebResponse httpResponse = null;

            if (0 < querys.Length)
            {
                url = url + "?" + querys;
            }

            if (host.Contains("https://"))
            {
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
                httpRequest = (HttpWebRequest)WebRequest.CreateDefault(new Uri(url));
            }
            else
            {
                httpRequest = (HttpWebRequest)WebRequest.Create(url);
            }
            httpRequest.Method = method;
            httpRequest.Headers.Add("Authorization", "APPCODE " + appcode);
            //根据API的要求，定义相对应的Content-Type
            httpRequest.ContentType = "application/json; charset=UTF-8";
            // 设置并解析  格式
            String config = "{\\\"side\\\":\\\"face\\\"}";
            bodys = "{\"img\":\"" + base64 + "\"";
            if (config.Length < 0)
            {
                bodys += ",\"configure\" :\"" + config + "\"";
            }
            bodys += "}";


            httpRequest.ContentType = "application/json; charset=UTF-8";
            if (0 < bodys.Length)
            {
                byte[] data = Encoding.UTF8.GetBytes(bodys);
                using (Stream stream = httpRequest.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }
            }
            try
            {
                httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            }
            catch (WebException ex)
            {
                httpResponse = (HttpWebResponse)ex.Response;
            }

            Console.WriteLine(httpResponse.StatusCode);
            Console.WriteLine(httpResponse.Method);
            Console.WriteLine(httpResponse.Headers);
            Stream st = httpResponse.GetResponseStream();
            StreamReader reader = new StreamReader(st, Encoding.GetEncoding("utf-8"));
            string analysis = reader.ReadToEnd();
            Console.WriteLine(reader.ReadToEnd());
            return (analysis);

        }

        public static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {
            return true;
        }
        //调试接口
        public static string CertHelper()
        {
            string result = "{\"sid\":\"121de0f0fa1763a11f08b1fb76628e8e1819bd76e47a14218247bbcafe980d8b3bb06fec\",\"data\":{\"房产证号\":\"JN00406313\",\"权利人\":\"王刚礼张洪梅\",\"共有情况\":\"共同共有\",\"坐落\":\"江宁区东山街道湖山北路95号武夷水岸家园14幢402室\",\"登记时间\":\"2015年04月22日\",\"房屋性质\":\"私有疾产\",\"房屋用途\":\"成套柱宅\",\"建筑面积\":\"93.33\",\"土地权利性质/取得方式\":\"\"},\"angle\":90,\"height\":1080,\"width\":1514,\"orgHeight\":1514,\"orgWidth\":1080}";
            return result;            
        }
    }
}
