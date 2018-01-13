using BaoCaoLuong2018.BaoCaoLuonng2017.MyUserControl;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;

namespace BaoCaoLuong2018.BaoCaoLuonng2017.MyUserControl
{
    public delegate void Focus_Text(string Truong, string Tag);
    public partial class uc_Loai_2 : UserControl
    {
        public event Focus_Text Focus;
        public event AllTextChange Changed;

        public uc_Loai_2()
        {
            InitializeComponent();
        }

        public void ResetData()
        {
            txt_Truong_001.Text = string.Empty;
            txt_Truong_001.BackColor = Color.White;
            txt_Truong_002.Text = string.Empty;
            txt_Truong_002.BackColor = Color.White;
            txt_Truong_003.Text = string.Empty;
            txt_Truong_003.BackColor = Color.White;
            txt_Truong_004.Text = string.Empty;
            txt_Truong_004.BackColor = Color.White;
            txt_Truong_005.Text = string.Empty;
            txt_Truong_005.BackColor = Color.White;
            txt_Truong_006.Text = string.Empty;
            txt_Truong_006.BackColor = Color.White;
            txt_Truong_007.Text = string.Empty;
            txt_Truong_007.BackColor = Color.White;
            txt_Truong_008.Text = string.Empty;
            txt_Truong_008.BackColor = Color.White;
            txt_Truong_009.Text = string.Empty;
            txt_Truong_009.BackColor = Color.White;
            txt_Truong_010.Text = string.Empty;
            txt_Truong_010.BackColor = Color.White;
        }

        public bool IsEmpty()
        {
            if (string.IsNullOrEmpty(txt_Truong_001.Text) &&
                string.IsNullOrEmpty(txt_Truong_002.Text) &&
                string.IsNullOrEmpty(txt_Truong_003.Text) &&
                string.IsNullOrEmpty(txt_Truong_004.Text) &&
                string.IsNullOrEmpty(txt_Truong_005.Text) &&
                string.IsNullOrEmpty(txt_Truong_006.Text) &&
                string.IsNullOrEmpty(txt_Truong_007.Text) &&
                string.IsNullOrEmpty(txt_Truong_008.Text) &&
                string.IsNullOrEmpty(txt_Truong_009.Text) &&
                string.IsNullOrEmpty(txt_Truong_010.Text))
                return true;
            return false;
        }

        public void SaveData_Loai_2(string idimage)
        {
            Global.db_BCL.Insert_Loai2_New(idimage, Global.StrBatch, Global.StrUsername, txt_Truong_001.Text, txt_Truong_002.Text, txt_Truong_003.Text, txt_Truong_004.Text, txt_Truong_005.Text, txt_Truong_006.Text, txt_Truong_007.Text, txt_Truong_008.Text, txt_Truong_009.Text, txt_Truong_010.Text);
        }

        public bool Lenght12(TextEdit txt)
        {
            try
            {
                int intMod = 11;
                List<string> P = new List<string>();

                for (int i = 0; i < txt.Text.Length; i++)
                {
                    P.Add(txt.Text[i].ToString());
                    //chỉ lấy 11 ký tự đầu để so sánh. ký tự thứu 12 để compare
                }

                if (P.Count != 12)
                {
                    txt.BackColor = Color.Red;
                }

                List<int> Q = new List<int> { 6, 5, 4, 3, 2, 7, 6, 5, 4, 3, 2 };

                List<string> P_Q = new List<string>();

                for (int i = 0; i < 11; i++)
                {
                    P_Q.Add((int.Parse(P[i]) * Q[i]).ToString());
                }

                int sum = 0;
                for (int i = 0; i < 11; i++)
                {
                    sum += int.Parse(P_Q[i]);
                }

                //MessageBox.Show(sum.ToString());

                int checksum = intMod - sum % intMod;

                if (checksum >= 10)
                    checksum = 0;

                if (P[11] == checksum.ToString())
                    return true;
                else
                    return false;
            }
            catch { return false; }
        }

        public bool Lenght13(TextEdit txt)
        {
            try
            {
                int intMod2 = 9;
                List<string> P = new List<string>();

                for (int i = txt.Text.Length - 1; i >= 0; i--)
                {
                    P.Add(txt.Text[i].ToString());
                    //chỉ lấy 12 ký tự đầu để so sánh. ký tự thứu 13 để compare
                }

                if (P.Count != 13)
                {
                    txt.BackColor = Color.Red;
                }

                List<int> Q = new List<int> { 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2 };

                List<string> P_Q = new List<string>();

                for (int i = 0; i < 12; i++)
                {
                    P_Q.Add((int.Parse(P[i]) * Q[i]).ToString());
                }

                int sum = 0;
                for (int i = 0; i < 12; i++)
                {
                    sum += int.Parse(P_Q[i]);
                }

                //MessageBox.Show(sum.ToString());

                int checksum = intMod2 - sum % intMod2;
                if (checksum >= 10)
                    checksum = 0;
                if (P[12] == checksum.ToString())
                    return true;
                else
                    return false;
            }
            catch { return false; }
        }

        //private void txt_Truong_004_TextChanged(object sender, EventArgs e)
        //{
        //    if (Changed != null)
        //        Changed(sender, e);

        //    //if (!(Lenght12(txt_Truong_004) || Lenght13(txt_Truong_004)) && (txt_Truong_004.Text.Length == 12 || txt_Truong_004.Text.Length == 13))
        //    //{
        //    //    txt_Truong_004.BackColor = Color.LimeGreen;
        //    //}
        //    //else
        //    //{
        //        if (txt_Truong_005.Text.Length == 12 || txt_Truong_005.Text.Length == 13 || txt_Truong_005.Text == "?" || string.IsNullOrEmpty(txt_Truong_005.Text))
        //            txt_Truong_005.BackColor = Color.White;
        //        else
        //            txt_Truong_005.BackColor = Color.Red;
        //    //}

        //    if (txt_Truong_005.Text.Length == 12)
        //    {
        //        if (!Lenght12(txt_Truong_005))
        //            txt_Truong_005.BackColor = Color.LimeGreen;
        //    }
        //    else
        //        if(txt_Truong_005.Text.Length == 13)
        //            if(!Lenght13(txt_Truong_005))
        //            txt_Truong_005.BackColor = Color.LimeGreen;

        //    //txt_Truong_004.BackColor = Color.White;
        //}

        private void txt_Truong_001_EditValueChanged(object sender, EventArgs e)
        {
            if (Changed != null)
                Changed(sender, e);
        }

        private void txt_Truong_002_EditValueChanged(object sender, EventArgs e)
        {
            if (txt_Truong_002.Text.Length == 8 || txt_Truong_002.Text == "?" || string.IsNullOrEmpty(txt_Truong_002.Text))
                txt_Truong_002.BackColor = Color.White;
            else
                txt_Truong_002.BackColor = Color.Red;
            if (Changed != null)
                Changed(sender, e);
        }

        private void txt_Truong_003_EditValueChanged(object sender, EventArgs e)
        {
            if (txt_Truong_003.Text.Length == 13 || txt_Truong_003.Text == "?" || string.IsNullOrEmpty(txt_Truong_003.Text))
                txt_Truong_003.BackColor = Color.White;
            else
                txt_Truong_003.BackColor = Color.Red;
            if (Changed != null)
                Changed(sender, e);
        }

        private void txt_Truong_004_EditValueChanged(object sender, EventArgs e)
        {
            if (txt_Truong_004.Text.Length <= 5 || txt_Truong_004.Text == "?" || string.IsNullOrEmpty(txt_Truong_004.Text))
                txt_Truong_004.BackColor = Color.White;
            else
                txt_Truong_004.BackColor = Color.Red;
            if (Changed != null)
                Changed(sender, e);
        }

        private void txt_Truong_005_EditValueChanged(object sender, EventArgs e)
        {
            if (txt_Truong_005.Text.Length <= 5 || txt_Truong_005.Text == "?" || string.IsNullOrEmpty(txt_Truong_005.Text))
                txt_Truong_005.BackColor = Color.White;
            else
                txt_Truong_005.BackColor = Color.Red;
            if (Changed != null)
                Changed(sender, e);
        }

        private void txt_Truong_006_EditValueChanged(object sender, EventArgs e)
        {
            if (txt_Truong_006.Text.Length <= 5 || txt_Truong_006.Text == "?" || string.IsNullOrEmpty(txt_Truong_006.Text))
                txt_Truong_006.BackColor = Color.White;
            else
                txt_Truong_006.BackColor = Color.Red;
            if (Changed != null)
                Changed(sender, e);
        }

        private void txt_Truong_007_EditValueChanged(object sender, EventArgs e)
        {
            if (txt_Truong_007.Text.Length <= 5 || txt_Truong_007.Text == "?" || string.IsNullOrEmpty(txt_Truong_007.Text))
                txt_Truong_007.BackColor = Color.White;
            else
                txt_Truong_007.BackColor = Color.Red;
            if (Changed != null)
                Changed(sender, e);
        }

        private void txt_Truong_008_EditValueChanged(object sender, EventArgs e)
        {
            if (txt_Truong_008.Text.Length == 1 || txt_Truong_008.Text == "?" || string.IsNullOrEmpty(txt_Truong_008.Text))
                txt_Truong_008.BackColor = Color.White;
            else
                txt_Truong_008.BackColor = Color.Red;
            if (Changed != null)
                Changed(sender, e);
        }

        private void txt_Truong_009_EditValueChanged(object sender, EventArgs e)
        {
            if (txt_Truong_009.Text.Length == 1 || txt_Truong_009.Text == "?" || string.IsNullOrEmpty(txt_Truong_009.Text))
                txt_Truong_009.BackColor = Color.White;
            else
                txt_Truong_009.BackColor = Color.Red;
            if (Changed != null)
                Changed(sender, e);
        }

        private void txt_Truong_010_EditValueChanged(object sender, EventArgs e)
        {
            if (txt_Truong_010.Text.Length == 1 || txt_Truong_010.Text == "?" || string.IsNullOrEmpty(txt_Truong_010.Text))
                txt_Truong_010.BackColor = Color.White;
            else
                txt_Truong_010.BackColor = Color.Red;
            if (Changed != null)
                Changed(sender, e);
        }

        private void uc_Loai_2_Load(object sender, EventArgs e)
        {
            txt_Truong_001.Tag = (from w in Global.DataNote where w.City == "CityS" & w.LoaiPhieu == "Loai2" & w.Truong == "1" select w.Note).FirstOrDefault();
            txt_Truong_002.Tag = (from w in Global.DataNote where w.City == "CityS" & w.LoaiPhieu == "Loai2" & w.Truong == "2" select w.Note).FirstOrDefault();
            txt_Truong_003.Tag = (from w in Global.DataNote where w.City == "CityS" & w.LoaiPhieu == "Loai2" & w.Truong == "3" select w.Note).FirstOrDefault();
            txt_Truong_004.Tag = (from w in Global.DataNote where w.City == "CityS" & w.LoaiPhieu == "Loai2" & w.Truong == "4" select w.Note).FirstOrDefault();
            txt_Truong_005.Tag = (from w in Global.DataNote where w.City == "CityS" & w.LoaiPhieu == "Loai2" & w.Truong == "5" select w.Note).FirstOrDefault();
            txt_Truong_006.Tag = (from w in Global.DataNote where w.City == "CityS" & w.LoaiPhieu == "Loai2" & w.Truong == "6" select w.Note).FirstOrDefault();
            txt_Truong_007.Tag = (from w in Global.DataNote where w.City == "CityS" & w.LoaiPhieu == "Loai2" & w.Truong == "7" select w.Note).FirstOrDefault();
            txt_Truong_008.Tag = (from w in Global.DataNote where w.City == "CityS" & w.LoaiPhieu == "Loai2" & w.Truong == "8" select w.Note).FirstOrDefault();
            txt_Truong_009.Tag = (from w in Global.DataNote where w.City == "CityS" & w.LoaiPhieu == "Loai2" & w.Truong == "9" select w.Note).FirstOrDefault();
            txt_Truong_010.Tag = (from w in Global.DataNote where w.City == "CityS" & w.LoaiPhieu == "Loai2" & w.Truong == "10" select w.Note).FirstOrDefault();
           

            txt_Truong_001.GotFocus += Txt_Truong_001_GotFocus;
            txt_Truong_002.GotFocus += Txt_Truong_001_GotFocus;
            txt_Truong_003.GotFocus += Txt_Truong_001_GotFocus;
            txt_Truong_004.GotFocus += Txt_Truong_001_GotFocus;
            txt_Truong_005.GotFocus += Txt_Truong_001_GotFocus;
            txt_Truong_006.GotFocus += Txt_Truong_001_GotFocus;
            txt_Truong_007.GotFocus += Txt_Truong_001_GotFocus;
            txt_Truong_008.GotFocus += Txt_Truong_001_GotFocus;
            txt_Truong_009.GotFocus += Txt_Truong_001_GotFocus;
            txt_Truong_010.GotFocus += Txt_Truong_001_GotFocus;
            
        }

        private void Txt_Truong_001_GotFocus(object sender, EventArgs e)
        {
            Focus(((TextEdit)sender)?.Name, ((TextEdit)sender)?.Tag + "");
            ((TextEdit)sender).SelectAll();
        }

        private void txt_Truong_001_KeyDown(object sender, KeyEventArgs e)
        {
            if (((TextEdit)sender).Name == "txt_Truong_001" && (e.KeyCode == Keys.Down|| e.KeyCode == Keys.Right))
            {
                SendKeys.Send("{Tab}");
            }
            else if (((TextEdit)sender).Name == "txt_Truong_001" && (e.KeyCode == Keys.Up || e.KeyCode == Keys.Left))
            { }
            else if (((TextEdit)sender).Name == "txt_Truong_010" && (e.KeyCode == Keys.Up || e.KeyCode == Keys.Left))
            {
                SendKeys.Send("+{Tab}");
            }
            else if (((TextEdit)sender).Name == "txt_Truong_010" && (e.KeyCode == Keys.Down || e.KeyCode == Keys.Right))
            { }
            else if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Right)
            {
                SendKeys.Send("{Tab}");
            }
            else if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Left)
            {
                SendKeys.Send("+{Tab}");
            }
        }
    }
}