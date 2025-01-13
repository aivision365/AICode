using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using System.Drawing.Drawing2D;
using AICode.Util;
using System.Text;

namespace AICode
{
    public partial class MiniForm : Form
    {

        private QuestionForm questionFrom = null;
        private ResultForm resultForm = null;
        private AppConfig config = new AppConfig();
        private Point mouseOffset;
        private ToolStripMenuItem currentOpacityItem = null;
        public MiniFormLocation miniFormLocation;

        private bool isMouseDown = false;
        public int miniBigFormSpace = 5;
        public int miniFormWidth = 96;
        public int miniFormHeight = 40;


        /*移动时logo出现在questionFrom窗体的位置方向枚举*/
        public enum MiniFormLocation
        {
            topLeft,
            topRigh,
            bottomLeft,
            bottomRight
        }

        public MiniForm()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
            StartupSetting.autoRun("AICode.exe", Application.ExecutablePath);
            initParameter();
        }

        public void initParameter()
        {
            config.loadConfigFile(); //加载配置文件
            currentOpacityItem = getCurrentOpacityItem(config.getOpacity());
            setOpacity(currentOpacityItem, config.getOpacity()); //设置透明度
            Location = config.getMiniBallInitLocation(); //设置logo的坐标
            TopMost = config.getTopMost();
            if (TopMost)
            {
                showStyle2.Image = new Bitmap(Properties.Resources.dot);
                showStyle1.Image = null;
            }
            else
            {
                showStyle1.Image = new Bitmap(Properties.Resources.dot);
                showStyle2.Image = null;
            }
        }

        //简单说明一下：
        //“public static extern bool RegisterHotKey()”这个函数用于注册热键。由于这个函数需要引用user32.dll动态链接库后才能使用，并且
        //user32.dll是非托管代码，不能用命名空间的方式直接引用，所以需要用“DllImport”进行引入后才能使用。于是在函数前面需要加上
        //“[DllImport("user32.dll", SetLastError = true)]”这行语句。
        //“public static extern bool UnregisterHotKey()”这个函数用于注销热键，同理也需要用DllImport引用user32.dll后才能使用。
        //“public enum KeyModifiers{}”定义了一组枚举，将辅助键的数字代码直接表示为文字，以方便使用。这样在调用时我们不必记住每一个辅
        //助键的代码而只需直接选择其名称即可。
        //（2）以窗体FormA为例，介绍HotKey类的使用
        //在FormA的Activate事件中注册热键，本例中注册F2，F4, F6这几个热键。这里的Id号可任意设置，但要保证不被重复。

        private void Form_Activated(object sender, EventArgs e)
        {
            //注册热键Ctrl+K，Id号为100。HotKey.KeyModifiers.Shift也可以直接使用数字4来表示。
            //HotKey.RegisterHotKey(Handle, 100, HotKey.KeyModifiers.Ctrl, Keys.K);
            //注册热键F2，Id号为100。HotKey.KeyModifiers.Shift也可以直接使用数字4来表示。
            HotKey.RegisterHotKey(Handle, 100, HotKey.KeyModifiers.None, Keys.F2);
            //注册热键F4，Id号为101。HotKey.KeyModifiers.Ctrl也可以直接使用数字2来表示。
            HotKey.RegisterHotKey(Handle, 101, 0, Keys.F4);
            //注册热键F6，Id号为101。HotKey.KeyModifiers.Ctrl也可以直接使用数字2来表示。
            HotKey.RegisterHotKey(Handle, 102, 0, Keys.F6);
        }
        //在FormA的Leave事件中注销热键。
        private void Form_Leave(object sender, EventArgs e)
        {
            //注销Id号为100的热键设定
            HotKey.UnregisterHotKey(Handle, 100);
            //注销Id号为101的热键设定
            HotKey.UnregisterHotKey(Handle, 101);
            //注销Id号为102的热键设定
            HotKey.UnregisterHotKey(Handle, 102);
        }

        /// 
        /// 监视Windows消息
        /// 重载WndProc方法，用于实现热键响应
        /// 
        /// 
        protected override void WndProc(ref Message m)
        {
            const int WM_HOTKEY = 0x0312;
            //问题
            string question = questionFrom?.tb_Question.Text;
            //按快捷键 
            switch (m.Msg)
            {
                case WM_HOTKEY:
                    switch (m.WParam.ToInt32())
                    {
                        //按下的是F2
                        case 100:
                            //此处填写快捷键响应代码 
                            isMouseDown = false;
                            this.Cursor = Cursors.Default;
                            showQuestionFrom();
                            break;
                        //按下的是F4
                        case 101:
                            //调用程序写代码的接口
                            if (!string.IsNullOrEmpty(question))
                            {
                                //调用AI生成代码,返回结果
                                string[] resultArr = GenAICode.GenCode(0, question, "");
                                if (resultArr != null && resultArr.Length > 0)
                                {
                                    foreach (var tmp5 in resultArr)
                                    {
                                        //模拟键盘输出,注意EverEdit会自动补全括号造成结果增加括号
                                        KeyboardInput.InputText(tmp5);
                                        KeyboardInput.keybd_event(Keys.Enter, 0, 0, 0);
                                        KeyboardInput.keybd_event(Keys.Home, 2, 0, 0);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("未返回结果,可能跟是请求太频繁,请稍后再试!");
                                }
                            }
                            else
                            {
                                MessageBox.Show("请输入要求后再生成代码");
                                showQuestionFrom();
                                questionFrom?.tb_Question.Focus();
                            }
                            break;
                        case 102:
                            //调用解析代码的接口
                            if (!string.IsNullOrEmpty(question))
                            {
                                //获取剪切板中的内容
                                string content = ClipBoardUtil.GetClipContent() == null ? "" : ClipBoardUtil.GetClipContent();
                                //调用AI解析代码,返回结果
                                string[] resultArr = GenAICode.GenCode(1, question, content);
                                if (resultArr != null && resultArr.Length > 0)
                                {
                                    //显示结果窗口
                                    showResultForm();
                                    //拼接字符串
                                    StringBuilder resultBuilder = new StringBuilder();
                                    foreach (var tmp5 in resultArr)
                                    {
                                        resultBuilder.Append(tmp5 + "\r\n");
                                    }
                                    //结果框显示结果
                                    string result = resultBuilder.ToString();
                                    resultForm.tb_ResultContent.Text = result;
                                }
                                else
                                {
                                    MessageBox.Show("未返回结果,可能跟是请求太频繁,请稍后再试!");
                                }

                            }
                            else
                            {
                                MessageBox.Show("请输入要求后再解析代码");
                                showQuestionFrom();
                                questionFrom?.tb_Question.Focus();
                            }
                            break;
                    }
                    break;
            }
            base.WndProc(ref m);
        }



        #region logo的右键菜单单击事件
        /*退出程序*/
        private void quit_Click(object sender, EventArgs e)
        {
            config.saveInfos(this.Location.X, this.Location.Y, (int)(this.Opacity * 100), this.TopMost);
            notifyIcon.Dispose();
            Application.Exit();
        }
        private void showStyle1_Click(object sender, EventArgs e)
        {
            showStyle1.Image = new Bitmap(Properties.Resources.dot);
            showStyle2.Image = null;
            this.TopMost = false;
            if (questionFrom != null)
            {
                questionFrom.TopMost = false;
            }
        }

        private void showStyle2_Click(object sender, EventArgs e)
        {
            showStyle2.Image = new Bitmap(Properties.Resources.dot);
            showStyle1.Image = null;
            this.TopMost = true;
            if (questionFrom != null)
            {
                questionFrom.TopMost = true;
            }
        }

        private void opacity100_Click(object sender, EventArgs e)
        {
            setOpacity(opacity100, 100);
        }

        private void opacity95_Click(object sender, EventArgs e)
        {
            setOpacity(opacity95, 95);
        }

        private void opacity85_Click(object sender, EventArgs e)
        {
            setOpacity(opacity85, 85);
        }

        private void opacity80_Click(object sender, EventArgs e)
        {
            setOpacity(opacity80, 80);
        }

        private void opacity75_Click(object sender, EventArgs e)
        {
            setOpacity(opacity75, 75);
        }

        private void opacity50_Click(object sender, EventArgs e)
        {
            setOpacity(opacity50, 50);
        }

        private void opacity25_Click(object sender, EventArgs e)
        {
            setOpacity(opacity25, 25);
        }

        /*设置窗体的透明度*/
        private void setOpacity(ToolStripMenuItem opacityItem, int opacity)
        {
            currentOpacityItem.Image = null;
            opacityItem.Image = new Bitmap(Properties.Resources.dot);
            this.Opacity = opacity * 0.01;
            if (questionFrom != null)
            {
                questionFrom.Opacity = opacity * 0.01;
            }
            currentOpacityItem = opacityItem;
        }

        private ToolStripMenuItem getCurrentOpacityItem(int opacity)
        {
            switch (opacity)
            {
                case 100: return opacity100;
                case 95: return opacity95;
                case 85: return opacity85;
                case 80: return opacity80;
                case 75: return opacity75;
                case 50: return opacity50;
                case 25: return opacity25;
                default: return opacity100;
            }
        }
        #endregion

        #region logo的鼠标事件

        private void miniBigFormSpace_MouseLeave(object sender, EventArgs e)
        {
            Point p = MousePosition;
        }

        private void miniBigFormSpace_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isMouseDown = true;
                mouseOffset = new Point(MousePosition.X - this.Location.X, MousePosition.Y - this.Location.Y);
                this.Cursor = Cursors.SizeAll;
            }
        }

        private void miniBigFormSpace_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDown = false;
            this.Cursor = Cursors.Default;
        }

        private void miniBigFormSpace_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown == true)
            {
                Point old = this.Location;
                this.Location = getMiniBallMoveLocation();
                if (old.X != this.Location.X || old.Y != this.Location.Y)
                {
                    if (questionFrom != null && questionFrom.Visible)
                    {
                        hideQuestionForm();
                    }
                    if (resultForm != null && resultForm.Visible)
                    {
                        hideResultForm();
                    }
                }
            }
        }
        #endregion

        #region logo,questionFrom,resultFrom的位置方法
        /*logo出现的位置*/
        private Point getMiniBallMoveLocation()
        {
            int x = MousePosition.X - mouseOffset.X;
            int y = MousePosition.Y - mouseOffset.Y;
            if (x < 0)
            {
                x = 0;
            }
            if (y < 0)
            {
                y = 0;
            }
            if (Screen.PrimaryScreen.WorkingArea.Width - x < miniFormWidth)
            {
                x = Screen.PrimaryScreen.WorkingArea.Width - miniFormWidth;
            }
            if (Screen.PrimaryScreen.WorkingArea.Height - y < miniFormHeight)
            {
                y = Screen.PrimaryScreen.WorkingArea.Height - miniFormHeight;
            }
            return new Point(x, y);
        }

        /*获取questionFrom出现的位置*/
        private Point getQuestionFormLocation()
        {
            int x = 0, y = 0;
            //minBall在bigBall下面
            if (this.Location.Y >= questionFrom.Height)
            {
                if (Screen.PrimaryScreen.WorkingArea.Width - this.Location.X <= questionFrom.Width)
                {
                    x = this.Location.X + miniFormWidth - questionFrom.Width;
                    miniFormLocation = MiniFormLocation.bottomRight;
                }
                else
                {
                    x = this.Location.X - 10;
                    miniFormLocation = MiniFormLocation.bottomLeft;
                }
                y = this.Location.Y - questionFrom.Height - miniBigFormSpace;
            }
            else if (this.Location.Y < questionFrom.Height) //minBall在bigBall上面
            {
                if (Screen.PrimaryScreen.WorkingArea.Width - this.Location.X > questionFrom.Width)
                {
                    x = this.Location.X;
                    miniFormLocation = MiniFormLocation.topLeft;
                }
                else
                {
                    x = this.Location.X + miniFormWidth - questionFrom.Width;
                    miniFormLocation = MiniFormLocation.topRigh;
                }
                y = this.Location.Y + miniFormHeight + miniBigFormSpace;
            }
            return new Point(x, y);
        }

        /*获取resultFrom出现的位置*/
        private Point getResultFormLocation()
        {
            int x = 0, y = 0;
            //minBall在bigBall下面
            if (this.Location.Y >= questionFrom.Height)
            {
                if (Screen.PrimaryScreen.WorkingArea.Width - this.Location.X <= questionFrom.Width)
                {
                    x = this.Location.X + miniFormWidth - questionFrom.Width;
                    miniFormLocation = MiniFormLocation.bottomRight;
                }
                else
                {
                    x = this.Location.X - 10;
                    miniFormLocation = MiniFormLocation.bottomLeft;
                }
                y = this.Location.Y + questionFrom.Height - miniBigFormSpace * 5;
            }
            else if (this.Location.Y < questionFrom.Height) //minBall在bigBall上面
            {
                if (Screen.PrimaryScreen.WorkingArea.Width - this.Location.X > questionFrom.Width)
                {
                    x = this.Location.X;
                    miniFormLocation = MiniFormLocation.topLeft;
                }
                else
                {
                    x = this.Location.X + miniFormWidth - questionFrom.Width;
                    miniFormLocation = MiniFormLocation.topRigh;
                }
                y = this.Location.Y + miniFormHeight + miniBigFormSpace;
            }
            return new Point(x, y);
        }
        #endregion

        #region 显示和隐藏questionFrom与resultFrom的方法
        /*隐藏questionFrom*/
        private void hideQuestionForm()
        {
            if (questionFrom != null && questionFrom.Visible)
            {
                questionFrom.Hide();
            }
        }

        /*显示questionFrom*/
        private void showQuestionFrom()
        {
            if (questionFrom == null)
            {
                questionFrom = new QuestionForm();
                questionFrom.Show();
                questionFrom.Opacity = this.Opacity;
                questionFrom.Location = getQuestionFormLocation();
            }
            else if (!questionFrom.Visible)
            {
                questionFrom.Location = getQuestionFormLocation();
                questionFrom.Show();
            }
        }
        /*隐藏resultFrom*/
        private void hideResultForm()
        {
            if (resultForm != null && resultForm.Visible)
            {
                resultForm.Hide();
            }
        }
        /*显示resultFrom*/
        private void showResultForm()
        {
            resultForm = new ResultForm();
            resultForm.Opacity = this.Opacity;
            resultForm.Location = getResultFormLocation();
            resultForm.Show();
        }

        #endregion
    }
}
