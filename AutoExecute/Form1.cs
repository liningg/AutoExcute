using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace AutoExecute
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// 设置目标窗体大小，位置
        /// </summary>
        /// <param name="hWnd">目标句柄</param>
        /// <param name="x">目标窗体新位置X轴坐标</param>
        /// <param name="y">目标窗体新位置Y轴坐标</param>
        /// <param name="nWidth">目标窗体新宽度</param>
        /// <param name="nHeight">目标窗体新高度</param>
        /// <param name="BRePaint">是否刷新窗体</param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int MoveWindow(IntPtr hWnd, int x, int y, int nWidth, int nHeight, bool BRePaint);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int x, int y, int Width, int Height, int flags);
        //Win32 API函数  
        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        private static extern int SendMessage(int hWnd, int Msg, int wParam, ref COPYDATASTRUCT lParam);

        [DllImport("User32.dll", EntryPoint = "FindWindow")]
        private static extern int FindWindow(string lpClassName, string lpWindowName);
        const int WM_COPYDATA = 0x004A;
        /// <summary>   
        /// 设置鼠标的坐标   
        /// </summary>   
        /// <param name="x">横坐标</param>   
        /// <param name="y">纵坐标</param>   
        [DllImport("User32")]
        public extern static void SetCursorPos(int x, int y);

        /// <summary>   
        /// 获取鼠标的坐标   
        /// </summary>   
        /// <param name="lpPoint">传址参数，坐标point类型</param>   
        /// <returns>获取成功返回真</returns>   
        [DllImport("User32")]
        public extern static bool GetCursorPos(ref Point lpPoint);
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        private static extern int mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);
        [System.Runtime.InteropServices.DllImport("user32.dll", EntryPoint = "SetForegroundWindow")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);//设置此窗体为活动窗体
        const int MOUSEEVENTF_MOVE = 0x0001;      //移动鼠标 
        const int MOUSEEVENTF_LEFTDOWN = 0x0002; //模拟鼠标左键按下 
        const int MOUSEEVENTF_LEFTUP = 0x0004; //模拟鼠标左键抬起 
        const int MOUSEEVENTF_RIGHTDOWN = 0x0008; //模拟鼠标右键按下 
        const int MOUSEEVENTF_RIGHTUP = 0x0010; //模拟鼠标右键抬起 
        const int MOUSEEVENTF_MIDDLEDOWN = 0x0020; //模拟鼠标中键按下 
        const int MOUSEEVENTF_MIDDLEUP = 0x0040; //模拟鼠标中键抬起 
        const int MOUSEEVENTF_ABSOLUTE = 0x8000; //标示是否采用绝对坐标 
        MouseHook mouseHook = new MouseHook();
        KeyboardHook keyboardHook = new KeyboardHook();
        JObject config = new JObject();
        JObject operation = new JObject();
        JArray operEvent = new JArray();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            mouseHook.MouseMove += new MouseEventHandler(mouseHook_MouseMove);
            mouseHook.MouseDown += new MouseEventHandler(mouseHook_MouseDown);
            mouseHook.MouseUp += new MouseEventHandler(mouseHook_MouseUp);
            mouseHook.MouseWheel += new MouseEventHandler(mouseHook_MouseWheel);

            keyboardHook.KeyDown += new KeyEventHandler(keyboardHook_KeyDown);
            keyboardHook.KeyUp += new KeyEventHandler(keyboardHook_KeyUp);
            keyboardHook.KeyPress += new KeyPressEventHandler(keyboardHook_KeyPress);

            config = JObject.Parse(File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "config.json"));
            operation = JObject.Parse(File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory  + "event.json"));

            //隐藏窗体
            //this.WindowState = FormWindowState.Minimized;
        }

        private void buttonStartRecord_Click(object sender, EventArgs e)
        {
            mouseHook.Start();
            keyboardHook.Start();
            ((JArray)operation["Event"]).Clear();
        }
        void keyboardHook_KeyPress(object sender, KeyPressEventArgs e)
        {

            AddKeyboardEvent(
                "KeyPress",
                "",
                e.KeyChar.ToString(),
                "",
                "",
                ""
                );

        }

        void keyboardHook_KeyUp(object sender, KeyEventArgs e)
        {

            AddKeyboardEvent(
                "KeyUp",
                e.KeyCode.ToString(),
                "",
                e.Shift.ToString(),
                e.Alt.ToString(),
                e.Control.ToString()
                );

        }

        void keyboardHook_KeyDown(object sender, KeyEventArgs e)
        {
            AddKeyboardEvent(
                "KeyDown",
                e.KeyCode.ToString(),
                "",
                e.Shift.ToString(),
                e.Alt.ToString(),
                e.Control.ToString()
                );

        }

        void mouseHook_MouseWheel(object sender, MouseEventArgs e)
        {

            AddMouseEvent(
                "MouseWheel",
                "",
                "",
                "",
                e.Delta.ToString()
                );

        }

        void mouseHook_MouseUp(object sender, MouseEventArgs e)
        {


            AddMouseEvent(
                "MouseUp",
                e.Button.ToString(),
                e.X.ToString(),
                e.Y.ToString(),
                ""
                );

        }

        void mouseHook_MouseDown(object sender, MouseEventArgs e)
        {
            AddMouseEvent(
                "MouseDown",
                e.Button.ToString(),
                e.X.ToString(),
                e.Y.ToString(),
                ""
                );
            AddEvent(e.X, e.Y, e.Button.ToString(), "");
        }

        void mouseHook_MouseMove(object sender, MouseEventArgs e)
        {

            SetXYLabel(e.X, e.Y);

        }

        void AddEvent(int x,int y,string mouse,string key)
        {
            JObject o = new JObject();
            o["x"] = x;
            o["y"] = y;
            o["mouse"] = mouse;
            ((JArray)(operation["Event"])).Add(o);
        }
        void SetXYLabel(int x, int y)
        {

            labelPosTip.Text = String.Format("Current Mouse Point: X={0}, y={1}", x, y);

        }

        void AddMouseEvent(string eventType, string button, string x, string y, string delta)
        {
            listView1.Items.Insert(0,
                new ListViewItem(
                    new string[]{
                        eventType,
                        button,
                        x,
                        y,
                        delta
                    }));

        }

        void AddKeyboardEvent(string eventType, string keyCode, string keyChar, string shift, string alt, string control)
        {

            listView2.Items.Insert(0,
                 new ListViewItem(
                     new string[]{
                        eventType,
                        keyCode,
                        keyChar,
                        shift,
                        alt,
                        control
                }));

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            mouseHook.Stop();
            keyboardHook.Stop();
        }

        private void buttonStopRecord_Click(object sender, EventArgs e)
        {
            mouseHook.Stop();
            keyboardHook.Stop();
            int count = ((JArray)(operation["Event"])).Count;
            if(count >0)
            {
                ((JArray)(operation["Event"])).RemoveAt(count - 1);
            }
            
            File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory  + "event.json",JsonConvert.SerializeObject(operation));
        }
      
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetWindowRect(IntPtr hWnd, ref RECT lpRect);

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left;                             //最左坐标
            public int Top;                             //最上坐标
            public int Right;                           //最右坐标
            public int Bottom;                        //最下坐标
        }
        [DllImport("user32.dll", EntryPoint = "ShowWindow", CharSet = CharSet.Auto)]
        public static extern int ShowWindow(IntPtr hwnd, int nCmdShow);
        const int SW_HIDE = 0;
        const int SW_SHOWNORMAL = 1;

        const int SW_SHOWMINIMIZED = 2;
        const int SW_SHOWMAXIMIZED = 3;
        const int SW_MAXIMIZE = 3;
        const int SW_SHOWNOACTIVATE = 4;
        const int SW_SHOW = 5;
        const int SW_MINIMIZE = 6;
        const int SW_SHOWMINNOACTIVE = 7;
        const int SW_SHOWNA = 8;
        const int SW_RESTORE = 9;

        private IntPtr getWindow(string name)
        {
            IntPtr windowHandle = new IntPtr(0);
            Process[] processes = Process.GetProcessesByName(name);
            foreach (Process p in processes)
            {
                windowHandle = p.MainWindowHandle;
                //do something with windowHandle
                break;
            }
            return windowHandle;
        }
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int BringWindowToTop(IntPtr hWnd);
        private bool doWindow()
        {
            bool ret = false;
            //int hWnd = FindWindow(null, config["ProcessName"].ToString());
            int hWnd = getWindow(config["ProcessName"].ToString()).ToInt32();
            if (hWnd != 0)
            {
                int x = Convert.ToInt32(config["StartPostion"].ToString().Split(',')[0]);
                int y = Convert.ToInt32(config["StartPostion"].ToString().Split(',')[1]);
                ShowWindow((IntPtr)hWnd, SW_MINIMIZE);
                ShowWindow((IntPtr)hWnd, SW_SHOWNORMAL);
                RECT rect = new RECT();
                GetWindowRect((IntPtr)hWnd, ref rect);
                MoveWindow((IntPtr)hWnd, x, y, rect.Right - rect.Left, rect.Bottom - rect.Top, false);
                SetForegroundWindow((IntPtr)hWnd);
                //BringWindowToTop((IntPtr)hWnd);
                ret = true;
            }
            else
            {
                LogClass.WriteLogFile("doWindow:没有找到窗体");
            }
            return ret;
        }
        private void doMessage()
        {
            JObject o = JObject.Parse(File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory  + "event.json"));
            JArray array = (JArray)o["Event"];
            int delay = Convert.ToInt32(config["DelayTime"].ToString());
            foreach (JToken token in array)
            {
                try
                {
                    int x = Convert.ToInt32(token["x"]);
                    int y = Convert.ToInt32(token["y"]);
                    string mouse = token["mouse"].ToString();
                    //string key = token["key"].ToString();

                    SetCursorPos(x, y);
                    Thread.Sleep(delay);
                    if (!string.IsNullOrEmpty(mouse))
                    {
                        mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, x, y, 0, 0);
                    }

                }
                catch (Exception ex)
                {
                    LogClass.WriteLogFile("doMessage:" + ex.Message);
                }
                Thread.Sleep(delay);


            }
        }
        private void doWork()
        {
            if (doWindow())
            {
                doMessage();
            }
        }
        protected void ChildThread(object o)
        {
            string[] str = o as string[];
            string strResult = str[0];
            string strType = str[1];
            this.Invoke((EventHandler)delegate
            {
                switch (strType)
                {
                    case "10":
                        {

                            doWork();
                            break;
                        }
                }
            });
           

        }
        protected override void DefWndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_COPYDATA:
                    {
                        COPYDATASTRUCT cds = new COPYDATASTRUCT();
                        Type t = cds.GetType();
                        cds = (COPYDATASTRUCT)m.GetLParam(t);
                        string strResult = cds.lpData;
                        string strType = cds.dwData.ToString();
                        Thread td = new Thread(ChildThread);
                        td.Start(new string[] { strResult, strType });
                        break;
                    }

                default:
                    base.DefWndProc(ref m);
                    break;
            }
        }

        private void buttonMessage_Click(object sender, EventArgs e)
        {
            doWork();
        }

        private void 显示主窗体ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = true;
            this.WindowState = FormWindowState.Normal;
            SetForegroundWindow(this.Handle);
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Visible = true;
            this.WindowState = FormWindowState.Normal;
            SetForegroundWindow(this.Handle);
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
            }
        }

        private void buttonWindowCallback_Click(object sender, EventArgs e)
        {
            doWindow();
        }

        private void buttonEventCallback_Click(object sender, EventArgs e)
        {
            doMessage();
        }
    }
    public struct COPYDATASTRUCT
    {
        public IntPtr dwData;
        public int cbData;
        [MarshalAs(UnmanagedType.LPStr)]
        public string lpData;
    }
}
