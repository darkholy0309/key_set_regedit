namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            MaximizeBox = false;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            Size = new Size(310, 250);
            //
            button1.Location = new Point(200, 20);
            button2.Location = new Point(200, 50);
            button3.Location = new Point(200, 80);
            button4.Location = new Point(200, 110);
            button5.Location = new Point(200, 140);
            button6.Location = new Point(20, 170);
            button1.Text = "재입력시간";
            button2.Text = "고정키";
            button3.Text = "필터키";
            button4.Text = "키 시퀀스";
            button5.Text = "사용자계정";
            button6.Text = "전원옵션";
            label1.Font = new Font("dotum", 14);
            label2.Font = new Font("dotum", 14);
            label3.Font = new Font("dotum", 14);
            label4.Font = new Font("dotum", 14);
            label5.Font = new Font("dotum", 14);
            label1.Location = new Point(20, 20);
            label2.Location = new Point(20, 50);
            label3.Location = new Point(20, 80);
            label4.Location = new Point(20, 110);
            label5.Location = new Point(20, 140);
            main();
        }

        void main()
        {
            if (Convert.ToInt32(Microsoft.Win32.RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, Microsoft.Win32.RegistryView.Default).OpenSubKey("software\\microsoft\\windows nt\\currentversion").GetValue("currentbuild")) < 22000)
            {
                MessageBox.Show("windows 11 update 21H2" + Environment.NewLine + "윈도우 업데이트 필요");
            }
            if (Microsoft.Win32.RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, Microsoft.Win32.RegistryView.Default).OpenSubKey("control panel\\keyboard").GetValue("keyboarddelay").ToString() == "0")
            {
                label1.Text = "재입력 시간 짧게";
            }
            if (Microsoft.Win32.RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, Microsoft.Win32.RegistryView.Default).OpenSubKey("control panel\\keyboard").GetValue("keyboarddelay").ToString() == "1")
            {
                label1.Text = "KeyboardDelay" + string.Empty.PadLeft(1) + Microsoft.Win32.RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, Microsoft.Win32.RegistryView.Default).OpenSubKey("control panel\\keyboard").GetValue("keyboarddelay");
            }
            if (Microsoft.Win32.RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, Microsoft.Win32.RegistryView.Default).OpenSubKey("control panel\\accessibility\\stickykeys").GetValue("flags").ToString() == "506")
            {
                label2.Text = "고정키 안함";
            }
            if (Microsoft.Win32.RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, Microsoft.Win32.RegistryView.Default).OpenSubKey("control panel\\accessibility\\stickykeys").GetValue("flags").ToString() == "510")
            {
                label2.Text = "Flags" + string.Empty.PadLeft(1) + Microsoft.Win32.RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, Microsoft.Win32.RegistryView.Default).OpenSubKey("control panel\\accessibility\\stickykeys").GetValue("flags");
            }
            if (Microsoft.Win32.RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, Microsoft.Win32.RegistryView.Default).OpenSubKey("control panel\\accessibility\\keyboard response").GetValue("flags").ToString() == "122")
            {
                label3.Text = "필터키 안함";
            }
            if (Microsoft.Win32.RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, Microsoft.Win32.RegistryView.Default).OpenSubKey("control panel\\accessibility\\keyboard response").GetValue("flags").ToString() == "126")
            {
                label3.Text = "Flags" + string.Empty.PadLeft(1) + Microsoft.Win32.RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, Microsoft.Win32.RegistryView.Default).OpenSubKey("control panel\\accessibility\\keyboard response").GetValue("flags");
            }
            if (Microsoft.Win32.RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, Microsoft.Win32.RegistryView.Default).OpenSubKey("keyboard layout\\toggle").GetValue("hotkey") == null)
            {
                label4.Text = "HotKey 1";
            }
            else if (Microsoft.Win32.RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, Microsoft.Win32.RegistryView.Default).OpenSubKey("keyboard layout\\toggle").GetValue("hotkey").ToString() == "3")
            {
                label4.Text = "키 시퀀스 안함";
            }
            else if (Microsoft.Win32.RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, Microsoft.Win32.RegistryView.Default).OpenSubKey("keyboard layout\\toggle").GetValue("hotkey").ToString() == "1")
            {
                label4.Text = "HotKey" + string.Empty.PadLeft(1) + Microsoft.Win32.RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, Microsoft.Win32.RegistryView.Default).OpenSubKey("keyboard layout\\toggle").GetValue("hotkey");
            }
            if (Microsoft.Win32.RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, Microsoft.Win32.RegistryView.Default).OpenSubKey("software\\microsoft\\windows\\currentversion\\policies\\system").GetValue("enablelua").ToString() == "0")
            {
                label5.Text = "사용자계정 안함";
            }
            if (Microsoft.Win32.RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, Microsoft.Win32.RegistryView.Default).OpenSubKey("software\\microsoft\\windows\\currentversion\\policies\\system").GetValue("enablelua").ToString() == "1")
            {
                label5.Text = "EnableLUA" + string.Empty.PadLeft(1) + Microsoft.Win32.RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, Microsoft.Win32.RegistryView.Default).OpenSubKey("software\\microsoft\\windows\\currentversion\\policies\\system").GetValue("enablelua");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            process.StartInfo.FileName = "cmd";
            process.StartInfo.Arguments = "/c" + string.Empty.PadLeft(1) + "powercfg.cpl";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;
            process.Start();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (Microsoft.Win32.RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, Microsoft.Win32.RegistryView.Default).OpenSubKey("software\\microsoft\\windows\\currentversion\\policies\\system").GetValue("enablelua").ToString() == "1")
                {
                    Microsoft.Win32.RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, Microsoft.Win32.RegistryView.Default).CreateSubKey("software\\microsoft\\windows\\currentversion\\policies\\system").SetValue("enablelua", 0, Microsoft.Win32.RegistryValueKind.DWord);
                }
                else if (Microsoft.Win32.RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, Microsoft.Win32.RegistryView.Default).OpenSubKey("software\\microsoft\\windows\\currentversion\\policies\\system").GetValue("enablelua").ToString() == "0")
                {
                    Microsoft.Win32.RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, Microsoft.Win32.RegistryView.Default).CreateSubKey("software\\microsoft\\windows\\currentversion\\policies\\system").SetValue("enablelua", 1, Microsoft.Win32.RegistryValueKind.DWord);
                }
                if (Microsoft.Win32.RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, Microsoft.Win32.RegistryView.Default).OpenSubKey("software\\microsoft\\windows\\currentversion\\policies\\system").GetValue("enablelua").ToString() == "0")
                {
                    label5.Text = "사용자계정 안함";
                }
                if (Microsoft.Win32.RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, Microsoft.Win32.RegistryView.Default).OpenSubKey("software\\microsoft\\windows\\currentversion\\policies\\system").GetValue("enablelua").ToString() == "1")
                {
                    label5.Text = "EnableLUA" + string.Empty.PadLeft(1) + Microsoft.Win32.RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, Microsoft.Win32.RegistryView.Default).OpenSubKey("software\\microsoft\\windows\\currentversion\\policies\\system").GetValue("enablelua");
                }
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("관리자 권한으로 실행 필요");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (Microsoft.Win32.RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, Microsoft.Win32.RegistryView.Default).OpenSubKey("keyboard layout\\toggle").GetValue("hotkey") == null)
            {
                Microsoft.Win32.RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, Microsoft.Win32.RegistryView.Default).CreateSubKey("keyboard layout\\toggle").SetValue("hotkey", 1, Microsoft.Win32.RegistryValueKind.String);
            }
            else if (Microsoft.Win32.RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, Microsoft.Win32.RegistryView.Default).OpenSubKey("keyboard layout\\toggle").GetValue("hotkey").ToString() == "1")
            {
                Microsoft.Win32.RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, Microsoft.Win32.RegistryView.Default).CreateSubKey("keyboard layout\\toggle").SetValue("hotkey", 3, Microsoft.Win32.RegistryValueKind.String);
            }
            else if (Microsoft.Win32.RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, Microsoft.Win32.RegistryView.Default).OpenSubKey("keyboard layout\\toggle").GetValue("hotkey").ToString() == "3")
            {
                Microsoft.Win32.RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, Microsoft.Win32.RegistryView.Default).CreateSubKey("keyboard layout\\toggle").SetValue("hotkey", 1, Microsoft.Win32.RegistryValueKind.String);
            }
            if (Microsoft.Win32.RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, Microsoft.Win32.RegistryView.Default).OpenSubKey("keyboard layout\\toggle").GetValue("hotkey").ToString() == "3")
            {
                label4.Text = "키 시퀀스 안함";
            }
            if (Microsoft.Win32.RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, Microsoft.Win32.RegistryView.Default).OpenSubKey("keyboard layout\\toggle").GetValue("hotkey").ToString() == "1")
            {
                label4.Text = "HotKey" + string.Empty.PadLeft(1) + Microsoft.Win32.RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, Microsoft.Win32.RegistryView.Default).OpenSubKey("keyboard layout\\toggle").GetValue("hotkey");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Microsoft.Win32.RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, Microsoft.Win32.RegistryView.Default).OpenSubKey("control panel\\accessibility\\keyboard response").GetValue("flags").ToString() == "126")
            {
                Microsoft.Win32.RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, Microsoft.Win32.RegistryView.Default).CreateSubKey("control panel\\accessibility\\keyboard response").SetValue("flags", 122, Microsoft.Win32.RegistryValueKind.String);
            }
            else if (Microsoft.Win32.RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, Microsoft.Win32.RegistryView.Default).OpenSubKey("control panel\\accessibility\\keyboard response").GetValue("flags").ToString() == "122")
            {
                Microsoft.Win32.RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, Microsoft.Win32.RegistryView.Default).CreateSubKey("control panel\\accessibility\\keyboard response").SetValue("flags", 126, Microsoft.Win32.RegistryValueKind.String);
                Microsoft.Win32.RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, Microsoft.Win32.RegistryView.Default).CreateSubKey("control panel\\accessibility\\keyboard response").SetValue("autorepeatdelay", 1000, Microsoft.Win32.RegistryValueKind.String);
                Microsoft.Win32.RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, Microsoft.Win32.RegistryView.Default).CreateSubKey("control panel\\accessibility\\keyboard response").SetValue("autorepeatrate", 500, Microsoft.Win32.RegistryValueKind.String);
            }
            if (Microsoft.Win32.RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, Microsoft.Win32.RegistryView.Default).OpenSubKey("control panel\\accessibility\\keyboard response").GetValue("flags").ToString() == "122")
            {
                label3.Text = "필터키 안함";
            }
            if (Microsoft.Win32.RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, Microsoft.Win32.RegistryView.Default).OpenSubKey("control panel\\accessibility\\keyboard response").GetValue("flags").ToString() == "126")
            {
                label3.Text = "Flags" + string.Empty.PadLeft(1) + Microsoft.Win32.RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, Microsoft.Win32.RegistryView.Default).OpenSubKey("control panel\\accessibility\\keyboard response").GetValue("flags");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Microsoft.Win32.RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, Microsoft.Win32.RegistryView.Default).OpenSubKey("control panel\\accessibility\\stickykeys").GetValue("flags").ToString() == "506")
            {
                Microsoft.Win32.RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, Microsoft.Win32.RegistryView.Default).CreateSubKey("control panel\\accessibility\\stickykeys").SetValue("flags", 510, Microsoft.Win32.RegistryValueKind.String);
            }
            else if (Microsoft.Win32.RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, Microsoft.Win32.RegistryView.Default).OpenSubKey("control panel\\accessibility\\stickykeys").GetValue("flags").ToString() == "510")
            {
                Microsoft.Win32.RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, Microsoft.Win32.RegistryView.Default).CreateSubKey("control panel\\accessibility\\stickykeys").SetValue("flags", 506, Microsoft.Win32.RegistryValueKind.String);
            }
            if (Microsoft.Win32.RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, Microsoft.Win32.RegistryView.Default).OpenSubKey("control panel\\accessibility\\stickykeys").GetValue("flags").ToString() == "506")
            {
                label2.Text = "고정키 안함";
            }
            if (Microsoft.Win32.RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, Microsoft.Win32.RegistryView.Default).OpenSubKey("control panel\\accessibility\\stickykeys").GetValue("flags").ToString() == "510")
            {
                label2.Text = "Flags" + string.Empty.PadLeft(1) + Microsoft.Win32.RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, Microsoft.Win32.RegistryView.Default).OpenSubKey("control panel\\accessibility\\stickykeys").GetValue("flags");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            process.StartInfo.FileName = "cmd";
            process.StartInfo.Arguments = "/c" + string.Empty.PadLeft(1) + "control keyboard";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;
            process.Start();
            main();
        }
    }
}