namespace SalesWinApp
{
    partial class frmOrdersDetail
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
            this.lbOrderId = new System.Windows.Forms.Label();
            this.lbMemberId = new System.Windows.Forms.Label();
            this.txtOrderId = new System.Windows.Forms.TextBox();
            this.txtMemberId = new System.Windows.Forms.TextBox();
            this.lbOrderDate = new System.Windows.Forms.Label();
            this.lbRequiredDate = new System.Windows.Forms.Label();
            this.txtOrderDate = new System.Windows.Forms.MaskedTextBox();
            this.txtRequiredDate = new System.Windows.Forms.MaskedTextBox();
            this.txtFreight = new System.Windows.Forms.TextBox();
            this.txtShippedDate = new System.Windows.Forms.MaskedTextBox();
            this.lbShppedDate = new System.Windows.Forms.Label();
            this.lbFreight = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbOrderId
            // 
            this.lbOrderId.AutoSize = true;
            this.lbOrderId.Location = new System.Drawing.Point(35, 40);
            this.lbOrderId.Name = "lbOrderId";
            this.lbOrderId.Size = new System.Drawing.Size(66, 20);
            this.lbOrderId.TabIndex = 0;
            this.lbOrderId.Text = "Order ID";
            // 
            // lbMemberId
            // 
            this.lbMemberId.AutoSize = true;
            this.lbMemberId.Location = new System.Drawing.Point(35, 105);
            this.lbMemberId.Name = "lbMemberId";
            this.lbMemberId.Size = new System.Drawing.Size(84, 20);
            this.lbMemberId.TabIndex = 1;
            this.lbMemberId.Text = "Member ID";
            // 
            // txtOrderId
            // 
            this.txtOrderId.Location = new System.Drawing.Point(142, 36);
            this.txtOrderId.Name = "txtOrderId";
            this.txtOrderId.Size = new System.Drawing.Size(181, 27);
            this.txtOrderId.TabIndex = 2;
            // 
            // txtMemberId
            // 
            this.txtMemberId.Location = new System.Drawing.Point(142, 102);
            this.txtMemberId.Name = "txtMemberId";
            this.txtMemberId.Size = new System.Drawing.Size(181, 27);
            this.txtMemberId.TabIndex = 3;
            // 
            // lbOrderDate
            // 
            this.lbOrderDate.AutoSize = true;
            this.lbOrderDate.Location = new System.Drawing.Point(370, 43);
            this.lbOrderDate.Name = "lbOrderDate";
            this.lbOrderDate.Size = new System.Drawing.Size(83, 20);
            this.lbOrderDate.TabIndex = 4;
            this.lbOrderDate.Text = "Order Date";
            // 
            // lbRequiredDate
            // 
            this.lbRequiredDate.AutoSize = true;
            this.lbRequiredDate.Location = new System.Drawing.Point(370, 105);
            this.lbRequiredDate.Name = "lbRequiredDate";
            this.lbRequiredDate.Size = new System.Drawing.Size(105, 20);
            this.lbRequiredDate.TabIndex = 5;
            this.lbRequiredDate.Text = "Required Date";
            // 
            // txtOrderDate
            // 
            this.txtOrderDate.Location = new System.Drawing.Point(481, 40);
            this.txtOrderDate.Mask = "00/00/0000";
            this.txtOrderDate.Name = "txtOrderDate";
            this.txtOrderDate.Size = new System.Drawing.Size(223, 27);
            this.txtOrderDate.TabIndex = 6;
            // 
            // txtRequiredDate
            // 
            this.txtRequiredDate.Location = new System.Drawing.Point(481, 102);
            this.txtRequiredDate.Mask = "00/00/0000";
            this.txtRequiredDate.Name = "txtRequiredDate";
            this.txtRequiredDate.Size = new System.Drawing.Size(223, 27);
            this.txtRequiredDate.TabIndex = 7;
            // 
            // txtFreight
            // 
            this.txtFreight.Location = new System.Drawing.Point(855, 102);
            this.txtFreight.Name = "txtFreight";
            this.txtFreight.Size = new System.Drawing.Size(203, 27);
            this.txtFreight.TabIndex = 8;
            // 
            // txtShippedDate
            // 
            this.txtShippedDate.Location = new System.Drawing.Point(855, 43);
            this.txtShippedDate.Mask = "00/00/0000";
            this.txtShippedDate.Name = "txtShippedDate";
            this.txtShippedDate.Size = new System.Drawing.Size(203, 27);
            this.txtShippedDate.TabIndex = 9;
            // 
            // lbShppedDate
            // 
            this.lbShppedDate.AutoSize = true;
            this.lbShppedDate.Location = new System.Drawing.Point(749, 47);
            this.lbShppedDate.Name = "lbShppedDate";
            this.lbShppedDate.Size = new System.Drawing.Size(100, 20);
            this.lbShppedDate.TabIndex = 10;
            this.lbShppedDate.Text = "Shipped Date";
            // 
            // lbFreight
            // 
            this.lbFreight.AutoSize = true;
            this.lbFreight.Location = new System.Drawing.Point(757, 105);
            this.lbFreight.Name = "lbFreight";
            this.lbFreight.Size = new System.Drawing.Size(55, 20);
            this.lbFreight.TabIndex = 11;
            this.lbFreight.Text = "Freight";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(346, 218);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(94, 29);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(610, 218);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(94, 29);
            this.btnClose.TabIndex = 13;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmOrdersDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1111, 333);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lbFreight);
            this.Controls.Add(this.lbShppedDate);
            this.Controls.Add(this.txtShippedDate);
            this.Controls.Add(this.txtFreight);
            this.Controls.Add(this.txtRequiredDate);
            this.Controls.Add(this.txtOrderDate);
            this.Controls.Add(this.lbRequiredDate);
            this.Controls.Add(this.lbOrderDate);
            this.Controls.Add(this.txtMemberId);
            this.Controls.Add(this.txtOrderId);
            this.Controls.Add(this.lbMemberId);
            this.Controls.Add(this.lbOrderId);
            this.Name = "frmOrdersDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmOrdersDetail";
            this.Load += new System.EventHandler(this.frmOrdersDetail_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lbOrderId;
        private Label lbMemberId;
        private TextBox txtOrderId;
        private TextBox txtMemberId;
        private Label lbOrderDate;
        private Label lbRequiredDate;
        private MaskedTextBox txtOrderDate;
        private MaskedTextBox txtRequiredDate;
        private TextBox txtFreight;
        private MaskedTextBox txtShippedDate;
        private Label lbShppedDate;
        private Label lbFreight;
        private Button btnSave;
        private Button btnClose;
    }
}