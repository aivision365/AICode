using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace AICode.Util
{
    /// <summary>
    /// 读取剪切板中的内容
    /// </summary>
    class ClipBoardUtil
    {
        /// <summary>
        /// 获取剪切板中的内容
        /// </summary>
        /// <returns></returns>
        public static string GetClipContent()
        {
            string content = "";
            Thread t = new Thread((ThreadStart)(() =>
            {
                // GetDataObject获取当前剪贴板上的数据
                IDataObject data = Clipboard.GetDataObject();

                // 将数据与指定的格式进行匹配，返回bool
                if (data.GetDataPresent(DataFormats.Text))
                {
                    // GetData检索数据并指定一个格式
                    content = (string)data.GetData(DataFormats.Text);
                }
            }));
            // Run your code from a thread that joins the STA Thread
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
            t.Join();
            //content = "Thread t = new Thread((ThreadStart)(() => {\r\n OpenFileDialog saveFileDialog1 = new OpenFileDialog();\r\n\r\n saveFileDialog1.Filter = \"JSON Files (*.json)|*.json\";\r\n    saveFileDialog1.FilterIndex = 2;\r\n    saveFileDialog1.RestoreDirectory = true;\r\n\r\n    if (saveFileDialog1.ShowDialog() == DialogResult.OK)\r\n    {\r\n        selectedPath = saveFileDialog1.FileName;\r\n    }\r\n}));\r\n\r\n// Run your code from a thread that joins the STA Thread\r\nt.SetApartmentState(ApartmentState.STA);\r\nt.Start();\r\nt.Join();";
            //content = content.Replace("\r", "");
            return CustomToEscape(content);
        }

        /// <summary>
        /// 转义字符在字符串中保持不变的处理方案，再次进行Escape
        /// 如果想输出对应c字符，那么需要使用转义方式，这样可能保证字符串的输入和输出不变，不然会被自动转义，尤其在写文件的时候
        /// 比如文件中想写入\b,不加转义的话，就会变成b，然后显示一个特殊的符合!!!

        /// 空格是一个空白字符，ASCII码是32

        /// \0某种意义说是字符串结尾

        /// 或者直接使用System.Text.RegularExpressions.Regex.Escape(str);

        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string CustomToEscape(string str)
        {
            StringBuilder sb = new StringBuilder("");
            for (int i = 0; i < str.Length; i++)
            {
                char c = str[i];
                switch (c)
                {
                    case '\\': // 反斜杠
                        sb.Append("\\\\");
                        break;
                    case '/': // 正斜杠
                        sb.Append("\\/");
                        break;
                    case '\"': // 双引号
                        sb.Append("\\\"");
                        break;
                    case '\a': // 感叹号
                        sb.Append("\\a");
                        break;
                    case '\b': // 退格
                        sb.Append("\\b");
                        break;
                    case '\f':
                        sb.Append("\\f");
                        break;
                    case '\n':
                        sb.Append("\\n");
                        break;
                    case '\r':
                        sb.Append("\\r");
                        break;
                    case '\t':
                        sb.Append("\\t");
                        break;
                    // 空格是一个空白字符，ASCII码是32
                    // \0某种意义说是字符串结尾
                    case '\0':// \0，会终止对此字符串的所有操作
                        sb.Append("\\0");
                        break;
                    default:
                        sb.Append(c);
                        break;
                }
            }
            return sb.ToString();
        }
    }
}
