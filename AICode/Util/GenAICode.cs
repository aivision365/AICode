using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace AICode.Util
{
    class GenAICode
    {
        // DeepSeek API 的 URL
        private static readonly string DeepSeekApiUrl = "https://api.deepseek.com/v1/chat/completions";
        // DeepSeek API 的密钥,获取地址:https://platform.deepseek.com/api_keys
        private static readonly string DeepSeekApiKey = "Your own key";

        /// <summary>
        /// 生成代码或解释代码
        /// </summary>
        /// <param name="askType">要求类型0:生成代码,1:解析代码</param>
        /// <param name="question">向服务器发送的要求</param>
        /// <param name="content">要解析的代码</param>
        public static string[] GenCode(int askType, string question, string content)
        {
            string responseText = HttpPostUseAuthNew(DeepSeekApiUrl, askType, question, content);
            Console.WriteLine(responseText);
            return ParseContent(responseText);
        }

        /// <summary>
        /// 用post方法访问服务器获取结果
        /// </summary>
        /// <param name="url">服务器地址</param>
        /// <param name="askType">要求类型0:生成代码,1:解析代码</param>
        /// <param name="question">向服务器发送的要求</param>
        /// <param name="content">要解析的代码</param>
        /// <returns></returns>
        public static string HttpPostUseAuthNew(string url, int askType, string question, string content)
        {
            string result = "";
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            req.Method = "POST";
            req.ContentType = "application/json";
            req.Headers["Authorization"] = $"Bearer {DeepSeekApiKey}";
            req.Timeout = 1000000;

            StringBuilder builder = new StringBuilder();
            switch (askType)
            {
                case 0:
                    builder.Append(JsonConvert.SerializeObject(new
                    {
                        model = "deepseek-chat",
                        messages = new[]
                        {
                            new { role = "user", content = question + ",注意只保留代码部分,其他部分不要输出,并逐行增加中文注释" }
                        }
                    }));
                    break;
                case 1:
                    builder.Append(JsonConvert.SerializeObject(new
                    {
                        model = "deepseek-chat",
                        messages = new[]
                        {
                            new { role = "user", content = question + ",代码内容为:" + content }
                        }
                    }));
                    break;
            }

            byte[] data = Encoding.UTF8.GetBytes(builder.ToString());
            req.ContentLength = data.Length;

            try
            {
                using (Stream reqStream = req.GetRequestStream())
                {
                    reqStream.Write(data, 0, data.Length);
                    reqStream.Close();
                }

                HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
                Stream stream = resp.GetResponseStream();
                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                {
                    result = reader.ReadToEnd();
                }
            }
            catch (WebException e)
            {
                Console.WriteLine("响应错误," + e.Message);
                MessageBox.Show("响应错误," + e.Message);
            }
            return result;
        }

        /// <summary>
        /// 解析生成的内容
        /// </summary>
        /// <param name="responseText"></param>
        private static string[] ParseContent(string responseText)
        {
            JObject responseObj = (JObject)JsonConvert.DeserializeObject(responseText);
            string[] result = null;
            if (responseObj != null)
            {
                string responseContent = responseObj["choices"]?[0]?["message"]?["content"]?.ToString();
                if (!string.IsNullOrEmpty(responseContent))
                {
                    string genTemp4Str = System.Text.RegularExpressions.Regex.Unescape(responseContent);
                    result = genTemp4Str.Split(new string[] { "\n" }, StringSplitOptions.None);
                    if (result != null && result.Length > 2)
                    {
                        if (result[0].Contains("```"))
                        {
                            for (int i = 0; i < result.Length; i++)
                            {
                                if (result[i].Contains("```"))
                                {
                                    result[i] = result[i].Replace("```", "");
                                }
                            }
                            return result.Skip(1).Take(result.Length - 1).ToArray();
                        }
                        else
                        {
                            return result;
                        }
                    }
                    else
                    {
                        return result;
                    }
                }
            }

            string resultStr = "未返回结果,可能是网络连接错误!";
            result = new string[] { resultStr };
            return result;
        }
    }
}