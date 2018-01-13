using BaoCaoLuong2018.BaoCaoLuonng2017.MyUserControl;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace BaoCaoLuong2018.BaoCaoLuonng2017.MyUserControl
{
    public partial class uc_Loai_3 : UserControl
    {
        public event AllTextChange Changed;

        public uc_Loai_3()
        {
            InitializeComponent();
        }

        public void ResetData()
        {
            txt_Truong_002.Text = string.Empty;
            txt_Truong_002.BackColor = Color.White;
            txt_Truong_003.Text = string.Empty;
            txt_Truong_003.BackColor = Color.White;
        }

        public bool IsEmpty()
        {
            if (string.IsNullOrEmpty(txt_Truong_002.Text) &&
                string.IsNullOrEmpty(txt_Truong_003.Text))
                return true;
            return false;
        }

        public void SaveData_Loai_3(string idimage)
        {
            Global.db_BCL.Insert_Loai3(idimage, Global.StrBatch, Global.StrUsername, txt_Truong_002.Text, txt_Truong_003.Text);
        }

        private void txt_Truong_002_TextChanged(object sender, EventArgs e)
        {
            if (txt_Truong_002.Text.Length == 12 || txt_Truong_002.Text == "?" || string.IsNullOrEmpty(txt_Truong_002.Text))
                txt_Truong_002.BackColor = Color.White;
            else
                txt_Truong_002.BackColor = Color.Red;
            if (Changed != null)
                Changed(sender, e);
        }

        private void txt_Truong_003_TextChanged(object sender, EventArgs e)
        {
            if (txt_Truong_003.Text.Length == 10 || txt_Truong_003.Text == "?" || string.IsNullOrEmpty(txt_Truong_003.Text))
            {
                txt_Truong_003.BackColor = Color.White;
                //luon luon bat dau bang so 4 hoac so 99
                if (txt_Truong_003.Text.Length > 1)
                    if (txt_Truong_003.Text[0].ToString() != "4")
                        if ((txt_Truong_003.Text[0].ToString() + txt_Truong_003.Text[1].ToString()) != "99")
                        {
                            txt_Truong_003.BackColor = Color.Red;
                        }
            }
            else
                txt_Truong_003.BackColor = Color.Red;
            if (Changed != null)
                Changed(sender, e);
        }
    }
}