using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using BaoCaoLuong2018.MyData;

namespace BaoCaoLuong2018.MyForm
{
    public partial class frm_CreateBatch : DevExpress.XtraEditors.XtraForm
    {
        private string[] _lFileNames;
        private bool _multi;
        private int soluonghinh;

        public frm_CreateBatch()
        {
            InitializeComponent();
        }

        private void btn_Browser_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                txt_PathFolder.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void btn_BrowserImage_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_BatchName.Text))
            {
                MessageBox.Show("Vui lòng điền tên batch", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
           
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "All Types Image|*.bmp;*.jpg;*.jpeg;*.png;*.tif;*.tiff";

            dlg.Multiselect = true;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                _lFileNames = dlg.FileNames;
                txt_ImagePath.Text = Path.GetDirectoryName(dlg.FileName);
            }soluonghinh = 0;
            soluonghinh = dlg.FileNames.Length;
            lb_SoLuongHinh.Text = dlg.FileNames.Length + " files ";
        }
        string folderBatch = "";
        private void btn_CreateBatch_Click(object sender, EventArgs e)
        {
            if (backgroundWorker1.IsBusy)
            {
                MessageBox.Show("Quá trình tạo batch đang diễn ra, Bạn hãy chờ quá trình tạo batch kết thúc mới tiếp tục tạo batch mới !");
                return;
            }
            if (txt_LoaiPhieu.Text == "CityN" && string.IsNullOrEmpty(cbb_FileTXT.Text))
            {
                if(MessageBox.Show("Bạn chưa chọn file txt. Bạn muốn tiếp tục ?","Xác nhận",MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2)==DialogResult.No)
                {
                    return;
                }
            }
            lb_SobatchHoanThanh.Text = "";
            txt_DateCreate.Text = DateTime.Now.ToShortDateString() + "-" + DateTime.Now.ToShortTimeString();
            backgroundWorker1.RunWorkerAsync();
            //UpLoadMulti();
        }

        private void txt_BatchName_EditValueChanged(object sender, EventArgs e)
        {
            folderBatch = "";
            if (!string.IsNullOrEmpty(txt_BatchName.Text))
            {
                _multi = false;
                txt_PathFolder.Enabled = false;
                btn_Browser.Enabled = false;
            }
            else
            {
                txt_PathFolder.Enabled = true;
                btn_Browser.Enabled = true;
            }
        }

        private void txt_PathFolder_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txt_PathFolder.Text))
                {
                    _multi = true;
                    folderBatch = Path.GetFileName(Path.GetDirectoryName(txt_PathFolder.Text+@"\"));
                    txt_BatchName.Enabled = false;
                    txt_ImagePath.Enabled = false;
                    btn_BrowserImage.Enabled = false;
                }
                else
                {
                    folderBatch = "";
                    txt_BatchName.Enabled = true;
                    txt_ImagePath.Enabled = true;
                    btn_BrowserImage.Enabled = true;
                }
            }
            catch
            {
                folderBatch = "";
            }
        }
        public string City = "";
        private bool flag_load = false;
        private void frm_CreateBatch_Load(object sender, EventArgs e)
        {
            flag_load = true;
            chk_ChiaUser.Checked = true;
            txt_UserCreate.Text = Global.StrUserName;
            txt_DateCreate.Text = DateTime.Now.ToShortDateString() + "-" + DateTime.Now.ToShortTimeString();

            txt_LoaiPhieu.Items.Clear();
            txt_LoaiPhieu.Items.Add(new { Text = "", Value = "" });
            txt_LoaiPhieu.Items.Add(new { Text = "CityN", Value = "CityN" });
            txt_LoaiPhieu.Items.Add(new { Text = "CityO", Value = "CityO" });
            //txt_LoaiPhieu.Items.Add(new { Text = "CityS", Value = "CityS" });
            txt_LoaiPhieu.DisplayMember = "Text";
            txt_LoaiPhieu.ValueMember = "Value";
            txt_LoaiPhieu.Text = City;
            if (txt_LoaiPhieu.Text == "CityN")
            {
                cbb_FileTXT.DataSource = (from w in Global.Db.tbl_CityN_DataOCRs
                                          where w.FileName != null && w.FileName != ""
                                          group w by new { w.FileName } into g
                                          orderby g.Key.FileName ascending
                                          select g.Key.FileName).ToList();
            }
            flag_load = false;
            txt_BatchName.Focus();
        }

        public static string[] GetFilesFrom(string searchFolder, string[] filters, bool isRecursive)
        {
            List<string> filesFound = new List<string>();
            var searchOption = isRecursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;
            foreach (var filter in filters)
            {
                filesFound.AddRange(Directory.GetFiles(searchFolder, $"*.{filter}", searchOption));
            }
            return filesFound.ToArray();
        }

        string[] separators = { @"\", "/" };
        private void UpLoadSingle()
        {
            progressBar1.Step = 1;
            progressBar1.Value = 1;
            progressBar1.Maximum = _lFileNames.Length;
            progressBar1.Minimum = 0;
            ModifyProgressBarColor.SetState(progressBar1, 1);

            string sBatchID = (txt_BatchName.Text + txt_LoaiPhieu.Text + txt_DateCreate.Text).Replace("/", "").Replace(@"\", "").Replace(@":", "").Replace(@"-", "");
            var batch = (from w in Global.Db.tbl_Batches.Where(w => w.BatchID == sBatchID) select w.BatchID).FirstOrDefault();
            if (!string.IsNullOrEmpty(txt_ImagePath.Text))
            {

                if (string.IsNullOrEmpty(batch))
                {
                    var fBatch = new tbl_Batch
                    {
                        BatchID = sBatchID,
                        City = txt_LoaiPhieu.Text,
                        BatchName = txt_BatchName.Text,
                        UserCreate = txt_UserCreate.Text,
                        DateCreate = DateTime.Now,
                        PathPicture = txt_Location.Text,
                        Location = txt_ImagePath.Text,
                        NumberImage = soluonghinh.ToString(),
                        ChiaUser = chk_ChiaUser.Checked ? true : false,
                        CongKhaiBatch = false,
                        Truong_005 = txt_Truong_005.Text,
                        Truong_006 = txt_Truong_006.Text,
                        Truong_016 = txt_Truong_016.Text,
                        Truong_017 = txt_Truong_017.Text,
                    };
                    Global.Db.tbl_Batches.InsertOnSubmit(fBatch);
                    Global.Db.SubmitChanges();
                }
                else
                {
                    MessageBox.Show("Batch đã tồn tại vui lòng điền tên batch khác!");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn hình ảnh!");
                return;
            }

            string temp = Global.StrPath + "\\" + sBatchID;
            if (!Directory.Exists(temp))
            {
                Directory.CreateDirectory(temp);
            }
            else
            {
                MessageBox.Show("Bị trùng tên batch!");
                return;
            }
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new[] { new DataColumn("ImageID", typeof(string)) });
            for (int i = 0; i < _lFileNames.Count(); i++)
            {
                FileInfo fi = new FileInfo(_lFileNames[i]);
                dt.Rows.Add(fi.Name);
            }
            string ConnectionString = Global.Db.Connection.ConnectionString;
            SqlConnection con = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand("Insert_Image", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@BatchID", sBatchID);
            cmd.Parameters.AddWithValue("@City", txt_LoaiPhieu.Text+"");
            cmd.Parameters.AddWithValue("@FileNameTXT", cbb_FileTXT.Text+"");
            cmd.Parameters.AddWithValue("@ListIdImage", dt);
            cmd.Parameters.AddWithValue("@ChiaUser", chk_ChiaUser.Checked ? 1 : 0);
            con.Open();
            cmd.ExecuteNonQuery();

            for (int i = 0; i < _lFileNames.Count(); i++)
            {
                File.Copy(_lFileNames[i], temp + @"\" + new FileInfo(_lFileNames[i]).Name);
                progressBar1.PerformStep();
                lb_SoImageDaHoanThanh.Text = (i + 1) + @"\" + _lFileNames.Count();
            }
            txt_DateCreate.Text = DateTime.Now.ToShortDateString() + "-" + DateTime.Now.ToShortTimeString();
            MessageBox.Show("Tạo batch mới thành công!");
            txt_BatchName.Text = "";
            txt_ImagePath.Text = "";
            lb_SoLuongHinh.Text = "";

        }
        string sBatchID = "", batch="";
        private void UpLoadMulti()
        {
            btn_Browser.Enabled = false;
            txt_PathFolder.Enabled = false;
            txt_Location.Enabled = false;
            List<string> lStrBath = new List<string>();
            lStrBath.AddRange(Directory.GetDirectories(txt_PathFolder.Text));
            int countBatchExists = 0;
            string listBatchExxists = "";
            for (int i = 0; i < lStrBath.Count; i++)
            {
                sBatchID = (new DirectoryInfo(lStrBath[i]).Name + txt_LoaiPhieu.Text + txt_DateCreate.Text).Replace("/", "").Replace(@"\", "").Replace(@":", "").Replace(@"-", "");
                batch = (from w in Global.Db.tbl_Batches.Where(w => w.BatchID == sBatchID) select w.BatchID).FirstOrDefault();
                if (!string.IsNullOrEmpty(batch))
                {
                    countBatchExists += 1;
                    listBatchExxists += lStrBath[i] + "\r\n";
                }
            }
            if (countBatchExists > 0)
            {
                MessageBox.Show("Batch đã tồn tại :\r\n" + listBatchExxists);
                btn_Browser.Enabled = true;
                txt_PathFolder.Enabled = true;
                txt_Location.Enabled = true;
                return;
            }
            int n = 0;
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new[] { new DataColumn("ImageID", typeof(string)) });
            foreach (string itemBatch in lStrBath)
            {
                dt.Clear();
                string batchName = "";
                int m = 0;
                batchName = (new DirectoryInfo(itemBatch).Name + txt_LoaiPhieu.Text + txt_DateCreate.Text).Replace("/", "").Replace(@"\", "").Replace(@":", "").Replace(@"-", "");

                n += 1;
                lb_SobatchHoanThanh.Text = n + @" :";

                var filters = new String[] { "jpg", "jpeg", "png", "gif", "tif", "bmp" };
                string[] pathImageLocation = GetFilesFrom(itemBatch, filters, false);

                var fBatch = new tbl_Batch
                {
                    BatchID = batchName,
                    City = txt_LoaiPhieu.Text,
                    BatchName = new DirectoryInfo(itemBatch).Name,
                    UserCreate = txt_UserCreate.Text,
                    DateCreate = DateTime.Now,
                    PathPicture = txt_Location.Text,
                    Location = txt_PathFolder.Text,
                    NumberImage = pathImageLocation.Length+"",
                    ChiaUser = chk_ChiaUser.Checked ? true : false,
                    CongKhaiBatch = false,
                    Truong_005 = txt_Truong_005.Text,
                    Truong_006 = txt_Truong_006.Text,
                    Truong_016 = txt_Truong_016.Text,
                    Truong_017 = txt_Truong_017.Text,
                };
                Global.Db.tbl_Batches.InsertOnSubmit(fBatch);
                Global.Db.SubmitChanges();
                
                progressBar1.Step = 1;
                progressBar1.Value = 1;
                progressBar1.Maximum = pathImageLocation.Length;
                progressBar1.Minimum = 0;
                ModifyProgressBarColor.SetState(progressBar1, 1);

                for (int i = 0; i < pathImageLocation.Count(); i++)
                {
                    FileInfo fi = new FileInfo(pathImageLocation[i]);
                    dt.Rows.Add(fi.Name);
                }
                string ConnectionString = Global.Db.Connection.ConnectionString;
                SqlConnection con = new SqlConnection(ConnectionString);
                SqlCommand cmd = new SqlCommand("Insert_Image", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BatchID", batchName);
                cmd.Parameters.AddWithValue("@City", txt_LoaiPhieu.Text + "");
                cmd.Parameters.AddWithValue("@FileNameTXT", cbb_FileTXT.Text + "");
                cmd.Parameters.AddWithValue("@ListIdImage", dt);
                cmd.Parameters.AddWithValue("@ChiaUser", chk_ChiaUser.Checked ? 1 : 0);
                con.Open();
                cmd.ExecuteNonQuery();

                string temp = Global.StrPath + "\\" + batchName;
                if (!Directory.Exists(temp))
                {
                    Directory.CreateDirectory(temp);
                }
                else
                {
                    MessageBox.Show("Bị trùng tên batch!");
                    return;
                }
                for (int i = 0; i < pathImageLocation.Count(); i++)
                {
                    File.Copy(pathImageLocation[i], temp + @"\" + new FileInfo(pathImageLocation[i]).Name);
                    progressBar1.PerformStep();
                    lb_SoImageDaHoanThanh.Text = (i + 1) + @"\" + pathImageLocation.Count();
                    m += 1;
                }
                lb_SoImageDaHoanThanh.Text = m + @"/" + pathImageLocation.Length;
                progressBar1.PerformStep();
            }
            MessageBox.Show(@"Tạo batch mới thành công!");
            txt_BatchName.Text = "";
            txt_ImagePath.Text = "";
            lb_SoLuongHinh.Text = "";
            txt_PathFolder.Text = "";
            txt_LoaiPhieu.SelectedIndex = 0;
            //btn_CreateBatch.Enabled = true;
            btn_Browser.Enabled = true;
            txt_PathFolder.Enabled = true;
            txt_Location.Enabled = true;
        }


        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            if (string.IsNullOrEmpty(txt_LoaiPhieu.Text) && _multi==false)
            {
                MessageBox.Show("Vui lòng chọn loại phiếu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (_multi)
            {
                lb_SobatchHoanThanh.Text = "";
                lb_SoImageDaHoanThanh.Text = "";
                //label1.Visible = true;
                //lb_SobatchHoanThanh.Visible = true;
                //lb_SoImageDaHoanThanh.Visible = true;
                UpLoadMulti();
            }
            else
            {
                lb_SobatchHoanThanh.Text = "1";
                lb_SoImageDaHoanThanh.Text = "";
                //label1.Visible = false;
                //lb_SobatchHoanThanh.Visible = false;
                //lb_SoImageDaHoanThanh.Visible = false;
                UpLoadSingle();
            }
        }
        
        private bool closePending;

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (backgroundWorker1.IsBusy)
            {
                MessageBox.Show("Quá trình tạo batch đang diễn ra, Bạn hãy chờ quá trình tạo batch kết thúc!");
                e.Cancel = true;
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (closePending) Close();
            closePending = false;
        }
        private bool flag = false;

        private void txt_ImagePath_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void cbb_FileTXT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar != 3)
                e.Handled = true;
        }

        private void cbb_FileTXT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete)
                ((ComboBox)sender).Text = "";
        }
        private void txt_LoaiPhieu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (flag_load)
                return;
            if (txt_LoaiPhieu.Text != "CityN")
            {
                txt_Truong_005.Text = "";
                txt_Truong_006.Text = "";
                txt_Truong_016.Text = "";
                txt_Truong_017.Text = "";
                txt_Truong_005.Enabled = false;
                txt_Truong_006.Enabled = false;
                txt_Truong_016.Enabled = false;
                txt_Truong_017.Enabled = false;
                cbb_FileTXT.DataSource = null;
            }
            else
            {
                txt_Truong_005.Enabled = true;
                txt_Truong_006.Enabled = true;
                txt_Truong_016.Enabled = true;
                txt_Truong_017.Enabled = true;
                cbb_FileTXT.Text = "";
                cbb_FileTXT.DataSource = null;
                cbb_FileTXT.DataSource = (from w in Global.Db.tbl_CityN_DataOCRs
                                          where w.FileName != null && w.FileName != ""
                                          group w by new { w.FileName } into g
                                          orderby g.Key.FileName ascending
                                          select g.Key.FileName).ToList();
                cbb_FileTXT.DisplayMember = "FileName";
            }
        }

        private void btn_AddFileTXT_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new[] { new DataColumn("LineDate", typeof(string)) });
            dt.Columns.AddRange(new[] { new DataColumn("STT", typeof(string)) });
            string strFileName = "";
            OpenFileDialog oFile = new OpenFileDialog();
            oFile.RestoreDirectory = true;
            oFile.Filter = "txt files (.txt)|*.txt|All files (.*)|*.*";
            oFile.Title = "Vui lòng chọn file OCR";
            oFile.Multiselect = false;
            if (oFile.ShowDialog() == DialogResult.OK)
            {
                strFileName = oFile.FileName;
            }
            List<string> listLineError = new List<string>();
            string[] lines = File.ReadAllLines(strFileName);
            int n = 0;
            for(int i=0;i<lines.Length;i++)
            {
                dt.Rows.Add(lines[i], ThemKyTuPhiaTruoc((i + 1)+""));
                if (lines[i].Length != 700)
                {
                    listLineError.Add(n.ToString());
                    continue;
                }
            }
            if(listLineError.Count>0)
            {
                dt.Clear();
                string s = "";
                for(int j=0;j<listLineError.Count();j++)
                {
                    s += listLineError[j] + "\r\n";
                }
                MessageBox.Show("File txt bạn chọn có số ký tự trong 1 dòng không đúng. Dòng sau đây lỗi:\r\n" + s);
                return;
            }
            FileInfo fi = new FileInfo(strFileName);
            if ((from w in Global.Db.tbl_CityN_DataOCRs
                 where w.FileName != null && w.FileName != ""
                 group w by new { w.FileName } into g
                 orderby g.Key.FileName ascending
                 select g.Key.FileName).ToList().Contains(fi.Name.Replace(".txt", "").Replace(".TXT", "")))
            {
                MessageBox.Show("File txt này đã tồn tại trong Database. Hãy Kiểm tra lại");
                return;
            }
            string ConnectionString = Global.Db.Connection.ConnectionString;
            SqlConnection con = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand("LoadDataFromOCRFile_New", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FileName", fi.Name.Replace(".txt","").Replace(".TXT",""));
            cmd.Parameters.AddWithValue("@ListData", dt);
            con.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("Tạo file txt thành công.");
            if(txt_LoaiPhieu.Text!="CityN")
            {
                cbb_FileTXT.Text = "";
                cbb_FileTXT.DataSource = null;
            }
            cbb_FileTXT.DataSource = (from w in Global.Db.tbl_CityN_DataOCRs
                                      where w.FileName != null && w.FileName != ""
                                      group w by new { w.FileName } into g
                                      orderby g.Key.FileName ascending
                                      select g.Key.FileName).ToList();
            cbb_FileTXT.DisplayMember = "FileName";
        }

        string getcharacter(int n, string str)
        {
            string kq = "";
            for (int i = 1; i <= n; i++)
            {
                kq = kq.Insert(kq.Length, str);
            }
            return kq;
        }

        public string ThemKyTuPhiaTruoc(string input)
        {
            return input.Insert(0, getcharacter(6 - input.Length, "0"));
        }
        private void btn_DeleteFileTXT_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(cbb_FileTXT.Text))
            {
                if (MessageBox.Show("Bạn chắc chắn muốn xóa file txt :\r\n" + cbb_FileTXT.Text, "Cảnh bảo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    Global.Db.DeleteFileTXT(cbb_FileTXT.Text+"");
                    MessageBox.Show("Đã xóa file txt.");
                    if (txt_LoaiPhieu.Text != "CityN")
                    {
                        cbb_FileTXT.Text = "";
                        cbb_FileTXT.DataSource = null;
                    }
                    cbb_FileTXT.DataSource = (from w in Global.Db.tbl_CityN_DataOCRs
                                              where w.FileName != null && w.FileName != ""
                                              group w by new { w.FileName } into g
                                              orderby g.Key.FileName ascending
                                              select g.Key.FileName).ToList();
                    cbb_FileTXT.DisplayMember = "FileName";
                }
            }
        }
    }
    public static class ModifyProgressBarColor
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr w, IntPtr l);
        public static void SetState(this ProgressBar pBar, int state)
        {
            SendMessage(pBar.Handle, 1040, (IntPtr)state, IntPtr.Zero);
        }
    }
}