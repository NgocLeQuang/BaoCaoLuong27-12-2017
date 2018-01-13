using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using DevExpress.XtraEditors;
using BaoCaoLuong2018.Properties;

namespace BaoCaoLuong2018.MyUserControl
{
    public partial class UC_CityN_Loai3 : UserControl
    {
        public event Focus_Text Focus;
        public event AllTextChange Changed;
        public UC_CityN_Loai3()
        {
            InitializeComponent();
        }

        private void txt_Truong_014_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 32)
            {
                e.Handled = true;
            }
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
            //category.Add(new Category() { Value_JP = "特定", Value_SO = "1" });
            category.Add(new Category() { Value_JP = "特", Value_SO = "1" });
            category.Add(new Category() { Value_JP = "?", Value_SO = "?" });
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
        private void SetTag()
        {
            textEdit1.Tag = "";
            textEdit2.Tag = "";
            textEdit3.Tag = "";
            textEdit4.Tag = "";
            textEdit5.Tag = "";
            textEdit8.Tag = "";
            txt_Truong_011.Tag = (from w in Global.DataNote where w.City == "CityN" & w.LoaiPhieu == "Loai3" & w.Truong == "11" select w.Note).FirstOrDefault();
            txt_Truong_014.Tag = (from w in Global.DataNote where w.City == "CityN" & w.LoaiPhieu == "Loai3" & w.Truong == "14" select w.Note).FirstOrDefault();
            txt_Truong_016.Tag = (from w in Global.DataNote where w.City == "CityN" & w.LoaiPhieu == "Loai3" & w.Truong == "16" select w.Note).FirstOrDefault();
            txt_Truong_020.Tag = (from w in Global.DataNote where w.City == "CityN" & w.LoaiPhieu == "Loai3" & w.Truong == "20" select w.Note).FirstOrDefault();
            txt_Truong_022.Tag = (from w in Global.DataNote where w.City == "CityN" & w.LoaiPhieu == "Loai3" & w.Truong == "22" select w.Note).FirstOrDefault();
            txt_Truong_024.Tag = (from w in Global.DataNote where w.City == "CityN" & w.LoaiPhieu == "Loai3" & w.Truong == "24" select w.Note).FirstOrDefault();
            txt_Truong_026.Tag = (from w in Global.DataNote where w.City == "CityN" & w.LoaiPhieu == "Loai3" & w.Truong == "26" select w.Note).FirstOrDefault();
            txt_Truong_028.Tag = (from w in Global.DataNote where w.City == "CityN" & w.LoaiPhieu == "Loai3" & w.Truong == "28" select w.Note).FirstOrDefault();
            txt_Truong_030.Tag = (from w in Global.DataNote where w.City == "CityN" & w.LoaiPhieu == "Loai3" & w.Truong == "30" select w.Note).FirstOrDefault();
            txt_Truong_032.Tag = (from w in Global.DataNote where w.City == "CityN" & w.LoaiPhieu == "Loai3" & w.Truong == "32" select w.Note).FirstOrDefault();
            txt_Truong_034.Tag = (from w in Global.DataNote where w.City == "CityN" & w.LoaiPhieu == "Loai3" & w.Truong == "34" select w.Note).FirstOrDefault();
            txt_Truong_036.Tag = (from w in Global.DataNote where w.City == "CityN" & w.LoaiPhieu == "Loai3" & w.Truong == "36" select w.Note).FirstOrDefault();
            txt_Truong_038.Tag = (from w in Global.DataNote where w.City == "CityN" & w.LoaiPhieu == "Loai3" & w.Truong == "38" select w.Note).FirstOrDefault();
            txt_Truong_040.Tag = (from w in Global.DataNote where w.City == "CityN" & w.LoaiPhieu == "Loai3" & w.Truong == "40" select w.Note).FirstOrDefault();
            txt_Truong_042.Tag = (from w in Global.DataNote where w.City == "CityN" & w.LoaiPhieu == "Loai3" & w.Truong == "42" select w.Note).FirstOrDefault();
            txt_Truong_044.Tag = (from w in Global.DataNote where w.City == "CityN" & w.LoaiPhieu == "Loai3" & w.Truong == "44" select w.Note).FirstOrDefault();
            txt_Truong_046.Tag = (from w in Global.DataNote where w.City == "CityN" & w.LoaiPhieu == "Loai3" & w.Truong == "46" select w.Note).FirstOrDefault();
            txt_Truong_048.Tag = (from w in Global.DataNote where w.City == "CityN" & w.LoaiPhieu == "Loai3" & w.Truong == "48" select w.Note).FirstOrDefault();
            txt_Truong_050.Tag = (from w in Global.DataNote where w.City == "CityN" & w.LoaiPhieu == "Loai3" & w.Truong == "50" select w.Note).FirstOrDefault();
            txt_Truong_052.Tag = (from w in Global.DataNote where w.City == "CityN" & w.LoaiPhieu == "Loai3" & w.Truong == "52" select w.Note).FirstOrDefault();
            txt_Truong_054.Tag = (from w in Global.DataNote where w.City == "CityN" & w.LoaiPhieu == "Loai3" & w.Truong == "54" select w.Note).FirstOrDefault();
            txt_Truong_056.Tag = (from w in Global.DataNote where w.City == "CityN" & w.LoaiPhieu == "Loai3" & w.Truong == "56" select w.Note).FirstOrDefault();
            txt_Truong_058.Tag = (from w in Global.DataNote where w.City == "CityN" & w.LoaiPhieu == "Loai3" & w.Truong == "58" select w.Note).FirstOrDefault();
            txt_Truong_060.Tag = (from w in Global.DataNote where w.City == "CityN" & w.LoaiPhieu == "Loai3" & w.Truong == "60" select w.Note).FirstOrDefault();
            txt_Truong_062.Tag = (from w in Global.DataNote where w.City == "CityN" & w.LoaiPhieu == "Loai3" & w.Truong == "62" select w.Note).FirstOrDefault();
            txt_Truong_064.Tag = (from w in Global.DataNote where w.City == "CityN" & w.LoaiPhieu == "Loai3" & w.Truong == "64" select w.Note).FirstOrDefault();
            txt_Truong_066.Tag = (from w in Global.DataNote where w.City == "CityN" & w.LoaiPhieu == "Loai3" & w.Truong == "66" select w.Note).FirstOrDefault();
            txt_Truong_068.Tag = (from w in Global.DataNote where w.City == "CityN" & w.LoaiPhieu == "Loai3" & w.Truong == "68" select w.Note).FirstOrDefault();
            txt_Truong_072.Tag = (from w in Global.DataNote where w.City == "CityN" & w.LoaiPhieu == "Loai3" & w.Truong == "72" select w.Note).FirstOrDefault();
            txt_Truong_074_1.Tag = txt_Truong_074_2.Tag = txt_Truong_074_3.Tag = (from w in Global.DataNote where w.City == "CityN" & w.LoaiPhieu == "Loai3" & w.Truong == "74" select w.Note).FirstOrDefault();
            txt_Truong_076.Tag = (from w in Global.DataNote where w.City == "CityN" & w.LoaiPhieu == "Loai3" & w.Truong == "76" select w.Note).FirstOrDefault();
            txt_Truong_082.Tag = (from w in Global.DataNote where w.City == "CityN" & w.LoaiPhieu == "Loai3" & w.Truong == "82" select w.Note).FirstOrDefault();
            txt_Truong_084.Tag = (from w in Global.DataNote where w.City == "CityN" & w.LoaiPhieu == "Loai3" & w.Truong == "84" select w.Note).FirstOrDefault();
            txt_Truong_086.Tag = (from w in Global.DataNote where w.City == "CityN" & w.LoaiPhieu == "Loai3" & w.Truong == "86" select w.Note).FirstOrDefault();
            txt_Truong_088.Tag = (from w in Global.DataNote where w.City == "CityN" & w.LoaiPhieu == "Loai3" & w.Truong == "88" select w.Note).FirstOrDefault();
            txt_Truong_090.Tag = (from w in Global.DataNote where w.City == "CityN" & w.LoaiPhieu == "Loai3" & w.Truong == "90" select w.Note).FirstOrDefault();
            txt_Truong_092.Tag = (from w in Global.DataNote where w.City == "CityN" & w.LoaiPhieu == "Loai3" & w.Truong == "92" select w.Note).FirstOrDefault();
            txt_Truong_094.Tag = (from w in Global.DataNote where w.City == "CityN" & w.LoaiPhieu == "Loai3" & w.Truong == "94" select w.Note).FirstOrDefault();
            txt_Truong_096.Tag = (from w in Global.DataNote where w.City == "CityN" & w.LoaiPhieu == "Loai3" & w.Truong == "96" select w.Note).FirstOrDefault();
            txt_Truong_098.Tag = (from w in Global.DataNote where w.City == "CityN" & w.LoaiPhieu == "Loai3" & w.Truong == "98" select w.Note).FirstOrDefault();
            txt_Truong_100.Tag = (from w in Global.DataNote where w.City == "CityN" & w.LoaiPhieu == "Loai3" & w.Truong == "100" select w.Note).FirstOrDefault();
            txt_Truong_102.Tag = (from w in Global.DataNote where w.City == "CityN" & w.LoaiPhieu == "Loai3" & w.Truong == "102" select w.Note).FirstOrDefault();
            txt_Truong_104.Tag = (from w in Global.DataNote where w.City == "CityN" & w.LoaiPhieu == "Loai3" & w.Truong == "104" select w.Note).FirstOrDefault();
            txt_Truong_106.Tag = (from w in Global.DataNote where w.City == "CityN" & w.LoaiPhieu == "Loai3" & w.Truong == "106" select w.Note).FirstOrDefault();
            txt_Truong_108.Tag = (from w in Global.DataNote where w.City == "CityN" & w.LoaiPhieu == "Loai3" & w.Truong == "108" select w.Note).FirstOrDefault();
            txt_Truong_110.Tag = (from w in Global.DataNote where w.City == "CityN" & w.LoaiPhieu == "Loai3" & w.Truong == "110" select w.Note).FirstOrDefault();
            txt_Truong_112.Tag = (from w in Global.DataNote where w.City == "CityN" & w.LoaiPhieu == "Loai3" & w.Truong == "112" select w.Note).FirstOrDefault();
            txt_Truong_114.Tag = (from w in Global.DataNote where w.City == "CityN" & w.LoaiPhieu == "Loai3" & w.Truong == "114" select w.Note).FirstOrDefault();
            txt_Truong_116.Tag = (from w in Global.DataNote where w.City == "CityN" & w.LoaiPhieu == "Loai3" & w.Truong == "116" select w.Note).FirstOrDefault();
            txt_Truong_118.Tag = (from w in Global.DataNote where w.City == "CityN" & w.LoaiPhieu == "Loai3" & w.Truong == "118" select w.Note).FirstOrDefault();
            txt_Truong_120.Tag = (from w in Global.DataNote where w.City == "CityN" & w.LoaiPhieu == "Loai3" & w.Truong == "120" select w.Note).FirstOrDefault();
            txt_Truong_122.Tag = (from w in Global.DataNote where w.City == "CityN" & w.LoaiPhieu == "Loai3" & w.Truong == "122" select w.Note).FirstOrDefault();
            txt_Truong_124.Tag = (from w in Global.DataNote where w.City == "CityN" & w.LoaiPhieu == "Loai3" & w.Truong == "124" select w.Note).FirstOrDefault();
            txt_Truong_126.Tag = (from w in Global.DataNote where w.City == "CityN" & w.LoaiPhieu == "Loai3" & w.Truong == "126" select w.Note).FirstOrDefault();
            txt_Truong_128.Tag = (from w in Global.DataNote where w.City == "CityN" & w.LoaiPhieu == "Loai3" & w.Truong == "128" select w.Note).FirstOrDefault();
            txt_Truong_130.Tag = (from w in Global.DataNote where w.City == "CityN" & w.LoaiPhieu == "Loai3" & w.Truong == "130" select w.Note).FirstOrDefault();
            txt_Truong_132.Tag = (from w in Global.DataNote where w.City == "CityN" & w.LoaiPhieu == "Loai3" & w.Truong == "132" select w.Note).FirstOrDefault();
            txt_Truong_134.Tag = (from w in Global.DataNote where w.City == "CityN" & w.LoaiPhieu == "Loai3" & w.Truong == "134" select w.Note).FirstOrDefault();
            txt_Truong_136.Tag = (from w in Global.DataNote where w.City == "CityN" & w.LoaiPhieu == "Loai3" & w.Truong == "136" select w.Note).FirstOrDefault();
            txt_Truong_138_1.Tag = txt_Truong_138_2.Tag = txt_Truong_138_3.Tag = txt_Truong_138_4.Tag = (from w in Global.DataNote where w.City == "CityN" & w.LoaiPhieu == "Loai3" & w.Truong == "138" select w.Note).FirstOrDefault();
            txt_Truong_140.Tag = (from w in Global.DataNote where w.City == "CityN" & w.LoaiPhieu == "Loai3" & w.Truong == "140" select w.Note).FirstOrDefault();
            txt_Truong_142.Tag = (from w in Global.DataNote where w.City == "CityN" & w.LoaiPhieu == "Loai3" & w.Truong == "142" select w.Note).FirstOrDefault();
            txt_Truong_144.Tag = (from w in Global.DataNote where w.City == "CityN" & w.LoaiPhieu == "Loai3" & w.Truong == "144" select w.Note).FirstOrDefault();
            txt_Truong_146.Tag = (from w in Global.DataNote where w.City == "CityN" & w.LoaiPhieu == "Loai3" & w.Truong == "146" select w.Note).FirstOrDefault();
            txt_Truong_150.Tag = (from w in Global.DataNote where w.City == "CityN" & w.LoaiPhieu == "Loai3" & w.Truong == "150" select w.Note).FirstOrDefault();
        }
        private void SetGotFocus()
        {
            textEdit1.GotFocus += Txt_Truong_015_GotFocus;
            textEdit2.GotFocus += Txt_Truong_015_GotFocus;
            textEdit3.GotFocus += Txt_Truong_015_GotFocus;
            textEdit4.GotFocus += Txt_Truong_015_GotFocus;
            textEdit5.GotFocus += Txt_Truong_015_GotFocus;
            textEdit8.GotFocus += Txt_Truong_015_GotFocus;
            txt_Truong_011.GotFocus += Txt_Truong_015_GotFocus;
            txt_Truong_014.GotFocus += Txt_Truong_015_GotFocus;
            txt_Truong_016.GotFocus += Txt_Truong_015_GotFocus;
            txt_Truong_020.GotFocus += Txt_Truong_015_GotFocus;
            txt_Truong_022.GotFocus += Txt_Truong_015_GotFocus;
            txt_Truong_024.GotFocus += Txt_Truong_015_GotFocus;
            txt_Truong_026.GotFocus += Txt_Truong_015_GotFocus;
            txt_Truong_028.GotFocus += Txt_Truong_015_GotFocus;
            txt_Truong_030.GotFocus += Txt_Truong_015_GotFocus;
            txt_Truong_032.GotFocus += Txt_Truong_015_GotFocus;
            txt_Truong_034.GotFocus += Txt_Truong_015_GotFocus;
            txt_Truong_036.GotFocus += Txt_Truong_015_GotFocus;
            txt_Truong_038.GotFocus += Txt_Truong_015_GotFocus;
            txt_Truong_040.GotFocus += Txt_Truong_015_GotFocus;
            txt_Truong_042.GotFocus += Txt_Truong_015_GotFocus;
            txt_Truong_044.GotFocus += Txt_Truong_015_GotFocus;
            txt_Truong_046.GotFocus += Txt_Truong_015_GotFocus;
            txt_Truong_048.GotFocus += Txt_Truong_015_GotFocus;
            txt_Truong_050.GotFocus += Txt_Truong_015_GotFocus;
            txt_Truong_052.GotFocus += Txt_Truong_015_GotFocus;
            txt_Truong_054.GotFocus += Txt_Truong_015_GotFocus;
            txt_Truong_056.GotFocus += Txt_Truong_015_GotFocus;
            txt_Truong_058.GotFocus += Txt_Truong_015_GotFocus;
            txt_Truong_060.GotFocus += Txt_Truong_015_GotFocus;
            txt_Truong_062.GotFocus += Txt_Truong_015_GotFocus;
            txt_Truong_064.GotFocus += Txt_Truong_015_GotFocus;
            txt_Truong_066.GotFocus += Txt_Truong_015_GotFocus;
            txt_Truong_068.GotFocus += Txt_Truong_015_GotFocus;
            txt_Truong_072.GotFocus += Txt_Truong_015_GotFocus;
            txt_Truong_074_1.GotFocus += Txt_Truong_015_GotFocus;
            txt_Truong_074_2.GotFocus += Txt_Truong_015_GotFocus;
            txt_Truong_074_3.GotFocus += Txt_Truong_015_GotFocus;
            txt_Truong_076.GotFocus += Txt_Truong_015_GotFocus;
            txt_Truong_082.GotFocus += Txt_Truong_015_GotFocus;
            txt_Truong_084.GotFocus += Txt_Truong_015_GotFocus;
            txt_Truong_086.GotFocus += Txt_Truong_015_GotFocus;
            txt_Truong_088.GotFocus += Txt_Truong_015_GotFocus;
            txt_Truong_090.GotFocus += Txt_Truong_015_GotFocus;
            txt_Truong_092.GotFocus += Txt_Truong_015_GotFocus;
            txt_Truong_094.GotFocus += Txt_Truong_015_GotFocus;
            txt_Truong_096.GotFocus += Txt_Truong_015_GotFocus;
            txt_Truong_098.GotFocus += Txt_Truong_015_GotFocus;
            txt_Truong_100.GotFocus += Txt_Truong_015_GotFocus;
            txt_Truong_102.GotFocus += Txt_Truong_015_GotFocus;
            txt_Truong_104.GotFocus += Txt_Truong_015_GotFocus;
            txt_Truong_106.GotFocus += Txt_Truong_015_GotFocus;
            txt_Truong_108.GotFocus += Txt_Truong_015_GotFocus;
            txt_Truong_110.GotFocus += Txt_Truong_015_GotFocus;
            txt_Truong_112.GotFocus += Txt_Truong_015_GotFocus;
            txt_Truong_114.GotFocus += Txt_Truong_015_GotFocus;
            txt_Truong_116.GotFocus += Txt_Truong_015_GotFocus;
            txt_Truong_118.GotFocus += Txt_Truong_015_GotFocus;
            txt_Truong_120.GotFocus += Txt_Truong_015_GotFocus;
            txt_Truong_122.GotFocus += Txt_Truong_015_GotFocus;
            txt_Truong_124.GotFocus += Txt_Truong_015_GotFocus;
            txt_Truong_126.GotFocus += Txt_Truong_015_GotFocus;
            txt_Truong_128.GotFocus += Txt_Truong_015_GotFocus;
            txt_Truong_130.GotFocus += Txt_Truong_015_GotFocus;
            txt_Truong_132.GotFocus += Txt_Truong_015_GotFocus;
            txt_Truong_134.GotFocus += Txt_Truong_015_GotFocus;
            txt_Truong_136.GotFocus += Txt_Truong_015_GotFocus;
            txt_Truong_138_1.GotFocus += Txt_Truong_015_GotFocus;
            txt_Truong_138_2.GotFocus += Txt_Truong_015_GotFocus;
            txt_Truong_138_3.GotFocus += Txt_Truong_015_GotFocus;
            txt_Truong_138_4.GotFocus += Txt_Truong_015_GotFocus;
            txt_Truong_140.GotFocus += Txt_Truong_015_GotFocus;
            txt_Truong_142.GotFocus += Txt_Truong_015_GotFocus;
            txt_Truong_144.GotFocus += Txt_Truong_015_GotFocus;
            txt_Truong_146.GotFocus += Txt_Truong_015_GotFocus;
            txt_Truong_150.GotFocus += Txt_Truong_015_GotFocus;
        }
        private void Txt_Truong_015_GotFocus(object sender, EventArgs e)
        {
            Focus(((TextEdit)sender)?.Name, ((TextEdit)sender)?.Tag + "");
            ((TextEdit)sender).SelectAll();
        }
        public void UC_CityN_Loai3_Load(object sender, EventArgs e)
        {
            SetDataLookUpEdit();
            txt_Truong_076.Properties.DataSource = category;
            txt_Truong_076.Properties.DisplayMember = "Value_JP";
            txt_Truong_076.Properties.ValueMember = "Value_SO";
            if (Global.FlagLoad)
                return;
            SetTag();
            SetGotFocus();
        }

        private void txt_Truong_011_TextChanged(object sender, EventArgs e)
        {
            if (((TextEdit)sender).Text.IndexOf('?') >= 0)
                ((TextEdit)sender).Text = "?";
        }
        public void ResetData()
        {
            textEdit1.Text = "";
            textEdit2.Text = "";
            textEdit3.Text = "";
            textEdit4.Text = "";
            textEdit5.Text = "";
            textEdit8.Text = "";
            txt_Truong_011.Text = "";
            txt_Truong_014.Text = "";
            txt_Truong_016.Text = "";
            txt_Truong_020.Text = "";
            txt_Truong_022.Text = "";
            txt_Truong_024.Text = "";
            txt_Truong_026.Text = "";
            txt_Truong_028.Text = "";
            txt_Truong_030.Text = "";
            txt_Truong_032.Text = "";
            txt_Truong_034.Text = "";
            txt_Truong_036.Text = "";
            txt_Truong_038.Text = "";
            txt_Truong_040.Text = "";
            txt_Truong_042.Text = "";
            txt_Truong_044.Text = "";
            txt_Truong_046.Text = "";
            txt_Truong_048.Text = "";
            txt_Truong_050.Text = "";
            txt_Truong_052.Text = "";
            txt_Truong_054.Text = "";
            txt_Truong_056.Text = "";
            txt_Truong_058.Text = "";
            txt_Truong_060.Text = "";
            txt_Truong_062.Text = "";
            txt_Truong_064.Text = "";
            txt_Truong_066.Text = "";
            txt_Truong_068.Text = "";
            txt_Truong_072.Text = "";
            txt_Truong_074_1.Text = "";
            txt_Truong_074_2.Text = "";
            txt_Truong_074_3.Text = "";
            txt_Truong_076.ItemIndex = 0;
            txt_Truong_082.Text = "";
            txt_Truong_084.Text = "";
            txt_Truong_086.Text = "";
            txt_Truong_088.Text = "";
            txt_Truong_090.Text = "";
            txt_Truong_092.Text = "";
            txt_Truong_094.Text = "";
            txt_Truong_096.Text = "";
            txt_Truong_098.Text = "";
            txt_Truong_100.Text = "";
            txt_Truong_102.Text = "";
            txt_Truong_104.Text = "";
            txt_Truong_106.Text = "";
            txt_Truong_108.Text = "";
            txt_Truong_110.Text = "";
            txt_Truong_112.Text = "";
            txt_Truong_114.Text = "";
            txt_Truong_116.Text = "";
            txt_Truong_118.Text = "";
            txt_Truong_120.Text = "";
            txt_Truong_122.Text = "";
            txt_Truong_124.Text = "";
            txt_Truong_126.Text = "";
            txt_Truong_128.Text = "";
            txt_Truong_130.Text = "";
            txt_Truong_132.Text = "";
            txt_Truong_134.Text = "";
            txt_Truong_136.Text = "";
            txt_Truong_138_1.Text = "";
            txt_Truong_138_2.Text = "";
            txt_Truong_138_3.Text = "";
            txt_Truong_138_4.Text = "";
            txt_Truong_140.Text = "";
            txt_Truong_142.Text = "";
            txt_Truong_144.Text = "";
            txt_Truong_146.Text = "";
            txt_Truong_150.Text = "";

            txt_Truong_011.ForeColor = Color.Black;
            txt_Truong_014.ForeColor = Color.Black;
            txt_Truong_016.ForeColor = Color.Black;
            txt_Truong_020.ForeColor = Color.Black;
            txt_Truong_022.ForeColor = Color.Black;
            txt_Truong_024.ForeColor = Color.Black;
            txt_Truong_026.ForeColor = Color.Black;
            txt_Truong_028.ForeColor = Color.Black;
            txt_Truong_030.ForeColor = Color.Black;
            txt_Truong_032.ForeColor = Color.Black;
            txt_Truong_034.ForeColor = Color.Black;
            txt_Truong_036.ForeColor = Color.Black;
            txt_Truong_038.ForeColor = Color.Black;
            txt_Truong_040.ForeColor = Color.Black;
            txt_Truong_042.ForeColor = Color.Black;
            txt_Truong_044.ForeColor = Color.Black;
            txt_Truong_046.ForeColor = Color.Black;
            txt_Truong_048.ForeColor = Color.Black;
            txt_Truong_050.ForeColor = Color.Black;
            txt_Truong_052.ForeColor = Color.Black;
            txt_Truong_054.ForeColor = Color.Black;
            txt_Truong_056.ForeColor = Color.Black;
            txt_Truong_058.ForeColor = Color.Black;
            txt_Truong_060.ForeColor = Color.Black;
            txt_Truong_062.ForeColor = Color.Black;
            txt_Truong_064.ForeColor = Color.Black;
            txt_Truong_066.ForeColor = Color.Black;
            txt_Truong_068.ForeColor = Color.Black;
            txt_Truong_072.ForeColor = Color.Black;
            txt_Truong_074_1.ForeColor = Color.Black;
            txt_Truong_074_2.ForeColor = Color.Black;
            txt_Truong_074_3.ForeColor = Color.Black;
            txt_Truong_076.ForeColor = Color.Black;
            txt_Truong_082.ForeColor = Color.Black;
            txt_Truong_084.ForeColor = Color.Black;
            txt_Truong_086.ForeColor = Color.Black;
            txt_Truong_088.ForeColor = Color.Black;
            txt_Truong_090.ForeColor = Color.Black;
            txt_Truong_092.ForeColor = Color.Black;
            txt_Truong_094.ForeColor = Color.Black;
            txt_Truong_096.ForeColor = Color.Black;
            txt_Truong_098.ForeColor = Color.Black;
            txt_Truong_100.ForeColor = Color.Black;
            txt_Truong_102.ForeColor = Color.Black;
            txt_Truong_104.ForeColor = Color.Black;
            txt_Truong_106.ForeColor = Color.Black;
            txt_Truong_108.ForeColor = Color.Black;
            txt_Truong_110.ForeColor = Color.Black;
            txt_Truong_112.ForeColor = Color.Black;
            txt_Truong_114.ForeColor = Color.Black;
            txt_Truong_116.ForeColor = Color.Black;
            txt_Truong_118.ForeColor = Color.Black;
            txt_Truong_120.ForeColor = Color.Black;
            txt_Truong_122.ForeColor = Color.Black;
            txt_Truong_124.ForeColor = Color.Black;
            txt_Truong_126.ForeColor = Color.Black;
            txt_Truong_128.ForeColor = Color.Black;
            txt_Truong_130.ForeColor = Color.Black;
            txt_Truong_132.ForeColor = Color.Black;
            txt_Truong_134.ForeColor = Color.Black;
            txt_Truong_136.ForeColor = Color.Black;
            txt_Truong_138_1.ForeColor = Color.Black;
            txt_Truong_138_2.ForeColor = Color.Black;
            txt_Truong_138_3.ForeColor = Color.Black;
            txt_Truong_138_4.ForeColor = Color.Black;
            txt_Truong_140.ForeColor = Color.Black;
            txt_Truong_142.ForeColor = Color.Black;
            txt_Truong_144.ForeColor = Color.Black;
            txt_Truong_146.ForeColor = Color.Black;
            txt_Truong_150.ForeColor = Color.Black;

            txt_Truong_011.BackColor = Color.White;
            txt_Truong_014.BackColor = Color.White;
            txt_Truong_016.BackColor = Color.White;
            txt_Truong_020.BackColor = Color.White;
            txt_Truong_022.BackColor = Color.White;
            txt_Truong_024.BackColor = Color.White;
            txt_Truong_026.BackColor = Color.White;
            txt_Truong_028.BackColor = Color.White;
            txt_Truong_030.BackColor = Color.White;
            txt_Truong_032.BackColor = Color.White;
            txt_Truong_034.BackColor = Color.White;
            txt_Truong_036.BackColor = Color.White;
            txt_Truong_038.BackColor = Color.White;
            txt_Truong_040.BackColor = Color.White;
            txt_Truong_042.BackColor = Color.White;
            txt_Truong_044.BackColor = Color.White;
            txt_Truong_046.BackColor = Color.White;
            txt_Truong_048.BackColor = Color.White;
            txt_Truong_050.BackColor = Color.White;
            txt_Truong_052.BackColor = Color.White;
            txt_Truong_054.BackColor = Color.White;
            txt_Truong_056.BackColor = Color.White;
            txt_Truong_058.BackColor = Color.White;
            txt_Truong_060.BackColor = Color.White;
            txt_Truong_062.BackColor = Color.White;
            txt_Truong_064.BackColor = Color.White;
            txt_Truong_066.BackColor = Color.White;
            txt_Truong_068.BackColor = Color.White;
            txt_Truong_072.BackColor = Color.White;
            txt_Truong_074_1.BackColor = Color.White;
            txt_Truong_074_2.BackColor = Color.White;
            txt_Truong_074_3.BackColor = Color.White;
            txt_Truong_076.BackColor = Color.White;
            txt_Truong_082.BackColor = Color.White;
            txt_Truong_084.BackColor = Color.White;
            txt_Truong_086.BackColor = Color.White;
            txt_Truong_088.BackColor = Color.White;
            txt_Truong_090.BackColor = Color.White;
            txt_Truong_092.BackColor = Color.White;
            txt_Truong_094.BackColor = Color.White;
            txt_Truong_096.BackColor = Color.White;
            txt_Truong_098.BackColor = Color.White;
            txt_Truong_100.BackColor = Color.White;
            txt_Truong_102.BackColor = Color.White;
            txt_Truong_104.BackColor = Color.White;
            txt_Truong_106.BackColor = Color.White;
            txt_Truong_108.BackColor = Color.White;
            txt_Truong_110.BackColor = Color.White;
            txt_Truong_112.BackColor = Color.White;
            txt_Truong_114.BackColor = Color.White;
            txt_Truong_116.BackColor = Color.White;
            txt_Truong_118.BackColor = Color.White;
            txt_Truong_120.BackColor = Color.White;
            txt_Truong_122.BackColor = Color.White;
            txt_Truong_124.BackColor = Color.White;
            txt_Truong_126.BackColor = Color.White;
            txt_Truong_128.BackColor = Color.White;
            txt_Truong_130.BackColor = Color.White;
            txt_Truong_132.BackColor = Color.White;
            txt_Truong_134.BackColor = Color.White;
            txt_Truong_136.BackColor = Color.White;
            txt_Truong_138_1.BackColor = Color.White;
            txt_Truong_138_2.BackColor = Color.White;
            txt_Truong_138_3.BackColor = Color.White;
            txt_Truong_138_4.BackColor = Color.White;
            txt_Truong_140.BackColor = Color.White;
            txt_Truong_142.BackColor = Color.White;
            txt_Truong_144.BackColor = Color.White;
            txt_Truong_146.BackColor = Color.White;
            txt_Truong_150.BackColor = Color.White;

            txt_Truong_138_1.Enabled = true;
            txt_Truong_138_2.Enabled = true;
            txt_Truong_138_3.Enabled = true;
            txt_Truong_138_4.Enabled = true;
        }
        public bool IsEmpty()
        {
            if (string.IsNullOrEmpty(txt_Truong_011.Text) &&
                string.IsNullOrEmpty(txt_Truong_014.Text) &&
                string.IsNullOrEmpty(txt_Truong_016.Text) &&
                string.IsNullOrEmpty(txt_Truong_020.Text) &&
                string.IsNullOrEmpty(txt_Truong_022.Text) &&
                string.IsNullOrEmpty(txt_Truong_024.Text) &&
                string.IsNullOrEmpty(txt_Truong_026.Text) &&
                string.IsNullOrEmpty(txt_Truong_028.Text) &&
                string.IsNullOrEmpty(txt_Truong_030.Text) &&
                string.IsNullOrEmpty(txt_Truong_032.Text) &&
                string.IsNullOrEmpty(txt_Truong_034.Text) &&
                string.IsNullOrEmpty(txt_Truong_036.Text) &&
                string.IsNullOrEmpty(txt_Truong_038.Text) &&
                string.IsNullOrEmpty(txt_Truong_040.Text) &&
                string.IsNullOrEmpty(txt_Truong_042.Text) &&
                string.IsNullOrEmpty(txt_Truong_044.Text) &&
                string.IsNullOrEmpty(txt_Truong_046.Text) &&
                string.IsNullOrEmpty(txt_Truong_048.Text) &&
                string.IsNullOrEmpty(txt_Truong_050.Text) &&
                string.IsNullOrEmpty(txt_Truong_052.Text) &&
                string.IsNullOrEmpty(txt_Truong_054.Text) &&
                string.IsNullOrEmpty(txt_Truong_056.Text) &&
                string.IsNullOrEmpty(txt_Truong_058.Text) &&
                string.IsNullOrEmpty(txt_Truong_060.Text) &&
                string.IsNullOrEmpty(txt_Truong_062.Text) &&
                string.IsNullOrEmpty(txt_Truong_064.Text) &&
                string.IsNullOrEmpty(txt_Truong_066.Text) &&
                string.IsNullOrEmpty(txt_Truong_068.Text) &&
                string.IsNullOrEmpty(txt_Truong_072.Text) &&
                string.IsNullOrEmpty(txt_Truong_074_1.Text) &&
                string.IsNullOrEmpty(txt_Truong_074_2.Text) &&
                string.IsNullOrEmpty(txt_Truong_074_3.Text) &&
                string.IsNullOrEmpty(txt_Truong_076.Text) &&
                string.IsNullOrEmpty(txt_Truong_082.Text) &&
                string.IsNullOrEmpty(txt_Truong_084.Text) &&
                string.IsNullOrEmpty(txt_Truong_086.Text) &&
                string.IsNullOrEmpty(txt_Truong_088.Text) &&
                string.IsNullOrEmpty(txt_Truong_090.Text) &&
                string.IsNullOrEmpty(txt_Truong_092.Text) &&
                string.IsNullOrEmpty(txt_Truong_094.Text) &&
                string.IsNullOrEmpty(txt_Truong_096.Text) &&
                string.IsNullOrEmpty(txt_Truong_098.Text) &&
                string.IsNullOrEmpty(txt_Truong_100.Text) &&
                string.IsNullOrEmpty(txt_Truong_102.Text) &&
                string.IsNullOrEmpty(txt_Truong_104.Text) &&
                string.IsNullOrEmpty(txt_Truong_106.Text) &&
                string.IsNullOrEmpty(txt_Truong_108.Text) &&
                string.IsNullOrEmpty(txt_Truong_110.Text) &&
                string.IsNullOrEmpty(txt_Truong_112.Text) &&
                string.IsNullOrEmpty(txt_Truong_114.Text) &&
                string.IsNullOrEmpty(txt_Truong_116.Text) &&
                string.IsNullOrEmpty(txt_Truong_118.Text) &&
                string.IsNullOrEmpty(txt_Truong_120.Text) &&
                string.IsNullOrEmpty(txt_Truong_122.Text) &&
                string.IsNullOrEmpty(txt_Truong_124.Text) &&
                string.IsNullOrEmpty(txt_Truong_126.Text) &&
                string.IsNullOrEmpty(txt_Truong_128.Text) &&
                string.IsNullOrEmpty(txt_Truong_130.Text) &&
                string.IsNullOrEmpty(txt_Truong_132.Text) &&
                string.IsNullOrEmpty(txt_Truong_134.Text) &&
                string.IsNullOrEmpty(txt_Truong_136.Text) &&
                string.IsNullOrEmpty(txt_Truong_138_1.Text) &&
                string.IsNullOrEmpty(txt_Truong_138_2.Text) &&
                string.IsNullOrEmpty(txt_Truong_138_3.Text) &&
                string.IsNullOrEmpty(txt_Truong_138_4.Text) &&
                string.IsNullOrEmpty(txt_Truong_140.Text) &&
                string.IsNullOrEmpty(txt_Truong_142.Text) &&
                string.IsNullOrEmpty(txt_Truong_144.Text) &&
                string.IsNullOrEmpty(txt_Truong_146.Text) &&
                string.IsNullOrEmpty(txt_Truong_150.Text) &&
                !chk_QC.Checked)
                return true;
            return false;
        }
        public bool CheckQC()
        {
            if (txt_Truong_011.Text.IndexOf('?') >= 0 ||
                txt_Truong_014.Text.IndexOf('?') >= 0 ||
                txt_Truong_016.Text.IndexOf('?') >= 0 ||
                txt_Truong_020.Text.IndexOf('?') >= 0 ||
                txt_Truong_022.Text.IndexOf('?') >= 0 ||
                txt_Truong_024.Text.IndexOf('?') >= 0 ||
                txt_Truong_026.Text.IndexOf('?') >= 0 ||
                txt_Truong_028.Text.IndexOf('?') >= 0 ||
                txt_Truong_030.Text.IndexOf('?') >= 0 ||
                txt_Truong_032.Text.IndexOf('?') >= 0 ||
                txt_Truong_034.Text.IndexOf('?') >= 0 ||
                txt_Truong_036.Text.IndexOf('?') >= 0 ||
                txt_Truong_038.Text.IndexOf('?') >= 0 ||
                txt_Truong_040.Text.IndexOf('?') >= 0 ||
                txt_Truong_042.Text.IndexOf('?') >= 0 ||
                txt_Truong_044.Text.IndexOf('?') >= 0 ||
                txt_Truong_046.Text.IndexOf('?') >= 0 ||
                txt_Truong_048.Text.IndexOf('?') >= 0 ||
                txt_Truong_050.Text.IndexOf('?') >= 0 ||
                txt_Truong_052.Text.IndexOf('?') >= 0 ||
                txt_Truong_054.Text.IndexOf('?') >= 0 ||
                txt_Truong_056.Text.IndexOf('?') >= 0 ||
                txt_Truong_058.Text.IndexOf('?') >= 0 ||
                txt_Truong_060.Text.IndexOf('?') >= 0 ||
                txt_Truong_062.Text.IndexOf('?') >= 0 ||
                txt_Truong_064.Text.IndexOf('?') >= 0 ||
                txt_Truong_066.Text.IndexOf('?') >= 0 ||
                txt_Truong_068.Text.IndexOf('?') >= 0 ||
                txt_Truong_072.Text.IndexOf('?') >= 0 ||
                txt_Truong_074_1.Text.IndexOf('?') >= 0 ||
                txt_Truong_074_2.Text.IndexOf('?') >= 0 ||
                txt_Truong_074_3.Text.IndexOf('?') >= 0 ||
                txt_Truong_076.Text.IndexOf('?') >= 0 ||
                txt_Truong_082.Text.IndexOf('?') >= 0 ||
                txt_Truong_084.Text.IndexOf('?') >= 0 ||
                txt_Truong_086.Text.IndexOf('?') >= 0 ||
                txt_Truong_088.Text.IndexOf('?') >= 0 ||
                txt_Truong_090.Text.IndexOf('?') >= 0 ||
                txt_Truong_092.Text.IndexOf('?') >= 0 ||
                txt_Truong_094.Text.IndexOf('?') >= 0 ||
                txt_Truong_096.Text.IndexOf('?') >= 0 ||
                txt_Truong_098.Text.IndexOf('?') >= 0 ||
                txt_Truong_100.Text.IndexOf('?') >= 0 ||
                txt_Truong_102.Text.IndexOf('?') >= 0 ||
                txt_Truong_104.Text.IndexOf('?') >= 0 ||
                txt_Truong_106.Text.IndexOf('?') >= 0 ||
                txt_Truong_108.Text.IndexOf('?') >= 0 ||
                txt_Truong_110.Text.IndexOf('?') >= 0 ||
                txt_Truong_112.Text.IndexOf('?') >= 0 ||
                txt_Truong_114.Text.IndexOf('?') >= 0 ||
                txt_Truong_116.Text.IndexOf('?') >= 0 ||
                txt_Truong_118.Text.IndexOf('?') >= 0 ||
                txt_Truong_120.Text.IndexOf('?') >= 0 ||
                txt_Truong_122.Text.IndexOf('?') >= 0 ||
                txt_Truong_124.Text.IndexOf('?') >= 0 ||
                txt_Truong_126.Text.IndexOf('?') >= 0 ||
                txt_Truong_128.Text.IndexOf('?') >= 0 ||
                txt_Truong_130.Text.IndexOf('?') >= 0 ||
                txt_Truong_132.Text.IndexOf('?') >= 0 ||
                txt_Truong_134.Text.IndexOf('?') >= 0 ||
                txt_Truong_136.Text.IndexOf('?') >= 0 ||
                txt_Truong_138_1.Text.IndexOf('?') >= 0 ||
                txt_Truong_138_2.Text.IndexOf('?') >= 0 ||
                txt_Truong_138_3.Text.IndexOf('?') >= 0 ||
                txt_Truong_138_4.Text.IndexOf('?') >= 0 ||
                txt_Truong_140.Text.IndexOf('?') >= 0 ||
                txt_Truong_142.Text.IndexOf('?') >= 0 ||
                txt_Truong_144.Text.IndexOf('?') >= 0 ||
                txt_Truong_146.Text.IndexOf('?') >= 0 ||
                txt_Truong_150.Text.IndexOf('?') >= 0 ||
                chk_QC.Checked)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool CheckSubmit()
        {
            if (!string.IsNullOrEmpty(txt_Truong_050.Text) & string.IsNullOrEmpty(txt_Truong_052.Text))
                return false;
            else if (!string.IsNullOrEmpty(txt_Truong_050.Text) &
                    !string.IsNullOrEmpty(txt_Truong_052.Text) &
                    txt_Truong_050.Text.IndexOf("?") < 0 &
                    txt_Truong_050.Text.IndexOf("●") < 0 &
                    txt_Truong_052.Text.IndexOf("?") < 0 &
                    txt_Truong_052.Text.IndexOf("●") < 0)
            {
                if (Double.Parse(txt_Truong_050.Text.Replace(",","")) > Double.Parse(txt_Truong_052.Text.Replace(",", "")))
                    return false;
                else
                    return true;
            }
            else
                return true;
        }
        public void Save_CityN_Loai3(string Batch, string image)
        {
            Global.Db.Insert_DESo_CityN(Batch, image, Global.StrUserName, CheckQC(), "Loai3",
                                        "", "", "", "", "", "", "", "", "", "",
                                        txt_Truong_011.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_011.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_011.Text,
                                        "", "",
                                        txt_Truong_014.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_014.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_014.Text,
                                        "",
                                        txt_Truong_016.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_016.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_016.Text,
                                        "",
                                        "",
                                        "",
                                        txt_Truong_020.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_020.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_020.Text.Replace(",",""),
                                        "",
                                        txt_Truong_022.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_022.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_022.Text.Replace(",", ""),
                                        "",
                                        txt_Truong_024.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_024.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_024.Text.Replace(",", ""),
                                        "",
                                        txt_Truong_026.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_026.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_026.Text.Replace(",", ""),
                                        "",
                                        txt_Truong_028.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_028.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_028.Text,
                                        "",
                                        txt_Truong_030.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_030.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_030.Text,
                                        "",
                                        txt_Truong_032.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_032.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_032.Text.Replace(",", ""),
                                        "",
                                        txt_Truong_034.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_034.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_034.Text,
                                        "",
                                        txt_Truong_036.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_036.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_036.Text,
                                        "",
                                        txt_Truong_038.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_038.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_038.Text,
                                        "",
                                        txt_Truong_040.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_040.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_040.Text,
                                        "",
                                        txt_Truong_042.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_042.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_042.Text,
                                        "",
                                        txt_Truong_044.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_044.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_044.Text,
                                        "",
                                        txt_Truong_046.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_046.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_046.Text,
                                        "",
                                        txt_Truong_048.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_048.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_048.Text,
                                        "",
                                        txt_Truong_050.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_050.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_050.Text.Replace(",", ""),
                                        "",
                                        txt_Truong_052.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_052.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_052.Text.Replace(",", ""),
                                        "",
                                        txt_Truong_054.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_054.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_054.Text.Replace(",", ""),
                                        "",
                                        txt_Truong_056.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_056.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_056.Text.Replace(",", ""),
                                        "",
                                        txt_Truong_058.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_058.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_058.Text.Replace(",", ""),
                                        "",
                                        txt_Truong_060.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_060.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_060.Text.Replace(",", ""),
                                        "",
                                        txt_Truong_062.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_062.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_062.Text.Replace(",", ""),
                                        "",
                                        txt_Truong_064.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_064.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_064.Text.Replace(",", ""),
                                        "",
                                        txt_Truong_066.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_066.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_066.Text.Replace(",", ""),
                                        "",
                                        txt_Truong_068.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_068.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_068.Text.Replace(",", ""),
                                        "",
                                        "",
                                        "",
                                        txt_Truong_072.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_072.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_072.Text.Replace(",", ""),
                                        "",
                                        txt_Truong_074_1.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_074_1.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_074_1.Text,
                                        txt_Truong_074_2.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_074_2.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_074_2.Text,
                                        txt_Truong_074_3.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_074_3.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_074_3.Text,
                                        "",
                                        txt_Truong_076.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_076.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_076.Text,
                                        "",
                                        "",
                                        "",
                                        "",
                                        "",
                                        txt_Truong_082.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_082.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_082.Text.Replace(",", ""),
                                        "",
                                        txt_Truong_084.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_084.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_084.Text.Replace(",", ""),
                                        "",
                                        txt_Truong_086.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_086.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_086.Text,
                                        "",
                                        txt_Truong_088.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_088.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_088.Text,
                                        "",
                                        txt_Truong_090.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_090.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_090.Text,
                                        "",
                                        txt_Truong_092.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_092.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_092.Text,
                                        "",
                                        txt_Truong_094.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_094.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_094.Text,
                                        "",
                                        txt_Truong_096.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_096.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_096.Text,
                                        "",
                                        txt_Truong_098.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_098.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_098.Text,
                                        "",
                                        txt_Truong_100.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_100.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_100.Text,
                                        "",
                                        txt_Truong_102.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_102.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_102.Text,
                                        "",
                                        txt_Truong_104.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_104.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_104.Text,
                                        "",
                                        txt_Truong_106.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_106.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_106.Text,
                                        "",
                                        txt_Truong_108.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_108.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_108.Text,
                                        "",
                                        txt_Truong_110.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_110.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_110.Text,
                                        "",
                                        txt_Truong_112.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_112.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_112.Text,
                                        "",
                                        txt_Truong_114.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_114.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_114.Text,
                                        "",
                                        txt_Truong_116.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_116.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_116.Text,
                                        "",
                                        txt_Truong_118.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_118.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_118.Text,
                                        "",
                                        txt_Truong_120.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_120.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_120.Text,
                                        "",
                                        txt_Truong_122.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_122.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_122.Text,
                                        "",
                                        txt_Truong_124.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_124.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_124.Text,
                                        "",
                                        txt_Truong_126.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_126.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_126.Text,
                                        "",
                                        txt_Truong_128.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_128.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_128.Text,
                                        "",
                                        txt_Truong_130.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_130.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_130.Text,
                                        "",
                                        txt_Truong_132.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_132.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_132.Text,
                                        "",
                                        txt_Truong_134.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_134.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_134.Text,
                                        "",
                                        txt_Truong_136.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_136.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_136.Text,
                                        "",
                                        txt_Truong_138_1.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_138_1.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_138_1.Text,
                                        txt_Truong_138_2.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_138_2.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_138_2.Text,
                                        txt_Truong_138_3.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_138_3.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_138_3.Text,
                                        txt_Truong_138_4.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_138_4.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_138_4.Text,
                                        "",
                                        txt_Truong_140.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_140.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_140.Text,
                                        "",
                                        txt_Truong_142.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_142.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_142.Text,
                                        "",
                                        txt_Truong_144.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_144.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_144.Text,
                                        "",
                                        txt_Truong_146.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_146.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_146.Text,
                                        "",
                                        "",
                                        "",
                                        txt_Truong_150.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_150.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_150.Text,
                                        "",
                                        "",
                                        "",
                                        "",
                                        "",
                                        "");
        }
        public void Edit_Save_CityN_Loai3(string Batch, string image)
        {
            Global.Db.Sua_va_Luu_DeSo_CityN(Batch, image, Global.StrUserName, Global.StrCity, "Loai3",
                                        "", "", "", "", "", "", "", "", "", "",
                                        txt_Truong_011.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_011.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_011.Text,
                                        "", "",
                                        txt_Truong_014.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_014.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_014.Text,
                                        "",
                                        txt_Truong_016.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_016.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_016.Text,
                                        "",
                                        "",
                                        "",
                                        txt_Truong_020.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_020.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_020.Text.Replace(",", ""),
                                        "",
                                        txt_Truong_022.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_022.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_022.Text.Replace(",", ""),
                                        "",
                                        txt_Truong_024.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_024.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_024.Text.Replace(",", ""),
                                        "",
                                        txt_Truong_026.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_026.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_026.Text.Replace(",", ""),
                                        "",
                                        txt_Truong_028.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_028.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_028.Text,
                                        "",
                                        txt_Truong_030.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_030.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_030.Text,
                                        "",
                                        txt_Truong_032.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_032.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_032.Text.Replace(",", ""),
                                        "",
                                        txt_Truong_034.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_034.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_034.Text,
                                        "",
                                        txt_Truong_036.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_036.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_036.Text,
                                        "",
                                        txt_Truong_038.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_038.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_038.Text,
                                        "",
                                        txt_Truong_040.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_040.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_040.Text,
                                        "",
                                        txt_Truong_042.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_042.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_042.Text,
                                        "",
                                        txt_Truong_044.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_044.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_044.Text,
                                        "",
                                        txt_Truong_046.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_046.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_046.Text,
                                        "",
                                        txt_Truong_048.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_048.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_048.Text,
                                        "",
                                        txt_Truong_050.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_050.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_050.Text.Replace(",", ""),
                                        "",
                                        txt_Truong_052.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_052.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_052.Text.Replace(",", ""),
                                        "",
                                        txt_Truong_054.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_054.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_054.Text.Replace(",", ""),
                                        "",
                                        txt_Truong_056.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_056.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_056.Text.Replace(",", ""),
                                        "",
                                        txt_Truong_058.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_058.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_058.Text.Replace(",", ""),
                                        "",
                                        txt_Truong_060.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_060.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_060.Text.Replace(",", ""),
                                        "",
                                        txt_Truong_062.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_062.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_062.Text.Replace(",", ""),
                                        "",
                                        txt_Truong_064.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_064.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_064.Text.Replace(",", ""),
                                        "",
                                        txt_Truong_066.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_066.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_066.Text.Replace(",", ""),
                                        "",
                                        txt_Truong_068.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_068.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_068.Text.Replace(",", ""),
                                        "",
                                        "",
                                        "",
                                        txt_Truong_072.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_072.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_072.Text.Replace(",", ""),
                                        "",
                                        txt_Truong_074_1.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_074_1.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_074_1.Text,
                                        txt_Truong_074_2.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_074_2.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_074_2.Text,
                                        txt_Truong_074_3.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_074_3.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_074_3.Text,
                                        "",
                                        txt_Truong_076.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_076.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_076.Text,
                                        "",
                                        "",
                                        "",
                                        "",
                                        "",
                                        txt_Truong_082.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_082.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_082.Text.Replace(",", ""),
                                        "",
                                        txt_Truong_084.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_084.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_084.Text.Replace(",", ""),
                                        "",
                                        txt_Truong_086.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_086.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_086.Text,
                                        "",
                                        txt_Truong_088.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_088.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_088.Text,
                                        "",
                                        txt_Truong_090.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_090.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_090.Text,
                                        "",
                                        txt_Truong_092.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_092.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_092.Text,
                                        "",
                                        txt_Truong_094.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_094.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_094.Text,
                                        "",
                                        txt_Truong_096.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_096.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_096.Text,
                                        "",
                                        txt_Truong_098.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_098.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_098.Text,
                                        "",
                                        txt_Truong_100.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_100.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_100.Text,
                                        "",
                                        txt_Truong_102.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_102.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_102.Text,
                                        "",
                                        txt_Truong_104.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_104.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_104.Text,
                                        "",
                                        txt_Truong_106.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_106.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_106.Text,
                                        "",
                                        txt_Truong_108.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_108.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_108.Text,
                                        "",
                                        txt_Truong_110.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_110.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_110.Text,
                                        "",
                                        txt_Truong_112.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_112.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_112.Text,
                                        "",
                                        txt_Truong_114.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_114.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_114.Text,
                                        "",
                                        txt_Truong_116.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_116.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_116.Text,
                                        "",
                                        txt_Truong_118.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_118.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_118.Text,
                                        "",
                                        txt_Truong_120.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_120.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_120.Text,
                                        "",
                                        txt_Truong_122.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_122.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_122.Text,
                                        "",
                                        txt_Truong_124.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_124.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_124.Text,
                                        "",
                                        txt_Truong_126.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_126.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_126.Text,
                                        "",
                                        txt_Truong_128.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_128.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_128.Text,
                                        "",
                                        txt_Truong_130.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_130.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_130.Text,
                                        "",
                                        txt_Truong_132.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_132.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_132.Text,
                                        "",
                                        txt_Truong_134.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_134.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_134.Text,
                                        "",
                                        txt_Truong_136.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_136.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_136.Text,
                                        "",
                                        txt_Truong_138_1.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_138_1.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_138_1.Text,
                                        txt_Truong_138_2.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_138_2.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_138_2.Text,
                                        txt_Truong_138_3.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_138_3.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_138_3.Text,
                                        txt_Truong_138_4.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_138_4.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_138_4.Text,
                                        "",
                                        txt_Truong_140.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_140.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_140.Text,
                                        "",
                                        txt_Truong_142.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_142.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_142.Text,
                                        "",
                                        txt_Truong_144.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_144.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_144.Text,
                                        "",
                                        txt_Truong_146.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_146.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_146.Text,
                                        "",
                                        "",
                                        "",
                                        txt_Truong_150.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_150.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_150.Text,
                                        "",
                                        "",
                                        "",
                                        "",
                                        "",
                                        "", CheckQC());
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
        private void DoiMauTruongTien(int soByteBe, int soBytelon, TextEdit textBox)
        {
            if (textBox.Text.IndexOf('?') < 0 && textBox.Text.IndexOf('●') < 0 && !string.IsNullOrEmpty(textBox.Text))
            {
                if (textBox.Text.Substring(0, 1) == "-")
                {
                    if (textBox.Text.Length >= soByteBe && textBox.Text.Length <= soBytelon + 1)
                    {
                        textBox.ForeColor = Color.Black;
                        textBox.BackColor = Color.White;
                    }
                    else
                    {
                        textBox.ForeColor = Color.White;
                        textBox.BackColor = Color.Red;
                    }
                }
                else
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
            }
            else
            {
                textBox.BackColor = Color.White;
                textBox.ForeColor = Color.Black;
            }
        }
        private void Tab_Left_Right(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                SendKeys.Send("+{Tab}");
            }
            else if (e.KeyCode == Keys.Right)
            {
                SendKeys.Send("{Tab}");
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
            DoiMau(0, 25, (TextEdit)sender);
        }

        private void txt_Truong_016_EditValueChanged(object sender, EventArgs e)
        {
            Changed?.Invoke(sender, e);
            DoiMau(0, 12, (TextEdit)sender);
        }

        private void txt_Truong_020_EditValueChanged(object sender, EventArgs e)
        {
            Changed?.Invoke(sender, e);
            DoiMauTruongTien(0, 13, (TextEdit)sender);
        }

        private void txt_Truong_028_EditValueChanged(object sender, EventArgs e)
        {
            Changed?.Invoke(sender, e);
            DoiMau(0, 1, (TextEdit)sender);
        }

        private void txt_Truong_032_EditValueChanged(object sender, EventArgs e)
        {
            Changed?.Invoke(sender, e);
            DoiMauTruongTien(0, 7, (TextEdit)sender);
        }

        private void txt_Truong_040_EditValueChanged(object sender, EventArgs e)
        {
            Changed?.Invoke(sender, e);
            DoiMau(0, 2, (TextEdit)sender);
        }

        private void txt_Truong_050_EditValueChanged(object sender, EventArgs e)
        {
            Changed?.Invoke(sender, e);
            DoiMauTruongTien(0, 9, (TextEdit)sender);
        }

        private void txt_Truong_056_EditValueChanged(object sender, EventArgs e)
        {
            Changed?.Invoke(sender, e);
            DoiMauTruongTien(0, 6, (TextEdit)sender);
        }

        private void txt_Truong_060_EditValueChanged(object sender, EventArgs e)
        {
            Changed?.Invoke(sender, e);
            DoiMauTruongTien(0, 10, (TextEdit)sender);
        }

        private void txt_Truong_076_EditValueChanged(object sender, EventArgs e)
        {
            Changed?.Invoke(sender, e);
        }

        private void txt_Truong_086_EditValueChanged(object sender, EventArgs e)
        {
            Changed?.Invoke(sender, e);
            DoiMau(0, 12, (TextEdit)sender);
        }

        private void txt_Truong_104_EditValueChanged(object sender, EventArgs e)
        {
            Changed?.Invoke(sender, e);
        }

        private void txt_Truong_106_EditValueChanged(object sender, EventArgs e)
        {
            Changed?.Invoke(sender, e);
        }

        private void chk_QC_CheckedChanged(object sender, EventArgs e)
        {
            Changed?.Invoke(sender, e);
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.QC = chk_QC.Checked;
            Settings.Default.LoaiPhieu = "Loai3";
            Settings.Default.Save();
        }

        private void txt_Truong_020_KeyUp(object sender, KeyEventArgs e)
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

        private void txt_Truong_138_1_EditValueChanged(object sender, EventArgs e)
        {
            Changed?.Invoke(sender, e);
            DoiMau(0, 1, (TextEdit)sender);
            if (!string.IsNullOrEmpty(txt_Truong_138_1.Text))
            {
                txt_Truong_138_2.Enabled = false;
                txt_Truong_138_3.Enabled = false;
                txt_Truong_138_4.Enabled = false;
            }
            else
            {
                txt_Truong_138_2.Enabled = true;
                txt_Truong_138_3.Enabled = true;
                txt_Truong_138_4.Enabled = true;
            }
        }

        private void txt_Truong_138_2_EditValueChanged(object sender, EventArgs e)
        {
            Changed?.Invoke(sender, e);
            DoiMau(0, 1, (TextEdit)sender);
            if (!string.IsNullOrEmpty(txt_Truong_138_2.Text))
            {
                txt_Truong_138_1.Enabled = false;
                txt_Truong_138_3.Enabled = false;
                txt_Truong_138_4.Enabled = false;
            }
            else
            {
                txt_Truong_138_1.Enabled = true;
                txt_Truong_138_3.Enabled = true;
                txt_Truong_138_4.Enabled = true;
            }
        }

        private void txt_Truong_138_3_EditValueChanged(object sender, EventArgs e)
        {
            Changed?.Invoke(sender, e);
            DoiMau(0, 1, (TextEdit)sender);
            if (!string.IsNullOrEmpty(txt_Truong_138_3.Text))
            {
                txt_Truong_138_2.Enabled = false;
                txt_Truong_138_1.Enabled = false;
                txt_Truong_138_4.Enabled = false;
            }
            else
            {
                txt_Truong_138_2.Enabled = true;
                txt_Truong_138_1.Enabled = true;
                txt_Truong_138_4.Enabled = true;
            }
        }

        private void txt_Truong_138_4_EditValueChanged(object sender, EventArgs e)
        {
            Changed?.Invoke(sender, e);
            DoiMau(0, 1, (TextEdit)sender);
            if (!string.IsNullOrEmpty(txt_Truong_138_4.Text))
            {
                txt_Truong_138_2.Enabled = false;
                txt_Truong_138_3.Enabled = false;
                txt_Truong_138_1.Enabled = false;
            }
            else
            {
                txt_Truong_138_2.Enabled = true;
                txt_Truong_138_3.Enabled = true;
                txt_Truong_138_1.Enabled = true;
            }
        }

        private void txt_Truong_011_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong11 = ((TextEdit)sender).Text;
            Settings.Default.LoaiPhieu = "Loai3";
            Settings.Default.Save();
        }

        private void txt_Truong_108_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong108 = ((TextEdit)sender).Text;
            Settings.Default.LoaiPhieu = "Loai3";
            Settings.Default.Save();
        }

        private void txt_Truong_014_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong14 = ((TextEdit)sender).Text;
            Settings.Default.LoaiPhieu = "Loai3";
            Settings.Default.Save();
        }


        private void txt_Truong_016_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong16 = ((TextEdit)sender).Text;
            Settings.Default.LoaiPhieu = "Loai3";
            Settings.Default.Save();
        }

        private void txt_Truong_020_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong20 = ((TextEdit)sender).Text;
            Settings.Default.LoaiPhieu = "Loai3";
            Settings.Default.Save();
        }

        private void txt_Truong_022_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong22 = ((TextEdit)sender).Text;
            Settings.Default.LoaiPhieu = "Loai3";
            Settings.Default.Save();
        }

        private void txt_Truong_024_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong24 = ((TextEdit)sender).Text;
            Settings.Default.LoaiPhieu = "Loai3";
            Settings.Default.Save();
        }

        private void txt_Truong_026_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong26 = ((TextEdit)sender).Text;
            Settings.Default.LoaiPhieu = "Loai3";
            Settings.Default.Save();
        }

        private void txt_Truong_028_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong28 = ((TextEdit)sender).Text;
            Settings.Default.LoaiPhieu = "Loai3";
            Settings.Default.Save();
        }

        private void txt_Truong_030_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong30 = ((TextEdit)sender).Text;
            Settings.Default.LoaiPhieu = "Loai3";
            Settings.Default.Save();
        }

        private void txt_Truong_032_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong32 = ((TextEdit)sender).Text;
            Settings.Default.LoaiPhieu = "Loai3";
            Settings.Default.Save();
        }

        private void txt_Truong_034_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong34 = ((TextEdit)sender).Text;
            Settings.Default.LoaiPhieu = "Loai3";
            Settings.Default.Save();
        }

        private void txt_Truong_036_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong36 = ((TextEdit)sender).Text;
            Settings.Default.LoaiPhieu = "Loai3";
            Settings.Default.Save();
        }

        private void txt_Truong_038_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong38 = ((TextEdit)sender).Text;
            Settings.Default.LoaiPhieu = "Loai3";
            Settings.Default.Save();
        }

        private void txt_Truong_040_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong40 = ((TextEdit)sender).Text;
            Settings.Default.LoaiPhieu = "Loai3";
            Settings.Default.Save();
        }

        private void txt_Truong_042_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong42 = ((TextEdit)sender).Text;
            Settings.Default.LoaiPhieu = "Loai3";
            Settings.Default.Save();
        }

        private void txt_Truong_044_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong44 = ((TextEdit)sender).Text;
            Settings.Default.LoaiPhieu = "Loai3";
            Settings.Default.Save();
        }

        private void txt_Truong_046_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong46 = ((TextEdit)sender).Text;
            Settings.Default.LoaiPhieu = "Loai3";
            Settings.Default.Save();
        }

        private void txt_Truong_048_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong48 = ((TextEdit)sender).Text;
            Settings.Default.LoaiPhieu = "Loai3";
            Settings.Default.Save();
        }

        private void txt_Truong_050_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong50 = ((TextEdit)sender).Text;
            Settings.Default.LoaiPhieu = "Loai3";
            Settings.Default.Save();
        }

        private void txt_Truong_052_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong52 = ((TextEdit)sender).Text;
            Settings.Default.LoaiPhieu = "Loai3";
            Settings.Default.Save();
        }

        private void txt_Truong_054_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong54 = ((TextEdit)sender).Text;
            Settings.Default.LoaiPhieu = "Loai3";
            Settings.Default.Save();
        }

        private void txt_Truong_056_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong56 = ((TextEdit)sender).Text;
            Settings.Default.LoaiPhieu = "Loai3";
            Settings.Default.Save();
        }

        private void txt_Truong_058_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong58 = ((TextEdit)sender).Text;
            Settings.Default.LoaiPhieu = "Loai3";
            Settings.Default.Save();
        }

        private void txt_Truong_060_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong60 = ((TextEdit)sender).Text;
            Settings.Default.LoaiPhieu = "Loai3";
            Settings.Default.Save();
        }

        private void txt_Truong_062_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong62 = ((TextEdit)sender).Text;
            Settings.Default.LoaiPhieu = "Loai3";
            Settings.Default.Save();
        }

        private void txt_Truong_064_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong64 = ((TextEdit)sender).Text;
            Settings.Default.LoaiPhieu = "Loai3";
            Settings.Default.Save();
        }

        private void txt_Truong_066_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong66 = ((TextEdit)sender).Text;
            Settings.Default.LoaiPhieu = "Loai3";
            Settings.Default.Save();
        }

        private void txt_Truong_068_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong68 = ((TextEdit)sender).Text;
            Settings.Default.LoaiPhieu = "Loai3";
            Settings.Default.Save();
        }

        private void txt_Truong_074_1_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong74_1 = ((TextEdit)sender).Text;
            Settings.Default.LoaiPhieu = "Loai3";
            Settings.Default.Save();
        }

        private void txt_Truong_074_2_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong74_2 = ((TextEdit)sender).Text;
            Settings.Default.LoaiPhieu = "Loai3";
            Settings.Default.Save();
        }

        private void txt_Truong_074_3_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong74_3 = ((TextEdit)sender).Text;
            Settings.Default.LoaiPhieu = "Loai3";
            Settings.Default.Save();
        }

        private void txt_Truong_076_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong76 = ((TextEdit)sender).Text;
            Settings.Default.LoaiPhieu = "Loai3";
            Settings.Default.Save();
        }

        private void txt_Truong_072_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong72 = ((TextEdit)sender).Text;
            Settings.Default.LoaiPhieu = "Loai3";
            Settings.Default.Save();
        }

        private void txt_Truong_086_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong86 = ((TextEdit)sender).Text;
            Settings.Default.LoaiPhieu = "Loai3";
            Settings.Default.Save();
        }

        private void txt_Truong_088_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong88 = ((TextEdit)sender).Text;
            Settings.Default.LoaiPhieu = "Loai3";
            Settings.Default.Save();
        }

        private void txt_Truong_090_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong90 = ((TextEdit)sender).Text;
            Settings.Default.LoaiPhieu = "Loai3";
            Settings.Default.Save();
        }

        private void txt_Truong_092_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong92 = ((TextEdit)sender).Text;
            Settings.Default.LoaiPhieu = "Loai3";
            Settings.Default.Save();
        }

        private void txt_Truong_094_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong94 = ((TextEdit)sender).Text;
            Settings.Default.LoaiPhieu = "Loai3";
            Settings.Default.Save();
        }

        private void txt_Truong_082_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong82 = ((TextEdit)sender).Text;
            Settings.Default.LoaiPhieu = "Loai3";
            Settings.Default.Save();
        }

        private void txt_Truong_084_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong84 = ((TextEdit)sender).Text;
            Settings.Default.LoaiPhieu = "Loai3";
            Settings.Default.Save();
        }

        private void txt_Truong_096_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong96 = ((TextEdit)sender).Text;
            Settings.Default.LoaiPhieu = "Loai3";
            Settings.Default.Save();
        }

        private void txt_Truong_104_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong104 = ((TextEdit)sender).Text;
            Settings.Default.LoaiPhieu = "Loai3";
            Settings.Default.Save();
        }

        private void txt_Truong_098_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong98 = ((TextEdit)sender).Text;
            Settings.Default.LoaiPhieu = "Loai3";
            Settings.Default.Save();
        }

        private void txt_Truong_100_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong100 = ((TextEdit)sender).Text;
            Settings.Default.LoaiPhieu = "Loai3";
            Settings.Default.Save();
        }

        private void txt_Truong_106_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong106 = ((TextEdit)sender).Text;
            Settings.Default.LoaiPhieu = "Loai3";
            Settings.Default.Save();
        }

        private void txt_Truong_102_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong102 = ((TextEdit)sender).Text;
            Settings.Default.LoaiPhieu = "Loai3";
            Settings.Default.Save();
        }

        private void txt_Truong_110_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong110 = ((TextEdit)sender).Text;
            Settings.Default.LoaiPhieu = "Loai3";
            Settings.Default.Save();
        }

        private void txt_Truong_126_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong126 = ((TextEdit)sender).Text;
            Settings.Default.LoaiPhieu = "Loai3";
            Settings.Default.Save();
        }

        private void txt_Truong_112_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong112 = ((TextEdit)sender).Text;
            Settings.Default.LoaiPhieu = "Loai3";
            Settings.Default.Save();
        }

        private void txt_Truong_114_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong114 = ((TextEdit)sender).Text;
            Settings.Default.LoaiPhieu = "Loai3";
            Settings.Default.Save();
        }

        private void txt_Truong_116_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong116 = ((TextEdit)sender).Text;
            Settings.Default.LoaiPhieu = "Loai3";
            Settings.Default.Save();
        }

        private void txt_Truong_118_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong118 = ((TextEdit)sender).Text;
            Settings.Default.LoaiPhieu = "Loai3";
            Settings.Default.Save();
        }

        private void txt_Truong_120_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong120 = ((TextEdit)sender).Text;
            Settings.Default.LoaiPhieu = "Loai3";
            Settings.Default.Save();
        }

        private void txt_Truong_122_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong122 = ((TextEdit)sender).Text;
            Settings.Default.LoaiPhieu = "Loai3";
            Settings.Default.Save();
        }

        private void txt_Truong_124_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong124 = ((TextEdit)sender).Text;
            Settings.Default.LoaiPhieu = "Loai3";
            Settings.Default.Save();
        }

        private void txt_Truong_128_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong128 = ((TextEdit)sender).Text;
            Settings.Default.LoaiPhieu = "Loai3";
            Settings.Default.Save();
        }

        private void txt_Truong_130_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong130 = ((TextEdit)sender).Text;
            Settings.Default.LoaiPhieu = "Loai3";
            Settings.Default.Save();
        }

        private void txt_Truong_132_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong132 = ((TextEdit)sender).Text;
            Settings.Default.LoaiPhieu = "Loai3";
            Settings.Default.Save();
        }

        private void txt_Truong_134_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong134 = ((TextEdit)sender).Text;
            Settings.Default.LoaiPhieu = "Loai3";
            Settings.Default.Save();
        }

        private void txt_Truong_136_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong136 = ((TextEdit)sender).Text;
            Settings.Default.LoaiPhieu = "Loai3";
            Settings.Default.Save();
        }

        private void txt_Truong_138_1_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong138_1 = ((TextEdit)sender).Text;
            Settings.Default.LoaiPhieu = "Loai3";
            Settings.Default.Save();
        }

        private void txt_Truong_138_2_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong138_2 = ((TextEdit)sender).Text;
            Settings.Default.LoaiPhieu = "Loai3";
            Settings.Default.Save();
        }

        private void txt_Truong_138_3_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong138_3 = ((TextEdit)sender).Text;
            Settings.Default.LoaiPhieu = "Loai3";
            Settings.Default.Save();
        }

        private void txt_Truong_138_4_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong138_4 = ((TextEdit)sender).Text;
            Settings.Default.LoaiPhieu = "Loai3";
            Settings.Default.Save();
        }

        private void txt_Truong_140_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong140 = ((TextEdit)sender).Text;
            Settings.Default.LoaiPhieu = "Loai3";
            Settings.Default.Save();
        }

        private void txt_Truong_142_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong142 = ((TextEdit)sender).Text;
            Settings.Default.LoaiPhieu = "Loai3";
            Settings.Default.Save();
        }

        private void txt_Truong_144_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong144 = ((TextEdit)sender).Text;
            Settings.Default.LoaiPhieu = "Loai3";
            Settings.Default.Save();
        }

        private void txt_Truong_146_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong146 = ((TextEdit)sender).Text;
            Settings.Default.LoaiPhieu = "Loai3";
            Settings.Default.Save();
        }

        private void txt_Truong_150_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong150 = ((TextEdit)sender).Text;
            Settings.Default.LoaiPhieu = "Loai3";
            Settings.Default.Save();
        }

        private void txt_Truong_020_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Add)
            {
                ((TextEdit)sender).Text = ((TextEdit)sender).Text + "000";
                ((TextEdit)sender).SelectionStart = ((TextEdit)sender).Text.Length;
            }
            else if (e.KeyCode == Keys.Down && (((TextEdit)sender).Name == "txt_Truong_020" || ((TextEdit)sender).Name == "txt_Truong_022" || ((TextEdit)sender).Name == "txt_Truong_024" || ((TextEdit)sender).Name == "txt_Truong_026"))
            {
                txt_Truong_028.Focus();
            }
            else if (e.KeyCode == Keys.Up && (((TextEdit)sender).Name == "txt_Truong_020" || ((TextEdit)sender).Name == "txt_Truong_022" || ((TextEdit)sender).Name == "txt_Truong_024" || ((TextEdit)sender).Name == "txt_Truong_026"))
            {
                txt_Truong_016.Focus();
            }
            else if (e.KeyCode == Keys.Down && ((TextEdit)sender).Name == "txt_Truong_032")
            {
                txt_Truong_050.Focus();
            }
            else if (e.KeyCode == Keys.Up && ((TextEdit)sender).Name == "txt_Truong_032")
            {
                txt_Truong_020.Focus();
            }
            else if (e.KeyCode == Keys.Down && ((TextEdit)sender).Name == "txt_Truong_050")
            {
                txt_Truong_052.Focus();
            }
            else if (e.KeyCode == Keys.Up && ((TextEdit)sender).Name == "txt_Truong_050")
            {
                txt_Truong_028.Focus();
            }
            else if (e.KeyCode == Keys.Down && (((TextEdit)sender).Name == "txt_Truong_052" || ((TextEdit)sender).Name == "txt_Truong_054" || ((TextEdit)sender).Name == "txt_Truong_056" || ((TextEdit)sender).Name == "txt_Truong_058"))
            {
                txt_Truong_060.Focus();
            }
            else if (e.KeyCode == Keys.Up && (((TextEdit)sender).Name == "txt_Truong_052" || ((TextEdit)sender).Name == "txt_Truong_054" || ((TextEdit)sender).Name == "txt_Truong_056" || ((TextEdit)sender).Name == "txt_Truong_058"))
            {
                txt_Truong_050.Focus();
            }
            else if (e.KeyCode == Keys.Down && (((TextEdit)sender).Name == "txt_Truong_060" || ((TextEdit)sender).Name == "txt_Truong_062" || ((TextEdit)sender).Name == "txt_Truong_064" || ((TextEdit)sender).Name == "txt_Truong_066" || ((TextEdit)sender).Name == "txt_Truong_068"))
            {
                txt_Truong_074_1.Focus();
            }
            else if (e.KeyCode == Keys.Up && (((TextEdit)sender).Name == "txt_Truong_060" || ((TextEdit)sender).Name == "txt_Truong_062" || ((TextEdit)sender).Name == "txt_Truong_064" || ((TextEdit)sender).Name == "txt_Truong_066" || ((TextEdit)sender).Name == "txt_Truong_068"))
            {
                txt_Truong_052.Focus();
            }
            else if (e.KeyCode == Keys.Down && ((TextEdit)sender).Name == "txt_Truong_072")
            {
                txt_Truong_086.Focus();
            }
            else if (e.KeyCode == Keys.Up && ((TextEdit)sender).Name == "txt_Truong_072")
            {
                txt_Truong_074_1.Focus();
            }
            else if (e.KeyCode == Keys.Down && ((TextEdit)sender).Name == "txt_Truong_082")
            {
                txt_Truong_096.Focus();
            }
            else if (e.KeyCode == Keys.Up && ((TextEdit)sender).Name == "txt_Truong_082")
            {
                txt_Truong_072.Focus();
            }
            else if (e.KeyCode == Keys.Down && ((TextEdit)sender).Name == "txt_Truong_084")
            {
                txt_Truong_104.Focus();
            }
            else if (e.KeyCode == Keys.Up && ((TextEdit)sender).Name == "txt_Truong_084")
            {
                txt_Truong_104.Focus();
            }
            else { Tab_Left_Right(sender, e); }
        }

        private void txt_Truong_011_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                SendKeys.Send("{Tab}");
                SendKeys.Send("{Tab}");
            }
            else if (e.KeyCode == Keys.Up)
            { }
            else if (e.KeyCode == Keys.Right)
            { SendKeys.Send("{Tab}"); }
            else if (e.KeyCode == Keys.Left )
            { }
        }

        private void txt_Truong_028_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                txt_Truong_050.Focus();
            }
            else if (e.KeyCode == Keys.Up)
            {
                txt_Truong_020.Focus();
            }
            Tab_Left_Right(sender, e);
        }

        private void txt_Truong_108_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                SendKeys.Send("{Tab}");
            }
            else if(e.KeyCode==Keys.Up && ((TextEdit)sender).Name== "txt_Truong_014")
            {
                txt_Truong_011.Focus();
            }
            else if (e.KeyCode == Keys.Up)
            {
                SendKeys.Send("+{Tab}");
            }
            Tab_Left_Right(sender, e);
        }

        private void txt_Truong_074_1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                txt_Truong_072.Focus();
            }
            else if (e.KeyCode == Keys.Up)
            {
                txt_Truong_060.Focus();
            }
            Tab_Left_Right(sender, e);
        }

        private void txt_Truong_086_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                txt_Truong_088.Focus();
            }
            else if (e.KeyCode == Keys.Up)
            {
                txt_Truong_072.Focus();
            }
            Tab_Left_Right(sender, e);
        }

        private void txt_Truong_088_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                txt_Truong_090.Focus();
            }
            else if (e.KeyCode == Keys.Up)
            {
                txt_Truong_086.Focus();
            }
            Tab_Left_Right(sender, e);
        }

        private void txt_Truong_096_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                txt_Truong_098.Focus();
            }
            else if (e.KeyCode == Keys.Up)
            {
                txt_Truong_082.Focus();
            }
            Tab_Left_Right(sender, e);
        }

        private void txt_Truong_104_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                txt_Truong_106.Focus();
            }
            else if (e.KeyCode == Keys.Up)
            {
                txt_Truong_084.Focus();
            }
            Tab_Left_Right(sender, e);
        }

        private void txt_Truong_090_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                txt_Truong_092.Focus();
            }
            else if (e.KeyCode == Keys.Up)
            {
                txt_Truong_088.Focus();
            }
            Tab_Left_Right(sender, e);
        }

        private void txt_Truong_098_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                txt_Truong_100.Focus();
            }
            else if (e.KeyCode == Keys.Up)
            {
                txt_Truong_096.Focus();
            }
            Tab_Left_Right(sender, e);
        }

        private void txt_Truong_092_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                txt_Truong_094.Focus();
            }
            else if (e.KeyCode == Keys.Up)
            {
                txt_Truong_090.Focus();
            }
            Tab_Left_Right(sender, e);
        }

        private void txt_Truong_100_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                txt_Truong_102.Focus();
            }
            else if (e.KeyCode == Keys.Up)
            {
                txt_Truong_098.Focus();
            }
            Tab_Left_Right(sender, e);
        }

        private void txt_Truong_106_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                txt_Truong_102.Focus();
            }
            else if (e.KeyCode == Keys.Up)
            {
                txt_Truong_104.Focus();
            }
            Tab_Left_Right(sender, e);
        }

        private void txt_Truong_094_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                txt_Truong_110.Focus();
            }
            else if (e.KeyCode == Keys.Up)
            {
                txt_Truong_092.Focus();
            }
            Tab_Left_Right(sender, e);
        }

        private void txt_Truong_102_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                txt_Truong_110.Focus();
            }
            else if (e.KeyCode == Keys.Up)
            {
                txt_Truong_100.Focus();
            }
            Tab_Left_Right(sender, e);
        }

        private void txt_Truong_110_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                txt_Truong_128.Focus();
            }
            else if (e.KeyCode == Keys.Up)
            {
                txt_Truong_094.Focus();
            }
            Tab_Left_Right(sender, e);
        }

        private void txt_Truong_128_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                txt_Truong_138_1.Focus();
            }
            else if (e.KeyCode == Keys.Up)
            {
                txt_Truong_110.Focus();
            }
            Tab_Left_Right(sender, e);
        }

        private void txt_Truong_138_1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                txt_Truong_146.Focus();
            }
            else if (e.KeyCode == Keys.Up)
            {
                txt_Truong_128.Focus();
            }
            Tab_Left_Right(sender, e);
        }

        private void txt_Truong_146_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                txt_Truong_150.Focus();
            }
            else if (e.KeyCode == Keys.Up)
            {
                txt_Truong_138_1.Focus();
            }
            Tab_Left_Right(sender, e);
        }

        private void txt_Truong_150_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down||e.KeyCode==Keys.Right)
            {
            }
            else if (e.KeyCode == Keys.Up||e.KeyCode==Keys.Left)
            {
                txt_Truong_138_1.Focus();
            }
        }
    }
}
