﻿using System;
using System.IO;
using System.Collections.Generic;
using GemBox.Spreadsheet;
using System.Text;
using System.Diagnostics;

namespace ExcelConvertTool
{
    public enum ExportFileType
    {
        Xml = 0,
        Bytes = 1,
        Cs = 2,
    }

    public class ExportManeger
    {
        public static void ExportExcel(List<FileInfo> allExcels, string xmlSavePath,string csSavePath)
        {
            for (int i = 0; i < allExcels.Count; i++)
            {
                try
                {
                    ExcelFile excelFile = ExcelFile.Load(allExcels[i].FullName);
                    foreach (ExcelWorksheet excelSheetData in excelFile.Worksheets)
                    {
                        if (!excelSheetData.Name.StartsWith(CommonTool.SheetExportSign))
                            continue;

                        SheetData sheetData = new SheetData(excelSheetData);

                        ExportXml(sheetData, xmlSavePath);
                        ExportCS(sheetData, csSavePath);
                    }
                }
                catch (Exception e)
                {
                    string log = "导出文件失败：" + allExcels[i].FullName + "\n" + e.Message;
                    CommonTool.OutputLog(log);
                }
            }
        }

        #region 导出xml
        static void ExportXml(SheetData sheetData,string savePath)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("<?xml version=\"1.0\" encoding=\"utf-8\"?>");

            stringBuilder.AppendLine("<" + sheetData.FileName + "s>");
            for (int i = 0; i < sheetData.TableRowsData.Count; i++)         // 行循环
            {
                stringBuilder.AppendLine("<" + sheetData.FileName + ">");
                for (int j = 0; j < sheetData.Heads.Count; j++)             // 列循环
                {
                    HeadData headData = sheetData.Heads[j];
                    if (headData.IsNotes)
                        continue;

                    TableRowData tableRowData = sheetData.TableRowsData[i];
                    stringBuilder.AppendLine("\t<" + headData.VariableName + ">" + tableRowData.GetCellValue(j) + "</" + headData.VariableName + ">");
                }
                stringBuilder.AppendLine("</" + sheetData.FileName + ">");
            }
            stringBuilder.AppendLine("</" + sheetData.FileName + "s>");


            string exportFileFullPath = savePath + "/" + sheetData.FileName + "Cfg.xml";

            if (File.Exists(exportFileFullPath))
                File.Delete(exportFileFullPath);

            // 写XML
            StreamWriter sw = new StreamWriter(exportFileFullPath);
            sw.Write(stringBuilder);
            sw.Close();

            // 输出日志
            CommonTool.OutputLog(exportFileFullPath + "转换完成");
        }
        #endregion

        #region 导出 读取bytes 配套cs
        static void ExportCS(SheetData sheetData, string savePath)
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine("using System.Collections.Generic;");
            stringBuilder.AppendLine("using UnityEngine;");
            stringBuilder.AppendLine("using Core;");
            stringBuilder.AppendLine();
            stringBuilder.AppendLine("namespace Config");
            stringBuilder.AppendLine("{");
            stringBuilder.AppendLine("\tpublic class " + sheetData.FileName + "Cfg");
            stringBuilder.AppendLine("\t{");

            for (int i = 0; i < sheetData.Heads.Count; i++)
            {
                HeadData headData = sheetData.Heads[i];
                if (headData.IsNotes)
                    continue;

                stringBuilder.AppendLine("\t\tpublic " + headData.Type + " " + headData.VariableName + ";");
            }

            stringBuilder.AppendLine();
            stringBuilder.AppendLine("\t\tpublic static List<" + sheetData.FileName + "Cfg> LoadConfig()");
            stringBuilder.AppendLine("\t\t{");
            stringBuilder.AppendLine("\t\t\tList<" + sheetData.FileName + "Cfg> dataList = ConfigRead.LoadConfig<"+ sheetData.FileName + "Cfg>(\"Assets/AssetsPackage/ConfigData/" + sheetData.FileName + "Cfg.xml\");");
            stringBuilder.AppendLine("\t\t\treturn dataList;");
            stringBuilder.AppendLine("\t\t}");
            stringBuilder.AppendLine(" ");

            stringBuilder.AppendLine("\t\tpublic static " + sheetData.FileName + "Cfg GetSingleRecore(int id)");
            stringBuilder.AppendLine("\t\t{");
            stringBuilder.AppendLine("\t\t\tList<" + sheetData.FileName + "Cfg> dataList = LoadConfig();");

            stringBuilder.AppendLine("\t\t\tforeach (var item in dataList)");
            stringBuilder.AppendLine("\t\t\t{");
            stringBuilder.AppendLine("\t\t\t\tif (item.id == id)");
            stringBuilder.AppendLine("\t\t\t\t{");
            stringBuilder.AppendLine("\t\t\t\t\treturn item;");
            stringBuilder.AppendLine("\t\t\t\t}");
            stringBuilder.AppendLine("\t\t\t}");
            stringBuilder.AppendLine("\t\t\treturn null;");

            stringBuilder.AppendLine("\t\t}");

            stringBuilder.AppendLine("\t}");
            stringBuilder.AppendLine("}");

            string exportFileFullPath = savePath + "/" + sheetData.FileName + "Cfg.cs";

            if (File.Exists(exportFileFullPath))
                File.Delete(exportFileFullPath);

            // 写文件
            StreamWriter sw = new StreamWriter(exportFileFullPath);
            sw.Write(stringBuilder);
            sw.Close();

            // 输出日志
            CommonTool.OutputLog(exportFileFullPath + "转换完成");
        }
        #endregion
    }
}
