namespace MES_PROJECT
{
    partial class MainForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.주문관리ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.주문관리ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.발주관리ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.발주등록ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.작업지시관리ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.작업지시등록ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.주문관리ToolStripMenuItem,
            this.발주관리ToolStripMenuItem,
            this.작업지시관리ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1284, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 주문관리ToolStripMenuItem
            // 
            this.주문관리ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.주문관리ToolStripMenuItem1});
            this.주문관리ToolStripMenuItem.Name = "주문관리ToolStripMenuItem";
            this.주문관리ToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.주문관리ToolStripMenuItem.Text = "주문관리";
            // 
            // 주문관리ToolStripMenuItem1
            // 
            this.주문관리ToolStripMenuItem1.Name = "주문관리ToolStripMenuItem1";
            this.주문관리ToolStripMenuItem1.Size = new System.Drawing.Size(122, 22);
            this.주문관리ToolStripMenuItem1.Text = "주문관리";
            this.주문관리ToolStripMenuItem1.Click += new System.EventHandler(this.주문관리ToolStripMenuItem1_Click);
            // 
            // 발주관리ToolStripMenuItem
            // 
            this.발주관리ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.발주등록ToolStripMenuItem});
            this.발주관리ToolStripMenuItem.Name = "발주관리ToolStripMenuItem";
            this.발주관리ToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.발주관리ToolStripMenuItem.Text = "발주관리";
            // 
            // 발주등록ToolStripMenuItem
            // 
            this.발주등록ToolStripMenuItem.Name = "발주등록ToolStripMenuItem";
            this.발주등록ToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.발주등록ToolStripMenuItem.Text = "발주등록";
            this.발주등록ToolStripMenuItem.Click += new System.EventHandler(this.발주등록ToolStripMenuItem_Click);
            // 
            // 작업지시관리ToolStripMenuItem
            // 
            this.작업지시관리ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.작업지시등록ToolStripMenuItem});
            this.작업지시관리ToolStripMenuItem.Name = "작업지시관리ToolStripMenuItem";
            this.작업지시관리ToolStripMenuItem.Size = new System.Drawing.Size(91, 20);
            this.작업지시관리ToolStripMenuItem.Text = "작업지시관리";
            // 
            // 작업지시등록ToolStripMenuItem
            // 
            this.작업지시등록ToolStripMenuItem.Name = "작업지시등록ToolStripMenuItem";
            this.작업지시등록ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.작업지시등록ToolStripMenuItem.Text = "작업지시등록";
            this.작업지시등록ToolStripMenuItem.Click += new System.EventHandler(this.작업지시등록ToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 941);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 주문관리ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 주문관리ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 발주관리ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 발주등록ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 작업지시관리ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 작업지시등록ToolStripMenuItem;
    }
}