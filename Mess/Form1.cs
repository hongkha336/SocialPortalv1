using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;
namespace Mess
{
    public partial class Form1 : Form
    {
        public ChromiumWebBrowser browserMess;
        public ChromiumWebBrowser browserSkype;
        public ChromiumWebBrowser browserOutLook;
        public ChromiumWebBrowser browserZalo;
        public ChromiumWebBrowser browserGmail;
        public Form1()
        {
            InitializeComponent();
            InitBrowser();
        }
        public void InitBrowser()
        {
            CefSettings settings = new CefSettings();
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Cookies);
            settings.RemoteDebuggingPort = 8080;
            settings.CachePath = path;
            //Initialize Cef with the provided settings
            Cef.Initialize(settings);



            browserMess = new ChromiumWebBrowser("www.messenger.com");
            tabPage3.Controls.Add(browserMess);
            browserMess.Dock = DockStyle.Fill;

            browserSkype = new ChromiumWebBrowser("https://web.skype.com/");
            tabPage2.Controls.Add(browserSkype);
            browserSkype.Dock = DockStyle.Fill;

            browserOutLook = new ChromiumWebBrowser("https://outlook.live.com/mail/0/inbox");
            tabPage1.Controls.Add(browserOutLook);
            browserOutLook.Dock = DockStyle.Fill;

            browserZalo = new ChromiumWebBrowser("https://chat.zalo.me/");
            tabPage4.Controls.Add(browserZalo);
            browserZalo.Dock = DockStyle.Fill;

            browserGmail = new ChromiumWebBrowser("https://gmail.google.com/");
            tabPage5.Controls.Add(browserGmail);
            browserGmail.Dock = DockStyle.Fill;


        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Cef.Shutdown();
        }


        TabPage activeTab;

        private void timer1_Tick(object sender, EventArgs e)
        {
            activeTab = tabControl1.SelectedTab;
            activeTab.Focus();
        }
    }
}
