
using System.Collections.Generic;
using GemBox.Spreadsheet;
using System.Windows.Forms;

namespace ExcelConvertTool
{
    #region 储存excel 单页数据 方便操作
    public class SheetData
    {
        public string FileName;

        ExcelWorksheet excelSheet;

        public readonly List<HeadData> Heads = new List<HeadData>();

        public readonly List<TableRowData> TableRowsData = new List<TableRowData>();

        public SheetData(ExcelWorksheet _excelSheet )
        {
            excelSheet = _excelSheet;

            InitSheet( );
        }

        void InitSheet( ) 
        {
            FileName = excelSheet.Name.Replace(Define.SheetExportSign, "");

            ExportHeadData();

            ExportAllRowData();
        }

        void ExportHeadData() 
        {
            int maxColCount = 100000;
            int continueBlankNum = 0;
            int maxBlankNum = 20;

            int itemCount = 0;
            Heads.Clear();
            for (int i = 0; i < maxColCount; i++)
            {
                object variableType = excelSheet.Rows[Define.VariableTypeRowNum].AllocatedCells[i].Value;
                if (variableType != null)
                {
                    string variableTypeString = CommonTool.TriEndAndStart(variableType);
                    if (variableTypeString.Equals(""))
                    {
                        continueBlankNum++;
                        if (continueBlankNum >= maxBlankNum)
                            break;
                    }
                    else if (!CommonTool.CheckTypeIsItRight(variableTypeString))
                    {
                        string str = string.Format("不支持的数据类型：{0}表，第{1}行，第{2}列:", FileName, Define.VariableNameRowNum + 1, i + 1);
                        CommonTool.OutputLog(str);
                        return;
                    }
                    else
                    {
                        object variableName = excelSheet.Rows[Define.VariableNameRowNum].AllocatedCells[i].Value;
                        if (variableName == null)
                        {
                            string str = string.Format("变量名为空：{0}表，第{1}行，第{2}列:", FileName, Define.VariableNameRowNum + 1, i + 1);
                            CommonTool.OutputLog(str);
                            return;
                        }

                        string variableNameStr = CommonTool.TriEndAndStart(variableName);
                        if (variableNameStr.Equals("") | variableName == null)
                        {
                            string str = string.Format("变量名为空：{0}表，第{1}行，第{2}列:", FileName, Define.VariableNameRowNum + 1, i + 1);
                            CommonTool.OutputLog(str);
                            return;
                        }

                        HeadData headWrapper = new HeadData(variableNameStr, variableTypeString);
                        Heads.Add(headWrapper);
                        itemCount++;
                    }
                }
                else
                {
                    continueBlankNum++;
                    if (continueBlankNum >= maxBlankNum)
                        break;
                }
            }
        }

        void ExportAllRowData() 
        {
            TableRowsData.Clear();

            int maxRowCount = 100000;

            for (int i = Define.VariableStartDataRowNum; i < maxRowCount; i++)     // 行
            {
                if (excelSheet.Rows[i].AllocatedCells[0].Value == null)
                    return;

                TableRowData tableWrapper = new TableRowData( this,excelSheet.Rows[i]);
                TableRowsData.Add(tableWrapper);
            }
        }
    }
    #endregion

    #region Excel表头 数据
    public class HeadData
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string VariableName { get; }

        /// <summary>
        /// 类型
        /// </summary>
        public string Type { get; }

        /// <summary>
        /// 策划注释列
        /// </summary>
        public bool IsNotes { get; }

        public HeadData(string name, string type)
        {
            VariableName = name;
            Type = type;

            // 检测是否为策划注释列
            IsNotes = name.StartsWith(Define.ColumnNotExportSign);
        }
    }
    #endregion

    #region Excel 单行表格数据
    public class TableRowData
    {
        /// <summary>
        /// 单元格数据
        /// Key为 列数
        /// Value为cellValue
        /// </summary>
        private Dictionary<int, string> cellValueDic = new Dictionary<int, string>();

        public TableRowData(SheetData sheetData, ExcelRow row)
        {
            for (int i = 0; i < sheetData.Heads.Count; i++)
            {
                HeadData headWrapper = sheetData.Heads[i];
                if (headWrapper.IsNotes)
                {
                    cellValueDic.Add(i, string.Empty);
                    continue;
                }

                string cellValue = string.Empty;
                if (row.AllocatedCells[i].Value == null)
                    cellValue = CommonTool.AutoCompleteCellContent(cellValue);
                else
                    cellValue = row.AllocatedCells[i].Value.ToString();

                cellValueDic.Add(i, cellValue);
            }
        }

        public string GetCellValue(int cellNum)
        {
            return cellValueDic[cellNum];
        }
    }
    #endregion
}
