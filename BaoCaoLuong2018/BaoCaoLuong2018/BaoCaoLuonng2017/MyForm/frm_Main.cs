using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraTab;
using System.IO;
using BaoCaoLuong2018.BaoCaoLuonng2017.MyUserControl;
using DevExpress.LookAndFeel;
using BaoCaoLuong2018.BaoCaoLuonng2017.MyLog;
using BaoCaoLuong2018.Properties;
using DevExpress.XtraEditors;

namespace BaoCaoLuong2018.BaoCaoLuonng2017.MyForm
{
    public partial class frm_Main : DevExpress.XtraEditors.XtraForm
    {
        public frm_Main()
        {
            Global.DataNote = (from w in Global.db_BCL.tbl_Notes select new Global.dataNote_ { City = w.City, LoaiPhieu = w.LoaiPhieu, Truong = w.Truong, Note = w.Note }).ToList();
            InitializeComponent();
        }
        LogFile log = new LogFile();
        //CLHandling_Loai1 Class_Loai_1 = new CLHandling_Loai1();

        int ChiaUser = -1;
        int LevelUser = -1;
        private void frm_Main_Load(object sender, EventArgs e)
        {
            Global.FreeTime = 0;
            ChiaUser = -1;
            LevelUser = -1;
            lb_SoPhieuCon.Text = "0";
            lb_SoPhieuNhap.Text = "0";
            lb_TongSoHinh.Text = "0";
            UserLookAndFeel.Default.SkinName = Settings.Default.ApplicationSkinName;
            lb_fBatchName.Text = Global.StrBatch;
            lb_UserName.Text = Global.StrUsername;
            lb_City.Text = Global.StrCity;
            tabcontrol.TabPages.Remove(tp_Loai_2);
            tabcontrol.TabPages.Remove(tp_Loai_4);
            tabcontrol.TabPages.Remove(tp_Loai_42);
            tabcontrol.TabPages.Remove(tp_DEJP);
            menu_QuanLy.Enabled = false;
            var checkDisableUser = (from w in Global.db_BPO.tbl_Users where w.Username == Global.StrUsername select w.IsDelete).FirstOrDefault();
            if (checkDisableUser)
            {
                MessageBox.Show("Tài khoản này đã vô hiệu hóa. Vui lòng liên hệ với Admin");
                DialogResult = DialogResult.Yes;
            }
            lb_TongSoHinh.Text = (from w in Global.db_BCL.tbl_Images where w.fbatchname == Global.StrBatch select w.idimage).Count().ToString();
            setValue();

            if (Global.StrRole == "DESO"|| Global.StrRole == "DEJP")
            {
                var ktBatch = (from w in Global.db_BCL.CheckBatchChiaUser(Global.StrBatch) select w.ChiaUser).FirstOrDefault();
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
                var ktUser = (from w in Global.db_BPO.CheckLevelUser(Global.StrUsername) select w.NotGoodUser).FirstOrDefault();
                if (ktUser == true)
                    LevelUser = 0;
                else if (ktUser == false)
                    LevelUser = 1;
                else
                    LevelUser = -1;
            }
            if (Global.StrRole=="DESO")
            {
                tabcontrol.TabPages.Add(tp_Loai_2);
                tabcontrol.TabPages.Add(tp_Loai_4);
                tabcontrol.TabPages.Add(tp_Loai_42);
                tabcontrol.SelectedTabPage = tp_Loai_4;
                uc_Loai_21.Focus += Uc_Loai_21_Focus;
                uc_Loai_41.Focus += Uc_Loai_41_Focus;
            }
            else if (Global.StrRole == "DEJP")
            {
                tabcontrol.TabPages.Add(tp_DEJP);
                uc_DEJP1.Focus += Uc_Loai_21_Focus;
            }
            else
            {
                btn_Start_Submit.Enabled = false;
                btn_Submit_Logout.Enabled = false;
                menu_QuanLy.Enabled = true;
            }
            try
            {
                Global.TenHinhThu2 = (from w in Global.db_BCL.tbl_Batches where w.fBatchName == Global.StrBatch select w.TeninhThu2).FirstOrDefault().ToString();
                Global.GiaTriTruongSo4 = (from w in Global.db_BCL.tbl_Batches where w.fBatchName == Global.StrBatch select w.GiaTriTruongSo4).FirstOrDefault().ToString();
            }
            catch (Exception i)
            {
                LogFile.WriteLog(Global.StrUsername + ".txt", i.Message);
            }
        }

        private void Uc_Loai_41_Focus(string Truong, string Tag)
        {
            txt_Note.Text = Tag;
        }

        private void Uc_Loai_21_Focus(string Truong, string Tag)
        {
            txt_Note.Text = Tag;
        }

        private void btn_Check_DESO_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Global.StrCheck = "CHECKDESO";
            new frm_Check().ShowDialog();
        }
        private void setValue()
        {
            var a = (from w in Global.db_BCL.GetSoLuongPhieu(Global.StrBatch, Global.StrUsername, LevelUser + "", ChiaUser + "", Global.StrRole.ToUpper()) select new { w.SoPhieuCon, w.SoPhieuNhap }).FirstOrDefault();
            lb_SoPhieuCon.Text = a.SoPhieuCon + "";
            lb_SoPhieuNhap.Text = a.SoPhieuNhap + "";
        }

        //public string GetImage()
        //{
        //    if (Global.StrRole == "DESO")
        //    {
        //        tabcontrol.SelectedTabPage = tp_Loai_4;
        //        string temp = (from w in Global.db_BCL.tbl_MissImage_DESOs
        //                       where w.fBatchName == Global.StrBatch && w.UserName == Global.StrUsername && w.Submit == 0
        //                       select w.IdImage).FirstOrDefault();
        //        if (string.IsNullOrEmpty(temp))
        //        {
        //            try
        //            {
        //                var getFilename =
        //                    (from w in Global.db_BCL.LayHinhMoi_DeSo(Global.StrBatch, Global.StrUsername)
        //                     select w.Column1).FirstOrDefault();
        //                if (string.IsNullOrEmpty(getFilename))
        //                {
        //                    return "NULL";
        //                }lb_IdImage.Text = getFilename;
        //                uc_PictureBox1.imageBox1.Image = null;
        //                if (uc_PictureBox1.LoadImage(Global.Webservice + Global.StrBatch + "/" + getFilename, getFilename,
        //                    Settings.Default.ZoomImage) == "Error")
        //                {
        //                    uc_PictureBox1.imageBox1.Image = Resources.svn_deleted;
        //                    return "Error";
        //                }
        //            }
        //            catch (Exception i)
        //            {
        //                LogFile.WriteLog(Global.StrUsername + ".txt", i.Message);
        //                return "NULL";
        //            }
        //        }
        //        else
        //        {
        //            lb_IdImage.Text = temp;
        //            uc_PictureBox1.imageBox1.Image = null;
        //            if (uc_PictureBox1.LoadImage(Global.Webservice + Global.StrBatch + "/" + temp, temp,
        //                Settings.Default.ZoomImage) == "Error"){
        //                uc_PictureBox1.imageBox1.Image = Resources.svn_deleted;
        //                return "Error";
        //            }
        //        }
        //        uc_Loai_41.txt_Truong_001.Focus();
        //    }
        //    else if (Global.StrRole == "DEJP")
        //    {
        //        string temp = (from w in Global.db_BCL.tbl_MissImage_DEJPs
        //                       where w.fBatchName == Global.StrBatch && w.UserName == Global.StrUsername && w.Submit == 0
        //                       select w.IdImage).FirstOrDefault();
        //        if (string.IsNullOrEmpty(temp))
        //        {
        //            try
        //            {
        //                var getFilename =
        //                    (from w in Global.db_BCL.LayHinhMoi_DEJP(Global.StrBatch, Global.StrUsername)
        //                     select w.Column1).FirstOrDefault();
        //                if (string.IsNullOrEmpty(getFilename))
        //                {
        //                    return "NULL";
        //                }
        //                lb_IdImage.Text = getFilename;
        //                uc_PictureBox1.imageBox1.Image = null;
        //                if (uc_PictureBox1.LoadImage(Global.Webservice + Global.StrBatch + "/" + getFilename, getFilename,
        //                    Settings.Default.ZoomImage) == "Error")
        //                {
        //                    uc_PictureBox1.imageBox1.Image = Resources.svn_deleted;
        //                    return "Error";
        //                }
        //            }
        //            catch (Exception i)
        //            {
        //                LogFile.WriteLog(Global.StrUsername + ".txt", i.Message);
        //                return "NULL";
        //            }
        //        }
        //        else
        //        {
        //            lb_IdImage.Text = temp;
        //            uc_PictureBox1.imageBox1.Image = null;
        //            if (uc_PictureBox1.LoadImage(Global.Webservice + Global.StrBatch + "/" + temp, temp,
        //                Settings.Default.ZoomImage) == "Error")
        //            {
        //                uc_PictureBox1.imageBox1.Image = Resources.svn_deleted;
        //                return "Error";
        //            }
        //        }
        //        tabcontrol.SelectedTabPage = tp_DEJP;
        //        uc_DEJP1.txt_Truong_003.Focus();
        //    }
        //    return "OK";
        //}

        public string GetImage()
        {
            try
            {
                var getFilename =(from w in Global.db_BCL.GetImage_Input(Global.StrBatch, Global.StrUsername,Global.StrRole,LevelUser,ChiaUser)select w.IDImage).FirstOrDefault();
                if (string.IsNullOrEmpty(getFilename))
                {
                    return "NULL";
                }
                lb_IdImage.Text = getFilename;
                uc_PictureBox1.imageBox1.Image = null;
                if (uc_PictureBox1.LoadImage(Global.Webservice + Global.StrBatch + "/" + getFilename, getFilename,
                    Settings.Default.ZoomImage) == "Error")
                {
                    uc_PictureBox1.imageBox1.Image = Resources.svn_deleted;
                    return "Error";
                }
            }
            catch (Exception i)
            {
                LogFile.WriteLog(Global.StrUsername + ".txt", i.Message);
                return "NULL";
            }
            if (Global.StrRole == "DESO")
            {
                tabcontrol.SelectedTabPage = tp_Loai_4;
                uc_Loai_41.txt_Truong_001.Focus();
            }
            else if (Global.StrRole == "DEJP")
            {
                tabcontrol.SelectedTabPage = tp_DEJP;
                uc_DEJP1.txt_Truong_003.Focus();
            }
            return "OK";
        }
        private string GetAutoTruongSo4(string strImageName)
        {
            try
            {
                long giatriso4 = long.Parse(Global.GiaTriTruongSo4);
                long tenhinh = long.Parse(strImageName);
                long tenhinhthu2 = long.Parse(Global.TenHinhThu2);
                return (giatriso4 + (tenhinh - tenhinhthu2) * 10).ToString();
                //return (int.Parse(Global.GiaTriTruongSo4) + (int.Parse(strImageName) - int.Parse(Global.TenHinhThu2)) * 10).ToString();
            }
            catch (Exception i)
            {
                LogFile.WriteLog(Global.StrUsername + ".txt", i.Message);
                return "";
            }
        }
        private void btn_Start_Submit_Click(object sender, EventArgs e)
        {
            try
            {
                Global.db_BPO.UpdateTimeLastRequest(Global.Strtoken);
                //Kiểm tra token
                var token = (from w in Global.db_BPO.tbl_TokenLogins
                             where w.UserName == Global.StrUsername && w.IDProject == Global.StrIdProject
                             select w.Token).FirstOrDefault();

                if (token != Global.Strtoken)
                {
                    //MessageBox.Show("User đã đăng nhập ở PC khác, bạn vui lòng đăng nhập lại!");
                    //DialogResult = DialogResult.Yes;
                }
                if (btn_Start_Submit.Text == "Start")
                {
                    if (string.IsNullOrEmpty(Global.StrBatch))
                    {
                        MessageBox.Show("Vui lòng đăng nhập lại và chọn Batch!");
                        return;
                    }
                    
                    string temp = GetImage();
                    if (temp == "NULL")
                    {
                        MessageBox.Show("Hết Hình!");
                        btn_Logout_ItemClick(null, null);
                    }
                    else if (temp == "Error")
                    {
                        MessageBox.Show("Không thể load hình!");
                        btn_Logout_ItemClick(null, null);
                    }
                    
                    //backgroundWorker1.RunWorkerAsync();
                    uc_Loai_21.ResetData();
                    uc_Loai_41.ResetData();
                    uc_Loai_421.ResetData();
                    btn_Start_Submit.Text = "Submit";
                    btn_Submit_Logout.Visible = true;
                    uc_Loai_21.txt_Truong_004.Text = GetAutoTruongSo4(Path.GetFileNameWithoutExtension(lb_IdImage.Text));//truong soo 4 new 
                    uc_Loai_41.txt_Truong_004.Text = GetAutoTruongSo4(Path.GetFileNameWithoutExtension(lb_IdImage.Text));//truong soo 4 new 
                }
                else
                {
                    if (Global.StrRole == "DESO")
                    {
                        if (tabcontrol.SelectedTabPage.Name == "tp_Loai_2")
                        {
                            if (uc_Loai_21.IsEmpty())
                            {
                                if (MessageBox.Show("Bạn đang để trống 1 hoặc nhiều trường. Bạn có muốn submit không? \r\nYes = Submit và chuyển qua hình khác<Nhấn Enter>\r\nNo = nhập lại trường trống cho hình này.<nhấn phím N>", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning,MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.No)
                                    return;
                            }
                            
                            uc_Loai_21.SaveData_Loai_2(lb_IdImage.Text);
                        }
                        else if (tabcontrol.SelectedTabPage.Name == "tp_Loai_4")
                        {
                            if (uc_Loai_41.IsEmpty())
                            {
                                if (MessageBox.Show("Bạn đang để trống 1 hoặc nhiều trường. Bạn có muốn submit không? \r\nYes = Submit và chuyển qua hình khác<Nhấn Enter>\r\nNo = nhập lại trường trống cho hình này.<nhấn phím N>", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.No)
                                    return;
                            }
                            if (uc_Loai_41.bSubmit)
                            {
                                MessageBox.Show("Trường 8 Có ký tự không hợp lệ. Vui lòng kiểm tra lại!");
                                return;
                            }
                            if (!uc_Loai_41.CheckSubmit())
                            {
                                MessageBox.Show("+ Trường 20 có dữ liệu Mà trường 21 trống thì không cho gửi phiếu\r\n+ Trường 20 giá trị phải nhỏ hơn 21 mới cho gửi phiếu");
                                return;
                            }
                                
                            uc_Loai_41.SaveData_Loai_4(lb_IdImage.Text);
                        }
                        else if (tabcontrol.SelectedTabPage== tp_Loai_42)
                        {
                            if (uc_Loai_421.IsEmpty())
                            {
                                if (MessageBox.Show("Bạn đang để trống 1 hoặc nhiều trường. Bạn có muốn submit không? \r\nYes = Submit và chuyển qua hình khác<Nhấn Enter>\r\nNo = nhập lại trường trống cho hình này.<nhấn phím N>", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.No)
                                    return;
                            }
                            if (uc_Loai_421.bSubmit)
                            {
                                MessageBox.Show("Trường 8 Có ký tự không hợp lệ. Vui lòng kiểm tra lại!");
                                return;
                            }

                            uc_Loai_421.SaveData_Loai_42(lb_IdImage.Text);
                        }
                        uc_Loai_21.ResetData();
                        uc_Loai_41.ResetData();
                        uc_Loai_421.ResetData();
                        
                    }
                    else if (Global.StrRole == "DEJP")
                    {

                        if (uc_DEJP1.IsEmpty())
                        {
                            if (MessageBox.Show("Bạn đang để trống 1 hoặc nhiều trường. Bạn có muốn submit không? \r\nYes = Submit và chuyển qua hình khác<Nhấn Enter>\r\nNo = nhập lại trường trống cho hình này.<nhấn phím N>", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.No)
                                return;
                        }
                        if (uc_DEJP1.bSubmit)
                        {
                            MessageBox.Show("Có ký tự không hợp lệ. Vui lòng kiểm tra lại!");
                            return;
                        }
                        
                        uc_DEJP1.SaveData_DEJP(lb_IdImage.Text);
                        uc_DEJP1.ResetData();
                    }
                    string temp = GetImage();
                    if (temp == "NULL")
                    {
                        MessageBox.Show("Hết Hình!");
                        btn_Logout_ItemClick(null, null);
                    }
                    else if (temp == "Error")
                    {
                        MessageBox.Show("Không thể load hình!");
                        btn_Logout_ItemClick(null, null);
                    }
                    uc_Loai_21.txt_Truong_004.Text = GetAutoTruongSo4(Path.GetFileNameWithoutExtension(lb_IdImage.Text));//truong soo 4 new 
                    uc_Loai_41.txt_Truong_004.Text = GetAutoTruongSo4(Path.GetFileNameWithoutExtension(lb_IdImage.Text));//truong soo 4 new 
                }

                setValue();
            }
            catch (Exception i)
            {
                LogFile.WriteLog(Global.StrUsername + ".txt", i.Message);
                MessageBox.Show("Lỗi khi Submit" + i.Message);
            }
        }

        private void btn_QuanLyBatch_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            new frm_ManagerBatch().ShowDialog();
            frm_Main_Load(sender, e);
        }

        private void btn_Submit_Logout_Click(object sender, EventArgs e)
        {
            try
            {
                if (Global.StrRole == "DESO")
                {
                    if (tabcontrol.SelectedTabPage.Name == "tp_Loai_2")
                    {
                        if (uc_Loai_21.IsEmpty())
                        {
                            if (
                                MessageBox.Show(
                                    "Bạn đang để trống 1 hoặc nhiều trường. Bạn có muốn submit không? \r\nYes = Submit và chuyển qua hình khác<Nhấn Enter>\r\nNo = nhập lại trường trống cho hình này.<nhấn phím N>",
                                    "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) ==
                                System.Windows.Forms.DialogResult.No)
                                return;
                        }
                        uc_Loai_21.SaveData_Loai_2(lb_IdImage.Text);
                    }
                    else if (tabcontrol.SelectedTabPage.Name == "tp_Loai_4")
                    {
                        if (uc_Loai_41.IsEmpty())
                        {
                            if (MessageBox.Show("Bạn đang để trống 1 hoặc nhiều trường. Bạn có muốn submit không? \r\nYes = Submit và chuyển qua hình khác<Nhấn Enter>\r\nNo = nhập lại trường trống cho hình này.<nhấn phím N>","Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) ==DialogResult.No)
                                return;
                        }
                        if (uc_Loai_41.bSubmit)
                        {
                            MessageBox.Show("Trường 8 Có ký tự không hợp lệ. Vui lòng kiểm tra lại!");
                            return;
                        }
                        if (!uc_Loai_41.CheckSubmit())
                        {
                            MessageBox.Show("+ Trường 20 có dữ liệu Mà trường 21 trống thì không cho gửi phiếu\r\n+ Trường 20 giá trị phải nhỏ hơn 21 mới cho gửi phiếu");
                            return;
                        }
                        uc_Loai_41.SaveData_Loai_4(lb_IdImage.Text);
                    }
                    else if (tabcontrol.SelectedTabPage == tp_Loai_42)
                    {
                        if (uc_Loai_421.IsEmpty())
                        {
                            if (MessageBox.Show("Bạn đang để trống 1 hoặc nhiều trường. Bạn có muốn submit không? \r\nYes = Submit và chuyển qua hình khác<Nhấn Enter>\r\nNo = nhập lại trường trống cho hình này.<nhấn phím N>", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.No)
                                return;
                        }
                        if (uc_Loai_421.bSubmit)
                        {
                            MessageBox.Show("Trường 8 Có ký tự không hợp lệ. Vui lòng kiểm tra lại!");
                            return;
                        }

                        uc_Loai_421.SaveData_Loai_42(lb_IdImage.Text);
                    }

                }
                else if (Global.StrRole == "DEJP")
                {
                    if (uc_DEJP1.IsEmpty())
                    {
                        if (MessageBox.Show("Bạn đang để trống 1 hoặc nhiều trường. Bạn có muốn submit không? \r\nYes = Submit và chuyển qua hình khác<Nhấn Enter>\r\nNo = nhập lại trường trống cho hình này.<nhấn phím N>","Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) ==DialogResult.No)
                            return;
                    }
                    if (uc_DEJP1.bSubmit)
                    {
                        MessageBox.Show("Có ký tự không hợp lệ. Vui lòng kiểm tra lại!");
                        return;
                    }
                    uc_DEJP1.SaveData_DEJP(lb_IdImage.Text);


                }
                btn_Logout_ItemClick(null, null);
            }
            catch (Exception i)
            {
                LogFile.WriteLog(Global.StrUsername + ".txt", i.Message);
                MessageBox.Show("Lỗi khi Submit : "+i.Message);
            }
        }

        private void btn_Logout_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult = DialogResult.Yes;
        }

        private void frm_Main_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode==Keys.Enter)
            {
                btn_Start_Submit_Click(null,null);
            }
            if(e.Control && e.KeyCode==Keys.Tab)
            {
                if (tabcontrol.SelectedTabPage == tp_Loai_2)
                    tabcontrol.SelectedTabPage = tp_Loai_4;
                else if (tabcontrol.SelectedTabPage == tp_Loai_4)
                    tabcontrol.SelectedTabPage = tp_Loai_42;
                else if (tabcontrol.SelectedTabPage == tp_Loai_42)
                    tabcontrol.SelectedTabPage = tp_Loai_2;
            }
            if (e.KeyCode==Keys.Escape)
            {
                new frm_FreeTime().ShowDialog();
                Global.db_BPO.UpdateTimeFree(Global.Strtoken, Global.FreeTime);
            }
        }

        private void btn_Check_DEJP_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Global.StrCheck = "CHECKDEJP";
            new frm_Check().ShowDialog();
        }

        private void btn_XuatExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            new frm_ExportExcel().ShowDialog();}

        private void btn_QuanLyUser_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //new frm_User().ShowDialog();
        }

        private void txt_LoaiPhieu_TextChanged(object sender, EventArgs e)
        {
            if (Global.StrRole != "DEJP" && Global.StrRole != "CHECKERDEJP")
            {
                if (txt_LoaiPhieu.Text == "2")
                    tabcontrol.SelectedTabPage = tp_Loai_2;
                if (txt_LoaiPhieu.Text == "4")
                    tabcontrol.SelectedTabPage = tp_Loai_4;
                if (txt_LoaiPhieu.Text == "5")
                    tabcontrol.SelectedTabPage = tp_Loai_42;
            }
        }

        private void btn_Check_NhamPhieu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btn_NangSuat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            new frm_NangSuat().ShowDialog();
        }

        private void btn_Exit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Application.Exit();
        }

        private void btn_Zoom_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            new frm_ChangeZoom().ShowDialog();
        }

        private void tabcontrol_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Tab)
            {
                frm_Main_KeyDown(sender, e);
                frm_Main_KeyDown(sender, e);
                frm_Main_KeyDown(sender, e);
                frm_Main_KeyDown(sender, e);
            }
        }

        private void frm_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Global.db_BPO.UpdateTimeLogout(Global.Strtoken);
            //Global.db_BPO.ResetToken(Global.StrUsername, Global.StrIdProject,Global.Strtoken);
            //Settings.Default.ApplicationSkinName = UserLookAndFeel.Default.SkinName;
            //Settings.Default.Save();

            try
            {
                BaoCaoLuong2018.Global.DbBpo.UpdateTimeLastRequest(BaoCaoLuong2018.Global.Token);
                BaoCaoLuong2018.Global.DbBpo.UpdateTimeLogout(BaoCaoLuong2018.Global.Token);
                BaoCaoLuong2018.Global.DbBpo.ResetToken(BaoCaoLuong2018.Global.StrUserName, BaoCaoLuong2018.Global.StrIdProject, BaoCaoLuong2018.Global.Token);
            }
            catch { /**/}
            Settings.Default.ApplicationSkinName = UserLookAndFeel.Default.SkinName;
            Settings.Default.Save();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //Global.db_BPO.UpdateTimeLastRequest(Global.Strtoken);
        }

        private void btn_Pause_Click(object sender, EventArgs e)
        {
            new frm_FreeTime().ShowDialog();
            Global.db_BPO.UpdateTimeFree(Global.Strtoken, Global.FreeTime);
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            //timer1.Start();
        }

        private void btn_TienDo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            new frm_TienDo().ShowDialog();
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
    }
}
