
namespace ExcelConvertTool
{
    partial class ToolWindow
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.excelTreeView = new System.Windows.Forms.TreeView();
            this.curChooseFolderBrowserInfo = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.logLable = new System.Windows.Forms.RichTextBox();
            this.showChooseExcel = new System.Windows.Forms.ListBox();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.findBtn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.curChooseXmlSavePathLable = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.curChooseCsSavePath = new System.Windows.Forms.TextBox();
            this.exportPathChooseBtn = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // excelTreeView
            // 
            this.excelTreeView.Location = new System.Drawing.Point(16, 56);
            this.excelTreeView.Name = "excelTreeView";
            this.excelTreeView.Size = new System.Drawing.Size(243, 568);
            this.excelTreeView.TabIndex = 0;
            this.excelTreeView.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.OnClickExeclFile);
            this.excelTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.excelTreeView_AfterSelect);
            // 
            // curChooseFolderBrowserInfo
            // 
            this.curChooseFolderBrowserInfo.Cursor = System.Windows.Forms.Cursors.Default;
            this.curChooseFolderBrowserInfo.Location = new System.Drawing.Point(97, 22);
            this.curChooseFolderBrowserInfo.Name = "curChooseFolderBrowserInfo";
            this.curChooseFolderBrowserInfo.ReadOnly = true;
            this.curChooseFolderBrowserInfo.Size = new System.Drawing.Size(365, 21);
            this.curChooseFolderBrowserInfo.TabIndex = 1;
            this.curChooseFolderBrowserInfo.TextChanged += new System.EventHandler(this.curChooseFolderBrowserInfo_TextChanged);
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Default;
            this.button1.Location = new System.Drawing.Point(476, 22);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(53, 21);
            this.button1.TabIndex = 2;
            this.button1.Text = ">>";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Cursor = System.Windows.Forms.Cursors.Default;
            this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "Config Folder:";
            // 
            // logLable
            // 
            this.logLable.Location = new System.Drawing.Point(18, 92);
            this.logLable.Name = "logLable";
            this.logLable.Size = new System.Drawing.Size(554, 492);
            this.logLable.TabIndex = 4;
            this.logLable.Text = "";
            // 
            // showChooseExcel
            // 
            this.showChooseExcel.FormattingEnabled = true;
            this.showChooseExcel.ItemHeight = 12;
            this.showChooseExcel.Location = new System.Drawing.Point(265, 92);
            this.showChooseExcel.Name = "showChooseExcel";
            this.showChooseExcel.Size = new System.Drawing.Size(264, 532);
            this.showChooseExcel.TabIndex = 5;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(457, 601);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(115, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "Translate";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.TranslateBtn);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(265, 56);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(197, 21);
            this.textBox1.TabIndex = 7;
            // 
            // findBtn
            // 
            this.findBtn.Location = new System.Drawing.Point(476, 56);
            this.findBtn.Name = "findBtn";
            this.findBtn.Size = new System.Drawing.Size(53, 21);
            this.findBtn.TabIndex = 8;
            this.findBtn.Text = "搜索";
            this.findBtn.UseVisualStyleBackColor = true;
            this.findBtn.Click += new System.EventHandler(this.findBtn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.excelTreeView);
            this.groupBox1.Controls.Add(this.findBtn);
            this.groupBox1.Controls.Add(this.showChooseExcel);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.curChooseFolderBrowserInfo);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(14, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(547, 637);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Excel";
            // 
            // curChooseXmlSavePathLable
            // 
            this.curChooseXmlSavePathLable.Cursor = System.Windows.Forms.Cursors.Default;
            this.curChooseXmlSavePathLable.Location = new System.Drawing.Point(108, 20);
            this.curChooseXmlSavePathLable.Name = "curChooseXmlSavePathLable";
            this.curChooseXmlSavePathLable.ReadOnly = true;
            this.curChooseXmlSavePathLable.Size = new System.Drawing.Size(405, 21);
            this.curChooseXmlSavePathLable.TabIndex = 9;
            this.curChooseXmlSavePathLable.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Cursor = System.Windows.Forms.Cursors.Default;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 9;
            this.label1.Text = "Xml Save Path:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.curChooseCsSavePath);
            this.groupBox2.Controls.Add(this.exportPathChooseBtn);
            this.groupBox2.Controls.Add(this.logLable);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.curChooseXmlSavePathLable);
            this.groupBox2.Location = new System.Drawing.Point(583, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(589, 637);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Export";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(322, 601);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(115, 23);
            this.button4.TabIndex = 15;
            this.button4.Text = "全选";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.ChooseAllNode);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.Cursor = System.Windows.Forms.Cursors.Default;
            this.label3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(16, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 12);
            this.label3.TabIndex = 14;
            this.label3.Text = "Cs. Save Path:";
            // 
            // button3
            // 
            this.button3.Cursor = System.Windows.Forms.Cursors.Default;
            this.button3.Location = new System.Drawing.Point(519, 55);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(53, 21);
            this.button3.TabIndex = 13;
            this.button3.Text = ">>";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // curChooseCsSavePath
            // 
            this.curChooseCsSavePath.Cursor = System.Windows.Forms.Cursors.Default;
            this.curChooseCsSavePath.Location = new System.Drawing.Point(108, 56);
            this.curChooseCsSavePath.Name = "curChooseCsSavePath";
            this.curChooseCsSavePath.ReadOnly = true;
            this.curChooseCsSavePath.Size = new System.Drawing.Size(405, 21);
            this.curChooseCsSavePath.TabIndex = 12;
            this.curChooseCsSavePath.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // exportPathChooseBtn
            // 
            this.exportPathChooseBtn.Cursor = System.Windows.Forms.Cursors.Default;
            this.exportPathChooseBtn.Location = new System.Drawing.Point(519, 20);
            this.exportPathChooseBtn.Name = "exportPathChooseBtn";
            this.exportPathChooseBtn.Size = new System.Drawing.Size(53, 21);
            this.exportPathChooseBtn.TabIndex = 9;
            this.exportPathChooseBtn.Text = ">>";
            this.exportPathChooseBtn.UseVisualStyleBackColor = true;
            // 
            // ToolWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1184, 661);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "ToolWindow";
            this.Text = "ExcelConvertTool";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView excelTreeView;
        private System.Windows.Forms.TextBox curChooseFolderBrowserInfo;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox logLable;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ListBox showChooseExcel;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button findBtn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox curChooseXmlSavePathLable;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button exportPathChooseBtn;
        private System.Windows.Forms.TextBox curChooseCsSavePath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
    }
}

