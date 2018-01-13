
using DevExpress.XtraEditors;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BaoCaoLuong2018.BaoCaoLuonng2017.MyLog;
using BaoCaoLuong2018.Properties;

namespace BaoCaoLuong2018.BaoCaoLuonng2017.MyForm
{
    public partial class frm_Check : XtraForm
    {
        public frm_Check()
        {
            InitializeComponent();
        }

        private void ResetData()
        {
            if (Global.StrCheck == "CHECKDESO")
            {
                var soloi = ((from w in Global.db_BCL.tbl_DESOs where w.fBatchName == cbb_BatchName.Text && w.Dem == 1 select w.IdImage).Count() / 2).ToString();
                lb_Loi.Text = soloi + " Lỗi";
                uc_Loai_11.ResetData();
                uc_Loai_12.ResetData();

                uc_Loai_21.ResetData();
                uc_Loai_22.ResetData();

                uc_Loai_31.ResetData();
                uc_Loai_32.ResetData();

                uc_Loai_41.ResetData();
                uc_Loai_42.ResetData();
            }
            else if (Global.StrCheck == "CHECKDEJP")
            {
                var soloi = ((from w in Global.db_BCL.tbl_DEJPs where w.fBatchName == cbb_BatchName.Text && w.Dem == 1 select w.IdImage).Count() / 2).ToString();
                lb_Loi.Text = soloi + " Lỗi";
                uc_DEJP1.ResetData();
                uc_DEJP2.ResetData();
            }
            uc_PictureBox1.imageBox1.Image = null;
        }

        private void Compare_TextBox(TextEdit t1, TextEdit t2)
        {
            if (!string.IsNullOrEmpty(t1.Text) || !string.IsNullOrEmpty(t2.Text))
            {
                if (t1.Text != t2.Text)
                {
                    t1.BackColor = Color.PaleVioletRed;
                    t2.BackColor = Color.PaleVioletRed;
                }
                else
                {
                    t1.BackColor = Color.White;
                    t2.BackColor = Color.White;
                }
            }
            else
            {
                t1.BackColor = Color.White;
                t2.BackColor = Color.White;
            }
        }

        private void Compare_LookUpEdit(LookUpEdit t1, LookUpEdit t2)
        {
            if (t1.ItemIndex != t2.ItemIndex)
            {
                t1.BackColor = Color.PaleVioletRed;
                t2.BackColor = Color.PaleVioletRed;
            }
            else
            {
                t1.BackColor = Color.White;
                t2.BackColor = Color.White;
            }
        }

        public void CompareRichTextBox(RichTextBox t1, RichTextBox t2)
        {

            int n = 0;
            string s = t1.Text;
            string s1 = t2.Text;
            if (s.Length > s1.Length)
            {
                n = s1.Length;
                t1.SelectionStart = n;
                t1.SelectionLength = s.Length - s1.Length;
                t1.SelectionColor = Color.Red;
                //t1.SelectionBackColor = Color.Red;
            }
            else
            {
                n = s.Length;
                t2.SelectionStart = n;
                t2.SelectionLength = s1.Length - s.Length;
                t2.SelectionColor = Color.Red;
                //t2.SelectionBackColor = Color.Red;
            }

            for (int i = 0; i < n; i++)
            {
                if (s[i] != s1[i])
                {
                    t1.SelectionStart = i;
                    t1.SelectionLength = 1;
                    t1.SelectionColor = Color.Red;
                    //t1.SelectionBackColor = Color.Red;

                    t2.SelectionStart = i;
                    t2.SelectionLength = 1;
                    t2.SelectionColor = Color.Red;
                    //t2.SelectionBackColor = Color.Red;
                    //loi++;

                }
            }
            //loi += Math.Abs(sosanh);
            //MessageBox.Show("Có tất cả " + loi.ToString() + " loi");  
        }
        private void VisibleButtonSave()
        {
            btn_Luu_DeSo1.Visible = false;
            btn_Luu_DeSo2.Visible = false;
            btn_SuaVaLuu_User1.Visible = false;
            btn_SuaVaLuu_User2.Visible = false;
        }
        public void LoadBatchMoi()
        {
            if (MessageBox.Show(@"You want to do the next batch?", @"Notification", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                Close();
            }
            else
            {
                VisibleButtonSave();
                ResetData();
                cbb_BatchName.Text = "";
                cbb_BatchName.DataSource = null;
                if (Global.StrCheck == "CHECKDESO")
                {
                    cbb_BatchName.DataSource = (from w in Global.db_BCL.GetBatNotFinishChecker(Global.StrUsername, "DESO") select new { w.fbatchname }).ToList();
                    cbb_BatchName.DisplayMember = "BatchName";
                }
                else if (Global.StrCheck == "CHECKDEJP")
                {
                    cbb_BatchName.DataSource = (from w in Global.db_BCL.GetBatNotFinishChecker(Global.StrUsername, "DEJP") select new { w.fbatchname }).ToList();
                    cbb_BatchName.DisplayMember = "BatchName";
                }
                btn_Start_Click(null, null);
            }
        }
        bool FlagLoad = false;
        private void frm_Check_Load(object sender, EventArgs e)
        {
            try
            {
                FlagLoad = true;
                tp_Loai_1_DeSo1.PageVisible = false;
                tp_Loai_2_DeSo1.PageVisible = false;
                tp_Loai_3_DeSo1.PageVisible = false;
                tp_Loai_4_DeSo1.PageVisible = false;
                tp_Loai_4_2_DeSo1.PageVisible = false;
                tp_DEJP1.PageVisible = false; ;

                tp_Loai_1_DeSo2.PageVisible = false;
                tp_Loai_2_DeSo2.PageVisible = false;
                tp_Loai_3_DeSo2.PageVisible = false;
                tp_Loai_4_DeSo2.PageVisible = false;
                tp_Loai_4_2_DeSo2.PageVisible = false;
                tp_DEJP2.PageVisible = false;
                uc_Loai_21.Focus += Uc_Loai_21_Focus;
                uc_Loai_22.Focus += Uc_Loai_21_Focus;
                uc_Loai_41.Focus += Uc_Loai_21_Focus;
                uc_Loai_42.Focus += Uc_Loai_21_Focus;
                uc_DEJP1.Focus += Uc_Loai_21_Focus;
                uc_DEJP2.Focus += Uc_Loai_21_Focus;
                if (Global.StrCheck == "CHECKDESO")
                {
                    cbb_BatchName.DataSource = (from w in Global.db_BCL.GetBatNotFinishChecker(Global.StrUsername,"DESO") select new { w.fbatchname}).ToList();
                    cbb_BatchName.DisplayMember = "fbatchname";
                    cbb_BatchName.Text = Global.StrBatch;
                    var soloi = ((from w in Global.db_BCL.tbl_DESOs where w.fBatchName == cbb_BatchName.Text && w.Dem == 1 select w.IdImage).Count() / 2).ToString();
                    lb_Loi.Text = soloi + " Lỗi";
                    tp_Loai_1_DeSo1.PageVisible = true;
                    tp_Loai_2_DeSo1.PageVisible = true;
                    tp_Loai_3_DeSo1.PageVisible = true;
                    tp_Loai_4_DeSo1.PageVisible = true;
                    tp_Loai_4_2_DeSo1.PageVisible = true;

                    tp_Loai_1_DeSo2.PageVisible = true;
                    tp_Loai_2_DeSo2.PageVisible = true;
                    tp_Loai_3_DeSo2.PageVisible = true;
                    tp_Loai_4_DeSo2.PageVisible = true;
                    tp_Loai_4_2_DeSo2.PageVisible = true;

                    btn_Luu_DeSo1.Visible = false;
                    btn_Luu_DeSo2.Visible = false;
                    btn_SuaVaLuu_User1.Visible = false;
                    btn_SuaVaLuu_User2.Visible = false;

                    uc_Loai_11.Changed += Uc_Loai_11_Changed;
                    uc_Loai_21.Changed += Uc_Loai_21_Changed;
                    uc_Loai_31.Changed += Uc_Loai_31_Changed;
                    uc_Loai_41.Changed += Uc_Loai_41_Changed;
                    uc_Loai_421.Changed += Uc_Loai_421_Changed;

                    uc_Loai_12.Changed += Uc_Loai_12_Changed;
                    uc_Loai_22.Changed += Uc_Loai_22_Changed;
                    uc_Loai_32.Changed += Uc_Loai_32_Changed;
                    uc_Loai_42.Changed += Uc_Loai_42_Changed;
                    uc_Loai_422.Changed += Uc_Loai_422_Changed;
                }
                else if (Global.StrCheck == "CHECKDEJP")
                {
                    tp_DEJP1.PageVisible = true;

                    tp_DEJP2.PageVisible = true;

                    btn_Luu_DeSo1.Visible = false;
                    btn_Luu_DeSo2.Visible = false;
                    btn_SuaVaLuu_User1.Visible = false;
                    btn_SuaVaLuu_User2.Visible = false;
                    cbb_BatchName.DataSource = (from w in Global.db_BCL.GetBatNotFinishChecker(Global.StrUsername, "DEJP") select new { w.fbatchname }).ToList();
                    cbb_BatchName.DisplayMember = "fbatchname";
                    cbb_BatchName.Text = Global.StrBatch;
                    var soloi = ((from w in Global.db_BCL.tbl_DEJPs where w.fBatchName == cbb_BatchName.Text && w.Dem == 1 select w.IdImage).Count() / 2).ToString();
                    lb_Loi.Text = soloi + " Lỗi";
                    
                    uc_DEJP1.Changed += Uc_DEJP1_Changed;
                    uc_DEJP2.Changed += Uc_DEJP2_Changed;
                }
                FlagLoad = true;
                ResetData();
            }
            catch (Exception i)
            {
                LogFile.WriteLog(Global.StrUsername + ".txt", i.Message);
                MessageBox.Show("Lỗi" + i);
            }
        }

        private void Uc_Loai_21_Focus(string Truong, string Tag)
        {
            txt_Note.Text = Tag;
        }

        private void Uc_Loai_422_Changed(object sender, EventArgs e)
        {
            btn_Luu_DeSo2.Visible = false;
            btn_SuaVaLuu_User2.Visible = true;
        }

        private void Uc_Loai_421_Changed(object sender, EventArgs e)
        {
            btn_Luu_DeSo1.Visible = false;
            btn_SuaVaLuu_User1.Visible = true;
        }

        private void Uc_DEJP2_Changed(object sender, EventArgs e)
        {
            btn_Luu_DeSo2.Visible = false;
            btn_SuaVaLuu_User2.Visible = true;
        }

        private void Uc_DEJP1_Changed(object sender, EventArgs e)
        {
            btn_Luu_DeSo1.Visible = false;
            btn_SuaVaLuu_User1.Visible = true;
        }

        private void Uc_Loai_42_Changed(object sender, EventArgs e)
        {
            btn_Luu_DeSo2.Visible = false;
            btn_SuaVaLuu_User2.Visible = true;
        }

        private void Uc_Loai_41_Changed(object sender, EventArgs e)
        {
            btn_Luu_DeSo1.Visible = false;
            btn_SuaVaLuu_User1.Visible = true;
        }

        private void btn_Start_Click(object sender, EventArgs e)
        {
            if (Global.StrCheck == "CHECKDESO")
            {
                var nhap = (from w in Global.db_BCL.tbl_Images where w.fbatchname == cbb_BatchName.Text && w.ReadImageDESo == 2 select w.idimage).Count();
                var sohinh = (from w in Global.db_BCL.tbl_Images where w.fbatchname == cbb_BatchName.Text select w.idimage).Count();
                var check = (from w in Global.db_BCL.tbl_MissImage_DESOs where w.fBatchName == cbb_BatchName.Text && w.Submit == 0 select w.IdImage).Count();
                if (sohinh > nhap)
                {
                    MessageBox.Show("Chưa nhập xong DeSo!");
                    return;
                }
                if (check > 0)
                {
                    var listUser = (from w in Global.db_BCL.tbl_MissImage_DESOs where w.fBatchName == cbb_BatchName.Text && w.Submit == 0 select w.UserName).ToList();
                    string sss = "";
                    foreach (var item in listUser)
                    {
                        sss += item + "\r\n";
                    }

                    if (listUser.Count > 0)
                    {
                        MessageBox.Show("Những user lấy hình về nhưng không nhập: \r\n" + sss);
                        return;
                    }
                }
                string temp = GetImage_DeSo();
                if (temp == "NULL")
                {
                    uc_PictureBox1.imageBox1.Dispose();
                    MessageBox.Show("Hết Hình!");
                    return;
                }
                if (temp == "Error")
                {
                    MessageBox.Show("Lỗi load hình");
                    return;
                }
                Load_DeSo(cbb_BatchName.Text, lb_Image.Text);
                btn_Luu_DeSo1.Visible = true;
                btn_Luu_DeSo2.Visible = true;
                btn_SuaVaLuu_User1.Visible = false;
                btn_SuaVaLuu_User2.Visible = false;
            }
            else if (Global.StrCheck == "CHECKDEJP")
            {
                var nhap = (from w in Global.db_BCL.tbl_Images where w.fbatchname == cbb_BatchName.Text && w.ReadImageDEJP == 2 select w.idimage).Count();
                var sohinh = (from w in Global.db_BCL.tbl_Images where w.fbatchname == cbb_BatchName.Text select w.idimage).Count();
                var check = (from w in Global.db_BCL.tbl_MissImage_DEJPs where w.fBatchName == cbb_BatchName.Text && w.Submit == 0 select w.IdImage).Count();
                if (sohinh > nhap)
                {
                    MessageBox.Show("Chưa nhập xong DeJP!");
                    return;
                }
                if (check > 0)
                {
                    var listUser = (from w in Global.db_BCL.tbl_MissImage_DEJPs
                                    where w.fBatchName == cbb_BatchName.Text && w.Submit == 0
                                    select w.UserName).ToList();
                    string sss = "";
                    foreach (var item in listUser)
                    {
                        sss += item + "\r\n";
                    }

                    if (listUser.Count > 0)
                    {
                        MessageBox.Show("Những user lấy hình về nhưng không nhập: \r\n" + sss);
                        return;
                    }
                }
                string temp = GetImage_DeJP();
                if (temp == "NULL")
                {
                    uc_PictureBox1.imageBox1.Dispose();
                    MessageBox.Show("Hết Hình!");
                    return;
                }
                if (temp == "Error")
                {
                    MessageBox.Show("Lỗi load hình");
                    return;
                }
                Load_DeJP(cbb_BatchName.Text, lb_Image.Text);
                btn_Luu_DeSo1.Visible = true;
                btn_Luu_DeSo2.Visible = true;
                btn_SuaVaLuu_User1.Visible = false;
                btn_SuaVaLuu_User2.Visible = false;
            }
            btn_Start.Visible = false;
        }

        private void Load_DeJP(string strBatch, string idimage)
        {
            var deso = (from w in Global.db_BCL.tbl_DEJPs
                        where w.fBatchName == strBatch && w.IdImage == idimage
                        select new
                        {
                            w.UserName,
                            w.LoaiPhieu,
                            w.Truong_003,
                            w.Truong_056,
                            w.Truong_060,
                            w.Truong_062,
                            w.Truong_064,
                            w.Truong_066,
                            w.Truong_068,
                            w.Truong_070,
                            w.Truong_072,
                            w.Truong_074
                        }).ToList();
            lb_username1.Text = deso[0].UserName;
            lb_username2.Text = deso[1].UserName;

            uc_DEJP1.txt_Truong_003.Text = deso[0].Truong_003;
            uc_DEJP1.txt_Truong_056.Text = deso[0].Truong_056;
            uc_DEJP1.txt_Truong_060.Text = deso[0].Truong_060;
            uc_DEJP1.txt_Truong_062.Text = deso[0].Truong_062;
            uc_DEJP1.txt_Truong_064.Text = deso[0].Truong_064;
            uc_DEJP1.txt_Truong_066.Text = deso[0].Truong_066;
            uc_DEJP1.txt_Truong_068.Text = deso[0].Truong_068;
            uc_DEJP1.txt_Truong_070.Text = deso[0].Truong_070;
            uc_DEJP1.txt_Truong_072.Text = deso[0].Truong_072;
            uc_DEJP1.txt_Truong_074.Text = deso[0].Truong_074;

            uc_DEJP2.txt_Truong_003.Text = deso[1].Truong_003;
            uc_DEJP2.txt_Truong_056.Text = deso[1].Truong_056;
            uc_DEJP2.txt_Truong_060.Text = deso[1].Truong_060;
            uc_DEJP2.txt_Truong_062.Text = deso[1].Truong_062;
            uc_DEJP2.txt_Truong_064.Text = deso[1].Truong_064;
            uc_DEJP2.txt_Truong_066.Text = deso[1].Truong_066;
            uc_DEJP2.txt_Truong_068.Text = deso[1].Truong_068;
            uc_DEJP2.txt_Truong_070.Text = deso[1].Truong_070;
            uc_DEJP2.txt_Truong_072.Text = deso[1].Truong_072;
            uc_DEJP2.txt_Truong_074.Text = deso[1].Truong_074;

            CompareRichTextBox(uc_DEJP1.txt_Truong_003, uc_DEJP2.txt_Truong_003);
            CompareRichTextBox(uc_DEJP1.txt_Truong_056, uc_DEJP2.txt_Truong_056);
            CompareRichTextBox(uc_DEJP1.txt_Truong_060, uc_DEJP2.txt_Truong_060);
            CompareRichTextBox(uc_DEJP1.txt_Truong_062, uc_DEJP2.txt_Truong_062);
            CompareRichTextBox(uc_DEJP1.txt_Truong_064, uc_DEJP2.txt_Truong_064);
            CompareRichTextBox(uc_DEJP1.txt_Truong_066, uc_DEJP2.txt_Truong_066);
            CompareRichTextBox(uc_DEJP1.txt_Truong_068, uc_DEJP2.txt_Truong_068);
            CompareRichTextBox(uc_DEJP1.txt_Truong_070, uc_DEJP2.txt_Truong_070);
            CompareRichTextBox(uc_DEJP1.txt_Truong_072, uc_DEJP2.txt_Truong_072);
            CompareRichTextBox(uc_DEJP1.txt_Truong_074, uc_DEJP2.txt_Truong_074);

            var soloi = ((from w in Global.db_BCL.tbl_DEJPs where w.fBatchName == cbb_BatchName.Text && w.Dem == 1 select w.IdImage).Count() / 2).ToString();
            lb_Loi.Text = soloi + " Lỗi";
        }

        private string GetImage_DeJP()
        {
            var temp = (from w in Global.db_BCL.tbl_MissCheck_DEJPs
                        where w.fBatchName == cbb_BatchName.Text && w.UserName == Global.StrUsername && w.Submit == 0
                        select w.IdImage).FirstOrDefault();
            if (string.IsNullOrEmpty(temp))
            {
                var getFilename =
                    (from w in Global.db_BCL.ImageCheck_DeJP(cbb_BatchName.Text, Global.StrUsername)
                     select w.Column1).FirstOrDefault();
                if (string.IsNullOrEmpty(getFilename))
                {
                    return "NULL";
                }
                lb_Image.Text = getFilename;
                uc_PictureBox1.imageBox1.Image = null;
                if (uc_PictureBox1.LoadImage(Global.Webservice + cbb_BatchName.Text + "/" + getFilename, getFilename,
                            Properties.Settings.Default.ZoomImage) == "Error")
                {
                    uc_PictureBox1.imageBox1.Image = Resources.svn_deleted;
                    return "Error";
                }
            }
            else
            {
                lb_Image.Text = temp;
                uc_PictureBox1.imageBox1.Image = null;
                if (uc_PictureBox1.LoadImage(Global.Webservice + cbb_BatchName.Text + "/" + temp, temp, Settings.Default.ZoomImage) == "Error")
                {
                    uc_PictureBox1.imageBox1.Image = Resources.svn_deleted;
                    return "Error";
                }
            }
            return "ok";
        }

        public static string loaiphieu_user1;
        public static string Loaiphieu_user2;
        public static bool Loaiphieu42_user1;
        public static bool Loaiphieu42_user2;

        private void Load_DeSo(string strBatch, string idimage)
        {
            var deso = (from w in Global.db_BCL.tbl_DESOs
                        where w.fBatchName == strBatch && w.IdImage == idimage
                        select new
                        {
                            w.UserName,
                            w.LoaiPhieu,
                            w.Truong_001,
                            w.Truong_002,
                            w.Truong_003,
                            w.Truong_004,
                            w.Truong_005,
                            w.Truong_006,
                            w.Truong_007,
                            w.Truong_008,
                            w.Truong_009,
                            w.Truong_010,
                            w.Truong_011,
                            w.Truong_012,
                            w.Truong_013,
                            w.Truong_014,
                            w.Truong_015,
                            w.Truong_016,
                            w.Truong_017,
                            w.Truong_018,
                            w.Truong_019,
                            w.Truong_020,
                            w.Truong_021,
                            w.Truong_022,
                            w.Truong_023,
                            w.Truong_024,
                            w.Truong_025,
                            w.Truong_026,
                            w.Truong_027,
                            w.Truong_028,
                            w.Truong_029,
                            w.Truong_030,
                            w.Truong_031,
                            w.Truong_032,
                            w.Truong_033,
                            w.Truong_034,
                            w.Truong_035,
                            w.Truong_036,
                            w.Truong_037,
                            w.Truong_038,
                            w.Truong_039,
                            w.Truong_040,
                            w.Truong_041,
                            w.Truong_042,
                            w.Truong_043,
                            w.Truong_044,
                            w.Truong_044_1,
                            w.Truong_044_2,
                            w.Truong_045,
                            w.Truong_046,
                            w.Truong_047,
                            w.Truong_048,
                            w.Truong_049,
                            w.Truong_050,
                            w.Truong_051,
                            w.Truong_051_1,
                            w.Truong_051_2,
                            w.Truong_051_3,
                            w.Truong_052,
                            w.Truong_053,
                            w.Truong_054,
                            w.Truong_054_1,
                            w.Truong_054_2,
                            w.Truong_054_3,
                            w.Truong_055,
                            w.Truong_056,
                            w.Truong_057,
                            w.Truong_058,
                            w.Truong_059,
                            w.Truong_060,
                            w.Truong_061,
                            w.Truong_062,
                            w.Truong_063,
                            w.Truong_064,
                            w.Truong_065,
                            w.Truong_066,
                            w.Truong_067,
                            w.Truong_068,
                            w.Truong_069,
                            w.Truong_070,
                            w.Truong_071,
                            w.Truong_072,
                            w.Truong_073,
                            w.Truong_074,
                            w.Truong_075,

                            w.LoaiPhieu4_2
                        }).ToList();
            lb_username1.Text = deso[0].UserName;
            lb_username2.Text = deso[1].UserName;

            loaiphieu_user1 = deso[0].LoaiPhieu;
            Loaiphieu_user2 = deso[1].LoaiPhieu;
            Loaiphieu42_user1 = deso[0].LoaiPhieu4_2.Value;
            Loaiphieu42_user2 = deso[1].LoaiPhieu4_2.Value;

            if (deso[0].LoaiPhieu == "Loai2")
            {
                tabcontrol_DeSo1.SelectedTabPage = tp_Loai_2_DeSo1;

                uc_Loai_21.txt_Truong_001.Text = deso[0].Truong_001;
                uc_Loai_21.txt_Truong_002.Text = deso[0].Truong_002;
                uc_Loai_21.txt_Truong_003.Text = deso[0].Truong_003;
                uc_Loai_21.txt_Truong_004.Text = deso[0].Truong_004;
                uc_Loai_21.txt_Truong_005.Text = deso[0].Truong_005;
                uc_Loai_21.txt_Truong_006.Text = deso[0].Truong_006;
                uc_Loai_21.txt_Truong_007.Text = deso[0].Truong_007;
                uc_Loai_21.txt_Truong_008.Text = deso[0].Truong_008;
                uc_Loai_21.txt_Truong_009.Text = deso[0].Truong_009;
                uc_Loai_21.txt_Truong_010.Text = deso[0].Truong_010;
            }
            else if (deso[0].LoaiPhieu == "Loai4" && deso[0].LoaiPhieu4_2 == false)
            {
                tabcontrol_DeSo1.SelectedTabPage = tp_Loai_4_DeSo1;

                tp_DEJP1.PageVisible = false;

                uc_Loai_41.txt_Truong_001.Text = deso[0].Truong_001;
                uc_Loai_41.txt_Truong_002.Text = deso[0].Truong_002;
                uc_Loai_41.txt_Truong_004.Text = deso[0].Truong_004;
                uc_Loai_41.txt_Truong_005.Text = deso[0].Truong_005;
                uc_Loai_41.txt_Truong_006.Text = deso[0].Truong_006;
                uc_Loai_41.txt_Truong_007.Text = deso[0].Truong_007;
                uc_Loai_41.txt_Truong_008.Text = deso[0].Truong_008;
                uc_Loai_41.txt_Truong_009.Text = deso[0].Truong_009;
                uc_Loai_41.txt_Truong_010.Text = deso[0].Truong_010;
                uc_Loai_41.txt_Truong_011.Text = deso[0].Truong_011;
                uc_Loai_41.txt_Truong_012.Text = deso[0].Truong_012;
                uc_Loai_41.txt_Truong_013.Text = deso[0].Truong_013;
                uc_Loai_41.txt_Truong_014.Text = deso[0].Truong_014;
                uc_Loai_41.txt_Truong_015.Text = deso[0].Truong_015;
                uc_Loai_41.txt_Truong_016.Text = deso[0].Truong_016;
                uc_Loai_41.txt_Truong_017.Text = deso[0].Truong_017;
                uc_Loai_41.txt_Truong_018.Text = deso[0].Truong_018;
                uc_Loai_41.txt_Truong_019.Text = deso[0].Truong_019;
                uc_Loai_41.txt_Truong_020.Text = deso[0].Truong_020;
                uc_Loai_41.txt_Truong_021.Text = deso[0].Truong_021;
                uc_Loai_41.txt_Truong_022.Text = deso[0].Truong_022;
                uc_Loai_41.txt_Truong_023.Text = deso[0].Truong_023;
                uc_Loai_41.txt_Truong_024.Text = deso[0].Truong_024;
                uc_Loai_41.txt_Truong_025.Text = deso[0].Truong_025;
                uc_Loai_41.txt_Truong_026.Text = deso[0].Truong_026;
                uc_Loai_41.txt_Truong_027.Text = deso[0].Truong_027;
                uc_Loai_41.txt_Truong_028.Text = deso[0].Truong_028;
                uc_Loai_41.txt_Truong_029.Text = deso[0].Truong_029;
                uc_Loai_41.txt_Truong_030.Text = deso[0].Truong_030;
                uc_Loai_41.txt_Truong_031.Text = deso[0].Truong_031;
                uc_Loai_41.txt_Truong_032.Text = deso[0].Truong_032;
                uc_Loai_41.txt_Truong_033.Text = deso[0].Truong_033;
                uc_Loai_41.txt_Truong_034.Text = deso[0].Truong_034;
                uc_Loai_41.txt_Truong_035.Text = deso[0].Truong_035;
                uc_Loai_41.txt_Truong_036.Text = deso[0].Truong_036;
                uc_Loai_41.txt_Truong_037.Text = deso[0].Truong_037;
                uc_Loai_41.txt_Truong_038.Text = deso[0].Truong_038;
                uc_Loai_41.txt_Truong_039.Text = deso[0].Truong_039;
                //uc_Loai_41.txt_Truong_040_1.Text = deso[0].Truong_040;

                switch (deso[0].Truong_040)
                {
                    case "1":
                        uc_Loai_41.txt_Truong_040_1.Text = "1";
                        break;
                    case "2":
                        uc_Loai_41.txt_Truong_040_2.Text = "1";
                        break;
                    case "3":
                        uc_Loai_41.txt_Truong_040_3.Text = "1";
                        break;
                    case "4":
                        uc_Loai_41.txt_Truong_040_4.Text = "1";
                        break;
                    case "?":
                        uc_Loai_41.txt_Truong_040_1.Text = "?";
                        break;
                    default:
                        break;
                }

                uc_Loai_41.txt_Truong_041.Text = deso[0].Truong_041;
                uc_Loai_41.txt_Truong_042.Text = deso[0].Truong_042;
                uc_Loai_41.txt_Truong_043.Text = deso[0].Truong_043;
                //uc_Loai_41.txt_Truong_044_1.Text = deso[0].Truong_044;
                uc_Loai_41.txt_Truong_044_1.Text = deso[0].Truong_044_1;
                uc_Loai_41.txt_Truong_044_2.Text = deso[0].Truong_044_2;
                uc_Loai_41.txt_Truong_045.Text = deso[0].Truong_045;
                uc_Loai_41.txt_Truong_046.Text = deso[0].Truong_046;
                uc_Loai_41.txt_Truong_047.Text = deso[0].Truong_047;
                uc_Loai_41.txt_Truong_048.Text = deso[0].Truong_048;
                uc_Loai_41.txt_Truong_049.Text = deso[0].Truong_049;
                uc_Loai_41.txt_Truong_050.Text = deso[0].Truong_050;
                //uc_Loai_41.txt_Truong_051_1.Text = deso[0].Truong_051;
                uc_Loai_41.txt_Truong_051_1.Text = deso[0].Truong_051_1;
                uc_Loai_41.txt_Truong_051_2.Text = deso[0].Truong_051_2;
                uc_Loai_41.txt_Truong_051_3.Text = deso[0].Truong_051_3;
                uc_Loai_41.txt_Truong_052.EditValue = deso[0].Truong_052;
                uc_Loai_41.txt_Truong_053.Text = deso[0].Truong_053;
                //uc_Loai_41.txt_Truong_054_1.Text = deso[0].Truong_054;
                uc_Loai_41.txt_Truong_054_1.Text = deso[0].Truong_054_1;
                uc_Loai_41.txt_Truong_054_2.Text = deso[0].Truong_054_2;
                uc_Loai_41.txt_Truong_054_3.Text = deso[0].Truong_054_3;

                uc_Loai_41.txt_Truong_055.EditValue = deso[0].Truong_055;
                uc_Loai_41.txt_Truong_057.Text = deso[0].Truong_057;
                uc_Loai_41.txt_Truong_058.Text = deso[0].Truong_058;
                uc_Loai_41.txt_Truong_059.Text = deso[0].Truong_059;
                uc_Loai_41.txt_Truong_061.Text = deso[0].Truong_061;
                uc_Loai_41.txt_Truong_063.Text = deso[0].Truong_063;
                uc_Loai_41.txt_Truong_065.Text = deso[0].Truong_065;
                uc_Loai_41.txt_Truong_067.Text = deso[0].Truong_067;
                uc_Loai_41.txt_Truong_069.Text = deso[0].Truong_069;
                uc_Loai_41.txt_Truong_071.Text = deso[0].Truong_071;
                uc_Loai_41.txt_Truong_073.Text = deso[0].Truong_073;
                uc_Loai_41.txt_Truong_075.Text = deso[0].Truong_075;
            }
            else if (deso[0].LoaiPhieu == "Loai5" && deso[0].LoaiPhieu4_2 == true)
            {
                tabcontrol_DeSo1.SelectedTabPage = tp_Loai_4_2_DeSo1;

                tp_DEJP1.PageVisible = false;
            }

            if (deso[1].LoaiPhieu == "Loai2")
            {
                tabcontrol_DeSo2.SelectedTabPage = tp_Loai_2_DeSo2;

                uc_Loai_22.txt_Truong_001.Text = deso[1].Truong_001;
                uc_Loai_22.txt_Truong_002.Text = deso[1].Truong_002;
                uc_Loai_22.txt_Truong_003.Text = deso[1].Truong_003;
                uc_Loai_22.txt_Truong_004.Text = deso[1].Truong_004;
                uc_Loai_22.txt_Truong_005.Text = deso[1].Truong_005;
                uc_Loai_22.txt_Truong_006.Text = deso[1].Truong_006;
                uc_Loai_22.txt_Truong_007.Text = deso[1].Truong_007;
                uc_Loai_22.txt_Truong_008.Text = deso[1].Truong_008;
                uc_Loai_22.txt_Truong_009.Text = deso[1].Truong_009;
                uc_Loai_22.txt_Truong_010.Text = deso[1].Truong_010;
            }
            else if (deso[1].LoaiPhieu == "Loai4" && deso[1].LoaiPhieu4_2 == false)
            {
                tabcontrol_DeSo2.SelectedTabPage = tp_Loai_4_DeSo2;

                uc_Loai_42.txt_Truong_001.Text = deso[1].Truong_001;
                uc_Loai_42.txt_Truong_002.Text = deso[1].Truong_002;
                uc_Loai_42.txt_Truong_004.Text = deso[1].Truong_004;
                uc_Loai_42.txt_Truong_005.Text = deso[1].Truong_005;
                uc_Loai_42.txt_Truong_006.Text = deso[1].Truong_006;
                uc_Loai_42.txt_Truong_007.Text = deso[1].Truong_007;
                uc_Loai_42.txt_Truong_008.Text = deso[1].Truong_008;
                uc_Loai_42.txt_Truong_009.Text = deso[1].Truong_009;
                uc_Loai_42.txt_Truong_010.Text = deso[1].Truong_010;
                uc_Loai_42.txt_Truong_011.Text = deso[1].Truong_011;
                uc_Loai_42.txt_Truong_012.Text = deso[1].Truong_012;
                uc_Loai_42.txt_Truong_013.Text = deso[1].Truong_013;
                uc_Loai_42.txt_Truong_014.Text = deso[1].Truong_014;
                uc_Loai_42.txt_Truong_015.Text = deso[1].Truong_015;
                uc_Loai_42.txt_Truong_016.Text = deso[1].Truong_016;
                uc_Loai_42.txt_Truong_017.Text = deso[1].Truong_017;
                uc_Loai_42.txt_Truong_018.Text = deso[1].Truong_018;
                uc_Loai_42.txt_Truong_019.Text = deso[1].Truong_019;
                uc_Loai_42.txt_Truong_020.Text = deso[1].Truong_020;
                uc_Loai_42.txt_Truong_021.Text = deso[1].Truong_021;
                uc_Loai_42.txt_Truong_022.Text = deso[1].Truong_022;
                uc_Loai_42.txt_Truong_023.Text = deso[1].Truong_023;
                uc_Loai_42.txt_Truong_024.Text = deso[1].Truong_024;
                uc_Loai_42.txt_Truong_025.Text = deso[1].Truong_025;
                uc_Loai_42.txt_Truong_026.Text = deso[1].Truong_026;
                uc_Loai_42.txt_Truong_027.Text = deso[1].Truong_027;
                uc_Loai_42.txt_Truong_028.Text = deso[1].Truong_028;
                uc_Loai_42.txt_Truong_029.Text = deso[1].Truong_029;
                uc_Loai_42.txt_Truong_030.Text = deso[1].Truong_030;
                uc_Loai_42.txt_Truong_031.Text = deso[1].Truong_031;
                uc_Loai_42.txt_Truong_032.Text = deso[1].Truong_032;
                uc_Loai_42.txt_Truong_033.Text = deso[1].Truong_033;
                uc_Loai_42.txt_Truong_034.Text = deso[1].Truong_034;
                uc_Loai_42.txt_Truong_035.Text = deso[1].Truong_035;
                uc_Loai_42.txt_Truong_036.Text = deso[1].Truong_036;
                uc_Loai_42.txt_Truong_037.Text = deso[1].Truong_037;
                uc_Loai_42.txt_Truong_038.Text = deso[1].Truong_038;
                uc_Loai_42.txt_Truong_039.Text = deso[1].Truong_039;
                //uc_Loai_42.txt_Truong_040_1.Text = deso[1].Truong_040;
                switch (deso[1].Truong_040)
                {
                    case "1":
                        uc_Loai_42.txt_Truong_040_1.Text = "1";
                        break;
                    case "2":
                        uc_Loai_42.txt_Truong_040_2.Text = "1";
                        break;
                    case "3":
                        uc_Loai_42.txt_Truong_040_3.Text = "1";
                        break;
                    case "4":
                        uc_Loai_42.txt_Truong_040_4.Text = "1";
                        break;
                    case "?":
                        uc_Loai_42.txt_Truong_040_1.Text = "?";
                        break;
                    default:
                        break;
                }
                
                uc_Loai_42.txt_Truong_041.Text = deso[1].Truong_041;
                uc_Loai_42.txt_Truong_042.Text = deso[1].Truong_042;
                uc_Loai_42.txt_Truong_043.Text = deso[1].Truong_043;
                //uc_Loai_42.txt_Truong_044_1.Text = deso[1].Truong_044;
                uc_Loai_42.txt_Truong_044_1.Text = deso[1].Truong_044_1;
                uc_Loai_42.txt_Truong_044_2.Text = deso[1].Truong_044_2;
                uc_Loai_42.txt_Truong_045.Text = deso[1].Truong_045;
                uc_Loai_42.txt_Truong_046.Text = deso[1].Truong_046;
                uc_Loai_42.txt_Truong_047.Text = deso[1].Truong_047;
                uc_Loai_42.txt_Truong_048.Text = deso[1].Truong_048;
                uc_Loai_42.txt_Truong_049.Text = deso[1].Truong_049;
                uc_Loai_42.txt_Truong_050.Text = deso[1].Truong_050;
                //uc_Loai_42.txt_Truong_051_1.Text = deso[1].Truong_051;
                uc_Loai_42.txt_Truong_051_1.Text = deso[1].Truong_051_1;
                uc_Loai_42.txt_Truong_051_2.Text = deso[1].Truong_051_2;
                uc_Loai_42.txt_Truong_051_3.Text = deso[1].Truong_051_3;
                uc_Loai_42.txt_Truong_052.EditValue = deso[1].Truong_052;
                uc_Loai_42.txt_Truong_053.Text = deso[1].Truong_053;
                //uc_Loai_42.txt_Truong_054_1.Text = deso[1].Truong_054;
                uc_Loai_42.txt_Truong_054_1.Text = deso[1].Truong_054_1;
                uc_Loai_42.txt_Truong_054_2.Text = deso[1].Truong_054_2;
                uc_Loai_42.txt_Truong_054_3.Text = deso[1].Truong_054_3;

                uc_Loai_42.txt_Truong_055.EditValue = deso[1].Truong_055;
                uc_Loai_42.txt_Truong_057.Text = deso[1].Truong_057;
                uc_Loai_42.txt_Truong_058.Text = deso[1].Truong_058;
                uc_Loai_42.txt_Truong_059.Text = deso[1].Truong_059;
                uc_Loai_42.txt_Truong_061.Text = deso[1].Truong_061;
                uc_Loai_42.txt_Truong_063.Text = deso[1].Truong_063;
                uc_Loai_42.txt_Truong_065.Text = deso[1].Truong_065;
                uc_Loai_42.txt_Truong_067.Text = deso[1].Truong_067;
                uc_Loai_42.txt_Truong_069.Text = deso[1].Truong_069;
                uc_Loai_42.txt_Truong_071.Text = deso[1].Truong_071;
                uc_Loai_42.txt_Truong_073.Text = deso[1].Truong_073;
                uc_Loai_42.txt_Truong_075.Text = deso[1].Truong_075;
            }
            else if (deso[1].LoaiPhieu == "Loai5" && deso[1].LoaiPhieu4_2 == true)
            {
                tabcontrol_DeSo2.SelectedTabPage = tp_Loai_4_2_DeSo2;

                tp_DEJP2.PageVisible = false;
            }

            //loại 2
            Compare_TextBox(uc_Loai_21.txt_Truong_001, uc_Loai_22.txt_Truong_001);
            Compare_TextBox(uc_Loai_21.txt_Truong_002, uc_Loai_22.txt_Truong_002);
            Compare_TextBox(uc_Loai_21.txt_Truong_003, uc_Loai_22.txt_Truong_003);
            Compare_TextBox(uc_Loai_21.txt_Truong_004, uc_Loai_22.txt_Truong_004);
            Compare_TextBox(uc_Loai_21.txt_Truong_005, uc_Loai_22.txt_Truong_005);
            Compare_TextBox(uc_Loai_21.txt_Truong_006, uc_Loai_22.txt_Truong_006);
            Compare_TextBox(uc_Loai_21.txt_Truong_007, uc_Loai_22.txt_Truong_007);
            Compare_TextBox(uc_Loai_21.txt_Truong_008, uc_Loai_22.txt_Truong_008);
            Compare_TextBox(uc_Loai_21.txt_Truong_009, uc_Loai_22.txt_Truong_009);
            Compare_TextBox(uc_Loai_21.txt_Truong_010, uc_Loai_22.txt_Truong_010);

            //loại 4
            Compare_TextBox(uc_Loai_41.txt_Truong_001, uc_Loai_42.txt_Truong_001);
            Compare_TextBox(uc_Loai_41.txt_Truong_002, uc_Loai_42.txt_Truong_002);
            Compare_TextBox(uc_Loai_41.txt_Truong_004, uc_Loai_42.txt_Truong_004);
            Compare_TextBox(uc_Loai_41.txt_Truong_005, uc_Loai_42.txt_Truong_005);
            Compare_TextBox(uc_Loai_41.txt_Truong_006, uc_Loai_42.txt_Truong_006);
            Compare_TextBox(uc_Loai_41.txt_Truong_007, uc_Loai_42.txt_Truong_007);
            Compare_TextBox(uc_Loai_41.txt_Truong_008, uc_Loai_42.txt_Truong_008);
            Compare_TextBox(uc_Loai_41.txt_Truong_009, uc_Loai_42.txt_Truong_009);
            Compare_TextBox(uc_Loai_41.txt_Truong_010, uc_Loai_42.txt_Truong_010);
            Compare_TextBox(uc_Loai_41.txt_Truong_011, uc_Loai_42.txt_Truong_011);
            Compare_TextBox(uc_Loai_41.txt_Truong_012, uc_Loai_42.txt_Truong_012);
            Compare_TextBox(uc_Loai_41.txt_Truong_013, uc_Loai_42.txt_Truong_013);
            Compare_TextBox(uc_Loai_41.txt_Truong_014, uc_Loai_42.txt_Truong_014);
            Compare_TextBox(uc_Loai_41.txt_Truong_015, uc_Loai_42.txt_Truong_015);
            Compare_TextBox(uc_Loai_41.txt_Truong_016, uc_Loai_42.txt_Truong_016);
            Compare_TextBox(uc_Loai_41.txt_Truong_017, uc_Loai_42.txt_Truong_017);
            Compare_TextBox(uc_Loai_41.txt_Truong_018, uc_Loai_42.txt_Truong_018);
            Compare_TextBox(uc_Loai_41.txt_Truong_019, uc_Loai_42.txt_Truong_019);
            Compare_TextBox(uc_Loai_41.txt_Truong_020, uc_Loai_42.txt_Truong_020);
            Compare_TextBox(uc_Loai_41.txt_Truong_021, uc_Loai_42.txt_Truong_021);
            Compare_TextBox(uc_Loai_41.txt_Truong_022, uc_Loai_42.txt_Truong_022);
            Compare_TextBox(uc_Loai_41.txt_Truong_023, uc_Loai_42.txt_Truong_023);
            Compare_TextBox(uc_Loai_41.txt_Truong_024, uc_Loai_42.txt_Truong_024);
            Compare_TextBox(uc_Loai_41.txt_Truong_025, uc_Loai_42.txt_Truong_025);
            Compare_TextBox(uc_Loai_41.txt_Truong_026, uc_Loai_42.txt_Truong_026);
            Compare_TextBox(uc_Loai_41.txt_Truong_027, uc_Loai_42.txt_Truong_027);
            Compare_TextBox(uc_Loai_41.txt_Truong_028, uc_Loai_42.txt_Truong_028);
            Compare_TextBox(uc_Loai_41.txt_Truong_029, uc_Loai_42.txt_Truong_029);
            Compare_TextBox(uc_Loai_41.txt_Truong_030, uc_Loai_42.txt_Truong_030);
            Compare_TextBox(uc_Loai_41.txt_Truong_031, uc_Loai_42.txt_Truong_031);
            Compare_TextBox(uc_Loai_41.txt_Truong_032, uc_Loai_42.txt_Truong_032);
            Compare_TextBox(uc_Loai_41.txt_Truong_033, uc_Loai_42.txt_Truong_033);
            Compare_TextBox(uc_Loai_41.txt_Truong_034, uc_Loai_42.txt_Truong_034);
            Compare_TextBox(uc_Loai_41.txt_Truong_035, uc_Loai_42.txt_Truong_035);
            Compare_TextBox(uc_Loai_41.txt_Truong_036, uc_Loai_42.txt_Truong_036);
            Compare_TextBox(uc_Loai_41.txt_Truong_037, uc_Loai_42.txt_Truong_037);
            Compare_TextBox(uc_Loai_41.txt_Truong_038, uc_Loai_42.txt_Truong_038);
            Compare_TextBox(uc_Loai_41.txt_Truong_039, uc_Loai_42.txt_Truong_039);
            Compare_TextBox(uc_Loai_41.txt_Truong_040_1, uc_Loai_42.txt_Truong_040_1);
            Compare_TextBox(uc_Loai_41.txt_Truong_040_2, uc_Loai_42.txt_Truong_040_2);
            Compare_TextBox(uc_Loai_41.txt_Truong_040_3, uc_Loai_42.txt_Truong_040_3);
            Compare_TextBox(uc_Loai_41.txt_Truong_040_4, uc_Loai_42.txt_Truong_040_4);
            Compare_TextBox(uc_Loai_41.txt_Truong_041, uc_Loai_42.txt_Truong_041);
            Compare_TextBox(uc_Loai_41.txt_Truong_042, uc_Loai_42.txt_Truong_042);
            Compare_TextBox(uc_Loai_41.txt_Truong_043, uc_Loai_42.txt_Truong_043);
            Compare_TextBox(uc_Loai_41.txt_Truong_044_1, uc_Loai_42.txt_Truong_044_1);
            Compare_TextBox(uc_Loai_41.txt_Truong_044_2, uc_Loai_42.txt_Truong_044_2);
            Compare_TextBox(uc_Loai_41.txt_Truong_045, uc_Loai_42.txt_Truong_045);
            Compare_TextBox(uc_Loai_41.txt_Truong_046, uc_Loai_42.txt_Truong_046);
            Compare_TextBox(uc_Loai_41.txt_Truong_047, uc_Loai_42.txt_Truong_047);
            Compare_TextBox(uc_Loai_41.txt_Truong_048, uc_Loai_42.txt_Truong_048);
            Compare_TextBox(uc_Loai_41.txt_Truong_049, uc_Loai_42.txt_Truong_049);
            Compare_TextBox(uc_Loai_41.txt_Truong_050, uc_Loai_42.txt_Truong_050);
            Compare_TextBox(uc_Loai_41.txt_Truong_051_1, uc_Loai_42.txt_Truong_051_1);
            Compare_TextBox(uc_Loai_41.txt_Truong_051_2, uc_Loai_42.txt_Truong_051_2);
            Compare_TextBox(uc_Loai_41.txt_Truong_051_3, uc_Loai_42.txt_Truong_051_3);
            Compare_LookUpEdit(uc_Loai_41.txt_Truong_052, uc_Loai_42.txt_Truong_052);
            Compare_TextBox(uc_Loai_41.txt_Truong_053, uc_Loai_42.txt_Truong_053);
            Compare_TextBox(uc_Loai_41.txt_Truong_054_1, uc_Loai_42.txt_Truong_054_1);
            Compare_TextBox(uc_Loai_41.txt_Truong_054_2, uc_Loai_42.txt_Truong_054_2);
            Compare_TextBox(uc_Loai_41.txt_Truong_054_3, uc_Loai_42.txt_Truong_054_3);
            Compare_LookUpEdit(uc_Loai_41.txt_Truong_055, uc_Loai_42.txt_Truong_055);
            Compare_TextBox(uc_Loai_41.txt_Truong_057, uc_Loai_42.txt_Truong_057);
            Compare_TextBox(uc_Loai_41.txt_Truong_058, uc_Loai_42.txt_Truong_058);
            Compare_TextBox(uc_Loai_41.txt_Truong_059, uc_Loai_42.txt_Truong_059);
            Compare_TextBox(uc_Loai_41.txt_Truong_061, uc_Loai_42.txt_Truong_061);
            Compare_TextBox(uc_Loai_41.txt_Truong_063, uc_Loai_42.txt_Truong_063);
            Compare_TextBox(uc_Loai_41.txt_Truong_065, uc_Loai_42.txt_Truong_065);
            Compare_TextBox(uc_Loai_41.txt_Truong_067, uc_Loai_42.txt_Truong_067);
            Compare_TextBox(uc_Loai_41.txt_Truong_069, uc_Loai_42.txt_Truong_069);
            Compare_TextBox(uc_Loai_41.txt_Truong_071, uc_Loai_42.txt_Truong_071);
            Compare_TextBox(uc_Loai_41.txt_Truong_073, uc_Loai_42.txt_Truong_073);
            Compare_TextBox(uc_Loai_41.txt_Truong_075, uc_Loai_42.txt_Truong_075);

            var soloi = ((from w in Global.db_BCL.tbl_DESOs where w.fBatchName == cbb_BatchName.Text && w.Dem == 1 select w.IdImage).Count() / 2).ToString();
            lb_Loi.Text = soloi + " Lỗi";
        }

        private string GetImage_DeSo()
        {
            var temp = (from w in Global.db_BCL.tbl_MissCheck_DESOs
                        where w.fBatchName == cbb_BatchName.Text && w.UserName == Global.StrUsername && w.Submit == 0
                        select w.IdImage).FirstOrDefault();
            if (string.IsNullOrEmpty(temp))
            {
                var getFilename =
                    (from w in Global.db_BCL.ImageCheck_DeSo(cbb_BatchName.Text, Global.StrUsername)
                     select w.Column1).FirstOrDefault();
                if (string.IsNullOrEmpty(getFilename))
                {
                    //lấy hình nhầm loại
                    var getFilename_nhamloaiphieu = (from w in Global.db_BCL.GetImageCheckNhapLoaiPhieu(cbb_BatchName.Text, Global.StrUsername) select w.Column1).FirstOrDefault();

                    if (string.IsNullOrEmpty(getFilename_nhamloaiphieu))
                    {
                        return "NULL";
                    }

                    lb_Image.Text = getFilename_nhamloaiphieu;
                    uc_PictureBox1.imageBox1.Image = null;
                    if (uc_PictureBox1.LoadImage(Global.Webservice + cbb_BatchName.Text + "/" + getFilename_nhamloaiphieu, getFilename_nhamloaiphieu,
                                Properties.Settings.Default.ZoomImage) == "Error")
                    {
                        uc_PictureBox1.imageBox1.Image = Resources.svn_deleted;
                        return "Error";
                    }
                }
                else
                {
                    lb_Image.Text = getFilename;
                    uc_PictureBox1.imageBox1.Image = null;
                    if (uc_PictureBox1.LoadImage(Global.Webservice + cbb_BatchName.Text + "/" + getFilename, getFilename,
                                Properties.Settings.Default.ZoomImage) == "Error")
                    {
                        uc_PictureBox1.imageBox1.Image = Resources.svn_deleted;
                        return "Error";
                    }
                }
            }
            else
            {
                lb_Image.Text = temp;
                uc_PictureBox1.imageBox1.Image = null;
                if (uc_PictureBox1.LoadImage(Global.Webservice + cbb_BatchName.Text + "/" + temp, temp, Settings.Default.ZoomImage) == "Error")
                {
                    uc_PictureBox1.imageBox1.Image = Resources.svn_deleted;
                    return "Error";
                }
            }
            return "ok";
        }

        private void Uc_Loai_11_Changed(object sender, EventArgs e)
        {
            btn_Luu_DeSo1.Visible = false;
            btn_SuaVaLuu_User1.Visible = true;
        }

        private void Uc_Loai_21_Changed(object sender, EventArgs e)
        {
            btn_Luu_DeSo1.Visible = false;
            btn_SuaVaLuu_User1.Visible = true;
        }

        private void Uc_Loai_31_Changed(object sender, EventArgs e)
        {
            btn_Luu_DeSo1.Visible = false;
            btn_SuaVaLuu_User1.Visible = true;
        }

        private void Uc_Loai_12_Changed(object sender, EventArgs e)
        {
            btn_Luu_DeSo2.Visible = false;
            btn_SuaVaLuu_User2.Visible = true;
        }

        private void Uc_Loai_22_Changed(object sender, EventArgs e)
        {
            btn_Luu_DeSo2.Visible = false;
            btn_SuaVaLuu_User2.Visible = true;
        }

        private void Uc_Loai_32_Changed(object sender, EventArgs e)
        {
            btn_Luu_DeSo2.Visible = false;
            btn_SuaVaLuu_User2.Visible = true;
        }

        private void btn_Luu_DeSo1_Click(object sender, EventArgs e)
        {
            if (Global.StrCheck == "CHECKDESO")
            {
                if (loaiphieu_user1 == Loaiphieu_user2 && Loaiphieu42_user1 == Loaiphieu42_user2)
                {
                    Global.db_BCL.LuuDESo(lb_Image.Text, cbb_BatchName.Text, lb_username1.Text, lb_username2.Text, Global.StrUsername);
                    ResetData();
                    string temp = GetImage_DeSo();
                    if (temp == "NULL")
                    {
                        uc_PictureBox1.imageBox1.Image = null;
                        MessageBox.Show(@"Batch '" + cbb_BatchName.Text + "' đã hoàn thành");
                        LoadBatchMoi();
                        return;
                    }
                    else if (temp == "Error")
                    {
                        MessageBox.Show("Lỗi load hình");
                        VisibleButtonSave();
                        return;
                    }
                    Load_DeSo(cbb_BatchName.Text, lb_Image.Text);
                    btn_Luu_DeSo1.Visible = true;
                    btn_Luu_DeSo2.Visible = true;
                    btn_SuaVaLuu_User1.Visible = false;
                    btn_SuaVaLuu_User2.Visible = false;
                }
                else
                {
                    string loaiphieu = "";
                    bool loaiphieu42 = false;
                    if (tabcontrol_DeSo1.SelectedTabPage == tp_Loai_1_DeSo1)
                        loaiphieu = "Loai1";
                    if (tabcontrol_DeSo1.SelectedTabPage == tp_Loai_2_DeSo1)
                        loaiphieu = "Loai2";
                    if (tabcontrol_DeSo1.SelectedTabPage == tp_Loai_3_DeSo1)
                        loaiphieu = "Loai3";
                    if (tabcontrol_DeSo1.SelectedTabPage == tp_Loai_4_DeSo1)
                        loaiphieu = "Loai4";
                    if (tabcontrol_DeSo1.SelectedTabPage == tp_Loai_4_2_DeSo1)
                    {
                        loaiphieu = "Loai5";
                        loaiphieu42 = true;
                    }

                    Global.db_BCL.LuuDESo_Nhamloaiphieu(lb_Image.Text, cbb_BatchName.Text, lb_username1.Text, lb_username2.Text, Global.StrUsername, loaiphieu, loaiphieu42);
                    ResetData();
                    string temp = GetImage_DeSo();
                    if (temp == "NULL")
                    {
                        uc_PictureBox1.imageBox1.Image = null;
                        MessageBox.Show(@"Batch '" + cbb_BatchName.Text + "' đã hoàn thành");
                        LoadBatchMoi();
                        return;
                    }
                    else if (temp == "Error")
                    {
                        MessageBox.Show("Lỗi load hình");
                        VisibleButtonSave();
                        return;
                    }
                    Load_DeSo(cbb_BatchName.Text, lb_Image.Text);
                    btn_Luu_DeSo1.Visible = true;
                    btn_Luu_DeSo2.Visible = true;
                    btn_SuaVaLuu_User1.Visible = false;
                    btn_SuaVaLuu_User2.Visible = false;
                }
            }
            else if (Global.StrCheck == "CHECKDEJP")
            {
                Global.db_BCL.LuuDEJP(lb_Image.Text, cbb_BatchName.Text, lb_username1.Text, lb_username2.Text, Global.StrUsername);
                ResetData();
                string temp = GetImage_DeJP();

                if (temp == "NULL")
                {
                    uc_PictureBox1.imageBox1.Image = null;
                    MessageBox.Show(@"Batch '" + cbb_BatchName.Text + "' đã hoàn thành");
                    LoadBatchMoi();
                    return;
                }
                else if (temp == "Error")
                {
                    MessageBox.Show("Lỗi load hình");
                    VisibleButtonSave();
                    return;
                }
                Load_DeJP(cbb_BatchName.Text, lb_Image.Text);
                btn_Luu_DeSo1.Visible = true;
                btn_Luu_DeSo2.Visible = true;
                btn_SuaVaLuu_User1.Visible = false;
                btn_SuaVaLuu_User2.Visible = false;
            }
        }

        private void btn_Luu_DeSo2_Click(object sender, EventArgs e)
        {
            if (Global.StrCheck == "CHECKDESO")
            {
                if (loaiphieu_user1 == Loaiphieu_user2 && Loaiphieu42_user1 == Loaiphieu42_user2)
                {
                    Global.db_BCL.LuuDESo(lb_Image.Text, cbb_BatchName.Text, lb_username2.Text, lb_username1.Text, Global.StrUsername);
                    ResetData();
                    string temp = GetImage_DeSo();
                    if (temp == "NULL")
                    {
                        uc_PictureBox1.imageBox1.Image = null;
                        MessageBox.Show(@"Batch '" + cbb_BatchName.Text + "' đã hoàn thành");
                        LoadBatchMoi();
                        return;
                    }
                    else if (temp == "Error")
                    {
                        MessageBox.Show("Lỗi load hình");
                        VisibleButtonSave();
                        return;
                    }
                    Load_DeSo(cbb_BatchName.Text, lb_Image.Text);
                    btn_Luu_DeSo1.Visible = true;
                    btn_Luu_DeSo2.Visible = true;
                    btn_SuaVaLuu_User1.Visible = false;
                    btn_SuaVaLuu_User2.Visible = false;
                }
                else
                {
                    bool loaiphieu42 = false;
                    string loaiphieu = "";
                    if (tabcontrol_DeSo2.SelectedTabPage == tp_Loai_1_DeSo2)
                        loaiphieu = "Loai1";
                    if (tabcontrol_DeSo2.SelectedTabPage == tp_Loai_2_DeSo2)
                        loaiphieu = "Loai2";
                    if (tabcontrol_DeSo2.SelectedTabPage == tp_Loai_3_DeSo2)
                        loaiphieu = "Loai3";
                    if (tabcontrol_DeSo2.SelectedTabPage == tp_Loai_4_DeSo2)
                        loaiphieu = "Loai4";
                    if (tabcontrol_DeSo2.SelectedTabPage == tp_Loai_4_2_DeSo2)
                    {
                        loaiphieu = "Loai5";
                        loaiphieu42 = true;
                    }

                    Global.db_BCL.LuuDESo_Nhamloaiphieu(lb_Image.Text, cbb_BatchName.Text, lb_username2.Text, lb_username1.Text, Global.StrUsername, loaiphieu, loaiphieu42);
                    ResetData();
                    string temp = GetImage_DeSo();
                    if (temp == "NULL")
                    {
                        uc_PictureBox1.imageBox1.Image = null;
                        MessageBox.Show(@"Batch '" + cbb_BatchName.Text + "' đã hoàn thành");
                        LoadBatchMoi();
                        return;
                    }
                    else if (temp == "Error")
                    {
                        MessageBox.Show("Lỗi load hình");
                        VisibleButtonSave();
                        return;
                    }
                    Load_DeSo(cbb_BatchName.Text, lb_Image.Text);
                    btn_Luu_DeSo1.Visible = true;
                    btn_Luu_DeSo2.Visible = true;
                    btn_SuaVaLuu_User1.Visible = false;
                    btn_SuaVaLuu_User2.Visible = false;
                }
            }
            else if (Global.StrCheck == "CHECKDEJP")
            {
                Global.db_BCL.LuuDEJP(lb_Image.Text, cbb_BatchName.Text, lb_username2.Text, lb_username1.Text, Global.StrUsername);
                ResetData();
                string temp = GetImage_DeJP();

                if (temp == "NULL")
                {
                    uc_PictureBox1.imageBox1.Image = null;
                    MessageBox.Show(@"Batch '" + cbb_BatchName.Text + "' đã hoàn thành");
                    LoadBatchMoi();
                    return;
                }
                else if (temp == "Error")
                {
                    MessageBox.Show("Lỗi load hình");
                    VisibleButtonSave();
                    return;
                }
                Load_DeJP(cbb_BatchName.Text, lb_Image.Text);
                btn_Luu_DeSo1.Visible = true;
                btn_Luu_DeSo2.Visible = true;
                btn_SuaVaLuu_User1.Visible = false;
                btn_SuaVaLuu_User2.Visible = false;
            }
        }

        private void btn_SuaVaLuu_User1_Click(object sender, EventArgs e)
        {
            if (Global.StrCheck == "CHECKDESO")
            {
                if (tabcontrol_DeSo1.SelectedTabPage.Name == "tp_Loai_2_DeSo1")
                    Global.db_BCL.SuaVaLuu_deso_new(lb_username1.Text, lb_username2.Text, lb_Image.Text, cbb_BatchName.Text, Global.StrUsername,
                        uc_Loai_21.txt_Truong_001.Text,
                        uc_Loai_21.txt_Truong_002.Text,
                        uc_Loai_21.txt_Truong_003.Text,
                        uc_Loai_21.txt_Truong_004.Text,
                        uc_Loai_21.txt_Truong_005.Text,
                        uc_Loai_21.txt_Truong_006.Text,
                        uc_Loai_21.txt_Truong_007.Text,
                        uc_Loai_21.txt_Truong_008.Text,
                        uc_Loai_21.txt_Truong_009.Text,
                        uc_Loai_21.txt_Truong_010.Text,
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "Loai2", false);
                else if (tabcontrol_DeSo1.SelectedTabPage == tp_Loai_4_DeSo1)
                {

                    string ValueTruong40 = "";
                    if (uc_Loai_41.txt_Truong_040_1.Text.Length > 0)
                        ValueTruong40 = "1";
                    else if (uc_Loai_41.txt_Truong_040_2.Text.Length > 0)
                        ValueTruong40 = "2";
                    else if (uc_Loai_41.txt_Truong_040_3.Text.Length > 0)
                        ValueTruong40 = "3";
                    else if (uc_Loai_41.txt_Truong_040_4.Text.Length > 0)
                        ValueTruong40 = "4";
                    Global.db_BCL.SuaVaLuu_deso_new(lb_username1.Text, lb_username2.Text, lb_Image.Text, cbb_BatchName.Text,
                        Global.StrUsername,
                        uc_Loai_41.txt_Truong_001.Text,
                        uc_Loai_41.txt_Truong_002.Text,
                        "",
                        uc_Loai_41.txt_Truong_004.Text?.Replace(",", ""),
                        uc_Loai_41.txt_Truong_005.Text?.Replace(",", ""),
                        uc_Loai_41.txt_Truong_006.Text?.Replace(",", ""),
                        uc_Loai_41.txt_Truong_007.Text?.Replace(",", ""),
                        uc_Loai_41.txt_Truong_008.Text,
                        uc_Loai_41.txt_Truong_009.Text,
                        uc_Loai_41.txt_Truong_010.Text,
                        uc_Loai_41.txt_Truong_011.Text?.Replace(",", ""),
                        uc_Loai_41.txt_Truong_012.Text,
                        uc_Loai_41.txt_Truong_013.Text,
                        uc_Loai_41.txt_Truong_014.Text,
                        uc_Loai_41.txt_Truong_015.Text,
                        uc_Loai_41.txt_Truong_016.Text,
                        uc_Loai_41.txt_Truong_017.Text,
                        uc_Loai_41.txt_Truong_018.Text,
                        uc_Loai_41.txt_Truong_019.Text,
                        uc_Loai_41.txt_Truong_020.Text?.Replace(",", ""),
                        uc_Loai_41.txt_Truong_021.Text?.Replace(",", ""),
                        uc_Loai_41.txt_Truong_022.Text?.Replace(",", ""),
                        uc_Loai_41.txt_Truong_023.Text?.Replace(",", ""),
                        uc_Loai_41.txt_Truong_024.Text?.Replace(",", ""),
                        uc_Loai_41.txt_Truong_025.Text,
                        uc_Loai_41.txt_Truong_026.Text,
                        uc_Loai_41.txt_Truong_027.Text,
                        uc_Loai_41.txt_Truong_028.Text,
                        uc_Loai_41.txt_Truong_029.Text,
                        uc_Loai_41.txt_Truong_030.Text,
                        uc_Loai_41.txt_Truong_031.Text,
                        uc_Loai_41.txt_Truong_032.Text,
                        uc_Loai_41.txt_Truong_033.Text,
                        uc_Loai_41.txt_Truong_034.Text,
                        uc_Loai_41.txt_Truong_035.Text,
                        uc_Loai_41.txt_Truong_036.Text,
                        uc_Loai_41.txt_Truong_037.Text,
                        "",
                        "",
                        ValueTruong40,
                        uc_Loai_41.txt_Truong_041.Text,
                        uc_Loai_41.txt_Truong_042.Text,
                        uc_Loai_41.txt_Truong_043.Text,
                        uc_Loai_41.txt_Truong_044_1.Text,
                        uc_Loai_41.txt_Truong_044_2.Text,
                        uc_Loai_41.txt_Truong_045.Text?.Replace(",", ""),
                        uc_Loai_41.txt_Truong_046.Text?.Replace(",", ""),
                        uc_Loai_41.txt_Truong_047.Text?.Replace(",", ""),
                        uc_Loai_41.txt_Truong_048.Text?.Replace(",", ""),
                        uc_Loai_41.txt_Truong_049.Text?.Replace(",", ""),
                        uc_Loai_41.txt_Truong_050.Text?.Replace(",", ""),
                        uc_Loai_41.txt_Truong_051_1.Text.Length == 1 ? "0" + uc_Loai_41.txt_Truong_051_1.Text : uc_Loai_41.txt_Truong_051_1.Text,
                        uc_Loai_41.txt_Truong_051_2.Text.Length == 1 ? "0" + uc_Loai_41.txt_Truong_051_2.Text : uc_Loai_41.txt_Truong_051_2.Text,
                        uc_Loai_41.txt_Truong_051_3.Text.Length == 1 ? "0" + uc_Loai_41.txt_Truong_051_3.Text : uc_Loai_41.txt_Truong_051_3.Text,
                        uc_Loai_41.txt_Truong_052.Text,
                        uc_Loai_41.txt_Truong_053.Text,
                        uc_Loai_41.txt_Truong_054_1.Text,
                        uc_Loai_41.txt_Truong_054_2.Text,
                        uc_Loai_41.txt_Truong_054_3.Text,
                        uc_Loai_41.txt_Truong_055.Text,
                        "",
                        uc_Loai_41.txt_Truong_057.Text,
                        uc_Loai_41.txt_Truong_058.Text?.Replace(",", ""),
                        uc_Loai_41.txt_Truong_059.Text?.Replace(",", ""),
                        "",
                        uc_Loai_41.txt_Truong_061.Text,
                        "",
                        uc_Loai_41.txt_Truong_063.Text,
                        "",
                        uc_Loai_41.txt_Truong_065.Text,
                        "",
                        uc_Loai_41.txt_Truong_067.Text,
                        "",
                        uc_Loai_41.txt_Truong_069.Text,
                        "",
                        uc_Loai_41.txt_Truong_071.Text,
                        "",
                        uc_Loai_41.txt_Truong_073.Text,
                        "",
                        uc_Loai_41.txt_Truong_075.Text,
                         "Loai4", false);
                }
                else if (tabcontrol_DeSo1.SelectedTabPage == tp_Loai_4_2_DeSo1)
                {
                    Global.db_BCL.SuaVaLuu_deso_new(lb_username1.Text, lb_username2.Text, lb_Image.Text, cbb_BatchName.Text,
                        Global.StrUsername,
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "Loai5", true);
                }

                ResetData();
                string temp = GetImage_DeSo();
                if (temp == "NULL")
                {
                    uc_PictureBox1.imageBox1.Image = null;
                    MessageBox.Show(@"Batch '" + cbb_BatchName.Text + "' đã hoàn thành");
                    LoadBatchMoi();
                    return;
                }
                else if (temp == "Error")
                {
                    MessageBox.Show("Lỗi load hình");
                    VisibleButtonSave();
                    return;
                }
                Load_DeSo(cbb_BatchName.Text, lb_Image.Text);
                btn_Luu_DeSo1.Visible = true;
                btn_Luu_DeSo2.Visible = true;
                btn_SuaVaLuu_User1.Visible = false;
                btn_SuaVaLuu_User2.Visible = false;
            }
            else if (Global.StrCheck == "CHECKDEJP")
            {
                if (uc_DEJP1.bSubmit)
                {
                    MessageBox.Show("Có ký tự không hợp lệ. Vui lòng kiểm tra lại!");
                    return;
                }

                Global.db_BCL.SuaVaLuu_DEJP(lb_username1.Text, lb_username2.Text, lb_Image.Text, cbb_BatchName.Text, Global.StrUsername,
                    uc_DEJP1.txt_Truong_003.Text,
                    uc_DEJP1.txt_Truong_056.Text,
                    uc_DEJP1.txt_Truong_060.Text,
                    uc_DEJP1.txt_Truong_062.Text,
                    uc_DEJP1.txt_Truong_064.Text,
                    uc_DEJP1.txt_Truong_066.Text,
                    uc_DEJP1.txt_Truong_068.Text,
                    uc_DEJP1.txt_Truong_070.Text,
                    uc_DEJP1.txt_Truong_072.Text,
                    uc_DEJP1.txt_Truong_074.Text,

                    "Loai4");

                ResetData();
                string temp = GetImage_DeJP();
                if (temp == "NULL")
                {
                    uc_PictureBox1.imageBox1.Image = null;
                    MessageBox.Show(@"Batch '" + cbb_BatchName.Text + "' đã hoàn thành");
                    LoadBatchMoi();
                    return;
                }
                else if (temp == "Error")
                {
                    MessageBox.Show("Lỗi load hình");
                    VisibleButtonSave();
                    return;
                }
                Load_DeJP(cbb_BatchName.Text, lb_Image.Text);
                btn_Luu_DeSo1.Visible = true;
                btn_Luu_DeSo2.Visible = true;
                btn_SuaVaLuu_User1.Visible = false;
                btn_SuaVaLuu_User2.Visible = false;
            }
        }

        private void btn_SuaVaLuu_User2_Click(object sender, EventArgs e)
        {
            if (Global.StrCheck == "CHECKDESO")
            {
                if (tabcontrol_DeSo2.SelectedTabPage.Name == "tp_Loai_2_DeSo2")
                    Global.db_BCL.SuaVaLuu_deso_new(lb_username2.Text, lb_username1.Text, lb_Image.Text, cbb_BatchName.Text, Global.StrUsername,
                        uc_Loai_22.txt_Truong_001.Text,
                        uc_Loai_22.txt_Truong_002.Text,
                        uc_Loai_22.txt_Truong_003.Text,
                        uc_Loai_22.txt_Truong_004.Text,
                        uc_Loai_22.txt_Truong_005.Text,
                        uc_Loai_22.txt_Truong_006.Text,
                        uc_Loai_22.txt_Truong_007.Text,
                        uc_Loai_22.txt_Truong_008.Text,
                        uc_Loai_22.txt_Truong_009.Text,
                        uc_Loai_22.txt_Truong_010.Text,
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "Loai2", false);
                else if (tabcontrol_DeSo2.SelectedTabPage.Name == "tp_Loai_4_DeSo2")
                {
                    Global.db_BCL.SuaVaLuu_deso_new(lb_username2.Text, lb_username1.Text, lb_Image.Text, cbb_BatchName.Text,
                        Global.StrUsername,
                        uc_Loai_42.txt_Truong_001.Text,
                        uc_Loai_42.txt_Truong_002.Text,
                        "",
                        uc_Loai_42.txt_Truong_004.Text?.Replace(",", ""),
                        uc_Loai_42.txt_Truong_005.Text?.Replace(",", ""),
                        uc_Loai_42.txt_Truong_006.Text?.Replace(",", ""),
                        uc_Loai_42.txt_Truong_007.Text?.Replace(",", ""),
                        uc_Loai_42.txt_Truong_008.Text,
                        uc_Loai_42.txt_Truong_009.Text,
                        uc_Loai_42.txt_Truong_010.Text,
                        uc_Loai_42.txt_Truong_011.Text?.Replace(",", ""),
                        uc_Loai_42.txt_Truong_012.Text,
                        uc_Loai_42.txt_Truong_013.Text,
                        uc_Loai_42.txt_Truong_014.Text,
                        uc_Loai_42.txt_Truong_015.Text,
                        uc_Loai_42.txt_Truong_016.Text,
                        uc_Loai_42.txt_Truong_017.Text,
                        uc_Loai_42.txt_Truong_018.Text,
                        uc_Loai_42.txt_Truong_019.Text,
                        uc_Loai_42.txt_Truong_020.Text?.Replace(",", ""),
                        uc_Loai_42.txt_Truong_021.Text?.Replace(",", ""),
                        uc_Loai_42.txt_Truong_022.Text?.Replace(",", ""),
                        uc_Loai_42.txt_Truong_023.Text?.Replace(",", ""),
                        uc_Loai_42.txt_Truong_024.Text?.Replace(",", ""),
                        uc_Loai_42.txt_Truong_025.Text,
                        uc_Loai_42.txt_Truong_026.Text,
                        uc_Loai_42.txt_Truong_027.Text,
                        uc_Loai_42.txt_Truong_028.Text,
                        uc_Loai_42.txt_Truong_029.Text,
                        uc_Loai_42.txt_Truong_030.Text,
                        uc_Loai_42.txt_Truong_031.Text,
                        uc_Loai_42.txt_Truong_032.Text,
                        uc_Loai_42.txt_Truong_033.Text,
                        uc_Loai_42.txt_Truong_034.Text,
                        uc_Loai_42.txt_Truong_035.Text,
                        uc_Loai_42.txt_Truong_036.Text,
                        uc_Loai_42.txt_Truong_037.Text,
                        "",
                        "",
                        uc_Loai_42.txt_Truong_040_1.Text,
                        uc_Loai_42.txt_Truong_041.Text,
                        uc_Loai_42.txt_Truong_042.Text,
                        uc_Loai_42.txt_Truong_043.Text,
                        uc_Loai_42.txt_Truong_044_1.Text,
                        uc_Loai_42.txt_Truong_044_2.Text,
                        uc_Loai_42.txt_Truong_045.Text?.Replace(",", ""),
                        uc_Loai_42.txt_Truong_046.Text?.Replace(",", ""),
                        uc_Loai_42.txt_Truong_047.Text?.Replace(",", ""),
                        uc_Loai_42.txt_Truong_048.Text?.Replace(",", ""),
                        uc_Loai_42.txt_Truong_049.Text?.Replace(",", ""),
                        uc_Loai_42.txt_Truong_050.Text?.Replace(",", ""),
                        //uc_Loai_42.txt_Truong_051_1.Text,
                        uc_Loai_42.txt_Truong_051_1.Text.Length == 1 ? "0" + uc_Loai_42.txt_Truong_051_1.Text : uc_Loai_42.txt_Truong_051_1.Text,
                        uc_Loai_42.txt_Truong_051_2.Text.Length == 1 ? "0" + uc_Loai_42.txt_Truong_051_2.Text : uc_Loai_42.txt_Truong_051_2.Text,
                        uc_Loai_42.txt_Truong_051_3.Text.Length == 1 ? "0" + uc_Loai_42.txt_Truong_051_3.Text : uc_Loai_42.txt_Truong_051_3.Text,
                        uc_Loai_42.txt_Truong_052.Text,
                        uc_Loai_42.txt_Truong_053.Text,
                        uc_Loai_42.txt_Truong_054_1.Text,
                        uc_Loai_42.txt_Truong_054_2.Text,
                        uc_Loai_42.txt_Truong_054_3.Text,
                        uc_Loai_42.txt_Truong_055.Text,
                        "",
                        uc_Loai_42.txt_Truong_057.Text,
                        uc_Loai_42.txt_Truong_058.Text?.Replace(",", ""),
                        uc_Loai_42.txt_Truong_059.Text?.Replace(",", ""),
                        "",
                        uc_Loai_42.txt_Truong_061.Text,
                        "",
                        uc_Loai_42.txt_Truong_063.Text,
                        "",
                        uc_Loai_42.txt_Truong_065.Text,
                        "",
                        uc_Loai_42.txt_Truong_067.Text,
                        "",
                        uc_Loai_42.txt_Truong_069.Text,
                        "",
                        uc_Loai_42.txt_Truong_071.Text,
                        "",
                        uc_Loai_42.txt_Truong_073.Text,
                        "",
                        uc_Loai_42.txt_Truong_075.Text,
                        "Loai4", false);
                }
                else if (tabcontrol_DeSo2.SelectedTabPage == tp_Loai_4_2_DeSo2)
                {
                    Global.db_BCL.SuaVaLuu_deso_new(lb_username2.Text, lb_username1.Text, lb_Image.Text, cbb_BatchName.Text,
                        Global.StrUsername,
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                       "Loai5", true);
                }

                ResetData();
                string temp = GetImage_DeSo();
                if (temp == "NULL")
                {
                    uc_PictureBox1.imageBox1.Image = null;
                    MessageBox.Show(@"Batch '" + cbb_BatchName.Text + "' đã hoàn thành");
                    LoadBatchMoi();
                    return;
                }
                else if (temp == "Error")
                {
                    MessageBox.Show("Lỗi load hình");
                    VisibleButtonSave();
                    return;
                }
                Load_DeSo(cbb_BatchName.Text, lb_Image.Text);
                btn_Luu_DeSo1.Visible = true;
                btn_Luu_DeSo2.Visible = true;
                btn_SuaVaLuu_User1.Visible = false;
                btn_SuaVaLuu_User2.Visible = false;
            }
            else if (Global.StrCheck == "CHECKDEJP")
            {
                if (uc_DEJP2.bSubmit)
                {
                    MessageBox.Show("Có ký tự không hợp lệ. Vui lòng kiểm tra lại!");
                    return;
                }
                Global.db_BCL.SuaVaLuu_DEJP(lb_username2.Text, lb_username1.Text, lb_Image.Text, cbb_BatchName.Text, Global.StrUsername,
                    uc_DEJP2.txt_Truong_003.Text,
                    uc_DEJP2.txt_Truong_056.Text,
                    uc_DEJP2.txt_Truong_060.Text,
                    uc_DEJP2.txt_Truong_062.Text,
                    uc_DEJP2.txt_Truong_064.Text,
                    uc_DEJP2.txt_Truong_066.Text,
                    uc_DEJP2.txt_Truong_068.Text,
                    uc_DEJP2.txt_Truong_070.Text,
                    uc_DEJP2.txt_Truong_072.Text,
                    uc_DEJP2.txt_Truong_074.Text,
                    "Loai4");

                ResetData();
                string temp = GetImage_DeJP();
                if (temp == "NULL")
                {
                    uc_PictureBox1.imageBox1.Image = null;
                    MessageBox.Show(@"Batch '" + cbb_BatchName.Text + "' đã hoàn thành");
                    LoadBatchMoi();
                    return;
                }
                else if (temp == "Error")
                {
                    MessageBox.Show("Lỗi load hình");
                    VisibleButtonSave();
                    return;
                }
                Load_DeJP(cbb_BatchName.Text, lb_Image.Text);
                btn_Luu_DeSo1.Visible = true;
                btn_Luu_DeSo2.Visible = true;
                btn_SuaVaLuu_User1.Visible = false; btn_SuaVaLuu_User2.Visible = false;
            }
        }

        private void uc_Loai_41_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.ScrollOrientation == System.Windows.Forms.ScrollOrientation.HorizontalScroll)
                uc_Loai_41.HorizontalScroll.Value = e.NewValue;
            else if (e.ScrollOrientation == System.Windows.Forms.ScrollOrientation.VerticalScroll)
                this.uc_Loai_42.VerticalScroll.Value = e.NewValue;
        }

        private void uc_Loai_42_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.ScrollOrientation == System.Windows.Forms.ScrollOrientation.HorizontalScroll)
                this.uc_Loai_42.HorizontalScroll.Value = e.NewValue;
            else if (e.ScrollOrientation == System.Windows.Forms.ScrollOrientation.VerticalScroll)
                this.uc_Loai_41.VerticalScroll.Value = e.NewValue;
        }

        private void uc_Loai_421_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.ScrollOrientation == System.Windows.Forms.ScrollOrientation.HorizontalScroll)
                uc_Loai_421.HorizontalScroll.Value = e.NewValue;
            else if (e.ScrollOrientation == System.Windows.Forms.ScrollOrientation.VerticalScroll)
                uc_Loai_422.VerticalScroll.Value = e.NewValue;
        }

        private void uc_Loai_422_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.ScrollOrientation == System.Windows.Forms.ScrollOrientation.HorizontalScroll)
                uc_Loai_422.HorizontalScroll.Value = e.NewValue;
            else if (e.ScrollOrientation == System.Windows.Forms.ScrollOrientation.VerticalScroll)
                uc_Loai_421.VerticalScroll.Value = e.NewValue;
        }


        private void tabcontrol_DeSo2_Click(object sender, EventArgs e)
        {
            if (tabcontrol_DeSo2.SelectedTabPage == tp_Loai_1_DeSo2)
                tabcontrol_DeSo1.SelectedTabPage = tp_Loai_1_DeSo1;
            else if (tabcontrol_DeSo2.SelectedTabPage == tp_Loai_2_DeSo2)
                tabcontrol_DeSo1.SelectedTabPage = tp_Loai_2_DeSo1;
            else if (tabcontrol_DeSo2.SelectedTabPage == tp_Loai_3_DeSo2)
                tabcontrol_DeSo1.SelectedTabPage = tp_Loai_3_DeSo1;
            else if (tabcontrol_DeSo2.SelectedTabPage == tp_Loai_4_DeSo2)
                tabcontrol_DeSo1.SelectedTabPage = tp_Loai_4_DeSo1;
            else if (tabcontrol_DeSo2.SelectedTabPage == tp_Loai_4_2_DeSo2)
                tabcontrol_DeSo1.SelectedTabPage = tp_Loai_4_2_DeSo1;
        }

        private void tabcontrol_DeSo1_Click(object sender, EventArgs e)
        {
            if (tabcontrol_DeSo1.SelectedTabPage == tp_Loai_1_DeSo1)
                tabcontrol_DeSo2.SelectedTabPage = tp_Loai_1_DeSo2;
            else if (tabcontrol_DeSo1.SelectedTabPage == tp_Loai_2_DeSo1)
                tabcontrol_DeSo2.SelectedTabPage = tp_Loai_2_DeSo2;
            else if (tabcontrol_DeSo1.SelectedTabPage == tp_Loai_3_DeSo1)
                tabcontrol_DeSo2.SelectedTabPage = tp_Loai_3_DeSo2;
            else if (tabcontrol_DeSo1.SelectedTabPage == tp_Loai_4_DeSo1)
                tabcontrol_DeSo2.SelectedTabPage = tp_Loai_4_DeSo2;
            else if (tabcontrol_DeSo1.SelectedTabPage == tp_Loai_4_2_DeSo1)
                tabcontrol_DeSo2.SelectedTabPage = tp_Loai_4_2_DeSo2;
        }

        private void uc_DEJP1_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.ScrollOrientation == System.Windows.Forms.ScrollOrientation.HorizontalScroll)
                uc_DEJP1.HorizontalScroll.Value = e.NewValue;
            else if (e.ScrollOrientation == System.Windows.Forms.ScrollOrientation.VerticalScroll)
                uc_DEJP2.VerticalScroll.Value = e.NewValue;
        }

        private void uc_DEJP2_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.ScrollOrientation == System.Windows.Forms.ScrollOrientation.HorizontalScroll)
                uc_DEJP2.HorizontalScroll.Value = e.NewValue;
            else if (e.ScrollOrientation == System.Windows.Forms.ScrollOrientation.VerticalScroll)
                uc_DEJP1.VerticalScroll.Value = e.NewValue;
        }

        private void lb_Image_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(lb_Image.Text);
            XtraMessageBox.Show("Copy image name Success!");
        }

        //private void lb_fBatchName_Click(object sender, EventArgs e)
        //{
        //    Clipboard.SetText(lb_fBatchName.Text);
        //    XtraMessageBox.Show("Copy batch name Success!");
        //}

        private void cbb_BatchName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (FlagLoad)
                return;
            VisibleButtonSave();
            lb_Image.Text = "";
            //Global.StrBatchID = cbb_Batch_Check.SelectedValue+"";
            ResetData();
            btn_Start.Visible = true;
        }

        private void cbb_BatchName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete)
                cbb_BatchName.Text = "";
        }

        private void cbb_BatchName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar != 1 && (int)e.KeyChar != 3)
                e.Handled = true;
        }
    }
}