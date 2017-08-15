using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;

///
/// Extended WebBrowser Control to suppress script-errors correctly
/// Refer to http://osexpert.blog.com/2011/09/14/net-webbrowser-and-scripterrorssuppressed/
/// 
namespace WebBrowserApp
{
    ///
    /// Based on http://support.microsoft.com/kb/261003
    ///
    public partial class ExtendedWebBrowser : WebBrowser
    {
        protected class ExtendedWebBrowserSite : WebBrowserSite, IOleCommandTarget
        {
            const int OLECMDID_SHOWSCRIPTERROR = 40;

            static Guid CGID_DocHostCommandHandler = new Guid("F38BC242-B950-11D1-8918-00C04FC2C836");

            const int S_OK = 0;
            const int OLECMDERR_E_NOTSUPPORTED = -2147221248;

            private ExtendedWebBrowser parent = null;

            public ExtendedWebBrowserSite(ExtendedWebBrowser wb) : base(wb)
            {
                parent = wb;
            }

            #region IOleCommandTarget Members
            public int QueryStatus(Guid pguidCmdGroup, int cCmds, IntPtr prgCmds, IntPtr pCmdText)
            {
                return OLECMDERR_E_NOTSUPPORTED;
            }

            public int Exec(Guid pguidCmdGroup, int nCmdID, int nCmdexecopt, IntPtr pvaIn, IntPtr pvaOut)
            {
                if (parent._scriptErrorsSuppressed && pguidCmdGroup == CGID_DocHostCommandHandler)
                {
                    if (nCmdID == OLECMDID_SHOWSCRIPTERROR)
                    {
                        // do not need to alter pvaOut as the docs says, enough to return S_OK here
                        return S_OK;
                    }
                }

                return OLECMDERR_E_NOTSUPPORTED;
            }
            #endregion
        }

        #region ExtenededWebBrowser Properties
        // override base.ScriptErrorsSuppressed property for bug-fix
        public bool _scriptErrorsSuppressed = false;
        public new bool ScriptErrorsSuppressed
        {
            get { return _scriptErrorsSuppressed; }
            set { _scriptErrorsSuppressed = value; }
        }

        // remapped base.ScriptErrorsSuppressed to this.Silent property(correspond to IWebBrowser2.Silent)
        public bool Silent
        {
            get { return base.ScriptErrorsSuppressed; }
            set { base.ScriptErrorsSuppressed = value; }
        }
        #endregion

        protected override WebBrowserSiteBase CreateWebBrowserSiteBase()
        {
            return new ExtendedWebBrowserSite(this);
        }

        public ExtendedWebBrowser()
        {
            InitializeComponent();
        }

        #region Unfortunately, this famous workaround does not any effect on the script error...
        //protected override void OnDocumentCompleted(WebBrowserDocumentCompletedEventArgs e)
        //{
        //    if (_scriptErrorsSuppressed)
        //    {
        //        base.Document.Window.Error += new HtmlElementErrorEventHandler(WindowError);
        //    }

        //    base.OnDocumentCompleted(e);
        //}

        //private void WindowError(object sender, HtmlElementErrorEventArgs e)
        //{
        //    // ignore this error to suppress the error dialog
        //    e.Handled = true;
        //}
        #endregion
    }

    [ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), ComVisible(true),
    Guid("B722BCCB-4E68-101B-A2BC-00AA00404770")]
    public interface IOleCommandTarget
    {
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int QueryStatus([In, MarshalAs(UnmanagedType.LPStruct)] Guid pguidCmdGroup,
          int cCmds,
          IntPtr prgCmds,
          IntPtr pCmdText);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int Exec([In, MarshalAs(UnmanagedType.LPStruct)] Guid pguidCmdGroup,
          int nCmdID,
          int nCmdexecopt,
          IntPtr pvaIn,
          IntPtr pvaOut);
    }
}

namespace WebBrowserApp
{
    partial class ExtendedWebBrowser
    {
        /// <summary> 
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region コンポーネント デザイナーで生成されたコード

        /// <summary> 
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
        }

        #endregion
    }
}