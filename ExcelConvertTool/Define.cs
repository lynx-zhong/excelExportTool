using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelConvertTool
{
    public class Define
    {
        public static string ExcelConvertToolCachePath() 
        {
            return GetAppRootPath() + @"ExcelToolCache/";
        }

        public static string ExcelConvertToolLogName() 
        {
            return @"ExcelToolLog.txt";
        }

        public static string GetAppRootPath() 
        {
            return System.Windows.Forms.Application.StartupPath + "/../../";
        }
    }
}
