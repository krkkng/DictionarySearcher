namespace DictionarySearcher
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chkClipboard = new System.Windows.Forms.CheckBox();
            this.lblInfo = new System.Windows.Forms.Label();
            this.btnNormal = new System.Windows.Forms.Button();
            this.btnMinus = new System.Windows.Forms.Button();
            this.btnPlus = new System.Windows.Forms.Button();
            this.lstHistory = new System.Windows.Forms.ListBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.extendedWebBrowser1 = new WebBrowserApp.ExtendedWebBrowser();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.extendedWebBrowser2 = new WebBrowserApp.ExtendedWebBrowser();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.extendedWebBrowser3 = new WebBrowserApp.ExtendedWebBrowser();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(547, 23);
            this.panel1.TabIndex = 6;
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Font = new System.Drawing.Font("メイリオ", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBox1.Location = new System.Drawing.Point(0, 0);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(509, 39);
            this.textBox1.TabIndex = 3;
            this.textBox1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyUp);
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Right;
            this.button1.Location = new System.Drawing.Point(509, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(38, 23);
            this.button1.TabIndex = 4;
            this.button1.TabStop = false;
            this.button1.Text = "go";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.chkClipboard);
            this.panel2.Controls.Add(this.lblInfo);
            this.panel2.Controls.Add(this.btnNormal);
            this.panel2.Controls.Add(this.btnMinus);
            this.panel2.Controls.Add(this.btnPlus);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 865);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(547, 29);
            this.panel2.TabIndex = 7;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // chkClipboard
            // 
            this.chkClipboard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkClipboard.AutoSize = true;
            this.chkClipboard.Location = new System.Drawing.Point(280, 7);
            this.chkClipboard.Name = "chkClipboard";
            this.chkClipboard.Size = new System.Drawing.Size(117, 16);
            this.chkClipboard.TabIndex = 10;
            this.chkClipboard.TabStop = false;
            this.chkClipboard.Text = "クリップボードを監視";
            this.chkClipboard.UseVisualStyleBackColor = true;
            this.chkClipboard.CheckedChanged += new System.EventHandler(this.chkClipboard_CheckedChanged);
            // 
            // lblInfo
            // 
            this.lblInfo.Location = new System.Drawing.Point(12, 8);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(370, 12);
            this.lblInfo.TabIndex = 9;
            this.lblInfo.Text = "完了";
            // 
            // btnNormal
            // 
            this.btnNormal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNormal.Location = new System.Drawing.Point(452, 3);
            this.btnNormal.Name = "btnNormal";
            this.btnNormal.Size = new System.Drawing.Size(43, 23);
            this.btnNormal.TabIndex = 8;
            this.btnNormal.TabStop = false;
            this.btnNormal.Text = "○";
            this.btnNormal.UseVisualStyleBackColor = true;
            this.btnNormal.Click += new System.EventHandler(this.btnNormal_Click);
            // 
            // btnMinus
            // 
            this.btnMinus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinus.Location = new System.Drawing.Point(501, 3);
            this.btnMinus.Name = "btnMinus";
            this.btnMinus.Size = new System.Drawing.Size(43, 23);
            this.btnMinus.TabIndex = 7;
            this.btnMinus.TabStop = false;
            this.btnMinus.Text = "－";
            this.btnMinus.UseVisualStyleBackColor = true;
            this.btnMinus.Click += new System.EventHandler(this.btnMinus_Click);
            // 
            // btnPlus
            // 
            this.btnPlus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPlus.Location = new System.Drawing.Point(403, 3);
            this.btnPlus.Name = "btnPlus";
            this.btnPlus.Size = new System.Drawing.Size(43, 23);
            this.btnPlus.TabIndex = 6;
            this.btnPlus.TabStop = false;
            this.btnPlus.Text = "＋";
            this.btnPlus.UseVisualStyleBackColor = true;
            this.btnPlus.Click += new System.EventHandler(this.btnPlus_Click);
            // 
            // lstHistory
            // 
            this.lstHistory.Dock = System.Windows.Forms.DockStyle.Left;
            this.lstHistory.FormattingEnabled = true;
            this.lstHistory.ItemHeight = 12;
            this.lstHistory.Location = new System.Drawing.Point(0, 23);
            this.lstHistory.Name = "lstHistory";
            this.lstHistory.Size = new System.Drawing.Size(131, 842);
            this.lstHistory.TabIndex = 8;
            this.lstHistory.TabStop = false;
            this.lstHistory.DoubleClick += new System.EventHandler(this.lstHistory_DoubleClick);
            this.lstHistory.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.lstHistory_PreviewKeyDown);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(131, 23);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 842);
            this.splitter1.TabIndex = 9;
            this.splitter1.TabStop = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(134, 23);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(413, 842);
            this.tabControl1.TabIndex = 10;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.extendedWebBrowser1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(405, 816);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Weblio";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // extendedWebBrowser1
            // 
            this.extendedWebBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.extendedWebBrowser1.Location = new System.Drawing.Point(3, 3);
            this.extendedWebBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.extendedWebBrowser1.Name = "extendedWebBrowser1";
            this.extendedWebBrowser1.Silent = false;
            this.extendedWebBrowser1.Size = new System.Drawing.Size(399, 810);
            this.extendedWebBrowser1.TabIndex = 4;
            this.extendedWebBrowser1.TabStop = false;
            this.extendedWebBrowser1.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.extendedWebBrowser1_DocumentCompleted);
            this.extendedWebBrowser1.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.extendedWebBrowser1_PreviewKeyDown);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.extendedWebBrowser2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(405, 816);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "英辞郎";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // extendedWebBrowser2
            // 
            this.extendedWebBrowser2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.extendedWebBrowser2.Location = new System.Drawing.Point(3, 3);
            this.extendedWebBrowser2.MinimumSize = new System.Drawing.Size(20, 20);
            this.extendedWebBrowser2.Name = "extendedWebBrowser2";
            this.extendedWebBrowser2.Silent = false;
            this.extendedWebBrowser2.Size = new System.Drawing.Size(399, 810);
            this.extendedWebBrowser2.TabIndex = 0;
            this.extendedWebBrowser2.TabStop = false;
            this.extendedWebBrowser2.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.extendedWebBrowser2_DocumentCompleted);
            this.extendedWebBrowser2.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.extendedWebBrowser2_PreviewKeyDown);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.extendedWebBrowser3);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(405, 816);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "goo 辞書";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // extendedWebBrowser3
            // 
            this.extendedWebBrowser3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.extendedWebBrowser3.Location = new System.Drawing.Point(0, 0);
            this.extendedWebBrowser3.MinimumSize = new System.Drawing.Size(20, 20);
            this.extendedWebBrowser3.Name = "extendedWebBrowser3";
            this.extendedWebBrowser3.Silent = false;
            this.extendedWebBrowser3.Size = new System.Drawing.Size(405, 816);
            this.extendedWebBrowser3.TabIndex = 0;
            this.extendedWebBrowser3.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.extendedWebBrowser3_DocumentCompleted);
            this.extendedWebBrowser3.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.extendedWebBrowser3_PreviewKeyDown);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 894);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.lstHistory);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "DictionarySearcher";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnMinus;
        private System.Windows.Forms.Button btnPlus;
        private System.Windows.Forms.Button btnNormal;
        private System.Windows.Forms.ListBox lstHistory;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private WebBrowserApp.ExtendedWebBrowser extendedWebBrowser1;
        private System.Windows.Forms.TabPage tabPage2;
        private WebBrowserApp.ExtendedWebBrowser extendedWebBrowser2;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.CheckBox chkClipboard;
        private System.Windows.Forms.TabPage tabPage3;
        private WebBrowserApp.ExtendedWebBrowser extendedWebBrowser3;
    }
}

