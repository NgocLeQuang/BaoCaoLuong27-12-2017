using DevExpress.XtraCharts;
using DevExpress.XtraEditors;
using System;
using System.Linq;
using System.Windows.Forms;
using Series = DevExpress.XtraCharts.Series;

namespace BaoCaoLuong2018.MyForm
{
    public partial class FrmTienDo : XtraForm
    {
        public FrmTienDo()
        {
            InitializeComponent();
        }

        bool FlagLoad = false;
        private void frm_TienDo_Load(object sender, EventArgs e)
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
            FlagLoad = false;
            cbb_City_SelectedIndexChanged(null, null);
        }

        //private void ThongKeDeJP()
        //{
        //    try
        //    {
        //        chartControl1.DataSource = null;
        //        chartControl1.Series.Clear();
        //        if (rb_All.Checked)
        //        {
        //            lb_TongSoHinh.Text = (from w in Global.Db.tbl_Images select w.IDImage).Count() + "";
        //            chartControl1.DataSource = Global.Db.ThongKeTienDoDeJPAll();
        //        }
        //        else{
        //            lb_TongSoHinh.Text = (from w in Global.Db.tbl_Images where w.BatchID == cbb_Batch.SelectedValue.ToString() select w.IDImage).Count() + "";
        //            chartControl1.DataSource = Global.Db.ThongKeTienDoDeJP(cbb_Batch.SelectedValue.ToString());

        //        }
        //        Series series1 = new Series("Series1", ViewType.Pie);
        //        series1.ArgumentScaleType = ScaleType.Qualitative;
        //        series1.ArgumentDataMember = "name";
        //        series1.ValueScaleType = ScaleType.Numerical;
        //        series1.ValueDataMembers.AddRange("soluong");
        //        chartControl1.Series.Add(series1);
        //        ((PiePointOptions) series1.Label.PointOptions).PointView = PointView.ArgumentAndValues;
        //        chartControl1.PaletteName = "Palette 1";
        //    }
        //    catch (Exception)
        //    {
        //        // ignored
        //    }
        //}
        private void ThongKe()
        {
            try
            {
                chartControl1.DataSource = null;
                chartControl1.Series.Clear();
                
                if (rb_All_DESO.Checked)
                {
                    lb_soHinhUserGood.Text = (from w in Global.Db.tbl_Images join b in Global.Db.tbl_Batches on w.BatchID equals (b.BatchID) where b.City == cbb_City.Text & w.FlagReadDeSo_Good == 0 select w).Count().ToString();
                    lb_soHinhUserNotGood.Text = (from w in Global.Db.tbl_Images where w.FlagReadDeSo_NotGood == 0 & w.BatchID == cbb_Batch.SelectedValue + "" select w).Count().ToString();
                    lb_TongSoHinh.Text = (from w in Global.Db.tbl_Images join b in Global.Db.tbl_Batches on w.BatchID equals (b.BatchID) where b.City == cbb_City.Text select w).Count().ToString();
                    chartControl1.DataSource = Global.Db.ThongKeTienDoAll(cbb_City.Text,"DESO");
                }
                else if (rb_All_DEJP.Checked)
                {
                    lb_soHinhUserGood.Text ="0";
                    lb_soHinhUserNotGood.Text = "0";
                    lb_TongSoHinh.Text = (from w in Global.Db.tbl_Images join b in Global.Db.tbl_Batches on w.BatchID equals(b.BatchID) where b.City==cbb_City.Text select w.IDImage).Count() + "";
                    chartControl1.DataSource = Global.Db.ThongKeTienDoAll(cbb_City.Text,"DEJP");
                }
                else if (rb_deso.Checked)
                {
                    lb_soHinhUserGood.Text = (from w in Global.Db.tbl_Images where w.FlagReadDeSo_Good == 0 & w.BatchID == cbb_Batch.SelectedValue + "" select w).Count().ToString();
                    lb_soHinhUserNotGood.Text = (from w in Global.Db.tbl_Images where w.FlagReadDeSo_NotGood == 0 & w.BatchID == cbb_Batch.SelectedValue + "" select w).Count().ToString();
                    lb_TongSoHinh.Text = (from w in Global.Db.tbl_Images join b in Global.Db.tbl_Batches on w.BatchID equals (b.BatchID) where b.City == cbb_City.Text & w.BatchID == cbb_Batch.SelectedValue.ToString() select w.IDImage).Count() + "";
                    chartControl1.DataSource = Global.Db.ThongKeTienDo(cbb_Batch.SelectedValue + "", cbb_City.Text, "DESO");
                }
                else if (rb_dejp.Checked)
                {
                    lb_soHinhUserGood.Text = "0";
                    lb_soHinhUserNotGood.Text = "0";

                    lb_TongSoHinh.Text = (from w in Global.Db.tbl_Images join b in Global.Db.tbl_Batches on w.BatchID equals (b.BatchID) where b.City == cbb_City.Text & w.BatchID == cbb_Batch.SelectedValue.ToString() select w.IDImage).Count() + "";
                    chartControl1.DataSource = Global.Db.ThongKeTienDo(cbb_Batch.SelectedValue + "", cbb_City.Text, "DEJP");
                }
                Series series1 = new Series("Series1", ViewType.Pie);
                series1.ArgumentScaleType = ScaleType.Qualitative;
                series1.ArgumentDataMember = "name";
                series1.ValueScaleType = ScaleType.Numerical;
                series1.ValueDataMembers.AddRange("soluong");
                chartControl1.Series.Add(series1);
                ((PiePointOptions)series1.Label.PointOptions).PointView = PointView.ArgumentAndValues;
                chartControl1.PaletteName = "Palette 1";
            }
            catch (Exception)
            {
                // ignored
            }
        }

        private void btn_ChiTiet_Click(object sender, EventArgs e)
        {
            frm_ChiTietTienDo frm = new frm_ChiTietTienDo();
            frm.Loai = rb_deso.Checked|| rb_All_DESO.Checked ? "DESO" : rb_dejp.Checked|| rb_All_DEJP.Checked ? "DEJP" : "";
            frm.lb_fBatchName.Text = rb_All_DESO.Checked ? "AllDESO" : rb_All_DEJP.Checked ? "AllDEJP" : cbb_Batch.Text;
            frm.lb_City.Text = cbb_City.Text;
            frm.BatchID = rb_All_DESO.Checked ? "AllDESO" : rb_All_DEJP.Checked ? "AllDEJP" : cbb_Batch.SelectedValue.ToString();
            frm.City = cbb_City.Text;
            //if (rb_deso.Checked)
            //{
            //    frm.rb_deso.Checked = true;
            //}
            //else if (rb_dejp.Checked)
            //{
            //    frm.rb_dejp.Checked = true;
            //}
            frm.ShowDialog();
        }
        
        private void chartControl1_CustomDrawSeriesPoint(object sender, CustomDrawSeriesPointEventArgs e)
        {
            string argument = e.SeriesPoint.Argument;
            var pointValue = e.SeriesPoint.Values[0];
            if (argument == "Hình chưa nhập")
            {
                e.LabelText = "Hình chưa nhập: " + pointValue + " hình";
            }
            else if (argument == "Hình đang nhập")
            {
                e.LabelText = "Hình đang nhập: " + pointValue + " hình";
            }
            else if (argument == "Hình chờ check")
            {
                e.LabelText = "Hình chờ check: " + pointValue + " hình";
            }
            else if (argument == "Hình đang check")
            {
                e.LabelText = "Hình đang check: " + pointValue + " hình";
            }
            else if (argument == "Hình hoàn thành")
            {
                e.LabelText = "Hình hoàn thành: " + pointValue + " hình";
            }
        }

        private void time_CheckHinhChuaNhap_Tick(object sender, EventArgs e)
        {
            if (cbb_Batch.Text == "")
                return;
            ThongKe();
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_deso.Checked)
                ThongKe();
        }

        private void rb_dejp_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_dejp.Checked)
                ThongKe();
        }

        private void cbb_City_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbb_Batch.DataSource = null;
            cbb_Batch.Text = "";
            var fBatchName = (from w in  Global.Db.tbl_Batches where w.City==cbb_City.Text orderby w.DateCreate descending select new { w.BatchID, w.BatchName}).ToList();
            cbb_Batch.DataSource = fBatchName;
            cbb_Batch.DisplayMember = "BatchName";
            cbb_Batch.ValueMember = "BatchID";
        }

        private void cbb_City_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if ((int)e.KeyChar != 3)
                e.Handled = true;
        }

        private void cbb_City_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete)
                ((System.Windows.Forms.ComboBox)sender).Text = "";
        }

        private void cbb_Batch_SelectedIndexChanged(object sender, EventArgs e)
        {
            rb_deso.Checked = true;
            rb_All_DESO.Checked = false;
            ThongKe();
        }

        private void rb_All_CheckedChanged(object sender, EventArgs e)
        {
            cbb_Batch.Enabled = !rb_All_DESO.Checked;
            ThongKe();
        }
    }
}