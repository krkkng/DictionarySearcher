using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace DictionarySearcher
{
    public partial class Form1 : Form
    {
        private ClipboardViewer.MyClipboardViewer cpviewer;
            
        public List<HistoryItem> History { get; set; }
        public string PrevCripboardString { get; set; } // 一つ前のクリップボード履歴を格納
        public Form1()
        {
            InitializeComponent();
            History = Serializer.DeSerialize();
            if(History == null)
                History = new List<HistoryItem>();
            SetListbox();
            cpviewer = new ClipboardViewer.MyClipboardViewer(this);
            cpviewer.ClipboardHandler += Cpviewer_ClipboardHandler;
        }

        private void Cpviewer_ClipboardHandler(object sender, ClipboardViewer.ClipboardEventArgs ev)
        {
            if (chkClipboard.Checked)
            {
                if (ev.Text != PrevCripboardString)
                {
                    PrevCripboardString = ev.Text;
                    textBox1.Text = ev.Text;
                    button1.PerformClick();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text)) return;
            var history = new HistoryItem();
            history.History = textBox1.Text;
            var Tmp = History.FirstOrDefault(t => t.History == history.History);
            if( Tmp != null)
            {
                Tmp.Count += 1;
                History.Remove(Tmp);
                History.Add(Tmp);
            }
            else
            {
                History.Add(history);
            }
            SetListbox();
            isnavigating1 = false;
            isnavigating2 = false;
            isnavigating3 = false;
            tabControl1.TabPages[0].Text = "Weblio";
            tabControl1.TabPages[1].Text = "英辞郎";
            tabControl1.TabPages[2].Text = "goo辞書";
            NavigateSelector();
            Application.DoEvents();
        }

        private void SetListbox()
        {
            List<HistoryItem> CopyHistory = new List<HistoryItem>(History);
            lstHistory.Items.Clear();
            CopyHistory.Reverse();
            lstHistory.Items.AddRange(CopyHistory.Distinct().ToArray());//(History.Reverse().ToArray()).Distinct().ToArray());
        }

        private void textBox1_Validated(object sender, EventArgs e)
        {
            button1.PerformClick();
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                button1.PerformClick();
            }
            if(e.KeyData == Keys.Escape)
            {
                textBox1.SelectAll();
            }

            if (e.KeyCode == Keys.Right && e.Alt)
            {
                tabControl1.SelectedIndex = tabControl1.SelectedIndex + 1 < tabControl1.TabCount ? tabControl1.SelectedIndex + 1 : tabControl1.TabCount - 1;// Math.Abs((tabControl1.SelectedIndex + 1) % (tabControl1.TabCount));
                textBox1.Focus();
            }
            if (e.KeyCode == Keys.Left && e.Alt)
            {
                tabControl1.SelectedIndex = tabControl1.SelectedIndex - 1 >= 0 ? tabControl1.SelectedIndex - 1 : 0;
                textBox1.Focus();
            }

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            try
            {
                var w = (mshtml.IHTMLWindow2)extendedWebBrowser1.Document.Window.DomWindow;
                var s = (mshtml.IHTMLScreen2)w.screen;
                int zoom = s.deviceXDPI * 100 / 96;

                zoom += 10;
                ((SHDocVw.WebBrowser)extendedWebBrowser1.ActiveXInstance).ExecWB(SHDocVw.OLECMDID.OLECMDID_OPTICAL_ZOOM, SHDocVw.OLECMDEXECOPT.OLECMDEXECOPT_DONTPROMPTUSER, zoom, IntPtr.Zero);
            }
            catch
            {

            }

        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            var w = (mshtml.IHTMLWindow2)extendedWebBrowser1.Document.Window.DomWindow;
            var s = (mshtml.IHTMLScreen2)w.screen;
            int zoom = s.deviceXDPI * 100 / 96;

            zoom -= 10;
            ((SHDocVw.WebBrowser)extendedWebBrowser1.ActiveXInstance).ExecWB(SHDocVw.OLECMDID.OLECMDID_OPTICAL_ZOOM, SHDocVw.OLECMDEXECOPT.OLECMDEXECOPT_DONTPROMPTUSER, zoom, IntPtr.Zero);

        }

        private void btnNormal_Click(object sender, EventArgs e)
        {
            var zoom = 100;
            ((SHDocVw.WebBrowser)extendedWebBrowser1.ActiveXInstance).ExecWB(SHDocVw.OLECMDID.OLECMDID_OPTICAL_ZOOM, SHDocVw.OLECMDEXECOPT.OLECMDEXECOPT_DONTPROMPTUSER, zoom, IntPtr.Zero);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            TopMost = true;
            SetRegKey.SetValue();

            panel1.Height = textBox1.Height;

            // Hookを有効にする
            MMFrame.Windows.GlobalHook.KeyboardHook.AddEvent(hookKeyboard);
            MMFrame.Windows.GlobalHook.KeyboardHook.Start();

            // WebBrowserの初期設定
            extendedWebBrowser1.ScriptErrorsSuppressed = true;
            extendedWebBrowser2.ScriptErrorsSuppressed = true;
            extendedWebBrowser3.ScriptErrorsSuppressed = true;

        }

        void hookKeyboard(ref MMFrame.Windows.GlobalHook.KeyboardHook.StateKeyboard s)
        {
            if (s.Stroke == MMFrame.Windows.GlobalHook.KeyboardHook.Stroke.KEY_UP && s.Key == Keys.Escape)
            {
                Activate();
                var xx = MousePosition.X;
                var yy = MousePosition.Y;

                Cursor.Position = new Point(this.Left + 50, this.Top + 50);

                var inputs = new List<MMFrame.Windows.Simulation.InputSimulator.Input>();
                var flags = new List<MMFrame.Windows.Simulation.InputSimulator.MouseStroke>();

                flags.Add(MMFrame.Windows.Simulation.InputSimulator.MouseStroke.LEFT_DOWN);
                flags.Add(MMFrame.Windows.Simulation.InputSimulator.MouseStroke.LEFT_UP);
                MMFrame.Windows.Simulation.InputSimulator.AddMouseInput(ref inputs, flags, 0, false, 0, 0);
                MMFrame.Windows.Simulation.InputSimulator.SendInput(inputs);

                Cursor.Position = new Point(xx, yy);
            }
        }
        private void lstHistory_DoubleClick(object sender, EventArgs e)
        {
            textBox1.Text = (lstHistory.SelectedItem as HistoryItem).History;
            button1.PerformClick();
        }

        private void navigateComplete()
        {
            if (isnavigating1 && isnavigating2 && isnavigating3)
            {
                Cursor = Cursors.Arrow;
                lblInfo.Text = "完了";
            }

        }
        bool isnavigating1 = false;
        bool isnavigating2 = false;
        bool isnavigating3 = false;
       


        private void extendedWebBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            isnavigating1 = true;
            tabControl1.TabPages[0].Text = "Weblio(完了)";
            lblInfo.Text = "完了";
        }

        private void extendedWebBrowser2_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            isnavigating2 = true;
            tabControl1.TabPages[1].Text = "英辞郎(完了)";
            lblInfo.Text = "完了";
        }

        private void extendedWebBrowser3_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            isnavigating3 = true;
            tabControl1.TabPages[2].Text = "goo辞書(完了)";
            lblInfo.Text = "完了";
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            //if (e.KeyData == Keys.Escape)
            //{
            //    textBox1.Focus();
            //}
        }

        private void extendedWebBrowser1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            //if(e.KeyData == Keys.Escape)
            //    textBox1.Focus();
            if (e.KeyCode == Keys.Right && e.Alt)
            {
                //tabControl1.SelectedIndex = tabControl1.SelectedIndex + 1 < tabControl1.TabCount ? tabControl1.SelectedIndex + 1 : tabControl1.TabCount - 1;// Math.Abs((tabControl1.SelectedIndex + 1) % (tabControl1.TabCount));
                textBox1.Focus();
            }
            if (e.KeyCode == Keys.Left && e.Alt)
            {
                //tabControl1.SelectedIndex = tabControl1.SelectedIndex - 1 >= 0 ? tabControl1.SelectedIndex - 1 : 0;
                textBox1.Focus();
            }

        }

        private void extendedWebBrowser2_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            //if (e.KeyData == Keys.Escape)
            //    textBox1.Focus();
            if (e.KeyCode == Keys.Right && e.Alt)
            {
                //tabControl1.SelectedIndex = tabControl1.SelectedIndex + 1 < tabControl1.TabCount ? tabControl1.SelectedIndex + 1 : tabControl1.TabCount - 1;// Math.Abs((tabControl1.SelectedIndex + 1) % (tabControl1.TabCount));
                textBox1.Focus();
            }
            if (e.KeyCode == Keys.Left && e.Alt)
            {
                //tabControl1.SelectedIndex = tabControl1.SelectedIndex - 1 >= 0 ? tabControl1.SelectedIndex - 1 : 0;
                textBox1.Focus();
            }

        }
        private void extendedWebBrowser3_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            //if (e.KeyData == Keys.Escape)
            //    textBox1.Focus();
            if (e.KeyCode == Keys.Right && e.Alt)
            {
                //tabControl1.SelectedIndex = tabControl1.SelectedIndex + 1 < tabControl1.TabCount ? tabControl1.SelectedIndex + 1 : tabControl1.TabCount - 1;// Math.Abs((tabControl1.SelectedIndex + 1) % (tabControl1.TabCount));
                textBox1.Focus();
            }
            if (e.KeyCode == Keys.Left && e.Alt)
            {
                //tabControl1.SelectedIndex = tabControl1.SelectedIndex - 1 >= 0 ? tabControl1.SelectedIndex - 1 : 0;
                textBox1.Focus();
            }

        }

        private void lstHistory_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            //if (e.KeyData == Keys.Escape)
            //    textBox1.Focus();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Serializer.Serialize(History);

            // Hookを無効にする
            if (MMFrame.Windows.GlobalHook.KeyboardHook.IsHooking)
                MMFrame.Windows.GlobalHook.KeyboardHook.Stop();
        }

        private void chkClipboard_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            NavigateSelector();

            
        }
        private void NavigateSelector()
        {
            if (tabControl1.SelectedIndex == 0 && !isnavigating1)
            {
                tabControl1.TabPages[0].Text = "Weblio(読込中...)";
                string url1 = "http://ejje.weblio.jp/content/" + textBox1.Text;
                extendedWebBrowser1.Navigate(url1);


            }
            else if (tabControl1.SelectedIndex == 1 && !isnavigating2)
            {
                 tabControl1.TabPages[1].Text = "英辞郎(読込中...)";
               System.Text.Encoding enc = System.Text.Encoding.GetEncoding("utf-8");
                string urlEnc = System.Web.HttpUtility.UrlEncode(textBox1.Text, enc);
                string url2 = "http://eowf.alc.co.jp/search?q=" + urlEnc;// + "&ref=sa";
                extendedWebBrowser2.Navigate(url2);
            }
            else if (tabControl1.SelectedIndex == 2 && !isnavigating3)
            {
                tabControl1.TabPages[2].Text = "goo辞書(読み込み中...)";
                string url3 = "https://dictionary.goo.ne.jp/srch/en/" + textBox1.Text + "/m0u/";
                extendedWebBrowser3.Navigate(url3);

            }

        }

    }
}
