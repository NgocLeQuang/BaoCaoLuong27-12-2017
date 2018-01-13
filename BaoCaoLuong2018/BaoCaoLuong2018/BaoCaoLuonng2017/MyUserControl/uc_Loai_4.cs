using BaoCaoLuong2018.BaoCaoLuonng2017.MyUserControl;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;

namespace BaoCaoLuong2018.BaoCaoLuonng2017.MyUserControl
{
    public partial class uc_Loai_4 : UserControl
    {
        public event Focus_Text Focus;
        public event AllTextChange Changed;

        private List<Category> category = new List<Category>();

        public uc_Loai_4()
        {
            InitializeComponent();
        }

        public bool bSubmit = false;

        private List<string> lChar = new List<string>
                                        { "ぁ",
                                        "あ",
                                        "ぃ",
                                        "い",
                                        "ぅ",
                                        "う",
                                        "ぇ",
                                        "え",
                                        "ぉ",
                                        "お",
                                        "か",
                                        "が",
                                        "き",
                                        "ぎ",
                                        "く",
                                        "ぐ",
                                        "け",
                                        "げ",
                                        "こ",
                                        "ご",
                                        "さ",
                                        "ざ",
                                        "し",
                                        "じ",
                                        "す",
                                        "ず",
                                        "せ",
                                        "ぜ",
                                        "そ",
                                        "ぞ",
                                        "た",
                                        "だ",
                                        "ち",
                                        "ぢ",
                                        "っ",
                                        "つ",
                                        "づ",
                                        "て",
                                        "で",
                                        "と",
                                        "ど",
                                        "な",
                                        "に",
                                        "ぬ",
                                        "ね",
                                        "の",
                                        "は",
                                        "ば",
                                        "ぱ",
                                        "ひ",
                                        "び",
                                        "ぴ",
                                        "ふ",
                                        "ぶ",
                                        "ぷ",
                                        "へ",
                                        "べ",
                                        "ぺ",
                                        "ほ",
                                        "ぼ",
                                        "ぽ",
                                        "ま",
                                        "み",
                                        "む",
                                        "め",
                                        "も",
                                        "ゃ",
                                        "や",
                                        "ゅ",
                                        "ゆ",
                                        "ょ",
                                        "よ",
                                        "ら",
                                        "り",
                                        "る",
                                        "れ",
                                        "ろ",
                                        "ゎ",
                                        "わ",
                                        "ゐ",
                                        "ゑ",
                                        "を",
                                        "ん",
                                        "ァ",
                                        "ア",
                                        "ィ",
                                        "イ",
                                        "ゥ",
                                        "ウ",
                                        "ェ",
                                        "エ",
                                        "ォ",
                                        "オ",
                                        "カ",
                                        "ガ",
                                        "キ",
                                        "ギ",
                                        "ク",
                                        "グ",
                                        "ケ",
                                        "ゲ",
                                        "コ",
                                        "ゴ",
                                        "サ",
                                        "ザ",
                                        "シ",
                                        "ジ",
                                        "ス",
                                        "ズ",
                                        "セ",
                                        "ゼ",
                                        "ソ",
                                        "ゾ",
                                        "タ",
                                        "ダ",
                                        "チ",
                                        "ヂ",
                                        "ッ",
                                        "ツ",
                                        "ヅ",
                                        "テ",
                                        "デ",
                                        "ト",
                                        "ド",
                                        "ナ",
                                        "ニ",
                                        "ヌ",
                                        "ネ",
                                        "ノ",
                                        "ハ",
                                        "バ",
                                        "パ",
                                        "ヒ",
                                        "ビ",
                                        "ピ",
                                        "フ",
                                        "ブ",
                                        "プ",
                                        "ヘ",
                                        "ベ",
                                        "ペ",
                                        "ホ",
                                        "ボ",
                                        "ポ",
                                        "マ",
                                        "ミ",
                                        "ム",
                                        "メ",
                                        "モ",
                                        "ャ",
                                        "ヤ",
                                        "ュ",
                                        "ユ",
                                        "ョ",
                                        "ヨ",
                                        "ラ",
                                        "リ",
                                        "ル",
                                        "レ",
                                        "ロ",
                                        "ヮ",
                                        "ワ",
                                        "ヰ",
                                        "ヱ",
                                        "ヲ",
                                        "ン",
                                        "ヴ",
                                        "ヵ",
                                        "ヶ",
                                        "Ａ",
                                        "Ｂ",
                                        "Ｃ",
                                        "Ｄ",
                                        "Ｅ",
                                        "Ｆ",
                                        "Ｇ",
                                        "Ｈ",
                                        "Ｉ",
                                        "Ｊ",
                                        "Ｋ",
                                        "Ｌ",
                                        "Ｍ",
                                        "Ｎ",
                                        "Ｏ",
                                        "Ｐ",
                                        "Ｑ",
                                        "Ｒ",
                                        "Ｓ",
                                        "Ｔ",
                                        "Ｕ",
                                        "Ｖ",
                                        "Ｗ",
                                        "Ｘ",
                                        "Ｙ",
                                        "Ｚ",
                                        "ａ",
                                        "ｂ",
                                        "ｃ",
                                        "ｄ",
                                        "ｅ",
                                        "ｆ",
                                        "ｇ",
                                        "ｈ",
                                        "ｉ",
                                        "ｊ",
                                        "ｋ",
                                        "ｌ",
                                        "ｍ",
                                        "ｎ",
                                        "ｏ",
                                        "ｐ",
                                        "ｑ",
                                        "ｒ",
                                        "ｓ",
                                        "ｔ",
                                        "ｕ",
                                        "ｖ",
                                        "ｗ",
                                        "ｘ",
                                        "ｙ",
                                        "ｚ",
                                        "０",
                                        "１",
                                        "２",
                                        "３",
                                        "４",
                                        "５",
                                        "６",
                                        "７",
                                        "８",
                                        "９",
                                        "ｬ",
                                        "ｭ",
                                        "ｮ",
                                        "ｧ",
                                        "ｨ",
                                        "ｩ",
                                        "ｪ",
                                        "ｫ",
                                        "　",
                                        "ｰ",
                                        "ｯ"
                                        };

        private void uc_Loai_4_Load(object sender, EventArgs e)
        {
            SetDataLookUpEdit();
            txt_Truong_052.Properties.DataSource = category;
            txt_Truong_052.Properties.DisplayMember = "Value_SO";
            txt_Truong_052.Properties.ValueMember = "Value_SO";

            txt_Truong_055.Properties.DataSource = category;
            txt_Truong_055.Properties.DisplayMember = "Value_SO";
            txt_Truong_055.Properties.ValueMember = "Value_SO";

            txt_Truong_001.Tag = (from w in Global.DataNote where w.City == "CityS" & w.LoaiPhieu == "Loai4" & w.Truong == "1" select w.Note).FirstOrDefault();
            txt_Truong_002.Tag = (from w in Global.DataNote where w.City == "CityS" & w.LoaiPhieu == "Loai4" & w.Truong == "2" select w.Note).FirstOrDefault();
            txt_Truong_004.Tag = (from w in Global.DataNote where w.City == "CityS" & w.LoaiPhieu == "Loai4" & w.Truong == "4" select w.Note).FirstOrDefault();
            txt_Truong_005.Tag = (from w in Global.DataNote where w.City == "CityS" & w.LoaiPhieu == "Loai4" & w.Truong == "5" select w.Note).FirstOrDefault();
            txt_Truong_006.Tag = (from w in Global.DataNote where w.City == "CityS" & w.LoaiPhieu == "Loai4" & w.Truong == "6" select w.Note).FirstOrDefault();
            txt_Truong_007.Tag = (from w in Global.DataNote where w.City == "CityS" & w.LoaiPhieu == "Loai4" & w.Truong == "7" select w.Note).FirstOrDefault();
            txt_Truong_008.Tag = (from w in Global.DataNote where w.City == "CityS" & w.LoaiPhieu == "Loai4" & w.Truong == "8" select w.Note).FirstOrDefault();
            txt_Truong_009.Tag = (from w in Global.DataNote where w.City == "CityS" & w.LoaiPhieu == "Loai4" & w.Truong == "9" select w.Note).FirstOrDefault();
            txt_Truong_010.Tag = (from w in Global.DataNote where w.City == "CityS" & w.LoaiPhieu == "Loai4" & w.Truong == "10" select w.Note).FirstOrDefault();
            txt_Truong_011.Tag = (from w in Global.DataNote where w.City == "CityS" & w.LoaiPhieu == "Loai4" & w.Truong == "11" select w.Note).FirstOrDefault();
            txt_Truong_012.Tag = (from w in Global.DataNote where w.City == "CityS" & w.LoaiPhieu == "Loai4" & w.Truong == "12" select w.Note).FirstOrDefault();
            txt_Truong_013.Tag = (from w in Global.DataNote where w.City == "CityS" & w.LoaiPhieu == "Loai4" & w.Truong == "13" select w.Note).FirstOrDefault();
            txt_Truong_014.Tag = (from w in Global.DataNote where w.City == "CityS" & w.LoaiPhieu == "Loai4" & w.Truong == "14" select w.Note).FirstOrDefault();
            txt_Truong_015.Tag = (from w in Global.DataNote where w.City == "CityS" & w.LoaiPhieu == "Loai4" & w.Truong == "15" select w.Note).FirstOrDefault();
            txt_Truong_016.Tag = (from w in Global.DataNote where w.City == "CityS" & w.LoaiPhieu == "Loai4" & w.Truong == "16" select w.Note).FirstOrDefault();
            txt_Truong_017.Tag = (from w in Global.DataNote where w.City == "CityS" & w.LoaiPhieu == "Loai4" & w.Truong == "17" select w.Note).FirstOrDefault();
            txt_Truong_018.Tag = (from w in Global.DataNote where w.City == "CityS" & w.LoaiPhieu == "Loai4" & w.Truong == "18" select w.Note).FirstOrDefault();
            txt_Truong_019.Tag = (from w in Global.DataNote where w.City == "CityS" & w.LoaiPhieu == "Loai4" & w.Truong == "19" select w.Note).FirstOrDefault();
            txt_Truong_020.Tag = (from w in Global.DataNote where w.City == "CityS" & w.LoaiPhieu == "Loai4" & w.Truong == "20" select w.Note).FirstOrDefault();
            txt_Truong_021.Tag = (from w in Global.DataNote where w.City == "CityS" & w.LoaiPhieu == "Loai4" & w.Truong == "21" select w.Note).FirstOrDefault();
            txt_Truong_022.Tag = (from w in Global.DataNote where w.City == "CityS" & w.LoaiPhieu == "Loai4" & w.Truong == "22" select w.Note).FirstOrDefault();
            txt_Truong_023.Tag = (from w in Global.DataNote where w.City == "CityS" & w.LoaiPhieu == "Loai4" & w.Truong == "23" select w.Note).FirstOrDefault();
            txt_Truong_024.Tag = (from w in Global.DataNote where w.City == "CityS" & w.LoaiPhieu == "Loai4" & w.Truong == "24" select w.Note).FirstOrDefault();
            txt_Truong_025.Tag = (from w in Global.DataNote where w.City == "CityS" & w.LoaiPhieu == "Loai4" & w.Truong == "25" select w.Note).FirstOrDefault();
            txt_Truong_026.Tag = (from w in Global.DataNote where w.City == "CityS" & w.LoaiPhieu == "Loai4" & w.Truong == "26" select w.Note).FirstOrDefault();
            txt_Truong_027.Tag = (from w in Global.DataNote where w.City == "CityS" & w.LoaiPhieu == "Loai4" & w.Truong == "27" select w.Note).FirstOrDefault();
            txt_Truong_028.Tag = (from w in Global.DataNote where w.City == "CityS" & w.LoaiPhieu == "Loai4" & w.Truong == "28" select w.Note).FirstOrDefault();
            txt_Truong_029.Tag = (from w in Global.DataNote where w.City == "CityS" & w.LoaiPhieu == "Loai4" & w.Truong == "29" select w.Note).FirstOrDefault();
            txt_Truong_030.Tag = (from w in Global.DataNote where w.City == "CityS" & w.LoaiPhieu == "Loai4" & w.Truong == "30" select w.Note).FirstOrDefault();
            txt_Truong_031.Tag = (from w in Global.DataNote where w.City == "CityS" & w.LoaiPhieu == "Loai4" & w.Truong == "31" select w.Note).FirstOrDefault();
            txt_Truong_032.Tag = (from w in Global.DataNote where w.City == "CityS" & w.LoaiPhieu == "Loai4" & w.Truong == "32" select w.Note).FirstOrDefault();
            txt_Truong_033.Tag = (from w in Global.DataNote where w.City == "CityS" & w.LoaiPhieu == "Loai4" & w.Truong == "33" select w.Note).FirstOrDefault();
            txt_Truong_034.Tag = (from w in Global.DataNote where w.City == "CityS" & w.LoaiPhieu == "Loai4" & w.Truong == "34" select w.Note).FirstOrDefault();
            txt_Truong_035.Tag = (from w in Global.DataNote where w.City == "CityS" & w.LoaiPhieu == "Loai4" & w.Truong == "35" select w.Note).FirstOrDefault();
            txt_Truong_036.Tag = (from w in Global.DataNote where w.City == "CityS" & w.LoaiPhieu == "Loai4" & w.Truong == "36" select w.Note).FirstOrDefault();
            txt_Truong_037.Tag = (from w in Global.DataNote where w.City == "CityS" & w.LoaiPhieu == "Loai4" & w.Truong == "37" select w.Note).FirstOrDefault();
            txt_Truong_038.Tag = (from w in Global.DataNote where w.City == "CityS" & w.LoaiPhieu == "Loai4" & w.Truong == "38" select w.Note).FirstOrDefault();
            txt_Truong_039.Tag = (from w in Global.DataNote where w.City == "CityS" & w.LoaiPhieu == "Loai4" & w.Truong == "39" select w.Note).FirstOrDefault();
            txt_Truong_040_1.Tag = txt_Truong_040_2.Tag = txt_Truong_040_3.Tag = txt_Truong_040_4.Tag = (from w in Global.DataNote where w.City == "CityS" & w.LoaiPhieu == "Loai4" & w.Truong == "40" select w.Note).FirstOrDefault();
            txt_Truong_041.Tag = (from w in Global.DataNote where w.City == "CityS" & w.LoaiPhieu == "Loai4" & w.Truong == "41" select w.Note).FirstOrDefault();
            txt_Truong_044_1.Tag = txt_Truong_044_2.Tag = (from w in Global.DataNote where w.City == "CityS" & w.LoaiPhieu == "Loai4" & w.Truong == "44" select w.Note).FirstOrDefault();
            txt_Truong_045.Tag = (from w in Global.DataNote where w.City == "CityS" & w.LoaiPhieu == "Loai4" & w.Truong == "45" select w.Note).FirstOrDefault();
            txt_Truong_046.Tag = (from w in Global.DataNote where w.City == "CityS" & w.LoaiPhieu == "Loai4" & w.Truong == "46" select w.Note).FirstOrDefault();
            txt_Truong_047.Tag = (from w in Global.DataNote where w.City == "CityS" & w.LoaiPhieu == "Loai4" & w.Truong == "47" select w.Note).FirstOrDefault();
            txt_Truong_048.Tag = (from w in Global.DataNote where w.City == "CityS" & w.LoaiPhieu == "Loai4" & w.Truong == "48" select w.Note).FirstOrDefault();
            txt_Truong_049.Tag = (from w in Global.DataNote where w.City == "CityS" & w.LoaiPhieu == "Loai4" & w.Truong == "49" select w.Note).FirstOrDefault();
            txt_Truong_050.Tag = (from w in Global.DataNote where w.City == "CityS" & w.LoaiPhieu == "Loai4" & w.Truong == "50" select w.Note).FirstOrDefault();
            txt_Truong_051_1.Tag = txt_Truong_051_2.Tag = txt_Truong_051_3.Tag = (from w in Global.DataNote where w.City == "CityS" & w.LoaiPhieu == "Loai4" & w.Truong == "51" select w.Note).FirstOrDefault();
            txt_Truong_052.Tag = (from w in Global.DataNote where w.City == "CityS" & w.LoaiPhieu == "Loai4" & w.Truong == "52" select w.Note).FirstOrDefault();
            txt_Truong_053.Tag = (from w in Global.DataNote where w.City == "CityS" & w.LoaiPhieu == "Loai4" & w.Truong == "53" select w.Note).FirstOrDefault();
            txt_Truong_054_1.Tag = txt_Truong_054_2.Tag = txt_Truong_054_3.Tag = (from w in Global.DataNote where w.City == "CityS" & w.LoaiPhieu == "Loai4" & w.Truong == "54" select w.Note).FirstOrDefault();
            txt_Truong_055.Tag = (from w in Global.DataNote where w.City == "CityS" & w.LoaiPhieu == "Loai4" & w.Truong == "55" select w.Note).FirstOrDefault();
            txt_Truong_057.Tag = (from w in Global.DataNote where w.City == "CityS" & w.LoaiPhieu == "Loai4" & w.Truong == "57" select w.Note).FirstOrDefault();
            txt_Truong_058.Tag = (from w in Global.DataNote where w.City == "CityS" & w.LoaiPhieu == "Loai4" & w.Truong == "58" select w.Note).FirstOrDefault();
            txt_Truong_059.Tag = (from w in Global.DataNote where w.City == "CityS" & w.LoaiPhieu == "Loai4" & w.Truong == "59" select w.Note).FirstOrDefault();
            txt_Truong_061.Tag = (from w in Global.DataNote where w.City == "CityS" & w.LoaiPhieu == "Loai4" & w.Truong == "61" select w.Note).FirstOrDefault();
            txt_Truong_063.Tag = (from w in Global.DataNote where w.City == "CityS" & w.LoaiPhieu == "Loai4" & w.Truong == "63" select w.Note).FirstOrDefault();
            txt_Truong_065.Tag = (from w in Global.DataNote where w.City == "CityS" & w.LoaiPhieu == "Loai4" & w.Truong == "65" select w.Note).FirstOrDefault();
            txt_Truong_067.Tag = (from w in Global.DataNote where w.City == "CityS" & w.LoaiPhieu == "Loai4" & w.Truong == "67" select w.Note).FirstOrDefault();
            txt_Truong_069.Tag = (from w in Global.DataNote where w.City == "CityS" & w.LoaiPhieu == "Loai4" & w.Truong == "69" select w.Note).FirstOrDefault();
            txt_Truong_071.Tag = (from w in Global.DataNote where w.City == "CityS" & w.LoaiPhieu == "Loai4" & w.Truong == "71" select w.Note).FirstOrDefault();
            txt_Truong_073.Tag = (from w in Global.DataNote where w.City == "CityS" & w.LoaiPhieu == "Loai4" & w.Truong == "73" select w.Note).FirstOrDefault();
            txt_Truong_075.Tag = (from w in Global.DataNote where w.City == "CityS" & w.LoaiPhieu == "Loai4" & w.Truong == "75" select w.Note).FirstOrDefault();
            
            txt_Truong_001.GotFocus += Txt_Truong_001_1_GotFocus;
            txt_Truong_002.GotFocus += Txt_Truong_001_1_GotFocus;
            txt_Truong_004.GotFocus += Txt_Truong_001_1_GotFocus;
            txt_Truong_005.GotFocus += Txt_Truong_001_1_GotFocus;
            txt_Truong_006.GotFocus += Txt_Truong_001_1_GotFocus;
            txt_Truong_007.GotFocus += Txt_Truong_001_1_GotFocus;
            txt_Truong_008.GotFocus += Txt_Truong_001_1_GotFocus;
            txt_Truong_009.GotFocus += Txt_Truong_001_1_GotFocus;
            txt_Truong_010.GotFocus += Txt_Truong_001_1_GotFocus;
            txt_Truong_011.GotFocus += Txt_Truong_001_1_GotFocus;
            txt_Truong_012.GotFocus += Txt_Truong_001_1_GotFocus;
            txt_Truong_013.GotFocus += Txt_Truong_001_1_GotFocus;
            txt_Truong_014.GotFocus += Txt_Truong_001_1_GotFocus;
            txt_Truong_015.GotFocus += Txt_Truong_001_1_GotFocus;
            txt_Truong_016.GotFocus += Txt_Truong_001_1_GotFocus;
            txt_Truong_017.GotFocus += Txt_Truong_001_1_GotFocus;
            txt_Truong_018.GotFocus += Txt_Truong_001_1_GotFocus;
            txt_Truong_019.GotFocus += Txt_Truong_001_1_GotFocus;
            txt_Truong_020.GotFocus += Txt_Truong_001_1_GotFocus;
            txt_Truong_021.GotFocus += Txt_Truong_001_1_GotFocus;
            txt_Truong_022.GotFocus += Txt_Truong_001_1_GotFocus;
            txt_Truong_023.GotFocus += Txt_Truong_001_1_GotFocus;
            txt_Truong_024.GotFocus += Txt_Truong_001_1_GotFocus;
            txt_Truong_025.GotFocus += Txt_Truong_001_1_GotFocus;
            txt_Truong_026.GotFocus += Txt_Truong_001_1_GotFocus;
            txt_Truong_027.GotFocus += Txt_Truong_001_1_GotFocus;
            txt_Truong_028.GotFocus += Txt_Truong_001_1_GotFocus;
            txt_Truong_029.GotFocus += Txt_Truong_001_1_GotFocus;
            txt_Truong_030.GotFocus += Txt_Truong_001_1_GotFocus;
            txt_Truong_031.GotFocus += Txt_Truong_001_1_GotFocus;
            txt_Truong_032.GotFocus += Txt_Truong_001_1_GotFocus;
            txt_Truong_033.GotFocus += Txt_Truong_001_1_GotFocus;
            txt_Truong_034.GotFocus += Txt_Truong_001_1_GotFocus;
            txt_Truong_035.GotFocus += Txt_Truong_001_1_GotFocus;

            txt_Truong_036.GotFocus += Txt_Truong_001_1_GotFocus;
            txt_Truong_037.GotFocus += Txt_Truong_001_1_GotFocus;
            txt_Truong_040_1.GotFocus += Txt_Truong_001_1_GotFocus;
            txt_Truong_040_2.GotFocus += Txt_Truong_001_1_GotFocus;
            txt_Truong_040_3.GotFocus += Txt_Truong_001_1_GotFocus;
            txt_Truong_040_4.GotFocus += Txt_Truong_001_1_GotFocus;
            txt_Truong_041.GotFocus += Txt_Truong_001_1_GotFocus;
            txt_Truong_044_1.GotFocus += Txt_Truong_001_1_GotFocus;
            txt_Truong_044_2.GotFocus += Txt_Truong_001_1_GotFocus;
            txt_Truong_045.GotFocus += Txt_Truong_001_1_GotFocus;
            txt_Truong_046.GotFocus += Txt_Truong_001_1_GotFocus;
            txt_Truong_047.GotFocus += Txt_Truong_001_1_GotFocus;
            txt_Truong_048.GotFocus += Txt_Truong_001_1_GotFocus;
            txt_Truong_049.GotFocus += Txt_Truong_001_1_GotFocus;
            txt_Truong_050.GotFocus += Txt_Truong_001_1_GotFocus;
            txt_Truong_051_1.GotFocus += Txt_Truong_001_1_GotFocus;
            txt_Truong_051_2.GotFocus += Txt_Truong_001_1_GotFocus;
            txt_Truong_051_3.GotFocus += Txt_Truong_001_1_GotFocus;
            txt_Truong_052.GotFocus += Txt_Truong_001_1_GotFocus;
            txt_Truong_053.GotFocus += Txt_Truong_001_1_GotFocus;
            txt_Truong_054_1.GotFocus += Txt_Truong_001_1_GotFocus;
            txt_Truong_054_2.GotFocus += Txt_Truong_001_1_GotFocus;
            txt_Truong_054_3.GotFocus += Txt_Truong_001_1_GotFocus;

            txt_Truong_055.GotFocus += Txt_Truong_001_1_GotFocus;
            txt_Truong_057.GotFocus += Txt_Truong_001_1_GotFocus;
            txt_Truong_058.GotFocus += Txt_Truong_001_1_GotFocus;
            txt_Truong_059.GotFocus += Txt_Truong_001_1_GotFocus;
            txt_Truong_061.GotFocus += Txt_Truong_001_1_GotFocus;
            txt_Truong_063.GotFocus += Txt_Truong_001_1_GotFocus;
            txt_Truong_065.GotFocus += Txt_Truong_001_1_GotFocus;
            txt_Truong_067.GotFocus += Txt_Truong_001_1_GotFocus;
            txt_Truong_069.GotFocus += Txt_Truong_001_1_GotFocus;
            txt_Truong_071.GotFocus += Txt_Truong_001_1_GotFocus;
            txt_Truong_073.GotFocus += Txt_Truong_001_1_GotFocus;
            txt_Truong_075.GotFocus += Txt_Truong_001_1_GotFocus;
        }
        public bool CheckSubmit()
        {
            if (!string.IsNullOrEmpty(txt_Truong_020.Text) & string.IsNullOrEmpty(txt_Truong_021.Text))
                return false;
            else if (!string.IsNullOrEmpty(txt_Truong_020.Text) &
                    !string.IsNullOrEmpty(txt_Truong_021.Text) &
                    txt_Truong_020.Text.IndexOf("?") < 0 &
                    txt_Truong_021.Text.IndexOf("?") < 0)
            {
                if (Double.Parse(txt_Truong_020.Text.Replace(",", "")) > Double.Parse(txt_Truong_021.Text.Replace(",", "")))
                    return false;
                else
                    return true;
            }
            else
                return true;
        }
        //private void Txt_Truong_158_LostFocus(object sender, EventArgs e)
        //{
        //    if (((TextEdit)(sender)).BackColor == Color.LimeGreen)
        //    {
        //        //MessageBox.Show("Bạn nhập không đúng công thức, Vui lòng kiểm tra lại.");// \r\nYes = Nhập Lại\r\nNo = Nhập ô khác", "Thông báo dữ liệu không đúng", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
        //    }
        //}

        private void Txt_Truong_001_1_GotFocus(object sender, EventArgs e)
        {
            Focus(((TextEdit)sender)?.Name, ((TextEdit)sender)?.Tag + "");
            ((TextEdit)sender).SelectAll();
        }

        public class Category
        {
            public string Value_JP { get; set; }
            public string Value_SO { get; set; }
        }

        private void SetDataLookUpEdit()
        {
            category.Add(new Category() { Value_JP = "", Value_SO = "" });
            category.Add(new Category() { Value_JP = "住", Value_SO = "01" });
            category.Add(new Category() { Value_JP = "認", Value_SO = "02" });
            category.Add(new Category() { Value_JP = "増", Value_SO = "03" });
            category.Add(new Category() { Value_JP = "震", Value_SO = "04" });
            category.Add(new Category() { Value_JP = "住（特）", Value_SO = "11" });
            category.Add(new Category() { Value_JP = "認（特）", Value_SO = "12" });
            category.Add(new Category() { Value_JP = "増（特）", Value_SO = "13" });
            category.Add(new Category() { Value_JP = "震（特）", Value_SO = "14" });
            category.Add(new Category() { Value_JP = "特", Value_SO = "11" });
            category.Add(new Category() { Value_JP = "特定", Value_SO = "11" });
            category.Add(new Category() { Value_JP = "?", Value_SO = "?" });
        }

        public void ResetData()
        {
            textEdit1.Text = "";
            textEdit2.Text = "";
            textEdit3.Text = "";
            textEdit4.Text = "";
            txt_Truong_001.Text = "";
            txt_Truong_002.Text = "";
            txt_Truong_004.Text = "";
            txt_Truong_005.Text = "";
            txt_Truong_006.Text = "";
            txt_Truong_007.Text = "";
            txt_Truong_008.Text = "";
            txt_Truong_009.Text = "";
            txt_Truong_010.Text = "";
            txt_Truong_011.Text = "";
            txt_Truong_012.Text = "";
            txt_Truong_013.Text = "";
            txt_Truong_014.Text = "";
            txt_Truong_015.Text = "";
            txt_Truong_016.Text = "";
            txt_Truong_017.Text = "";
            txt_Truong_018.Text = "";
            txt_Truong_019.Text = "";
            txt_Truong_020.Text = "";
            txt_Truong_021.Text = "";
            txt_Truong_022.Text = "";
            txt_Truong_023.Text = "";
            txt_Truong_024.Text = "";
            txt_Truong_025.Text = "";
            txt_Truong_026.Text = "";
            txt_Truong_027.Text = "";
            txt_Truong_028.Text = "";
            txt_Truong_029.Text = "";
            txt_Truong_030.Text = "";
            txt_Truong_031.Text = "";
            txt_Truong_032.Text = "";
            txt_Truong_033.Text = "";
            txt_Truong_034.Text = "";
            txt_Truong_035.Text = "";
            txt_Truong_036.Text = "";
            txt_Truong_037.Text = "";
            txt_Truong_038.Text = "";
            txt_Truong_039.Text = "";
            txt_Truong_040_1.Text = "";
            txt_Truong_040_2.Text = "";
            txt_Truong_040_3.Text = "";
            txt_Truong_040_4.Text = "";
            txt_Truong_041.Text = "";
            txt_Truong_042.Text = "";
            txt_Truong_043.Text = "";
            txt_Truong_044_1.Text = "";
            txt_Truong_044_2.Text = "";
            txt_Truong_045.Text = "";
            txt_Truong_046.Text = "";
            txt_Truong_047.Text = "";
            txt_Truong_048.Text = "";
            txt_Truong_049.Text = "";
            txt_Truong_050.Text = "";
            txt_Truong_051_1.Text = "";
            txt_Truong_051_2.Text = "";
            txt_Truong_051_3.Text = "";
            txt_Truong_052.ItemIndex =0;
            txt_Truong_053.Text = "";
            txt_Truong_054_1.Text = "";
            txt_Truong_054_2.Text = "";
            txt_Truong_054_3.Text = "";
            txt_Truong_055.ItemIndex =0;
            txt_Truong_057.Text = "";
            txt_Truong_058.Text = "";
            txt_Truong_059.Text = "";
            txt_Truong_061.Text = "";
            txt_Truong_063.Text = "";
            txt_Truong_065.Text = "";
            txt_Truong_067.Text = "";
            txt_Truong_069.Text = "";
            txt_Truong_071.Text = "";
            txt_Truong_073.Text = "";
            txt_Truong_075.Text = "";
            
            txt_Truong_015.BackColor = Color.White;
            txt_Truong_016.BackColor = Color.White;
            txt_Truong_017.BackColor = Color.White;
            txt_Truong_018.BackColor = Color.White;
            txt_Truong_019.BackColor = Color.White;
            txt_Truong_020.BackColor = Color.White;
            txt_Truong_021.BackColor = Color.White;
            txt_Truong_022.BackColor = Color.White;
            txt_Truong_023.BackColor = Color.White;
            txt_Truong_024.BackColor = Color.White;
            txt_Truong_025.BackColor = Color.White;
            txt_Truong_026.BackColor = Color.White;
            txt_Truong_027.BackColor = Color.White;
            txt_Truong_028.BackColor = Color.White;
            txt_Truong_029.BackColor = Color.White;
            txt_Truong_030.BackColor = Color.White;
            txt_Truong_031.BackColor = Color.White;
            txt_Truong_032.BackColor = Color.White;
            txt_Truong_033.BackColor = Color.White;
            txt_Truong_034.BackColor = Color.White;
            txt_Truong_035.BackColor = Color.White;
            txt_Truong_036.BackColor = Color.White;
            txt_Truong_037.BackColor = Color.White;
            txt_Truong_038.BackColor = Color.White;
            txt_Truong_039.BackColor = Color.White;
            txt_Truong_040_1.BackColor = Color.White;
            txt_Truong_040_2.BackColor = Color.White;
            txt_Truong_040_3.BackColor = Color.White;
            txt_Truong_040_4.BackColor = Color.White;
            txt_Truong_041.BackColor = Color.White;
            txt_Truong_042.BackColor = Color.White;
            txt_Truong_043.BackColor = Color.White;
            txt_Truong_044_1.BackColor = Color.White;
            txt_Truong_044_2.BackColor = Color.White;
            txt_Truong_045.BackColor = Color.White;
            txt_Truong_046.BackColor = Color.White;
            txt_Truong_047.BackColor = Color.White;
            txt_Truong_048.BackColor = Color.White;
            txt_Truong_049.BackColor = Color.White;
            txt_Truong_050.BackColor = Color.White;
            txt_Truong_051_1.BackColor = Color.White;
            txt_Truong_051_2.BackColor = Color.White;
            txt_Truong_051_3.BackColor = Color.White;
            txt_Truong_052.BackColor = Color.White;
            txt_Truong_053.BackColor = Color.White;
            txt_Truong_054_1.BackColor = Color.White;
            txt_Truong_054_2.BackColor = Color.White;
            txt_Truong_054_3.BackColor = Color.White;
            txt_Truong_055.BackColor = Color.White;
            txt_Truong_057.BackColor = Color.White;
            txt_Truong_058.BackColor = Color.White;
            txt_Truong_059.BackColor = Color.White;
            txt_Truong_061.BackColor = Color.White;
            txt_Truong_063.BackColor = Color.White;
            txt_Truong_065.BackColor = Color.White;
            txt_Truong_067.BackColor = Color.White;
            txt_Truong_069.BackColor = Color.White;
            txt_Truong_071.BackColor = Color.White;
            txt_Truong_073.BackColor = Color.White;
            txt_Truong_075.BackColor = Color.White;
            txt_Truong_040_1.Enabled = true;
            txt_Truong_040_2.Enabled = true;
            txt_Truong_040_3.Enabled = true;
            txt_Truong_040_4.Enabled = true;
        }

        public bool IsEmpty()
        {
            if (string.IsNullOrEmpty(txt_Truong_001.Text) &&
                string.IsNullOrEmpty(txt_Truong_002.Text) &&
                string.IsNullOrEmpty(txt_Truong_004.Text) &&
                string.IsNullOrEmpty(txt_Truong_005.Text) &&
                string.IsNullOrEmpty(txt_Truong_006.Text) &&
                string.IsNullOrEmpty(txt_Truong_007.Text) &&
                string.IsNullOrEmpty(txt_Truong_008.Text) &&
                string.IsNullOrEmpty(txt_Truong_009.Text) &&
                string.IsNullOrEmpty(txt_Truong_010.Text) &&
                string.IsNullOrEmpty(txt_Truong_011.Text) &&
                string.IsNullOrEmpty(txt_Truong_012.Text) &&
                string.IsNullOrEmpty(txt_Truong_013.Text) &&
                string.IsNullOrEmpty(txt_Truong_014.Text) &&
                string.IsNullOrEmpty(txt_Truong_015.Text) &&
                string.IsNullOrEmpty(txt_Truong_016.Text) &&
                string.IsNullOrEmpty(txt_Truong_017.Text) &&
                string.IsNullOrEmpty(txt_Truong_018.Text) &&
                string.IsNullOrEmpty(txt_Truong_019.Text) &&
                string.IsNullOrEmpty(txt_Truong_020.Text) &&
                string.IsNullOrEmpty(txt_Truong_021.Text) &&
                string.IsNullOrEmpty(txt_Truong_022.Text) &&
                string.IsNullOrEmpty(txt_Truong_023.Text) &&
                string.IsNullOrEmpty(txt_Truong_024.Text) &&
                string.IsNullOrEmpty(txt_Truong_025.Text) &&
                string.IsNullOrEmpty(txt_Truong_026.Text) &&
                string.IsNullOrEmpty(txt_Truong_027.Text) &&
                string.IsNullOrEmpty(txt_Truong_028.Text) &&
                string.IsNullOrEmpty(txt_Truong_029.Text) &&
                string.IsNullOrEmpty(txt_Truong_030.Text) &&
                string.IsNullOrEmpty(txt_Truong_031.Text) &&
                string.IsNullOrEmpty(txt_Truong_032.Text) &&
                string.IsNullOrEmpty(txt_Truong_033.Text) &&
                string.IsNullOrEmpty(txt_Truong_034.Text) &&
                string.IsNullOrEmpty(txt_Truong_035.Text) &&
                string.IsNullOrEmpty(txt_Truong_036.Text) &&
                string.IsNullOrEmpty(txt_Truong_037.Text) &&
                string.IsNullOrEmpty(txt_Truong_038.Text) &&
                string.IsNullOrEmpty(txt_Truong_039.Text) &&
                string.IsNullOrEmpty(txt_Truong_040_1.Text) &&
                string.IsNullOrEmpty(txt_Truong_040_2.Text) &&
                string.IsNullOrEmpty(txt_Truong_040_3.Text) &&
                string.IsNullOrEmpty(txt_Truong_040_4.Text) &&
                string.IsNullOrEmpty(txt_Truong_041.Text) &&
                string.IsNullOrEmpty(txt_Truong_042.Text) &&
                string.IsNullOrEmpty(txt_Truong_043.Text) &&
                string.IsNullOrEmpty(txt_Truong_044_1.Text) &&
                string.IsNullOrEmpty(txt_Truong_044_2.Text) &&
                string.IsNullOrEmpty(txt_Truong_045.Text) &&
                string.IsNullOrEmpty(txt_Truong_046.Text) &&
                string.IsNullOrEmpty(txt_Truong_047.Text) &&
                string.IsNullOrEmpty(txt_Truong_048.Text) &&
                string.IsNullOrEmpty(txt_Truong_049.Text) &&
                string.IsNullOrEmpty(txt_Truong_050.Text) &&
                string.IsNullOrEmpty(txt_Truong_051_1.Text) &&
                string.IsNullOrEmpty(txt_Truong_051_2.Text) &&
                string.IsNullOrEmpty(txt_Truong_051_3.Text) &&
                string.IsNullOrEmpty(txt_Truong_052.Text) &&
                string.IsNullOrEmpty(txt_Truong_053.Text) &&
                string.IsNullOrEmpty(txt_Truong_054_1.Text) &&
                string.IsNullOrEmpty(txt_Truong_054_2.Text) &&
                string.IsNullOrEmpty(txt_Truong_054_3.Text) &&
                string.IsNullOrEmpty(txt_Truong_055.Text) &&
                string.IsNullOrEmpty(txt_Truong_057.Text) &&
                string.IsNullOrEmpty(txt_Truong_058.Text) &&
                string.IsNullOrEmpty(txt_Truong_059.Text) &&
                string.IsNullOrEmpty(txt_Truong_061.Text) &&
                string.IsNullOrEmpty(txt_Truong_063.Text) &&
                string.IsNullOrEmpty(txt_Truong_065.Text) &&
                string.IsNullOrEmpty(txt_Truong_067.Text) &&
                string.IsNullOrEmpty(txt_Truong_069.Text) &&
                string.IsNullOrEmpty(txt_Truong_071.Text) &&
                string.IsNullOrEmpty(txt_Truong_073.Text) &&
                string.IsNullOrEmpty(txt_Truong_075.Text))
                return true;
            return false;
        }

        //public bool CheckDieuKienCamSubmit()
        //{
        //    if ((!string.IsNullOrEmpty(txt_Truong_020.Text)) && string.IsNullOrEmpty(txt_Truong_021.Text))
        //        return true;

        //    try
        //    {
        //        if (int.Parse(txt_Truong_020.Text) >= int.Parse(txt_Truong_021.Text))
        //            return true;
        //    }
        //    catch (Exception)
        //    {

        //    }
        //    return false;
        //}

        public void SaveData_Loai_4(string idImage)
        {
            string ValueTruong40 = "";
            if (txt_Truong_040_1.Text.Length > 0)
                ValueTruong40 = "1";
            else if (txt_Truong_040_2.Text.Length > 0)
                ValueTruong40 = "2";
            else if (txt_Truong_040_3.Text.Length > 0)
                ValueTruong40 = "3";
            else if (txt_Truong_040_4.Text.Length > 0)
                ValueTruong40 = "4";
           
            Global.db_BCL.Insert_Loai4(idImage, Global.StrBatch, Global.StrUsername, "Loai4",

                //txt_Truong_037.Text?.Replace(",", ""),
                txt_Truong_001.Text,
                txt_Truong_002.Text,
                "",
                txt_Truong_004.Text?.Replace(",", ""),
                txt_Truong_005.Text?.Replace(",", ""),
                txt_Truong_006.Text?.Replace(",", ""),
                txt_Truong_007.Text?.Replace(",", ""),
                txt_Truong_008.Text,
                txt_Truong_009.Text,
                txt_Truong_010.Text,
                txt_Truong_011.Text?.Replace(",", ""),
                txt_Truong_012.Text,
                txt_Truong_013.Text,
                txt_Truong_014.Text,
                txt_Truong_015.Text,
                txt_Truong_016.Text,
                txt_Truong_017.Text,
                txt_Truong_018.Text,
                txt_Truong_019.Text,
                txt_Truong_020.Text?.Replace(",", ""),
                txt_Truong_021.Text?.Replace(",", ""),
                txt_Truong_022.Text?.Replace(",", ""),
                txt_Truong_023.Text?.Replace(",", ""),
                txt_Truong_024.Text?.Replace(",", ""),
                txt_Truong_025.Text,
                txt_Truong_026.Text,
                txt_Truong_027.Text,
                txt_Truong_028.Text,
                txt_Truong_029.Text,
                txt_Truong_030.Text,
                txt_Truong_031.Text,
                txt_Truong_032.Text,
                txt_Truong_033.Text,
                txt_Truong_034.Text,
                txt_Truong_035.Text,
                txt_Truong_036.Text,
                txt_Truong_037.Text,
                txt_Truong_038.Text,
                txt_Truong_039.Text,
                ValueTruong40,
                txt_Truong_041.Text,
                txt_Truong_042.Text,
                txt_Truong_043.Text,
                txt_Truong_044_1.Text,
                txt_Truong_044_2.Text,
                txt_Truong_045.Text?.Replace(",", ""),
                txt_Truong_046.Text?.Replace(",", ""),
                txt_Truong_047.Text?.Replace(",", ""),
                txt_Truong_048.Text?.Replace(",", ""),
                txt_Truong_049.Text?.Replace(",", ""),
                txt_Truong_050.Text?.Replace(",", ""),
                
                txt_Truong_051_1.Text,
                txt_Truong_051_2.Text,
                txt_Truong_051_3.Text,
                txt_Truong_052.Text,
                txt_Truong_053.Text?.Replace(",", ""),
                txt_Truong_054_1.Text,
                txt_Truong_054_2.Text,
                txt_Truong_054_3.Text,

                txt_Truong_055.Text,
                "",
                txt_Truong_057.Text,
                txt_Truong_058.Text?.Replace(",", ""),
                txt_Truong_059.Text?.Replace(",", ""),
                "",
                txt_Truong_061.Text,
                "",
                txt_Truong_063.Text,
                "",
                txt_Truong_065.Text,
                "",
                txt_Truong_067.Text,
                "",
                txt_Truong_069.Text,
                "",
                txt_Truong_071.Text,
                "",
                txt_Truong_073.Text,
                "",
                txt_Truong_075.Text);
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
                    return false;
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

                for (int i = txt.Text.Length - 1; i >= 0; i--){
                    P.Add(txt.Text[i].ToString());
                    //chỉ lấy 12 ký tự đầu để so sánh. ký tự thứu 13 để compare
                }

                if (P.Count != 13)
                {
                    return false;
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
        
        //private void txt_Truong_037_KeyUp(object sender, KeyEventArgs e)
        //{
        //    try
        //    {
        //        curency(txt_Truong_037);
        //    }
        //    catch
        //    {
        //    }
        //}

        //private void txt_Truong_041_KeyUp(object sender, KeyEventArgs e)
        //{
        //    try
        //    {
        //        curency((TextEdit)sender);
        //    }
        //    catch
        //    {
        //    }
        //}

        private void doimautrongkhoang(TextEdit txt, int so_nho, int so_lon)
        {
            if (txt.Text.Length > 0 && txt.Text != "?")
            {
                if (txt.Text.Substring(0, 1) == "-")
                {
                    if (txt.Text.Length >= so_nho && txt.Text.Length <= so_lon + 1)
                    {
                        txt.ForeColor = Color.Black;
                        txt.BackColor = Color.White;
                    }
                    else
                    {
                        txt.ForeColor = Color.White;
                        txt.BackColor = Color.Red;
                    }
                }
                else
                {
                    if (txt.Text.Length >= so_nho && txt.Text.Length <= so_lon)
                    {
                        txt.ForeColor = Color.Black;
                        txt.BackColor = Color.White;
                    }
                    else
                    {
                        txt.ForeColor = Color.White;
                        txt.BackColor = Color.Red;
                    }
                }
            }
            else
            {
                txt.ForeColor = Color.Black;
                txt.BackColor = Color.White;
            }
        }

        //private void txt_Truong_006_EditValueChanged(object sender, EventArgs e)
        //{
        //    doimautrongkhoang((TextEdit)sender, 0, 10);

        //    if (txt_Truong_006_.Text.Length == 10 || txt_Truong_006_.Text == "?" || string.IsNullOrEmpty(txt_Truong_006_.Text))
        //    {
        //        txt_Truong_006_.BackColor = Color.White;
        //        //luon luon bat dau bang so 4 hoac so 99
        //        if (txt_Truong_006_.Text.Length > 1)
        //            if (txt_Truong_006_.Text[0].ToString() != "4")
        //                if ((txt_Truong_006_.Text[0].ToString() + txt_Truong_006_.Text[1].ToString()) != "99")
        //                {
        //                    txt_Truong_006_.BackColor = Color.Red;
        //                }
        //    }
        //    else
        //        txt_Truong_006_.BackColor = Color.Red;

        //    if (Changed != null)
        //        Changed(sender, e);
        //}

        private void txt_Truong_009_EditValueChanged(object sender, EventArgs e)
        {
            doimautrongkhoang((TextEdit)sender, 0, 10);
            if (Changed != null)
                Changed(sender, e);
        }

        //private void txt_Truong_008_EditValueChanged_1(object sender, EventArgs e)
        //{
        //    doimautrongkhoang((TextEdit)sender, 0, 25);

        //    if (!string.IsNullOrEmpty(txt_Truong_008_.Text))
        //    {
        //        if (txt_Truong_008_.Text.Length >= 2)
        //        {
        //            if (txt_Truong_008_.Text.Substring(txt_Truong_008_.Text.Length - 2, 2) == "  ")
        //            {
        //                txt_Truong_008_.BackColor = Color.Red;
        //                txt_Truong_008_.ForeColor = Color.White;
        //                bSubmit = true;
        //                txt_Truong_008_.Properties.MaxLength = txt_Truong_008_.Text.Length;
        //            }
        //            else
        //            {
        //                string result = lChar.Find(s => s == txt_Truong_008_.Text[txt_Truong_008_.Text.Length - 1].ToString());
        //                if (!string.IsNullOrEmpty(result))
        //                {
        //                    txt_Truong_008_.BackColor = Color.Red;
        //                    txt_Truong_008_.ForeColor = Color.White;
        //                    bSubmit = true;
        //                    txt_Truong_008_.Properties.MaxLength = txt_Truong_008_.Text.Length;
        //                }
        //                else
        //                {
        //                    txt_Truong_008_.BackColor = Color.White;
        //                    txt_Truong_008_.ForeColor = Color.Black;
        //                    bSubmit = false;
        //                    txt_Truong_008_.Properties.MaxLength = 0;
        //                    doimautrongkhoang((TextEdit)sender, 0, 25);
        //                }

        //            }

        //        }

        //        else
        //        {
        //            string result = lChar.Find(s => s == txt_Truong_008_.Text[txt_Truong_008_.Text.Length - 1].ToString());
        //            if (!string.IsNullOrEmpty(result))
        //            {
        //                txt_Truong_008_.BackColor = Color.Red;
        //                txt_Truong_008_.ForeColor = Color.White;
        //                bSubmit = true;
        //                txt_Truong_008_.Properties.MaxLength = txt_Truong_008_.Text.Length;
        //            }
        //            else
        //            {
        //                txt_Truong_008_.BackColor = Color.White;
        //                txt_Truong_008_.ForeColor = Color.Black;
        //                bSubmit = false;
        //                txt_Truong_008_.Properties.MaxLength = 0;
        //            }
        //        }

        //    }
        //    else
        //    {
        //        txt_Truong_008_.BackColor = Color.White;
        //        txt_Truong_008_.ForeColor = Color.Black;
        //        bSubmit = false;
        //        txt_Truong_008_.Properties.MaxLength = 0;
        //    }

        //    if (txt_Truong_008_.Text == "0")
        //    {
        //        txt_Truong_008_.BackColor = Color.Red;
        //        txt_Truong_008_.ForeColor = Color.White;
        //    }

        //    if (Changed != null)
        //        Changed(sender, e);
        //}

        //private void txt_Truong_003_EditValueChanged(object sender, EventArgs e)
        //{
        //    if (Lenght12(txt_Truong_003))
        //        txt_Truong_003.BackColor = Color.White;
        //    else
        //    {
        //        if (txt_Truong_003.Text.Length > 12)
        //            txt_Truong_003.BackColor = Color.Red;
        //        else
        //            txt_Truong_003.BackColor = Color.LimeGreen;
        //    }

        //    if (Changed != null)
        //        Changed(sender, e);
        //}
        

        //private void txt_Truong_158_EditValueChanged(object sender, EventArgs e)
        //{
        //    if (Lenght12(txt_Truong_158))
        //        txt_Truong_158.BackColor = Color.White;
        //    else
        //    {
        //        if (txt_Truong_158.Text.Length > 12)
        //            txt_Truong_158.BackColor = Color.Red;
        //        else
        //            txt_Truong_158.BackColor = Color.LimeGreen;
        //    }

        //    if (Changed != null)
        //        Changed(sender, e);
        //}
        

        //----------------------------------

        private void txt_Truong_001_EditValueChanged(object sender, EventArgs e)
        {
            doimautrongkhoang((TextEdit)sender, 0, 25);
            if (Changed != null)
                Changed(sender, e);
        }

        private void txt_Truong_002_EditValueChanged(object sender, EventArgs e)
        {
            doimautrongkhoang((TextEdit)sender, 0, 12);
            if (Changed != null)
                Changed(sender, e);
        }

        private void txt_Truong_004_EditValueChanged(object sender, EventArgs e)
        {
            doimautrongkhoang((TextEdit)sender, 0, 14);
            if (Changed != null)
                Changed(sender, e);
        }

        private void txt_Truong_005_EditValueChanged(object sender, EventArgs e)
        {
            
            doimautrongkhoang((TextEdit)sender, 0, 14);
            if (Changed != null)
                Changed(sender, e);

            //if (!(Lenght12(txt_Truong_005) || Lenght13(txt_Truong_005)) && (txt_Truong_005.Text.Length == 12 || txt_Truong_005.Text.Length == 13))
            //{
            //    txt_Truong_005.BackColor = Color.LimeGreen;
            //}
            //else

            //if (txt_Truong_005.Text.Length == 12)
            //{
            //    if (!Lenght12(txt_Truong_005))
            //        txt_Truong_005.BackColor = Color.LimeGreen;
            //}
            //else if (txt_Truong_005.Text.Length == 13)
            //    if (!Lenght13(txt_Truong_005))
            //        txt_Truong_005.BackColor = Color.LimeGreen;
        }

        private void txt_Truong_006_EditValueChanged_1(object sender, EventArgs e)
        {
            doimautrongkhoang((TextEdit)sender, 0, 14);
            if (Changed != null)
                Changed(sender, e);
        }

        private void txt_Truong_007_EditValueChanged(object sender, EventArgs e)
        {
            doimautrongkhoang((TextEdit)sender, 0, 14);
            if (Changed != null)
                Changed(sender, e);
        }

        private void txt_Truong_008_EditValueChanged(object sender, EventArgs e)
        {
            doimautrongkhoang((TextEdit)sender, 0, 1);
            if (Changed != null)
                Changed(sender, e);
        }

        private void txt_Truong_009_EditValueChanged_1(object sender, EventArgs e)
        {
            doimautrongkhoang((TextEdit)sender, 0, 1);
            if (Changed != null)
                Changed(sender, e);
        }

        private void txt_Truong_010_EditValueChanged(object sender, EventArgs e)
        {
            doimautrongkhoang((TextEdit)sender, 0, 1);
            if (Changed != null)
                Changed(sender, e);
        }

        private void txt_Truong_011_EditValueChanged(object sender, EventArgs e)
        {
            doimautrongkhoang((TextEdit)sender, 0, 14);
            if (Changed != null)
                Changed(sender, e);
        }
        private void txt_Truong_012_EditValueChanged(object sender, EventArgs e)
        {
            doimautrongkhoang((TextEdit)sender, 0, 1);
            if (Changed != null)
                Changed(sender, e);
        }

        private void txt_Truong_013_EditValueChanged(object sender, EventArgs e)
        {
            doimautrongkhoang((TextEdit)sender, 0, 1);
            if (Changed != null)
                Changed(sender, e);
        }

        private void txt_Truong_014_EditValueChanged(object sender, EventArgs e)
        {
            doimautrongkhoang((TextEdit)sender, 0, 1);
            if (Changed != null)
                Changed(sender, e);
        }

        private void txt_Truong_015_EditValueChanged(object sender, EventArgs e)
        {
            doimautrongkhoang((TextEdit)sender, 0, 2);
            if (Changed != null)
                Changed(sender, e);
        }

        private void txt_Truong_016_EditValueChanged(object sender, EventArgs e)
        {
            doimautrongkhoang((TextEdit)sender, 0, 2);
            if (Changed != null)
                Changed(sender, e);
        }

        private void txt_Truong_017_EditValueChanged(object sender, EventArgs e)
        {
            doimautrongkhoang((TextEdit)sender, 0, 1);
            if (Changed != null)
                Changed(sender, e);
        }

        private void txt_Truong_018_EditValueChanged(object sender, EventArgs e)
        {
            doimautrongkhoang((TextEdit)sender, 0, 1);
            if (Changed != null)
                Changed(sender, e);
        }

        private void txt_Truong_019_EditValueChanged(object sender, EventArgs e)
        {
            doimautrongkhoang((TextEdit)sender, 0, 1);
            if (Changed != null)
                Changed(sender, e);
        }

        private void txt_Truong_020_EditValueChanged(object sender, EventArgs e)
        {
            doimautrongkhoang((TextEdit)sender, 0, 14);
            if (Changed != null)
                Changed(sender, e);
        }

        private void txt_Truong_021_EditValueChanged(object sender, EventArgs e)
        {
            doimautrongkhoang((TextEdit)sender, 0, 14);
            if (Changed != null)
                Changed(sender, e);
        }

        private void txt_Truong_022_EditValueChanged(object sender, EventArgs e)
        {
            doimautrongkhoang((TextEdit)sender, 0, 14);
            if (Changed != null)
                Changed(sender, e);
        }

        private void txt_Truong_023_EditValueChanged(object sender, EventArgs e)
        {
            doimautrongkhoang((TextEdit)sender, 0, 14);
            if (Changed != null)
                Changed(sender, e);
        }

        private void txt_Truong_024_EditValueChanged(object sender, EventArgs e)
        {
            doimautrongkhoang((TextEdit)sender, 0, 14);
            if (Changed != null)
                Changed(sender, e);
        }

        private void txt_Truong_025_EditValueChanged(object sender, EventArgs e)
        {
            doimautrongkhoang((TextEdit)sender, 0, 1);
            if (Changed != null)
                Changed(sender, e);
        }

        private void txt_Truong_026_EditValueChanged(object sender, EventArgs e)
        {
            doimautrongkhoang((TextEdit)sender, 0, 1);
            if (Changed != null)
                Changed(sender, e);
        }

        private void txt_Truong_027_EditValueChanged(object sender, EventArgs e)
        {
            doimautrongkhoang((TextEdit)sender, 0, 1);
            if (Changed != null)
                Changed(sender, e);
        }

        private void txt_Truong_028_EditValueChanged(object sender, EventArgs e)
        {
            doimautrongkhoang((TextEdit)sender, 0, 1);
            if (Changed != null)
                Changed(sender, e);
        }

        private void txt_Truong_029_EditValueChanged(object sender, EventArgs e)
        {
            doimautrongkhoang((TextEdit)sender, 0, 1);
            if (Changed != null)
                Changed(sender, e);
        }

        private void txt_Truong_030_EditValueChanged(object sender, EventArgs e)
        {
            doimautrongkhoang((TextEdit)sender, 0, 1);
            if (Changed != null)
                Changed(sender, e);
        }

        private void txt_Truong_031_EditValueChanged(object sender, EventArgs e)
        {
            doimautrongkhoang((TextEdit)sender, 0, 1);
            if (Changed != null)
                Changed(sender, e);
        }

        private void txt_Truong_032_EditValueChanged(object sender, EventArgs e)
        {
            doimautrongkhoang((TextEdit)sender, 0, 1);
            if (Changed != null)
                Changed(sender, e);
        }

        private void txt_Truong_033_EditValueChanged(object sender, EventArgs e)
        {
            doimautrongkhoang((TextEdit)sender, 0, 1);
            if (Changed != null)
                Changed(sender, e);
        }

        private void txt_Truong_034_EditValueChanged(object sender, EventArgs e)
        {
            doimautrongkhoang((TextEdit)sender, 0, 1);
            if (Changed != null)
                Changed(sender, e);
        }

        private void txt_Truong_035_EditValueChanged(object sender, EventArgs e)
        {
            doimautrongkhoang((TextEdit)sender, 0, 1);
            if (Changed != null)
                Changed(sender, e);
        }

        private void txt_Truong_036_EditValueChanged(object sender, EventArgs e)
        {
            doimautrongkhoang((TextEdit)sender, 0, 1);
            if (Changed != null)
                Changed(sender, e);
        }

        private void txt_Truong0373839_EditValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(((TextEdit)sender).Text))
                if (((TextEdit)sender).Text!= "?")
                {
                    doimautrongkhoang((TextEdit)sender, 0, 2);
                }
                else
                {
                    doimautrongkhoang((TextEdit)sender, 0, 1);
                }
            
            else
            {
                doimautrongkhoang((TextEdit)sender, 0, 1);
            }
            
            if (Changed != null)
                Changed(sender, e);
        }

        private void txt_Truong_040_EditValueChanged(object sender, EventArgs e)
        {
            doimautrongkhoang((TextEdit)sender, 0, 1);
            if (Changed != null)
                Changed(sender, e);
            if (!string.IsNullOrEmpty(txt_Truong_040_1.Text))
            {
                txt_Truong_040_2.Enabled = false;
                txt_Truong_040_3.Enabled = false;
                txt_Truong_040_4.Enabled = false;
            }
            else
            {
                txt_Truong_040_2.Enabled = true;
                txt_Truong_040_3.Enabled = true;
                txt_Truong_040_4.Enabled = true;
            }
        }

        private void txt_Truong_0414243_EditValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(((TextEdit)sender).Text))
            {
                if (((TextEdit)sender).Text != "?")
                {
                    doimautrongkhoang((TextEdit)sender, 0, 2);
                }
                else
                {
                    doimautrongkhoang((TextEdit)sender, 0, 1);
                }
            }
            else
            {
                doimautrongkhoang((TextEdit)sender, 0, 1);
            }
            if (Changed != null)
                Changed(sender, e);
        }

        private void txt_Truong_044_EditValueChanged(object sender, EventArgs e) //44.1
        {
            //if (!string.IsNullOrEmpty(((TextEdit)sender).Text))
            //{
            //    if (((TextEdit)sender).Text != "?")
            //    {
            //        doimautrongkhoang((TextEdit)sender, 13, 13);
            //    }
            //    else
            //    {
            //        doimautrongkhoang((TextEdit)sender, 0, 1);
            //    }
            //}
            //else
            //{
            //    doimautrongkhoang((TextEdit)sender, 0, 1);
            //}
            
            doimautrongkhoang((TextEdit)sender, 0, 1);

            if (Changed != null)
                Changed(sender, e);
        }

        private void txt_Truong_044_2_EditValueChanged(object sender, EventArgs e)
        {
            doimautrongkhoang((TextEdit)sender, 0, 12);

            if (Changed != null)
                Changed(sender, e);
        }

        private void txt_Truong_045_EditValueChanged(object sender, EventArgs e)
        {
            doimautrongkhoang((TextEdit)sender, 0, 14);
            if (Changed != null)
                Changed(sender, e);
        }

        private void txt_Truong_046_EditValueChanged(object sender, EventArgs e)
        {
            doimautrongkhoang((TextEdit)sender, 0, 14);
            if (Changed != null)
                Changed(sender, e);
        }

        private void txt_Truong_047_EditValueChanged(object sender, EventArgs e)
        {
            doimautrongkhoang((TextEdit)sender, 0, 14);
            if (Changed != null)
                Changed(sender, e);
        }

        private void txt_Truong_048_EditValueChanged(object sender, EventArgs e)
        {
            doimautrongkhoang((TextEdit)sender, 0, 14);
            if (Changed != null)
                Changed(sender, e);
        }

        private void txt_Truong_049_EditValueChanged(object sender, EventArgs e)
        {
            doimautrongkhoang((TextEdit)sender, 0, 14);
            if (Changed != null)
                Changed(sender, e);
        }

        private void txt_Truong_050_EditValueChanged(object sender, EventArgs e)
        {
            doimautrongkhoang((TextEdit)sender, 0, 14);
            if (Changed != null)
                Changed(sender, e);
        }
        private void txt_Truong_051_EditValueChanged(object sender, EventArgs e)
        {
            doimautrongkhoang((TextEdit)sender, 0, 2);
            if (Changed != null)
                Changed(sender, e);
        }

        private void txt_Truong_052_EditValueChanged(object sender, EventArgs e)
        {
            if (Changed != null)
                Changed(sender, e);
        }

        private void txt_Truong_052_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                txt_Truong_053.Focus();
            }
            else if (e.KeyCode == Keys.Up)
            {
                txt_Truong_046.Focus();
            }
            else if (e.KeyCode == Keys.Right)
            {
                SendKeys.Send("{Tab}");
            }
            else if (e.KeyCode == Keys.Left)
            {
                SendKeys.Send("+{Tab}");
            }
            if (e.KeyData == Keys.Back || e.KeyData == Keys.Delete)
            {
                txt_Truong_052.ItemIndex = 0;
                e.Handled = true;
            }
        }

        private void txt_Truong053_EditValueChanged(object sender, EventArgs e)
        {
            doimautrongkhoang((TextEdit)sender, 0, 14);
            if (Changed != null)
                Changed(sender, e);
        }

        private void txt_Truong_054_EditValueChanged(object sender, EventArgs e)
        {
            doimautrongkhoang((TextEdit)sender, 0, 2);
            if (Changed != null)
                Changed(sender, e);
        }

        private void txt_Truong_055_EditValueChanged(object sender, EventArgs e)
        {
            if (Changed != null)
                Changed(sender, e);
        }

        private void txt_Truong_055_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                txt_Truong_051_1.Focus();
            }
            else if (e.KeyCode == Keys.Up)
            {
                txt_Truong_057.Focus();
            }
            else if (e.KeyCode == Keys.Right)
            {
                SendKeys.Send("{Tab}");
            }
            else if (e.KeyCode == Keys.Left)
            {
                SendKeys.Send("+{Tab}");
            }
            if (e.KeyData == Keys.Back || e.KeyData == Keys.Delete)
            {
                txt_Truong_055.ItemIndex = 0;
                e.Handled = true;
            }
        }

        private void txt_Truong_057_EditValueChanged(object sender, EventArgs e)
        {
            doimautrongkhoang((TextEdit)sender, 0, 12);
            if (Changed != null)
                Changed(sender, e);
        }

        private void txt_Truong_058_EditValueChanged(object sender, EventArgs e)
        {
            doimautrongkhoang((TextEdit)sender, 0, 14);
            if (Changed != null)
                Changed(sender, e);
        }

        private void txt_Truong_059_EditValueChanged(object sender, EventArgs e)
        {
            doimautrongkhoang((TextEdit)sender, 0, 14);
            if (Changed != null)
                Changed(sender, e);
        }

        private void txt_Truong_061_EditValueChanged(object sender, EventArgs e)
        {
            doimautrongkhoang((TextEdit)sender, 0, 12);
            if (Changed != null)
                Changed(sender, e);
        }

        private void txt_Truong_063_EditValueChanged(object sender, EventArgs e)
        {
            doimautrongkhoang((TextEdit)sender, 0, 12);
            if (Changed != null)
                Changed(sender, e);
        }

        private void txt_Truong_065_EditValueChanged(object sender, EventArgs e)
        {
            doimautrongkhoang((TextEdit)sender, 0, 12);
            if (Changed != null)
                Changed(sender, e);
        }

        private void txt_Truong_067_EditValueChanged(object sender, EventArgs e)
        {
            doimautrongkhoang((TextEdit)sender, 0, 12);
            if (Changed != null)
                Changed(sender, e);
        }

        private void txt_Truong_069_EditValueChanged(object sender, EventArgs e)
        {
            doimautrongkhoang((TextEdit)sender, 0, 12);
            if (Changed != null)
                Changed(sender, e);
        }

        private void txt_Truong_071_EditValueChanged(object sender, EventArgs e)
        {
            doimautrongkhoang((TextEdit)sender, 0, 12);
            if (Changed != null)
                Changed(sender, e);
        }

        private void txt_Truong_073_EditValueChanged(object sender, EventArgs e)
        {
            doimautrongkhoang((TextEdit)sender, 0, 12);
            if (Changed != null)
                Changed(sender, e);
        }

        private void txt_Truong_075_EditValueChanged(object sender, EventArgs e)
        {
            doimautrongkhoang((TextEdit)sender, 0, 12);
            if (Changed != null)
                Changed(sender, e);
        }

        private void txt_Truong_004_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                TextEdit te = (TextEdit)sender;
                if (te.Text.IndexOf('●') >= 0 || te.Text.IndexOf('?') >= 0)
                {
                    te.Text = te.Text.Replace(",", "");
                }
                else if (!string.IsNullOrEmpty(te.Text))
                {
                    if (te.Text[0] + "" == "-")
                    {
                        string str = te.Text.Replace("-", "").Replace(",", "");
                        int start = te.Text.Length - te.SelectionStart;
                        te.Text = "-" + FormatCurency(str);
                        te.SelectionStart = -start + te.Text.Length;
                    }
                    else
                    {
                        string str = te.Text.Replace(",", "");
                        int start = te.Text.Length - te.SelectionStart;
                        te.Text = FormatCurency(str);
                        te.SelectionStart = -start + te.Text.Length;
                    }
                }
            }
            catch
            {
            }
        }
        string FormatCurency(string curency)// định dạng 1,234
        {
            string str = curency.ToString();
            string pattern = @"(?<a>\d*)(?<b>\d{3})*";
            Match m = Regex.Match(str, pattern, RegexOptions.RightToLeft);
            StringBuilder sb = new StringBuilder();
            foreach (Capture i in m.Groups["b"].Captures)
            {
                sb.Insert(0, "," + i.Value);
            }
            sb.Insert(0, m.Groups["a"].Value);
            return sb.ToString().Trim(',');
        }

        private void txt_Truong_051_1_KeyUp(object sender, KeyEventArgs e)
        {
            //if (txt_Truong_051_1.Text == "0" ||txt_Truong_051_1.Text == "00" || txt_Truong_051_1.Text.Length < 1)
            //    return;
            //if (txt_Truong_051_1.Text.Length < 2)
            //    txt_Truong_051_1.Text = "0" + txt_Truong_051_1.Text;
            //else
            //    txt_Truong_051_1.Text = txt_Truong_051_1.Text.Substring(txt_Truong_051_1.Text.Length - 2);
            //txt_Truong_051_1.SelectionStart = txt_Truong_051_1.Text.Length;

            //if(txt_Truong_051_1.Text.Length > 0 && txt_Truong_051_2.Text.Length > 0)
            //{
            //    txt_Truong_051_3.Text = "01";
            //    txt_Truong_051_3.ReadOnly = true;
            //}
            //else
            //    txt_Truong_051_3.ReadOnly = true;


        }

        private void txt_Truong_051_2_KeyUp(object sender, KeyEventArgs e)
        {
            //if (txt_Truong_051_2.Text == "0"  || txt_Truong_051_2.Text == "00" || txt_Truong_051_2.Text.Length < 1)
            //    return;
            //if (txt_Truong_051_2.Text.Length < 2)
            //    txt_Truong_051_2.Text = "0" + txt_Truong_051_2.Text;
            //else
            //    txt_Truong_051_2.Text = txt_Truong_051_2.Text.Substring(txt_Truong_051_2.Text.Length - 2);
            //txt_Truong_051_2.SelectionStart = txt_Truong_051_2.Text.Length;

            //if (txt_Truong_051_1.Text.Length > 0 && txt_Truong_051_2.Text.Length > 0)
            //{
            //    txt_Truong_051_3.Text = "01";
            //    txt_Truong_051_3.ReadOnly = true;
            //}
            //else
            //    txt_Truong_051_3.ReadOnly = true;
        }

        private void txt_Truong_051_3_KeyUp(object sender, KeyEventArgs e)
        {
            //if (txt_Truong_051_3.Text == "0" || txt_Truong_051_3.Text == "00" || txt_Truong_051_3.Text.Length < 1)
            //    return;
            //if (txt_Truong_051_3.Text.Length < 2)
            //    txt_Truong_051_3.Text = "0" + txt_Truong_051_3.Text;
            //else
            //    txt_Truong_051_3.Text = txt_Truong_051_3.Text.Substring(txt_Truong_051_3.Text.Length - 2);
            //txt_Truong_051_3.SelectionStart = txt_Truong_051_3.Text.Length;
        }

        private void txt_Truong_054_1_KeyUp(object sender, KeyEventArgs e)
        {
            //if (txt_Truong_054_1.Text == "0" || txt_Truong_054_1.Text == "00" || txt_Truong_054_1.Text.Length < 1)
            //    return;
            //if (txt_Truong_054_1.Text.Length < 2)
            //    txt_Truong_054_1.Text = "0" + txt_Truong_054_1.Text;
            //else
            //    txt_Truong_054_1.Text = txt_Truong_054_1.Text.Substring(txt_Truong_054_1.Text.Length - 2);
            //txt_Truong_054_1.SelectionStart = txt_Truong_054_1.Text.Length;
        }

        private void txt_Truong_054_2_KeyUp(object sender, KeyEventArgs e)
        {
            //if (txt_Truong_054_2.Text == "0" || txt_Truong_054_2.Text == "00" || txt_Truong_054_2.Text.Length < 1)
            //    return;
            //if (txt_Truong_054_2.Text.Length < 2)
            //    txt_Truong_054_2.Text = "0" + txt_Truong_054_2.Text;
            //else
            //    txt_Truong_054_2.Text = txt_Truong_054_2.Text.Substring(txt_Truong_054_2.Text.Length - 2);
            //txt_Truong_054_2.SelectionStart = txt_Truong_054_2.Text.Length;
        }

        private void txt_Truong_054_3_KeyUp(object sender, KeyEventArgs e)
        {
            //if (txt_Truong_054_3.Text == "0" || txt_Truong_054_3.Text == "00" || txt_Truong_054_3.Text.Length < 1)
            //    return;
            //if (txt_Truong_054_3.Text.Length < 2)
            //    txt_Truong_054_3.Text = "0" + txt_Truong_054_3.Text;
            //else
            //    txt_Truong_054_3.Text = txt_Truong_054_3.Text.Substring(txt_Truong_054_3.Text.Length - 2);
            //txt_Truong_054_3.SelectionStart = txt_Truong_054_3.Text.Length;
        }

        private void txt_Truong_004_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down &&(((TextEdit)sender).Name == "txt_Truong_004" || ((TextEdit)sender).Name == "txt_Truong_005" || ((TextEdit)sender).Name == "txt_Truong_006" || ((TextEdit)sender).Name == "txt_Truong_007"))
            {
                txt_Truong_008.Focus();
            }
            else if (e.KeyCode == Keys.Up && (((TextEdit)sender).Name == "txt_Truong_004" || ((TextEdit)sender).Name == "txt_Truong_005" || ((TextEdit)sender).Name == "txt_Truong_006" || ((TextEdit)sender).Name == "txt_Truong_007"))
            {
                txt_Truong_002.Focus();
            }
            else if (e.KeyCode == Keys.Down && ((TextEdit)sender).Name == "txt_Truong_011")
            {
                txt_Truong_020.Focus();
            }
            else if (e.KeyCode == Keys.Up && ((TextEdit)sender).Name == "txt_Truong_011")
            {
                txt_Truong_004.Focus();
            }
            else if (e.KeyCode == Keys.Down && ((TextEdit)sender).Name == "txt_Truong_020")
            {
                txt_Truong_021.Focus();
            }
            else if (e.KeyCode == Keys.Up && ((TextEdit)sender).Name == "txt_Truong_020")
            {
                txt_Truong_008.Focus();
            }
            else if (e.KeyCode == Keys.Down && (((TextEdit)sender).Name == "txt_Truong_021" || ((TextEdit)sender).Name == "txt_Truong_022" || ((TextEdit)sender).Name == "txt_Truong_023" || ((TextEdit)sender).Name == "txt_Truong_024"))
            {
                txt_Truong_045.Focus();
            }
            else if (e.KeyCode == Keys.Up && (((TextEdit)sender).Name == "txt_Truong_021" || ((TextEdit)sender).Name == "txt_Truong_022" || ((TextEdit)sender).Name == "txt_Truong_023" || ((TextEdit)sender).Name == "txt_Truong_024"))
            {
                txt_Truong_020.Focus();
            }
            else if (e.KeyCode == Keys.Down && ((TextEdit)sender).Name == "txt_Truong_045")
            {
                txt_Truong_046.Focus();
            }
            else if (e.KeyCode == Keys.Up && ((TextEdit)sender).Name == "txt_Truong_045")
            {
                txt_Truong_021.Focus();
            }
            else if (e.KeyCode == Keys.Down && (((TextEdit)sender).Name == "txt_Truong_046" || ((TextEdit)sender).Name == "txt_Truong_047" || ((TextEdit)sender).Name == "txt_Truong_048" || ((TextEdit)sender).Name == "txt_Truong_049" || ((TextEdit)sender).Name == "txt_Truong_050"))
            {
                txt_Truong_051_1.Focus();
            }
            else if (e.KeyCode == Keys.Up && (((TextEdit)sender).Name == "txt_Truong_046" || ((TextEdit)sender).Name == "txt_Truong_047" || ((TextEdit)sender).Name == "txt_Truong_048" || ((TextEdit)sender).Name == "txt_Truong_049" || ((TextEdit)sender).Name == "txt_Truong_050"))
            {
                txt_Truong_045.Focus();
            }
            else if (e.KeyCode == Keys.Down && ((TextEdit)sender).Name == "txt_Truong_053")
            {
                txt_Truong_057.Focus();
            }
            else if (e.KeyCode == Keys.Up && ((TextEdit)sender).Name == "txt_Truong_053")
            {
                txt_Truong_051_1.Focus();
            }
            else if (e.KeyCode == Keys.Down && ((TextEdit)sender).Name == "txt_Truong_058")
            {
                txt_Truong_069.Focus();
            }
            else if (e.KeyCode == Keys.Down && ((TextEdit)sender).Name == "txt_Truong_059")
            {
                txt_Truong_061.Focus();
            }
            else if (e.KeyCode == Keys.Up && (((TextEdit)sender).Name == "txt_Truong_058" || ((TextEdit)sender).Name == "txt_Truong_059"))
            {
                txt_Truong_053.Focus();
            }
            else if (e.KeyCode == Keys.Right)
            {
                SendKeys.Send("{Tab}");
            }
            else if (e.KeyCode == Keys.Left)
            {
                SendKeys.Send("+{Tab}");
            }
            if (e.KeyCode == Keys.Add)
            {
                ((TextEdit)sender).Text = ((TextEdit)sender).Text + "000";
                ((TextEdit)sender).SelectionStart = ((TextEdit)sender).Text.Length;
            }
        }

        private void txt_Truong_001_KeyDown(object sender, KeyEventArgs e)
        {
            if (((TextEdit)sender).Name == "txt_Truong_001" && (e.KeyCode == Keys.Down || e.KeyCode == Keys.Right))
            {
                SendKeys.Send("{Tab}");
            }
            else if (((TextEdit)sender).Name == "txt_Truong_001" && (e.KeyCode == Keys.Up || e.KeyCode == Keys.Left))
            { }
            else if (((TextEdit)sender).Name == "txt_Truong_044_2" && (e.KeyCode == Keys.Up || e.KeyCode == Keys.Left))
            {
                SendKeys.Send("+{Tab}");
            }
            else if (((TextEdit)sender).Name == "txt_Truong_044_2" && (e.KeyCode == Keys.Down || e.KeyCode == Keys.Right))
            { }
        }

        private void txt_Truong_002_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Right)
            {
                SendKeys.Send("{Tab}");
            }
            else if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Left)
            {
                SendKeys.Send("+{Tab}");
            }
        }

        private void txt_Truong_008_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                txt_Truong_020.Focus();
            }
            else if (e.KeyCode == Keys.Up)
            {
                txt_Truong_004.Focus();
            }
            else if (e.KeyCode == Keys.Right)
            {
                SendKeys.Send("{Tab}");
            }
            else if (e.KeyCode == Keys.Left)
            {
                SendKeys.Send("+{Tab}");
            }
        }

        private void txt_Truong_051_1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                txt_Truong_053.Focus();
            }
            else if (e.KeyCode == Keys.Up)
            {
                txt_Truong_046.Focus();
            }
            else if (e.KeyCode == Keys.Right)
            {
                SendKeys.Send("{Tab}");
            }
            else if (e.KeyCode == Keys.Left)
            {
                SendKeys.Send("+{Tab}");
            }
        }

        private void txt_Truong_054_1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                txt_Truong_051_1.Focus();
            }
            else if (e.KeyCode == Keys.Up)
            {
                txt_Truong_057.Focus();
            }
            else if (e.KeyCode == Keys.Right)
            {
                SendKeys.Send("{Tab}");
            }
            else if (e.KeyCode == Keys.Left)
            {
                SendKeys.Send("+{Tab}");
            }
        }

        private void txt_Truong_057_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                txt_Truong_061.Focus();
            }
            else if (e.KeyCode == Keys.Up)
            {
                txt_Truong_053.Focus();
            }
            else if (e.KeyCode == Keys.Right)
            {
                SendKeys.Send("{Tab}");
            }
            else if (e.KeyCode == Keys.Left)
            {
                SendKeys.Send("+{Tab}");
            }
        }

        private void txt_Truong_061_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                txt_Truong_063.Focus();
            }
            else if (e.KeyCode == Keys.Up)
            {
                txt_Truong_057.Focus();
            }
            else if (e.KeyCode == Keys.Right)
            {
                SendKeys.Send("{Tab}");
            }
            else if (e.KeyCode == Keys.Left)
            {
                SendKeys.Send("+{Tab}");
            }
        }

        private void txt_Truong_069_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                SendKeys.Send("{Tab}");
                SendKeys.Send("{Tab}");
            }
            else if (e.KeyCode == Keys.Up)
            {
                SendKeys.Send("+{Tab}");
                SendKeys.Send("+{Tab}");
            }
            else if (e.KeyCode == Keys.Right)
            {
                SendKeys.Send("{Tab}");
            }
            else if (e.KeyCode == Keys.Left)
            {
                SendKeys.Send("+{Tab}");
            }
        }

        private void txt_Truong_075_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                txt_Truong_025.Focus();
            }
            else if (e.KeyCode == Keys.Up)
            {
                txt_Truong_073.Focus();
            }
            else if (e.KeyCode == Keys.Right)
            {
                SendKeys.Send("{Tab}");
            }
            else if (e.KeyCode == Keys.Left)
            {
                SendKeys.Send("+{Tab}");
            }
        }

        private void txt_Truong_025_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                txt_Truong_035.Focus();
            }
            else if (e.KeyCode == Keys.Up)
            {
                txt_Truong_067.Focus();
            }
            else if (e.KeyCode == Keys.Right)
            {
                SendKeys.Send("{Tab}");
            }
            else if (e.KeyCode == Keys.Left)
            {
                SendKeys.Send("+{Tab}");
            }
        }

        private void txt_Truong_035_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                txt_Truong_040_1.Focus();
            }
            else if (e.KeyCode == Keys.Up)
            {
                txt_Truong_025.Focus();
            }
            else if (e.KeyCode == Keys.Right)
            {
                SendKeys.Send("{Tab}");
            }
            else if (e.KeyCode == Keys.Left)
            {
                SendKeys.Send("+{Tab}");
            }
        }

        private void txt_Truong_040_1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                txt_Truong_044_1.Focus();
            }
            else if (e.KeyCode == Keys.Up)
            {
                txt_Truong_035.Focus();
            }
            else if (e.KeyCode == Keys.Right)
            {
                SendKeys.Send("{Tab}");
            }
            else if (e.KeyCode == Keys.Left)
            {
                SendKeys.Send("+{Tab}");
            }
        }

        private void txt_Truong_044_1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                txt_Truong_044_2.Focus();
            }
            else if (e.KeyCode == Keys.Right)
            {
                SendKeys.Send("{Tab}");
            }
            else if (e.KeyCode == Keys.Left)
            {
                SendKeys.Send("+{Tab}");
            }
        }

        private void txt_Truong_040_2_EditValueChanged(object sender, EventArgs e)
        {
            doimautrongkhoang((TextEdit)sender, 0, 1);
            if (Changed != null)
                Changed(sender, e);
            if (!string.IsNullOrEmpty(txt_Truong_040_2.Text))
            {
                txt_Truong_040_1.Enabled = false;
                txt_Truong_040_3.Enabled = false;
                txt_Truong_040_4.Enabled = false;
            }
            else
            {
                txt_Truong_040_1.Enabled = true;
                txt_Truong_040_3.Enabled = true;
                txt_Truong_040_4.Enabled = true;
            }
        }

        private void txt_Truong_040_3_EditValueChanged(object sender, EventArgs e)
        {
            doimautrongkhoang((TextEdit)sender, 0, 1);
            if (Changed != null)
                Changed(sender, e);
            if (!string.IsNullOrEmpty(txt_Truong_040_3.Text))
            {
                txt_Truong_040_2.Enabled = false;
                txt_Truong_040_1.Enabled = false;
                txt_Truong_040_4.Enabled = false;
            }
            else
            {
                txt_Truong_040_2.Enabled = true;
                txt_Truong_040_1.Enabled = true;
                txt_Truong_040_4.Enabled = true;
            }
        }

        private void txt_Truong_040_4_EditValueChanged(object sender, EventArgs e)
        {
            doimautrongkhoang((TextEdit)sender, 0, 1);
            if (Changed != null)
                Changed(sender, e);
            if (!string.IsNullOrEmpty(txt_Truong_040_4.Text))
            {
                txt_Truong_040_2.Enabled = false;
                txt_Truong_040_3.Enabled = false;
                txt_Truong_040_1.Enabled = false;
            }
            else
            {
                txt_Truong_040_2.Enabled = true;
                txt_Truong_040_3.Enabled = true;
                txt_Truong_040_1.Enabled = true;
            }
        }
    }
}