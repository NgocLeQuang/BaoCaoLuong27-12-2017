namespace BaoCaoLuong2018.BaoCaoLuonng2017.MyForm
{
    partial class frm_ManagerBatch
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
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions1 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_ManagerBatch));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btn_TaoBatch = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.IDBatch = new DevExpress.XtraGrid.Columns.GridColumn();
            this.fBatchName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.fdatecreated = new DevExpress.XtraGrid.Columns.GridColumn();
            this.fusercreate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.fPathPicture = new DevExpress.XtraGrid.Columns.GridColumn();
            this.fLocation = new DevExpress.XtraGrid.Columns.GridColumn();
            this.fSoLuongAnh = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemButtonEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btn_TaoBatch);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 479);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(856, 65);
            this.panelControl1.TabIndex = 0;
            // 
            // btn_TaoBatch
            // 
            this.btn_TaoBatch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_TaoBatch.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.btn_TaoBatch.Appearance.Options.UseFont = true;
            this.btn_TaoBatch.Location = new System.Drawing.Point(351, 5);
            this.btn_TaoBatch.Name = "btn_TaoBatch";
            this.btn_TaoBatch.Size = new System.Drawing.Size(142, 55);
            this.btn_TaoBatch.TabIndex = 0;
            this.btn_TaoBatch.Text = "Tạo Batch";
            this.btn_TaoBatch.Click += new System.EventHandler(this.btn_TaoBatch_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemButtonEdit1});
            this.gridControl1.Size = new System.Drawing.Size(856, 479);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.IDBatch,
            this.fBatchName,
            this.fdatecreated,
            this.fusercreate,
            this.fPathPicture,
            this.fLocation,
            this.fSoLuongAnh,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn1});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.CellValueChanging += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanging);
            // 
            // IDBatch
            // 
            this.IDBatch.AppearanceHeader.Options.UseTextOptions = true;
            this.IDBatch.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.IDBatch.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.IDBatch.Caption = "IDBatch";
            this.IDBatch.FieldName = "IDBatch";
            this.IDBatch.Name = "IDBatch";
            this.IDBatch.OptionsColumn.ReadOnly = true;
            this.IDBatch.Visible = true;
            this.IDBatch.VisibleIndex = 0;
            // 
            // fBatchName
            // 
            this.fBatchName.AppearanceHeader.Options.UseTextOptions = true;
            this.fBatchName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.fBatchName.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.fBatchName.Caption = "Tên Batch";
            this.fBatchName.FieldName = "fBatchName";
            this.fBatchName.Name = "fBatchName";
            this.fBatchName.OptionsColumn.ReadOnly = true;
            this.fBatchName.Visible = true;
            this.fBatchName.VisibleIndex = 1;
            // 
            // fdatecreated
            // 
            this.fdatecreated.AppearanceHeader.Options.UseTextOptions = true;
            this.fdatecreated.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.fdatecreated.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.fdatecreated.Caption = "Ngày tạo Batch";
            this.fdatecreated.FieldName = "fdatecreated";
            this.fdatecreated.Name = "fdatecreated";
            this.fdatecreated.OptionsColumn.ReadOnly = true;
            this.fdatecreated.Visible = true;
            this.fdatecreated.VisibleIndex = 2;
            // 
            // fusercreate
            // 
            this.fusercreate.AppearanceHeader.Options.UseTextOptions = true;
            this.fusercreate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.fusercreate.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.fusercreate.Caption = "User tạo Batch";
            this.fusercreate.FieldName = "fusercreate";
            this.fusercreate.Name = "fusercreate";
            this.fusercreate.OptionsColumn.ReadOnly = true;
            this.fusercreate.Visible = true;
            this.fusercreate.VisibleIndex = 3;
            // 
            // fPathPicture
            // 
            this.fPathPicture.AppearanceHeader.Options.UseTextOptions = true;
            this.fPathPicture.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.fPathPicture.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.fPathPicture.Caption = "Đường dẫn up batch";
            this.fPathPicture.FieldName = "fPathPicture";
            this.fPathPicture.Name = "fPathPicture";
            this.fPathPicture.OptionsColumn.ReadOnly = true;
            this.fPathPicture.Visible = true;
            this.fPathPicture.VisibleIndex = 4;
            // 
            // fLocation
            // 
            this.fLocation.AppearanceHeader.Options.UseTextOptions = true;
            this.fLocation.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.fLocation.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.fLocation.Caption = "Path xuất trong excel";
            this.fLocation.FieldName = "fLocation";
            this.fLocation.Name = "fLocation";
            this.fLocation.OptionsColumn.ReadOnly = true;
            this.fLocation.Visible = true;
            this.fLocation.VisibleIndex = 5;
            // 
            // fSoLuongAnh
            // 
            this.fSoLuongAnh.AppearanceHeader.Options.UseTextOptions = true;
            this.fSoLuongAnh.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.fSoLuongAnh.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.fSoLuongAnh.Caption = "Số lượng ảnh";
            this.fSoLuongAnh.FieldName = "fSoLuongAnh";
            this.fSoLuongAnh.Name = "fSoLuongAnh";
            this.fSoLuongAnh.OptionsColumn.ReadOnly = true;
            this.fSoLuongAnh.Visible = true;
            this.fSoLuongAnh.VisibleIndex = 6;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Chia User";
            this.gridColumn2.FieldName = "ChiaUser";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 7;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Công khai batch";
            this.gridColumn3.FieldName = "CongKhaiBatch";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 8;
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn1.Caption = "Xoá Batch";
            this.gridColumn1.ColumnEdit = this.repositoryItemButtonEdit1;
            this.gridColumn1.ImageAlignment = System.Drawing.StringAlignment.Center;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.ReadOnly = true;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 9;
            // 
            // repositoryItemButtonEdit1
            // 
            this.repositoryItemButtonEdit1.AutoHeight = false;
            editorButtonImageOptions1.Image = ((System.Drawing.Image)(resources.GetObject("editorButtonImageOptions1.Image")));
            this.repositoryItemButtonEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(editorButtonImageOptions1, DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, null)});
            this.repositoryItemButtonEdit1.Name = "repositoryItemButtonEdit1";
            this.repositoryItemButtonEdit1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.repositoryItemButtonEdit1.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.repositoryItemButtonEdit1_ButtonClick);
            // 
            // frm_ManagerBatch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(856, 544);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.panelControl1);
            this.Name = "frm_ManagerBatch";
            this.Text = "Quản lý Batch";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frm_ManagerBatch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btn_TaoBatch;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn IDBatch;
        private DevExpress.XtraGrid.Columns.GridColumn fBatchName;
        private DevExpress.XtraGrid.Columns.GridColumn fdatecreated;
        private DevExpress.XtraGrid.Columns.GridColumn fusercreate;
        private DevExpress.XtraGrid.Columns.GridColumn fPathPicture;
        private DevExpress.XtraGrid.Columns.GridColumn fLocation;
        private DevExpress.XtraGrid.Columns.GridColumn fSoLuongAnh;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
    }
}