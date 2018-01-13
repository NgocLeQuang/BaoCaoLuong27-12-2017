using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using BaoCaoLuong2018.Properties;

namespace BaoCaoLuong2018.MyUserControl
{
    public partial class UC_CityN_Loai1 : UserControl
    {
        public event AllTextChange Changed;
        public event Focus_Text Focus;
        public UC_CityN_Loai1()
        {
            InitializeComponent();
        }

        public void UC_CityN_Loai1_Load(object sender, EventArgs e)
        {
            if (Global.FlagLoad)
                return;
            txt_Truong_011.Tag = (from w in Global.DataNote where w.City == "CityN" & w.LoaiPhieu == "Loai1" & w.Truong == "11" select w.Note).FirstOrDefault();
            txt_Truong_014.Tag = (from w in Global.DataNote where w.City == "CityN" & w.LoaiPhieu == "Loai1" & w.Truong == "14" select w.Note).FirstOrDefault();
            txt_Truong_026.Tag = (from w in Global.DataNote where w.City == "CityN" & w.LoaiPhieu == "Loai1" & w.Truong == "26" select w.Note).FirstOrDefault();
            txt_Truong_016.Tag = (from w in Global.DataNote where w.City == "CityN" & w.LoaiPhieu == "Loai1" & w.Truong == "16" select w.Note).FirstOrDefault();
            txt_Truong_018.Tag = (from w in Global.DataNote where w.City == "CityN" & w.LoaiPhieu == "Loai1" & w.Truong == "18" select w.Note).FirstOrDefault();
            txt_Truong_020.Tag = (from w in Global.DataNote where w.City == "CityN" & w.LoaiPhieu == "Loai1" & w.Truong == "20" select w.Note).FirstOrDefault();
            txt_Truong_022.Tag = (from w in Global.DataNote where w.City == "CityN" & w.LoaiPhieu == "Loai1" & w.Truong == "22" select w.Note).FirstOrDefault();
            txt_Truong_024.Tag = (from w in Global.DataNote where w.City == "CityN" & w.LoaiPhieu == "Loai1" & w.Truong == "24" select w.Note).FirstOrDefault();
            txt_Truong_028_1.Tag = txt_Truong_028_2.Tag = (from w in Global.DataNote where w.City == "CityN" & w.LoaiPhieu == "Loai1" & w.Truong == "28" select w.Note).FirstOrDefault();

            txt_Truong_011.GotFocus += Txt_Truong_018_GotFocus;
            txt_Truong_014.GotFocus += Txt_Truong_018_GotFocus;
            txt_Truong_026.GotFocus += Txt_Truong_018_GotFocus;
            txt_Truong_016.GotFocus += Txt_Truong_018_GotFocus;
            txt_Truong_018.GotFocus += Txt_Truong_018_GotFocus;
            txt_Truong_020.GotFocus += Txt_Truong_018_GotFocus;
            txt_Truong_022.GotFocus += Txt_Truong_018_GotFocus;
            txt_Truong_024.GotFocus += Txt_Truong_018_GotFocus;
            txt_Truong_028_1.GotFocus += Txt_Truong_018_GotFocus;
            txt_Truong_028_2.GotFocus += Txt_Truong_018_GotFocus;
        }
        private void Txt_Truong_018_GotFocus(object sender, EventArgs e)
        {
            Focus(((TextEdit)sender).Name, ((TextEdit)sender).Tag + "");
            ((TextEdit)sender).SelectAll();
        }

        private void txt_Truong_011_TextChanged(object sender, EventArgs e)
        {
            if (((TextEdit)sender).Text.IndexOf('?') >= 0)
                ((TextEdit)sender).Text = "?";
        }
        public void ResetData()
        {
            txt_Truong_011.Text = "";
            txt_Truong_014.Text = "";
            txt_Truong_026.Text = "";
            txt_Truong_016.Text = "";
            txt_Truong_018.Text = "";
            txt_Truong_020.Text = "";
            txt_Truong_022.Text = "";
            txt_Truong_024.Text = "";
            txt_Truong_028_1.Text = "";
            txt_Truong_028_2.Text = "";
            chk_QC.Checked = false;

            txt_Truong_011.ForeColor = Color.Black;
            txt_Truong_014.ForeColor = Color.Black;
            txt_Truong_026.ForeColor = Color.Black;
            txt_Truong_016.ForeColor = Color.Black;
            txt_Truong_018.ForeColor = Color.Black;
            txt_Truong_020.ForeColor = Color.Black;
            txt_Truong_022.ForeColor = Color.Black;
            txt_Truong_024.ForeColor = Color.Black;
            txt_Truong_028_1.ForeColor = Color.Black;
            txt_Truong_028_2.ForeColor = Color.Black;

            txt_Truong_011.BackColor = Color.White;
            txt_Truong_014.BackColor = Color.White;
            txt_Truong_026.BackColor = Color.White;
            txt_Truong_016.BackColor = Color.White;
            txt_Truong_018.BackColor = Color.White;
            txt_Truong_020.BackColor = Color.White;
            txt_Truong_022.BackColor = Color.White;
            txt_Truong_024.BackColor = Color.White;
            txt_Truong_028_1.BackColor = Color.White;
            txt_Truong_028_2.BackColor = Color.White;
        }
        public bool IsEmpty()
        {
            if (string.IsNullOrEmpty(txt_Truong_011.Text) &&
                string.IsNullOrEmpty(txt_Truong_014.Text) &&
                string.IsNullOrEmpty(txt_Truong_016.Text) &&
                string.IsNullOrEmpty(txt_Truong_018.Text) &&
                string.IsNullOrEmpty(txt_Truong_020.Text) &&
                string.IsNullOrEmpty(txt_Truong_022.Text) &&
                string.IsNullOrEmpty(txt_Truong_024.Text) &&
                string.IsNullOrEmpty(txt_Truong_026.Text) &&
                string.IsNullOrEmpty(txt_Truong_028_1.Text) &&
                string.IsNullOrEmpty(txt_Truong_028_2.Text) &&
                !chk_QC.Checked)
                return true;
            return false;
        }
        public bool CheckQC()
        {
            if (txt_Truong_011.Text.IndexOf('?') >= 0 || txt_Truong_011.Text.IndexOf('●') >= 0 ||
                txt_Truong_014.Text.IndexOf('?') >= 0 || txt_Truong_014.Text.IndexOf('●') >= 0 ||
                txt_Truong_016.Text.IndexOf('?') >= 0 || txt_Truong_016.Text.IndexOf('●') >= 0 ||
                txt_Truong_018.Text.IndexOf('?') >= 0 || txt_Truong_018.Text.IndexOf('●') >= 0 ||
                txt_Truong_020.Text.IndexOf('?') >= 0 || txt_Truong_020.Text.IndexOf('●') >= 0 ||
                txt_Truong_022.Text.IndexOf('?') >= 0 || txt_Truong_022.Text.IndexOf('●') >= 0 ||
                txt_Truong_024.Text.IndexOf('?') >= 0 || txt_Truong_024.Text.IndexOf('●') >= 0 ||
                txt_Truong_026.Text.IndexOf('?') >= 0 || txt_Truong_026.Text.IndexOf('●') >= 0 ||
                txt_Truong_028_1.Text.IndexOf('?') >= 0 || txt_Truong_028_1.Text.IndexOf('●') >= 0 ||
                txt_Truong_028_2.Text.IndexOf('?') >= 0 || txt_Truong_028_2.Text.IndexOf('●') >= 0 ||
                chk_QC.Checked)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        string truong28 = "";
        public void Save_CityN_Loai1(string Batch, string image)
        {
            truong28 = "";
            if (txt_Truong_028_1.Text.IndexOf("?") >= 0 || txt_Truong_028_2.Text.IndexOf("?") >= 0||(txt_Truong_028_1.Text == "1"& txt_Truong_028_2.Text == "1"))
                truong28 = "?";
            else if(txt_Truong_028_1.Text=="1")
                truong28 = "1";
            else if (txt_Truong_028_2.Text == "1")
                truong28 = "0";
            Global.Db.Insert_DESo_CityN(Batch, image, Global.StrUserName, CheckQC(), "Loai1",
                                        "", "", "", "", "", "", "", "", "", "",
                                        txt_Truong_011.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_011.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_011.Text,
                                        "", "",
                                        txt_Truong_014.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_014.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_014.Text,
                                        "",
                                        txt_Truong_016.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_016.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_016.Text,
                                        "",
                                        txt_Truong_018.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_018.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_018.Text,
                                        "",
                                        txt_Truong_020.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_020.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_020.Text,
                                        "",
                                        txt_Truong_022.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_022.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_022.Text,
                                        "",
                                        txt_Truong_024.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_024.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_024.Text,
                                        "",
                                        txt_Truong_026.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_026.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_026.Text,
                                        "",
                                        truong28,"","",
                                        "", "", "", "", "", "", "", "", "", "",
                                        "", "", "", "", "", "", "", "", "", "",
                                        "", "", "", "", "", "", "", "", "", "",
                                        "", "", "", "", "", "", "", "", "", "",
                                        "", "", "", "", "", "", "", "", "", "",
                                        "", "", "", "", "", "", "", "", "", "",
                                        "", "", "", "", "", "", "", "", "", "",
                                        "", "", "", "", "", "", "", "", "", "",
                                        "", "", "", "", "", "", "", "", "", "",
                                        "", "", "", "", "", "", "", "", "", "",
                                        "", "", "", "", "", "", "", "", "", "",
                                        "", "", "", "", "", "", "", "", "", "",
                                        "", "", "", "", "", "", "", "", "", "",
                                        "");
        }
        public void Edit_Save_CityN_Loai1(string Batch, string image)
        {
            truong28 = "";
            if (txt_Truong_028_1.Text.IndexOf("?") >= 0 || txt_Truong_028_2.Text.IndexOf("?") >= 0 || (txt_Truong_028_1.Text == "1" & txt_Truong_028_2.Text == "1"))
                truong28 = "?";
            else if (txt_Truong_028_1.Text == "1")
                truong28 = "1";
            else if (txt_Truong_028_2.Text == "1")
                truong28 = "0";
            Global.Db.Sua_va_Luu_DeSo_CityN(Batch, image, Global.StrUserName, Global.StrCity, "Loai1",
                                        "", "", "", "", "", "", "", "", "", "",
                                        txt_Truong_011.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_011.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_011.Text,
                                        "", "",
                                        txt_Truong_014.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_014.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_014.Text,
                                        "",
                                        txt_Truong_016.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_016.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_016.Text,
                                        "",
                                        txt_Truong_018.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_018.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_018.Text,
                                        "",
                                        txt_Truong_020.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_020.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_020.Text,
                                        "",
                                        txt_Truong_022.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_022.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_022.Text,
                                        "",
                                        txt_Truong_024.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_024.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_024.Text,
                                        "",
                                        txt_Truong_026.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_026.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_026.Text,
                                        "",
                                        truong28, "", "",
                                        "", "", "", "", "", "", "", "", "", "",
                                        "", "", "", "", "", "", "", "", "", "",
                                        "", "", "", "", "", "", "", "", "", "",
                                        "", "", "", "", "", "", "", "", "", "",
                                        "", "", "", "", "", "", "", "", "", "",
                                        "", "", "", "", "", "", "", "", "", "",
                                        "", "", "", "", "", "", "", "", "", "",
                                        "", "", "", "", "", "", "", "", "", "",
                                        "", "", "", "", "", "", "", "", "", "",
                                        "", "", "", "", "", "", "", "", "", "",
                                        "", "", "", "", "", "", "", "", "", "",
                                        "", "", "", "", "", "", "", "", "", "",
                                        "", "", "", "", "", "", "", "", "", "",
                                        "",
                                        CheckQC());
        }
        private void DoiMau(int soByteBe, int soBytelon, TextEdit textBox)
        {
            if (textBox.Text.IndexOf('?') < 0 && textBox.Text.IndexOf('●') < 0 && !string.IsNullOrEmpty(textBox.Text))
            {
                if (textBox.Text.Length >= soByteBe && textBox.Text.Length <= soBytelon)
                {
                    textBox.BackColor = Color.White;
                    textBox.ForeColor = Color.Black;
                }
                else
                {
                    textBox.BackColor = Color.Red;
                    textBox.ForeColor = Color.White;
                }
            }
            else
            {
                textBox.BackColor = Color.White;
                textBox.ForeColor = Color.Black;
            }
        }

        private void txt_Truong_011_EditValueChanged(object sender, EventArgs e)
        {
            Changed?.Invoke(sender, e);
            DoiMau(0, 11, (TextEdit)sender);
        }

        private void txt_Truong_014_EditValueChanged(object sender, EventArgs e)
        {
            Changed?.Invoke(sender, e);
            DoiMau(0, 1, (TextEdit)sender);
        }

        private void txt_Truong_026_EditValueChanged(object sender, EventArgs e)
        {
            Changed?.Invoke(sender, e);
            DoiMau(0, 13, (TextEdit)sender);
        }

        private void txt_Truong_016_EditValueChanged(object sender, EventArgs e)
        {
            Changed?.Invoke(sender, e);
            DoiMau(0, 5, (TextEdit)sender);
        }

        private void txt_Truong_018_EditValueChanged(object sender, EventArgs e)
        {
            Changed?.Invoke(sender, e);
            DoiMau(0, 3, (TextEdit)sender);
        }

        private void txt_Truong_020_EditValueChanged(object sender, EventArgs e)
        {
            Changed?.Invoke(sender, e);
            DoiMau(0, 5, (TextEdit)sender);
        }

        private void txt_Truong_022_EditValueChanged(object sender, EventArgs e)
        {
            Changed?.Invoke(sender, e);
            DoiMau(0, 5, (TextEdit)sender);
        }

        private void txt_Truong_024_EditValueChanged(object sender, EventArgs e)
        {
            Changed?.Invoke(sender, e);
            DoiMau(0, 15, (TextEdit)sender);
        }

        private void txt_Truong_028_1_EditValueChanged(object sender, EventArgs e)
        {
            Changed?.Invoke(sender, e);
            DoiMau(0, 1, (TextEdit)sender);
        }

        private void txt_Truong_028_2_EditValueChanged(object sender, EventArgs e)
        {
            Changed?.Invoke(sender, e);
            DoiMau(0, 1, (TextEdit)sender);
        }

        private void chk_QC_CheckedChanged(object sender, EventArgs e)
        {
            Changed?.Invoke(sender, e);
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.QC = chk_QC.Checked;
            Settings.Default.Save();
        }

        private void txt_Truong_011_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong11 = txt_Truong_011.Text;
            Settings.Default.LoaiPhieu = "Loai1";
            Settings.Default.Save();
        }

        private void txt_Truong_014_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong14 = txt_Truong_014.Text;
            Settings.Default.LoaiPhieu = "Loai1";
            Settings.Default.Save();
        }

        private void txt_Truong_026_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong26 = txt_Truong_026.Text;
            Settings.Default.LoaiPhieu = "Loai1";
            Settings.Default.Save();
        }

        private void txt_Truong_016_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong16 = txt_Truong_016.Text;
            Settings.Default.LoaiPhieu = "Loai1";
            Settings.Default.Save();
        }

        private void txt_Truong_018_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong18 = txt_Truong_018.Text;
            Settings.Default.LoaiPhieu = "Loai1";
            Settings.Default.Save();
        }

        private void txt_Truong_020_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong20 = txt_Truong_020.Text;
            Settings.Default.LoaiPhieu = "Loai1";
            Settings.Default.Save();
        }

        private void txt_Truong_022_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong22 = txt_Truong_022.Text;
            Settings.Default.LoaiPhieu = "Loai1";
            Settings.Default.Save();
        }

        private void txt_Truong_024_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong24 = txt_Truong_024.Text;
            Settings.Default.LoaiPhieu = "Loai1";
            Settings.Default.Save();
        }

        private void txt_Truong_028_1_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong28_1 = txt_Truong_028_1.Text;
            Settings.Default.LoaiPhieu = "Loai1";
            Settings.Default.Save();
        }

        private void txt_Truong_028_2_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong28_2 = txt_Truong_028_2.Text;
            Settings.Default.LoaiPhieu = "Loai1";
            Settings.Default.Save();
        }
    }
}
