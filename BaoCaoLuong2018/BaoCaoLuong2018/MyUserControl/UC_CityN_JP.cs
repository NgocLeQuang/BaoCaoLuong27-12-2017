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
    public partial class UC_CityN_JP : UserControl
    {
        public event AllTextChange Changed;
        public event Focus_Text Focus;
        public UC_CityN_JP()
        {
            InitializeComponent();
        }

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
                                            "?",
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
                                            "ﾖ"
        };

        public bool bSubmit = false;

        private void Txt_Truong_094_GotFocus(object sender, EventArgs e)
        {
            Focus(((TextEdit)sender).Name, ((TextEdit)sender).Tag + "");
            ((TextEdit)sender).SelectAll();
        }

        private void txt_Truong_016_TextChanged(object sender, EventArgs e)
        {
            //if (((TextEdit)sender).Text.IndexOf('?') >= 0)
            //    ((TextEdit)sender).Text = "?";
        }
        public void ResetData()
        {
            txt_Truong_018.Text = "";
            txt_Truong_148.Text = "";

            txt_Truong_018.ForeColor = Color.Black;
            txt_Truong_148.ForeColor = Color.Black;

            txt_Truong_018.BackColor = Color.White;
            txt_Truong_148.BackColor = Color.White;
        }
        public bool IsEmpty()
        {
            if (string.IsNullOrEmpty(txt_Truong_018.Text) &&
                string.IsNullOrEmpty(txt_Truong_148.Text))
                return true;
            return false;
        }
        public bool CheckQC()
        {
            if (txt_Truong_018.Text.IndexOf('?') >= 0 || txt_Truong_018.Text.IndexOf('●') >= 0 ||
                txt_Truong_148.Text.IndexOf('?') >= 0 || txt_Truong_148.Text.IndexOf('●') >= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void UC_CityN_JP_Load(object sender, EventArgs e)
        {
            SetDataLookUpEdit();
            txt_Truong_148.Properties.DataSource = category;
            txt_Truong_148.Properties.DisplayMember = "Value_SO";
            txt_Truong_148.Properties.ValueMember = "Value_SO";
            if (Global.FlagLoad)
                return;
            txt_Truong_018.Tag = (from w in Global.DataNote where w.City == "CityN" & w.LoaiPhieu == "LoaiJP" & w.Truong == "18" select w.Note).FirstOrDefault();
            txt_Truong_148.Tag = (from w in Global.DataNote where w.City == "CityN" & w.LoaiPhieu == "LoaiJP" & w.Truong == "148" select w.Note).FirstOrDefault();
            txt_Truong_018.GotFocus += Txt_Truong_094_GotFocus;
            txt_Truong_148.GotFocus += Txt_Truong_094_GotFocus;
        }
        
        private void doimautrongkhoang(TextEdit txt, int so_nho, int so_lon)
        {
            txt.Text = txt.Text.Replace("ｧ", "ｱ").Replace("ｨ", "ｲ").Replace("ｩ", "ｳ").Replace("ｪ", "ｴ").Replace("ｫ", "ｵ").Replace("ｯ", "ﾂ").Replace("ｬ", "ﾔ").Replace("ｭ", "ﾕ").Replace("ｮ", "ﾖ").Replace("ｦ", "ｵ");
            if (!string.IsNullOrEmpty(txt.Text))
            {
                if (txt.Text.Length >= 2)
                {
                    if (txt.Text.Substring(txt.Text.Length - 2, 2) == "  ")
                    {
                        txt.BackColor = Color.Red;
                        txt.ForeColor = Color.White;
                        bSubmit = true;
                        txt.Properties.MaxLength = txt.Text.Length;
                    }
                    else
                    {
                        string result = lChar.Find(s => s == txt.Text[(txt.SelectionStart>0? txt.SelectionStart: txt.Text.Length) - 1].ToString());
                        if (string.IsNullOrEmpty(result))
                        {

                            string result1 = lChar.Find(s => s == txt.Text[(txt.SelectionStart > 0 ? txt.SelectionStart : txt.Text.Length) - 2].ToString() + txt.Text[(txt.SelectionStart > 0 ? txt.SelectionStart : txt.Text.Length) - 1].ToString());
                            if (string.IsNullOrEmpty(result1))
                            {
                                txt.BackColor = Color.Red;
                                txt.ForeColor = Color.White;
                                bSubmit = true;
                                txt.Properties.MaxLength = txt.Text.Length;
                            }
                            else
                            {
                                txt.BackColor = Color.White;
                                txt.ForeColor = Color.Black;
                                bSubmit = false;
                                txt.Properties.MaxLength = 0;
                            }
                        }
                        else
                        {
                            txt.BackColor = Color.White;
                            txt.ForeColor = Color.Black;
                            bSubmit = false;
                            txt.Properties.MaxLength = 0;
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
                        txt.Properties.MaxLength = txt.Text.Length;
                    }
                    else
                    {
                        txt.BackColor = Color.White;
                        txt.ForeColor = Color.Black;
                        bSubmit = false;
                        txt.Properties.MaxLength = 0;
                    }
                }
            }
            else
            {
                txt.BackColor = Color.White;
                txt.ForeColor = Color.Black;
                bSubmit = false;
                txt.Properties.MaxLength = 0;
            }
        }
        
        public void Save_CityN_JP(string Batch, string image)
        {
            Global.Db.Insert_DEJP_CityN(Batch, image, Global.StrUserName, Global.Token, Global.Version,
                     txt_Truong_018.Text.Replace("ｧ", "ｱ").Replace("ｨ", "ｲ").Replace("ｩ", "ｳ").Replace("ｪ", "ｴ").Replace("ｫ", "ｵ").Replace("ｯ", "ﾂ").Replace("ｬ", "ﾔ").Replace("ｭ", "ﾕ").Replace("ｮ", "ﾖ").Replace("ｦ", "ｵ"),
                     txt_Truong_148.Text);
        }

        public void Edit_Save_CityN_JP(string Batch, string image)
        {
            Global.Db.Sua_Va_Luu_DeJP_CityN(Batch, image, Global.StrUserName,Global.StrCity,
                     txt_Truong_018.Text.Replace("ｧ", "ｱ").Replace("ｨ", "ｲ").Replace("ｩ", "ｳ").Replace("ｪ", "ｴ").Replace("ｫ", "ｵ").Replace("ｯ", "ﾂ").Replace("ｬ", "ﾔ").Replace("ｭ", "ﾕ").Replace("ｮ", "ﾖ").Replace("ｦ", "ｵ"),
                     txt_Truong_148.Text);
        }
        private void txt_Truong_018_EditValueChanged(object sender, EventArgs e)
        {
            Changed?.Invoke(sender, e);
            doimautrongkhoang((TextEdit)sender, 0, 30);
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
        private void txt_Truong_148_EditValueChanged(object sender, EventArgs e)
        {
            Changed?.Invoke(sender, e);
            DoiMau( 0, 3, (TextEdit)sender);
        }
        private List<Category> category = new List<Category>();

        public class Category
        {
            public string Value_JP { get; set; }
            public string Value_SO { get; set; }
        }
        private void SetDataLookUpEdit()
        {
            category.Clear();
            category.Add(new Category() { Value_JP = "", Value_SO = "" });
            category.Add(new Category() { Value_JP = "千種区", Value_SO = "010" });
            category.Add(new Category() { Value_JP = "東区", Value_SO = "020" });
            category.Add(new Category() { Value_JP = "北区", Value_SO = "030" });
            category.Add(new Category() { Value_JP = "西区", Value_SO = "040" });
            category.Add(new Category() { Value_JP = "中村区", Value_SO = "050" });
            category.Add(new Category() { Value_JP = "中区", Value_SO = "060" });
            category.Add(new Category() { Value_JP = "昭和区", Value_SO = "070" });
            category.Add(new Category() { Value_JP = "瑞穂区", Value_SO = "080" });
            category.Add(new Category() { Value_JP = "熱田区", Value_SO = "090" });
            category.Add(new Category() { Value_JP = "中川区", Value_SO = "100" });
            category.Add(new Category() { Value_JP = "港区", Value_SO = "110" });
            category.Add(new Category() { Value_JP = "南区", Value_SO = "120" });
            category.Add(new Category() { Value_JP = "守山区", Value_SO = "130" });
            category.Add(new Category() { Value_JP = "緑区", Value_SO = "140" });
            category.Add(new Category() { Value_JP = "名東区", Value_SO = "150" });
            category.Add(new Category() { Value_JP = "天白区", Value_SO = "160" });
            category.Add(new Category() { Value_JP = "?", Value_SO = "?" });
        }

        private void txt_Truong_018_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong18 = txt_Truong_018.Text;
            Settings.Default.LoaiPhieu = "LoaiJP";
            Settings.Default.Save();
        }

        private void txt_Truong_148_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong148 = txt_Truong_148.Text;
            Settings.Default.LoaiPhieu = "LoaiJP";
            Settings.Default.Save();
        }
    }
}
