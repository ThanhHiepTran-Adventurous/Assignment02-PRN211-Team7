namespace SalesWinApp
{
    partial class frmMain
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
            this.windownsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.tlsManageMember = new System.Windows.Forms.ToolStripMenuItem();
            this.tlsManageProduct = new System.Windows.Forms.ToolStripMenuItem();
            this.tlsManageOrder = new System.Windows.Forms.ToolStripMenuItem();
            this.systemsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.windownsMenu,
            this.systemsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // windownsMenu
            // 
            this.windownsMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlsManageMember,
            this.tlsManageProduct,
            this.tlsManageOrder});
            this.windownsMenu.Name = "windownsMenu";
            this.windownsMenu.Size = new System.Drawing.Size(111, 24);
            this.windownsMenu.Text = "&Management";
            // 
            // tlsManageMember
            // 
            this.tlsManageMember.Name = "tlsManageMember";
            this.tlsManageMember.Size = new System.Drawing.Size(148, 26);
            this.tlsManageMember.Text = "&Member";
            this.tlsManageMember.Click += new System.EventHandler(this.tlsManageMember_Click);
            // 
            // tlsManageProduct
            // 
            this.tlsManageProduct.Name = "tlsManageProduct";
            this.tlsManageProduct.Size = new System.Drawing.Size(148, 26);
            this.tlsManageProduct.Text = "&Product";
            // 
            // tlsManageOrder
            // 
            this.tlsManageOrder.Name = "tlsManageOrder";
            this.tlsManageOrder.Size = new System.Drawing.Size(148, 26);
            this.tlsManageOrder.Text = "&Order";
            // 
            // systemsToolStripMenuItem
            // 
            this.systemsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeToolStripMenuItem});
            this.systemsToolStripMenuItem.Name = "systemsToolStripMenuItem";
            this.systemsToolStripMenuItem.Size = new System.Drawing.Size(76, 24);
            this.systemsToolStripMenuItem.Text = "&Systems";
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(128, 26);
            this.closeToolStripMenuItem.Text = "&Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmMain";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem windownsMenu;
        private ToolStripMenuItem tlsManageMember;
        private ToolStripMenuItem tlsManageProduct;
        private ToolStripMenuItem tlsManageOrder;
        private ToolStripMenuItem systemsToolStripMenuItem;
        private ToolStripMenuItem closeToolStripMenuItem;
    }
}