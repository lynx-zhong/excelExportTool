using System.IO;
using System.Windows.Forms;
using System.Text;
using System.Collections.Generic;

namespace ExcelConvertTool
{
    public class CommonTool
    {
        public enum LogMark
        {
            ExcelPathMark,
            CsOutputPathMark,
            XmlOutputPathMark,
        }

        public static string GetLogMark(LogMark logMark) 
        {
            switch (logMark)
            {
                case LogMark.ExcelPathMark:
                    return "ExcelPath:";
                case LogMark.CsOutputPathMark:
                    return "CsOutputPath:";
                case LogMark.XmlOutputPathMark:
                    return "XmlOutputPath:";
                default:
                    break;
            }

            return string.Empty;
        }


        private static RichTextBox richText;
        public static void InitLog(RichTextBox richTex) 
        {
            richText = richTex;
        }

        public static void WriteLog(string logInfo,bool isModif = false,string mark = "") 
        {
            try
            {
                string excelToolLogPath = Define.GetExcelConvertToolLogPath();
                if (!File.Exists(excelToolLogPath))
                    File.Create(excelToolLogPath).Close();

                if (isModif)
                {
                    bool isSucceed = false;
                    string[] fileInfo = File.ReadAllLines(excelToolLogPath);
                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < fileInfo.Length; i++)
                    {
                        if (fileInfo[i].StartsWith(mark))
                        {
                            sb.AppendLine(logInfo);
                            isSucceed = true;
                        }
                        else
                        {
                            sb.AppendLine(fileInfo[i]);
                        }
                    }

                    if (!isSucceed)
                        sb.AppendLine(logInfo);

                    StreamWriter streamWriter = new StreamWriter(excelToolLogPath, false);
                    string aa = sb.ToString().TrimEnd('\n', '\r', ' ');
                    streamWriter.WriteLine(aa);
                    streamWriter.Close();
                }
                else
                {
                    StreamWriter streamWriter = new StreamWriter(excelToolLogPath, true);
                    streamWriter.WriteLine(logInfo);
                    streamWriter.Close();
                }

            }
            catch (System.Exception e)
            {
                CommonTool.OutputLog(e.Message);
                return;
            }
        }

        public static void OutputLog(string log) 
        {
            if (richText != null)
            {
                richText.Text = richText.Text + log + "\n";
            }
        }

        public static string TriEndAndStart(object objStr)
        {
            string str = objStr.ToString().TrimEnd('\n', '\r', ' ');
            str = str.TrimStart(' ', '\n', '\r');

            return str;
        }
        public static string AutoCompleteCellContent(string str)
        {
            return "0";
        }

        public static bool CheckTypeIsItRight(string typeString) 
        {
            List<string> allTypeString = new List<string>() { "bool","string", "int", "float","long","double", "List<int>","List<long>",
            "List<float>","List<double>","List<string>","#","Vector3","Vector2","List<Vector3>","List<Vector2>"
            };

            for (int i = 0; i < allTypeString.Count; i++)
            {
                if (typeString.Equals(allTypeString[i]))
                    return true;
            }

            return false;
        }

        #region 按首字母排序
        /// <summary>
        /// 首字母排序 数组
        /// </summary>
        public static void SortDirectory(DirectoryInfo[] allDirectorys)
        {
            for (int i = 0; i < allDirectorys.Length - 1; i++)
            {
                for (int j = i + 1; j < allDirectorys.Length; j++)
                {
                    if (string.Compare(GetFirstPY(allDirectorys[i].Name), GetFirstPY(allDirectorys[j].Name)) == 1)
                    {
                        DirectoryInfo temp = allDirectorys[i];
                        allDirectorys[i] = allDirectorys[j];
                        allDirectorys[j] = temp;
                    }
                }
            }
        }

        /// <summary>
        /// 获取首字母拼音
        /// </summary>
        public static string GetFirstPY(string str)
        {
            string ret = string.Empty;

            foreach (char c in str)
            {
                ret += GetPYChar(c);
            }

            return ret;
        }

        /// <summary>
        /// 获取拼音
        /// </summary>
        private static string GetPYChar(char c)
        {
            string str = c.ToString();

            if ((int)c >= 32 && (int)c <= 126)
            {
                return str;
            }

            byte[] array = new byte[2];

            array = System.Text.Encoding.Default.GetBytes(str);

            int i = (short)(array[0] - '\0') * 256 + ((short)(array[1] - '\0'));

            if (i < 0xB0A1) return "*";

            if (i < 0xB0C5) return "A";

            if (i < 0xB2C1) return "B";

            if (i < 0xB4EE) return "C";

            if (i < 0xB6EA) return "D";

            if (i < 0xB7A2) return "E";

            if (i < 0xB8C1) return "F";

            if (i < 0xB9FE) return "G";

            if (i < 0xBBF7) return "H";

            if (i < 0xBFA6) return "J";

            if (i < 0xC0AC) return "K";

            if (i < 0xC2E8) return "L";

            if (i < 0xC4C3) return "M";

            if (i < 0xC5B6) return "N";

            if (i < 0xC5BE) return "O";

            if (i < 0xC6DA) return "P";

            if (i < 0xC8BB) return "Q";

            if (i < 0xC8F6) return "R";

            if (i < 0xCBFA) return "S";

            if (i < 0xCDDA) return "T";

            if (i < 0xCEF4) return "W";

            if (i < 0xD1B9) return "X";

            if (i < 0xD4D1) return "Y";

            if (i < 0xD7FA) return "Z";

            return "*";
        }
        #endregion
    }
}
