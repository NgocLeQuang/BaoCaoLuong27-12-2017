using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

using DevExpress.XtraTab;
using System.IO;

using BaoCaoLuong2018.BaoCaoLuonng2017.MyUserControl;
using DevExpress.LookAndFeel;


namespace BaoCaoLuong2018.BaoCaoLuonng2017.MyForm
{
    partial class frm_Main
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
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.menu_Menu = new DevExpress.XtraBars.BarSubItem();
            this.btn_Logout = new DevExpress.XtraBars.BarButtonItem();
            this.btn_Exit = new DevExpress.XtraBars.BarButtonItem();
            this.menu_QuanLy = new DevExpress.XtraBars.BarSubItem();
            this.btn_QuanLyBatch = new DevExpress.XtraBars.BarButtonItem();
            this.btn_QuanLyUser = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem1 = new DevExpress.XtraBars.BarSubItem();
            this.btn_Check_DESO = new DevExpress.XtraBars.BarButtonItem();
            this.btn_Check_DEJP = new DevExpress.XtraBars.BarButtonItem();
            this.btn_XuatExcel = new DevExpress.XtraBars.BarButtonItem();
            this.btn_NangSuat = new DevExpress.XtraBars.BarButtonItem();
            this.btn_TienDo = new DevExpress.XtraBars.BarButtonItem();
            this.btn_Zoom = new DevExpress.XtraBars.BarButtonItem();
            this.skinBarSubItem1 = new DevExpress.XtraBars.SkinBarSubItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.btn_Check_NhamPhieu = new DevExpress.XtraBars.BarButtonItem();
            this.btn_ZoomImage = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.lb_City = new System.Windows.Forms.Label();
            this.lb_SoPhieuNhap = new DevExpress.XtraEditors.LabelControl();
            this.lb_SoPhieuCon = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.lb_TongSoHinh = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.lb_UserName = new DevExpress.XtraEditors.LabelControl();
            this.lb_IdImage = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.lb_fBatchName = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.tabcontrol = new DevExpress.XtraTab.XtraTabControl();
            this.tp_Loai_2 = new DevExpress.XtraTab.XtraTabPage();
            this.uc_Loai_21 = new BaoCaoLuong2018.BaoCaoLuonng2017.MyUserControl.uc_Loai_2();
            this.tp_Loai_4 = new DevExpress.XtraTab.XtraTabPage();
            this.uc_Loai_41 = new BaoCaoLuong2018.BaoCaoLuonng2017.MyUserControl.uc_Loai_4();
            this.tp_DEJP = new DevExpress.XtraTab.XtraTabPage();
            this.uc_DEJP1 = new BaoCaoLuong2018.BaoCaoLuonng2017.MyUserControl.uc_DEJP();
            this.tp_Loai_42 = new DevExpress.XtraTab.XtraTabPage();
            this.uc_Loai_421 = new BaoCaoLuong2018.BaoCaoLuonng2017.MyUserControl.uc_Loai_42();
            this.txt_Note = new System.Windows.Forms.TextBox();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.btn_Pause = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Submit_Logout = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Start_Submit = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl4 = new DevExpress.XtraEditors.PanelControl();
            this.txt_LoaiPhieu = new DevExpress.XtraEditors.TextEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.uc_PictureBox1 = new BaoCaoLuong2018.BaoCaoLuonng2017.MyUserControl.uc_PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabcontrol)).BeginInit();
            this.tabcontrol.SuspendLayout();
            this.tp_Loai_2.SuspendLayout();
            this.tp_Loai_4.SuspendLayout();
            this.tp_DEJP.SuspendLayout();
            this.tp_Loai_42.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).BeginInit();
            this.panelControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_LoaiPhieu.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.menu_Menu,
            this.btn_Logout,
            this.btn_Exit,
            this.menu_QuanLy,
            this.btn_QuanLyBatch,
            this.btn_QuanLyUser,
            this.barSubItem1,
            this.btn_Check_DESO,
            this.btn_Check_DEJP,
            this.btn_Check_NhamPhieu,
            this.btn_XuatExcel,
            this.btn_NangSuat,
            this.btn_TienDo,
            this.btn_ZoomImage,
            this.barButtonItem1,
            this.btn_Zoom,
            this.skinBarSubItem1});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 17;
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.menu_Menu),
            new DevExpress.XtraBars.LinkPersistInfo(this.menu_QuanLy),
            new DevExpress.XtraBars.LinkPersistInfo(this.btn_Zoom),
            new DevExpress.XtraBars.LinkPersistInfo(this.skinBarSubItem1)});
            this.bar2.OptionsBar.DrawBorder = false;
            this.bar2.OptionsBar.DrawDragBorder = false;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // menu_Menu
            // 
            this.menu_Menu.Caption = "&Menu";
            this.menu_Menu.Id = 0;
            this.menu_Menu.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btn_Logout),
            new DevExpress.XtraBars.LinkPersistInfo(this.btn_Exit)});
            this.menu_Menu.Name = "menu_Menu";
            // 
            // btn_Logout
            // 
            this.btn_Logout.Caption = "&Logout";
            this.btn_Logout.Id = 1;
            this.btn_Logout.Name = "btn_Logout";
            this.btn_Logout.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_Logout_ItemClick);
            // 
            // btn_Exit
            // 
            this.btn_Exit.Caption = "&Exit";
            this.btn_Exit.Id = 2;
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_Exit_ItemClick);
            // 
            // menu_QuanLy
            // 
            this.menu_QuanLy.Caption = "&Quản lý";
            this.menu_QuanLy.Id = 3;
            this.menu_QuanLy.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btn_QuanLyBatch),
            new DevExpress.XtraBars.LinkPersistInfo(this.btn_QuanLyUser),
            new DevExpress.XtraBars.LinkPersistInfo(this.barSubItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.btn_XuatExcel),
            new DevExpress.XtraBars.LinkPersistInfo(this.btn_NangSuat),
            new DevExpress.XtraBars.LinkPersistInfo(this.btn_TienDo)});
            this.menu_QuanLy.Name = "menu_QuanLy";
            // 
            // btn_QuanLyBatch
            // 
            this.btn_QuanLyBatch.Caption = "&Quản lý Batch";
            this.btn_QuanLyBatch.Id = 4;
            this.btn_QuanLyBatch.Name = "btn_QuanLyBatch";
            this.btn_QuanLyBatch.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_QuanLyBatch_ItemClick);
            // 
            // btn_QuanLyUser
            // 
            this.btn_QuanLyUser.Caption = "&Quản lý User";
            this.btn_QuanLyUser.Id = 5;
            this.btn_QuanLyUser.Name = "btn_QuanLyUser";
            this.btn_QuanLyUser.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_QuanLyUser_ItemClick);
            // 
            // barSubItem1
            // 
            this.barSubItem1.Caption = "&Check";
            this.barSubItem1.Id = 6;
            this.barSubItem1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btn_Check_DESO),
            new DevExpress.XtraBars.LinkPersistInfo(this.btn_Check_DEJP)});
            this.barSubItem1.Name = "barSubItem1";
            // 
            // btn_Check_DESO
            // 
            this.btn_Check_DESO.Caption = "Check_DE&SO";
            this.btn_Check_DESO.Id = 7;
            this.btn_Check_DESO.Name = "btn_Check_DESO";
            this.btn_Check_DESO.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_Check_DESO_ItemClick);
            // 
            // btn_Check_DEJP
            // 
            this.btn_Check_DEJP.Caption = "Check_DE&JP";
            this.btn_Check_DEJP.Id = 8;
            this.btn_Check_DEJP.Name = "btn_Check_DEJP";
            this.btn_Check_DEJP.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_Check_DEJP_ItemClick);
            // 
            // btn_XuatExcel
            // 
            this.btn_XuatExcel.Caption = "&Xuất Excel";
            this.btn_XuatExcel.Id = 10;
            this.btn_XuatExcel.Name = "btn_XuatExcel";
            this.btn_XuatExcel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_XuatExcel_ItemClick);
            // 
            // btn_NangSuat
            // 
            this.btn_NangSuat.Caption = "&Năng suất";
            this.btn_NangSuat.Id = 11;
            this.btn_NangSuat.Name = "btn_NangSuat";
            this.btn_NangSuat.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_NangSuat_ItemClick);
            // 
            // btn_TienDo
            // 
            this.btn_TienDo.Caption = "&Tiến độ";
            this.btn_TienDo.Id = 12;
            this.btn_TienDo.Name = "btn_TienDo";
            this.btn_TienDo.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_TienDo_ItemClick);
            // 
            // btn_Zoom
            // 
            this.btn_Zoom.Caption = "Zoom Image";
            this.btn_Zoom.Id = 15;
            this.btn_Zoom.Name = "btn_Zoom";
            this.btn_Zoom.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_Zoom_ItemClick);
            // 
            // skinBarSubItem1
            // 
            this.skinBarSubItem1.Caption = "&Đổi Themes";
            this.skinBarSubItem1.Id = 16;
            this.skinBarSubItem1.Name = "skinBarSubItem1";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(1344, 20);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 722);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(1344, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 20);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 702);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1344, 20);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 702);
            // 
            // btn_Check_NhamPhieu
            // 
            this.btn_Check_NhamPhieu.Caption = "Check_Nhầm &Phiếu";
            this.btn_Check_NhamPhieu.Id = 9;
            this.btn_Check_NhamPhieu.Name = "btn_Check_NhamPhieu";
            this.btn_Check_NhamPhieu.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_Check_NhamPhieu_ItemClick);
            // 
            // btn_ZoomImage
            // 
            this.btn_ZoomImage.Caption = "&Zoom Image";
            this.btn_ZoomImage.Id = 13;
            this.btn_ZoomImage.Name = "btn_ZoomImage";
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "barButtonItem1";
            this.barButtonItem1.Id = 14;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.lb_City);
            this.panelControl1.Controls.Add(this.lb_SoPhieuNhap);
            this.panelControl1.Controls.Add(this.lb_SoPhieuCon);
            this.panelControl1.Controls.Add(this.labelControl6);
            this.panelControl1.Controls.Add(this.lb_TongSoHinh);
            this.panelControl1.Controls.Add(this.labelControl4);
            this.panelControl1.Controls.Add(this.lb_UserName);
            this.panelControl1.Controls.Add(this.lb_IdImage);
            this.panelControl1.Controls.Add(this.labelControl5);
            this.panelControl1.Controls.Add(this.lb_fBatchName);
            this.panelControl1.Controls.Add(this.labelControl3);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 20);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1344, 27);
            this.panelControl1.TabIndex = 4;
            // 
            // lb_City
            // 
            this.lb_City.AutoSize = true;
            this.lb_City.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_City.ForeColor = System.Drawing.Color.Red;
            this.lb_City.Location = new System.Drawing.Point(6, 8);
            this.lb_City.Name = "lb_City";
            this.lb_City.Size = new System.Drawing.Size(41, 13);
            this.lb_City.TabIndex = 15;
            this.lb_City.Text = "label1";
            // 
            // lb_SoPhieuNhap
            // 
            this.lb_SoPhieuNhap.Appearance.ForeColor = System.Drawing.Color.DarkGreen;
            this.lb_SoPhieuNhap.Appearance.Options.UseForeColor = true;
            this.lb_SoPhieuNhap.Location = new System.Drawing.Point(576, 7);
            this.lb_SoPhieuNhap.Name = "lb_SoPhieuNhap";
            this.lb_SoPhieuNhap.Size = new System.Drawing.Size(24, 13);
            this.lb_SoPhieuNhap.TabIndex = 0;
            this.lb_SoPhieuNhap.Text = "1000";
            // 
            // lb_SoPhieuCon
            // 
            this.lb_SoPhieuCon.Appearance.ForeColor = System.Drawing.Color.Crimson;
            this.lb_SoPhieuCon.Appearance.Options.UseForeColor = true;
            this.lb_SoPhieuCon.Location = new System.Drawing.Point(456, 7);
            this.lb_SoPhieuCon.Name = "lb_SoPhieuCon";
            this.lb_SoPhieuCon.Size = new System.Drawing.Size(24, 13);
            this.lb_SoPhieuCon.TabIndex = 0;
            this.lb_SoPhieuCon.Text = "1000";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(516, 7);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(58, 13);
            this.labelControl6.TabIndex = 0;
            this.labelControl6.Text = "Số hình làm:";
            // 
            // lb_TongSoHinh
            // 
            this.lb_TongSoHinh.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.lb_TongSoHinh.Appearance.Options.UseForeColor = true;
            this.lb_TongSoHinh.Location = new System.Drawing.Point(336, 7);
            this.lb_TongSoHinh.Name = "lb_TongSoHinh";
            this.lb_TongSoHinh.Size = new System.Drawing.Size(24, 13);
            this.lb_TongSoHinh.TabIndex = 0;
            this.lb_TongSoHinh.Text = "1000";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(396, 7);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(59, 13);
            this.labelControl4.TabIndex = 0;
            this.labelControl4.Text = "Số hình còn:";
            // 
            // lb_UserName
            // 
            this.lb_UserName.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lb_UserName.Location = new System.Drawing.Point(1154, 6);
            this.lb_UserName.Name = "lb_UserName";
            this.lb_UserName.Size = new System.Drawing.Size(49, 13);
            this.lb_UserName.TabIndex = 0;
            this.lb_UserName.Text = "UserName";
            // 
            // lb_IdImage
            // 
            this.lb_IdImage.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lb_IdImage.Location = new System.Drawing.Point(954, 6);
            this.lb_IdImage.Name = "lb_IdImage";
            this.lb_IdImage.Size = new System.Drawing.Size(40, 13);
            this.lb_IdImage.TabIndex = 0;
            this.lb_IdImage.Text = "IdImage";
            this.lb_IdImage.Click += new System.EventHandler(this.lb_IdImage_Click);
            // 
            // labelControl5
            // 
            this.labelControl5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelControl5.Location = new System.Drawing.Point(1095, 6);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(53, 13);
            this.labelControl5.TabIndex = 0;
            this.labelControl5.Text = "UserName:";
            // 
            // lb_fBatchName
            // 
            this.lb_fBatchName.Location = new System.Drawing.Point(126, 7);
            this.lb_fBatchName.Name = "lb_fBatchName";
            this.lb_fBatchName.Size = new System.Drawing.Size(31, 13);
            this.lb_fBatchName.TabIndex = 0;
            this.lb_fBatchName.Text = "Batch:";
            this.lb_fBatchName.Click += new System.EventHandler(this.lb_fBatchName_Click);
            // 
            // labelControl3
            // 
            this.labelControl3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelControl3.Location = new System.Drawing.Point(904, 6);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(44, 13);
            this.labelControl3.TabIndex = 0;
            this.labelControl3.Text = "IdImage:";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(284, 7);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(51, 13);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "Tổng hình:";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(89, 7);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(31, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Batch:";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.splitContainerControl1);
            this.panelControl2.Controls.Add(this.panelControl3);
            this.panelControl2.Controls.Add(this.panelControl4);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelControl2.Location = new System.Drawing.Point(758, 47);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(586, 675);
            this.panelControl2.TabIndex = 5;
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel2;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(2, 28);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.tabcontrol);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.AutoScroll = true;
            this.splitContainerControl1.Panel2.Controls.Add(this.txt_Note);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(582, 613);
            this.splitContainerControl1.SplitterPosition = 57;
            this.splitContainerControl1.TabIndex = 4;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // tabcontrol
            // 
            this.tabcontrol.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabcontrol.Location = new System.Drawing.Point(0, 0);
            this.tabcontrol.Name = "tabcontrol";
            this.tabcontrol.SelectedTabPage = this.tp_Loai_2;
            this.tabcontrol.Size = new System.Drawing.Size(582, 551);
            this.tabcontrol.TabIndex = 1;
            this.tabcontrol.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tp_Loai_2,
            this.tp_Loai_4,
            this.tp_DEJP,
            this.tp_Loai_42});
            this.tabcontrol.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tabcontrol_KeyDown);
            // 
            // tp_Loai_2
            // 
            this.tp_Loai_2.Controls.Add(this.uc_Loai_21);
            this.tp_Loai_2.Name = "tp_Loai_2";
            this.tp_Loai_2.Size = new System.Drawing.Size(576, 523);
            this.tp_Loai_2.Text = "Loại 2";
            // 
            // uc_Loai_21
            // 
            this.uc_Loai_21.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uc_Loai_21.Location = new System.Drawing.Point(0, 0);
            this.uc_Loai_21.Name = "uc_Loai_21";
            this.uc_Loai_21.Size = new System.Drawing.Size(576, 523);
            this.uc_Loai_21.TabIndex = 0;
            // 
            // tp_Loai_4
            // 
            this.tp_Loai_4.Controls.Add(this.uc_Loai_41);
            this.tp_Loai_4.Name = "tp_Loai_4";
            this.tp_Loai_4.Size = new System.Drawing.Size(576, 523);
            this.tp_Loai_4.Text = "Loại 4";
            // 
            // uc_Loai_41
            // 
            this.uc_Loai_41.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uc_Loai_41.Location = new System.Drawing.Point(0, 0);
            this.uc_Loai_41.Name = "uc_Loai_41";
            this.uc_Loai_41.Size = new System.Drawing.Size(576, 523);
            this.uc_Loai_41.TabIndex = 0;
            // 
            // tp_DEJP
            // 
            this.tp_DEJP.Controls.Add(this.uc_DEJP1);
            this.tp_DEJP.Name = "tp_DEJP";
            this.tp_DEJP.Size = new System.Drawing.Size(576, 523);
            this.tp_DEJP.Text = "DEJP";
            // 
            // uc_DEJP1
            // 
            this.uc_DEJP1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uc_DEJP1.Location = new System.Drawing.Point(0, 0);
            this.uc_DEJP1.Name = "uc_DEJP1";
            this.uc_DEJP1.Size = new System.Drawing.Size(576, 523);
            this.uc_DEJP1.TabIndex = 0;
            // 
            // tp_Loai_42
            // 
            this.tp_Loai_42.Controls.Add(this.uc_Loai_421);
            this.tp_Loai_42.Name = "tp_Loai_42";
            this.tp_Loai_42.Size = new System.Drawing.Size(576, 523);
            this.tp_Loai_42.Text = "Loại 5";
            // 
            // uc_Loai_421
            // 
            this.uc_Loai_421.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uc_Loai_421.Location = new System.Drawing.Point(0, 0);
            this.uc_Loai_421.Name = "uc_Loai_421";
            this.uc_Loai_421.Size = new System.Drawing.Size(576, 523);
            this.uc_Loai_421.TabIndex = 0;
            // 
            // txt_Note
            // 
            this.txt_Note.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_Note.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Note.Location = new System.Drawing.Point(0, 0);
            this.txt_Note.Multiline = true;
            this.txt_Note.Name = "txt_Note";
            this.txt_Note.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_Note.Size = new System.Drawing.Size(582, 57);
            this.txt_Note.TabIndex = 1;
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.btn_Pause);
            this.panelControl3.Controls.Add(this.btn_Submit_Logout);
            this.panelControl3.Controls.Add(this.btn_Start_Submit);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl3.Location = new System.Drawing.Point(2, 641);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(582, 32);
            this.panelControl3.TabIndex = 0;
            // 
            // btn_Pause
            // 
            this.btn_Pause.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Pause.Location = new System.Drawing.Point(482, 4);
            this.btn_Pause.Name = "btn_Pause";
            this.btn_Pause.Size = new System.Drawing.Size(90, 25);
            this.btn_Pause.TabIndex = 3;
            this.btn_Pause.Text = "Tạm dừng (ESC)";
            this.btn_Pause.Click += new System.EventHandler(this.btn_Pause_Click);
            // 
            // btn_Submit_Logout
            // 
            this.btn_Submit_Logout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Submit_Logout.Location = new System.Drawing.Point(110, 5);
            this.btn_Submit_Logout.Name = "btn_Submit_Logout";
            this.btn_Submit_Logout.Size = new System.Drawing.Size(90, 25);
            this.btn_Submit_Logout.TabIndex = 1;
            this.btn_Submit_Logout.Text = "Submit + Logout";
            this.btn_Submit_Logout.Click += new System.EventHandler(this.btn_Submit_Logout_Click);
            // 
            // btn_Start_Submit
            // 
            this.btn_Start_Submit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Start_Submit.Location = new System.Drawing.Point(14, 4);
            this.btn_Start_Submit.Name = "btn_Start_Submit";
            this.btn_Start_Submit.Size = new System.Drawing.Size(90, 25);
            this.btn_Start_Submit.TabIndex = 0;
            this.btn_Start_Submit.Text = "Start";
            this.btn_Start_Submit.Click += new System.EventHandler(this.btn_Start_Submit_Click);
            // 
            // panelControl4
            // 
            this.panelControl4.Controls.Add(this.txt_LoaiPhieu);
            this.panelControl4.Controls.Add(this.labelControl7);
            this.panelControl4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl4.Location = new System.Drawing.Point(2, 2);
            this.panelControl4.Name = "panelControl4";
            this.panelControl4.Size = new System.Drawing.Size(582, 26);
            this.panelControl4.TabIndex = 2;
            // 
            // txt_LoaiPhieu
            // 
            this.txt_LoaiPhieu.Location = new System.Drawing.Point(101, 2);
            this.txt_LoaiPhieu.MenuManager = this.barManager1;
            this.txt_LoaiPhieu.Name = "txt_LoaiPhieu";
            this.txt_LoaiPhieu.Size = new System.Drawing.Size(189, 20);
            this.txt_LoaiPhieu.TabIndex = 1;
            this.txt_LoaiPhieu.TextChanged += new System.EventHandler(this.txt_LoaiPhieu_TextChanged);
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(43, 5);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(52, 13);
            this.labelControl7.TabIndex = 0;
            this.labelControl7.Text = "Loại phiếu:";
            // 
            // uc_PictureBox1
            // 
            this.uc_PictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uc_PictureBox1.Location = new System.Drawing.Point(0, 47);
            this.uc_PictureBox1.Name = "uc_PictureBox1";
            this.uc_PictureBox1.Size = new System.Drawing.Size(758, 675);
            this.uc_PictureBox1.TabIndex = 10;
            // 
            // timer1
            // 
            this.timer1.Interval = 10000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1344, 722);
            this.Controls.Add(this.uc_PictureBox1);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.KeyPreview = true;
            this.Name = "frm_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Báo Cáo Lương 2017 City_S";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_Main_FormClosing);
            this.Load += new System.EventHandler(this.frm_Main_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_Main_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabcontrol)).EndInit();
            this.tabcontrol.ResumeLayout(false);
            this.tp_Loai_2.ResumeLayout(false);
            this.tp_Loai_4.ResumeLayout(false);
            this.tp_DEJP.ResumeLayout(false);
            this.tp_Loai_42.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).EndInit();
            this.panelControl4.ResumeLayout(false);
            this.panelControl4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_LoaiPhieu.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarSubItem menu_Menu;
        private DevExpress.XtraBars.BarButtonItem btn_Logout;
        private DevExpress.XtraBars.BarButtonItem btn_Exit;
        private DevExpress.XtraBars.BarSubItem menu_QuanLy;
        private DevExpress.XtraBars.BarButtonItem btn_QuanLyBatch;
        private DevExpress.XtraBars.BarButtonItem btn_QuanLyUser;
        private DevExpress.XtraBars.BarSubItem barSubItem1;
        private DevExpress.XtraBars.BarButtonItem btn_Check_DESO;
        private DevExpress.XtraBars.BarButtonItem btn_Check_DEJP;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem btn_Check_NhamPhieu;
        private DevExpress.XtraBars.BarButtonItem btn_XuatExcel;
        private DevExpress.XtraBars.BarButtonItem btn_NangSuat;
        private DevExpress.XtraBars.BarButtonItem btn_TienDo;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraTab.XtraTabControl tabcontrol;
        private DevExpress.XtraTab.XtraTabPage tp_Loai_2;
        private DevExpress.XtraTab.XtraTabPage tp_Loai_4;
        private DevExpress.XtraTab.XtraTabPage tp_DEJP;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.SimpleButton btn_Submit_Logout;
        private DevExpress.XtraEditors.SimpleButton btn_Start_Submit;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl lb_SoPhieuNhap;
        private DevExpress.XtraEditors.LabelControl lb_SoPhieuCon;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl lb_TongSoHinh;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl lb_fBatchName;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl4;
        private DevExpress.XtraEditors.TextEdit txt_LoaiPhieu;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl lb_UserName;
        private DevExpress.XtraEditors.LabelControl lb_IdImage;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private BaoCaoLuong2018.BaoCaoLuonng2017.MyUserControl.uc_PictureBox uc_PictureBox1;
        private BaoCaoLuong2018.BaoCaoLuonng2017.MyUserControl.uc_Loai_2 uc_Loai_21;
        private BaoCaoLuong2018.BaoCaoLuonng2017.MyUserControl.uc_Loai_4 uc_Loai_41;
        private BaoCaoLuong2018.BaoCaoLuonng2017.MyUserControl.uc_DEJP uc_DEJP1;
        private DevExpress.XtraTab.XtraTabPage tp_Loai_42;
        private BaoCaoLuong2018.BaoCaoLuonng2017.MyUserControl.uc_Loai_42 uc_Loai_421;
        private DevExpress.XtraBars.BarButtonItem btn_ZoomImage;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem btn_Zoom;
        private DevExpress.XtraBars.SkinBarSubItem skinBarSubItem1;
        private System.Windows.Forms.Timer timer1;
        private DevExpress.XtraEditors.SimpleButton btn_Pause;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private Label lb_City;
        private TextBox txt_Note;
    }
}