namespace BaoCaoLuong2018.BaoCaoLuonng2017.MyUserControl
{
    partial class uc_Loai_1
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txt_Truong_001 = new DevExpress.XtraEditors.TextEdit();
            this.txt_Truong_002 = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Truong_001.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Truong_002.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.ForestGreen;
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Location = new System.Drawing.Point(9, 8);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(12, 16);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "1.";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.ForeColor = System.Drawing.Color.ForestGreen;
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Appearance.Options.UseForeColor = true;
            this.labelControl2.Location = new System.Drawing.Point(9, 40);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(12, 16);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "2.";
            // 
            // txt_Truong_001
            // 
            this.txt_Truong_001.Location = new System.Drawing.Point(33, 7);
            this.txt_Truong_001.Name = "txt_Truong_001";
            this.txt_Truong_001.Properties.Mask.EditMask = "[0-9?]+";
            this.txt_Truong_001.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txt_Truong_001.Properties.MaxLength = 2;
            this.txt_Truong_001.Size = new System.Drawing.Size(153, 20);
            this.txt_Truong_001.TabIndex = 3;
            this.txt_Truong_001.TextChanged += new System.EventHandler(this.txt_Truong_001_TextChanged);
            // 
            // txt_Truong_002
            // 
            this.txt_Truong_002.Enabled = false;
            this.txt_Truong_002.Location = new System.Drawing.Point(33, 39);
            this.txt_Truong_002.Name = "txt_Truong_002";
            this.txt_Truong_002.Properties.Mask.EditMask = "[1-2?]+";
            this.txt_Truong_002.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txt_Truong_002.Size = new System.Drawing.Size(153, 20);
            this.txt_Truong_002.TabIndex = 4;
            this.txt_Truong_002.TextChanged += new System.EventHandler(this.txt_Truong_002_TextChanged);
            // 
            // uc_Loai_1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txt_Truong_002);
            this.Controls.Add(this.txt_Truong_001);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Name = "uc_Loai_1";
            this.Size = new System.Drawing.Size(197, 69);
            this.Load += new System.EventHandler(this.uc_Loai_1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txt_Truong_001.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Truong_002.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public DevExpress.XtraEditors.LabelControl labelControl1;
        public DevExpress.XtraEditors.LabelControl labelControl2;
        public DevExpress.XtraEditors.TextEdit txt_Truong_001;
        public DevExpress.XtraEditors.TextEdit txt_Truong_002;
    }
}
