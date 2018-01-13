using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using System.Runtime.InteropServices;

namespace BaoCaoLuong2018.MyForm
{
    public partial class frm_NangSuat : DevExpress.XtraEditors.XtraForm
    {
        private DateTime firstDateTime;
        private DateTime lastDateTime;
        public frm_NangSuat()
        {
            InitializeComponent();
        }

        private void frm_NangSuat_Load(object sender, EventArgs e)
        {
            lb_SoLuong.Text = "";
            timeFisrt.EditValue = "00:00";
            timeEnd.EditValue = "23:59";
            string firstdate = dtp_FirstDay.Value.ToString("yyyy-MM-dd ") + timeFisrt.Text + ":00";//" 00:00:00";
            string lastdate = dtp_EndDay.Value.ToString("yyyy-MM-dd ") + timeEnd.Text + ":59";// " 23:59:59";

            cbb_City.Items.Clear();
            cbb_City.Items.Add(new { Text = "", Value = "" });
            cbb_City.Items.Add(new { Text = "CityN", Value = "CityN" });
            cbb_City.Items.Add(new { Text = "CityO", Value = "CityO" });
            //cbb_City.Items.Add(new { Text = "CityS", Value = "CityS" });
            cbb_City.DisplayMember = "Text";
            cbb_City.ValueMember = "Value";
            cbb_City.SelectedText = Global.StrCity;
            firstDateTime = DateTime.Parse(firstdate);
            lastDateTime = DateTime.Parse(lastdate);
            LoadDataGrid(firstDateTime, lastDateTime);
        }
        private void LoadDataGrid(DateTime TuNgay, DateTime DenNgay)
        {
            gridControl1.DataSource = null;
            gridControl2.DataSource = null;
            gridControl3.DataSource = null;
            gridControl4.DataSource = null;
            gridControl5.DataSource = null;
            gridControl6.DataSource = null;
            dataGridView1.DataSource = null;
            dataGridView2.DataSource = null;
            dataGridView3.DataSource = null;
            dataGridView4.DataSource = null;
            dataGridView5.DataSource = null;
            dataGridView6.DataSource = null;
            gridControl1.DataSource = dataGridView1.DataSource = Global.Db.NangSuatInput(TuNgay, DenNgay, "CityN", "Loai1");
            gridControl2.DataSource = dataGridView2.DataSource = Global.Db.NangSuatInput(TuNgay, DenNgay, "CityN", "Loai3");
            gridControl3.DataSource = dataGridView3.DataSource = Global.Db.NangSuatInput(TuNgay, DenNgay, "CityN", "LoaiJP");
            gridControl4.DataSource = dataGridView4.DataSource = Global.Db.NangSuatInput(TuNgay, DenNgay, "CityO", "Loai1");
            gridControl5.DataSource = dataGridView5.DataSource = Global.Db.NangSuatInput(TuNgay, DenNgay, "CityO", "Loai3");
            gridControl6.DataSource = dataGridView6.DataSource = Global.Db.NangSuatInput(TuNgay, DenNgay, "CityO", "LoaiJP");
        }
        private void GridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            GridView View = sender as GridView;
            //doi mau row chan
            if (e.RowHandle >= 0)
            {
                if (e.RowHandle % 2 == 0) e.Appearance.BackColor = Color.LavenderBlush;
                else
                {
                    e.Appearance.BackColor = Color.BlanchedAlmond;
                }
            }
        }
        private void dtp_FirstDay_ValueChanged(object sender, EventArgs e)
        {
            string firstdate = dtp_FirstDay.Value.ToString("yyyy-MM-dd ") + timeFisrt.Text + ":00"; //" 00:00:00";
            string lastdate = dtp_EndDay.Value.ToString("yyyy-MM-dd ") + timeEnd.Text + ":59"; //" 23:59:59";
            firstDateTime = DateTime.Parse(firstdate);
            lastDateTime = DateTime.Parse(lastdate);
            if (firstDateTime >= lastDateTime)
            {
                MessageBox.Show("Ngày bắt đầu phải nhỏ hơn hoặc bằng ngày kết thúc");
            }
            else
            {
                LoadDataGrid(firstDateTime, lastDateTime);
            }
        }

        private void dtp_EndDay_ValueChanged(object sender, EventArgs e)
        {
            string firstdate = dtp_FirstDay.Value.ToString("yyyy-MM-dd ") + timeFisrt.Text + ":00";// " 00:00:00";
            string lastdate = dtp_EndDay.Value.ToString("yyyy-MM-dd ") + timeEnd.Text + ":59";// " 23:59:59";
            firstDateTime = DateTime.Parse(firstdate);
            lastDateTime = DateTime.Parse(lastdate);
            if (firstDateTime > lastDateTime)
            {
                MessageBox.Show("Ngày kết thúc phải lớn hơn hoặc bằng ngày bắt đầu");
            }
            else
            {
                LoadDataGrid(firstDateTime, lastDateTime);
            }
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (!File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Productivity.xlsx"))
            {
                File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Productivity.xlsx");
                File.WriteAllBytes((Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/Productivity.xlsx"), Properties.Resources.Productivity);
            }
            else
            {
                File.WriteAllBytes((Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/Productivity.xlsx"), Properties.Resources.Productivity);
            }
           TableToExcel(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Productivity.xlsx");
          
        }
        Microsoft.Office.Interop.Excel.Application app = null;
        Microsoft.Office.Interop.Excel.Workbook book = null;
        Microsoft.Office.Interop.Excel.Worksheet wrksheet = null;
        SaveFileDialog saveFileDialog1 = new SaveFileDialog();

        public void TableToExcel(string strfilename)
        {
            try
            {
                lb_SoLuong.Text = "";
                progressBar1.Step = 1;
                progressBar1.Value = 1;
                progressBar1.Maximum = dataGridView1.RowCount + dataGridView2.RowCount + dataGridView3.RowCount + dataGridView4.RowCount + dataGridView5.RowCount + dataGridView6.RowCount;
                progressBar1.Minimum = 0;
                progressBar1.Visible = true;
                ModifyProgressBarColor.SetState(progressBar1, 1);
                app = new Microsoft.Office.Interop.Excel.Application();
                book = app.Workbooks.Open(strfilename, 0, true, 5, "", "", false, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "", true, false, 0, true, false, false);
                wrksheet = (Microsoft.Office.Interop.Excel.Worksheet)book.Sheets["Loại 1 CityN"];
                int h = 1,n=0;
                wrksheet.Cells[1, 1] = "BÁO CÁO HIỆU SUẤT DỰ ÁN BÁO CÁO LƯƠNG 2018 LOẠI 1 - CityN";
                wrksheet.Cells[2, 10] = "Thời gian:" + timeFisrt.Text + "/" + dtp_FirstDay.Value.Day + "/" + dtp_FirstDay.Value.Month + "/" + dtp_FirstDay.Value.Year + " đến " + timeEnd.Text + "/" + dtp_EndDay.Value.Day + "/" + dtp_EndDay.Value.Month + "/" + dtp_EndDay.Value.Year;
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    wrksheet.Cells[h + 2, 1] = h;
                    wrksheet.Cells[h + 2, 2] = dataGridView1.Rows[i].Cells[0].Value + "";//username
                    wrksheet.Cells[h + 2, 3] = dataGridView1.Rows[i].Cells[1].Value + "";//fullname
                    wrksheet.Cells[h + 2, 4] = dataGridView1.Rows[i].Cells[2].Value + "";//tong
                    wrksheet.Cells[h + 2, 5] = dataGridView1.Rows[i].Cells[3].Value + "";//phieudung
                    wrksheet.Cells[h + 2, 6] = dataGridView1.Rows[i].Cells[4].Value + "";//phieusai
                    wrksheet.Cells[h + 2, 7] = dataGridView1.Rows[i].Cells[5].Value + "";//thoigian
                    wrksheet.Cells[h + 2, 8] = dataGridView1.Rows[i].Cells[6].Value + "";//hieusuat
                    h++;
                    progressBar1.PerformStep();
                    lb_SoLuong.Text = ++n+@"\"+ progressBar1.Maximum;
                }
                wrksheet = (Microsoft.Office.Interop.Excel.Worksheet)book.Sheets["Loại 3 CityN"];
                h = 1;
                wrksheet.Cells[1, 1] = "BÁO CÁO HIỆU SUẤT DỰ ÁN BÁO CÁO LƯƠNG 2018 LOẠI 3 - CityN";
                wrksheet.Cells[2, 10] = "Thời gian:" + timeFisrt.Text + "/" + dtp_FirstDay.Value.Day + "/" + dtp_FirstDay.Value.Month + "/" + dtp_FirstDay.Value.Year + " đến " + timeEnd.Text + "/" + dtp_EndDay.Value.Day + "/" + dtp_EndDay.Value.Month + "/" + dtp_EndDay.Value.Year;
                for (int i = 0; i < dataGridView2.RowCount; i++)
                {
                    wrksheet.Cells[h + 2, 1] = h;
                    wrksheet.Cells[h + 2, 2] = dataGridView2.Rows[i].Cells[0].Value + "";//username
                    wrksheet.Cells[h + 2, 3] = dataGridView2.Rows[i].Cells[1].Value + "";//fullname
                    wrksheet.Cells[h + 2, 4] = dataGridView2.Rows[i].Cells[2].Value + "";//tong
                    wrksheet.Cells[h + 2, 5] = dataGridView2.Rows[i].Cells[3].Value + "";//phieudung
                    wrksheet.Cells[h + 2, 6] = dataGridView2.Rows[i].Cells[4].Value + "";//phieusai
                    wrksheet.Cells[h + 2, 7] = dataGridView2.Rows[i].Cells[5].Value + "";//thoigian
                    wrksheet.Cells[h + 2, 8] = dataGridView2.Rows[i].Cells[6].Value + "";//hieusuat
                    h++;
                    progressBar1.PerformStep();
                    lb_SoLuong.Text = ++n + @"\" + progressBar1.Maximum;
                }
                wrksheet = (Microsoft.Office.Interop.Excel.Worksheet)book.Sheets["Loại JP CityN"];
                h = 1;
                wrksheet.Cells[1, 1] = "BÁO CÁO HIỆU SUẤT DỰ ÁN BÁO CÁO LƯƠNG 2018 DEJP - CityN";
                wrksheet.Cells[2, 10] = "Thời gian:" + timeFisrt.Text + "/" + dtp_FirstDay.Value.Day + "/" + dtp_FirstDay.Value.Month + "/" + dtp_FirstDay.Value.Year + " đến " + timeEnd.Text + "/" + dtp_EndDay.Value.Day + "/" + dtp_EndDay.Value.Month + "/" + dtp_EndDay.Value.Year;

                for (int i = 0; i < dataGridView3.RowCount; i++)
                {
                    wrksheet.Cells[h + 2, 1] = h;
                    wrksheet.Cells[h + 2, 2] = dataGridView3.Rows[i].Cells[0].Value + "";//username
                    wrksheet.Cells[h + 2, 3] = dataGridView3.Rows[i].Cells[1].Value + "";//fullname
                    wrksheet.Cells[h + 2, 4] = dataGridView3.Rows[i].Cells[2].Value + "";//tong
                    wrksheet.Cells[h + 2, 5] = dataGridView3.Rows[i].Cells[3].Value + "";//phieudung
                    wrksheet.Cells[h + 2, 6] = dataGridView3.Rows[i].Cells[4].Value + "";//phieusai
                    wrksheet.Cells[h + 2, 7] = dataGridView3.Rows[i].Cells[5].Value + "";//thoigian
                    wrksheet.Cells[h + 2, 8] = dataGridView3.Rows[i].Cells[6].Value + "";//hieusuat
                    h++;
                    progressBar1.PerformStep();
                    lb_SoLuong.Text = ++n + @"\" + progressBar1.Maximum;
                }
                wrksheet = (Microsoft.Office.Interop.Excel.Worksheet)book.Sheets["Loại 1 CityO"];
                h = 1;
                wrksheet.Cells[1, 1] = "BÁO CÁO HIỆU SUẤT DỰ ÁN BÁO CÁO LƯƠNG 2018 LOẠI 1 - CityO";
                wrksheet.Cells[2, 10] = "Thời gian:" + timeFisrt.Text + "/" + dtp_FirstDay.Value.Day + "/" + dtp_FirstDay.Value.Month + "/" + dtp_FirstDay.Value.Year + " đến " + timeEnd.Text + "/" + dtp_EndDay.Value.Day + "/" + dtp_EndDay.Value.Month + "/" + dtp_EndDay.Value.Year;

                for (int i = 0; i < dataGridView4.RowCount; i++)
                {
                    wrksheet.Cells[h + 2, 1] = h;
                    wrksheet.Cells[h + 2, 2] = dataGridView4.Rows[i].Cells[0].Value + "";//username
                    wrksheet.Cells[h + 2, 3] = dataGridView4.Rows[i].Cells[1].Value + "";//fullname
                    wrksheet.Cells[h + 2, 4] = dataGridView4.Rows[i].Cells[2].Value + "";//tong
                    wrksheet.Cells[h + 2, 5] = dataGridView4.Rows[i].Cells[3].Value + "";//phieudung
                    wrksheet.Cells[h + 2, 6] = dataGridView4.Rows[i].Cells[4].Value + "";//phieusai
                    wrksheet.Cells[h + 2, 7] = dataGridView4.Rows[i].Cells[5].Value + "";//thoigian
                    wrksheet.Cells[h + 2, 8] = dataGridView4.Rows[i].Cells[6].Value + "";//hieusuat
                    h++;
                    progressBar1.PerformStep();
                    lb_SoLuong.Text = ++n + @"\" + progressBar1.Maximum;
                }
                wrksheet = (Microsoft.Office.Interop.Excel.Worksheet)book.Sheets["Loại 3 CityO"];
                h = 1;
                wrksheet.Cells[1, 1] = "BÁO CÁO HIỆU SUẤT DỰ ÁN BÁO CÁO LƯƠNG 2018 LOẠI 3 - CityO";
                wrksheet.Cells[2, 10] = "Thời gian:" + timeFisrt.Text + "/" + dtp_FirstDay.Value.Day + "/" + dtp_FirstDay.Value.Month + "/" + dtp_FirstDay.Value.Year + " đến " + timeEnd.Text + "/" + dtp_EndDay.Value.Day + "/" + dtp_EndDay.Value.Month + "/" + dtp_EndDay.Value.Year;

                for (int i = 0; i < dataGridView5.RowCount; i++)
                {
                    wrksheet.Cells[h + 2, 1] = h;
                    wrksheet.Cells[h + 2, 2] = dataGridView5.Rows[i].Cells[0].Value + "";//username
                    wrksheet.Cells[h + 2, 3] = dataGridView5.Rows[i].Cells[1].Value + "";//fullname
                    wrksheet.Cells[h + 2, 4] = dataGridView5.Rows[i].Cells[2].Value + "";//tong
                    wrksheet.Cells[h + 2, 5] = dataGridView5.Rows[i].Cells[3].Value + "";//phieudung
                    wrksheet.Cells[h + 2, 6] = dataGridView5.Rows[i].Cells[4].Value + "";//phieusai
                    wrksheet.Cells[h + 2, 7] = dataGridView5.Rows[i].Cells[5].Value + "";//thoigian
                    wrksheet.Cells[h + 2, 8] = dataGridView5.Rows[i].Cells[6].Value + "";//hieusuat
                    h++;
                    progressBar1.PerformStep();
                    lb_SoLuong.Text = ++n + @"\" + progressBar1.Maximum;
                }
                wrksheet = (Microsoft.Office.Interop.Excel.Worksheet)book.Sheets["Loại JP CityO"];
                h = 1;
                wrksheet.Cells[1, 1] = "BÁO CÁO HIỆU SUẤT DỰ ÁN BÁO CÁO LƯƠNG 2018 DEJP - CityO";
                wrksheet.Cells[2, 10] = "Thời gian:" + timeFisrt.Text + "/" + dtp_FirstDay.Value.Day + "/" + dtp_FirstDay.Value.Month + "/" + dtp_FirstDay.Value.Year + " đến " + timeEnd.Text + "/" + dtp_EndDay.Value.Day + "/" + dtp_EndDay.Value.Month + "/" + dtp_EndDay.Value.Year;

                for (int i = 0; i < dataGridView6.RowCount; i++)
                {
                    wrksheet.Cells[h + 2, 1] = h;
                    wrksheet.Cells[h + 2, 2] = dataGridView6.Rows[i].Cells[0].Value + "";//username
                    wrksheet.Cells[h + 2, 3] = dataGridView6.Rows[i].Cells[1].Value + "";//fullname
                    wrksheet.Cells[h + 2, 4] = dataGridView6.Rows[i].Cells[2].Value + "";//tong
                    wrksheet.Cells[h + 2, 5] = dataGridView6.Rows[i].Cells[3].Value + "";//phieudung
                    wrksheet.Cells[h + 2, 6] = dataGridView6.Rows[i].Cells[4].Value + "";//phieusai
                    wrksheet.Cells[h + 2, 7] = dataGridView6.Rows[i].Cells[5].Value + "";//thoigian
                    wrksheet.Cells[h + 2, 8] = dataGridView6.Rows[i].Cells[6].Value + "";//hieusuat
                    h++;
                    progressBar1.PerformStep();
                    lb_SoLuong.Text = ++n + @"\" + progressBar1.Maximum;
                }
                string savePath;

                saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Title = @"Save Excel Files";
                saveFileDialog1.Filter = @"Excel files (*.xlsx)|*.xlsx";
                saveFileDialog1.FileName = "NangSuat_BaoCaoLuong2018_" + dtp_FirstDay.Value.Day + "-" + dtp_EndDay.Value.Day;
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
                if (savePath != null) Process.Start(savePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            finally
            {
                progressBar1.Visible = false;
                lb_SoLuong.Text = "";
                if (book != null)
                    book.Close(false);
                if (app != null)
                    app.Quit();
                if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Productivity.xlsx"))
                {
                    File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Productivity.xlsx");
                }
                if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + saveFileDialog1.FileName))
                {
                    File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + saveFileDialog1.FileName);
                }
            }
        }
        private void timeFisrt_EditValueChanged(object sender, EventArgs e)
        {
            string firstdate = dtp_FirstDay.Value.ToString("yyyy-MM-dd ") + timeFisrt.Text + ":00"; //" 00:00:00";
            string lastdate = dtp_EndDay.Value.ToString("yyyy-MM-dd ") + timeEnd.Text + ":59"; //" 23:59:59";
            firstDateTime = DateTime.Parse(firstdate);
            lastDateTime = DateTime.Parse(lastdate);
            if (firstDateTime >= lastDateTime)
            {
                MessageBox.Show("Giờ bắt đầu phải nhỏ hơn hoặc bằng giờ kết thúc");
            }
            else
            {
                LoadDataGrid(firstDateTime, lastDateTime);
            }
        }

        private void timeEnd_EditValueChanged(object sender, EventArgs e)
        {
            string firstdate = dtp_FirstDay.Value.ToString("yyyy-MM-dd ") + timeFisrt.Text + ":00";// " 00:00:00";
            string lastdate = dtp_EndDay.Value.ToString("yyyy-MM-dd ") + timeEnd.Text + ":59";// " 23:59:59";
            firstDateTime = DateTime.Parse(firstdate);
            lastDateTime = DateTime.Parse(lastdate);
            if (firstDateTime > lastDateTime)
            {
                MessageBox.Show("Giờ kết thúc phải lớn hơn hoặc bằng giờ bắt đầu");
            }
            else
            {
                LoadDataGrid(firstDateTime, lastDateTime);
            }
        }

    }
}