namespace BaoCaoLuong2018.MyUserControl
{
    partial class UC_CityN_JP
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
            this.txt_Truong_018 = new DevExpress.XtraEditors.TextEdit();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_Truong_148 = new DevExpress.XtraEditors.LookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Truong_018.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Truong_148.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_Truong_018
            // 
            this.txt_Truong_018.Location = new System.Drawing.Point(36, 3);
            this.txt_Truong_018.Name = "txt_Truong_018";
            this.txt_Truong_018.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Truong_018.Properties.Appearance.Options.UseFont = true;
            this.txt_Truong_018.Size = new System.Drawing.Size(258, 22);
            this.txt_Truong_018.TabIndex = 76;
            this.txt_Truong_018.EditValueChanged += new System.EventHandler(this.txt_Truong_018_EditValueChanged);
            this.txt_Truong_018.TextChanged += new System.EventHandler(this.txt_Truong_016_TextChanged);
            this.txt_Truong_018.Leave += new System.EventHandler(this.txt_Truong_018_Leave);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Green;
            this.label9.Location = new System.Drawing.Point(3, 8);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(25, 13);
            this.label9.TabIndex = 79;
            this.label9.Text = "18.";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Green;
            this.label5.Location = new System.Drawing.Point(3, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 80;
            this.label5.Text = "148.";
            // 
            // txt_Truong_148
            // 
            this.txt_Truong_148.Location = new System.Drawing.Point(36, 29);
            this.txt_Truong_148.Name = "txt_Truong_148";
            this.txt_Truong_148.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.txt_Truong_148.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Truong_148.Properties.Appearance.Options.UseFont = true;
            this.txt_Truong_148.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txt_Truong_148.Properties.DropDownRows = 25;
            this.txt_Truong_148.Properties.NullText = "";
            this.txt_Truong_148.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.txt_Truong_148.Size = new System.Drawing.Size(258, 22);
            this.txt_Truong_148.TabIndex = 81;
            this.txt_Truong_148.EditValueChanged += new System.EventHandler(this.txt_Truong_148_EditValueChanged);
            this.txt_Truong_148.TextChanged += new System.EventHandler(this.txt_Truong_016_TextChanged);
            this.txt_Truong_148.Leave += new System.EventHandler(this.txt_Truong_148_Leave);
            // 
            // UC_CityN_JP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txt_Truong_148);
            this.Controls.Add(this.txt_Truong_018);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label5);
            this.Name = "UC_CityN_JP";
            this.Size = new System.Drawing.Size(300, 56);
            this.Load += new System.EventHandler(this.UC_CityN_JP_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txt_Truong_018.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Truong_148.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public DevExpress.XtraEditors.TextEdit txt_Truong_018;
        public System.Windows.Forms.Label label9;
        public System.Windows.Forms.Label label5;
        public DevExpress.XtraEditors.LookUpEdit txt_Truong_148;
    }
}
