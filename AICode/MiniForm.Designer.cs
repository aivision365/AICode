namespace AICode
{
    partial class MiniForm
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
            if(disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MiniForm));
            this.mainContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showStyle = new System.Windows.Forms.ToolStripMenuItem();
            this.showStyle1 = new System.Windows.Forms.ToolStripMenuItem();
            this.showStyle2 = new System.Windows.Forms.ToolStripMenuItem();
            this.transparecy = new System.Windows.Forms.ToolStripMenuItem();
            this.opacity100 = new System.Windows.Forms.ToolStripMenuItem();
            this.opacity95 = new System.Windows.Forms.ToolStripMenuItem();
            this.opacity85 = new System.Windows.Forms.ToolStripMenuItem();
            this.opacity80 = new System.Windows.Forms.ToolStripMenuItem();
            this.opacity75 = new System.Windows.Forms.ToolStripMenuItem();
            this.opacity50 = new System.Windows.Forms.ToolStripMenuItem();
            this.opacity25 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.quit = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.mainContextMenu.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainContextMenu
            // 
            this.mainContextMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mainContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showStyle,
            this.transparecy,
            this.toolStripSeparator1,
            this.quit});
            this.mainContextMenu.Name = "mainContextMenu";
            this.mainContextMenu.Size = new System.Drawing.Size(139, 82);
            // 
            // showStyle
            // 
            this.showStyle.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showStyle1,
            this.showStyle2});
            this.showStyle.Name = "showStyle";
            this.showStyle.Size = new System.Drawing.Size(138, 24);
            this.showStyle.Text = "显示方式";
            // 
            // showStyle1
            // 
            this.showStyle1.Name = "showStyle1";
            this.showStyle1.Size = new System.Drawing.Size(212, 26);
            this.showStyle1.Text = "不在前端显示";
            this.showStyle1.Click += new System.EventHandler(this.showStyle1_Click);
            // 
            // showStyle2
            // 
            this.showStyle2.Name = "showStyle2";
            this.showStyle2.Size = new System.Drawing.Size(212, 26);
            this.showStyle2.Text = "在其他窗口前显示";
            this.showStyle2.Click += new System.EventHandler(this.showStyle2_Click);
            // 
            // transparecy
            // 
            this.transparecy.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.opacity100,
            this.opacity95,
            this.opacity85,
            this.opacity80,
            this.opacity75,
            this.opacity50,
            this.opacity25});
            this.transparecy.Name = "transparecy";
            this.transparecy.ShowShortcutKeys = false;
            this.transparecy.Size = new System.Drawing.Size(138, 24);
            this.transparecy.Text = "透明度";
            // 
            // opacity100
            // 
            this.opacity100.AutoSize = false;
            this.opacity100.Name = "opacity100";
            this.opacity100.ShowShortcutKeys = false;
            this.opacity100.Size = new System.Drawing.Size(152, 22);
            this.opacity100.Text = "不透明";
            this.opacity100.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.opacity100.Click += new System.EventHandler(this.opacity100_Click);
            // 
            // opacity95
            // 
            this.opacity95.Name = "opacity95";
            this.opacity95.ShowShortcutKeys = false;
            this.opacity95.Size = new System.Drawing.Size(128, 26);
            this.opacity95.Text = "95";
            this.opacity95.Click += new System.EventHandler(this.opacity95_Click);
            // 
            // opacity85
            // 
            this.opacity85.Name = "opacity85";
            this.opacity85.ShowShortcutKeys = false;
            this.opacity85.Size = new System.Drawing.Size(128, 26);
            this.opacity85.Text = "85";
            this.opacity85.Click += new System.EventHandler(this.opacity85_Click);
            // 
            // opacity80
            // 
            this.opacity80.Name = "opacity80";
            this.opacity80.ShowShortcutKeys = false;
            this.opacity80.Size = new System.Drawing.Size(128, 26);
            this.opacity80.Text = "80";
            this.opacity80.Click += new System.EventHandler(this.opacity80_Click);
            // 
            // opacity75
            // 
            this.opacity75.Name = "opacity75";
            this.opacity75.ShowShortcutKeys = false;
            this.opacity75.Size = new System.Drawing.Size(128, 26);
            this.opacity75.Text = "75";
            this.opacity75.Click += new System.EventHandler(this.opacity75_Click);
            // 
            // opacity50
            // 
            this.opacity50.Name = "opacity50";
            this.opacity50.ShowShortcutKeys = false;
            this.opacity50.Size = new System.Drawing.Size(128, 26);
            this.opacity50.Text = "50";
            this.opacity50.Click += new System.EventHandler(this.opacity50_Click);
            // 
            // opacity25
            // 
            this.opacity25.Name = "opacity25";
            this.opacity25.ShowShortcutKeys = false;
            this.opacity25.Size = new System.Drawing.Size(128, 26);
            this.opacity25.Text = "25";
            this.opacity25.Click += new System.EventHandler(this.opacity25_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(135, 6);
            // 
            // quit
            // 
            this.quit.Name = "quit";
            this.quit.ShowShortcutKeys = false;
            this.quit.Size = new System.Drawing.Size(138, 24);
            this.quit.Text = "退出";
            this.quit.Click += new System.EventHandler(this.quit_Click);
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.mainContextMenu;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "AI代码生成";
            this.notifyIcon.Visible = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Location = new System.Drawing.Point(-4, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(56, 54);
            this.panel1.TabIndex = 2;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.miniBigFormSpace_MouseDown);
            this.panel1.MouseLeave += new System.EventHandler(this.miniBigFormSpace_MouseLeave);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.miniBigFormSpace_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.miniBigFormSpace_MouseUp);
            // 
            // button1
            // 
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.Location = new System.Drawing.Point(3, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(46, 46);
            this.button1.TabIndex = 0;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.miniBigFormSpace_MouseDown);
            this.button1.MouseLeave += new System.EventHandler(this.miniBigFormSpace_MouseLeave);
            this.button1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.miniBigFormSpace_MouseMove);
            this.button1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.miniBigFormSpace_MouseUp);
            // 
            // MiniForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(52, 56);
            this.ContextMenuStrip = this.mainContextMenu;
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MiniForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "AI代码生成";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.White;
            this.Activated += new System.EventHandler(this.Form_Activated);
            this.Leave += new System.EventHandler(this.Form_Leave);
            this.mainContextMenu.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip mainContextMenu;
        private System.Windows.Forms.ToolStripMenuItem transparecy;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem quit;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ToolStripMenuItem opacity95;
        private System.Windows.Forms.ToolStripMenuItem opacity85;
        private System.Windows.Forms.ToolStripMenuItem opacity80;
        private System.Windows.Forms.ToolStripMenuItem opacity75;
        private System.Windows.Forms.ToolStripMenuItem opacity50;
        private System.Windows.Forms.ToolStripMenuItem opacity25;
        private System.Windows.Forms.ToolStripMenuItem opacity100;
        private System.Windows.Forms.ToolStripMenuItem showStyle;
        private System.Windows.Forms.ToolStripMenuItem showStyle1;
        private System.Windows.Forms.ToolStripMenuItem showStyle2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
    }
}

