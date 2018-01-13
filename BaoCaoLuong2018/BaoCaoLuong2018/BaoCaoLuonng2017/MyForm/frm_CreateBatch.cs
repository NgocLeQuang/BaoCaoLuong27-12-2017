using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace BaoCaoLuong2018.BaoCaoLuonng2017.MyForm
{
    public partial class frm_CreateBatch : DevExpress.XtraEditors.XtraForm
    {
        private string _csvpath = "";
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
            }
            soluonghinh = 0;
            soluonghinh = dlg.FileNames.Length;
            lb_SoLuongHinh.Text = dlg.FileNames.Length + " files ";
        }

        private void btn_CreateBatch_Click(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
        }

        private void txt_BatchName_EditValueChanged(object sender, EventArgs e)
        {
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
            if (!string.IsNullOrEmpty(txt_PathFolder.Text))
            {
                _multi = true;
                txt_BatchName.Enabled = false;
                txt_ImagePath.Enabled = false;
                btn_BrowserImage.Enabled = false;
            }
            else
            {
                txt_BatchName.Enabled = true;
                txt_ImagePath.Enabled = true;
                btn_BrowserImage.Enabled = true;
            }
        }

        private void frm_CreateBatch_Load(object sender, EventArgs e)
        {
            chk_ChiaUser.Checked = true;
            txt_UserCreate.Text = Global.StrUsername;
            txt_DateCreate.Text = DateTime.Now.ToShortDateString() + "  -  " + DateTime.Now.ToShortTimeString();
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

        private void UpLoadSingle()
        {
            try
            {
                progressBarControl1.EditValue = 0;
                progressBarControl1.Properties.Step = 1;
                progressBarControl1.Properties.PercentView = true;
                progressBarControl1.Properties.Maximum = _lFileNames.Length;
                progressBarControl1.Properties.Minimum = 0;
                var batch = (from w in Global.db_BCL.tbl_Batches.Where(w => w.fBatchName == txt_BatchName.Text) select w.fBatchName).FirstOrDefault();
                if (!string.IsNullOrEmpty(txt_ImagePath.Text))
                {
                    if (string.IsNullOrEmpty(batch))
                    {
                        var fBatch = new tbl_Batch
                        {
                            fBatchName = txt_BatchName.Text,
                            fusercreate = txt_UserCreate.Text,
                            fdatecreated = DateTime.Now,
                            fPathPicture = txt_ImagePath.Text,
                            fLocation = txt_Location.Text,
                            fSoLuongAnh = soluonghinh.ToString(),
                            ChiaUser = chk_ChiaUser.Checked ? true : false,
                            CongKhaiBatch = false,
                            GiaTriTruongSo4 = txt_TruongSo4.Text,
                            TeninhThu2 = txt_TenHinhThu2.Text
                        };
                        Global.db_BCL.tbl_Batches.InsertOnSubmit(fBatch);
                        Global.db_BCL.SubmitChanges();
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
                string temp = Global.StrPath + "\\" + txt_BatchName.Text;
                if (!Directory.Exists(temp))
                {
                    Directory.CreateDirectory(temp);
                }
                else
                {
                    MessageBox.Show("Bị trùng tên batch!");
                    return;
                }
                foreach (string i in _lFileNames)
                {
                    FileInfo fi = new FileInfo(i);
                    tbl_Image tempImage = new tbl_Image
                    {
                        fbatchname = txt_BatchName.Text,
                        idimage = Path.GetFileName(fi.ToString()),
                        ReadImageDESo = 0,
                        ReadImageDEJP = 0,
                        CheckedDESo = 0,
                        CheckedDEJP = 0,
                        FlagReadDeSo_Good = chk_ChiaUser.Checked ? 0 : 1,
                        FlagReadDeSo_NotGood = chk_ChiaUser.Checked ? 0 : 1,
                        TienDoDESO = "Hình chưa nhập",
                        TienDoDEJP = "Hình chưa nhập"
                    };
                    Global.db_BCL.tbl_Images.InsertOnSubmit(tempImage);
                    Global.db_BCL.SubmitChanges();
                    string des = temp + @"\" + Path.GetFileName(fi.ToString());
                    fi.CopyTo(des);
                    progressBarControl1.PerformStep();
                    progressBarControl1.Update();
                }
                MessageBox.Show("Tạo batch mới thành công!");
                progressBarControl1.EditValue = 0;
                txt_BatchName.Text = "";
                txt_ImagePath.Text = "";
                lb_SoLuongHinh.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: \r\n" + ex.Message);
            }
            finally
            {
                chk_ChiaUser.Enabled = true;
            }
        }

        private void UpLoadMulti()
        {
            try
            {
                List<string> lStrBath = new List<string>();
                lStrBath.AddRange(Directory.GetDirectories(txt_PathFolder.Text));
                progressBarControl1.EditValue = 0;
                progressBarControl1.Properties.Step = 1;
                progressBarControl1.Properties.PercentView = true;
                progressBarControl1.Properties.Maximum = lStrBath.Count;
                progressBarControl1.Properties.Minimum = 0;
                foreach (string item in lStrBath)
                {
                    var fBatch = new tbl_Batch
                    {
                        fBatchName = new DirectoryInfo(item).Name,
                        fusercreate = txt_UserCreate.Text,
                        fdatecreated = DateTime.Now,
                        fPathPicture = item,
                        fLocation = txt_Location.Text,
                        fSoLuongAnh = Directory.GetFiles(item).Length.ToString(),
                        ChiaUser = chk_ChiaUser.Checked ? true : false,
                        CongKhaiBatch = false
                    };
                    Global.db_BCL.tbl_Batches.InsertOnSubmit(fBatch);
                    Global.db_BCL.SubmitChanges();

                    string searchFolder = txt_PathFolder.Text + "\\" + new DirectoryInfo(item).Name;
                    var filters = new String[] { "jpg", "jpeg", "png", "gif", "tiff", "bmp" };
                    string[] tmp = GetFilesFrom(searchFolder, filters, false);
                    string temp = Global.StrPath + "\\" + new DirectoryInfo(item).Name;
                    Directory.CreateDirectory(temp);
                    string imageJPG = "";
                    foreach (string i in tmp)
                    {
                        FileInfo fi = new FileInfo(i);
                        tbl_Image tempImage = new tbl_Image
                        {
                            fbatchname = new DirectoryInfo(item).Name,
                            idimage = Path.GetFileName(fi.ToString()),
                            ReadImageDESo = 0,
                            ReadImageDEJP = 0,
                            CheckedDESo = 0,
                            CheckedDEJP = 0,
                            FlagReadDeSo_Good = chk_ChiaUser.Checked ? 0 : 1,
                            FlagReadDeSo_NotGood = chk_ChiaUser.Checked ? 0 : 1,
                            TienDoDESO = "Hình chưa nhập",
                            TienDoDEJP = "Hình chưa nhập"
                        };
                        Global.db_BCL.tbl_Images.InsertOnSubmit(tempImage);
                        Global.db_BCL.SubmitChanges();
                        string des = temp + @"\" + Path.GetFileName(fi.ToString());
                        fi.CopyTo(des);
                        progressBarControl1.PerformStep();
                        progressBarControl1.Update();
                    }
                    progressBarControl1.PerformStep();
                    progressBarControl1.Update();
                }
                MessageBox.Show("Tạo batch mới thành công!");
                progressBarControl1.EditValue = 0;
                txt_BatchName.Text = "";
                txt_ImagePath.Text = "";
                lb_SoLuongHinh.Text = "";
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi: \r\n" + ex.Message);
            }
            finally
            {
                chk_ChiaUser.Enabled = true;
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            chk_ChiaUser.Enabled = false;
            if (_multi)
            {
                UpLoadMulti();
            }
            else
            {
                UpLoadSingle();
            }
        }

        private void frm_CreateBatch_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        private bool closePending;

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (backgroundWorker1.IsBusy)
            {
                closePending = true;
                backgroundWorker1.CancelAsync();
                e.Cancel = true;
                this.Enabled = false;   // or this.Hide()
                return;
            }
            base.OnFormClosing(e);
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (closePending) this.Close();
            closePending = false;
        }
    }
}