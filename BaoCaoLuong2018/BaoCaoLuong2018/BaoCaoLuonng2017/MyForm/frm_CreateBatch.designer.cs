namespace BaoCaoLuong2018.BaoCaoLuonng2017.MyForm
{
    partial class frm_CreateBatch
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.txt_BatchName = new DevExpress.XtraEditors.TextEdit();
            this.txt_PathFolder = new DevExpress.XtraEditors.TextEdit();
            this.txt_Location = new DevExpress.XtraEditors.TextEdit();
            this.txt_UserCreate = new DevExpress.XtraEditors.TextEdit();
            this.txt_DateCreate = new DevExpress.XtraEditors.TextEdit();
            this.txt_ImagePath = new DevExpress.XtraEditors.TextEdit();
            this.btn_Browser = new DevExpress.XtraEditors.SimpleButton();
            this.btn_BrowserImage = new DevExpress.XtraEditors.SimpleButton();
            this.btn_CreateBatch = new DevExpress.XtraEditors.SimpleButton();
            this.progressBarControl1 = new DevExpress.XtraEditors.ProgressBarControl();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.lb_SoLuongHinh = new DevExpress.XtraEditors.LabelControl();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.txt_TruongSo4 = new DevExpress.XtraEditors.TextEdit();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.txt_TenHinhThu2 = new DevExpress.XtraEditors.TextEdit();
            this.chk_ChiaUser = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.txt_BatchName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_PathFolder.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Location.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_UserCreate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_DateCreate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_ImagePath.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.progressBarControl1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_TruongSo4.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_TenHinhThu2.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Location = new System.Drawing.Point(221, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(182, 27);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "TẠO BATCH MỚI";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(30, 68);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(81, 13);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "Tên Batch (đơn):";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(30, 109);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(101, 13);
            this.labelControl3.TabIndex = 1;
            this.labelControl3.Text = "Folder Batch (nhiều):";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(30, 149);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(58, 13);
            this.labelControl4.TabIndex = 1;
            this.labelControl4.Text = "Đường dẫn:";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(30, 192);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(75, 13);
            this.labelControl5.TabIndex = 1;
            this.labelControl5.Text = "User tạo Batch:";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(30, 236);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(78, 13);
            this.labelControl6.TabIndex = 1;
            this.labelControl6.Text = "Ngày tạo Batch:";
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(30, 281);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(91, 13);
            this.labelControl7.TabIndex = 1;
            this.labelControl7.Text = "Đường dẫn Image:";
            // 
            // txt_BatchName
            // 
            this.txt_BatchName.Location = new System.Drawing.Point(137, 65);
            this.txt_BatchName.Name = "txt_BatchName";
            this.txt_BatchName.Size = new System.Drawing.Size(304, 20);
            this.txt_BatchName.TabIndex = 2;
            this.txt_BatchName.EditValueChanged += new System.EventHandler(this.txt_BatchName_EditValueChanged);
            // 
            // txt_PathFolder
            // 
            this.txt_PathFolder.Location = new System.Drawing.Point(137, 106);
            this.txt_PathFolder.Name = "txt_PathFolder";
            this.txt_PathFolder.Size = new System.Drawing.Size(356, 20);
            this.txt_PathFolder.TabIndex = 2;
            this.txt_PathFolder.EditValueChanged += new System.EventHandler(this.txt_PathFolder_EditValueChanged);
            // 
            // txt_Location
            // 
            this.txt_Location.Location = new System.Drawing.Point(137, 146);
            this.txt_Location.Name = "txt_Location";
            this.txt_Location.Size = new System.Drawing.Size(356, 20);
            this.txt_Location.TabIndex = 2;
            // 
            // txt_UserCreate
            // 
            this.txt_UserCreate.Location = new System.Drawing.Point(137, 189);
            this.txt_UserCreate.Name = "txt_UserCreate";
            this.txt_UserCreate.Properties.ReadOnly = true;
            this.txt_UserCreate.Size = new System.Drawing.Size(174, 20);
            this.txt_UserCreate.TabIndex = 2;
            // 
            // txt_DateCreate
            // 
            this.txt_DateCreate.Location = new System.Drawing.Point(137, 233);
            this.txt_DateCreate.Name = "txt_DateCreate";
            this.txt_DateCreate.Properties.ReadOnly = true;
            this.txt_DateCreate.Size = new System.Drawing.Size(174, 20);
            this.txt_DateCreate.TabIndex = 2;
            // 
            // txt_ImagePath
            // 
            this.txt_ImagePath.Location = new System.Drawing.Point(137, 278);
            this.txt_ImagePath.Name = "txt_ImagePath";
            this.txt_ImagePath.Properties.ReadOnly = true;
            this.txt_ImagePath.Size = new System.Drawing.Size(356, 20);
            this.txt_ImagePath.TabIndex = 2;
            // 
            // btn_Browser
            // 
            this.btn_Browser.Location = new System.Drawing.Point(499, 104);
            this.btn_Browser.Name = "btn_Browser";
            this.btn_Browser.Size = new System.Drawing.Size(85, 23);
            this.btn_Browser.TabIndex = 3;
            this.btn_Browser.Text = "Browser...";
            this.btn_Browser.Click += new System.EventHandler(this.btn_Browser_Click);
            // 
            // btn_BrowserImage
            // 
            this.btn_BrowserImage.Location = new System.Drawing.Point(499, 276);
            this.btn_BrowserImage.Name = "btn_BrowserImage";
            this.btn_BrowserImage.Size = new System.Drawing.Size(85, 23);
            this.btn_BrowserImage.TabIndex = 3;
            this.btn_BrowserImage.Text = "Chọn Image...";
            this.btn_BrowserImage.Click += new System.EventHandler(this.btn_BrowserImage_Click);
            // 
            // btn_CreateBatch
            // 
            this.btn_CreateBatch.Location = new System.Drawing.Point(221, 416);
            this.btn_CreateBatch.Name = "btn_CreateBatch";
            this.btn_CreateBatch.Size = new System.Drawing.Size(164, 44);
            this.btn_CreateBatch.TabIndex = 4;
            this.btn_CreateBatch.Text = "Tạo Batch";
            this.btn_CreateBatch.Click += new System.EventHandler(this.btn_CreateBatch_Click);
            // 
            // progressBarControl1
            // 
            this.progressBarControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBarControl1.Location = new System.Drawing.Point(0, 493);
            this.progressBarControl1.Name = "progressBarControl1";
            this.progressBarControl1.Properties.Step = 1;
            this.progressBarControl1.Size = new System.Drawing.Size(632, 40);
            this.progressBarControl1.TabIndex = 5;
            // 
            // lb_SoLuongHinh
            // 
            this.lb_SoLuongHinh.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.lb_SoLuongHinh.Appearance.ForeColor = System.Drawing.Color.DarkGreen;
            this.lb_SoLuongHinh.Appearance.Options.UseFont = true;
            this.lb_SoLuongHinh.Appearance.Options.UseForeColor = true;
            this.lb_SoLuongHinh.Location = new System.Drawing.Point(137, 304);
            this.lb_SoLuongHinh.Name = "lb_SoLuongHinh";
            this.lb_SoLuongHinh.Size = new System.Drawing.Size(0, 19);
            this.lb_SoLuongHinh.TabIndex = 6;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(30, 332);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(62, 13);
            this.labelControl8.TabIndex = 1;
            this.labelControl8.Text = "Truong So 4:";
            this.labelControl8.Visible = false;
            // 
            // txt_TruongSo4
            // 
            this.txt_TruongSo4.Location = new System.Drawing.Point(137, 329);
            this.txt_TruongSo4.Name = "txt_TruongSo4";
            this.txt_TruongSo4.Size = new System.Drawing.Size(356, 20);
            this.txt_TruongSo4.TabIndex = 2;
            this.txt_TruongSo4.Visible = false;
            // 
            // labelControl9
            // 
            this.labelControl9.Location = new System.Drawing.Point(30, 376);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(73, 13);
            this.labelControl9.TabIndex = 1;
            this.labelControl9.Text = "Ten hinh thu 2:";
            this.labelControl9.Visible = false;
            // 
            // txt_TenHinhThu2
            // 
            this.txt_TenHinhThu2.Location = new System.Drawing.Point(137, 373);
            this.txt_TenHinhThu2.Name = "txt_TenHinhThu2";
            this.txt_TenHinhThu2.Size = new System.Drawing.Size(356, 20);
            this.txt_TenHinhThu2.TabIndex = 2;
            this.txt_TenHinhThu2.Visible = false;
            // 
            // chk_ChiaUser
            // 
            this.chk_ChiaUser.AutoSize = true;
            this.chk_ChiaUser.Location = new System.Drawing.Point(449, 67);
            this.chk_ChiaUser.Name = "chk_ChiaUser";
            this.chk_ChiaUser.Size = new System.Drawing.Size(72, 17);
            this.chk_ChiaUser.TabIndex = 10;
            this.chk_ChiaUser.Text = "Chia User";
            this.chk_ChiaUser.UseVisualStyleBackColor = true;
            // 
            // frm_CreateBatch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 533);
            this.Controls.Add(this.chk_ChiaUser);
            this.Controls.Add(this.lb_SoLuongHinh);
            this.Controls.Add(this.progressBarControl1);
            this.Controls.Add(this.btn_CreateBatch);
            this.Controls.Add(this.btn_BrowserImage);
            this.Controls.Add(this.btn_Browser);
            this.Controls.Add(this.txt_ImagePath);
            this.Controls.Add(this.txt_DateCreate);
            this.Controls.Add(this.txt_UserCreate);
            this.Controls.Add(this.txt_TenHinhThu2);
            this.Controls.Add(this.txt_TruongSo4);
            this.Controls.Add(this.txt_Location);
            this.Controls.Add(this.txt_PathFolder);
            this.Controls.Add(this.txt_BatchName);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.labelControl9);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.labelControl8);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Name = "frm_CreateBatch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tạo batch mới";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frm_CreateBatch_FormClosed);
            this.Load += new System.EventHandler(this.frm_CreateBatch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txt_BatchName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_PathFolder.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Location.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_UserCreate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_DateCreate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_ImagePath.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.progressBarControl1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_TruongSo4.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_TenHinhThu2.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.TextEdit txt_BatchName;
        private DevExpress.XtraEditors.TextEdit txt_PathFolder;
        private DevExpress.XtraEditors.TextEdit txt_Location;
        private DevExpress.XtraEditors.TextEdit txt_UserCreate;
        private DevExpress.XtraEditors.TextEdit txt_DateCreate;
        private DevExpress.XtraEditors.TextEdit txt_ImagePath;
        private DevExpress.XtraEditors.SimpleButton btn_Browser;
        private DevExpress.XtraEditors.SimpleButton btn_BrowserImage;
        private DevExpress.XtraEditors.SimpleButton btn_CreateBatch;
        private DevExpress.XtraEditors.ProgressBarControl progressBarControl1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private DevExpress.XtraEditors.LabelControl lb_SoLuongHinh;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.TextEdit txt_TruongSo4;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.TextEdit txt_TenHinhThu2;
        private System.Windows.Forms.CheckBox chk_ChiaUser;
    }
}