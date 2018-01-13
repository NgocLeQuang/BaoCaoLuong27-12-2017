﻿using System;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using System.Data;
using System.Diagnostics;
using System.Collections.Generic;
using BaoCaoLuong2018.Properties;
using BaoCaoLuong2018.MyData;

namespace BaoCaoLuong2018
{
    internal class Global
    {
        public static string StrUserName = "";
        public static string StrPcName = "";
        public static string StrDomainName = "";
        public static string StrBatch = "";
        public static string StrBatchID = "";
        public static string StrRole = "";
        public static string Token = "";
        public static string StrIdProject = "BaoCaoLuong2018";
        public static string StrCheck = "";
        public static List<dataNote_> DataNote = new List<dataNote_>();
        public static bool FlagLoad = false;
        public static bool FlagLoadCheck = false;


        public static string Version = "1.2.8";
        public static string StrCity="";
        public static bool FlagChangeSave = true;
        public static string StrPath = @"\\192.168.165.10\BaoCaoLuong2018$";
        public static string Webservice;
        public static DataBaoCaoLuongDataContext Db;
        public static DataBPODataContext DbBpo;
        public struct dataNote_
        {
            public string City { set; get; }
            public string LoaiPhieu { set; get; }
            public string Truong { set; get; }
            public string Note { set; get; }
        }
        public static string GetToken(string strUserName)
        {
            Random rnd = new Random();
            return MyClass.HashMD5.GetMd5Hash(DateTime.Now + strUserName + rnd.Next(1111, 9999));
        }

        public static IPAddress GetServerIpAddress()
        {
            if (!System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                return null;
            }
            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
            try
            {
                return host.AddressList.FirstOrDefault(ip => ip.AddressFamily == AddressFamily.InterNetwork);
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static bool CheckOutSource(string Role)
        {
            bool? OutSource = (from w in DbBpo.tbl_Versions where w.IDProject == StrIdProject select w.OutSource).FirstOrDefault();
            if (OutSource == false && Settings.Default.Server == "Khác" && (Role == "DESO"|| Role=="DEJP"))
                return true;
            return false;
        }
        public static void RunUpdateVersion()
        {
            //Process.Start(@"\\10.10.10.254\DE_Viet\2017\BaoCaoLuong2018");
            if (Settings.Default.Server == "Đà Nẵng")
                Process.Start(@"\\10.10.10.254\DE_Viet\2018\BaoCaoLuong2018\Tool");
            else
                Process.Start("https://drive.google.com/drive/folders/1PS0xuChchhWGzFrPEWFysBr-7IzRcY3W");
        }
    }
}
