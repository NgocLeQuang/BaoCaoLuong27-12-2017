using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace BaoCaoLuong2018.MyForm
{
    public partial class Refresh_ImageNotInput : DevExpress.XtraEditors.XtraForm
    {
        int minute = 0;
        public Refresh_ImageNotInput()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            GetImageNotSubmit();
        }
        public void GetImageNotSubmit()
        {
            gridControl1.DataSource = (from w in Global.Db.GetImageNotSubmitDeInput(int.Parse(string.IsNullOrEmpty(txt_Minute.Text) ? "10" : txt_Minute.Text), cbb_City.Text, "DESO") select new { w.BatchID, w.BatchName, w.IdImage, w.UserName, w.Start_Date, w.TimeRange }).ToList(); ;
            gridControl2.DataSource = (from w in Global.Db.GetImageNotSubmitDeInput(int.Parse(string.IsNullOrEmpty(txt_Minute.Text) ? "10" : txt_Minute.Text), cbb_City.Text, "DEJP") select new { w.BatchID, w.BatchName, w.IdImage, w.UserName, w.Start_Date, w.TimeRange }).ToList(); ;
        }
        private void Refresh_ImageNotInput_Load(object sender, EventArgs e)
        {
            cbb_City.Items.Clear();
            cbb_City.Items.Add(new { Text = "", Value = "" });
            cbb_City.Items.Add(new { Text = "CityN", Value = "CityN" });
            cbb_City.Items.Add(new { Text = "CityO", Value = "CityO" });
            //cbb_City.Items.Add(new { Text = "CityS", Value = "CityS" });
            cbb_City.DisplayMember = "Text";
            cbb_City.ValueMember = "Value";
            cbb_City.SelectedText = Global.StrCity;
            txt_Minute.Text = "10";
            GetImageNotSubmit();
        }    

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }
        
        private void Refresh_ImageNotInput_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Enabled = false;
        }

        private void btn_Refresh_Click_1(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tp_DeSo)
            {
                if(gridView1.GetSelectedRows().Count()<=0)
                {
                    MessageBox.Show("Bạn chưa chọn dòng. Hãy chọn dòng trước khi thực hiện.");
                    return;
                }
                foreach (var rowHandle in gridView1.GetSelectedRows())
                {
                    string BatchID = gridView1.GetRowCellValue(rowHandle, "BatchID").ToString();
                    string ImageName = gridView1.GetRowCellValue(rowHandle, "IdImage").ToString();
                    string UserName = gridView1.GetRowCellValue(rowHandle, "UserName").ToString();
                    Global.Db.RefreshImageNotInput(BatchID, ImageName, UserName,"DESO");
                }
            }
            else if (tabControl1.SelectedTab == tp_DeJP)
            {
                if (gridView2.GetSelectedRows().Count() <= 0)
                {
                    MessageBox.Show("Bạn chưa chọn dòng. Hãy chọn dòng trước khi thực hiện.");
                    return;
                }
                foreach (var rowHandle in gridView2.GetSelectedRows())
                {
                    string BatchID = gridView2.GetRowCellValue(rowHandle, "BatchID").ToString();
                    string ImageName = gridView2.GetRowCellValue(rowHandle, "IdImage").ToString();
                    string UserName = gridView2.GetRowCellValue(rowHandle, "UserName").ToString();
                    Global.Db.RefreshImageNotInput(BatchID, ImageName, UserName,"DEJP");
                }
            }
            GetImageNotSubmit();
        }

        private void btn_Refresh_All_Click_1(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tp_DeSo && gridView1.RowCount > 0)
            {
                if (MessageBox.Show("Bạn chắc chắn muốn refresh tất cả.", "Cảnh bảo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                    return;
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    string BatchID = gridView1.GetRowCellValue(i, "BatchID").ToString();
                    string ImageName = gridView1.GetRowCellValue(i, "IdImage").ToString();
                    string UserName = gridView1.GetRowCellValue(i, "UserName").ToString();
                    Global.Db.RefreshImageNotInput(BatchID, ImageName, UserName, "DESO");
                }
            }
            else if (tabControl1.SelectedTab == tp_DeJP && gridView2.RowCount>0)
            {
                if (MessageBox.Show("Bạn chắc chắn muốn refresh tất cả.", "Cảnh bảo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                    return;
                for (int i = 0; i < gridView2.RowCount; i++)
                {
                    string BatchID = gridView2.GetRowCellValue(i, "BatchID").ToString();
                    string ImageName = gridView2.GetRowCellValue(i, "IdImage").ToString();
                    string UserName = gridView2.GetRowCellValue(i, "UserName").ToString();
                    Global.Db.RefreshImageNotInput(BatchID, ImageName, UserName, "DEJP");
                }
            }
            GetImageNotSubmit();
        }

        private void txt_MinuteSo_TextChanged(object sender, EventArgs e)
        {
            GetImageNotSubmit();
        }

        private void cbb_City_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete)
                cbb_City.Text = "";
        }

        private void cbb_City_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar != 3)
                e.Handled = true;
        }

        private void cbb_City_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}