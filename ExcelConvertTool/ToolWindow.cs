using System;
using System.Collections.Generic;
using System.Windows.Forms;
using GemBox.Spreadsheet;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security;
using System.Security.AccessControl;
using System.Security.Permissions;
using Microsoft.Win32;

namespace ExcelConvertTool
{
    /** 
     * 说明
     * 
     * FileManager
     * 1.文件选择的方式，直接以文件夹，文件的树状图做选择
     * 2.文件过滤 用 "#" 号键。文件名以"#"号键开头则不导出
     * 3.文件导出目录以 C开头的则为客户端独有目录，以 S开头为服务器独有。
     * 4.文件导出目录分为 Global Client Server
     * 
     * ToolWindow 
     * 1.只做窗体展示 走FileManeger 获取导入 导出的数据
     * 
     * ExportManager
     * 1.文件导出操作管理，把Excel 提供的数据，和当前的导出类型，选择适合的导出器
     * 
     * Define
     * 1.代码里面定义一些常量
     * 
     * Export....
     * 
     * **/

    /**
     * 导表工具需要优化补充的地方
     * 
     * 1. 支持自定义结构类型 自定义类
     * 2. 支持 keyword
     * 3. 多语言支持
     * 4. 序列化导出
     * 5. 自动补全
     * 6. 合并表格
     * **/

    public partial class ToolWindow : Form
    {
        #region 常量定义
        public const string ExcelFileTag = "ExcelFileTag";
        public const string FolderTag = "FolderTag";

        #endregion

        #region 变量申明

        Dictionary<string, FileInfo> allExcelFilesDic;   // 所有的文件

        public string saveXmlPath;

        public string saveCsPath;

        #endregion

        public ToolWindow()
        {
            InitializeComponent();
            Awake();
        }

        private void Awake()
        {
            SpreadsheetInfo.SetLicense("EQU2-1000-0000-000U");
            CommonTool.InitLog(logLable);

            excelTreeView.CheckBoxes = true;
            excelTreeView.Nodes.Clear();

            //ShowCacheFloderInfo();
            ShowDefinePath();
            ShowExcelTreeList();
        }

        #region TreeView 操作
        void ShowCacheFloderInfo()
        {
            string filePath;
            bool isHaveOath = GetCahceFloderInfo(CommonTool.LogMark.ExcelPathMark, out filePath);
            if (isHaveOath)
            {
                curChooseFolderBrowserInfo.Text = filePath;
            }

            isHaveOath = GetCahceFloderInfo(CommonTool.LogMark.CsOutputPathMark, out filePath);
            if (isHaveOath)
            {
                curChooseCsSavePath.Text = filePath;
                saveCsPath = filePath;
            }

            isHaveOath = GetCahceFloderInfo(CommonTool.LogMark.XmlOutputPathMark, out filePath);
            if (isHaveOath)
            {
                curChooseXmlSavePathLable.Text = filePath;
                saveXmlPath = filePath;
            }
        }

        void ShowDefinePath() 
        {
            string excelFolderPath = Path.GetFullPath(Define.ExcelFolderPath);
            curChooseFolderBrowserInfo.Text = excelFolderPath;
        }

        void ShowExcelTreeList()
        {
            excelTreeView.Nodes.Clear();

            //string excelFolderBrowserPath;
            //bool isHaveExcelToolLog = GetCahceFloderInfo(CommonTool.LogMark.ExcelPathMark, out excelFolderBrowserPath);
            //if (!isHaveExcelToolLog)
            //    return;

            DirectoryInfo rootDirectoryInfo = new DirectoryInfo(Define.ExcelFolderPath);
            DirectoryInfo[] allDirectorys = rootDirectoryInfo.GetDirectories();
            //CommonTool.SortDirectory(allDirectorys);

            allExcelFilesDic = new Dictionary<string, FileInfo>();
            foreach (DirectoryInfo directoryInfo in allDirectorys)
            {
                TreeNode treeNode = excelTreeView.Nodes.Add(directoryInfo.Name);
                treeNode.Tag = FolderTag;

                foreach (var fileItem in directoryInfo.GetFiles())
                {
                    if (!fileItem.Name.StartsWith("~") && fileItem.Name.EndsWith(".xlsx"))
                    {
                        TreeNode excelFileNode = new TreeNode();
                        excelFileNode.Text = fileItem.Name;
                        excelFileNode.Tag = ExcelFileTag;
                        treeNode.Nodes.Add(excelFileNode);

                        allExcelFilesDic.Add(fileItem.Name, fileItem);
                    }
                }
            }
        }

        private void OnClickExeclFile(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag.ToString() == FolderTag)
                SetChildNodeCheckedState(e.Node, e.Node.Checked);

            showChooseExcel.Items.Clear();
            List<TreeNode> allChooseNodes = GetAllChooseNodes();
            foreach (TreeNode node in allChooseNodes)
            {
                showChooseExcel.Items.Add(node.Text);
            }
        }

        private void ChooseAllNode(object sender, EventArgs e)
        {
            for (int i = 0; i < excelTreeView.Nodes.Count; i++)
            {
                TreeNode floderNode = excelTreeView.Nodes[i];
                floderNode.Checked = true;
                for (int j = 0; j < excelTreeView.Nodes[i].Nodes.Count; j++)
                {
                    TreeNode treeNode = excelTreeView.Nodes[i].Nodes[j];
                    treeNode.Checked = true;
                }
            }
        }

        private void SetChildNodeCheckedState(TreeNode currNode, bool state)
        {
            TreeNodeCollection nodes = currNode.Nodes;
            if (nodes.Count > 0)
            {
                foreach (TreeNode tn in nodes)
                {
                    tn.Checked = state;
                    SetChildNodeCheckedState(tn, state);
                }
            }
        }

        private List<TreeNode> GetAllChooseNodes()
        {
            List<TreeNode> allChooseNodes = new List<TreeNode>();

            foreach (TreeNode commNodes in excelTreeView.Nodes)
            {
                for (int i = 0; i < commNodes.Nodes.Count; i++)
                {
                    if (commNodes.Nodes[i].Checked && commNodes.Nodes[i].Tag.ToString() == ExcelFileTag)
                    {
                        allChooseNodes.Add(commNodes.Nodes[i]);
                    }
                }
            }

            return allChooseNodes;
        }

        private List<FileInfo> GetAllSelectedNodeFiles()
        {
            List<FileInfo> fileInfos = new List<FileInfo>();

            for (int i = 0; i < excelTreeView.Nodes.Count; i++)
            {
                TreeNodeCollection FoldersNode = excelTreeView.Nodes[i].Nodes;
                foreach (TreeNode file in FoldersNode)
                {
                    if (file.Checked && allExcelFilesDic.ContainsKey(file.Text))
                        fileInfos.Add(allExcelFilesDic[file.Text]);
                }
            }

            return fileInfos;
        }
        #endregion


        #region 目录 操作
        private void ChooseExcelFolderBrowser(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            folderBrowser.Description = "选择配置表文件夹";

            string excelFolderBrowserPath;
            string logPath = Define.GetExcelConvertToolLogPath();
            bool isHaveExcelToolLog = GetCahceFloderInfo(CommonTool.LogMark.ExcelPathMark, out excelFolderBrowserPath);
            if (isHaveExcelToolLog)
                folderBrowser.SelectedPath = excelFolderBrowserPath;

            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                curChooseFolderBrowserInfo.Text = folderBrowser.SelectedPath;

                string mark = CommonTool.GetLogMark(CommonTool.LogMark.ExcelPathMark);
                CommonTool.WriteLog(mark + folderBrowser.SelectedPath, true, mark);

                ShowExcelTreeList();
            }
        }

        //private void XmlSavePathChooseBtn(object sender, EventArgs e)
        //{
        //    FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
        //    folderBrowser.Description = "选择xml 存储目录";

        //    string xmlFolderBrowserPath;
        //    bool filePath = GetCahceFloderInfo(CommonTool.LogMark.XmlOutputPathMark, out xmlFolderBrowserPath);
        //    if (filePath)
        //        folderBrowser.SelectedPath = xmlFolderBrowserPath;

        //    if (folderBrowser.ShowDialog() == DialogResult.OK)
        //    {
        //        saveXmlPath = folderBrowser.SelectedPath;
        //        curChooseXmlSavePathLable.Text = folderBrowser.SelectedPath;
        //        string mark = CommonTool.GetLogMark(CommonTool.LogMark.XmlOutputPathMark);
        //        CommonTool.WriteLog(mark + folderBrowser.SelectedPath,true, mark);
        //    }
        //}

        //private void CsSavePathChooseBtn(object sender, EventArgs e)
        //{
        //    FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
        //    folderBrowser.Description = "选择Cs 存储目录";

        //    string csFolderBrowserPath;
        //    bool filePath = GetCahceFloderInfo(CommonTool.LogMark.XmlOutputPathMark, out csFolderBrowserPath);
        //    if (filePath)
        //        folderBrowser.SelectedPath = csFolderBrowserPath;

        //    if (folderBrowser.ShowDialog() == DialogResult.OK)
        //    {
        //        saveCsPath = folderBrowser.SelectedPath;
        //        curChooseCsSavePath.Text = folderBrowser.SelectedPath;
        //        string mark = CommonTool.GetLogMark(CommonTool.LogMark.CsOutputPathMark);
        //        CommonTool.WriteLog(mark + folderBrowser.SelectedPath, true, mark);
        //    }
        //}

        bool GetCahceFloderInfo(CommonTool.LogMark logMark, out string outPath)
        {
            string excelToolLogPath = Define.GetExcelConvertToolLogPath();
            outPath = string.Empty;
            if (!File.Exists(excelToolLogPath))
                return false;

            string[] fileInfo = File.ReadAllLines(excelToolLogPath);
            if (fileInfo.Length == 0)
                return false;

            string logMarkStr = CommonTool.GetLogMark(logMark);
            outPath = getLogInfo(logMarkStr, fileInfo);

            if (outPath.Equals(string.Empty))
                return false;

            return true;
        }

        string getLogInfo(string keywork, string[] filesInfo)
        {
            for (int i = 0; i < filesInfo.Length; i++)
            {
                if (filesInfo[i].StartsWith(keywork))
                    return filesInfo[i].Replace(keywork, string.Empty);
            }

            return string.Empty;
        }

        private void TranslateBtn(object sender, EventArgs e)
        {
            List<FileInfo> fileInfos = GetAllSelectedNodeFiles();
            string s = string.Empty;

            for (int i = 0; i < fileInfos.Count; i++)
            {
                s = s + fileInfos[i].FullName + "\n";
            }

            logLable.Text = s;

            ExportManeger.ExportExcel(fileInfos, saveXmlPath, saveCsPath);
        }
        #endregion

        void ChooseSavePath(string saveType)
        {

        }

        private void excelTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void curChooseFolderBrowserInfo_TextChanged(object sender, EventArgs e)
        {

        }

        private void findBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
