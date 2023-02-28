using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelConvertTool
{
    public static class Define
    {
        #region Excel 配置方式定义

        public static string SheetExportSign = "t_";

        public static string ColumnNotExportSign = "#";

        // todo char类型 可以换string吗
        public static char StrSplitChar = '|';

        public static int VariableTypeRowNum = 0;

        public static int VariableNameRowNum = 1;

        public static int VariableStartDataRowNum = 3;

        #endregion

        #region 项目相关路径定义

        public static string ExcelFolderPath 
        {
            get
            {
                return GetAppRootPath() + "Temp/Excel/China"; 
            }
        }

        public static string ExportXmlFolderPath {
            get {
                string path = GetAppRootPath() + "Temp/Export/XML";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                return path;
            }
        }

        public static string ExportCSFolderPath {
            get {
                string path = GetAppRootPath() + "Temp/Export/CS";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                return path;
            }
        }

        #endregion


        /// <summary>
        /// 工具信息缓存的目录
        /// </summary>
        public static string ExcelConvertToolCachePath() 
        {
            return GetAppRootPath() + @"ExcelToolCache/";
        }

        /// <summary>
        /// 工具信息缓存的文件
        /// </summary>
        public static string ExcelConvertToolLogName() 
        {
            return @"ExcelToolLog.txt";
        }

        public static string GetExcelConvertToolLogPath() 
        {
            return ExcelConvertToolCachePath() + ExcelConvertToolLogName();
        }

        public static string GetAppRootPath() 
        {
            return System.Windows.Forms.Application.StartupPath + "/../../../";
        }
    }
}
