using BaoCaoLuong2018.BaoCaoLuonng2017.MyUserControl;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Linq;

namespace BaoCaoLuong2018.BaoCaoLuonng2017.MyUserControl
{
    public partial class uc_DEJP : UserControl
    {
        public event AllTextChange Changed;
        public event Focus_Text Focus;
        public bool bSubmit = false;

        //private List<string> lChar = new List<string>
        //                                { "ぁ",
        //                                "あ",
        //                                "ぃ",
        //                                "い",
        //                                "ぅ",
        //                                "う",
        //                                "ぇ",
        //                                "え",
        //                                "ぉ",
        //                                "お",
        //                                "か",
        //                                "が",
        //                                "き",
        //                                "ぎ",
        //                                "く",
        //                                "ぐ",
        //                                "け",
        //                                "げ",
        //                                "こ",
        //                                "ご",
        //                                "さ",
        //                                "ざ",
        //                                "し",
        //                                "じ",
        //                                "す",
        //                                "ず",
        //                                "せ",
        //                                "ぜ",
        //                                "そ",
        //                                "ぞ",
        //                                "た",
        //                                "だ",
        //                                "ち",
        //                                "ぢ",
        //                                "っ",
        //                                "つ",
        //                                "づ",
        //                                "て",
        //                                "で",
        //                                "と",
        //                                "ど",
        //                                "な",
        //                                "に",
        //                                "ぬ",
        //                                "ね",
        //                                "の",
        //                                "は",
        //                                "ば",
        //                                "ぱ",
        //                                "ひ",
        //                                "び",
        //                                "ぴ",
        //                                "ふ",
        //                                "ぶ",
        //                                "ぷ",
        //                                "へ",
        //                                "べ",
        //                                "ぺ",
        //                                "ほ",
        //                                "ぼ",
        //                                "ぽ",
        //                                "ま",
        //                                "み",
        //                                "む",
        //                                "め",
        //                                "も",
        //                                "ゃ",
        //                                "や",
        //                                "ゅ",
        //                                "ゆ",
        //                                "ょ",
        //                                "よ",
        //                                "ら",
        //                                "り",
        //                                "る",
        //                                "れ",
        //                                "ろ",
        //                                "ゎ",
        //                                "わ",
        //                                "ゐ",
        //                                "ゑ",
        //                                "を",
        //                                "ん",
        //                                "ァ",
        //                                "ア",
        //                                "ィ",
        //                                "イ",
        //                                "ゥ",
        //                                "ウ",
        //                                "ェ",
        //                                "エ",
        //                                "ォ",
        //                                "オ",
        //                                "カ",
        //                                "ガ",
        //                                "キ",
        //                                "ギ",
        //                                "ク",
        //                                "グ",
        //                                "ケ",
        //                                "ゲ",
        //                                "コ",
        //                                "ゴ",
        //                                "サ",
        //                                "ザ",
        //                                "シ",
        //                                "ジ",
        //                                "ス",
        //                                "ズ",
        //                                "セ",
        //                                "ゼ",
        //                                "ソ",
        //                                "ゾ",
        //                                "タ",
        //                                "ダ",
        //                                "チ",
        //                                "ヂ",
        //                                "ッ",
        //                                "ツ",
        //                                "ヅ",
        //                                "テ",
        //                                "デ",
        //                                "ト",
        //                                "ド",
        //                                "ナ",
        //                                "ニ",
        //                                "ヌ",
        //                                "ネ",
        //                                "ノ",
        //                                "ハ",
        //                                "バ",
        //                                "パ",
        //                                "ヒ",
        //                                "ビ",
        //                                "ピ",
        //                                "フ",
        //                                "ブ",
        //                                "プ",
        //                                "ヘ",
        //                                "ベ",
        //                                "ペ",
        //                                "ホ",
        //                                "ボ",
        //                                "ポ",
        //                                "マ",
        //                                "ミ",
        //                                "ム",
        //                                "メ",
        //                                "モ",
        //                                "ャ",
        //                                "ヤ",
        //                                "ュ",
        //                                "ユ",
        //                                "ョ",
        //                                "ヨ",
        //                                "ラ",
        //                                "リ",
        //                                "ル",
        //                                "レ",
        //                                "ロ",
        //                                "ヮ",
        //                                "ワ",
        //                                "ヰ",
        //                                "ヱ",
        //                                "ヲ",
        //                                "ン",
        //                                "ヴ",
        //                                "ヵ",
        //                                "ヶ",
        //                                "Ａ",
        //                                "Ｂ",
        //                                "Ｃ",
        //                                "Ｄ",
        //                                "Ｅ",
        //                                "Ｆ",
        //                                "Ｇ",
        //                                "Ｈ",
        //                                "Ｉ",
        //                                "Ｊ",
        //                                "Ｋ",
        //                                "Ｌ",
        //                                "Ｍ",
        //                                "Ｎ",
        //                                "Ｏ",
        //                                "Ｐ",
        //                                "Ｑ",
        //                                "Ｒ",
        //                                "Ｓ",
        //                                "Ｔ",
        //                                "Ｕ",
        //                                "Ｖ",
        //                                "Ｗ",
        //                                "Ｘ",
        //                                "Ｙ",
        //                                "Ｚ",
        //                                "ａ",
        //                                "ｂ",
        //                                "ｃ",
        //                                "ｄ",
        //                                "ｅ",
        //                                "ｆ",
        //                                "ｇ",
        //                                "ｈ",
        //                                "ｉ",
        //                                "ｊ",
        //                                "ｋ",
        //                                "ｌ",
        //                                "ｍ",
        //                                "ｎ",
        //                                "ｏ",
        //                                "ｐ",
        //                                "ｑ",
        //                                "ｒ",
        //                                "ｓ",
        //                                "ｔ",
        //                                "ｕ",
        //                                "ｖ",
        //                                "ｗ",
        //                                "ｘ",
        //                                "ｙ",
        //                                "ｚ",
        //                                "０",
        //                                "１",
        //                                "２",
        //                                "３",
        //                                "４",
        //                                "５",
        //                                "６",
        //                                "７",
        //                                "８",
        //                                "９",
        //                                "ｬ",
        //                                "ｭ",
        //                                "ｮ",
        //                                "ｧ",
        //                                "ｨ",
        //                                "ｩ",
        //                                "ｪ",
        //                                "ｫ",
        //                                "　",
        //                                "ｰ",
        //                                "ｯ"
        //                                };

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

        public uc_DEJP()
        {
            InitializeComponent();
        }

        private void uc_DEJP_Load(object sender, EventArgs e)
        {
            txt_Truong_003.Tag = (from w in Global.DataNote where w.City == "CityS" & w.LoaiPhieu == "JP" & w.Truong == "3" select w.Note).FirstOrDefault();
            txt_Truong_056.Tag = (from w in Global.DataNote where w.City == "CityS" & w.LoaiPhieu == "JP" & w.Truong == "56" select w.Note).FirstOrDefault();
            txt_Truong_060.Tag = (from w in Global.DataNote where w.City == "CityS" & w.LoaiPhieu == "JP" & w.Truong == "60" select w.Note).FirstOrDefault();
            txt_Truong_062.Tag = (from w in Global.DataNote where w.City == "CityS" & w.LoaiPhieu == "JP" & w.Truong == "62" select w.Note).FirstOrDefault();
            txt_Truong_064.Tag = (from w in Global.DataNote where w.City == "CityS" & w.LoaiPhieu == "JP" & w.Truong == "64" select w.Note).FirstOrDefault();
            txt_Truong_066.Tag = (from w in Global.DataNote where w.City == "CityS" & w.LoaiPhieu == "JP" & w.Truong == "66" select w.Note).FirstOrDefault();
            txt_Truong_068.Tag = (from w in Global.DataNote where w.City == "CityS" & w.LoaiPhieu == "JP" & w.Truong == "68" select w.Note).FirstOrDefault();
            txt_Truong_070.Tag = (from w in Global.DataNote where w.City == "CityS" & w.LoaiPhieu == "JP" & w.Truong == "70" select w.Note).FirstOrDefault();
            txt_Truong_072.Tag = (from w in Global.DataNote where w.City == "CityS" & w.LoaiPhieu == "JP" & w.Truong == "72" select w.Note).FirstOrDefault();
            txt_Truong_074.Tag = (from w in Global.DataNote where w.City == "CityS" & w.LoaiPhieu == "JP" & w.Truong == "74" select w.Note).FirstOrDefault();


            txt_Truong_003.GotFocus += Txt_Truong_001_GotFocus;
            txt_Truong_056.GotFocus += Txt_Truong_001_GotFocus;
            txt_Truong_060.GotFocus += Txt_Truong_001_GotFocus;
            txt_Truong_062.GotFocus += Txt_Truong_001_GotFocus;
            txt_Truong_064.GotFocus += Txt_Truong_001_GotFocus;
            txt_Truong_066.GotFocus += Txt_Truong_001_GotFocus;
            txt_Truong_068.GotFocus += Txt_Truong_001_GotFocus;
            txt_Truong_070.GotFocus += Txt_Truong_001_GotFocus;
            txt_Truong_072.GotFocus += Txt_Truong_001_GotFocus;
            txt_Truong_074.GotFocus += Txt_Truong_001_GotFocus;
        }
        private void Txt_Truong_001_GotFocus(object sender, EventArgs e)
        {
            Focus(((RichTextBox)sender)?.Name, ((RichTextBox)sender)?.Tag + "");
            ((RichTextBox)sender).SelectAll();
        }
        public void setRandom()
        {
            Random rd = new Random();
            txt_Truong_056.Text = rd.Next(40, 700).ToString();
        }

        public void ResetData()
        {
            txt_Truong_003.Text = string.Empty;
            txt_Truong_056.Text = string.Empty;
            txt_Truong_060.Text = string.Empty;
            txt_Truong_062.Text = string.Empty;
            txt_Truong_064.Text = string.Empty;
            txt_Truong_066.Text = string.Empty;
            txt_Truong_068.Text = string.Empty;
            txt_Truong_070.Text = string.Empty;
            txt_Truong_072.Text = string.Empty;
            txt_Truong_074.Text = string.Empty;

            txt_Truong_003.BackColor = Color.White;
            txt_Truong_056.BackColor = Color.White;
            txt_Truong_060.BackColor = Color.White;
            txt_Truong_062.BackColor = Color.White;
            txt_Truong_064.BackColor = Color.White;
            txt_Truong_066.BackColor = Color.White;
            txt_Truong_068.BackColor = Color.White;
            txt_Truong_070.BackColor = Color.White;
            txt_Truong_072.BackColor = Color.White;
            txt_Truong_074.BackColor = Color.White;

        }

        public bool IsEmpty()
        {
            if (string.IsNullOrEmpty(txt_Truong_003.Text) &&
                 string.IsNullOrEmpty(txt_Truong_056.Text) &&
                 string.IsNullOrEmpty(txt_Truong_060.Text) &&
                 string.IsNullOrEmpty(txt_Truong_062.Text) &&
                 string.IsNullOrEmpty(txt_Truong_064.Text) &&
                 string.IsNullOrEmpty(txt_Truong_066.Text) &&
                 string.IsNullOrEmpty(txt_Truong_068.Text) &&
                 string.IsNullOrEmpty(txt_Truong_070.Text) &&
                 string.IsNullOrEmpty(txt_Truong_072.Text) &&
                 string.IsNullOrEmpty(txt_Truong_074.Text)
                )
                return true;
            return false;
        }
        //private void doimautrongkhoang(TextEdit txt, int so_nho, int so_lon)
        //{
        //    if (!string.IsNullOrEmpty(txt.Text))
        //    {
        //        if (txt.Text.Length >= 2)
        //        {
        //            if (txt.Text.Substring(txt.Text.Length - 2, 2) == "  ")
        //            {
        //                txt.BackColor = Color.Red;
        //                txt.ForeColor = Color.White;
        //                bSubmit = true;
        //                txt.Properties.MaxLength = txt.Text.Length;
        //            }
        //            else
        //            {
        //                string result = lChar.Find(s => s == txt.Text[txt.Text.Length - 1].ToString());
        //                if (!string.IsNullOrEmpty(result))
        //                {
        //                    txt.BackColor = Color.Red;
        //                    txt.ForeColor = Color.White;
        //                    bSubmit = true;
        //                    txt.Properties.MaxLength = txt.Text.Length;
        //                }
        //                else
        //                {
        //                    txt.BackColor = Color.White;
        //                    txt.ForeColor = Color.Black;
        //                    bSubmit = false;
        //                    txt.Properties.MaxLength = 0;
        //                }
        //            }
        //        }
        //        else
        //        {
        //            string result = lChar.Find(s => s == txt.Text[txt.Text.Length - 1].ToString());
        //            if (!string.IsNullOrEmpty(result))
        //            {
        //                txt.BackColor = Color.Red;
        //                txt.ForeColor = Color.White;
        //                bSubmit = true;
        //                txt.Properties.MaxLength = txt.Text.Length;
        //            }
        //            else
        //            {
        //                txt.BackColor = Color.White;
        //                txt.ForeColor = Color.Black;
        //                bSubmit = false;
        //                txt.Properties.MaxLength = 0;
        //            }
        //        }
        //    }
        //    else
        //    {
        //        txt.BackColor = Color.White;
        //        txt.ForeColor = Color.Black;
        //        bSubmit = false;
        //        txt.Properties.MaxLength = 0;
        //    }
        //}
        private void doimautrongkhoang(RichTextBox txt, int so_nho, int so_lon)
        {
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

        //private void doimautrongkhoang(RichTextBox txt, int so_nho, int so_lon)
        //{
        //    if (txt.Text.Length > 0)
        //    {
        //        if (txt.Text != "?")
        //        {
        //            if (txt.Text.Substring(0, 1) == "-")
        //            {
        //                if (txt.Text.Length >= so_nho && txt.Text.Length <= so_lon + 1)
        //                {
        //                    txt.ForeColor = Color.Black;
        //                    txt.BackColor = Color.White;
        //                }
        //                else
        //                {
        //                    txt.ForeColor = Color.White;
        //                    txt.BackColor = Color.Red;
        //                }
        //            }
        //            else
        //            {
        //                if (txt.Text.Length >= so_nho && txt.Text.Length <= so_lon)
        //                {
        //                    txt.ForeColor = Color.Black;
        //                    txt.BackColor = Color.White;
        //                }
        //                else
        //                {
        //                    txt.ForeColor = Color.White;
        //                    txt.BackColor = Color.Red;
        //                }
        //            }
        //        }
        //        else
        //        {
        //            txt.ForeColor = Color.Black;
        //            txt.BackColor = Color.White;
        //        }
        //    }
        //    else
        //    {
        //        txt.ForeColor = Color.Black;
        //        txt.BackColor = Color.White;
        //    }
        //}

        private void txt_Truong_002_EditValueChanged(object sender, EventArgs e)
        {
            doimautrongkhoang((RichTextBox)sender, 0, 25);
            
            if (Changed != null)
                Changed(sender, e);
        }

        public void SaveData_DEJP(string idimage)
        {
            Global.db_BCL.Insert_DEJP(idimage, Global.StrBatch, Global.StrUsername, 
                                        txt_Truong_003.Text, 
                                        txt_Truong_056.Text,
                                        txt_Truong_060.Text,
                                        txt_Truong_062.Text,
                                        txt_Truong_064.Text,
                                        txt_Truong_066.Text,
                                        txt_Truong_068.Text,
                                        txt_Truong_070.Text,
                                        txt_Truong_072.Text,
                                        txt_Truong_074.Text
                                        );
        }

        private void labelControl8_Click(object sender, EventArgs e)
        {

        }

        private void txt_Truong_066_EditValueChanged(object sender, EventArgs e)
        {
            doimautrongkhoang((RichTextBox)sender, 0, 30);

            if (Changed != null)
                Changed(sender, e);
        }

        private void txt_Truong_060_EditValueChanged(object sender, EventArgs e)
        {
            doimautrongkhoang((RichTextBox)sender, 0, 30);

            if (Changed != null)
                Changed(sender, e);
        }

        private void txt_Truong_062_EditValueChanged(object sender, EventArgs e)
        {
            doimautrongkhoang((RichTextBox)sender, 0, 30);

            if (Changed != null)
                Changed(sender, e);
        }

        private void txt_Truong_064_EditValueChanged(object sender, EventArgs e)
        {
            doimautrongkhoang((RichTextBox)sender, 0, 30);

            if (Changed != null)
                Changed(sender, e);
        }

        private void txt_Truong_056_EditValueChanged(object sender, EventArgs e)
        {
            doimautrongkhoang((RichTextBox)sender, 0, 30);

            if (Changed != null)
                Changed(sender, e);
        }

        private void txt_Truong_068_EditValueChanged(object sender, EventArgs e)
        {
            doimautrongkhoang((RichTextBox)sender, 0, 30);

            if (Changed != null)
                Changed(sender, e);
        }

        private void txt_Truong_070_EditValueChanged(object sender, EventArgs e)
        {
            doimautrongkhoang((RichTextBox)sender, 0, 30);

            if (Changed != null)
                Changed(sender, e);
        }

        private void txt_Truong_072_EditValueChanged(object sender, EventArgs e)
        {
            doimautrongkhoang((RichTextBox)sender, 0, 30);

            if (Changed != null)
                Changed(sender, e);
        }

        private void txt_Truong_074_EditValueChanged(object sender, EventArgs e)
        {
            doimautrongkhoang((RichTextBox)sender, 0, 30);

            if (Changed != null)
                Changed(sender, e);
        }

        private void txt_Truong_003_KeyDown(object sender, KeyEventArgs e)
        {
            if((((RichTextBox)sender).Name== "txt_Truong_003"|| ((RichTextBox)sender).Name == "txt_Truong_056") && (e.KeyCode==Keys.Down || e.KeyCode == Keys.Right))
            {
                SendKeys.Send("{Tab}");
            }
            else if (((RichTextBox)sender).Name == "txt_Truong_003"&& (e.KeyCode == Keys.Up || e.KeyCode == Keys.Left))
            { }
            else if (((RichTextBox)sender).Name == "txt_Truong_056" && (e.KeyCode == Keys.Up || e.KeyCode == Keys.Left))
            {
                SendKeys.Send("+{Tab}");
            }
            else if ((((RichTextBox)sender).Name == "txt_Truong_060" && e.KeyCode == Keys.Up))
            {
                SendKeys.Send("+{Tab}");
            }
            else if (((RichTextBox)sender).Name == "txt_Truong_074" && (e.KeyCode == Keys.Down || e.KeyCode == Keys.Right))
            { }
            else if (((RichTextBox)sender).Name == "txt_Truong_066" && e.KeyCode == Keys.Down)
            { }
            else if(e.KeyCode == Keys.Right)
            {
                SendKeys.Send("{Tab}");
            }
            else if (e.KeyCode == Keys.Left)
            {
                SendKeys.Send("+{Tab}");
            }
            else if (e.KeyCode == Keys.Down)
            {
                SendKeys.Send("{Tab}");
                SendKeys.Send("{Tab}");
            }
            else if (e.KeyCode == Keys.Up)
            {
                SendKeys.Send("+{Tab}");
                SendKeys.Send("+{Tab}");
            }
        }
    }
}