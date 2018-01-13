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
    public partial class UC_CityO_JP : UserControl
    {
        public event Focus_Text Focus;
        public event AllTextChange Changed;
        public UC_CityO_JP()
        {
            InitializeComponent();
        }
        public bool bSubmit = false;

        private List<string> lChar = new List<string>
                                        {   "ｱ",
                                            "ｲ",
                                            "ｳ",
                                            "ｴ",
                                            "ｵ",
                                            "ｶ",
                                            "ｷ",
                                            "ｸ",
                                            "ｹ",
                                            "ｺ",
                                            "ｻ",
                                            "ｼ",
                                            "ｽ",
                                            "ｾ",
                                            "ｿ",
                                            "ﾀ",
                                            "ﾁ",
                                            "ﾂ",
                                            "ﾃ",
                                            "ﾄ",
                                            "ﾅ",
                                            "ﾆ",
                                            "ﾇ",
                                            "ﾈ",
                                            "ﾉ",
                                            "ﾊ",
                                            "ﾋ",
                                            "ﾌ",
                                            "ﾍ",
                                            "ﾎ",
                                            "ﾏ",
                                            "ﾐ",
                                            "ﾑ",
                                            "ﾒ",
                                            "ﾓ",
                                            "ﾔ",
                                            "ﾕ",
                                            "ﾖ",
                                            "ﾗ",
                                            "ﾘ",
                                            "ﾙ",
                                            "ﾚ",
                                            "ﾛ",
                                            "ﾜ",
                                            "ｦ",
                                            "ﾝ",
                                            "ｶﾞ",
                                            "ｷﾞ",
                                            "ｸﾞ",
                                            "ｹﾞ",
                                            "ｺﾞ",
                                            "ｻﾞ",
                                            "ｼﾞ",
                                            "ｽﾞ",
                                            "ｾﾞ",
                                            "ｿﾞ",
                                            "ﾀﾞ",
                                            "ﾁﾞ",
                                            "ﾂﾞ",
                                            "ﾃﾞ",
                                            "ﾄﾞ",
                                            "ﾊﾞ",
                                            "ﾊﾟ",
                                            "ﾋﾞ",
                                            "ﾋﾟ",
                                            "ﾌﾞ",
                                            "ﾌﾟ",
                                            "ﾍﾞ",
                                            "ﾍﾟ",
                                            "ﾎﾞ",
                                            "ﾎﾟ",
                                            "ｳﾞ",
                                            "A",
                                            "B",
                                            "C",
                                            "D",
                                            "E",
                                            "F",
                                            "G",
                                            "H",
                                            "I",
                                            "J",
                                            "K",
                                            "L",
                                            "M",
                                            "N",
                                            "O",
                                            "P",
                                            "Q",
                                            "R",
                                            "S",
                                            "T",
                                            "U",
                                            "V",
                                            "W",
                                            "X",
                                            "Y",
                                            "Z",
                                            " ",
                                            "ｰ",
                                            "ｧ",
                                            "ｨ",
                                            "ｩ",
                                            "ｪ",
                                            "ｫ",
                                            "ｯ",
                                            "ｬ",
                                            "ｭ",
                                            "ｮ",
                                            "ｱ",
                                            "ｲ",
                                            "ｳ",
                                            "ｴ",
                                            "ｵ",
                                            "ﾂ",
                                            "ﾔ",
                                            "ﾕ",
                                            "ﾖ",
                                            "?"
        };

        public void UC_CityO_JP_Load(object sender, EventArgs e)
        {
            if (Global.FlagLoad)
                return;
            txt_Truong_016.Tag = (from w in Global.DataNote where w.City == "CityO" & w.LoaiPhieu == "LoaiJP" & w.Truong == "16" select w.Note).FirstOrDefault();
            txt_Truong_094.Tag = (from w in Global.DataNote where w.City == "CityO" & w.LoaiPhieu == "LoaiJP" & w.Truong == "94" select w.Note).FirstOrDefault();
            txt_Truong_096.Tag = (from w in Global.DataNote where w.City == "CityO" & w.LoaiPhieu == "LoaiJP" & w.Truong == "96" select w.Note).FirstOrDefault();
            txt_Truong_098.Tag = (from w in Global.DataNote where w.City == "CityO" & w.LoaiPhieu == "LoaiJP" & w.Truong == "98" select w.Note).FirstOrDefault();
            txt_Truong_100.Tag = (from w in Global.DataNote where w.City == "CityO" & w.LoaiPhieu == "LoaiJP" & w.Truong == "100" select w.Note).FirstOrDefault();
            txt_Truong_102.Tag = (from w in Global.DataNote where w.City == "CityO" & w.LoaiPhieu == "LoaiJP" & w.Truong == "102" select w.Note).FirstOrDefault();
            txt_Truong_104.Tag = (from w in Global.DataNote where w.City == "CityO" & w.LoaiPhieu == "LoaiJP" & w.Truong == "104" select w.Note).FirstOrDefault();
            txt_Truong_106.Tag = (from w in Global.DataNote where w.City == "CityO" & w.LoaiPhieu == "LoaiJP" & w.Truong == "106" select w.Note).FirstOrDefault();
            txt_Truong_108.Tag = (from w in Global.DataNote where w.City == "CityO" & w.LoaiPhieu == "LoaiJP" & w.Truong == "108" select w.Note).FirstOrDefault();
            
            txt_Truong_016.GotFocus += Txt_Truong_094_GotFocus;
            txt_Truong_094.GotFocus += Txt_Truong_094_GotFocus;
            txt_Truong_096.GotFocus += Txt_Truong_094_GotFocus;
            txt_Truong_098.GotFocus += Txt_Truong_094_GotFocus;
            txt_Truong_100.GotFocus += Txt_Truong_094_GotFocus;
            txt_Truong_102.GotFocus += Txt_Truong_094_GotFocus;
            txt_Truong_104.GotFocus += Txt_Truong_094_GotFocus;
            txt_Truong_106.GotFocus += Txt_Truong_094_GotFocus;
            txt_Truong_108.GotFocus += Txt_Truong_094_GotFocus;
        }

        private void Txt_Truong_094_GotFocus(object sender, EventArgs e)
        {
            Focus(((RichTextBox)sender).Name, ((RichTextBox)sender).Tag + "");
            ((RichTextBox)sender).SelectAll();
        }

        private void txt_Truong_094_TextChanged(object sender, EventArgs e)
        {
            //if (((TextEdit)sender).Text.IndexOf('●') >= 0)
            //    ((TextEdit)sender).Text = "●";
            //if (((TextEdit)sender).Text.IndexOf('?') >= 0)
            //    ((TextEdit)sender).Text = "?";
        }
        public void ResetData()
        {
            txt_Truong_016.Text = "";
            txt_Truong_094.Text = "";
            txt_Truong_096.Text = "";
            txt_Truong_098.Text = "";
            txt_Truong_100.Text = "";
            txt_Truong_102.Text = "";
            txt_Truong_104.Text = "";
            txt_Truong_106.Text = "";
            txt_Truong_108.Text = "";

            txt_Truong_016.ForeColor = Color.Black;
            txt_Truong_094.ForeColor = Color.Black;
            txt_Truong_096.ForeColor = Color.Black;
            txt_Truong_098.ForeColor = Color.Black;
            txt_Truong_100.ForeColor = Color.Black;
            txt_Truong_102.ForeColor = Color.Black;
            txt_Truong_104.ForeColor = Color.Black;
            txt_Truong_106.ForeColor = Color.Black;
            txt_Truong_108.ForeColor = Color.Black;

            txt_Truong_016.BackColor = Color.White;
            txt_Truong_094.BackColor = Color.White;
            txt_Truong_096.BackColor = Color.White;
            txt_Truong_098.BackColor = Color.White;
            txt_Truong_100.BackColor = Color.White;
            txt_Truong_102.BackColor = Color.White;
            txt_Truong_104.BackColor = Color.White;
            txt_Truong_106.BackColor = Color.White;
            txt_Truong_108.BackColor = Color.White;
        }
        public bool IsEmpty()
        {
            if (string.IsNullOrEmpty(txt_Truong_016.Text) &&
                string.IsNullOrEmpty(txt_Truong_094.Text) &&
                string.IsNullOrEmpty(txt_Truong_096.Text) &&
                string.IsNullOrEmpty(txt_Truong_098.Text) &&
                string.IsNullOrEmpty(txt_Truong_100.Text) &&
                string.IsNullOrEmpty(txt_Truong_102.Text) &&
                string.IsNullOrEmpty(txt_Truong_104.Text) &&
                string.IsNullOrEmpty(txt_Truong_106.Text) &&
                string.IsNullOrEmpty(txt_Truong_108.Text))
                return true;
            return false;
        }
        public bool CheckQC()
        {
            if (txt_Truong_016.Text.IndexOf('?') >= 0 || txt_Truong_016.Text.IndexOf('●') >= 0 ||
                txt_Truong_094.Text.IndexOf('?') >= 0 || txt_Truong_094.Text.IndexOf('●') >= 0 ||
                txt_Truong_096.Text.IndexOf('?') >= 0 || txt_Truong_096.Text.IndexOf('●') >= 0 ||
                txt_Truong_098.Text.IndexOf('?') >= 0 || txt_Truong_098.Text.IndexOf('●') >= 0 ||
                txt_Truong_100.Text.IndexOf('?') >= 0 || txt_Truong_100.Text.IndexOf('●') >= 0 ||
                txt_Truong_102.Text.IndexOf('?') >= 0 || txt_Truong_102.Text.IndexOf('●') >= 0 ||
                txt_Truong_104.Text.IndexOf('?') >= 0 || txt_Truong_104.Text.IndexOf('●') >= 0 ||
                txt_Truong_106.Text.IndexOf('?') >= 0 || txt_Truong_106.Text.IndexOf('●') >= 0 ||
                txt_Truong_108.Text.IndexOf('?') >= 0 || txt_Truong_108.Text.IndexOf('●') >= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        int Start = 0;
        private void doimautrongkhoang(RichTextBox txt, int so_nho, int so_lon)
        {
            Start = 0;
            Start = txt.SelectionStart;
            txt.Text = txt.Text.Replace("ｧ", "ｱ").Replace("ｨ", "ｲ").Replace("ｩ", "ｳ").Replace("ｪ", "ｴ").Replace("ｫ", "ｵ").Replace("ｯ", "ﾂ").Replace("ｬ", "ﾔ").Replace("ｭ", "ﾕ").Replace("ｮ", "ﾖ");
            txt.SelectionStart = Start;
            if (!string.IsNullOrEmpty(txt.Text))
            {
                if (txt.Text.Length >= 2)
                {
                    if (txt.Text.Substring(txt.Text.Length - 2, 2) == "  ")
                    {
                        txt.BackColor = Color.Red;
                        txt.ForeColor = Color.White;
                        bSubmit = true;
                        txt.MaxLength = txt.Text.Length;
                    }
                    else
                    {
                        string result = lChar.Find(s => s == txt.Text[(txt.SelectionStart > 0 ? txt.SelectionStart : txt.Text.Length) - 1].ToString());
                        if (string.IsNullOrEmpty(result))
                        {

                            string result1 = lChar.Find(s => s == txt.Text[(txt.SelectionStart > 0 ? txt.SelectionStart : txt.Text.Length) - 2].ToString() + txt.Text[(txt.SelectionStart > 0 ? txt.SelectionStart : txt.Text.Length) - 1].ToString());
                            if (string.IsNullOrEmpty(result1))
                            {
                                txt.BackColor = Color.Red;
                                txt.ForeColor = Color.White;
                                bSubmit = true;
                                txt.MaxLength = txt.Text.Length;
                            }
                            else
                            {
                                txt.BackColor = Color.White;
                                txt.ForeColor = Color.Black;
                                bSubmit = false;
                                txt.MaxLength = 0;
                            }
                        }
                        else
                        {
                            txt.BackColor = Color.White;
                            txt.ForeColor = Color.Black;
                            bSubmit = false;
                            txt.MaxLength = 0;
                        }
                    }
                }
                else
                {
                    string result = lChar.Find(s => s == txt.Text[txt.Text.Length - 1].ToString());
                    if (string.IsNullOrEmpty(result))
                    {
                        txt.BackColor = Color.Red;
                        txt.ForeColor = Color.White;
                        bSubmit = true;
                        txt.MaxLength = txt.Text.Length;
                    }
                    else
                    {
                        txt.BackColor = Color.White;
                        txt.ForeColor = Color.Black;
                        bSubmit = false;
                        txt.MaxLength = 0;
                    }
                }
            }
            else
            {
                txt.BackColor = Color.White;
                txt.ForeColor = Color.Black;
                bSubmit = false;
                txt.MaxLength = 0;
            }
        }
        //private void DoiMau(int soByteBe, int soBytelon, TextEdit textBox)
        //{
        //    if (textBox.Text.IndexOf('?') < 0 && textBox.Text.IndexOf('●') < 0 && !string.IsNullOrEmpty(textBox.Text))
        //    {
        //        if (textBox.Text.Length >= soByteBe && textBox.Text.Length <= soBytelon)
        //        {
        //            textBox.BackColor = Color.White;
        //            textBox.ForeColor = Color.Black;
        //        }
        //        else
        //        {
        //            textBox.BackColor = Color.Red;
        //            textBox.ForeColor = Color.White;
        //        }
        //    }
        //    else
        //    {
        //        textBox.BackColor = Color.White;
        //        textBox.ForeColor = Color.Black;
        //    }
        //}

        public void Save_CityO_JP(string Batch, string image)
        {
            Global.Db.Insert_DEJP_CityO(Batch, image, Global.StrUserName, Global.Token, Global.Version,
                     txt_Truong_016.Text.Replace("ｧ", "ｱ").Replace("ｨ", "ｲ").Replace("ｩ", "ｳ").Replace("ｪ", "ｴ").Replace("ｫ", "ｵ").Replace("ｯ", "ﾂ").Replace("ｬ", "ﾔ").Replace("ｭ", "ﾕ").Replace("ｮ", "ﾖ"),
                     txt_Truong_094.Text.Replace("ｧ", "ｱ").Replace("ｨ", "ｲ").Replace("ｩ", "ｳ").Replace("ｪ", "ｴ").Replace("ｫ", "ｵ").Replace("ｯ", "ﾂ").Replace("ｬ", "ﾔ").Replace("ｭ", "ﾕ").Replace("ｮ", "ﾖ"),
                     txt_Truong_096.Text.Replace("ｧ", "ｱ").Replace("ｨ", "ｲ").Replace("ｩ", "ｳ").Replace("ｪ", "ｴ").Replace("ｫ", "ｵ").Replace("ｯ", "ﾂ").Replace("ｬ", "ﾔ").Replace("ｭ", "ﾕ").Replace("ｮ", "ﾖ"),
                     txt_Truong_098.Text.Replace("ｧ", "ｱ").Replace("ｨ", "ｲ").Replace("ｩ", "ｳ").Replace("ｪ", "ｴ").Replace("ｫ", "ｵ").Replace("ｯ", "ﾂ").Replace("ｬ", "ﾔ").Replace("ｭ", "ﾕ").Replace("ｮ", "ﾖ"),
                     txt_Truong_100.Text.Replace("ｧ", "ｱ").Replace("ｨ", "ｲ").Replace("ｩ", "ｳ").Replace("ｪ", "ｴ").Replace("ｫ", "ｵ").Replace("ｯ", "ﾂ").Replace("ｬ", "ﾔ").Replace("ｭ", "ﾕ").Replace("ｮ", "ﾖ"),
                     txt_Truong_102.Text.Replace("ｧ", "ｱ").Replace("ｨ", "ｲ").Replace("ｩ", "ｳ").Replace("ｪ", "ｴ").Replace("ｫ", "ｵ").Replace("ｯ", "ﾂ").Replace("ｬ", "ﾔ").Replace("ｭ", "ﾕ").Replace("ｮ", "ﾖ"),
                     txt_Truong_104.Text.Replace("ｧ", "ｱ").Replace("ｨ", "ｲ").Replace("ｩ", "ｳ").Replace("ｪ", "ｴ").Replace("ｫ", "ｵ").Replace("ｯ", "ﾂ").Replace("ｬ", "ﾔ").Replace("ｭ", "ﾕ").Replace("ｮ", "ﾖ"),
                     txt_Truong_106.Text.Replace("ｧ", "ｱ").Replace("ｨ", "ｲ").Replace("ｩ", "ｳ").Replace("ｪ", "ｴ").Replace("ｫ", "ｵ").Replace("ｯ", "ﾂ").Replace("ｬ", "ﾔ").Replace("ｭ", "ﾕ").Replace("ｮ", "ﾖ"),
                     txt_Truong_108.Text.Replace("ｧ", "ｱ").Replace("ｨ", "ｲ").Replace("ｩ", "ｳ").Replace("ｪ", "ｴ").Replace("ｫ", "ｵ").Replace("ｯ", "ﾂ").Replace("ｬ", "ﾔ").Replace("ｭ", "ﾕ").Replace("ｮ", "ﾖ"));
        }

        public void Edit_Save_CityO_JP(string Batch, string image)
        {
            Global.Db.Sua_Va_Luu_DeJP(Batch, image, Global.StrUserName, Global.StrCity,
                     txt_Truong_016.Text.Replace("ｧ", "ｱ").Replace("ｨ", "ｲ").Replace("ｩ", "ｳ").Replace("ｪ", "ｴ").Replace("ｫ", "ｵ").Replace("ｯ", "ﾂ").Replace("ｬ", "ﾔ").Replace("ｭ", "ﾕ").Replace("ｮ", "ﾖ"),
                     txt_Truong_094.Text.Replace("ｧ", "ｱ").Replace("ｨ", "ｲ").Replace("ｩ", "ｳ").Replace("ｪ", "ｴ").Replace("ｫ", "ｵ").Replace("ｯ", "ﾂ").Replace("ｬ", "ﾔ").Replace("ｭ", "ﾕ").Replace("ｮ", "ﾖ"),
                     txt_Truong_096.Text.Replace("ｧ", "ｱ").Replace("ｨ", "ｲ").Replace("ｩ", "ｳ").Replace("ｪ", "ｴ").Replace("ｫ", "ｵ").Replace("ｯ", "ﾂ").Replace("ｬ", "ﾔ").Replace("ｭ", "ﾕ").Replace("ｮ", "ﾖ"),
                     txt_Truong_098.Text.Replace("ｧ", "ｱ").Replace("ｨ", "ｲ").Replace("ｩ", "ｳ").Replace("ｪ", "ｴ").Replace("ｫ", "ｵ").Replace("ｯ", "ﾂ").Replace("ｬ", "ﾔ").Replace("ｭ", "ﾕ").Replace("ｮ", "ﾖ"),
                     txt_Truong_100.Text.Replace("ｧ", "ｱ").Replace("ｨ", "ｲ").Replace("ｩ", "ｳ").Replace("ｪ", "ｴ").Replace("ｫ", "ｵ").Replace("ｯ", "ﾂ").Replace("ｬ", "ﾔ").Replace("ｭ", "ﾕ").Replace("ｮ", "ﾖ"),
                     txt_Truong_102.Text.Replace("ｧ", "ｱ").Replace("ｨ", "ｲ").Replace("ｩ", "ｳ").Replace("ｪ", "ｴ").Replace("ｫ", "ｵ").Replace("ｯ", "ﾂ").Replace("ｬ", "ﾔ").Replace("ｭ", "ﾕ").Replace("ｮ", "ﾖ"),
                     txt_Truong_104.Text.Replace("ｧ", "ｱ").Replace("ｨ", "ｲ").Replace("ｩ", "ｳ").Replace("ｪ", "ｴ").Replace("ｫ", "ｵ").Replace("ｯ", "ﾂ").Replace("ｬ", "ﾔ").Replace("ｭ", "ﾕ").Replace("ｮ", "ﾖ"),
                     txt_Truong_106.Text.Replace("ｧ", "ｱ").Replace("ｨ", "ｲ").Replace("ｩ", "ｳ").Replace("ｪ", "ｴ").Replace("ｫ", "ｵ").Replace("ｯ", "ﾂ").Replace("ｬ", "ﾔ").Replace("ｭ", "ﾕ").Replace("ｮ", "ﾖ"),
                     txt_Truong_108.Text.Replace("ｧ", "ｱ").Replace("ｨ", "ｲ").Replace("ｩ", "ｳ").Replace("ｪ", "ｴ").Replace("ｫ", "ｵ").Replace("ｯ", "ﾂ").Replace("ｬ", "ﾔ").Replace("ｭ", "ﾕ").Replace("ｮ", "ﾖ"));
        }
        private void txt_Truong_016_EditValueChanged(object sender, EventArgs e)
        {
            Changed?.Invoke(sender, e);
            if (Global.FlagLoadCheck)
            { return; }
            doimautrongkhoang((RichTextBox)sender, 0, 50);
        }

        private void txt_Truong_094_EditValueChanged(object sender, EventArgs e)
        {
            Changed?.Invoke(sender, e);
            if (Global.FlagLoadCheck)
            { return; }
            doimautrongkhoang((RichTextBox)sender,0, 60);
        }

        private void txt_Truong_016_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong16 = txt_Truong_016.Text;
            Settings.Default.Save();
        }

        private void txt_Truong_094_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong94 = txt_Truong_094.Text;
            Settings.Default.Save();
        }

        private void txt_Truong_096_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong96 = txt_Truong_096.Text;
            Settings.Default.Save();
        }

        private void txt_Truong_098_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong98 = txt_Truong_098.Text;
            Settings.Default.Save();
        }

        private void txt_Truong_100_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong100 = txt_Truong_100.Text;
            Settings.Default.Save();
        }

        private void txt_Truong_102_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong102 = txt_Truong_102.Text;
            Settings.Default.Save();
        }

        private void txt_Truong_104_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong104 = txt_Truong_104.Text;
            Settings.Default.Save();
        }

        private void txt_Truong_106_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong106 = txt_Truong_106.Text;
            Settings.Default.Save();
        }

        private void txt_Truong_108_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong108 = txt_Truong_108.Text;
            Settings.Default.Save();
        }

        private void txt_Truong_016_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Right)
            //{
            //    SendKeys.Send("{Tab}");
            //}
            if (e.KeyCode == Keys.Down)
            {
                SendKeys.Send("{Tab}");
            }
        }

        private void txt_Truong_094_KeyDown(object sender, KeyEventArgs e)
        {
            if ((/*e.KeyCode == Keys.Right||*/e.KeyCode==Keys.Down) && ((RichTextBox)sender).Name == "txt_Truong_108")
            {
                return;
            }
            else if (e.KeyCode == Keys.Down && ((RichTextBox)sender).Name == "txt_Truong_100")
            {
                return;
            }
            else if (e.KeyCode == Keys.Up && ((RichTextBox)sender).Name == "txt_Truong_094")
            {
                SendKeys.Send("+{Tab}");
            }
            //else if (e.KeyCode == Keys.Right)
            //{
            //    SendKeys.Send("{Tab}");
            //}
            else if (e.KeyCode == Keys.Down)
            {
                SendKeys.Send("{Tab}");
                SendKeys.Send("{Tab}");
            }
            //else if (e.KeyCode == Keys.Left)
            //{
            //    SendKeys.Send("+{Tab}");
            //}
            else if (e.KeyCode == Keys.Up)
            {
                SendKeys.Send("+{Tab}");
                SendKeys.Send("+{Tab}");
            }
        }
    }
}