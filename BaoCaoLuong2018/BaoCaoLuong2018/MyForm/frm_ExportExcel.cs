using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace BaoCaoLuong2018.MyForm
{
    public partial class frm_ExportExcel : DevExpress.XtraEditors.XtraForm
    {
        public frm_ExportExcel()
        {
            InitializeComponent();
        }
        Microsoft.Office.Interop.Excel.Application App = null;
        Microsoft.Office.Interop.Excel.Workbook book = null;
        Microsoft.Office.Interop.Excel.Worksheet wrksheet = null;
        int h = 2;
        string namefileExcel = "";

        public struct MyEntry
        {
            public string BatchID { get; set; }
            public string BatchName { get; set; }
        }
        bool FlagLoad = false;
        private void frm_ExportExcel_Load(object sender, EventArgs e)
        {
            FlagLoad = true;
            cbb_City.Items.Clear();
            cbb_City.Items.Add(new { Text = "", Value = "" });
            cbb_City.Items.Add(new { Text = "CityN", Value = "CityN" });
            cbb_City.Items.Add(new { Text = "CityO", Value = "CityO" });
            //cbb_City.Items.Add(new { Text = "CityS", Value = "CityS" });
            cbb_City.DisplayMember = "Text";
            cbb_City.ValueMember = "Value";
            cbb_City.Text = Global.StrCity;
            chk_Multiple.Checked = false;
            dgv.PageVisible = true;
            Batch.PageVisible = false;
            list_Batch.DataSource= (from w in Global.Db.GetBatch(cbb_City.Text) select new MyEntry { BatchID=w.BatchID, BatchName = w.BatchName }).ToList();
            list_Batch.DisplayMember = "BatchName";
            list_Batch.ValueMember = "BatchID";
            cbb_Batch.DataSource = (from w in Global.Db.GetBatch(cbb_City.Text) select new { w.BatchID,w.BatchName }).ToList();
            cbb_Batch.DisplayMember = "BatchName";
            cbb_Batch.ValueMember = "BatchID";
            cbb_Batch.SelectedValue = Global.StrBatchID;
            FlagLoad = false;
        }

        int n = 1;
        private void WriteExcel(int iRow, string image, string no, string field, string content)
        {
            wrksheet.Cells[iRow, 1] = image;
            wrksheet.Cells[iRow, 2] = no;
            wrksheet.Cells[iRow, 3] = field;
            wrksheet.Cells[iRow, 4] = content;
        }

        public void KiemTraQuaKyTuKhongDauChamHoi(int IndexGridColumn, int IndexGridRow, int Field, string FieldName, int Lenght)
        {
            if ((dataGridView1[IndexGridColumn, IndexGridRow].Value + "").Length > Lenght)
            {
                n += 1;
                WriteExcel(n, dataGridView1[11, IndexGridRow].Value + "-" + dataGridView1[12, IndexGridRow].Value + "-" + dataGridView1[13, IndexGridRow].Value + "", Field + "", FieldName, "桁オーバーの為入る所まで入力");
            }
        }
        public void KiemTraQuaKyTu(int IndexGridColumn, int IndexGridRow, int Field, string FieldName, int Lenght)
        {
            if ((dataGridView1[IndexGridColumn, IndexGridRow].Value + "").Length > Lenght)
            {
                n += 1;
                WriteExcel(n, dataGridView1[11, IndexGridRow].Value + "-" + dataGridView1[12, IndexGridRow].Value + "-" + dataGridView1[13, IndexGridRow].Value + "", Field + "", FieldName, "桁オーバーの為入る所まで入力");
            }
            if ((dataGridView1[IndexGridColumn, IndexGridRow].Value + "").IndexOf("?") >= 0)
            {
                n += 1;
                WriteExcel(n, dataGridView1[11, IndexGridRow].Value + "-" + dataGridView1[12, IndexGridRow].Value + "-" + dataGridView1[13, IndexGridRow].Value + "", Field + "", FieldName, "不明の為入力せず");
            }
        }

        public void KiemTraTruongTienAm(string Value, int IndexGridRow, int Field, string FieldName)
        {
            if ((Value == "" ? "" : Value[0] + "") == "-")
            {
                n += 1;
                WriteExcel(n, dataGridView1[11, IndexGridRow].Value + "-" + dataGridView1[12, IndexGridRow].Value + "-" + dataGridView1[13, IndexGridRow].Value + "", Field + "", FieldName, "金額マイナスの為入力せず");
            }
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
        public string ThemOTruocThemSpaceKhiCoDauHoi(string input, int iByte, string str)
        {
            if (string.IsNullOrEmpty(input))
                return input.Insert(0, getcharacter(iByte - input.Length, " "));
            if (input.IndexOf("?") >= 0)
            {
                return input.Insert(0, getcharacter(iByte - input.Length, " "));
            }
            else if (input.Length >= iByte)
                return input.Substring(0, iByte);
            return input.Insert(0, getcharacter(iByte - input.Length, str));
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            namefileExcel = "";
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new[] { new DataColumn("BatchName", typeof(string)) });
            if (!chk_Multiple.Checked)
            {
                var CountImageNotComplete = (from w in Global.Db.CheckInputComplete(cbb_Batch.SelectedValue + "", "DESO") select w.IdImage).ToList();
                var check = (from w in Global.Db.tbl_MissImage_DeSos where w.BatchID == cbb_Batch.SelectedValue + "" && w.Submit == false select w.IDImage).Count();
                if (CountImageNotComplete.Count > 0)
                {
                    MessageBox.Show("Chưa nhập xong DeSo!");
                    return;
                }
                if (check > 0)
                {
                    var list_user = (from w in Global.Db.tbl_MissImage_DeSos where w.BatchID == cbb_Batch.SelectedValue + "" && w.Submit == false select w.UserName).ToList();
                    string sss = "";
                    foreach (var item in list_user)
                    {
                        sss += item + "\r\n";
                    }
                    if (list_user.Count > 0)
                    {
                        MessageBox.Show("Những user lấy hình về nhưng chưa nhập deso: \r\n" + sss);
                        return;
                    }
                }
                var soloi = (from w in Global.Db.GetNumberErrorUnfinish_Excel(cbb_Batch.SelectedValue + "", "DESO") select w.IDImage).Count();
                var ListCheckNotComplete = (from w in Global.Db.tbl_MissImage_DeSos where w.BatchID == cbb_Batch.SelectedValue + "" && w.Submit == false select new { w.IDImage, w.UserName }).ToList();
                if (soloi > 0)
                {
                    MessageBox.Show("Chưa check xong DeSo!");
                    return;
                }
                if (ListCheckNotComplete.Count > 0)
                {
                    string sss = "";
                    foreach (var item in ListCheckNotComplete)
                    {
                        sss += item.UserName + "\r\n";
                    }
                    MessageBox.Show("Những user lấy hình về nhưng chưa check deso: \r\n" + sss);
                    return;
                }
                CountImageNotComplete = (from w in Global.Db.CheckInputComplete(cbb_Batch.SelectedValue + "", "DEJP") select w.IdImage).ToList();
                check = (from w in Global.Db.tbl_MissImage_DeJPs where w.BatchID == cbb_Batch.SelectedValue + "" && w.Submit == false select w.IDImage).Count();
                if (CountImageNotComplete.Count > 0)
                {
                    MessageBox.Show("Chưa nhập xong DEJP!");
                    return;
                }
                if (check > 0)
                {
                    var list_user = (from w in Global.Db.tbl_MissImage_DeJPs where w.BatchID == cbb_Batch.SelectedValue + "" && w.Submit == false select w.UserName).ToList();
                    string sss = "";
                    foreach (var item in list_user)
                    {
                        sss += item + "\r\n";
                    }
                    if (list_user.Count > 0)
                    {
                        MessageBox.Show("Những user lấy hình về nhưng chưa nhập dejp: \r\n" + sss);
                        return;
                    }
                }
                soloi = (from w in Global.Db.GetNumberErrorUnfinish_Excel(cbb_Batch.SelectedValue + "", "DEJP") select w.IDImage).Count();
                ListCheckNotComplete = (from w in Global.Db.tbl_MissImage_DeJPs where w.BatchID == cbb_Batch.SelectedValue + "" && w.Submit == false select new { w.IDImage, w.UserName }).ToList();
                if (soloi > 0)
                {
                    MessageBox.Show("Chưa check xong DEJP!");
                    return;
                }
                if (ListCheckNotComplete.Count > 0)
                {
                    string sss = "";
                    foreach (var item in ListCheckNotComplete)
                    {
                        sss += item.UserName + "\r\n";
                    }
                    MessageBox.Show("Những user lấy hình về nhưng chưa check dejp: \r\n" + sss);
                    return;
                }
                dt.Rows.Add(cbb_Batch.SelectedValue + "");
                namefileExcel = cbb_Batch.Text + "";
                //dataGridView1.DataSource = null;
                //if (cbb_City.Text == "CityO")
                //{
                //    dataGridView1.DataSource = (from w in Global.Db.ExportExcel(cbb_Batch.SelectedValue + "") select w).ToList();
                //    if (dataGridView1.RowCount <= 0)
                //    {
                //        MessageBox.Show("Không có dữ liệu.");
                //        return;
                //    }
                //}
                //else if (cbb_City.Text == "CityN")
                //{
                //    dataGridView1.DataSource = (from w in Global.Db.ExportExcel_CityN(cbb_Batch.SelectedValue + "") select w).ToList();
                //    if (dataGridView1.RowCount <= 0)
                //    {
                //        MessageBox.Show("Không có dữ liệu.");
                //        return;
                //    }
                //}
            }
            else if (chk_Multiple.Checked)
            {
                if (list_Batch.SelectedItems.Count <= 0 & list_Batch.Items.Count > 0)
                {
                    MessageBox.Show("Vui lòng chọn batch.");
                    return;
                }
                if (list_Batch.Items.Count <= 0)
                {
                    MessageBox.Show("Không có Batch.");
                    return;
                }
                foreach (var item in list_Batch.SelectedItems)
                {
                    var CountImageNotComplete = (from w in Global.Db.CheckInputComplete(((MyEntry)item).BatchID + "", "DESO") select w.IdImage).ToList();
                    var check = (from w in Global.Db.tbl_MissImage_DeSos where w.BatchID == ((MyEntry)item).BatchID + "" && w.Submit == false select w.IDImage).Count();
                    if (CountImageNotComplete.Count > 0)
                    {
                        MessageBox.Show("Chưa nhập xong DeSo!");
                        return;
                    }
                    if (check > 0)
                    {
                        var list_user = (from w in Global.Db.tbl_MissImage_DeSos where w.BatchID == ((MyEntry)item).BatchID + "" && w.Submit == false select w.UserName).ToList();
                        string sss = "";
                        foreach (var item_temp in list_user)
                        {
                            sss += item_temp + "\r\n";
                        }
                        if (list_user.Count > 0)
                        {
                            MessageBox.Show("Những user lấy hình về nhưng chưa nhập deso: \r\n" + sss);
                            return;
                        }
                    }
                    var soloi = (from w in Global.Db.GetNumberErrorUnfinish_Excel(((MyEntry)item).BatchID + "", "DESO") select w.IDImage).Count();
                    var ListCheckNotComplete = (from w in Global.Db.tbl_MissImage_DeSos where w.BatchID == ((MyEntry)item).BatchID + "" && w.Submit == false select new { w.IDImage, w.UserName }).ToList();
                    if (ListCheckNotComplete.Count > 0 || soloi > 0)
                    {
                        MessageBox.Show("Chưa check xong DeSo!");
                        string sss = "";
                        foreach (var item_temp in ListCheckNotComplete)
                        {
                            sss += item_temp.UserName + "\r\n";
                        }
                        MessageBox.Show("Những user lấy hình về nhưng chưa check deso: \r\n" + sss);
                        return;
                    }
                    CountImageNotComplete = (from w in Global.Db.CheckInputComplete(((MyEntry)item).BatchID + "", "DEJP") select w.IdImage).ToList();
                    check = (from w in Global.Db.tbl_MissImage_DeJPs where w.BatchID == ((MyEntry)item).BatchID + "" && w.Submit == false select w.IDImage).Count();
                    if (CountImageNotComplete.Count > 0)
                    {
                        MessageBox.Show("Chưa nhập xong DEJP!");
                        return;
                    }
                    if (check > 0)
                    {
                        var list_user = (from w in Global.Db.tbl_MissImage_DeJPs where w.BatchID == ((MyEntry)item).BatchID + "" && w.Submit == false select w.UserName).ToList();
                        string sss = "";
                        foreach (var item_temp in list_user)
                        {
                            sss += item_temp + "\r\n";
                        }
                        if (list_user.Count > 0)
                        {
                            MessageBox.Show("Những user lấy hình về nhưng chưa nhập dejp: \r\n" + sss);
                            return;
                        }
                    }
                    soloi = (from w in Global.Db.GetNumberErrorUnfinish_Excel(((MyEntry)item).BatchID + "", "DEJP") select w.IDImage).Count();
                    ListCheckNotComplete = (from w in Global.Db.tbl_MissImage_DeJPs where w.BatchID == ((MyEntry)item).BatchID + "" && w.Submit == false select new { w.IDImage, w.UserName }).ToList();
                    if (ListCheckNotComplete.Count > 0 || soloi > 0)
                    {
                        MessageBox.Show("Chưa check xong DEJP!");
                        string sss = "";
                        foreach (var item_temp in ListCheckNotComplete)
                        {
                            sss += item_temp.UserName + "\r\n";
                        }
                        MessageBox.Show("Những user lấy hình về nhưng chưa check dejp: \r\n" + sss);
                        return;
                    }
                    dt.Rows.Add(((MyEntry)item).BatchID + "");
                    namefileExcel += ((MyEntry)item).BatchName + "_";
                }
                namefileExcel += "Multiple";
            }

            string ConnectionString = Global.Db.Connection.ConnectionString;
            SqlConnection con = new SqlConnection(ConnectionString);
            DataTable data = new DataTable();
            if (cbb_City.Text == "CityO")
            {
                SqlCommand cmd = new SqlCommand("ExportExcel_Multiple", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BatchID", dt);
                con.Open();
                data.Load(cmd.ExecuteReader());
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = data;
                if (dataGridView1.RowCount <= 0)
                {
                    MessageBox.Show("Không có dữ liệu.");
                    return;
                }
                if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\ExportExcel.xlsx"))
                {
                    File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\ExportExcel.xlsx");
                    File.WriteAllBytes((Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/ExportExcel.xlsx"), Properties.Resources.ExportExcel);
                }
                else
                {
                    File.WriteAllBytes((Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/ExportExcel.xlsx"), Properties.Resources.ExportExcel);
                }
                App = new Microsoft.Office.Interop.Excel.Application();
                book = App.Workbooks.Open(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "\\ExportExcel.xlsx", 0, true, 5, "", "", false, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "", true, false, 0, true, false, false);
                wrksheet = (Microsoft.Office.Interop.Excel.Worksheet)book.ActiveSheet;
            }
            else if (cbb_City.Text == "CityN")
            {
                SqlCommand cmd = new SqlCommand("ExportExcel_CityN_Multiple_New", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BatchID", dt);
                con.Open();
                data.Load(cmd.ExecuteReader());
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = data;
                if (dataGridView1.RowCount <= 0)
                {
                    MessageBox.Show("Không có dữ liệu.");
                    return;
                }
                if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\ExportExcelCityN.xlsx"))
                {
                    File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\ExportExcelCityN.xlsx");
                    File.WriteAllBytes((Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/ExportExcelCityN.xlsx"), Properties.Resources.ExportExcelCityN);
                }
                else
                {
                    File.WriteAllBytes((Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/ExportExcelCityN.xlsx"), Properties.Resources.ExportExcelCityN);
                }
                App = new Microsoft.Office.Interop.Excel.Application();
                book = App.Workbooks.Open(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "\\ExportExcelCityN.xlsx", 0, true, 5, "", "", false, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "", true, false, 0, true, false, false);
                wrksheet = (Microsoft.Office.Interop.Excel.Worksheet)book.ActiveSheet;
            }
            backgroundWorker1.RunWorkerAsync();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            namefileExcel = "";
            if (!chk_Multiple.Checked)
            {
                var CountImageNotComplete = (from w in Global.Db.CheckInputComplete(cbb_Batch.SelectedValue + "", "DESO") select w.IdImage).ToList();
                var check = (from w in Global.Db.tbl_MissImage_DeSos where w.BatchID == cbb_Batch.SelectedValue + "" && w.Submit == false select w.IDImage).Count();
                if (CountImageNotComplete.Count > 0)
                {
                    MessageBox.Show("Chưa nhập xong DeSo!");
                    return;
                }
                if (check > 0)
                {
                    var list_user = (from w in Global.Db.tbl_MissImage_DeSos where w.BatchID == cbb_Batch.SelectedValue + "" && w.Submit == false select w.UserName).ToList();
                    string sss = "";
                    foreach (var item in list_user)
                    {
                        sss += item + "\r\n";
                    }
                    if (list_user.Count > 0)
                    {
                        MessageBox.Show("Những user lấy hình về nhưng chưa nhập deso: \r\n" + sss);
                        return;
                    }
                }
                var soloi = (from w in Global.Db.GetNumberErrorUnfinish_Excel(cbb_Batch.SelectedValue + "", "DESO") select w.IDImage).Count();
                var ListCheckNotComplete = (from w in Global.Db.tbl_MissImage_DeSos where w.BatchID == cbb_Batch.SelectedValue + "" && w.Submit == false select new { w.IDImage, w.UserName }).ToList();
                if (ListCheckNotComplete.Count > 0 || soloi > 0)
                {
                    MessageBox.Show("Chưa check xong DeSo!");
                    string sss = "";
                    foreach (var item in ListCheckNotComplete)
                    {
                        sss += item.UserName + "\r\n";
                    }
                    MessageBox.Show("Những user lấy hình về nhưng chưa check deso: \r\n" + sss);
                    return;
                }

                CountImageNotComplete = (from w in Global.Db.CheckInputComplete(cbb_Batch.SelectedValue + "", "DEJP") select w.IdImage).ToList();
                check = (from w in Global.Db.tbl_MissImage_DeJPs where w.BatchID == cbb_Batch.SelectedValue + "" && w.Submit == false select w.IDImage).Count();
                if (CountImageNotComplete.Count > 0)
                {
                    MessageBox.Show("Chưa nhập xong DEJP!");
                    return;
                }
                if (check > 0)
                {
                    var list_user = (from w in Global.Db.tbl_MissImage_DeJPs where w.BatchID == cbb_Batch.SelectedValue + "" && w.Submit == false select w.UserName).ToList();
                    string sss = "";
                    foreach (var item in list_user)
                    {
                        sss += item + "\r\n";
                    }
                    if (list_user.Count > 0)
                    {
                        MessageBox.Show("Những user lấy hình về nhưng chưa nhập dejp: \r\n" + sss);
                        return;
                    }
                }
                soloi = (from w in Global.Db.GetNumberErrorUnfinish_Excel(cbb_Batch.SelectedValue + "", "DEJP") select w.IDImage).Count();
                ListCheckNotComplete = (from w in Global.Db.tbl_MissImage_DeJPs where w.BatchID == cbb_Batch.SelectedValue + "" && w.Submit == false select new { w.IDImage, w.UserName }).ToList();
                if (ListCheckNotComplete.Count > 0 || soloi > 0)
                {
                    MessageBox.Show("Chưa check xong DEJP!");
                    string sss = "";
                    foreach (var item in ListCheckNotComplete)
                    {
                        sss += item.UserName + "\r\n";
                    }
                    MessageBox.Show("Những user lấy hình về nhưng chưa check dejp: \r\n" + sss);
                    return;
                }

                dataGridView1.DataSource = null;
                if (cbb_City.Text == "CityO")
                {
                    dataGridView1.DataSource = (from w in Global.Db.ExportExcel_Error(cbb_Batch.SelectedValue + "") select w).ToList();
                }
                if (dataGridView1.RowCount <= 0)
                {
                    MessageBox.Show("Không có dữ liệu.");
                    return;
                }
                namefileExcel = cbb_Batch.Text + "_Error";
            }
            else if (chk_Multiple.Checked)
            {
                if (list_Batch.SelectedItems.Count <= 0 & list_Batch.Items.Count > 0)
                {
                    MessageBox.Show("Vui lòng chọn batch.");
                    return;
                }
                if (list_Batch.Items.Count <= 0)
                {
                    MessageBox.Show("Không có Batch.");
                    return;
                }
                DataTable dt = new DataTable();
                dt.Columns.AddRange(new[] { new DataColumn("BatchName", typeof(string)) });
                foreach (var item in list_Batch.SelectedItems)
                {
                    var CountImageNotComplete = (from w in Global.Db.CheckInputComplete(((MyEntry)item).BatchID + "", "DESO") select w.IdImage).ToList();
                    var check = (from w in Global.Db.tbl_MissImage_DeSos where w.BatchID == ((MyEntry)item).BatchID + "" && w.Submit == false select w.IDImage).Count();
                    if (CountImageNotComplete.Count > 0)
                    {
                        MessageBox.Show("Chưa nhập xong DeSo!");
                        return;
                    }
                    if (check > 0)
                    {
                        var list_user = (from w in Global.Db.tbl_MissImage_DeSos where w.BatchID == ((MyEntry)item).BatchID + "" && w.Submit == false select w.UserName).ToList();
                        string sss = "";
                        foreach (var item_temp in list_user)
                        {
                            sss += item_temp + "\r\n";
                        }
                        if (list_user.Count > 0)
                        {
                            MessageBox.Show("Những user lấy hình về nhưng chưa nhập deso: \r\n" + sss);
                            return;
                        }
                    }
                    var soloi = (from w in Global.Db.GetNumberErrorUnfinish_Excel(((MyEntry)item).BatchID + "", "DESO") select w.IDImage).Count();
                    var ListCheckNotComplete = (from w in Global.Db.tbl_MissImage_DeSos where w.BatchID == ((MyEntry)item).BatchID + "" && w.Submit == false select new { w.IDImage, w.UserName }).ToList();
                    if (ListCheckNotComplete.Count > 0 || soloi > 0)
                    {
                        MessageBox.Show("Chưa check xong DeSo!");
                        string sss = "";
                        foreach (var item_temp in ListCheckNotComplete)
                        {
                            sss += item_temp.UserName + "\r\n";
                        }
                        MessageBox.Show("Những user lấy hình về nhưng chưa check deso: \r\n" + sss);
                        return;
                    }
                    CountImageNotComplete = (from w in Global.Db.CheckInputComplete(((MyEntry)item).BatchID + "", "DEJP") select w.IdImage).ToList();
                    check = (from w in Global.Db.tbl_MissImage_DeJPs where w.BatchID == ((MyEntry)item).BatchID + "" && w.Submit == false select w.IDImage).Count();
                    if (CountImageNotComplete.Count > 0)
                    {
                        MessageBox.Show("Chưa nhập xong DEJP!");
                        return;
                    }
                    if (check > 0)
                    {
                        var list_user = (from w in Global.Db.tbl_MissImage_DeJPs where w.BatchID == ((MyEntry)item).BatchID + "" && w.Submit == false select w.UserName).ToList();
                        string sss = "";
                        foreach (var item_temp in list_user)
                        {
                            sss += item_temp + "\r\n";
                        }
                        if (list_user.Count > 0)
                        {
                            MessageBox.Show("Những user lấy hình về nhưng chưa nhập dejp: \r\n" + sss);
                            return;
                        }
                    }
                    soloi = (from w in Global.Db.GetNumberErrorUnfinish_Excel(((MyEntry)item).BatchID + "", "DEJP") select w.IDImage).Count();
                    ListCheckNotComplete = (from w in Global.Db.tbl_MissImage_DeJPs where w.BatchID == ((MyEntry)item).BatchID + "" && w.Submit == false select new { w.IDImage, w.UserName }).ToList();
                    if (ListCheckNotComplete.Count > 0 || soloi > 0)
                    {
                        MessageBox.Show("Chưa check xong DEJP!");
                        string sss = "";
                        foreach (var item_temp in ListCheckNotComplete)
                        {
                            sss += item_temp.UserName + "\r\n";
                        }
                        MessageBox.Show("Những user lấy hình về nhưng chưa check dejp: \r\n" + sss);
                        return;
                    }
                    dt.Rows.Add(((MyEntry)item).BatchID + "");
                    namefileExcel += ((MyEntry)item).BatchName + "_";
                }
                dataGridView1.DataSource = null;
                string ConnectionString = Global.Db.Connection.ConnectionString;
                SqlConnection con = new SqlConnection(ConnectionString);
                DataTable data = new DataTable();
                if (cbb_City.Text == "CityO")
                {
                    SqlCommand cmd = new SqlCommand("ExportExcel_Error_Multiple", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@BatchID", dt);
                    cmd.Parameters.AddWithValue("@City", cbb_City.Text);
                    con.Open();
                    data.Load(cmd.ExecuteReader());
                    dataGridView1.DataSource = data;
                }
                namefileExcel += "Multiple_Error";
            }
            if (dataGridView1.RowCount <= 0)
            {
                MessageBox.Show("Không có dữ liệu.");
                return;
            }
            if (cbb_City.Text == "CityO")
            {
                if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\ExportExcel_Error.xlsx"))
                {
                    File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\ExportExcel_Error.xlsx");
                    File.WriteAllBytes((Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/ExportExcel_Error.xlsx"), Properties.Resources.ExportExcel_Error);
                }
                else
                {
                    File.WriteAllBytes((Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/ExportExcel_Error.xlsx"), Properties.Resources.ExportExcel_Error);
                }
                App = new Microsoft.Office.Interop.Excel.Application();
                book = App.Workbooks.Open(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "\\ExportExcel_Error.xlsx", 0, true, 5, "", "", false, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "", true, false, 0, true, false, false);
                wrksheet = (Microsoft.Office.Interop.Excel.Worksheet)book.ActiveSheet;
            }
            backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            progressBar1.Step = 1;
            progressBar1.Value = 0;
            progressBar1.Maximum = dataGridView1.RowCount;
            progressBar1.Minimum = 0;
            ModifyProgressBarColor.SetState(progressBar1, 1);
            h = 2;
            if(namefileExcel.IndexOf("_Error")<0)
            {
                if (cbb_City.Text == "CityO")
                {
                    string Truong66 = "";
                    string Truong18Loai1 = "";
                    bool IsLoai2 = false;
                    for (int i = 0; i < dataGridView1.RowCount; i++)
                    {
                        Truong66 = "";
                        if (dataGridView1[1, i].Value + "" == "Loai1")
                            Truong18Loai1 = dataGridView1[19, i].Value + "";
                        if (i > 0 & IsLoai2 & dataGridView1[1, i].Value + "" == "Loai3")
                            Truong66 = "1";
                        if (dataGridView1[1, i].Value + "" == "Loai2" && !IsLoai2)
                            IsLoai2 = true;
                        else if (dataGridView1[1, i].Value + "" == "Loai2" && IsLoai2)
                            IsLoai2 = false;
                        else if (dataGridView1[1, i].Value + "" == "Loai1")
                            IsLoai2 = false;

                        wrksheet.Cells[h, 1] = dataGridView1[0, i].Value + "";  //Trường 01/ Tên hình
                        wrksheet.Cells[h, 2] = dataGridView1[1, i].Value + "";  //LoaiPhieu
                        wrksheet.Cells[h, 3] = dataGridView1[2, i].Value + "";  //Truong001
                        wrksheet.Cells[h, 4] = dataGridView1[3, i].Value + "";
                        wrksheet.Cells[h, 5] = dataGridView1[4, i].Value + "";
                        wrksheet.Cells[h, 6] = dataGridView1[5, i].Value + "";
                        wrksheet.Cells[h, 7] = dataGridView1[6, i].Value + "";
                        wrksheet.Cells[h, 8] = dataGridView1[7, i].Value + "";
                        wrksheet.Cells[h, 9] = dataGridView1[8, i].Value + "";
                        wrksheet.Cells[h, 10] = dataGridView1[9, i].Value + "";
                        wrksheet.Cells[h, 11] = dataGridView1[10, i].Value + "";
                        wrksheet.Cells[h, 12] = dataGridView1[11, i].Value + "";
                        wrksheet.Cells[h, 13] = dataGridView1[12, i].Value + "";
                        wrksheet.Cells[h, 14] = dataGridView1[13, i].Value + "";
                        wrksheet.Cells[h, 15] = dataGridView1[14, i].Value + "";
                        wrksheet.Cells[h, 16] = (dataGridView1[1, i].Value + "") == "Loai1" ? "4" : (dataGridView1[1, i].Value + "") == "Loai2" ? "" : Truong18Loai1;
                        wrksheet.Cells[h, 17] = dataGridView1[16, i].Value + "";    //Truong015
                        wrksheet.Cells[h, 18] = dataGridView1[17, i].Value + "";    //Truong016
                        wrksheet.Cells[h, 19] = dataGridView1[18, i].Value + "";    //Truong017
                        wrksheet.Cells[h, 20] = dataGridView1[19, i].Value + "";    //Truong018
                        wrksheet.Cells[h, 21] = dataGridView1[20, i].Value + "";    //Truong019
                        wrksheet.Cells[h, 22] = dataGridView1[21, i].Value + "";    //Truong020
                        wrksheet.Cells[h, 23] = dataGridView1[22, i].Value + "";    //Truong021
                        wrksheet.Cells[h, 24] = dataGridView1[23, i].Value + "";    //Truong022
                        wrksheet.Cells[h, 25] = dataGridView1[24, i].Value + "";    //Truong023
                        wrksheet.Cells[h, 26] = dataGridView1[25, i].Value + "";    //Truong024
                        wrksheet.Cells[h, 27] = dataGridView1[26, i].Value + "";    //Truong025
                        wrksheet.Cells[h, 28] = dataGridView1[27, i].Value + "";    //Truong026
                        wrksheet.Cells[h, 29] = dataGridView1[28, i].Value + "";    //Truong027
                        wrksheet.Cells[h, 30] = dataGridView1[29, i].Value + "";    //Truong028
                        wrksheet.Cells[h, 31] = dataGridView1[30, i].Value + "";    //Truong029
                        wrksheet.Cells[h, 32] = dataGridView1[31, i].Value + "";    //Truong030
                        wrksheet.Cells[h, 33] = dataGridView1[32, i].Value + "";    //Truong031
                        wrksheet.Cells[h, 34] = dataGridView1[33, i].Value + "";    //Truong032
                        wrksheet.Cells[h, 35] = dataGridView1[34, i].Value + "";    //Truong033
                        wrksheet.Cells[h, 36] = dataGridView1[35, i].Value + "";    //Truong034
                        wrksheet.Cells[h, 37] = dataGridView1[36, i].Value + "";    //Truong035
                        wrksheet.Cells[h, 38] = dataGridView1[37, i].Value + "";    //Truong036
                        wrksheet.Cells[h, 39] = dataGridView1[38, i].Value + "";    //Truong037
                        wrksheet.Cells[h, 40] = dataGridView1[39, i].Value + "";    //Truong038
                        wrksheet.Cells[h, 41] = dataGridView1[40, i].Value + "";    //Truong039
                        wrksheet.Cells[h, 42] = dataGridView1[41, i].Value + "";    //Truong040
                        wrksheet.Cells[h, 43] = dataGridView1[42, i].Value + "";    //Truong041
                        wrksheet.Cells[h, 44] = dataGridView1[43, i].Value + "";    //Truong042
                        wrksheet.Cells[h, 45] = dataGridView1[44, i].Value + "";    //Truong043
                        wrksheet.Cells[h, 46] = dataGridView1[45, i].Value + "";    //Truong044
                        wrksheet.Cells[h, 47] = dataGridView1[46, i].Value + "";    //Truong045
                        wrksheet.Cells[h, 48] = dataGridView1[47, i].Value + "";    //Truong046
                        wrksheet.Cells[h, 49] = dataGridView1[48, i].Value + "";    //Truong047
                        wrksheet.Cells[h, 50] = dataGridView1[49, i].Value + "";    //Truong048
                        wrksheet.Cells[h, 51] = dataGridView1[50, i].Value + "";    //Truong049
                        wrksheet.Cells[h, 52] = dataGridView1[51, i].Value + "";    //Truong050
                        wrksheet.Cells[h, 53] = dataGridView1[52, i].Value + "";    //Truong051
                        wrksheet.Cells[h, 54] = dataGridView1[53, i].Value + "";    //Truong052
                        wrksheet.Cells[h, 55] = dataGridView1[54, i].Value + "";    //Truong053
                        wrksheet.Cells[h, 56] = dataGridView1[55, i].Value + "";    //Truong054
                        wrksheet.Cells[h, 57] = dataGridView1[56, i].Value + "";    //Truong055
                        wrksheet.Cells[h, 58] = dataGridView1[57, i].Value + "";    //Truong056
                        wrksheet.Cells[h, 59] = dataGridView1[58, i].Value + "";    //Truong057
                        wrksheet.Cells[h, 60] = dataGridView1[59, i].Value + "";    //Truong058
                        wrksheet.Cells[h, 61] = dataGridView1[60, i].Value + "";    //Truong059
                        wrksheet.Cells[h, 62] = dataGridView1[61, i].Value + "";    //Truong060
                        wrksheet.Cells[h, 63] = dataGridView1[62, i].Value + "";    //Truong061
                        wrksheet.Cells[h, 64] = dataGridView1[63, i].Value + "";    //Truong062
                        wrksheet.Cells[h, 65] = dataGridView1[64, i].Value + "";    //Truong063
                        wrksheet.Cells[h, 66] = dataGridView1[65, i].Value + "";    //Truong064
                        wrksheet.Cells[h, 67] = dataGridView1[66, i].Value + "";    //Truong065
                        wrksheet.Cells[h, 68] = (dataGridView1[1, i].Value + "" == "Loai3") ? Truong66 : "";                           //Truong066
                        wrksheet.Cells[h, 69] = dataGridView1[68, i].Value + "";    //Truong067
                        wrksheet.Cells[h, 70] = dataGridView1[69, i].Value + "";    //Truong068
                        wrksheet.Cells[h, 71] = dataGridView1[70, i].Value + "";    //Truong069
                        wrksheet.Cells[h, 72] = dataGridView1[71, i].Value + "";    //Truong070
                        wrksheet.Cells[h, 73] = dataGridView1[72, i].Value + "";    //Truong071
                        wrksheet.Cells[h, 74] = dataGridView1[73, i].Value + "";    //Truong072
                        wrksheet.Cells[h, 75] = dataGridView1[74, i].Value + "";    //Truong073
                        wrksheet.Cells[h, 76] = dataGridView1[75, i].Value + "";    //Truong074
                        wrksheet.Cells[h, 77] = dataGridView1[76, i].Value + "";    //Truong075
                        wrksheet.Cells[h, 78] = dataGridView1[77, i].Value + "";    //Truong076
                        wrksheet.Cells[h, 79] = dataGridView1[78, i].Value + "";    //Truong077
                        wrksheet.Cells[h, 80] = dataGridView1[79, i].Value + "";    //Truong078
                        wrksheet.Cells[h, 81] = dataGridView1[80, i].Value + "";    //Truong079
                        wrksheet.Cells[h, 82] = dataGridView1[81, i].Value + "";    //Truong080
                        wrksheet.Cells[h, 83] = dataGridView1[82, i].Value + "";    //Truong081
                        wrksheet.Cells[h, 84] = dataGridView1[83, i].Value + "";    //Truong082
                        wrksheet.Cells[h, 85] = dataGridView1[84, i].Value + "";    //Truong083
                        wrksheet.Cells[h, 86] = dataGridView1[85, i].Value + "";    //Truong084
                        wrksheet.Cells[h, 87] = dataGridView1[86, i].Value + "";    //Truong085
                        wrksheet.Cells[h, 88] = dataGridView1[87, i].Value + "";    //Truong086
                        wrksheet.Cells[h, 89] = dataGridView1[88, i].Value + "";    //Truong087
                        wrksheet.Cells[h, 90] = dataGridView1[89, i].Value + "";    //Truong088
                        wrksheet.Cells[h, 91] = dataGridView1[90, i].Value + "";    //Truong089
                        wrksheet.Cells[h, 92] = dataGridView1[91, i].Value + "";    //Truong090
                        wrksheet.Cells[h, 93] = dataGridView1[92, i].Value + "";    //Truong091
                        wrksheet.Cells[h, 94] = dataGridView1[93, i].Value + "";    //Truong092
                        wrksheet.Cells[h, 95] = dataGridView1[94, i].Value + "";    //Truong093
                        for (int j = 1; j <= 4; j++)
                        {
                            if (string.IsNullOrEmpty(dataGridView1[95, i].Value + "") && string.IsNullOrEmpty(dataGridView1[96, i].Value + "") &&
                                  (!string.IsNullOrEmpty(dataGridView1[97, i].Value + "") || !string.IsNullOrEmpty(dataGridView1[98, i].Value + "")))
                            {
                                dataGridView1[95, i].Value = dataGridView1[97, i].Value + "";
                                dataGridView1[96, i].Value = dataGridView1[98, i].Value + "";

                                dataGridView1[97, i].Value = "";
                                dataGridView1[98, i].Value = "";
                            }
                            if (string.IsNullOrEmpty(dataGridView1[103, i].Value + "") && string.IsNullOrEmpty(dataGridView1[104, i].Value + "") &&
                                (!string.IsNullOrEmpty(dataGridView1[105, i].Value + "") || !string.IsNullOrEmpty(dataGridView1[106, i].Value + "")))
                            {
                                dataGridView1[103, i].Value = dataGridView1[105, i].Value + "";
                                dataGridView1[104, i].Value = dataGridView1[106, i].Value + "";

                                dataGridView1[105, i].Value = "";
                                dataGridView1[106, i].Value = "";
                            }
                            if (string.IsNullOrEmpty(dataGridView1[97, i].Value + "") && string.IsNullOrEmpty(dataGridView1[98, i].Value + "") &&
                                (!string.IsNullOrEmpty(dataGridView1[99, i].Value + "") || !string.IsNullOrEmpty(dataGridView1[100, i].Value + "")))
                            {
                                dataGridView1[97, i].Value = dataGridView1[99, i].Value + "";
                                dataGridView1[98, i].Value = dataGridView1[100, i].Value + "";

                                dataGridView1[99, i].Value = "";
                                dataGridView1[100, i].Value = "";
                            }
                            if (string.IsNullOrEmpty(dataGridView1[105, i].Value + "") && string.IsNullOrEmpty(dataGridView1[106, i].Value + "") &&
                               (!string.IsNullOrEmpty(dataGridView1[107, i].Value + "") || !string.IsNullOrEmpty(dataGridView1[108, i].Value + "")))
                            {
                                dataGridView1[105, i].Value = dataGridView1[107, i].Value + "";
                                dataGridView1[106, i].Value = dataGridView1[108, i].Value + "";

                                dataGridView1[107, i].Value = "";
                                dataGridView1[108, i].Value = "";
                            }
                            if (string.IsNullOrEmpty(dataGridView1[99, i].Value + "") && string.IsNullOrEmpty(dataGridView1[100, i].Value + "") &&
                               (!string.IsNullOrEmpty(dataGridView1[101, i].Value + "") || !string.IsNullOrEmpty(dataGridView1[102, i].Value + "")))
                            {
                                dataGridView1[99, i].Value = dataGridView1[101, i].Value + "";
                                dataGridView1[100, i].Value = dataGridView1[102, i].Value + "";

                                dataGridView1[101, i].Value = "";
                                dataGridView1[102, i].Value = "";
                            }
                            if (string.IsNullOrEmpty(dataGridView1[107, i].Value + "") && string.IsNullOrEmpty(dataGridView1[108, i].Value + "") &&
                              (!string.IsNullOrEmpty(dataGridView1[109, i].Value + "") || !string.IsNullOrEmpty(dataGridView1[110, i].Value + "")))
                            {
                                dataGridView1[107, i].Value = dataGridView1[109, i].Value + "";
                                dataGridView1[108, i].Value = dataGridView1[110, i].Value + "";

                                dataGridView1[109, i].Value = "";
                                dataGridView1[110, i].Value = "";
                            }
                        }

                        wrksheet.Cells[h, 96] = dataGridView1[95, i].Value + "";    //Truong094
                        wrksheet.Cells[h, 97] = dataGridView1[96, i].Value + "";    //Truong095
                        wrksheet.Cells[h, 104] = dataGridView1[103, i].Value + "";    //Truong102
                        wrksheet.Cells[h, 105] = dataGridView1[104, i].Value + "";    //Truong103

                        wrksheet.Cells[h, 98] = dataGridView1[97, i].Value + "";    //Truong096
                        wrksheet.Cells[h, 99] = dataGridView1[98, i].Value + "";    //Truong097
                        wrksheet.Cells[h, 106] = dataGridView1[105, i].Value + "";    //Truong104
                        wrksheet.Cells[h, 107] = dataGridView1[106, i].Value + "";    //Truong105

                        wrksheet.Cells[h, 100] = dataGridView1[99, i].Value + "";    //Truong098
                        wrksheet.Cells[h, 101] = dataGridView1[100, i].Value + "";    //Truong099
                        wrksheet.Cells[h, 108] = dataGridView1[107, i].Value + "";    //Truong106
                        wrksheet.Cells[h, 109] = dataGridView1[108, i].Value + "";    //Truong107

                        wrksheet.Cells[h, 102] = dataGridView1[101, i].Value + "";    //Truong100
                        wrksheet.Cells[h, 103] = dataGridView1[102, i].Value + "";    //Truong101
                        wrksheet.Cells[h, 110] = dataGridView1[109, i].Value + "";    //Truong108
                        wrksheet.Cells[h, 111] = dataGridView1[110, i].Value + "";    //Truong109
                        wrksheet.Cells[h, 112] = dataGridView1[111, i].Value + "";    //Truong110
                        wrksheet.Cells[h, 113] = dataGridView1[112, i].Value + "";    //Truong111
                        wrksheet.Cells[h, 114] = "";   //Truong112
                        wrksheet.Cells[h, 115] = dataGridView1[113, i].Value + "";    //Batch
                        lb_Complete.Text = (i + 1) + "/" + dataGridView1.RowCount;
                        progressBar1.PerformStep();
                        h++;
                    }
                    Microsoft.Office.Interop.Excel.Range rowHead = wrksheet.get_Range("A1", "DK" + (h - 1));
                    rowHead.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;
                }
                else if(cbb_City.Text=="CityN")
                {
                    string Truong74 = "";
                    for (int i = 0; i < dataGridView1.RowCount; i++)
                    {
                        Truong74 = "";
                        if ((dataGridView1[65, i].Value + "").IndexOf("?") >= 0 && (dataGridView1[66, i].Value + "").IndexOf("?") >= 0 && (dataGridView1[67, i].Value + "").IndexOf("?") >= 0)
                            Truong74 = " ? ? ?";
                        else if ((dataGridView1[65, i].Value + "").IndexOf("?") >= 0)
                            Truong74 = " ?" + ThemOTruocThemSpaceKhiCoDauHoi(dataGridView1[66, i].Value + "", 2, "0") + ThemOTruocThemSpaceKhiCoDauHoi(dataGridView1[67, i].Value + "", 2, "0");
                        else if ((dataGridView1[66, i].Value + "").IndexOf("?") >= 0 || (dataGridView1[67, i].Value + "").IndexOf("?") >= 0)
                            Truong74 = "?";
                        else
                            Truong74 = ThemOTruocThemSpaceKhiCoDauHoi(dataGridView1[65, i].Value + "", 2, "0") +
                                        ThemOTruocThemSpaceKhiCoDauHoi(dataGridView1[66, i].Value + "", 2, "0") +
                                        ThemOTruocThemSpaceKhiCoDauHoi(dataGridView1[67, i].Value + "", 2, "0");
                        wrksheet.Cells[h, 1] = dataGridView1[0, i].Value + "";  //Trường 01/ Tên hình
                        wrksheet.Cells[h, 2] = dataGridView1[1, i].Value + "";  //LoaiPhieu
                        wrksheet.Cells[h, 3] = dataGridView1[2, i].Value + "";  //Truong001
                        wrksheet.Cells[h, 4] = dataGridView1[3, i].Value + "";  //Truong011
                        wrksheet.Cells[h, 5] = dataGridView1[4, i].Value + "";  //Truong012
                        wrksheet.Cells[h, 6] = dataGridView1[5, i].Value + "";  //Truong014
                        wrksheet.Cells[h, 7] = dataGridView1[6, i].Value + "";  //Truong015
                        wrksheet.Cells[h, 8] = dataGridView1[7, i].Value + "";  //Truong016
                        wrksheet.Cells[h, 9] = dataGridView1[8, i].Value + "";  //Truong017
                        wrksheet.Cells[h, 10] = dataGridView1[9, i].Value + "";  //Truong018
                        wrksheet.Cells[h, 11] = dataGridView1[10, i].Value + "";  //Truong019
                        wrksheet.Cells[h, 12] = dataGridView1[11, i].Value + "";  //Truong020
                        wrksheet.Cells[h, 13] = dataGridView1[12, i].Value + "";  //Truong021
                        wrksheet.Cells[h, 14] = dataGridView1[13, i].Value + "";  //Truong022
                        wrksheet.Cells[h, 15] = dataGridView1[14, i].Value + "";  //Truong023
                        wrksheet.Cells[h, 16] = dataGridView1[15, i].Value + "";  //Truong024
                        wrksheet.Cells[h, 17] = dataGridView1[16, i].Value + "";  //Truong025
                        wrksheet.Cells[h, 18] = dataGridView1[17, i].Value + "";  //Truong026
                        wrksheet.Cells[h, 19] = dataGridView1[18, i].Value + "";  //Truong027
                        wrksheet.Cells[h, 20] = dataGridView1[19, i].Value + "";  //Truong028
                        wrksheet.Cells[h, 21] = dataGridView1[20, i].Value + "";  //Truong029
                        wrksheet.Cells[h, 22] = dataGridView1[21, i].Value + "";  //Truong030
                        wrksheet.Cells[h, 23] = dataGridView1[22, i].Value + "";  //Truong031
                        wrksheet.Cells[h, 24] = dataGridView1[23, i].Value + "";  //Truong032
                        wrksheet.Cells[h, 25] = dataGridView1[24, i].Value + "";  //Truong033
                        wrksheet.Cells[h, 26] = dataGridView1[25, i].Value + "";  //Truong034
                        wrksheet.Cells[h, 27] = dataGridView1[26, i].Value + "";  //Truong035
                        wrksheet.Cells[h, 28] = dataGridView1[27, i].Value + "";  //Truong036
                        wrksheet.Cells[h, 29] = dataGridView1[28, i].Value + "";  //Truong037
                        wrksheet.Cells[h, 30] = dataGridView1[29, i].Value + "";  //Truong038
                        wrksheet.Cells[h, 31] = dataGridView1[30, i].Value + "";  //Truong039
                        wrksheet.Cells[h, 32] = dataGridView1[31, i].Value + "";  //Truong040
                        wrksheet.Cells[h, 33] = dataGridView1[32, i].Value + "";  //Truong041
                        wrksheet.Cells[h, 34] = dataGridView1[33, i].Value + "";  //Truong042
                        wrksheet.Cells[h, 35] = dataGridView1[34, i].Value + "";  //Truong043
                        wrksheet.Cells[h, 36] = dataGridView1[35, i].Value + "";  //Truong044
                        wrksheet.Cells[h, 37] = dataGridView1[36, i].Value + "";  //Truong045
                        wrksheet.Cells[h, 38] = dataGridView1[37, i].Value + "";  //Truong046
                        wrksheet.Cells[h, 39] = dataGridView1[38, i].Value + "";  //Truong047
                        wrksheet.Cells[h, 40] = dataGridView1[39, i].Value + "";  //Truong048
                        wrksheet.Cells[h, 41] = dataGridView1[40, i].Value + "";  //Truong049
                        wrksheet.Cells[h, 42] = dataGridView1[41, i].Value + "";  //Truong050
                        wrksheet.Cells[h, 43] = dataGridView1[42, i].Value + "";  //Truong051
                        wrksheet.Cells[h, 44] = dataGridView1[43, i].Value + "";  //Truong052
                        wrksheet.Cells[h, 45] = dataGridView1[44, i].Value + "";  //Truong053
                        wrksheet.Cells[h, 46] = dataGridView1[45, i].Value + "";  //Truong054
                        wrksheet.Cells[h, 47] = dataGridView1[46, i].Value + "";  //Truong055
                        wrksheet.Cells[h, 48] = dataGridView1[47, i].Value + "";  //Truong056
                        wrksheet.Cells[h, 49] = dataGridView1[48, i].Value + "";  //Truong057
                        wrksheet.Cells[h, 50] = dataGridView1[49, i].Value + "";  //Truong058
                        wrksheet.Cells[h, 51] = dataGridView1[50, i].Value + "";  //Truong059
                        wrksheet.Cells[h, 52] = dataGridView1[51, i].Value + "";  //Truong060
                        wrksheet.Cells[h, 53] = dataGridView1[52, i].Value + "";  //Truong061
                        wrksheet.Cells[h, 54] = dataGridView1[53, i].Value + "";  //Truong062
                        wrksheet.Cells[h, 55] = dataGridView1[54, i].Value + "";  //Truong063
                        wrksheet.Cells[h, 56] = dataGridView1[55, i].Value + "";  //Truong064
                        wrksheet.Cells[h, 57] = dataGridView1[56, i].Value + "";  //Truong065
                        wrksheet.Cells[h, 58] = dataGridView1[57, i].Value + "";  //Truong066
                        wrksheet.Cells[h, 59] = dataGridView1[58, i].Value + "";  //Truong067
                        wrksheet.Cells[h, 60] = dataGridView1[59, i].Value + "";  //Truong068
                        wrksheet.Cells[h, 61] = dataGridView1[60, i].Value + "";  //Truong069
                        wrksheet.Cells[h, 62] = dataGridView1[61, i].Value + "";  //Truong070
                        wrksheet.Cells[h, 63] = dataGridView1[62, i].Value + "";  //Truong071
                        wrksheet.Cells[h, 64] = dataGridView1[63, i].Value + "";  //Truong072
                        wrksheet.Cells[h, 65] = dataGridView1[64, i].Value + "";  //Truong073
                        wrksheet.Cells[h, 66] = Truong74;                         //Truong074
                        wrksheet.Cells[h, 67] = dataGridView1[68, i].Value + "";  //Truong075
                        wrksheet.Cells[h, 68] = dataGridView1[69, i].Value + "";  //Truong076
                        wrksheet.Cells[h, 69] = dataGridView1[70, i].Value + "";  //Truong077
                        wrksheet.Cells[h, 70] = dataGridView1[71, i].Value + "";  //Truong078
                        wrksheet.Cells[h, 71] = dataGridView1[72, i].Value + "";  //Truong079
                        wrksheet.Cells[h, 72] = dataGridView1[73, i].Value + "";  //Truong080
                        wrksheet.Cells[h, 73] = dataGridView1[74, i].Value + "";  //Truong081
                        wrksheet.Cells[h, 74] = dataGridView1[75, i].Value + "";  //Truong082
                        wrksheet.Cells[h, 75] = dataGridView1[76, i].Value + "";  //Truong083
                        wrksheet.Cells[h, 76] = dataGridView1[77, i].Value + "";  //Truong084
                        wrksheet.Cells[h, 77] = dataGridView1[78, i].Value + "";  //Truong085
                        wrksheet.Cells[h, 78] = dataGridView1[79, i].Value + "";  //Truong086
                        wrksheet.Cells[h, 79] = dataGridView1[80, i].Value + "";  //Truong087
                        wrksheet.Cells[h, 80] = dataGridView1[81, i].Value + "";  //Truong088
                        wrksheet.Cells[h, 81] = dataGridView1[82, i].Value + "";  //Truong089
                        wrksheet.Cells[h, 82] = dataGridView1[83, i].Value + "";  //Truong090
                        wrksheet.Cells[h, 83] = dataGridView1[84, i].Value + "";  //Truong091
                        wrksheet.Cells[h, 84] = dataGridView1[85, i].Value + "";  //Truong092
                        wrksheet.Cells[h, 85] = dataGridView1[86, i].Value + "";  //Truong093
                        wrksheet.Cells[h, 86] = dataGridView1[87, i].Value + "";  //Truong094
                        wrksheet.Cells[h, 87] = dataGridView1[88, i].Value + "";  //Truong095
                        wrksheet.Cells[h, 88] = dataGridView1[89, i].Value + "";  //Truong096
                        wrksheet.Cells[h, 89] = dataGridView1[90, i].Value + "";  //Truong097
                        wrksheet.Cells[h, 90] = dataGridView1[91, i].Value + "";  //Truong098
                        wrksheet.Cells[h, 91] = dataGridView1[92, i].Value + "";  //Truong099
                        wrksheet.Cells[h, 92] = dataGridView1[93, i].Value + "";  //Truong100
                        wrksheet.Cells[h, 93] = dataGridView1[94, i].Value + "";  //Truong101
                        wrksheet.Cells[h, 94] = dataGridView1[95, i].Value + "";  //Truong102
                        wrksheet.Cells[h, 95] = dataGridView1[96, i].Value + "";  //Truong103
                        wrksheet.Cells[h, 96] = dataGridView1[97, i].Value + "";  //Truong104
                        wrksheet.Cells[h, 97] = dataGridView1[98, i].Value + "";  //Truong105
                        wrksheet.Cells[h, 98] = dataGridView1[99, i].Value + "";  //Truong106
                        wrksheet.Cells[h, 99] = dataGridView1[100, i].Value + "";  //Truong107
                        wrksheet.Cells[h, 100] = dataGridView1[101, i].Value + "";  //Truong108
                        wrksheet.Cells[h, 101] = dataGridView1[102, i].Value + "";  //Truong109
                        wrksheet.Cells[h, 102] = dataGridView1[103, i].Value + "";  //Truong110
                        wrksheet.Cells[h, 103] = dataGridView1[104, i].Value + "";  //Truong111
                        wrksheet.Cells[h, 104] = dataGridView1[105, i].Value + "";  //Truong112
                        wrksheet.Cells[h, 105] = dataGridView1[106, i].Value + "";  //Truong113
                        wrksheet.Cells[h, 106] = dataGridView1[107, i].Value + "";  //Truong114
                        wrksheet.Cells[h, 107] = dataGridView1[108, i].Value + "";  //Truong115
                        wrksheet.Cells[h, 108] = dataGridView1[109, i].Value + "";  //Truong116
                        wrksheet.Cells[h, 109] = dataGridView1[110, i].Value + "";  //Truong117
                        wrksheet.Cells[h, 110] = dataGridView1[111, i].Value + "";  //Truong118
                        wrksheet.Cells[h, 111] = dataGridView1[112, i].Value + "";  //Truong119
                        wrksheet.Cells[h, 112] = dataGridView1[113, i].Value + "";  //Truong120
                        wrksheet.Cells[h, 113] = dataGridView1[114, i].Value + "";  //Truong121
                        wrksheet.Cells[h, 114] = dataGridView1[115, i].Value + "";  //Truong122
                        wrksheet.Cells[h, 115] = dataGridView1[116, i].Value + "";  //Truong123
                        wrksheet.Cells[h, 116] = dataGridView1[117, i].Value + "";  //Truong124
                        wrksheet.Cells[h, 117] = dataGridView1[118, i].Value + "";  //Truong125
                        wrksheet.Cells[h, 118] = dataGridView1[119, i].Value + "";  //Truong126
                        wrksheet.Cells[h, 119] = dataGridView1[120, i].Value + "";  //Truong127
                        wrksheet.Cells[h, 120] = dataGridView1[121, i].Value + "";  //Truong128
                        wrksheet.Cells[h, 121] = dataGridView1[122, i].Value + "";  //Truong129
                        wrksheet.Cells[h, 122] = dataGridView1[123, i].Value + "";  //Truong130
                        wrksheet.Cells[h, 123] = dataGridView1[124, i].Value + "";  //Truong131
                        wrksheet.Cells[h, 124] = dataGridView1[125, i].Value + "";  //Truong132
                        wrksheet.Cells[h, 125] = dataGridView1[126, i].Value + "";  //Truong133
                        wrksheet.Cells[h, 126] = dataGridView1[127, i].Value + "";  //Truong134
                        wrksheet.Cells[h, 127] = dataGridView1[128, i].Value + "";  //Truong135
                        wrksheet.Cells[h, 128] = dataGridView1[129, i].Value + "";  //Truong136
                        wrksheet.Cells[h, 129] = dataGridView1[130, i].Value + "";  //Truong137
                        wrksheet.Cells[h, 130] = dataGridView1[131, i].Value + "";  //Truong138
                        wrksheet.Cells[h, 131] = dataGridView1[132, i].Value + "";  //Truong139
                        wrksheet.Cells[h, 132] = dataGridView1[133, i].Value + "";  //Truong140
                        wrksheet.Cells[h, 133] = dataGridView1[134, i].Value + "";  //Truong141
                        wrksheet.Cells[h, 134] = dataGridView1[135, i].Value + "";  //Truong142
                        wrksheet.Cells[h, 135] = dataGridView1[136, i].Value + "";  //Truong143
                        wrksheet.Cells[h, 136] = dataGridView1[137, i].Value + "";  //Truong144
                        wrksheet.Cells[h, 137] = dataGridView1[138, i].Value + "";  //Truong145
                        wrksheet.Cells[h, 138] = dataGridView1[139, i].Value + "";  //Truong146
                        wrksheet.Cells[h, 139] = dataGridView1[140, i].Value + "";  //Truong147
                        wrksheet.Cells[h, 140] = dataGridView1[141, i].Value + "";  //Truong148
                        wrksheet.Cells[h, 141] = dataGridView1[142, i].Value + "";  //Truong149
                        wrksheet.Cells[h, 142] = dataGridView1[143, i].Value + "";  //Truong150
                        wrksheet.Cells[h, 143] = dataGridView1[144, i].Value + "";  //Truong151
                        wrksheet.Cells[h, 144] = dataGridView1[145, i].Value + "";  //Truong152
                        wrksheet.Cells[h, 145] = dataGridView1[146, i].Value + "";  //Truong153
                        wrksheet.Cells[h, 146] = dataGridView1[147, i].Value + "";  //Truong154
                        wrksheet.Cells[h, 147] = dataGridView1[148, i].Value + "";  //Truong155
                        wrksheet.Cells[h, 148] = dataGridView1[149, i].Value + "";  //Truong156
                        wrksheet.Cells[h, 149] = dataGridView1[150, i].Value + "";  //Batch
                        wrksheet.Cells[h, 150] = dataGridView1[151, i].Value + "";  //STT
                        lb_Complete.Text = (i + 1) + "/" + dataGridView1.RowCount;
                        progressBar1.PerformStep();
                        h++;
                    }
                    Microsoft.Office.Interop.Excel.Range rowHead = wrksheet.get_Range("A1", "ET" + (h - 1));
                    rowHead.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;
                }
            }
            else
            {
                n = 1;
                int SoPhieuLoai1 = 0;
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    if (dataGridView1[1, i].Value + "" == "Loai1")
                    {
                        SoPhieuLoai1 += 1;
                        if (SoPhieuLoai1 >= 3)
                        {
                            if (i + 1 < dataGridView1.RowCount)
                            {
                                if (dataGridView1[1, i + 1].Value + "" != "Loai1")
                                {
                                    n += 1;
                                    WriteExcel(n, dataGridView1[11, i].Value + "-" + dataGridView1[12, i].Value + "-" + dataGridView1[13, i].Value + "", "", "総括表", "３枚連続発生");
                                }
                            }
                            else
                            {
                                n += 1;
                                WriteExcel(n, dataGridView1[11, i].Value + "-" + dataGridView1[12, i].Value + "-" + dataGridView1[13, i].Value + "", "", "総括表", "３枚連続発生");
                            }
                        }
                        if ((dataGridView1[22, i].Value + "").Length > 8)
                        {
                            n += 1;
                            WriteExcel(n, dataGridView1[11, i].Value + "-" + dataGridView1[12, i].Value + "-" + dataGridView1[13, i].Value + "", "21", "報告人員_在職", "桁オーバーの為＂99999999”で入力");
                        }
                        if (((dataGridView1[23, i].Value + "").Length > 8))
                        {
                            n += 1;
                            WriteExcel(n, dataGridView1[11, i].Value + "-" + dataGridView1[12, i].Value + "-" + dataGridView1[13, i].Value + "", "22", "報告人員_退職", "桁オーバーの為＂99999999”で入力");
                        }
                        if (((dataGridView1[24, i].Value + "").Length > 8))
                        {
                            n += 1;
                            WriteExcel(n, dataGridView1[11, i].Value + "-" + dataGridView1[12, i].Value + "-" + dataGridView1[13, i].Value + "", "23", "報告人員_その他", "桁オーバーの為＂99999999”で入力");
                        }
                        if (((dataGridView1[25, i].Value + "").Length > 8))
                        {
                            n += 1;
                            WriteExcel(n, dataGridView1[11, i].Value + "-" + dataGridView1[12, i].Value + "-" + dataGridView1[13, i].Value + "", "24", "報告人員_合計", "桁オーバーの為＂99999999”で入力");
                        }
                        if (!string.IsNullOrEmpty(dataGridView1[26, i].Value + "") && (dataGridView1[26, i].Value + "").Length < 12)
                        {
                            n += 1;
                            WriteExcel(n, dataGridView1[11, i].Value + "-" + dataGridView1[12, i].Value + "-" + dataGridView1[13, i].Value + "", "25", "個人番号又は法人番号", "“" + dataGridView1[26, i].Value + "”で入力");
                        }
                        if (((dataGridView1[27, i].Value + "").Length > 8))
                        {
                            n += 1;
                            WriteExcel(n, dataGridView1[11, i].Value + "-" + dataGridView1[12, i].Value + "-" + dataGridView1[13, i].Value + "", "26", "報告人員_特徴", "桁オーバーの為＂99999999”で入力");
                        }
                        if (((dataGridView1[28, i].Value + "").Length > 8))
                        {
                            n += 1;
                            WriteExcel(n, dataGridView1[11, i].Value + "-" + dataGridView1[12, i].Value + "-" + dataGridView1[13, i].Value + "", "27", "報告人員_普徴", "桁オーバーの為＂99999999”で入力");
                        }

                    }
                    else if (dataGridView1[1, i].Value + "" == "Loai2")
                    {
                        SoPhieuLoai1 = 0;
                    }
                    else if (dataGridView1[1, i].Value + "" == "Loai3")
                    {
                        SoPhieuLoai1 = 0;
                        //Kiểm tra quá ký tự hoặc chứa dấu ? của tất cả các trường loại 3
                        KiemTraQuaKyTu(2, i, 1, "市区町村CD", 6);
                        KiemTraQuaKyTu(3, i, 2, "送付票_年度", 4);
                        KiemTraQuaKyTu(4, i, 3, "送付票_簿冊番号", 5);
                        KiemTraQuaKyTu(5, i, 4, "送付票_入力回", 5);
                        KiemTraQuaKyTu(6, i, 5, "送付票_開始", 6);
                        KiemTraQuaKyTu(7, i, 6, "送付票_終了", 6);
                        KiemTraQuaKyTu(8, i, 7, "送付票_資料区分", 2);
                        KiemTraQuaKyTu(9, i, 8, "レコード区分", 1);
                        KiemTraQuaKyTu(10, i, 9, "資料番号_年度", 4);
                        KiemTraQuaKyTu(11, i, 10, "資料番号_簿冊番号", 5);
                        KiemTraQuaKyTu(12, i, 11, "資料番号_入力回", 5);
                        KiemTraQuaKyTu(13, i, 12, "資料番号_番号", 6);
                        //KiemTraQuaKyTu(14, i, 13, "余白", 8);
                        KiemTraQuaKyTu(15, i, 14, "指定番号", 12);
                        KiemTraQuaKyTu(16, i, 15, "受給者番号", 30);
                        KiemTraQuaKyTu(17, i, 16, "カナ氏名", 50);
                        KiemTraQuaKyTu(18, i, 17, "給与収入", 12);
                        KiemTraQuaKyTu(19, i, 18, "給与所得", 12);
                        KiemTraQuaKyTu(20, i, 19, "所得控除合計額", 12);
                        KiemTraQuaKyTu(21, i, 20, "源泉徴収税額", 12);
                        KiemTraQuaKyTu(22, i, 21, "控配_有", 1);
                        //KiemTraQuaKyTu(23, i, 22, "控配_無", 1);
                        KiemTraQuaKyTu(24, i, 23, "控配_老人", 1);
                        KiemTraQuaKyTu(25, i, 24, "配偶者特別控除", 12);
                        KiemTraQuaKyTu(26, i, 25, "扶養_特定扶養", 2);
                        KiemTraQuaKyTu(27, i, 26, "扶養_同居老人", 2);
                        KiemTraQuaKyTu(28, i, 27, "扶養_老人扶養", 2);
                        KiemTraQuaKyTu(29, i, 28, "扶養_その他扶養", 2);
                        //KiemTraQuaKyTu(30, i, 29, "余白", 2);
                        KiemTraQuaKyTu(31, i, 30, "障害_同居特障", 2);
                        KiemTraQuaKyTu(32, i, 31, "障害_特別障害", 2);
                        KiemTraQuaKyTu(33, i, 32, "障害_普通障害", 2);
                        KiemTraQuaKyTu(34, i, 33, "小規模企業共済等", 12);
                        KiemTraQuaKyTu(35, i, 34, "社会保険料控除額", 12);
                        KiemTraQuaKyTu(36, i, 35, "生命保険料控除額", 12);
                        KiemTraQuaKyTu(37, i, 36, "損害保険料控除額", 12);
                        KiemTraQuaKyTu(38, i, 37, "住宅取得等控除額", 12);
                        KiemTraQuaKyTu(39, i, 38, "配偶者の合計所得", 12);
                        KiemTraQuaKyTu(40, i, 39, "個人年金保険料", 12);
                        KiemTraQuaKyTu(41, i, 40, "長期損害保険料", 12);
                        KiemTraQuaKyTu(42, i, 41, "扶養_年少扶養", 2);
                        //KiemTraQuaKyTu(43, i, 42, "夫あり", 1);
                        //KiemTraQuaKyTu(44, i, 43, "未成年者", 1);
                        KiemTraQuaKyTu(45, i, 44, "乙欄区分", 1);
                        KiemTraQuaKyTu(46, i, 45, "本人特別障害", 1);
                        KiemTraQuaKyTu(47, i, 46, "本人普通障害", 1);
                        //KiemTraQuaKyTu(48, i, 47, "老年者", 1);
                        KiemTraQuaKyTu(49, i, 48, "寡婦", 1);
                        KiemTraQuaKyTu(50, i, 49, "特別寡婦", 1);
                        KiemTraQuaKyTu(51, i, 50, "寡夫", 1);
                        KiemTraQuaKyTu(52, i, 51, "勤労学生", 1);
                        KiemTraQuaKyTu(53, i, 52, "死亡退職", 1);
                        //KiemTraQuaKyTu(54, i, 53, "災害者", 1);
                        //KiemTraQuaKyTu(55, i, 54, "外国人", 1);
                        KiemTraQuaKyTu(56, i, 55, "中途就退_就職", 1);
                        KiemTraQuaKyTu(57, i, 56, "中途就退_退職", 1);
                        KiemTraQuaKyTuKhongDauChamHoi(58, i, 57, "中途就退年月日_年号", 1);
                        KiemTraQuaKyTuKhongDauChamHoi(59, i, 58, "中途就退年月日_年", 2);
                        KiemTraQuaKyTuKhongDauChamHoi(60, i, 59, "中途就退年月日_月", 2);
                        KiemTraQuaKyTuKhongDauChamHoi(61, i, 60, "中途就退年月日_日", 2);
                        //KiemTraQuaKyTu(62, i, , "", );Flag60
                        KiemTraQuaKyTu(63, i, 61, "生年月日_年号", 1);
                        KiemTraQuaKyTu(64, i, 62, "生年月日_年", 2);
                        KiemTraQuaKyTu(65, i, 63, "生年月日_月", 2);
                        KiemTraQuaKyTu(66, i, 64, "生年月日_日", 2);
                        KiemTraQuaKyTu(67, i, 65, "年調済区分", 1);
                        KiemTraQuaKyTu(68, i, 66, "普徴区分", 1);
                        KiemTraQuaKyTu(69, i, 67, "前職分給与収入", 12);
                        KiemTraQuaKyTu(70, i, 68, "前職有区分", 1);
                        //KiemTraQuaKyTu(71, i, 69, "訂正分給報区分", 1);
                        //KiemTraQuaKyTu(72, i, 70, "非合算区分", 1);
                        //KiemTraQuaKyTu(73, i, 71, "強制均等割課税区分", 1);
                        //KiemTraQuaKyTu(74, i, 72, "租税条約区分", 1);
                        KiemTraQuaKyTu(75, i, 73, "宛名番号", 15);
                        KiemTraQuaKyTu(76, i, 74, "住宅借入特控家屋居住年1", 2);
                        KiemTraQuaKyTu(77, i, 75, "住宅借入特控家屋居住月1", 2);
                        KiemTraQuaKyTu(78, i, 76, "住宅借入特控家屋居住日1", 2);
                        KiemTraQuaKyTu(79, i, 77, "住宅借入特控適用数", 1);
                        KiemTraQuaKyTu(80, i, 78, "住宅借入特控可能額", 12);
                        KiemTraQuaKyTu(81, i, 79, "住宅借入特控区分1", 2);
                        //KiemTraQuaKyTu(82, i, 80, "住宅借入金等の額1", 12);
                        KiemTraQuaKyTu(83, i, 81, "住宅借入特控家屋居住年2", 2);
                        KiemTraQuaKyTu(84, i, 82, "住宅借入特控家屋居住月2", 2);
                        KiemTraQuaKyTu(85, i, 83, "住宅借入特控家屋居住日2", 2);
                        KiemTraQuaKyTu(86, i, 84, "住宅借入特控区分2", 2);
                        //KiemTraQuaKyTu(87, i, 85, "住宅借入金等の額2", 12);
                        KiemTraQuaKyTu(88, i, 86, "新生命保険料", 12);
                        KiemTraQuaKyTu(89, i, 87, "旧生命保険料", 12);
                        KiemTraQuaKyTu(90, i, 88, "介護医療保険料", 12);
                        KiemTraQuaKyTu(91, i, 89, "新個人年金保険料", 12);
                        KiemTraQuaKyTu(92, i, 90, "個人番号", 12);
                        //KiemTraQuaKyTu(93, i, 91, "摘要", 130);
                        //KiemTraQuaKyTu(94, i, 92, "控除対象配偶者_カナ氏名", 60);
                        //KiemTraQuaKyTu(95, i, 93, "控除対象配偶者_個人番号", 12);
                        KiemTraQuaKyTu(96, i, 94, "扶養1_カナ氏名", 60);
                        KiemTraQuaKyTu(97, i, 95, "扶養1_個人番号", 12);
                        KiemTraQuaKyTu(98, i, 96, "扶養2_カナ氏名", 60);
                        KiemTraQuaKyTu(99, i, 97, "扶養2_個人番号", 12);
                        KiemTraQuaKyTu(100, i, 98, "扶養3_カナ氏名", 60);
                        KiemTraQuaKyTu(101, i, 99, "扶養3_個人番号", 12);
                        KiemTraQuaKyTu(102, i, 100, "扶養4_カナ氏名", 60);
                        KiemTraQuaKyTu(103, i, 101, "扶養4_個人番号", 12);
                        KiemTraQuaKyTu(104, i, 102, "年少扶養1_カナ氏名", 60);
                        KiemTraQuaKyTu(105, i, 103, "年少扶養1_個人番号", 12);
                        KiemTraQuaKyTu(106, i, 104, "年少扶養2_カナ氏名", 60);
                        KiemTraQuaKyTu(107, i, 105, "年少扶養2_個人番号", 12);
                        KiemTraQuaKyTu(108, i, 106, "年少扶養3_カナ氏名", 60);
                        KiemTraQuaKyTu(109, i, 107, "年少扶養3_個人番号", 12);
                        KiemTraQuaKyTu(110, i, 108, "年少扶養4_カナ氏名", 60);
                        KiemTraQuaKyTu(111, i, 109, "年少扶養4_個人番号", 12);
                        KiemTraQuaKyTu(112, i, 110, "扶養5以降_個人番号", 12);
                        KiemTraQuaKyTu(113, i, 111, "年少扶養5以降_個人番号", 12);
                        //KiemTraQuaKyTu(114, i, 112, "余白", 14);

                        //Có nhiều thông tin trong 1 ô
                        if (dataGridView1[62, i].Value + "" == "1")
                        {
                            n += 1;
                            WriteExcel(n, dataGridView1[11, i].Value + "-" + dataGridView1[12, i].Value + "-" + dataGridView1[13, i].Value + "", "57_60", "中途就退年月日_年号～日", "複数記入　“" + dataGridView1[58, i].Value + "" + dataGridView1[59, i].Value + "" + dataGridView1[60, i].Value + "" + dataGridView1[61, i].Value + "" + "”で入力");
                        }

                        //Trường tiền âm
                        KiemTraTruongTienAm(dataGridView1[18, i].Value + "", i, 17, "給与収入");
                        KiemTraTruongTienAm(dataGridView1[19, i].Value + "", i, 18, "給与所得");
                        KiemTraTruongTienAm(dataGridView1[20, i].Value + "", i, 19, "所得控除合計額");
                        KiemTraTruongTienAm(dataGridView1[21, i].Value + "", i, 20, "源泉徴収税額");
                        KiemTraTruongTienAm(dataGridView1[25, i].Value + "", i, 24, "配偶者特別控除");
                        KiemTraTruongTienAm(dataGridView1[34, i].Value + "", i, 33, "小規模企業共済等");
                        KiemTraTruongTienAm(dataGridView1[35, i].Value + "", i, 34, "社会保険料控除額");
                        KiemTraTruongTienAm(dataGridView1[36, i].Value + "", i, 35, "生命保険料控除額");
                        KiemTraTruongTienAm(dataGridView1[37, i].Value + "", i, 36, "損害保険料控除額");
                        KiemTraTruongTienAm(dataGridView1[38, i].Value + "", i, 37, "住宅取得等控除額");
                        KiemTraTruongTienAm(dataGridView1[39, i].Value + "", i, 38, "配偶者の合計所得");
                        KiemTraTruongTienAm(dataGridView1[40, i].Value + "", i, 39, "個人年金保険料");
                        KiemTraTruongTienAm(dataGridView1[41, i].Value + "", i, 40, "長期損害保険料");
                        KiemTraTruongTienAm(dataGridView1[69, i].Value + "", i, 67, "前職分給与収入");
                        KiemTraTruongTienAm(dataGridView1[80, i].Value + "", i, 78, "住宅借入特控可能額");
                        KiemTraTruongTienAm(dataGridView1[88, i].Value + "", i, 86, "新生命保険料");
                        KiemTraTruongTienAm(dataGridView1[89, i].Value + "", i, 87, "旧生命保険料");
                        KiemTraTruongTienAm(dataGridView1[90, i].Value + "", i, 88, "介護医療保険料");
                        KiemTraTruongTienAm(dataGridView1[91, i].Value + "", i, 89, "新個人年金保険料");

                        //Chi Tiết Loại 3
                        if (!string.IsNullOrEmpty(dataGridView1[71, i].Value + "") && (dataGridView1[71, i].Value + "") != "3")
                        {
                            n += 1;
                            WriteExcel(n, dataGridView1[11, i].Value + "-" + dataGridView1[12, i].Value + "-" + dataGridView1[13, i].Value + "", "69", "訂正分給報区分", "不明の為入力せず");
                        }
                        if (!string.IsNullOrEmpty(dataGridView1[74, i].Value + "") && (dataGridView1[74, i].Value + "") != "5")
                        {
                            n += 1;
                            WriteExcel(n, dataGridView1[11, i].Value + "-" + dataGridView1[12, i].Value + "-" + dataGridView1[13, i].Value + "", "72", "租税条約区分", "不明の為入力せず");
                        }
                        if (!string.IsNullOrEmpty(dataGridView1[92, i].Value + "") && (dataGridView1[92, i].Value + "").Length < 12)
                        {
                            n += 1;
                            WriteExcel(n, dataGridView1[11, i].Value + "-" + dataGridView1[12, i].Value + "-" + dataGridView1[13, i].Value + "", "90", "個人番号", "桁不足　“" + dataGridView1[92, i].Value + "”で入力");
                        }
                        if (!string.IsNullOrEmpty(dataGridView1[97, i].Value + "") && (dataGridView1[97, i].Value + "").Length < 12)
                        {
                            n += 1;
                            WriteExcel(n, dataGridView1[11, i].Value + "-" + dataGridView1[12, i].Value + "-" + dataGridView1[13, i].Value + "", "95", "扶養1_個人番号", "桁不足　“" + (dataGridView1[97, i].Value + "") + "”で入力");
                        }
                        if (!string.IsNullOrEmpty(dataGridView1[99, i].Value + "") && (dataGridView1[99, i].Value + "").Length < 12)
                        {
                            n += 1;
                            WriteExcel(n, dataGridView1[11, i].Value + "-" + dataGridView1[12, i].Value + "-" + dataGridView1[13, i].Value + "", "97", "扶養2_個人番号", "桁不足　“" + (dataGridView1[99, i].Value + "") + "”で入力");
                        }
                        if (!string.IsNullOrEmpty(dataGridView1[101, i].Value + "") && (dataGridView1[101, i].Value + "").Length < 12)
                        {
                            n += 1;
                            WriteExcel(n, dataGridView1[11, i].Value + "-" + dataGridView1[12, i].Value + "-" + dataGridView1[13, i].Value + "", "99", "扶養3_個人番号", "桁不足　“" + (dataGridView1[101, i].Value + "") + "”で入力");
                        }
                        if (!string.IsNullOrEmpty(dataGridView1[103, i].Value + "") && (dataGridView1[103, i].Value + "").Length < 12)
                        {
                            n += 1;
                            WriteExcel(n, dataGridView1[11, i].Value + "-" + dataGridView1[12, i].Value + "-" + dataGridView1[13, i].Value + "", "101", "扶養4_個人番号", "桁不足　“" + (dataGridView1[103, i].Value + "") + "”で入力");
                        }
                        if (!string.IsNullOrEmpty(dataGridView1[105, i].Value + "") && (dataGridView1[105, i].Value + "").Length < 12)
                        {
                            n += 1;
                            WriteExcel(n, dataGridView1[11, i].Value + "-" + dataGridView1[12, i].Value + "-" + dataGridView1[13, i].Value + "", "103", "年少扶養1_個人番号", "桁不足　“" + (dataGridView1[105, i].Value + "") + "”で入力");
                        }
                        if (!string.IsNullOrEmpty(dataGridView1[107, i].Value + "") && (dataGridView1[107, i].Value + "").Length < 12)
                        {
                            n += 1;
                            WriteExcel(n, dataGridView1[11, i].Value + "-" + dataGridView1[12, i].Value + "-" + dataGridView1[13, i].Value + "", "105", "年少扶養2_個人番号", "桁不足　“" + (dataGridView1[107, i].Value + "") + "”で入力");
                        }
                        if (!string.IsNullOrEmpty(dataGridView1[109, i].Value + "") && (dataGridView1[109, i].Value + "").Length < 12)
                        {
                            n += 1;
                            WriteExcel(n, dataGridView1[11, i].Value + "-" + dataGridView1[12, i].Value + "-" + dataGridView1[13, i].Value + "", "107", "年少扶養3_個人番号", "桁不足　“" + (dataGridView1[109, i].Value + "") + "”で入力");
                        }
                        if (!string.IsNullOrEmpty(dataGridView1[111, i].Value + "") && (dataGridView1[111, i].Value + "").Length < 12)
                        {
                            n += 1;
                            WriteExcel(n, dataGridView1[11, i].Value + "-" + dataGridView1[12, i].Value + "-" + dataGridView1[13, i].Value + "", "109", "年少扶養4_個人番号", "桁不足　“" + (dataGridView1[111, i].Value + "") + "”で入力");
                        }
                        if (!string.IsNullOrEmpty(dataGridView1[112, i].Value + "") && (dataGridView1[112, i].Value + "").Length < 12)
                        {
                            n += 1;
                            WriteExcel(n, dataGridView1[11, i].Value + "-" + dataGridView1[12, i].Value + "-" + dataGridView1[13, i].Value + "", "110", "扶養5以降_個人番号", "桁不足　“" + (dataGridView1[112, i].Value + "") + "”で入力");
                        }
                        if (!string.IsNullOrEmpty(dataGridView1[113, i].Value + "") && (dataGridView1[113, i].Value + "").Length < 12)
                        {
                            n += 1;
                            WriteExcel(n, dataGridView1[11, i].Value + "-" + dataGridView1[12, i].Value + "-" + dataGridView1[13, i].Value + "", "111", "年少扶養5以降_個人番号", "桁不足　“" + (dataGridView1[113, i].Value + "") + "”で入力");
                        }
                        //if (string.IsNullOrEmpty(dataGridView1[59, i].Value + "") &&
                        //    string.IsNullOrEmpty(dataGridView1[60, i].Value + "") &&
                        //    string.IsNullOrEmpty(dataGridView1[61, i].Value + "") &&
                        //    string.IsNullOrEmpty(dataGridView1[56, i].Value + "") &&
                        //    string.IsNullOrEmpty(dataGridView1[57, i].Value + ""))
                        //{
                        //    n += 1;
                        //    WriteExcel(n, dataGridView1[11, i].Value + "-" + dataGridView1[12, i].Value + "-" + dataGridView1[13, i].Value + "", "57_60", "中途就退年月日_年号～日", "“ 000000”で入力");
                        //}
                        //else 
                        if ((dataGridView1[59, i].Value + "").IndexOf("?") >= 0 &&
                            (dataGridView1[60, i].Value + "").IndexOf("?") >= 0 &&
                            (dataGridView1[61, i].Value + "").IndexOf("?") >= 0)
                        {
                            n += 1;
                            WriteExcel(n, dataGridView1[11, i].Value + "-" + dataGridView1[12, i].Value + "-" + dataGridView1[13, i].Value + "", "57_60", "中途就退年月日_年号～日", "“4000000”で入力");
                        }
                        else if ((dataGridView1[59, i].Value + "").IndexOf("?") >= 0 ||
                           (dataGridView1[60, i].Value + "").IndexOf("?") >= 0 ||
                           (dataGridView1[61, i].Value + "").IndexOf("?") >= 0)
                        {
                            if ((dataGridView1[59, i].Value + "").IndexOf("?") >= 0)
                            {
                                n += 1;
                                WriteExcel(n, dataGridView1[11, i].Value + "-" + dataGridView1[12, i].Value + "-" + dataGridView1[13, i].Value + "", "57_60", "中途就退年月日_年号～日", "“400"+ dataGridView1[60, i].Value + "" + dataGridView1[61, i].Value + "" + "”で入力");
                            }
                            else if ((dataGridView1[60, i].Value + "").IndexOf("?") >= 0)
                            {
                                n += 1;
                                WriteExcel(n, dataGridView1[11, i].Value + "-" + dataGridView1[12, i].Value + "-" + dataGridView1[13, i].Value + "", "57_60", "中途就退年月日_年号～日", "“4" + dataGridView1[59, i].Value + "00" + dataGridView1[61, i].Value + "" + "”で入力");
                            }
                            else if ((dataGridView1[61, i].Value + "").IndexOf("?") >= 0)
                            {
                                n += 1;
                                WriteExcel(n, dataGridView1[11, i].Value + "-" + dataGridView1[12, i].Value + "-" + dataGridView1[13, i].Value + "", "57_60", "中途就退年月日_年号～日", "“4" + dataGridView1[59, i].Value + "" + dataGridView1[60, i].Value + "00" + "”で入力");
                            }
                        }
                        else if ((string.IsNullOrEmpty(dataGridView1[59, i].Value + "")) || (string.IsNullOrEmpty(dataGridView1[60, i].Value + ""))|| (string.IsNullOrEmpty(dataGridView1[61, i].Value + "")))
                        {
                            if (dataGridView1[56, i].Value + "" == "1")
                            {
                                n += 1;
                                WriteExcel(n, dataGridView1[11, i].Value + "-" + dataGridView1[12, i].Value + "-" + dataGridView1[13, i].Value + "", "57_60", "中途就退年月日_年号～日", "“4290101”で入力");
                            }
                            else if (dataGridView1[57, i].Value + "" == "1" || (dataGridView1[57, i].Value + "" == "1" && dataGridView1[56, i].Value + "" == "1"))
                            {
                                n += 1;
                                WriteExcel(n, dataGridView1[11, i].Value + "-" + dataGridView1[12, i].Value + "-" + dataGridView1[13, i].Value + "", "57_60", "中途就退年月日_年号～日", "“4291231”で入力");
                            }
                            else if (string.IsNullOrEmpty(dataGridView1[56, i].Value + "" + dataGridView1[57, i].Value + "") || (dataGridView1[56, i].Value + "" + dataGridView1[57, i].Value + "").IndexOf("?") >= 0)
                            {
                                n += 1;
                                WriteExcel(n, dataGridView1[11, i].Value + "-" + dataGridView1[12, i].Value + "-" + dataGridView1[13, i].Value + "", "57_60", "中途就退年月日_年号～日", "“ 000000”で入力");
                            }
                        }
                    }
                    //wrksheet.Cells[h, 1] = dataGridView1[0, i].Value + "";  //Trường 01/ Tên hình
                    //wrksheet.Cells[h, 2] = dataGridView1[1, i].Value + "";  //LoaiPhieu
                    //wrksheet.Cells[h, 3] = dataGridView1[2, i].Value + "";  //Truong001
                    //wrksheet.Cells[h, 4] = dataGridView1[3, i].Value + "";  //Truong002
                    //wrksheet.Cells[h, 5] = dataGridView1[4, i].Value + "";  //Truong003
                    //wrksheet.Cells[h, 6] = dataGridView1[5, i].Value + "";  //Truong004
                    //wrksheet.Cells[h, 7] = dataGridView1[6, i].Value + "";  //Truong005
                    //wrksheet.Cells[h, 8] = dataGridView1[7, i].Value + "";  //Truong006
                    //wrksheet.Cells[h, 9] = dataGridView1[8, i].Value + "";  //Truong007
                    //wrksheet.Cells[h, 10] = dataGridView1[9, i].Value + "";  //Truong008
                    //wrksheet.Cells[h, 11] = dataGridView1[10, i].Value + "";  //Truong009
                    //wrksheet.Cells[h, 12] = dataGridView1[11, i].Value + "";  //Truong010
                    //wrksheet.Cells[h, 13] = dataGridView1[12, i].Value + "";  //Truong011
                    //wrksheet.Cells[h, 14] = dataGridView1[13, i].Value + "";  //Truong012
                    //wrksheet.Cells[h, 15] = dataGridView1[14, i].Value + "";  //Truong013
                    //wrksheet.Cells[h, 16] = dataGridView1[15, i].Value + "";  //Truong014
                    //wrksheet.Cells[h, 17] = dataGridView1[16, i].Value + "";    //Truong015
                    //wrksheet.Cells[h, 18] = dataGridView1[17, i].Value + "";    //Truong016
                    //wrksheet.Cells[h, 19] = dataGridView1[18, i].Value + "";    //Truong017
                    //wrksheet.Cells[h, 20] = dataGridView1[19, i].Value + "";    //Truong018
                    //wrksheet.Cells[h, 21] = dataGridView1[20, i].Value + "";    //Truong019
                    //wrksheet.Cells[h, 22] = dataGridView1[21, i].Value + "";    //Truong020
                    //wrksheet.Cells[h, 23] = dataGridView1[22, i].Value + "";    //Truong021
                    //wrksheet.Cells[h, 24] = dataGridView1[23, i].Value + "";    //Truong022
                    //wrksheet.Cells[h, 25] = dataGridView1[24, i].Value + "";    //Truong023
                    //wrksheet.Cells[h, 26] = dataGridView1[25, i].Value + "";    //Truong024
                    //wrksheet.Cells[h, 27] = dataGridView1[26, i].Value + "";    //Truong025
                    //wrksheet.Cells[h, 28] = dataGridView1[27, i].Value + "";    //Truong026
                    //wrksheet.Cells[h, 29] = dataGridView1[28, i].Value + "";    //Truong027
                    //wrksheet.Cells[h, 30] = dataGridView1[29, i].Value + "";    //Truong028
                    //wrksheet.Cells[h, 31] = dataGridView1[30, i].Value + "";    //Truong029
                    //wrksheet.Cells[h, 32] = dataGridView1[31, i].Value + "";    //Truong030
                    //wrksheet.Cells[h, 33] = dataGridView1[32, i].Value + "";    //Truong031
                    //wrksheet.Cells[h, 34] = dataGridView1[33, i].Value + "";    //Truong032
                    //wrksheet.Cells[h, 35] = dataGridView1[34, i].Value + "";    //Truong033
                    //wrksheet.Cells[h, 36] = dataGridView1[35, i].Value + "";    //Truong034
                    //wrksheet.Cells[h, 37] = dataGridView1[36, i].Value + "";    //Truong035
                    //wrksheet.Cells[h, 38] = dataGridView1[37, i].Value + "";    //Truong036
                    //wrksheet.Cells[h, 39] = dataGridView1[38, i].Value + "";    //Truong037
                    //wrksheet.Cells[h, 40] = dataGridView1[39, i].Value + "";    //Truong038
                    //wrksheet.Cells[h, 41] = dataGridView1[40, i].Value + "";    //Truong039
                    //wrksheet.Cells[h, 42] = dataGridView1[41, i].Value + "";    //Truong040
                    //wrksheet.Cells[h, 43] = dataGridView1[42, i].Value + "";    //Truong041
                    //wrksheet.Cells[h, 44] = dataGridView1[43, i].Value + "";    //Truong042
                    //wrksheet.Cells[h, 45] = dataGridView1[44, i].Value + "";    //Truong043
                    //wrksheet.Cells[h, 46] = dataGridView1[45, i].Value + "";    //Truong044
                    //wrksheet.Cells[h, 47] = dataGridView1[46, i].Value + "";    //Truong045
                    //wrksheet.Cells[h, 48] = dataGridView1[47, i].Value + "";    //Truong046
                    //wrksheet.Cells[h, 49] = dataGridView1[48, i].Value + "";    //Truong047
                    //wrksheet.Cells[h, 50] = dataGridView1[49, i].Value + "";    //Truong048
                    //wrksheet.Cells[h, 51] = dataGridView1[50, i].Value + "";    //Truong049
                    //wrksheet.Cells[h, 52] = dataGridView1[51, i].Value + "";    //Truong050
                    //wrksheet.Cells[h, 53] = dataGridView1[52, i].Value + "";    //Truong051
                    //wrksheet.Cells[h, 54] = dataGridView1[53, i].Value + "";    //Truong052
                    //wrksheet.Cells[h, 55] = dataGridView1[54, i].Value + "";    //Truong053
                    //wrksheet.Cells[h, 56] = dataGridView1[55, i].Value + "";    //Truong054
                    //wrksheet.Cells[h, 57] = dataGridView1[56, i].Value + "";    //Truong055
                    //wrksheet.Cells[h, 58] = dataGridView1[57, i].Value + "";    //Truong056
                    //wrksheet.Cells[h, 59] = dataGridView1[58, i].Value + "";    //Truong057
                    //wrksheet.Cells[h, 60] = dataGridView1[59, i].Value + "";    //Truong058
                    //wrksheet.Cells[h, 61] = dataGridView1[60, i].Value + "";    //Truong059
                    //wrksheet.Cells[h, 62] = dataGridView1[61, i].Value + "";    //Truong060
                    //wrksheet.Cells[h, 63] = dataGridView1[62, i].Value + "";    //FlagTruong_60
                    //wrksheet.Cells[h, 64] = dataGridView1[63, i].Value + "";    //Truong061
                    //wrksheet.Cells[h, 65] = dataGridView1[64, i].Value + "";    //Truong062
                    //wrksheet.Cells[h, 66] = dataGridView1[65, i].Value + "";    //Truong063
                    //wrksheet.Cells[h, 67] = dataGridView1[66, i].Value + "";    //Truong064
                    //wrksheet.Cells[h, 68] = dataGridView1[67, i].Value + "";    //Truong065
                    //wrksheet.Cells[h, 69] = Truong66;                           //Truong066
                    //wrksheet.Cells[h, 70] = dataGridView1[69, i].Value + "";    //Truong067
                    //wrksheet.Cells[h, 71] = dataGridView1[70, i].Value + "";    //Truong068
                    //wrksheet.Cells[h, 72] = dataGridView1[71, i].Value + "";    //Truong069
                    //wrksheet.Cells[h, 73] = dataGridView1[72, i].Value + "";    //Truong070
                    //wrksheet.Cells[h, 74] = dataGridView1[73, i].Value + "";    //Truong071
                    //wrksheet.Cells[h, 75] = dataGridView1[74, i].Value + "";    //Truong072
                    //wrksheet.Cells[h, 76] = dataGridView1[75, i].Value + "";    //Truong073
                    //wrksheet.Cells[h, 77] = dataGridView1[76, i].Value + "";    //Truong074
                    //wrksheet.Cells[h, 78] = dataGridView1[77, i].Value + "";    //Truong075
                    //wrksheet.Cells[h, 79] = dataGridView1[78, i].Value + "";    //Truong076
                    //wrksheet.Cells[h, 80] = dataGridView1[79, i].Value + "";    //Truong077
                    //wrksheet.Cells[h, 81] = dataGridView1[80, i].Value + "";    //Truong078
                    //wrksheet.Cells[h, 82] = dataGridView1[81, i].Value + "";    //Truong079
                    //wrksheet.Cells[h, 83] = dataGridView1[82, i].Value + "";    //Truong080
                    //wrksheet.Cells[h, 84] = dataGridView1[83, i].Value + "";    //Truong081
                    //wrksheet.Cells[h, 85] = dataGridView1[84, i].Value + "";    //Truong082
                    //wrksheet.Cells[h, 86] = dataGridView1[85, i].Value + "";    //Truong083
                    //wrksheet.Cells[h, 87] = dataGridView1[86, i].Value + "";    //Truong084
                    //wrksheet.Cells[h, 88] = dataGridView1[87, i].Value + "";    //Truong085
                    //wrksheet.Cells[h, 89] = dataGridView1[88, i].Value + "";    //Truong086
                    //wrksheet.Cells[h, 90] = dataGridView1[89, i].Value + "";    //Truong087
                    //wrksheet.Cells[h, 91] = dataGridView1[90, i].Value + "";    //Truong088
                    //wrksheet.Cells[h, 92] = dataGridView1[91, i].Value + "";    //Truong089
                    //wrksheet.Cells[h, 93] = dataGridView1[92, i].Value + "";    //Truong090
                    //wrksheet.Cells[h, 94] = dataGridView1[93, i].Value + "";    //Truong091
                    //wrksheet.Cells[h, 95] = dataGridView1[94, i].Value + "";    //Truong092
                    //wrksheet.Cells[h, 96] = dataGridView1[95, i].Value + "";    //Truong093
                    //wrksheet.Cells[h, 97] = dataGridView1[96, i].Value + "";    //Truong094
                    //wrksheet.Cells[h, 98] = dataGridView1[97, i].Value + "";    //Truong095
                    //wrksheet.Cells[h, 99] = dataGridView1[98, i].Value + "";    //Truong096
                    //wrksheet.Cells[h, 100] = dataGridView1[99, i].Value + "";    //Truong097
                    //wrksheet.Cells[h, 101] = dataGridView1[100, i].Value + "";    //Truong098
                    //wrksheet.Cells[h, 102] = dataGridView1[101, i].Value + "";    //Truong099
                    //wrksheet.Cells[h, 103] = dataGridView1[102, i].Value + "";    //Truong100
                    //wrksheet.Cells[h, 104] = dataGridView1[103, i].Value + "";    //Truong101
                    //wrksheet.Cells[h, 105] = dataGridView1[104, i].Value + "";    //Truong102
                    //wrksheet.Cells[h, 106] = dataGridView1[105, i].Value + "";    //Truong103
                    //wrksheet.Cells[h, 107] = dataGridView1[106, i].Value + "";    //Truong104
                    //wrksheet.Cells[h, 108] = dataGridView1[107, i].Value + "";    //Truong105
                    //wrksheet.Cells[h, 109] = dataGridView1[108, i].Value + "";    //Truong106
                    //wrksheet.Cells[h, 110] = dataGridView1[109, i].Value + "";    //Truong107
                    //wrksheet.Cells[h, 111] = dataGridView1[110, i].Value + "";    //Truong108
                    //wrksheet.Cells[h, 112] = dataGridView1[111, i].Value + "";    //Truong109
                    //wrksheet.Cells[h, 113] = dataGridView1[112, i].Value + "";    //Truong110
                    //wrksheet.Cells[h, 114] = dataGridView1[113, i].Value + "";    //Truong111
                    //wrksheet.Cells[h, 115] = "";   //Truong112
                    lb_Complete.Text = (i + 1) + "/" + dataGridView1.RowCount;
                    progressBar1.PerformStep();
                    h++;
                }
                Microsoft.Office.Interop.Excel.Range rowHead = wrksheet.get_Range("A1", "D" + n);
                rowHead.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;
            }
        }
        
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                string savePath = "";
                saveFileDialog1.Title = "Save Excel Files";
                saveFileDialog1.Filter = "Excel files (*.xlsx)|*.xlsx";
                saveFileDialog1.FileName = namefileExcel;
                saveFileDialog1.RestoreDirectory = true;
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    book.SaveCopyAs(saveFileDialog1.FileName);
                    book.Saved = true;
                    savePath = Path.GetDirectoryName(saveFileDialog1.FileName);
                }
                else
                {
                    MessageBox.Show(@"Error exporting excel!");
                    return;
                }
                Process.Start(savePath);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (book != null)
                    book.Close(false);
                if (App != null)
                    App.Quit();
                if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\ExportExcel.xlsx"))
                {
                    File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\ExportExcel.xlsx");
                }
                if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\ExportExcelCityN.xlsx"))
                {
                    File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\ExportExcelCityN.xlsx");
                }
                if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\ExportExcel_Error.xlsx"))
                {
                    File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\ExportExcel_Error.xlsx");
                }
            }
        }

        private void cbb_Batch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 3)
                e.Handled = true;
        }

        private void chk_Multiple_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_Multiple.Checked)
            {
                dgv.PageVisible = false;
                Batch.PageVisible = true;
                cbb_Batch.Enabled = false;
            }
            else
            {
                dgv.PageVisible = true;
                Batch.PageVisible = false;
                cbb_Batch.Enabled = true;
            }
        }

        private void txt_LoaiPhieu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (FlagLoad)
                return;
            list_Batch.DataSource = (from w in Global.Db.GetBatch(cbb_City.Text) select new MyEntry { BatchID = w.BatchID, BatchName = w.BatchName }).ToList();
            list_Batch.DisplayMember = "BatchName";
            list_Batch.ValueMember = "BatchID";
            cbb_Batch.DataSource = (from w in Global.Db.GetBatch(cbb_City.Text) select new { w.BatchID, w.BatchName }).ToList();
            cbb_Batch.DisplayMember = "BatchName";
            cbb_Batch.ValueMember = "BatchID";
        }

        private void cbb_City_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar != 3)
                e.Handled = true;
        }

        private void cbb_City_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete)
                ((ComboBox)sender).Text = "";
        }
    }
}