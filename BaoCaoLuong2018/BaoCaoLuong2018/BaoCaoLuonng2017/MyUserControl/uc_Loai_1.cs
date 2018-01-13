using BaoCaoLuong2018.BaoCaoLuonng2017;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace BaoCaoLuong2018.BaoCaoLuonng2017.MyUserControl
{
    public delegate void AllTextChange(object sender, EventArgs e);

    public partial class uc_Loai_1 : UserControl
    {
        public event AllTextChange Changed;

        public uc_Loai_1()
        {
            InitializeComponent();
        }

        public void ResetData()
        {
            txt_Truong_001.Text = "";
            txt_Truong_001.BackColor = Color.White;
            txt_Truong_002.Text = "";
            txt_Truong_002.BackColor = Color.White;
        }

        public bool IsEmpty()
        {
            if (string.IsNullOrEmpty(txt_Truong_001.Text) &&
                string.IsNullOrEmpty(txt_Truong_002.Text))
                return true;
            return false;
        }

        public void SaveData_Loai_1(string idimage)
        {
            Global.db_BCL.Insert_Loai1(idimage, Global.StrBatch, Global.StrUsername, txt_Truong_001.Text, txt_Truong_002.Text);
        }

        private void txt_Truong_001_TextChanged(object sender, EventArgs e)
        {
            if (txt_Truong_001.Text == "06" || txt_Truong_001.Text == "07")
            {
                txt_Truong_002.Enabled = true;
            }
            else
            {
                txt_Truong_002.Text = "";
                txt_Truong_002.Enabled = false;
            }
            if (Changed != null)
                Changed(sender, e);
        }

        private void txt_Truong_002_TextChanged(object sender, EventArgs e)
        {
            if (Changed != null)
                Changed(sender, e);
        }

        private void uc_Loai_1_Load(object sender, EventArgs e)
        {
        }
    }
}