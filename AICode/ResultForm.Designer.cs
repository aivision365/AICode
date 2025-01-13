
namespace AICode
{
    partial class ResultForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ResultForm));
            this.tb_ResultContent = new FastColoredTextBoxNS.FastColoredTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.tb_ResultContent)).BeginInit();
            this.SuspendLayout();
            // 
            // tb_ResultContent
            // 
            this.tb_ResultContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_ResultContent.AutoCompleteBracketsList = new char[] {
        '(',
        ')',
        '{',
        '}',
        '[',
        ']',
        '\"',
        '\"',
        '\'',
        '\''};
            this.tb_ResultContent.AutoScrollMinSize = new System.Drawing.Size(35, 22);
            this.tb_ResultContent.BackBrush = null;
            this.tb_ResultContent.CharCnWidth = 25;
            this.tb_ResultContent.CharHeight = 22;
            this.tb_ResultContent.CharWidth = 12;
            this.tb_ResultContent.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tb_ResultContent.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.tb_ResultContent.IsReplaceMode = false;
            this.tb_ResultContent.Location = new System.Drawing.Point(3, 13);
            this.tb_ResultContent.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tb_ResultContent.Name = "tb_ResultContent";
            this.tb_ResultContent.Paddings = new System.Windows.Forms.Padding(0);
            this.tb_ResultContent.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.tb_ResultContent.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("tb_ResultContent.ServiceColors")));
            this.tb_ResultContent.Size = new System.Drawing.Size(1155, 698);
            this.tb_ResultContent.TabIndex = 1;
            this.tb_ResultContent.Zoom = 100;
            this.tb_ResultContent.TextChangedDelayed += new System.EventHandler<FastColoredTextBoxNS.TextChangedEventArgs>(this.tb_ResultContent_TextChangedDelayed);
            // 
            // ResultForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1170, 724);
            this.Controls.Add(this.tb_ResultContent);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ResultForm";
            this.Text = "结果窗口";
            ((System.ComponentModel.ISupportInitialize)(this.tb_ResultContent)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public FastColoredTextBoxNS.FastColoredTextBox tb_ResultContent;
    }
}