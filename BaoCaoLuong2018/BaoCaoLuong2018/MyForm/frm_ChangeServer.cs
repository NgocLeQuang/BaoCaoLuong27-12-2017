﻿using BaoCaoLuong2018.Properties;
using System;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using BaoCaoLuong2018.MyData;
namespace BaoCaoLuong2018.MyForm
{
    public partial class frm_ChangeServer : DevExpress.XtraEditors.XtraForm
    {
        public frm_ChangeServer()
        {
            InitializeComponent();
        }

        private void frm_ChangeServer_Load(object sender, EventArgs e)
        {
            try
            {
                switch (Settings.Default.Server)
                {
                    case "Đà Nẵng":
                        rb_DaNang.Checked = true;
                        break;
                    case "Khác":
                        rb_Khac.Checked = true;
                        break;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Vui lòng chọn server!");
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (rb_DaNang.Checked == false && rb_Khac.Checked == false)
            {
                MessageBox.Show("Vui lòng chọn vị trí bạn làm việc.");
                return;
            }
            try
            {
                if (rb_DaNang.Checked)
                {
                    Settings.Default.Server = "Đà Nẵng";
                    Settings.Default.Save();
                    Global.Webservice = "http://192.168.165.10:8888/BaoCaoLuong2018/";
                    Global.Db = new DataBaoCaoLuongDataContext(@"Data Source=192.168.165.10\BPOSERVER;Initial Catalog=BaoCaoLuong2018;Persist Security Info=True;User ID=baocaoluong2018;Password=123@123a");
                    Global.Db.CommandTimeout = 5 * 60; // 5 Mins
                    Global.DbBpo = new DataBPODataContext(@"Data Source=192.168.165.10;Initial Catalog=DatabaseDataEntryBPO;Persist Security Info=True;User ID=bpoentry;Password=123@123a");
                    BaoCaoLuonng2017.Global.Webservice = "http://192.168.165.10:8888/BaoCaoLuong2017_CityS/";
                    BaoCaoLuonng2017.Global.db_BCL = new BaoCaoLuonng2017.DataBaoCaoLuongDataContext(@"Data Source=192.168.165.10\BPOSERVER;Initial Catalog=BaoCaoLuong2017_CityS;Persist Security Info=True;User ID=baocaoluong2018;Password=123@123a");
                    BaoCaoLuonng2017.Global.db_BCL.CommandTimeout = 5 * 60;
                    BaoCaoLuonng2017.Global.db_BPO = new BaoCaoLuonng2017.DataEntryBPODataContext(@"Data Source=192.168.165.10;Initial Catalog=DatabaseDataEntryBPO;Persist Security Info=True;User ID=bpoentry;Password=123@123a");
                }
                else if (rb_Khac.Checked)
                {
                    Settings.Default.Server = "Khác";
                    Settings.Default.Save();
                    Global.Webservice = "http://101.99.53.121:3606/BaoCaoLuong2018/";
                    Global.Db = new DataBaoCaoLuongDataContext(@"Data Source=101.99.53.121,3605;Initial Catalog=BaoCaoLuong2018;Persist Security Info=True;Network Library=DBMSSOCN;User ID=baocaoluong2018;Password=123@123a");
                    Global.Db.CommandTimeout = 5 * 60; // 5 Mins
                    Global.DbBpo = new DataBPODataContext(@"Data Source=101.99.53.121,3605;Initial Catalog=DatabaseDataEntryBPO;Persist Security Info=True;Network Library=DBMSSOCN;User ID=bpoentry;Password=123@123a");
                    BaoCaoLuonng2017.Global.Webservice = "http://101.99.53.121:3606/BaoCaoLuong2017_CityS/";
                    BaoCaoLuonng2017.Global.db_BCL = new BaoCaoLuonng2017.DataBaoCaoLuongDataContext(@"Data Source=101.99.53.121,3605;Initial Catalog=BaoCaoLuong2017_CityS;Persist Security Info=True;User ID=baocaoluong2018;Password=123@123a");
                    BaoCaoLuonng2017.Global.db_BCL.CommandTimeout = 5 * 60;
                    BaoCaoLuonng2017.Global.db_BPO = new BaoCaoLuonng2017.DataEntryBPODataContext(@"Data Source=101.99.53.121,3605;Initial Catalog=DatabaseDataEntryBPO;Persist Security Info=True;Network Library=DBMSSOCN;User ID=bpoentry;Password=123@123a");
                }
            }
            catch (Exception i)
            {
                MessageBox.Show(i.Message + "");
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        public static string GetLocalIpAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("Local IP Address Not Found!");
        }

        private void rb_DaNang_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_DaNang.Checked)
                rb_Khac.Checked = false;
            else
                rb_DaNang.Checked = false;

        }

        private void rb_Khac_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_Khac.Checked)
                rb_DaNang.Checked = false;
            else
                rb_Khac.Checked = false;
        }
    }
}