using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using DevExpress.LookAndFeel;
using DevExpress.XtraEditors;
using BaoCaoLuong2018.Properties;

namespace BaoCaoLuong2018.MyForm
{
    public partial class frm_Main : XtraForm
    {
        public frm_Main()
        {
            InitializeComponent();
        }

        int ChiaUser = -1;
        int LevelUser = -1;
        private string Folder = "";
        bool FlagLoad = false;
        private void btn_Logout_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult = DialogResult.Yes;
        }

        private void btn_Exit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Application.Exit();
        }

        private void btn_QuanLyBatch_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            new frm_ManagerBatch().ShowDialog();
        }

        private void frm_Main_Load(object sender, EventArgs e)
        {
            try
            {
                Global.FlagLoad = true;
                ChiaUser = -1;
                LevelUser = -1;
                lb_IdImage.Text = "";
                Global.FlagChangeSave = false;
                UserLookAndFeel.Default.SkinName = Settings.Default.ApplicationSkinName;
                splitMain.SplitterPosition = Settings.Default.PositionSplitMain;
                tab_CityO_Loai1.PageVisible = false;
                tab_CityO_Loai2.PageVisible = false;
                tab_CityO_Loai3.PageVisible = false;
                tab_CityO_JP.PageVisible = false;
                tab_CityN_Loai1.PageVisible = false;
                tab_CityN_Loai3.PageVisible = false;
                tab_CityN_LoaiJP.PageVisible = false;

                menu_QuanLy.Enabled = false;
                menu_Check.Enabled = false;
                btn_Check_DeSo.Enabled = false;
                btn_Check_DeSo_NhamPhieu.Enabled = false;
                btn_Check_DeSo_QC.Enabled = false;
                btn_Check_DeJP.Enabled = false;
                btn_Submit.Enabled = false;
                btn_Submit_Logout.Enabled = false;
                Folder = "";
                lb_fBatchName.Text = Global.StrBatch;
                lb_UserName.Text = Global.StrUserName;
                lb_City.Text = Global.StrCity;
                Global.FlagLoad = false;
                var checkDisableUser = (from w in Global.DbBpo.tbl_Users where w.Username == Global.StrUserName select w.IsDelete).FirstOrDefault();
                Global.DataNote = (from w in Global.Db.tbl_Notes select new Global.dataNote_ { City = w.City, LoaiPhieu = w.LoaiPhieu, Truong = w.Truong, Note = w.Note }).ToList();
                //Global.listdata13.Clear();
                //Global.listdata13 = (from w in Global.Db.tbl_Database_Truong13s select w.id3).ToList();
                //Folder = (from w in Global.Db.GetFolder(lb_fBatchName.Text) select w.fPathPicture).FirstOrDefault();
                if (checkDisableUser)
                {
                    MessageBox.Show("Tài khoản này đã vô hiệu hóa. Vui lòng liên hệ với Admin");
                    DialogResult = DialogResult.Yes;
                }
                if (Global.StrRole.ToUpper() == "DESO"|| Global.StrRole.ToUpper() == "DEJP")
                {
                    var ktBatch = (from w in Global.Db.CheckBatchChiaUser(Global.StrBatchID, Global.StrCity) select w.ChiaUser).FirstOrDefault();
                    if (ktBatch == true)
                    {
                        ChiaUser = 1;
                    }
                    else if (ktBatch == false)
                    {
                        ChiaUser = 0;
                    }
                    else
                    {
                        ChiaUser = -1;
                    }
                    var ktUser = (from w in Global.DbBpo.CheckLevelUser(Global.StrUserName) select w.NotGoodUser).FirstOrDefault();
                    if (ktUser == true)
                        LevelUser = 0;
                    else if (ktUser == false)
                        LevelUser = 1;
                    else
                        LevelUser = -1;
                    lb_TongPhieu.Text = (from w in Global.Db.tbl_Batches where w.BatchID == Global.StrBatchID & w.City == Global.StrCity select w.NumberImage).FirstOrDefault();
                    setValue();
                    if (Global.StrRole.ToUpper() == "DESO")
                    {
                        if (Global.StrCity == "CityO")
                        {
                            uC_CityO_Loai11.UC_CityO_Loai1_Load(null, null);
                            uC_CityO_Loai3_DeSo1.UC_CityO_Loai3_DeSo_Load(null, null);
                            uC_CityO_Loai11.Focus += UC_CityO_Loai3_DeSo1_Focus;
                            uC_CityO_Loai3_DeSo1.Focus += UC_CityO_Loai3_DeSo1_Focus;
                            tab_CityO_Loai1.PageVisible = true;
                            tab_CityO_Loai2.PageVisible = true;
                            tab_CityO_Loai3.PageVisible = true;
                            uC_CityO_Loai11.ResetData();
                            uC_CityO_Loai3_DeSo1.ResetData();
                        }
                        else if(Global.StrCity=="CityN")
                        {
                            uC_CityN_Loai11.UC_CityN_Loai1_Load(null, null);
                            uC_CityN_Loai31.UC_CityN_Loai3_Load(null, null);
                            uC_CityN_Loai11.Focus += UC_CityO_Loai3_DeSo1_Focus;
                            uC_CityN_Loai31.Focus += UC_CityO_Loai3_DeSo1_Focus;
                            tab_CityN_Loai1.PageVisible = true;
                            tab_CityN_Loai3.PageVisible = true;
                            uC_CityN_Loai11.ResetData();
                            uC_CityN_Loai31.ResetData();
                        }
                    }
                    else if (Global.StrRole.ToUpper() == "DEJP")
                    {
                        if (Global.StrCity == "CityO")
                        {
                            splitMain.SplitterPosition = 525;
                            uC_CityO_JP1.UC_CityO_JP_Load(null, null);
                            uC_CityO_JP1.Focus += UC_CityO_Loai3_DeSo1_Focus;
                            tab_CityO_JP.PageVisible = true;
                            uC_CityO_JP1.ResetData();
                        }
                        else if(Global.StrCity=="CityN")
                        {
                            splitMain.SplitterPosition = 525;
                            uC_CityN_JP1.UC_CityN_JP_Load(null, null);
                            uC_CityN_JP1.Focus += UC_CityO_Loai3_DeSo1_Focus;
                            tab_CityN_LoaiJP.PageVisible = true;
                            uC_CityN_JP1.ResetData();
                        }
                    }
                    menu_QuanLy.Enabled = false;
                    menu_Check.Enabled = false;
                    btn_Submit.Enabled = true;
                }
                else if (Global.StrRole.ToUpper() == "ADMIN")
                {
                    menu_QuanLy.Enabled = true;
                    menu_Check.Enabled = true;
                    btn_Check_DeSo.Enabled = true;
                    btn_Check_DeSo_NhamPhieu.Enabled = true;
                    btn_Check_DeSo_QC.Enabled = true;
                    btn_Check_DeJP.Enabled = true;
                    btn_Submit.Enabled = false;
                    btn_Submit_Logout.Enabled = false;
                    FlagLoad = true;
                    bool? OutSource = (from w in Global.DbBpo.tbl_Versions where w.IDProject == Global.StrIdProject select w.OutSource).FirstOrDefault();
                    if (OutSource == true)
                        ckOutSource.EditValue = true;
                    else
                        ckOutSource.EditValue = false;
                    FlagLoad = false;
                }
                else if (Global.StrRole.ToUpper() == "CHECKERDESO")
                {
                    menu_Check.Enabled = true;
                    menu_QuanLy.Enabled = false;
                    btn_Check_DeSo.Enabled = true;
                    btn_Check_DeSo_NhamPhieu.Enabled = true;
                    btn_Check_DeSo_QC.Enabled = true;
                    btn_Submit.Enabled = false;
                    btn_Submit_Logout.Enabled = false;
                }
                else if (Global.StrRole.ToUpper() == "CHECKERDEJP")
                {
                    menu_Check.Enabled = true;
                    menu_QuanLy.Enabled = false;
                    btn_Check_DeJP.Enabled = true;
                    btn_Submit.Enabled = false;
                    btn_Submit_Logout.Enabled = false;
                }
            }
            catch
            {
                MessageBox.Show("Kết nối internet của bạn bị gián đoạn, Vui lòng kiểm tra lại!");
                DialogResult = DialogResult.Yes;
            }
        }

        private void UC_CityO_Loai3_DeSo1_Focus(string Truong, string Tag)
        {
            txt_Note.Text = Tag;
        }
        
        private void setValue()
        {
            var a = (from w in Global.Db.GetSoLuongPhieu(Global.StrBatchID, Global.StrCity, Global.StrUserName,LevelUser+"" ,ChiaUser +"",Global.StrRole.ToUpper()) select new { w.SoPhieuCon, w.SoPhieuNhap }).FirstOrDefault();
            lb_SoPhieuCon.Text = a.SoPhieuCon + "";
            lb_SoPhieuNhap.Text = a.SoPhieuNhap + "";
        }
        public struct ImageImformation
        {
            public string ImageName { set; get; }
            public string LoaiPhieu { set; get; }
        }
        private ImageImformation getFilename=new ImageImformation();

        public void SetFieldLocation_IsNull()
        {
            Settings.Default.City = Global.StrCity;
            Settings.Default.BatchID = Global.StrBatchID;
            Settings.Default.ImageID = lb_IdImage.Text;
            Settings.Default.UserInput = Global.StrUserName;
            Settings.Default.LoaiPhieu = "";
            Settings.Default.Truong11 = "";
            Settings.Default.Truong14 = "";
            Settings.Default.Truong15 = "";
            Settings.Default.Truong16 = "";
            Settings.Default.Truong17 = "";
            Settings.Default.Truong18 = "";
            Settings.Default.Truong19 = "";
            Settings.Default.Truong20 = "";
            Settings.Default.Truong21 = "";
            Settings.Default.Truong22 = "";
            Settings.Default.Truong23 = "";
            Settings.Default.Truong24 = "";
            Settings.Default.Truong25 = "";
            Settings.Default.Truong26 = "";
            Settings.Default.Truong27 = "";
            Settings.Default.Truong28 = "";
            Settings.Default.Truong30 = "";
            Settings.Default.Truong31 = "";
            Settings.Default.Truong32 = "";
            Settings.Default.Truong33 = "";
            Settings.Default.Truong34 = "";
            Settings.Default.Truong35 = "";
            Settings.Default.Truong36 = "";
            Settings.Default.Truong37 = "";
            Settings.Default.Truong38 = "";
            Settings.Default.Truong39 = "";
            Settings.Default.Truong40 = "";
            Settings.Default.Truong41 = "";
            Settings.Default.Truong42 = "";
            Settings.Default.Truong43 = "";
            Settings.Default.Truong44 = "";
            Settings.Default.Truong45 = "";
            Settings.Default.Truong46 = "";
            Settings.Default.Truong47 = "";
            Settings.Default.Truong48 = "";
            Settings.Default.Truong49 = "";
            Settings.Default.Truong50 = "";
            Settings.Default.Truong51 = "";
            Settings.Default.Truong52 = "";
            Settings.Default.Truong53 = "";
            Settings.Default.Truong54 = "";
            Settings.Default.Truong55 = "";
            Settings.Default.Truong56 = "";
            Settings.Default.Truong57 = "";
            Settings.Default.Truong58 = "";
            Settings.Default.Truong59 = "";
            Settings.Default.Truong60 = "";
            Settings.Default.Truong62 = "";
            Settings.Default.Truong63 = "";
            Settings.Default.Truong64 = "";
            Settings.Default.Truong65 = "";
            Settings.Default.Truong66 = "";
            Settings.Default.Truong67 = "";
            Settings.Default.Truong68 = "";
            Settings.Default.Truong69 = "";
            Settings.Default.Truong70 = "";
            Settings.Default.Truong71 = "";
            Settings.Default.Truong72 = "";
            Settings.Default.Truong73 = "";
            Settings.Default.Truong74 = "";
            Settings.Default.Truong75 = "";
            Settings.Default.Truong76 = "";
            Settings.Default.Truong77 = "";
            Settings.Default.Truong78 = "";
            Settings.Default.Truong79 = "";
            Settings.Default.Truong80 = "";
            Settings.Default.Truong81 = "";
            Settings.Default.Truong82 = "";
            Settings.Default.Truong83 = "";
            Settings.Default.Truong84 = "";
            Settings.Default.Truong85 = "";
            Settings.Default.Truong86 = "";
            Settings.Default.Truong87 = "";
            Settings.Default.Truong88 = "";
            Settings.Default.Truong89 = "";
            Settings.Default.Truong90 = "";
            Settings.Default.Truong91 = "";
            Settings.Default.Truong92 = "";
            Settings.Default.Truong93 = "";
            Settings.Default.Truong94 = "";
            Settings.Default.Truong95 = "";
            Settings.Default.Truong96 = "";
            Settings.Default.Truong97 = "";
            Settings.Default.Truong98 = "";
            Settings.Default.Truong99 = "";
            Settings.Default.Truong100 = "";
            Settings.Default.Truong101 = "";
            Settings.Default.Truong102 = "";
            Settings.Default.Truong103 = "";
            Settings.Default.Truong104 = "";
            Settings.Default.Truong105 = "";
            Settings.Default.Truong106 = "";
            Settings.Default.Truong107 = "";
            Settings.Default.Truong108 = "";
            Settings.Default.Truong109 = "";
            Settings.Default.Truong110 = "";
            Settings.Default.Truong111 = "";
            Settings.Default.Truong112 = "";
            Settings.Default.Truong114 = "";
            Settings.Default.Truong116 = "";
            Settings.Default.Truong118 = "";
            Settings.Default.Truong120 = "";
            Settings.Default.Truong122 = "";
            Settings.Default.Truong124 = "";
            Settings.Default.Truong128 = "";
            Settings.Default.Truong130 = "";
            Settings.Default.Truong132 = "";
            Settings.Default.Truong134 = "";
            Settings.Default.Truong136 = "";
            Settings.Default.Truong140 = "";
            Settings.Default.Truong142 = "";
            Settings.Default.Truong144 = "";
            Settings.Default.Truong146 = "";
            Settings.Default.Truong148 = "";
            Settings.Default.Truong150 = "";
            Settings.Default.Truong138_1 = "";
            Settings.Default.Truong138_2 = "";
            Settings.Default.Truong138_3 = "";
            Settings.Default.Truong138_4 = "";
            Settings.Default.Truong28_1 = "";
            Settings.Default.Truong28_2 = "";
            Settings.Default.Truong61_1 = "";
            Settings.Default.Truong61_2 = "";
            Settings.Default.Truong61_3 = "";
            Settings.Default.Truong61_4 = "";
            Settings.Default.Truong74_1 = "";
            Settings.Default.Truong74_2 = "";
            Settings.Default.Truong74_3 = "";
            Settings.Default.Truong74_4 = "";
            Settings.Default.QC = false;
            Settings.Default.Save();
        }
        public void SetFieldLocation_IsValue()
        {
            if (Global.StrCity == "CityO")
            {
                if (Settings.Default.LoaiPhieu == "Loai1")
                {
                    uC_CityO_Loai11.chk_QC.Checked = Settings.Default.QC;
                    uC_CityO_Loai11.txt_Truong_018.Text = Settings.Default.Truong18;
                    uC_CityO_Loai11.txt_Truong_019.Text = Settings.Default.Truong19;
                    uC_CityO_Loai11.txt_Truong_021.Text = Settings.Default.Truong21;
                    uC_CityO_Loai11.txt_Truong_022.Text = Settings.Default.Truong22;
                    uC_CityO_Loai11.txt_Truong_023.Text = Settings.Default.Truong23;
                    uC_CityO_Loai11.txt_Truong_024.Text = Settings.Default.Truong24;
                    uC_CityO_Loai11.txt_Truong_025.Text = Settings.Default.Truong25;
                    uC_CityO_Loai11.txt_Truong_026.Text = Settings.Default.Truong26;
                    uC_CityO_Loai11.txt_Truong_027.Text = Settings.Default.Truong27;
                }
                else if (Settings.Default.LoaiPhieu == "Loai3")
                {
                    uC_CityO_Loai3_DeSo1.chk_QC.Checked = Settings.Default.QC;
                    uC_CityO_Loai3_DeSo1.txt_Truong_015.Text = Settings.Default.Truong15;
                    uC_CityO_Loai3_DeSo1.txt_Truong_017.Text = Settings.Default.Truong17;
                    uC_CityO_Loai3_DeSo1.txt_Truong_018.Text = Settings.Default.Truong18;
                    uC_CityO_Loai3_DeSo1.txt_Truong_019.Text = Settings.Default.Truong19;
                    uC_CityO_Loai3_DeSo1.txt_Truong_020.Text = Settings.Default.Truong20;
                    uC_CityO_Loai3_DeSo1.txt_Truong_021.Text = Settings.Default.Truong21;
                    uC_CityO_Loai3_DeSo1.txt_Truong_023.Text = Settings.Default.Truong23;
                    uC_CityO_Loai3_DeSo1.txt_Truong_024.Text = Settings.Default.Truong24;
                    uC_CityO_Loai3_DeSo1.txt_Truong_025.Text = Settings.Default.Truong25;
                    uC_CityO_Loai3_DeSo1.txt_Truong_026.Text = Settings.Default.Truong26;
                    uC_CityO_Loai3_DeSo1.txt_Truong_027.Text = Settings.Default.Truong27;
                    uC_CityO_Loai3_DeSo1.txt_Truong_028.Text = Settings.Default.Truong28;
                    uC_CityO_Loai3_DeSo1.txt_Truong_030.Text = Settings.Default.Truong30;
                    uC_CityO_Loai3_DeSo1.txt_Truong_031.Text = Settings.Default.Truong31;
                    uC_CityO_Loai3_DeSo1.txt_Truong_032.Text = Settings.Default.Truong32;
                    uC_CityO_Loai3_DeSo1.txt_Truong_033.Text = Settings.Default.Truong33;
                    uC_CityO_Loai3_DeSo1.txt_Truong_034.Text = Settings.Default.Truong34;
                    uC_CityO_Loai3_DeSo1.txt_Truong_035.Text = Settings.Default.Truong35;
                    uC_CityO_Loai3_DeSo1.txt_Truong_036.Text = Settings.Default.Truong36;
                    uC_CityO_Loai3_DeSo1.txt_Truong_037.Text = Settings.Default.Truong37;
                    uC_CityO_Loai3_DeSo1.txt_Truong_038.Text = Settings.Default.Truong38;
                    uC_CityO_Loai3_DeSo1.txt_Truong_039.Text = Settings.Default.Truong39;
                    uC_CityO_Loai3_DeSo1.txt_Truong_040.Text = Settings.Default.Truong40;
                    uC_CityO_Loai3_DeSo1.txt_Truong_041.Text = Settings.Default.Truong41;
                    uC_CityO_Loai3_DeSo1.txt_Truong_044.Text = Settings.Default.Truong44;
                    uC_CityO_Loai3_DeSo1.txt_Truong_045.Text = Settings.Default.Truong45;
                    uC_CityO_Loai3_DeSo1.txt_Truong_046.Text = Settings.Default.Truong46;
                    uC_CityO_Loai3_DeSo1.txt_Truong_048.Text = Settings.Default.Truong48;
                    uC_CityO_Loai3_DeSo1.txt_Truong_049.Text = Settings.Default.Truong49;
                    uC_CityO_Loai3_DeSo1.txt_Truong_050.Text = Settings.Default.Truong50;
                    uC_CityO_Loai3_DeSo1.txt_Truong_051.Text = Settings.Default.Truong51;
                    uC_CityO_Loai3_DeSo1.txt_Truong_052.Text = Settings.Default.Truong52;
                    uC_CityO_Loai3_DeSo1.txt_Truong_055.Text = Settings.Default.Truong55;
                    uC_CityO_Loai3_DeSo1.txt_Truong_056.Text = Settings.Default.Truong56;
                    uC_CityO_Loai3_DeSo1.txt_Truong_058.Text = Settings.Default.Truong58;
                    uC_CityO_Loai3_DeSo1.txt_Truong_059.Text = Settings.Default.Truong59;
                    uC_CityO_Loai3_DeSo1.txt_Truong_060.Text = Settings.Default.Truong60;
                    uC_CityO_Loai3_DeSo1.txt_Truong_061_1.Text = Settings.Default.Truong61_1;
                    uC_CityO_Loai3_DeSo1.txt_Truong_061_2.Text = Settings.Default.Truong61_2;
                    uC_CityO_Loai3_DeSo1.txt_Truong_061_3.Text = Settings.Default.Truong61_3;
                    uC_CityO_Loai3_DeSo1.txt_Truong_061_4.Text = Settings.Default.Truong61_4;
                    uC_CityO_Loai3_DeSo1.txt_Truong_062.Text = Settings.Default.Truong62;
                    uC_CityO_Loai3_DeSo1.txt_Truong_063.Text = Settings.Default.Truong63;
                    uC_CityO_Loai3_DeSo1.txt_Truong_064.Text = Settings.Default.Truong64;
                    uC_CityO_Loai3_DeSo1.txt_Truong_067.Text = Settings.Default.Truong67;
                    uC_CityO_Loai3_DeSo1.txt_Truong_069.Text = Settings.Default.Truong69;
                    uC_CityO_Loai3_DeSo1.txt_Truong_072.Text = Settings.Default.Truong72;
                    uC_CityO_Loai3_DeSo1.txt_Truong_073.Text = Settings.Default.Truong73;
                    uC_CityO_Loai3_DeSo1.txt_Truong_074.Text = Settings.Default.Truong74;
                    uC_CityO_Loai3_DeSo1.txt_Truong_075.Text = Settings.Default.Truong75;
                    uC_CityO_Loai3_DeSo1.txt_Truong_076.Text = Settings.Default.Truong76;
                    uC_CityO_Loai3_DeSo1.txt_Truong_077.Text = Settings.Default.Truong77;
                    uC_CityO_Loai3_DeSo1.txt_Truong_078.Text = Settings.Default.Truong78;
                    uC_CityO_Loai3_DeSo1.txt_Truong_079.Text = Settings.Default.Truong79;
                    uC_CityO_Loai3_DeSo1.txt_Truong_081.Text = Settings.Default.Truong81;
                    uC_CityO_Loai3_DeSo1.txt_Truong_082.Text = Settings.Default.Truong82;
                    uC_CityO_Loai3_DeSo1.txt_Truong_083.Text = Settings.Default.Truong83;
                    uC_CityO_Loai3_DeSo1.txt_Truong_084.Text = Settings.Default.Truong84;
                    uC_CityO_Loai3_DeSo1.txt_Truong_086.Text = Settings.Default.Truong86;
                    uC_CityO_Loai3_DeSo1.txt_Truong_087.Text = Settings.Default.Truong87;
                    uC_CityO_Loai3_DeSo1.txt_Truong_088.Text = Settings.Default.Truong88;
                    uC_CityO_Loai3_DeSo1.txt_Truong_089.Text = Settings.Default.Truong89;
                    uC_CityO_Loai3_DeSo1.txt_Truong_090.Text = Settings.Default.Truong90;
                    uC_CityO_Loai3_DeSo1.txt_Truong_095.Text = Settings.Default.Truong95;
                    uC_CityO_Loai3_DeSo1.txt_Truong_097.Text = Settings.Default.Truong97;
                    uC_CityO_Loai3_DeSo1.txt_Truong_099.Text = Settings.Default.Truong99;
                    uC_CityO_Loai3_DeSo1.txt_Truong_101.Text = Settings.Default.Truong101;
                    uC_CityO_Loai3_DeSo1.txt_Truong_103.Text = Settings.Default.Truong103;
                    uC_CityO_Loai3_DeSo1.txt_Truong_105.Text = Settings.Default.Truong105;
                    uC_CityO_Loai3_DeSo1.txt_Truong_107.Text = Settings.Default.Truong107;
                    uC_CityO_Loai3_DeSo1.txt_Truong_109.Text = Settings.Default.Truong109;
                    uC_CityO_Loai3_DeSo1.txt_Truong_110.Text = Settings.Default.Truong110;
                    uC_CityO_Loai3_DeSo1.txt_Truong_111.Text = Settings.Default.Truong111;
                }
            }
            else if (Global.StrCity == "CityN")
            {
                if (Settings.Default.LoaiPhieu == "Loai1")
                {
                    uC_CityN_Loai11.chk_QC.Checked = Settings.Default.QC;
                    uC_CityN_Loai11.txt_Truong_011.Text = Settings.Default.Truong11;
                    uC_CityN_Loai11.txt_Truong_014.Text = Settings.Default.Truong14;
                    uC_CityN_Loai11.txt_Truong_026.Text = Settings.Default.Truong26;
                    uC_CityN_Loai11.txt_Truong_016.Text = Settings.Default.Truong16;
                    uC_CityN_Loai11.txt_Truong_018.Text = Settings.Default.Truong18;
                    uC_CityN_Loai11.txt_Truong_020.Text = Settings.Default.Truong20;
                    uC_CityN_Loai11.txt_Truong_022.Text = Settings.Default.Truong22;
                    uC_CityN_Loai11.txt_Truong_024.Text = Settings.Default.Truong24;
                    uC_CityN_Loai11.txt_Truong_028_1.Text = Settings.Default.Truong28_1;
                    uC_CityN_Loai11.txt_Truong_028_2.Text = Settings.Default.Truong28_2;
                }
                else if (Settings.Default.LoaiPhieu == "Loai3")
                {
                    uC_CityN_Loai31.chk_QC.Checked = Settings.Default.QC;
                    uC_CityN_Loai31.txt_Truong_011.Text = Settings.Default.Truong11;
                    uC_CityN_Loai31.txt_Truong_014.Text = Settings.Default.Truong14;
                    uC_CityN_Loai31.txt_Truong_016.Text = Settings.Default.Truong16;
                    uC_CityN_Loai31.txt_Truong_020.Text = Settings.Default.Truong20;
                    uC_CityN_Loai31.txt_Truong_022.Text = Settings.Default.Truong22;
                    uC_CityN_Loai31.txt_Truong_024.Text = Settings.Default.Truong24;
                    uC_CityN_Loai31.txt_Truong_026.Text = Settings.Default.Truong26;
                    uC_CityN_Loai31.txt_Truong_028.Text = Settings.Default.Truong28;
                    uC_CityN_Loai31.txt_Truong_030.Text = Settings.Default.Truong30;
                    uC_CityN_Loai31.txt_Truong_032.Text = Settings.Default.Truong32;
                    uC_CityN_Loai31.txt_Truong_034.Text = Settings.Default.Truong34;
                    uC_CityN_Loai31.txt_Truong_036.Text = Settings.Default.Truong36;
                    uC_CityN_Loai31.txt_Truong_038.Text = Settings.Default.Truong38;
                    uC_CityN_Loai31.txt_Truong_040.Text = Settings.Default.Truong40;
                    uC_CityN_Loai31.txt_Truong_042.Text = Settings.Default.Truong42;
                    uC_CityN_Loai31.txt_Truong_044.Text = Settings.Default.Truong44;
                    uC_CityN_Loai31.txt_Truong_046.Text = Settings.Default.Truong46;
                    uC_CityN_Loai31.txt_Truong_048.Text = Settings.Default.Truong48;
                    uC_CityN_Loai31.txt_Truong_050.Text = Settings.Default.Truong50;
                    uC_CityN_Loai31.txt_Truong_052.Text = Settings.Default.Truong52;
                    uC_CityN_Loai31.txt_Truong_054.Text = Settings.Default.Truong54;
                    uC_CityN_Loai31.txt_Truong_056.Text = Settings.Default.Truong56;
                    uC_CityN_Loai31.txt_Truong_058.Text = Settings.Default.Truong58;
                    uC_CityN_Loai31.txt_Truong_060.Text = Settings.Default.Truong60;
                    uC_CityN_Loai31.txt_Truong_062.Text = Settings.Default.Truong62;
                    uC_CityN_Loai31.txt_Truong_064.Text = Settings.Default.Truong64;
                    uC_CityN_Loai31.txt_Truong_066.Text = Settings.Default.Truong66;
                    uC_CityN_Loai31.txt_Truong_068.Text = Settings.Default.Truong68;
                    uC_CityN_Loai31.txt_Truong_072.Text = Settings.Default.Truong72;
                    uC_CityN_Loai31.txt_Truong_074_1.Text = Settings.Default.Truong74_1;
                    uC_CityN_Loai31.txt_Truong_074_2.Text = Settings.Default.Truong74_2;
                    uC_CityN_Loai31.txt_Truong_074_3.Text = Settings.Default.Truong74_3;
                    uC_CityN_Loai31.txt_Truong_076.Text = Settings.Default.Truong76;
                    uC_CityN_Loai31.txt_Truong_082.Text = Settings.Default.Truong82;
                    uC_CityN_Loai31.txt_Truong_084.Text = Settings.Default.Truong84;
                    uC_CityN_Loai31.txt_Truong_086.Text = Settings.Default.Truong86;
                    uC_CityN_Loai31.txt_Truong_088.Text = Settings.Default.Truong88;
                    uC_CityN_Loai31.txt_Truong_090.Text = Settings.Default.Truong90;
                    uC_CityN_Loai31.txt_Truong_092.Text = Settings.Default.Truong92;
                    uC_CityN_Loai31.txt_Truong_094.Text = Settings.Default.Truong94;
                    uC_CityN_Loai31.txt_Truong_096.Text = Settings.Default.Truong96;
                    uC_CityN_Loai31.txt_Truong_098.Text = Settings.Default.Truong98;
                    uC_CityN_Loai31.txt_Truong_100.Text = Settings.Default.Truong100;
                    uC_CityN_Loai31.txt_Truong_102.Text = Settings.Default.Truong102;
                    uC_CityN_Loai31.txt_Truong_104.Text = Settings.Default.Truong104;
                    uC_CityN_Loai31.txt_Truong_106.Text = Settings.Default.Truong106;
                    uC_CityN_Loai31.txt_Truong_108.Text = Settings.Default.Truong108;
                    uC_CityN_Loai31.txt_Truong_110.Text = Settings.Default.Truong110;
                    uC_CityN_Loai31.txt_Truong_112.Text = Settings.Default.Truong112;
                    uC_CityN_Loai31.txt_Truong_114.Text = Settings.Default.Truong114;
                    uC_CityN_Loai31.txt_Truong_116.Text = Settings.Default.Truong116;
                    uC_CityN_Loai31.txt_Truong_118.Text = Settings.Default.Truong118;
                    uC_CityN_Loai31.txt_Truong_120.Text = Settings.Default.Truong120;
                    uC_CityN_Loai31.txt_Truong_122.Text = Settings.Default.Truong122;
                    uC_CityN_Loai31.txt_Truong_124.Text = Settings.Default.Truong124;
                    uC_CityN_Loai31.txt_Truong_126.Text = Settings.Default.Truong126;
                    uC_CityN_Loai31.txt_Truong_128.Text = Settings.Default.Truong128;
                    uC_CityN_Loai31.txt_Truong_130.Text = Settings.Default.Truong130;
                    uC_CityN_Loai31.txt_Truong_132.Text = Settings.Default.Truong132;
                    uC_CityN_Loai31.txt_Truong_134.Text = Settings.Default.Truong134;
                    uC_CityN_Loai31.txt_Truong_136.Text = Settings.Default.Truong136;
                    uC_CityN_Loai31.txt_Truong_138_1.Text = Settings.Default.Truong138_1;
                    uC_CityN_Loai31.txt_Truong_138_2.Text = Settings.Default.Truong138_2;
                    uC_CityN_Loai31.txt_Truong_138_3.Text = Settings.Default.Truong138_3;
                    uC_CityN_Loai31.txt_Truong_138_4.Text = Settings.Default.Truong138_4;
                    uC_CityN_Loai31.txt_Truong_140.Text = Settings.Default.Truong140;
                    uC_CityN_Loai31.txt_Truong_142.Text = Settings.Default.Truong142;
                    uC_CityN_Loai31.txt_Truong_144.Text = Settings.Default.Truong144;
                    uC_CityN_Loai31.txt_Truong_146.Text = Settings.Default.Truong146;
                    uC_CityN_Loai31.txt_Truong_150.Text = Settings.Default.Truong150;
                }
            }
        }
        public void SetFieldLocation_IsNull_JP()
        {
            Settings.Default.City = Global.StrCity;
            Settings.Default.BatchID = Global.StrBatchID;
            Settings.Default.ImageID = lb_IdImage.Text;
            Settings.Default.UserInput = Global.StrUserName;
            Settings.Default.Truong16 = "";
            Settings.Default.Truong94 = "";
            Settings.Default.Truong96 = "";
            Settings.Default.Truong98 = "";
            Settings.Default.Truong100 = "";
            Settings.Default.Truong102 = "";
            Settings.Default.Truong104 = "";
            Settings.Default.Truong106 = "";
            Settings.Default.Truong108 = "";
            Settings.Default.Truong18 = "";
            Settings.Default.Truong148 = "";
            Settings.Default.QC = false;
            Settings.Default.Save();
        }
        public void SetFieldLocation_IsValue_JP()
        {
            if (Global.StrCity == "CityO")
            {
                uC_CityO_JP1.txt_Truong_016.Text = Settings.Default.Truong16;
                uC_CityO_JP1.txt_Truong_094.Text = Settings.Default.Truong94;
                uC_CityO_JP1.txt_Truong_096.Text = Settings.Default.Truong96;
                uC_CityO_JP1.txt_Truong_098.Text = Settings.Default.Truong98;
                uC_CityO_JP1.txt_Truong_100.Text = Settings.Default.Truong100;
                uC_CityO_JP1.txt_Truong_102.Text = Settings.Default.Truong102;
                uC_CityO_JP1.txt_Truong_104.Text = Settings.Default.Truong104;
                uC_CityO_JP1.txt_Truong_106.Text = Settings.Default.Truong106;
                uC_CityO_JP1.txt_Truong_108.Text = Settings.Default.Truong108;
            }
            else if (Global.StrCity == "CityN")
            {
                uC_CityN_JP1.txt_Truong_018.Text = Settings.Default.Truong18;
                uC_CityN_JP1.txt_Truong_148.Text = Settings.Default.Truong148;
            }
            }
        string LoaiPhieu_TXT = "";
        private string GetImage()
        {
            lb_IdImage.Text = "";
            LoaiPhieu_TXT = "";
            getFilename.ImageName = "";
            getFilename.LoaiPhieu = "";
            Global.FlagChangeSave = true;
            if (ChiaUser == 1)  //Batch có chia User nhập
            {
                if (LevelUser == 1) //User Level Good
                {
                    var temp = (from w in Global.Db.GetImage_MissImage_New(Global.StrBatchID, Global.StrUserName, Global.StrCity, Global.StrRole) select new { w.IDImage,w.LoaiPhieu }).ToList();
                    getFilename.ImageName = temp[0]?.IDImage;
                    getFilename.LoaiPhieu = temp[0]?.LoaiPhieu;
                    if (string.IsNullOrEmpty(getFilename.ImageName))
                    {
                        try
                        {
                            var temp1 = (from w in Global.Db.GetImage_Group_Good_new(Global.StrBatchID, lb_UserName.Text, Global.StrCity, Global.StrRole) select new { w.IDImage, w.LoaiPhieu }).ToList();
                            getFilename.ImageName = temp1[0]?.IDImage;
                            getFilename.LoaiPhieu = temp1[0]?.LoaiPhieu;
                            if (string.IsNullOrEmpty(getFilename.ImageName))
                            {
                                return "NULL";
                            }
                            LoaiPhieu_TXT = getFilename.LoaiPhieu;
                            lb_IdImage.Text = getFilename.ImageName;
                            uc_PictureBox1.imageBox1.Image = null;
                            if (uc_PictureBox1.LoadImage(Global.Webservice + Global.StrBatchID + "/" + getFilename.ImageName, getFilename.ImageName, Settings.Default.ZoomImage) == "Error")
                            {
                                uc_PictureBox1.imageBox1.Image = Resources.svn_deleted;
                                return "Error";
                            }
                            if (Global.StrRole == "DESO")
                            {
                                SetFieldLocation_IsNull();
                            }
                            else if (Global.StrRole == "DEJP")
                            {
                                SetFieldLocation_IsNull_JP();
                            }
                        }
                        catch (Exception)
                        {
                            return "NULL";
                        }
                    }
                    else
                    {
                        LoaiPhieu_TXT = getFilename.LoaiPhieu;
                        lb_IdImage.Text = getFilename.ImageName;
                        uc_PictureBox1.imageBox1.Image = null;
                        if (uc_PictureBox1.LoadImage(Global.Webservice + Global.StrBatchID + "/" + getFilename.ImageName, getFilename.ImageName, Settings.Default.ZoomImage) == "Error")
                        {
                            uc_PictureBox1.imageBox1.Image = Resources.svn_deleted;
                            return "Error";
                        }
                        if (Settings.Default.BatchID == Global.StrBatchID & Settings.Default.ImageID == lb_IdImage.Text & Settings.Default.City == Global.StrCity & Settings.Default.UserInput.ToUpper() == Global.StrUserName.ToUpper())
                        {
                            if (Global.StrRole == "DESO")
                            {
                                SetFieldLocation_IsValue();
                            }
                            else if (Global.StrRole == "DEJP")
                            {
                                SetFieldLocation_IsValue_JP();
                            }
                        }
                        else
                        {
                            if (Global.StrRole == "DESO")
                            {
                                SetFieldLocation_IsNull();
                            }
                            else if (Global.StrRole == "DEJP")
                            {
                                SetFieldLocation_IsNull_JP();
                            }
                        }
                    }
                }
                else if (LevelUser == 0) //User Level Not Good
                {
                    var temp = (from w in Global.Db.GetImage_MissImage_New(Global.StrBatchID, Global.StrUserName, Global.StrCity, Global.StrRole) select new { w.IDImage, w.LoaiPhieu }).ToList();
                    getFilename.ImageName = temp[0]?.IDImage;
                    getFilename.LoaiPhieu = temp[0]?.LoaiPhieu;
                    if (string.IsNullOrEmpty(getFilename.ImageName))
                    {
                        try
                        {
                            var temp1 = (from w in Global.Db.GetImage_Group_Notgood_new(Global.StrBatchID, lb_UserName.Text,Global.StrCity, Global.StrRole) select new { w.IDImage, w.LoaiPhieu }).ToList();
                            getFilename.ImageName = temp1[0]?.IDImage;
                            getFilename.LoaiPhieu = temp1[0]?.LoaiPhieu;
                            if (string.IsNullOrEmpty(getFilename.ImageName))
                            {
                                return "NULL";
                            }
                            LoaiPhieu_TXT = getFilename.LoaiPhieu;
                            lb_IdImage.Text = getFilename.ImageName;
                            uc_PictureBox1.imageBox1.Image = null;
                            if (uc_PictureBox1.LoadImage(Global.Webservice + Global.StrBatchID + "/" + getFilename.ImageName, getFilename.ImageName, Settings.Default.ZoomImage) == "Error")
                            {
                                uc_PictureBox1.imageBox1.Image = Resources.svn_deleted;
                                return "Error";
                            }
                            if (Global.StrRole == "DESO")
                            {
                                SetFieldLocation_IsNull();
                            }
                            else if (Global.StrRole == "DEJP")
                            {
                                SetFieldLocation_IsNull_JP();
                            }
                        }
                        catch (Exception)
                        {
                            return "NULL";
                        }
                    }
                    else
                    {
                        lb_IdImage.Text = getFilename.ImageName;
                        LoaiPhieu_TXT = getFilename.LoaiPhieu;
                        uc_PictureBox1.imageBox1.Image = null;
                        if (uc_PictureBox1.LoadImage(Global.Webservice + Global.StrBatchID + "/" + getFilename.ImageName, getFilename.ImageName, Settings.Default.ZoomImage) == "Error")
                        {
                            uc_PictureBox1.imageBox1.Image = Resources.svn_deleted;
                            return "Error";
                        }
                        if (Settings.Default.BatchID == Global.StrBatchID & Settings.Default.ImageID == lb_IdImage.Text & Settings.Default.City == Global.StrCity & Settings.Default.UserInput.ToUpper() == Global.StrUserName.ToUpper())
                        {
                            if (Global.StrRole == "DESO")
                            {
                                SetFieldLocation_IsValue();
                            }
                            else if (Global.StrRole == "DEJP")
                            {
                                SetFieldLocation_IsValue_JP();
                            }
                        }
                        else
                        {
                            if (Global.StrRole == "DESO")
                            {
                                SetFieldLocation_IsNull();
                            }
                            else if (Global.StrRole == "DEJP")
                            {
                                SetFieldLocation_IsNull_JP();
                            }
                        }
                    }
                }
            }
            else if (ChiaUser == 0)  //Batch không chia user
            {
                var temp = (from w in Global.Db.GetImage_MissImage_New(Global.StrBatchID, Global.StrUserName, Global.StrCity, Global.StrRole) select new { w.IDImage, w.LoaiPhieu }).ToList();
                getFilename.ImageName = temp[0]?.IDImage;
                getFilename.LoaiPhieu = temp[0]?.LoaiPhieu;
                if (string.IsNullOrEmpty(getFilename.ImageName))
                {
                    try
                    {
                        var temp1 = (from w in Global.Db.LayHinhMoi_new(Global.StrBatchID, lb_UserName.Text,Global.StrCity, Global.StrRole) select new { w.IDImage, w.LoaiPhieu }).ToList();
                        getFilename.ImageName = temp1[0]?.IDImage;
                        getFilename.LoaiPhieu = temp1[0]?.LoaiPhieu;
                        if (string.IsNullOrEmpty(getFilename.ImageName))
                        {
                            return "NULL";
                        }
                        lb_IdImage.Text = getFilename.ImageName;
                        LoaiPhieu_TXT = getFilename.LoaiPhieu;
                        uc_PictureBox1.imageBox1.Image = null;
                        if (uc_PictureBox1.LoadImage(Global.Webservice + Global.StrBatchID + "/" + getFilename.ImageName, getFilename.ImageName, Settings.Default.ZoomImage) == "Error")
                        {
                            uc_PictureBox1.imageBox1.Image = Resources.svn_deleted;
                            return "Error";
                        }
                        if (Global.StrRole == "DESO")
                        {
                            SetFieldLocation_IsNull();
                        }
                        else if (Global.StrRole == "DEJP")
                        {
                            SetFieldLocation_IsNull_JP();
                        }
                    }
                    catch (Exception)
                    {
                        return "NULL";
                    }
                }
                else
                {
                    lb_IdImage.Text = getFilename.ImageName;
                    LoaiPhieu_TXT = getFilename.LoaiPhieu;
                    uc_PictureBox1.imageBox1.Image = null;
                    if (uc_PictureBox1.LoadImage(Global.Webservice + Global.StrBatchID + "/" + getFilename.ImageName, getFilename.ImageName, Settings.Default.ZoomImage) == "Error")
                    {
                        uc_PictureBox1.imageBox1.Image = Resources.svn_deleted;
                        return "Error";
                    }
                    if (Settings.Default.BatchID == Global.StrBatchID & Settings.Default.ImageID == lb_IdImage.Text & Settings.Default.City == Global.StrCity & Settings.Default.UserInput.ToUpper() == Global.StrUserName.ToUpper())
                    {
                        if (Global.StrRole == "DESO")
                        {
                            SetFieldLocation_IsValue();
                        }
                        else if (Global.StrRole == "DEJP")
                        {
                            SetFieldLocation_IsValue_JP();
                        }
                    }
                    else
                    {
                        if (Global.StrRole == "DESO")
                        {
                            SetFieldLocation_IsNull();
                        }
                        else if (Global.StrRole == "DEJP")
                        {
                            SetFieldLocation_IsNull_JP();
                        }
                    }
                }
            }
            if (Global.StrRole == "DESO")
            {
                if (Global.StrCity == "CityO")
                {
                    if (pn_Main.SelectedTabPage == tab_CityO_Loai1)
                        uC_CityO_Loai11.txt_Truong_018.Focus();
                    if (pn_Main.SelectedTabPage == tab_CityO_Loai3)
                        uC_CityO_Loai3_DeSo1.txt_Truong_015.Focus();
                }
                else if (Global.StrCity == "CityN")
                {
                    if (LoaiPhieu_TXT == "Loai1")
                    {
                        pn_Main.SelectedTabPage = tab_CityN_Loai1;
                        uC_CityN_Loai11.txt_Truong_011.Focus();
                    }
                    else if (LoaiPhieu_TXT == "Loai3")
                    {
                        pn_Main.SelectedTabPage = tab_CityN_Loai3;
                        uC_CityN_Loai31.txt_Truong_011.Focus();
                    }
                }
            }
            else if (Global.StrRole == "DEJP")
            {
                if (Global.StrCity == "CityO")
                {
                    uC_CityO_JP1.txt_Truong_016.Focus();
                }
                else if (Global.StrCity == "CityN")
                {
                    uC_CityN_JP1.txt_Truong_018.Focus();
                }
            }
            return "ok";
        }

        private string token = "", Image_temp="";
        private void btn_Submit_Click(object sender, EventArgs e)
        {
            token = "";
            Image_temp = "";
            var version = (from w in Global.DbBpo.tbl_Versions where w.IDProject == Global.StrIdProject select w.IDVersion).FirstOrDefault();
            if (version != Global.Version)
            {
                MessageBox.Show("Version bạn dùng đã cũ, vui lòng cập nhật phiên bản mới!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Global.RunUpdateVersion();
                DialogResult = DialogResult.Yes;
                return;
            }
            token = (from w in Global.DbBpo.tbl_TokenLogins where w.UserName == Global.StrUserName && w.IDProject == Global.StrIdProject select w.Token).FirstOrDefault();
            if (token != Global.Token)
            {
                MessageBox.Show(@"User logged on to another PC, please login again!");
                DialogResult = DialogResult.Yes;
            }
            if (btn_Submit.Text == "Start")
            {
                if (string.IsNullOrEmpty(Global.StrBatchID))
                {
                    MessageBox.Show("Vui lòng đăng nhập lại và chọn Batch!");
                    return;
                }
                uC_CityO_JP1.ResetData();
                uC_CityO_Loai11.ResetData();
                uC_CityO_Loai3_DeSo1.ResetData();
                uC_CityN_JP1.ResetData();
                uC_CityN_Loai11.ResetData();
                uC_CityN_Loai31.ResetData();
                Image_temp = GetImage();
                if (Image_temp == "NULL")
                {
                    MessageBox.Show(@"Hoàn thành batch '" + lb_fBatchName.Text + "'");
                    Global.StrBatch = "";
                    Global.StrBatchID = "";
                    Folder = "";
                    if (LevelUser == 0)
                    {
                        var listResult = Global.Db.GetBatNotFinishDeNotGood(Global.StrUserName,Global.StrCity, Global.StrRole).ToList();
                        if (listResult.Count > 0)
                        {
                            if (MessageBox.Show(@"Batch tiếp theo: " + listResult[0].BatchName + "\nBạn muốn làm tiếp ??", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                            {
                                if (Global.CheckOutSource(Global.StrRole) == true)
                                {
                                    MessageBox.Show("Hiện tại dự án chưa có nhu cầu về nguồn nhân lực bên ngoài");
                                    btn_Logout_ItemClick(null, null);
                                }
                                Global.StrBatchID = listResult[0].BatchID;
                                Global.StrBatch = listResult[0].BatchName;
                                //Folder = (from w in Global.Db.GetFolder(listResult[0].BatchID) select w.fPathPicture).FirstOrDefault();

                                var ktBatch = (from w in Global.Db.CheckBatchChiaUser(listResult[0].BatchID,Global.StrCity) select w.ChiaUser).FirstOrDefault();
                                if (ktBatch == true)
                                {
                                    ChiaUser = 1;
                                }
                                else if (ktBatch == false)
                                {
                                    ChiaUser = 0;
                                }
                                else
                                {
                                    ChiaUser = -1;
                                }
                                lb_fBatchName.Text = Global.StrBatch;
                                lb_IdImage.Text = "";
                                lb_TongPhieu.Text = (from w in Global.Db.tbl_Images where w.BatchID == Global.StrBatchID select w.IDImage).Count().ToString();
                                setValue();
                                btn_Submit.Text = @"Start";
                                btn_Submit_Click(null, null);
                            }
                            else
                            {
                                btn_Logout_ItemClick(null, null);
                            }
                        }
                        else
                        {
                            btn_Logout_ItemClick(null, null);
                        }
                    }
                    else
                    {
                        var listResult = Global.Db.GetBatNotFinishDeGood(Global.StrUserName,Global.StrCity, Global.StrRole).ToList();
                        if (listResult.Count > 0)
                        {
                            if (MessageBox.Show(@"Batch tiếp theo: " + listResult[0].BatchName + "\nBạn muốn làm tiếp ??", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                            {
                                if (Global.CheckOutSource(Global.StrRole) == true)
                                {
                                    MessageBox.Show("Hiện tại dự án chưa có nhu cầu về nguồn nhân lực bên ngoài");
                                    btn_Logout_ItemClick(null, null);
                                }
                                Global.StrBatch = listResult[0].BatchName;
                                Global.StrBatchID = listResult[0].BatchID;
                                //Folder = (from w in Global.Db.GetFolder(listResult[0].fbatchname) select w.fPathPicture).FirstOrDefault();
                                var ktBatch = (from w in Global.Db.CheckBatchChiaUser(listResult[0].BatchID,Global.StrCity) select w.ChiaUser).FirstOrDefault();
                                if (ktBatch == true)
                                {
                                    ChiaUser = 1;
                                }
                                else if (ktBatch == false)
                                {
                                    ChiaUser = 0;
                                }
                                else
                                {
                                    ChiaUser = -1;
                                }
                                lb_fBatchName.Text = Global.StrBatch;
                                lb_TongPhieu.Text = (from w in Global.Db.tbl_Images where w.BatchID == Global.StrBatchID select w.IDImage).Count().ToString();
                                setValue();
                                btn_Submit.Text = @"Start";
                                btn_Submit_Click(null, null);
                            }
                            else
                            {
                                btn_Logout_ItemClick(null, null);
                            }
                        }
                        else
                        {
                            btn_Logout_ItemClick(null, null);
                        }
                    }
                }
                else if (Image_temp == "Error")
                {
                    MessageBox.Show("Không thể load hình!");
                    btn_Logout_ItemClick(null, null);
                }
                setValue();
                btn_Submit.Text = "Submit";
                btn_Submit_Logout.Enabled = true;
            }
            else
            {
                if (Global.StrRole == "DESO")
                {
                    if (pn_Main.SelectedTabPage == tab_CityO_Loai1)
                    {
                        if (uC_CityO_Loai11.IsEmpty())
                        {
                            if (MessageBox.Show("Bạn đang để trống 1 hoặc nhiều trường. Bạn có muốn submit không? \r\nYes = Submit và chuyển qua hình khác<Nhấn Enter>\r\nNo = nhập lại trường trống cho hình này.<nhấn phím N>", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.No)
                                return;
                        }
                        uC_CityO_Loai11.Save_CityO_Loai1(Global.StrBatchID, lb_IdImage.Text);
                    }
                    else if(pn_Main.SelectedTabPage==tab_CityO_Loai2)
                    {
                        Global.Db.Insert_DESo_CityO(Global.StrBatchID, lb_IdImage.Text, Global.StrUserName, false, "Loai2",
                                                    "", "", "", "", "", "", "", "", "", "",
                                                    "", "", "", "", "", "", "", "", "", "",
                                                    "", "", "", "", "", "", "", "", "", "",
                                                    "", "", "", "", "", "", "", "", "", "",
                                                    "", "", "", "", "", "", "", "", "", "",
                                                    "", "", "", "", "", "", "", "", "", "",
                                                    "", "", "", "", "", "", "", "", "", "",
                                                    "", "", "", "", "", "", "", "", "", "",
                                                    "", "", "", "", "", "", "", "", "", "",
                                                    "", "", "", "", "", "", "", "", "", "",
                                                    "", "", "", "", "", "", "", "", "", "",
                                                    "", "","","","","");
                    }
                    else if (pn_Main.SelectedTabPage == tab_CityO_Loai3)
                    {
                        if (uC_CityO_Loai3_DeSo1.IsEmpty())
                        {
                            if (MessageBox.Show("Bạn đang để trống 1 hoặc nhiều trường. Bạn có muốn submit không? \r\nYes = Submit và chuyển qua hình khác<Nhấn Enter>\r\nNo = nhập lại trường trống cho hình này.<nhấn phím N>", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.No)
                                return;
                        }
                        if (!uC_CityO_Loai3_DeSo1.CheckSubmit())
                        {
                            MessageBox.Show("Điều kiện nhập sai tại trường 33 và 34. Bạn hãy kiểm tra lại", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        uC_CityO_Loai3_DeSo1.Save_CityO_Loai3(Global.StrBatchID, lb_IdImage.Text);
                    }
                    else if (pn_Main.SelectedTabPage == tab_CityN_Loai1)
                    {
                        if (uC_CityN_Loai11.IsEmpty())
                        {
                            if (MessageBox.Show("Bạn đang để trống 1 hoặc nhiều trường. Bạn có muốn submit không? \r\nYes = Submit và chuyển qua hình khác<Nhấn Enter>\r\nNo = nhập lại trường trống cho hình này.<nhấn phím N>", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.No)
                                return;
                        }
                        uC_CityN_Loai11.Save_CityN_Loai1(Global.StrBatchID, lb_IdImage.Text);
                    }
                    else if (pn_Main.SelectedTabPage == tab_CityN_Loai3)
                    {
                        if (uC_CityN_Loai31.IsEmpty())
                        {
                            if (MessageBox.Show("Bạn đang để trống 1 hoặc nhiều trường. Bạn có muốn submit không? \r\nYes = Submit và chuyển qua hình khác<Nhấn Enter>\r\nNo = nhập lại trường trống cho hình này.<nhấn phím N>", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.No)
                                return;
                        }
                        if (!uC_CityN_Loai31.CheckSubmit())
                        {
                            MessageBox.Show("Điều kiện nhập sai tại trường 50 và 52. Bạn hãy kiểm tra lại", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        uC_CityN_Loai31.Save_CityN_Loai3(Global.StrBatchID, lb_IdImage.Text);
                    }
                    uC_CityO_Loai11.ResetData();
                    uC_CityO_Loai3_DeSo1.ResetData();
                    uC_CityN_Loai11.ResetData();
                    uC_CityN_Loai31.ResetData();
                }
                else if (Global.StrRole == "DEJP")
                {
                    if (pn_Main.SelectedTabPage == tab_CityO_JP)
                    {
                        if (uC_CityO_JP1.IsEmpty())
                        {
                            if (MessageBox.Show("Bạn đang để trống 1 hoặc nhiều trường. Bạn có muốn submit không? \r\nYes = Submit và chuyển qua hình khác<Nhấn Enter>\r\nNo = nhập lại trường trống cho hình này.<nhấn phím N>", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.No)
                                return;
                        }
                        if (uC_CityO_JP1.bSubmit)
                        {
                            MessageBox.Show("Có ký tự không hợp lệ. Vui lòng kiểm tra lại!");
                            return;
                        }
                        uC_CityO_JP1.Save_CityO_JP(Global.StrBatchID, lb_IdImage.Text);
                    }
                    else if (pn_Main.SelectedTabPage == tab_CityN_LoaiJP)
                    {
                        if (uC_CityN_JP1.IsEmpty())
                        {
                            if (MessageBox.Show("Bạn đang để trống 1 hoặc nhiều trường. Bạn có muốn submit không? \r\nYes = Submit và chuyển qua hình khác<Nhấn Enter>\r\nNo = nhập lại trường trống cho hình này.<nhấn phím N>", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.No)
                                return;
                        }
                        if (uC_CityN_JP1.bSubmit)
                        {
                            MessageBox.Show("Có ký tự không hợp lệ. Vui lòng kiểm tra lại!");
                            return;
                        }
                        uC_CityN_JP1.Save_CityN_JP(Global.StrBatchID, lb_IdImage.Text);
                    }
                    uC_CityO_JP1.ResetData();
                    uC_CityN_JP1.ResetData();
                }
                setValue();
                Image_temp = GetImage();
                if (Image_temp == "NULL")
                {
                    MessageBox.Show(@"Hoàn thành batch '" + lb_fBatchName.Text + "'");
                    Global.StrBatch = "";
                    Global.StrBatchID = "";
                    Folder = "";
                    if (LevelUser == 0)
                    {
                        var listResult = Global.Db.GetBatNotFinishDeNotGood(Global.StrUserName,Global.StrCity,Global.StrRole).ToList();
                        if (listResult.Count > 0)
                        {
                            if (MessageBox.Show(@"Batch tiếp theo: " + listResult[0].BatchName + "\nBạn muốn làm tiếp ??", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                            {
                                if (Global.CheckOutSource(Global.StrRole) == true)
                                {
                                    MessageBox.Show("Hiện tại dự án chưa có nhu cầu về nguồn nhân lực bên ngoài");
                                    btn_Logout_ItemClick(null, null);
                                }
                                Global.StrBatch = listResult[0].BatchName;
                                Global.StrBatchID = listResult[0].BatchID;
                                //Folder = (from w in Global.Db.GetFolder(listResult[0].BatchID) select w.fPathPicture).FirstOrDefault();
                                var ktBatch = (from w in Global.Db.CheckBatchChiaUser(listResult[0].BatchID,Global.StrCity) select w.ChiaUser).FirstOrDefault();
                                if (ktBatch == true)
                                {
                                    ChiaUser = 1;
                                }
                                else if (ktBatch == false)
                                {
                                    ChiaUser = 0;
                                }
                                else
                                {
                                    ChiaUser = -1;
                                }
                                lb_fBatchName.Text = Global.StrBatch;
                                lb_IdImage.Text = "";
                                lb_TongPhieu.Text = (from w in Global.Db.tbl_Images where w.BatchID == Global.StrBatchID select w.IDImage).Count().ToString();
                                setValue();
                                btn_Submit.Text = @"Start";
                                btn_Submit_Click(null, null);
                            }
                            else
                            {
                                btn_Logout_ItemClick(null, null);
                            }
                        }
                        else
                        {
                            btn_Logout_ItemClick(null, null);
                        }
                    }
                    else
                    {
                        var listResult = Global.Db.GetBatNotFinishDeGood(Global.StrUserName,Global.StrCity, Global.StrRole).ToList();
                        if (listResult.Count > 0)
                        {
                            if (MessageBox.Show(@"Batch tiếp theo: " + listResult[0].BatchName + "\nBạn muốn làm tiếp ??", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                            {
                                if (Global.CheckOutSource(Global.StrRole) == true)
                                {
                                    MessageBox.Show("Hiện tại dự án chưa có nhu cầu về nguồn nhân lực bên ngoài");
                                    btn_Logout_ItemClick(null, null);
                                }
                                Global.StrBatch = listResult[0].BatchName;
                                Global.StrBatchID = listResult[0].BatchID;
                                //Folder = (from w in Global.Db.GetFolder(listResult[0].BatchID) select w.fPathPicture).FirstOrDefault();
                                var ktBatch = (from w in Global.Db.CheckBatchChiaUser(listResult[0].BatchID,Global.StrCity) select w.ChiaUser).FirstOrDefault();
                                if (ktBatch == true)
                                {
                                    ChiaUser = 1;
                                }
                                else if (ktBatch == false)
                                {
                                    ChiaUser = 0;
                                }
                                else
                                {
                                    ChiaUser = -1;
                                }
                                lb_fBatchName.Text = Global.StrBatch;
                                lb_TongPhieu.Text = (from w in Global.Db.tbl_Images where w.BatchID == Global.StrBatchID select w.IDImage).Count().ToString();
                                setValue();
                                btn_Submit.Text = @"Start";
                                btn_Submit_Click(null, null);
                            }
                            else
                            {
                                btn_Logout_ItemClick(null, null);
                            }
                        }
                        else
                        {
                            btn_Logout_ItemClick(null, null);
                        }
                    }
                }
                else if (Image_temp == "Error")
                {
                    MessageBox.Show("Không thể load hình!");
                    btn_Logout_ItemClick(null, null);
                }
            }
        }

        private void btn_Submit_Logout_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lb_IdImage.Text))
                return;
            var version = (from w in Global.DbBpo.tbl_Versions where w.IDProject == Global.StrIdProject select w.IDVersion).FirstOrDefault();
            if (version != Global.Version)
            {
                MessageBox.Show("Version bạn dùng đã cũ, vui lòng cập nhật phiên bản mới!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Global.RunUpdateVersion();
                DialogResult = DialogResult.Yes;
                return;
            }
            token = (from w in Global.DbBpo.tbl_TokenLogins where w.UserName == Global.StrUserName && w.IDProject == Global.StrIdProject select w.Token).FirstOrDefault();
            if (token != Global.Token)
            {
                MessageBox.Show(@"User logged on to another PC, please login again!");
                DialogResult = DialogResult.Yes;
            }
            if (Global.StrRole == "DESO")
            {
                if (pn_Main.SelectedTabPage == tab_CityO_Loai1)
                {
                    if (uC_CityO_Loai11.IsEmpty())
                    {
                        if (MessageBox.Show("Bạn đang để trống 1 hoặc nhiều trường. Bạn có muốn submit không? \r\nYes = Submit và chuyển qua hình khác<Nhấn Enter>\r\nNo = nhập lại trường trống cho hình này.<nhấn phím N>", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.No)
                            return;
                    }
                    uC_CityO_Loai11.Save_CityO_Loai1(Global.StrBatchID, lb_IdImage.Text);
                }
                else if (pn_Main.SelectedTabPage == tab_CityO_Loai2)
                {
                    Global.Db.Insert_DESo_CityO(Global.StrBatchID, lb_IdImage.Text, Global.StrUserName, false, "Loai2",
                                                "", "", "", "", "", "", "", "", "", "",
                                                "", "", "", "", "", "", "", "", "", "",
                                                "", "", "", "", "", "", "", "", "", "",
                                                "", "", "", "", "", "", "", "", "", "",
                                                "", "", "", "", "", "", "", "", "", "",
                                                "", "", "", "", "", "", "", "", "", "",
                                                "", "", "", "", "", "", "", "", "", "",
                                                "", "", "", "", "", "", "", "", "", "",
                                                "", "", "", "", "", "", "", "", "", "",
                                                "", "", "", "", "", "", "", "", "", "",
                                                "", "", "", "", "", "", "", "", "", "",
                                                "", "", "", "", "", "");
                }
                else if (pn_Main.SelectedTabPage == tab_CityO_Loai3)
                {
                    if (uC_CityO_Loai3_DeSo1.IsEmpty())
                    {
                        if (MessageBox.Show("Bạn đang để trống 1 hoặc nhiều trường. Bạn có muốn submit không? \r\nYes = Submit và chuyển qua hình khác<Nhấn Enter>\r\nNo = nhập lại trường trống cho hình này.<nhấn phím N>", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.No)
                            return;
                    }
                    if (!uC_CityO_Loai3_DeSo1.CheckSubmit())
                    {
                        MessageBox.Show("Điều kiện nhập sai tại trường 33 và 34. Bạn hãy kiểm tra lại", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    uC_CityO_Loai3_DeSo1.Save_CityO_Loai3(Global.StrBatchID, lb_IdImage.Text);
                }
                else if (pn_Main.SelectedTabPage == tab_CityN_Loai1)
                {
                    if (uC_CityN_Loai11.IsEmpty())
                    {
                        if (MessageBox.Show("Bạn đang để trống 1 hoặc nhiều trường. Bạn có muốn submit không? \r\nYes = Submit và chuyển qua hình khác<Nhấn Enter>\r\nNo = nhập lại trường trống cho hình này.<nhấn phím N>", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.No)
                            return;
                    }
                    uC_CityN_Loai11.Save_CityN_Loai1(Global.StrBatchID, lb_IdImage.Text);
                }
                else if (pn_Main.SelectedTabPage == tab_CityN_Loai3)
                {
                    if (uC_CityN_Loai31.IsEmpty())
                    {
                        if (MessageBox.Show("Bạn đang để trống 1 hoặc nhiều trường. Bạn có muốn submit không? \r\nYes = Submit và chuyển qua hình khác<Nhấn Enter>\r\nNo = nhập lại trường trống cho hình này.<nhấn phím N>", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.No)
                            return;
                    }
                    if (!uC_CityN_Loai31.CheckSubmit())
                    {
                        MessageBox.Show("Điều kiện nhập sai tại trường 50 và 52. Bạn hãy kiểm tra lại", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    uC_CityN_Loai31.Save_CityN_Loai3(Global.StrBatchID, lb_IdImage.Text);
                }
                uC_CityO_Loai11.ResetData();
                uC_CityO_Loai3_DeSo1.ResetData();
                uC_CityN_Loai11.ResetData();
                uC_CityN_Loai31.ResetData();
            }
            else if (Global.StrRole == "DEJP")
            {
                if (pn_Main.SelectedTabPage == tab_CityO_JP)
                {
                    if (uC_CityO_JP1.IsEmpty())
                    {
                        if (MessageBox.Show("Bạn đang để trống 1 hoặc nhiều trường. Bạn có muốn submit không? \r\nYes = Submit và chuyển qua hình khác<Nhấn Enter>\r\nNo = nhập lại trường trống cho hình này.<nhấn phím N>", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.No)
                            return;
                    }
                    if (uC_CityO_JP1.bSubmit)
                    {
                        MessageBox.Show("Có ký tự không hợp lệ. Vui lòng kiểm tra lại!");
                        return;
                    }
                    uC_CityO_JP1.Save_CityO_JP(Global.StrBatchID, lb_IdImage.Text);
                }
                else if (pn_Main.SelectedTabPage == tab_CityN_LoaiJP)
                {
                    if (uC_CityN_JP1.IsEmpty())
                    {
                        if (MessageBox.Show("Bạn đang để trống 1 hoặc nhiều trường. Bạn có muốn submit không? \r\nYes = Submit và chuyển qua hình khác<Nhấn Enter>\r\nNo = nhập lại trường trống cho hình này.<nhấn phím N>", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.No)
                            return;
                    }
                    if (uC_CityN_JP1.bSubmit)
                    {
                        MessageBox.Show("Có ký tự không hợp lệ. Vui lòng kiểm tra lại!");
                        return;
                    }
                    uC_CityN_JP1.Save_CityN_JP(Global.StrBatchID, lb_IdImage.Text);
                }
                uC_CityO_JP1.ResetData();
                uC_CityN_JP1.ResetData();
            }
            DialogResult = DialogResult.Yes;
        }

        private void frm_Main_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.Enter)
            {
                btn_Submit_Click(null, null);
            }
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.Tab)
            {
                if (pn_Main.SelectedTabPage.Name == "tab_CityO_Loai1")
                    pn_Main.SelectedTabPage.Name = "tab_CityO_Loai2";
                else if (pn_Main.SelectedTabPage.Name == "tab_CityO_Loai2")
                    pn_Main.SelectedTabPage.Name = "tab_CityO_Loai3";
                else if (pn_Main.SelectedTabPage.Name == "tab_CityO_Loai3")
                    pn_Main.SelectedTabPage.Name = "tab_CityO_Loai1";
            }
        }
        
        private void btn_ExportExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           new frm_ExportExcel().ShowDialog();
        }

        private void btn_TienDo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            new FrmTienDo().ShowDialog();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //new FrmFeedback().ShowDialog();
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            new frm_NangSuat().ShowDialog();
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            new frm_User().ShowDialog();
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           new frm_ChangePassword().ShowDialog();
        }

        private void frm_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                Global.DbBpo.UpdateTimeLastRequest(Global.Token);
                Global.DbBpo.UpdateTimeLogout(Global.Token);
                Global.DbBpo.ResetToken(Global.StrUserName, Global.StrIdProject, Global.Token);
            }
            catch { /**/}
            Settings.Default.ApplicationSkinName = UserLookAndFeel.Default.SkinName;
            Settings.Default.Save();
        }

        private void splitMain_SplitterPositionChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(splitMain.SplitterPosition + "");
            Settings.Default.PositionSplitMain = splitMain.SplitterPosition;
            Settings.Default.Save();
        }

        private void btn_Pause_Click(object sender, EventArgs e)
        {
            //    new FrmFreeTime().ShowDialog();
            //    Global.DbBpo.UpdateTimeFree(Global.Token, Global.FreeTime);
        }

        private void lb_IdImage_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(lb_IdImage.Text);
            XtraMessageBox.Show("Copy image name Success!");
        }

        private void lb_fBatchName_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(lb_fBatchName.Text);
            XtraMessageBox.Show("Copy batch name Success!");
        }
        
        private void pn_Main_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (pn_Main.SelectedTabPage == tab_CityO_Loai1)
            {
                uC_CityO_Loai11.txt_Truong_018.Focus();
                splitMain.SplitterPosition = 295;
            }
            else if (pn_Main.SelectedTabPage == tab_CityO_Loai3)
            {
                uC_CityO_Loai3_DeSo1.txt_Truong_015.Focus();
                splitMain.SplitterPosition = 677;
            }
            else if (pn_Main.SelectedTabPage == tab_CityN_Loai1)
            {
                uC_CityN_Loai11.txt_Truong_011.Focus();
                splitMain.SplitterPosition = 305;
            }
            else if (pn_Main.SelectedTabPage == tab_CityN_Loai3)
            {
                uC_CityN_Loai31.txt_Truong_011.Focus();
                splitMain.SplitterPosition = 675;
            }
            else if (pn_Main.SelectedTabPage == tab_CityN_LoaiJP)
            {
                uC_CityN_JP1.txt_Truong_018.Focus();
                splitMain.SplitterPosition = 310;
            }
        }
        
        private void btn_RefreshImageNotInput_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            new Refresh_ImageNotInput().ShowDialog();
        }

        private void btn_Check_DeSo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Global.FlagChangeSave = false;
            Global.StrCheck = "CHECKDESO";
            frm_Checker fCheck = new frm_Checker();
            fCheck.TypeCheck = "CHECK DESO";
            fCheck.ShowDialog();
        }

        private void btn_Check_DeSo_NhamPhieu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Global.FlagChangeSave = false;
            Global.StrCheck = "CHECKDESO";
            frm_Checker fCheck = new frm_Checker();
            fCheck.TypeCheck = "CHECK DESO NHẦM PHIẾU";
            fCheck.ShowDialog();
        }

        private void btn_Check_DeSo_QC_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Global.FlagChangeSave = false;
            Global.StrCheck = "CHECKDESO";
            frm_Checker fCheck = new frm_Checker();
            fCheck.TypeCheck = "CHECK DESO QC";
            fCheck.ShowDialog();
        }

        private void btn_Check_DeJP_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Global.FlagChangeSave = false;
            Global.StrCheck = "CHECKDEJP";
            frm_Checker fCheck = new frm_Checker();
            fCheck.TypeCheck = "CHECK DEJP";
            fCheck.ShowDialog();
        }

        private void ckOutSource_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (FlagLoad == true)
                    return;
                int a = Global.DbBpo.UpdateOutSourceProject(Global.StrIdProject, Convert.ToBoolean(ckOutSource.EditValue+""));
                if (a == 0)
                {
                    MessageBox.Show("Thay đổi thành công");
                }
                else if (a == -1)
                {
                    MessageBox.Show("Thay đổi không thành công");
                }
            }
            catch (Exception i)
            {
                MessageBox.Show("Lỗi: " + i.Message); ;
            }
        }
    }
}