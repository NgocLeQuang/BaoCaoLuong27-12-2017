namespace BaoCaoLuong2018.BaoCaoLuonng2017.MyForm
{
    partial class frm_ExportExcel
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.cbb_Batch = new System.Windows.Forms.ComboBox();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.lb_SoDong_trongExcel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(7, 102);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(1062, 423);
            this.dataGridView1.TabIndex = 7;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.simpleButton1.Appearance.Options.UseFont = true;
            this.simpleButton1.Location = new System.Drawing.Point(618, 60);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(102, 33);
            this.simpleButton1.TabIndex = 6;
            this.simpleButton1.Text = "Xuất Excel";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // cbb_Batch
            // 
            this.cbb_Batch.FormattingEnabled = true;
            this.cbb_Batch.Location = new System.Drawing.Point(18, 69);
            this.cbb_Batch.Name = "cbb_Batch";
            this.cbb_Batch.Size = new System.Drawing.Size(502, 21);
            this.cbb_Batch.TabIndex = 5;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Location = new System.Drawing.Point(202, 23);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(92, 19);
            this.labelControl1.TabIndex = 4;
            this.labelControl1.Text = "Chọn Batch";
            // 
            // lb_SoDong_trongExcel
            // 
            this.lb_SoDong_trongExcel.AutoSize = true;
            this.lb_SoDong_trongExcel.Location = new System.Drawing.Point(559, 72);
            this.lb_SoDong_trongExcel.Name = "lb_SoDong_trongExcel";
            this.lb_SoDong_trongExcel.Size = new System.Drawing.Size(19, 13);
            this.lb_SoDong_trongExcel.TabIndex = 8;
            this.lb_SoDong_trongExcel.Text = "...";
            // 
            // frm_ExportExcel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1074, 528);
            this.Controls.Add(this.lb_SoDong_trongExcel);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.cbb_Batch);
            this.Controls.Add(this.labelControl1);
            this.Name = "frm_ExportExcel";
            this.Text = "frm_ExportExcel";
            this.Load += new System.EventHandler(this.frm_ExportExcel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private System.Windows.Forms.ComboBox cbb_Batch;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label lb_SoDong_trongExcel;
    }
}