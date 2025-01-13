namespace AICode
{
    partial class QuestionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuestionForm));
            this.tb_Question = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tb_Question
            // 
            this.tb_Question.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.tb_Question.Font = new System.Drawing.Font("宋体", 13F);
            this.tb_Question.Location = new System.Drawing.Point(0, 0);
            this.tb_Question.Margin = new System.Windows.Forms.Padding(0);
            this.tb_Question.Multiline = true;
            this.tb_Question.Name = "tb_Question";
            this.tb_Question.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tb_Question.Size = new System.Drawing.Size(343, 116);
            this.tb_Question.TabIndex = 0;
            this.tb_Question.Text = "逐行解析这段halcon代码,并增加中文注释,每行之间不要有空格,halcon注释开头要用*";
            // 
            // QuestionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(351, 120);
            this.Controls.Add(this.tb_Question);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "QuestionForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "搜索框";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.White;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox tb_Question;
    }
}

