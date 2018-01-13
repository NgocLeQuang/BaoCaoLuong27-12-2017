using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaoCaoLuong2018.BaoCaoLuonng2017
{
    public class Global
    {
        public static DataEntryBPODataContext db_BPO;
        public static DataBaoCaoLuongDataContext db_BCL;
        public static string StrMachine = "";
        public static string StrUserWindow = "";
        public static string StrIpAddress = "";
        public static string StrUsername = "";
        public static string StrBatch = "";
        public static string StrRole = "";
        public static string Strtoken = "";
        public static string StrIdimage = "";
        public static string StrCity = "";
        public static string StrCheck = "";
        public static string StrPath = @"\\10.10.10.248\BaoCaoLuong2017_CityS$";
        public static string Webservice = "http://10.10.10.248:8888/BaoCaoLuong2017_CityS/";
        public static string TenHinhThu2 = "";
        public static string GiaTriTruongSo4 = "";
        public static string StrIdProject = "BaoCaoLuong2017_CityS";
        public static int FreeTime = 0;


        public struct dataNote_
        {
            public string City { set; get; }
            public string LoaiPhieu { set; get; }
            public string Truong { set; get; }
            public string Note { set; get; }
        }

        public static List<dataNote_> DataNote = new List<dataNote_>();

    }
}
