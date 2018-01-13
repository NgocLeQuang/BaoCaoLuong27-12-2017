using Microsoft.Office.Interop.Excel;
using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace BaoCaoLuong2018.BaoCaoLuonng2017.MyForm
{
    public partial class frm_ExportExcel : DevExpress.XtraEditors.XtraForm
    {
        public frm_ExportExcel()
        {
            InitializeComponent();
        }

        private void frm_ExportExcel_Load(object sender, EventArgs e)
        {
            cbb_Batch.DataSource = Global.db_BCL.GetBatch();
            cbb_Batch.DisplayMember = "fBatchName";
            cbb_Batch.ValueMember = "fbatchname";
            cbb_Batch.Text = Global.StrBatch;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var nhap = (from w in Global.db_BCL.tbl_Images
                        where w.fbatchname == cbb_Batch.Text && w.ReadImageDESo == 2
                        select w.idimage).Count();
            var sohinh = (from w in Global.db_BCL.tbl_Images
                          where w.fbatchname == cbb_Batch.Text
                          select w.idimage).Count();
            var check = (from w in Global.db_BCL.tbl_MissImage_DESOs
                         where w.fBatchName == cbb_Batch.Text && w.Submit == 0
                         select w.IdImage).Count();
            if (sohinh > nhap)
            {
                MessageBox.Show("Chưa nhập xong DeSo!");
                return;
            }
            if (check > 0)
            {
                var list_user = (from w in Global.db_BCL.tbl_MissImage_DESOs
                                 where w.fBatchName == cbb_Batch.Text && w.Submit == 0
                                 select w.UserName).ToList();
                string sss = "";
                foreach (var item in list_user)
                {
                    sss += item + "\r\n";
                }

                if (list_user.Count > 0)
                {
                    MessageBox.Show("Những user lấy hình về nhưng không nhập: \r\n" + sss);
                    return;
                }
            }
            nhap = (from w in Global.db_BCL.tbl_Images
                    where w.fbatchname == cbb_Batch.Text && w.ReadImageDEJP == 2
                    select w.idimage).Count();
            check = (from w in Global.db_BCL.tbl_MissImage_DEJPs
                     where w.fBatchName == cbb_Batch.Text && w.Submit == 0
                     select w.IdImage).Count();
            if (sohinh > nhap)
            {
                MessageBox.Show("Chưa nhập xong DeJP!");
                return;
            }
            if (check > 0)
            {
                var list_user = (from w in Global.db_BCL.tbl_MissImage_DEJPs
                                 where w.fBatchName == cbb_Batch.Text && w.Submit == 0
                                 select w.UserName).ToList();
                string sss = "";
                foreach (var item in list_user)
                {
                    sss += item + "\r\n";
                }

                if (list_user.Count > 0)
                {
                    MessageBox.Show("Những user lấy hình về nhưng không nhập: \r\n" + sss);
                    return;
                }
            }
            var soloi = ((from w in Global.db_BCL.tbl_DESOs
                          where w.fBatchName == cbb_Batch.Text && w.Dem == 1
                          select w.IdImage).Count() / 2);

            check = (from w in Global.db_BCL.tbl_MissCheck_DESOs
                     where w.fBatchName == cbb_Batch.Text && w.Submit == 0
                     select w.IdImage).Count();
            if (check > 0 || soloi > 0)
            {
                MessageBox.Show("Chưa check xong DeSo!");
                return;
            }
            soloi = ((from w in Global.db_BCL.tbl_DEJPs
                      where w.fBatchName == cbb_Batch.Text && w.Dem == 1
                      select w.IdImage).Count() / 2);

            check = (from w in Global.db_BCL.tbl_MissCheck_DEJPs
                     where w.fBatchName == cbb_Batch.Text && w.Submit == 0
                     select w.IdImage).Count();
            if (check > 0 || soloi > 0)
            {
                MessageBox.Show("Chưa check xong DeJP!");
                return;
            }
            if (System.IO.File.Exists(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "\\S_City_ExportExcel.xlsx"))
            {
                System.IO.File.Delete(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "\\S_City_ExportExcel.xlsx");
                File.WriteAllBytes((Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/S_City_ExportExcel.xlsx"), Properties.Resources.S_City_ExportExcel);
            }
            else
            {
                System.IO.File.WriteAllBytes((System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "/S_City_ExportExcel.xlsx"), Properties.Resources.S_City_ExportExcel);
            }
            TableToExcel(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "\\S_City_ExportExcel.xlsx");
        }
        Microsoft.Office.Interop.Excel.Application App = null;
        Microsoft.Office.Interop.Excel.Workbook book = null;
        Microsoft.Office.Interop.Excel.Worksheet wrksheet = null;
        public bool TableToExcel(String strfilename)
        {
            try
            {
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = Global.db_BCL.ExportExcel(cbb_Batch.Text);
                App = new Microsoft.Office.Interop.Excel.Application();
                book = App.Workbooks.Open(strfilename, 0, true, 5, "", "", false, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "", true, false, 0, true, false, false);
                wrksheet = (Microsoft.Office.Interop.Excel.Worksheet)book.ActiveSheet;
                
                string truongso1_tobia = "";
                string dulieu_truong2_loai1 = "";
                string loaiphieu = "";
                bool truong3_loai2_trong = false;
                string dulieu_truong3_loai2 = "";
                string dulieu_truong4_loai2 = "";
                int hangloai2 = 0;
                int hangloai2_truong4 = 0;
                int h = 2;
                int hLoaiHai = 0;
                int hLoaiBa = 0;
                string TruongSo06Loai2 = "";
                string TruongSo06Loai3 = "";
                string TruongSo06Loai4 = "";

                string TruongSo5Loai2 = "";
                foreach (DataGridViewRow dr in dataGridView1.Rows)
                {
                    //i = 0 --> dr.Cells[i] la ten hinh
                    //i = 1 --> dr.Cells[i] la laoi hinh

                    //loại phiếu

                    switch (dr.Cells[1].Value.ToString())
                    {
                        case "Loai1":
                            //insert loai 1

                            truongso1_tobia = dr.Cells[2].Value != null ? dr.Cells[2].Value.ToString() : "";
                            dulieu_truong2_loai1 = dr.Cells[3].Value != null ? dr.Cells[3].Value.ToString() : "";

                            //bỏ qua nếu rỗng
                            if (string.IsNullOrEmpty(dr.Cells[2].Value != null ? dr.Cells[2].Value.ToString() : "") &&
                                string.IsNullOrEmpty(dr.Cells[3].Value != null ? dr.Cells[3].Value.ToString() : ""))
                            {
                                TruongSo06Loai2 = "";
                                TruongSo06Loai3 = "";
                                TruongSo06Loai4 = "";
                                hLoaiHai = 0;
                                hLoaiBa = 0;
                                break;
                            }

                            wrksheet.Cells[h, 1] = dr.Cells[0].Value != null ? dr.Cells[0].Value.ToString() : "";//tên iamge
                            wrksheet.Cells[h, 2] = dr.Cells[1].Value != null ? dr.Cells[1].Value.ToString() : "";//laoi
                            wrksheet.Cells[h, 3] = dr.Cells[2].Value != null ? dr.Cells[2].Value.ToString() : "";//truong so 1
                            wrksheet.Cells[h, 4] = dr.Cells[3].Value != null ? dr.Cells[3].Value.ToString() : "";// truong so2
                            wrksheet.Cells[h, 217] = dr.Cells[216].Value != null ? dr.Cells[216].Value.ToString() : "";

                            TruongSo06Loai2 = "";
                            TruongSo06Loai3 = "";
                            TruongSo06Loai4 = "";
                            hLoaiHai = 0;
                            hLoaiBa = 0;

                            break;

                        case "Loai2":
                            //insert loai 2
                            TruongSo06Loai3 = "";
                            TruongSo06Loai4 = "";
                            hLoaiBa = 0;

                            //bo qua neu rong
                            wrksheet.Cells[h, 1] = dr.Cells[0].Value != null ? dr.Cells[0].Value.ToString() : ""; //tên image
                            wrksheet.Cells[h, 2] = dr.Cells[1].Value != null ? dr.Cells[1].Value.ToString() : ""; //loại
                            wrksheet.Cells[h, 3] = "07";  // cố định 07
                            wrksheet.Cells[h, 4] = ""; //Cột C
                            wrksheet.Cells[h, 5] = dr.Cells[2].Value != null ? dr.Cells[2].Value.ToString() : ""; //Truong so 1
                            wrksheet.Cells[h, 6] = ""; //Cột E
                            wrksheet.Cells[h, 7] = dr.Cells[3].Value != null ? dr.Cells[3].Value.ToString() : ""; //Truong so 2
                            wrksheet.Cells[h, 8] = ""; //Cột G
                            wrksheet.Cells[h, 9] = dr.Cells[4].Value != null ? dr.Cells[4].Value.ToString() : ""; //Truong so 3
                            wrksheet.Cells[h, 10] = ""; //Cột I
                            wrksheet.Cells[h, 11] = dr.Cells[5].Value != null ? dr.Cells[5].Value.ToString() : ""; //Truong so 4
                            wrksheet.Cells[h, 12] = ""; //Cột K
                            wrksheet.Cells[h, 13] = dr.Cells[6].Value != null ? dr.Cells[6].Value.ToString() : ""; //Truong so 5
                            wrksheet.Cells[h, 14] = ""; //Cột M
                            wrksheet.Cells[h, 15] = dr.Cells[7].Value != null ? dr.Cells[7].Value.ToString() : ""; //Truong so 6
                            wrksheet.Cells[h, 16] = ""; //Cột O
                            wrksheet.Cells[h, 17] = dr.Cells[8].Value != null ? dr.Cells[8].Value.ToString() : ""; //Truong so 7
                            wrksheet.Cells[h, 18] = ""; //Cột Q
                            wrksheet.Cells[h, 19] = dr.Cells[9].Value != null ? dr.Cells[9].Value.ToString() : ""; //Truong so 8
                            wrksheet.Cells[h, 20] = ""; //Cột S
                            wrksheet.Cells[h, 21] = dr.Cells[10].Value != null ? dr.Cells[10].Value.ToString() : ""; //Truong so 9
                            wrksheet.Cells[h, 22] = ""; //Cột U
                            wrksheet.Cells[h, 23] = dr.Cells[11].Value != null ? dr.Cells[11].Value.ToString() : ""; //Truong so 10
                            wrksheet.Cells[h, 24] = ""; //Cột W
                            wrksheet.Cells[h, 146] = "";
                            break;

                        case "Loai3":
                            //insert loai 3
                            TruongSo06Loai4 = "";
                            if (string.IsNullOrEmpty(dr.Cells[3].Value != null ? dr.Cells[3].Value.ToString() : "")
                                && string.IsNullOrEmpty(dr.Cells[4].Value != null ? dr.Cells[4].Value.ToString() : "")
                                )
                                break;

                            wrksheet.Cells[h, 1] = dr.Cells[0].Value != null ? dr.Cells[0].Value.ToString() : "";
                            wrksheet.Cells[h, 2] = dr.Cells[1].Value != null ? dr.Cells[1].Value.ToString() : "";
                            wrksheet.Cells[h, 3] = "";
                            wrksheet.Cells[h, 4] = "";
                            wrksheet.Cells[h, 5] = "";
                            wrksheet.Cells[h, 6] = dr.Cells[3].Value != null ? dr.Cells[3].Value.ToString() : "";//truong so 4 moi - 2 cu
                            wrksheet.Cells[h, 7] = "";

                            //Bắt đầu trường số 6
                            if (truongso1_tobia == "06" || truongso1_tobia == "07")
                                wrksheet.Cells[h, 8] = "4091953036";
                            else if (string.IsNullOrEmpty(dr.Cells[4].Value != null ? dr.Cells[4].Value.ToString() : ""))
                                wrksheet.Cells[h, 8] = TruongSo06Loai2;
                            else
                                wrksheet.Cells[h, 8] = TruongSo06Loai3 = dr.Cells[4].Value != null ? dr.Cells[4].Value.ToString() : "";//truong so 6 moi -4 cu
                            hLoaiBa = h;

                            wrksheet.Cells[h, 12] = "9";
                            wrksheet.Cells[h, 217] = dr.Cells[216].Value != null ? dr.Cells[216].Value.ToString() : "";

                            break;

                        case "Loai4":
                            //insert loai 4

                            wrksheet.Cells[h, 1] = dr.Cells[0].Value != null ? dr.Cells[0].Value.ToString() : "";//idimage
                            wrksheet.Cells[h, 2] = dr.Cells[1].Value != null ? dr.Cells[1].Value.ToString() : "";//loai phieu
                            wrksheet.Cells[h, 3] = "01";//cố định 01
                            wrksheet.Cells[h, 4] = "";//trống
                            wrksheet.Cells[h, 5] = dr.Cells[2].Value != null ? dr.Cells[2].Value.ToString() : "";//truong so 1
                            wrksheet.Cells[h, 6] = "";//trống
                            wrksheet.Cells[h, 7] = dr.Cells[3].Value != null ? dr.Cells[3].Value.ToString() : "";//truong so 2
                            wrksheet.Cells[h, 8] = "";//trống
                            wrksheet.Cells[h, 9] = dr.Cells[4].Value != null ? dr.Cells[4].Value.ToString() : "";//truong so 3
                            wrksheet.Cells[h, 10] = "";//trống
                            wrksheet.Cells[h, 11] = dr.Cells[5].Value != null ? dr.Cells[5].Value.ToString() : "";//truong so 4
                            wrksheet.Cells[h, 12] = "";//trống
                            wrksheet.Cells[h, 13] = dr.Cells[6].Value != null ? dr.Cells[6].Value.ToString() : "";//truong so 5
                            wrksheet.Cells[h, 14] = "";//trống
                            wrksheet.Cells[h, 15] = dr.Cells[7].Value != null ? dr.Cells[7].Value.ToString() : "";//truong so 6
                            wrksheet.Cells[h, 16] = "";//trống
                            wrksheet.Cells[h, 17] = dr.Cells[8].Value != null ? dr.Cells[8].Value.ToString() : "";//truong so 7
                            wrksheet.Cells[h, 18] = "";//trống
                            wrksheet.Cells[h, 19] = dr.Cells[9].Value != null ? dr.Cells[9].Value.ToString() : "";//truong so 8
                            wrksheet.Cells[h, 20] = "";//trống
                            wrksheet.Cells[h, 21] = dr.Cells[10].Value != null ? dr.Cells[10].Value.ToString() : "";//truong so 9
                            wrksheet.Cells[h, 22] = "";//trống
                            wrksheet.Cells[h, 23] = dr.Cells[11].Value != null ? dr.Cells[11].Value.ToString() : "";//truong so 10
                            wrksheet.Cells[h, 24] = "";//trống
                            wrksheet.Cells[h, 25] = dr.Cells[12].Value != null ? dr.Cells[12].Value.ToString() : "";//truong so 11
                            wrksheet.Cells[h, 26] = "";//trống
                            wrksheet.Cells[h, 27] = dr.Cells[13].Value != null ? dr.Cells[13].Value.ToString() : "";//truong so 12
                            wrksheet.Cells[h, 28] = "";//trống
                            wrksheet.Cells[h, 29] = dr.Cells[14].Value != null ? dr.Cells[14].Value.ToString() : "";//truong so 13
                            wrksheet.Cells[h, 30] = "";//trống
                            wrksheet.Cells[h, 31] = dr.Cells[15].Value != null ? dr.Cells[15].Value.ToString() : "";//truong so 14
                            wrksheet.Cells[h, 32] = "";//trống
                            wrksheet.Cells[h, 33] = dr.Cells[16].Value != null ? dr.Cells[16].Value.ToString() : "";//truong so 15
                            wrksheet.Cells[h, 34] = "";//trống
                            wrksheet.Cells[h, 35] = dr.Cells[17].Value != null ? dr.Cells[17].Value.ToString() : "";//truong so 16
                            wrksheet.Cells[h, 36] = "";//trống
                            wrksheet.Cells[h, 37] = dr.Cells[18].Value != null ? dr.Cells[18].Value.ToString() : "";//truong so 17
                            wrksheet.Cells[h, 38] = "";//trống
                            wrksheet.Cells[h, 39] = dr.Cells[19].Value != null ? dr.Cells[19].Value.ToString() : "";//truong so 18
                            wrksheet.Cells[h, 40] = "";//trống
                            wrksheet.Cells[h, 41] = dr.Cells[20].Value != null ? dr.Cells[20].Value.ToString() : "";//truong so 19
                            wrksheet.Cells[h, 42] = "";//trống
                            wrksheet.Cells[h, 43] = dr.Cells[21].Value != null ? dr.Cells[21].Value.ToString() : "";//truong so 20
                            wrksheet.Cells[h, 44] = "";//trống
                            wrksheet.Cells[h, 45] = dr.Cells[22].Value != null ? dr.Cells[22].Value.ToString() : "";//truong so 21
                            wrksheet.Cells[h, 46] = dr.Cells[23].Value != null ? dr.Cells[23].Value.ToString() : "";//truong so 22
                            wrksheet.Cells[h, 47] = dr.Cells[24].Value != null ? dr.Cells[24].Value.ToString() : "";//truong so 23
                            wrksheet.Cells[h, 48] = dr.Cells[25].Value != null ? dr.Cells[25].Value.ToString() : "";//truong so 24
                            wrksheet.Cells[h, 49] = "";//trống
                            wrksheet.Cells[h, 50] = dr.Cells[26].Value != null ? dr.Cells[26].Value.ToString() : "";//truong so 25
                            wrksheet.Cells[h, 51] = "";//trống
                            wrksheet.Cells[h, 52] = dr.Cells[27].Value != null ? dr.Cells[27].Value.ToString() : "";//truong so 26
                            wrksheet.Cells[h, 53] = "";//trống
                            wrksheet.Cells[h, 54] = dr.Cells[28].Value != null ? dr.Cells[28].Value.ToString() : "";//truong so 27
                            wrksheet.Cells[h, 55] = "";//trống
                            wrksheet.Cells[h, 56] = dr.Cells[29].Value != null ? dr.Cells[29].Value.ToString() : "";//truong so 28
                            wrksheet.Cells[h, 57] = "";//trống
                            wrksheet.Cells[h, 58] = dr.Cells[30].Value != null ? dr.Cells[30].Value.ToString() : "";//truong so 29
                            wrksheet.Cells[h, 59] = "";//trống
                            wrksheet.Cells[h, 60] = dr.Cells[31].Value != null ? dr.Cells[31].Value.ToString() : "";//truong so 30
                            wrksheet.Cells[h, 61] = "";//trống
                            wrksheet.Cells[h, 62] = dr.Cells[32].Value != null ? dr.Cells[32].Value.ToString() : "";//truong so 31
                            wrksheet.Cells[h, 63] = "";//trống
                            wrksheet.Cells[h, 64] = dr.Cells[33].Value != null ? dr.Cells[33].Value.ToString() : "";//truong so 32
                            wrksheet.Cells[h, 65] = "";//trống
                            wrksheet.Cells[h, 66] = dr.Cells[34].Value != null ? dr.Cells[34].Value.ToString() : "";//truong so 33
                            wrksheet.Cells[h, 67] = "";//trống
                            wrksheet.Cells[h, 68] = dr.Cells[35].Value != null ? dr.Cells[35].Value.ToString() : "";//truong so 34
                            wrksheet.Cells[h, 69] = "";//trống
                            wrksheet.Cells[h, 70] = dr.Cells[36].Value != null ? dr.Cells[36].Value.ToString() : "";//truong so 35
                            wrksheet.Cells[h, 71] = "";//trống
                            wrksheet.Cells[h, 72] = dr.Cells[37].Value != null ? dr.Cells[37].Value.ToString() : "";//truong so 36
                            wrksheet.Cells[h, 73] = "";//trống
                           
                                wrksheet.Cells[h, 74] = dr.Cells[38].Value != null ? dr.Cells[38].Value.ToString() : "";//truong so 37
                                wrksheet.Cells[h, 75] = dr.Cells[39].Value != null ? dr.Cells[39].Value.ToString() : "";//truong so 38
                                wrksheet.Cells[h, 76] = dr.Cells[40].Value != null ? dr.Cells[40].Value.ToString() : "";//truong so 39
                           

                            wrksheet.Cells[h, 77] = "";//trống


                            wrksheet.Cells[h, 78] = dr.Cells[41].Value != null ? dr.Cells[41].Value.ToString() : "";//truong so 40
                          

                           
                                wrksheet.Cells[h, 79] = dr.Cells[42].Value != null ? dr.Cells[42].Value.ToString() : "";//truong so 41
                                wrksheet.Cells[h, 80] = dr.Cells[43].Value != null ? dr.Cells[43].Value.ToString() : "";//truong so 42
                                wrksheet.Cells[h, 81] = dr.Cells[44].Value != null ? dr.Cells[44].Value.ToString() : "";//truong so 43
                           

                            wrksheet.Cells[h, 82] = "";//trống

                           
                            wrksheet.Cells[h, 83] = dr.Cells[45].Value != null ? dr.Cells[45].Value.ToString() : "";//truong so 44
                            wrksheet.Cells[h, 84] = "";//trống

                            //dòng 2
                            //h++;

                            //wrksheet.Cells[h, 1] = dr.Cells[0].Value != null ? dr.Cells[0].Value.ToString() : "";//idimage
                            //wrksheet.Cells[h, 2] = dr.Cells[1].Value != null ? dr.Cells[1].Value.ToString() : "";//loai phieu

                            wrksheet.Cells[h, 85] = "02";//cố định 02
                            wrksheet.Cells[h, 86] = "";//trống
                            wrksheet.Cells[h, 87] = dr.Cells[46].Value != null ? dr.Cells[46].Value.ToString() : "";//truong so 45
                            wrksheet.Cells[h, 88] = "";//trống
                            wrksheet.Cells[h, 89] = dr.Cells[47].Value != null ? dr.Cells[47].Value.ToString() : "";//truong so 46
                            wrksheet.Cells[h, 90] = dr.Cells[48].Value != null ? dr.Cells[48].Value.ToString() : "";//truong so 47
                            wrksheet.Cells[h, 91] = dr.Cells[49].Value != null ? dr.Cells[49].Value.ToString() : "";//truong so 48
                            wrksheet.Cells[h, 92] = dr.Cells[50].Value != null ? dr.Cells[50].Value.ToString() : "";//truong so 49
                            wrksheet.Cells[h, 93] = dr.Cells[51].Value != null ? dr.Cells[51].Value.ToString() : "";//truong so 50
                            wrksheet.Cells[h, 94] = "";//trống
                            wrksheet.Cells[h, 95] = dr.Cells[52].Value != null ? ThemKyTubatKyPhiatruocNeuTrongThiDeTrong(dr.Cells[52].Value.ToString(), 7, "4") : "";//truong so 51
                            wrksheet.Cells[h, 96] = "";//trống
                            wrksheet.Cells[h, 97] = dr.Cells[53].Value != null ? dr.Cells[53].Value.ToString() : "";//truong so 52
                            wrksheet.Cells[h, 98] = "";//trống
                            wrksheet.Cells[h, 99] = dr.Cells[54].Value != null ? dr.Cells[54].Value.ToString() : "";//truong so 53
                            wrksheet.Cells[h, 100] = "";//trống
                            wrksheet.Cells[h, 101] = dr.Cells[55].Value != null ? ThemKyTubatKyPhiatruocNeuTrongThiDeTrong(dr.Cells[55].Value.ToString(), 7, "4") : "";//truong so 54
                            wrksheet.Cells[h, 102] = "";//trống
                            wrksheet.Cells[h, 103] = dr.Cells[56].Value != null ? dr.Cells[56].Value.ToString() : "";//truong so 55
                            wrksheet.Cells[h, 104] = "";//trống
                            wrksheet.Cells[h, 105] = dr.Cells[57].Value != null ? dr.Cells[57].Value.ToString() : "";//truong so 56
                            wrksheet.Cells[h, 106] = "";//trống
                            wrksheet.Cells[h, 107] = dr.Cells[58].Value != null ? dr.Cells[58].Value.ToString() : "";//truong so 57
                            wrksheet.Cells[h, 108] = "";//trống
                            wrksheet.Cells[h, 109] = dr.Cells[59].Value != null ? dr.Cells[59].Value.ToString() : "";//truong so 58
                            wrksheet.Cells[h, 110] = "";//trống
                            wrksheet.Cells[h, 111] = dr.Cells[60].Value != null ? dr.Cells[60].Value.ToString() : "";//truong so 59
                            wrksheet.Cells[h, 112] = "";//trống

                            //dòng 3
                            //h++;

                            //wrksheet.Cells[h, 1] = dr.Cells[0].Value != null ? dr.Cells[0].Value.ToString() : "";//idimage
                            //wrksheet.Cells[h, 2] = dr.Cells[1].Value != null ? dr.Cells[1].Value.ToString() : "";//loai phieu

                            wrksheet.Cells[h, 113] = "03";//cố định 03
                            wrksheet.Cells[h, 114] = "";//trống
                            wrksheet.Cells[h, 115] = dr.Cells[61].Value != null ? dr.Cells[61].Value.ToString() : "";//truong so 60
                            wrksheet.Cells[h, 116] = "";//trống
                            wrksheet.Cells[h, 117] = dr.Cells[62].Value != null ? dr.Cells[62].Value.ToString() : "";//truong so 61
                            wrksheet.Cells[h, 118] = "";//trống
                            wrksheet.Cells[h, 119] = dr.Cells[63].Value != null ? dr.Cells[63].Value.ToString() : "";//truong so 62
                            wrksheet.Cells[h, 120] = "";//trống
                            wrksheet.Cells[h, 121] = dr.Cells[64].Value != null ? dr.Cells[64].Value.ToString() : "";//truong so 63
                            wrksheet.Cells[h, 122] = "";//trống
                            wrksheet.Cells[h, 123] = dr.Cells[65].Value != null ? dr.Cells[65].Value.ToString() : "";//truong so 64
                            wrksheet.Cells[h, 124] = "";//trống
                            wrksheet.Cells[h, 125] = dr.Cells[66].Value != null ? dr.Cells[66].Value.ToString() : "";//truong so 65
                            wrksheet.Cells[h, 126] = "";//trống
                            wrksheet.Cells[h, 127] = dr.Cells[67].Value != null ? dr.Cells[67].Value.ToString() : "";//truong so 66
                            wrksheet.Cells[h, 128] = "";//trống
                            wrksheet.Cells[h, 129] = dr.Cells[68].Value != null ? dr.Cells[68].Value.ToString() : "";//truong so 67
                            wrksheet.Cells[h, 130] = "";//trống
                            wrksheet.Cells[h, 131] = dr.Cells[69].Value != null ? dr.Cells[69].Value.ToString() : "";//truong so 68
                            wrksheet.Cells[h, 132] = "";//trống
                            wrksheet.Cells[h, 133] = dr.Cells[70].Value != null ? dr.Cells[70].Value.ToString() : "";//truong so 69
                            wrksheet.Cells[h, 134] = "";//trống
                            wrksheet.Cells[h, 135] = dr.Cells[71].Value != null ? dr.Cells[71].Value.ToString() : "";//truong so 70
                            wrksheet.Cells[h, 136] = "";//trống
                            wrksheet.Cells[h, 137] = dr.Cells[72].Value != null ? dr.Cells[72].Value.ToString() : "";//truong so 71
                            wrksheet.Cells[h, 138] = "";//trống
                            wrksheet.Cells[h, 139] = dr.Cells[73].Value != null ? dr.Cells[73].Value.ToString() : "";//truong so 72
                            wrksheet.Cells[h, 140] = "";//trống
                            wrksheet.Cells[h, 141] = dr.Cells[74].Value != null ? dr.Cells[74].Value.ToString() : "";//truong so 73
                            wrksheet.Cells[h, 142] = "";//trống
                            wrksheet.Cells[h, 143] = dr.Cells[75].Value != null ? dr.Cells[75].Value.ToString() : "";//truong so 74
                            wrksheet.Cells[h, 144] = "";//trống
                            wrksheet.Cells[h, 145] = dr.Cells[76].Value != null ? dr.Cells[76].Value.ToString() : "";//truong so 75
                            wrksheet.Cells[h, 146] = "";//trống

                            break;

                        case "Loai5":
                            //insert loai 2
                            TruongSo06Loai3 = "";
                            TruongSo06Loai4 = "";
                            hLoaiBa = 0;

                            //bo qua neu rong
                            wrksheet.Cells[h, 1] = dr.Cells[0].Value != null ? dr.Cells[0].Value.ToString() : ""; //tên image
                            wrksheet.Cells[h, 2] = dr.Cells[1].Value != null ? dr.Cells[1].Value.ToString() : ""; //loại
                            wrksheet.Cells[h, 3] = "10";  // cố định 10
                            wrksheet.Cells[h, 146] = "";
                            break;
                    }
                    lb_SoDong_trongExcel.Text = (h - 1).ToString() + "/" + dataGridView1.Rows.Count.ToString();
                    Range rowHead = wrksheet.get_Range("A2", "EP" + h);
                    rowHead.Borders.LineStyle = Constants.xlSolid;
                    h++;
                }
                string savePath = "";
                saveFileDialog1.Title = "Save Excel Files";
                saveFileDialog1.Filter = "Excel files (*.xlsx)|*.xlsx";
                saveFileDialog1.FileName = cbb_Batch.Text;
                saveFileDialog1.RestoreDirectory = true;
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    //Tô màu
                    
                    book.SaveCopyAs(saveFileDialog1.FileName);
                    book.Saved = true;
                    savePath = Path.GetDirectoryName(saveFileDialog1.FileName);
                    App.Quit();
                }
                else
                {
                    MessageBox.Show("Lỗi khi xuất excel!");
                    return false;
                }
                Process.Start(savePath);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }

            /*

                  dr.Cells[i].ToString()
                    if (i == 1)
                    {
                        if (dr.Cells[i].ToString() == "Loai1")
                        {
                            loaiphieu = "1";
                        }
                        else if (dr.Cells[i].ToString() == "Loai2")
                        {
                            loaiphieu = "2";
                        }
                        else if (dr.Cells[i].ToString() == "Loai3")
                        {
                            loaiphieu = "3";
                        }
                        else
                        {
                            loaiphieu = "4";
                        }
                        wrksheet.Cells[h, i + 1] = dr.Cells[i].Value.ToString();
                    }
                    //trường 001
                    else if (i == 2)
                    {
                        switch (loaiphieu)
                        {
                            case "1":
                                wrksheet.Cells[h, i + 1] = dr.Cells[i].Value.ToString();
                                truongso1_tobia = dr.Cells[i].Value.ToString();

                                break;

                            case "2":
                                wrksheet.Cells[h, i + 1] = truongso1_tobia;
                                break;

                            case "3":
                                wrksheet.Cells[h, i + 1] = truongso1_tobia;
                                break;

                            case "4":
                                if (!string.IsNullOrEmpty(dr.Cells[i].Value.ToString()))
                                {
                                    if (dr.Cells[i].Value.ToString() == "?")
                                    {
                                        wrksheet.Cells[h, i + 1] = "?";
                                    }
                                    else
                                    {
                                        wrksheet.Cells[h, i + 1] = dr.Cells[i].Value.ToString();
                                    }
                                }
                                else
                                {
                                    wrksheet.Cells[h, i + 1] = "";
                                }
                                break;
                        }
                    }
                    //trường 002
                    else if (i == 3)
                    {
                        switch (loaiphieu)
                        {
                            case "1":
                                wrksheet.Cells[h, i + 1] = dr.Cells[i].Value != null ? dr.Cells[i].Value.ToString() : "";

                                if (!string.IsNullOrEmpty(dr.Cells[i].Value.ToString()))
                                {
                                    wrksheet.Cells[h, i + 1] = dr.Cells[i].Value.ToString();
                                    dulieu_truong2_loai1 = dr.Cells[i].Value.ToString();
                                }
                                else
                                {
                                    wrksheet.Cells[h, i + 1] = "";
                                    dulieu_truong2_loai1 = "";
                                }
                                break;

                            case "2":
                                if (!string.IsNullOrEmpty(dr.Cells[i].Value.ToString()))
                                {
                                    if (dr.Cells[i].Value.ToString()=="?")
                                    {
                                        wrksheet.Cells[h, i + 1] = "?";
                                    }
                                    else
                                    {
                                        wrksheet.Cells[h, i + 1] = ThemKyTubatKyPhiatruoc(dr.Cells[i].Value.ToString(), 12, "0");
                                    }
                                }
                                else
                                {
                                    wrksheet.Cells[h, i + 1] = "";
                                }
                                break;

                            case "3":
                                if (!string.IsNullOrEmpty(dr.Cells[i].Value.ToString()))
                                {
                                    if (dr.Cells[i].Value.ToString() == "?")
                                    {
                                        wrksheet.Cells[h, i + 1] = "?";
                                    }
                                    else
                                    {
                                        wrksheet.Cells[h, i + 1] = ThemKyTubatKyPhiatruoc(dr.Cells[i].Value.ToString(), 12, "0");
                                    }
                                }
                                else
                                {
                                    wrksheet.Cells[h, i + 1] = "";
                                }
                                break;

                            case "4":
                                wrksheet.Cells[h, i + 1] = dr.Cells[i].Value?.ToString();
                                break;
                        }
                    }
                    else if (i == 4)
                    {
                        switch (loaiphieu)
                        {
                            case "1":
                                wrksheet.Cells[h, i + 1] = "";
                                break;

                            case "2":
                                if (!string.IsNullOrEmpty(dr.Cells[i].Value.ToString()))
                                {
                                    if (dr.Cells[i].Value.ToString() == "?")
                                    {
                                        wrksheet.Cells[h, i + 1] = "?";
                                        dulieu_truong3_loai2 = "?";
                                    }
                                    else
                                    {
                                        wrksheet.Cells[h, i + 1] = ThemKyTubatKyPhiatruoc(dr.Cells[i].Value.ToString(), 12, "0");
                                        dulieu_truong3_loai2 = ThemKyTubatKyPhiatruoc(dr.Cells[i].Value.ToString(), 12, "0");
                                    }
                                    truong3_loai2_trong = false;
                                }
                                else
                                {
                                    wrksheet.Cells[h, i + 1] = "";
                                    dulieu_truong3_loai2 = "";
                                    truong3_loai2_trong = true;
                                }
                                hangloai2 = h;
                                break;

                            case "3":
                                if (!string.IsNullOrEmpty(dr.Cells[i].Value.ToString()))
                                {
                                    if (dr.Cells[i].Value.ToString() == "?")
                                    {
                                        wrksheet.Cells[h, i + 1] = "?";
                                        if (truong3_loai2_trong)
                                        {
                                            wrksheet.Cells[hangloai2, i + 2] = "?";
                                        }
                                    }
                                    else
                                    {
                                        wrksheet.Cells[h, i + 1] = ThemKyTubatKyPhiatruoc(dr.Cells[i].Value.ToString(), 12, "0");
                                        if (truong3_loai2_trong)
                                        {
                                            wrksheet.Cells[hangloai2, i + 2] = ThemKyTubatKyPhiatruoc(dr.Cells[i].Value.ToString(), 12, "0");
                                        }
                                    }
                                }
                                else
                                {
                                    wrksheet.Cells[h, i + 1] = "333333333333";
                                    if (truong3_loai2_trong)
                                    {
                                        wrksheet.Cells[hangloai2, i + 1] = "333333333333";
                                    }
                                }
                                break;

                            case "4":
                                if (!string.IsNullOrEmpty(dr.Cells[i].Value == null? "" : dr.Cells[i].Value.ToString()))
                                {
                                    if (dr.Cells[i].Value.ToString() == "?")
                                    {
                                        wrksheet.Cells[h, i + 1] = "?";
                                    }
                                    else
                                    {
                                        wrksheet.Cells[h, i + 1] = ThemKyTubatKyPhiatruoc(dr.Cells[i].Value.ToString(), 12, "0");
                                    }
                                }
                                else
                                {
                                    wrksheet.Cells[h, i + 1] = "";
                                }
                                break;
                        }
                    }
                    else if (i == 5)
                    {
                        switch (loaiphieu)
                        {
                            case "1":
                                wrksheet.Cells[h, i + 1] = "";
                                break;

                            case "2":
                                if (!string.IsNullOrEmpty(dr.Cells[i].Value.ToString()))
                                {
                                    if (dr.Cells[i].Value.ToString() == "?")
                                    {
                                        wrksheet.Cells[h, i + 1] = "?";
                                        dulieu_truong4_loai2 = "?";
                                    }
                                    else
                                    {
                                        wrksheet.Cells[h, i + 1] = ThemKyTubatKyPhiatruoc(dr.Cells[i].Value.ToString(), 12, "0");
                                        dulieu_truong4_loai2 = ThemKyTubatKyPhiatruoc(dr.Cells[i].Value.ToString(), 12, "0");
                                    }
                                }
                                else
                                {
                                    wrksheet.Cells[h, i + 1] = "";
                                    dulieu_truong4_loai2 = "";
                                }
                                hangloai2_truong4 = h;
                                break;

                            case "3":
                                wrksheet.Cells[h, i + 1] = "";
                                break;

                            case "4":
                                wrksheet.Cells[h, i + 1] = !string.IsNullOrEmpty(dr.Cells[i].Value == null ? "" : dr.Cells[i].Value.ToString()) ? dr.Cells[i].Value?.ToString() : "";
                                break;
                        }
                    }
                    else if (i == 6)
                    {
                        if (loaiphieu=="4")
                        {
                            if (!string.IsNullOrEmpty(dr.Cells[i].Value == null ? "": dr.Cells[i].Value.ToString() ))
                            {
                                if (dulieu_truong4_loai2 != dr.Cells[i].Value.ToString())
                                {
                                    wrksheet.Cells[h, i + 1] = "9999999999999";
                                    wrksheet.Cells[hangloai2_truong4, i + 1] = "9999999999999";
                                }
                                else
                                {
                                    wrksheet.Cells[h, i + 1] = dr.Cells[i].Value.ToString();
                                }
                            }
                            else
                            {
                                if (!string.IsNullOrEmpty(dulieu_truong4_loai2))
                                {
                                    wrksheet.Cells[h, i + 1] = "9999999999999";
                                    wrksheet.Cells[hangloai2_truong4, i + 1] = "9999999999999";
                                }
                                else
                                {
                                    wrksheet.Cells[h, i + 1] = "";
                                }
                            }
                        }
                        else
                        {
                            wrksheet.Cells[h, i + 1] = !string.IsNullOrEmpty(dr.Cells[i].Value.ToString()) ? dr.Cells[i].Value?.ToString(): "";
                        }
                    }
                    else if (i == 7)
                    {
                        if (loaiphieu=="4")
                        {
                            if (truongso1_tobia=="06" || truongso1_tobia == "07")
                            {
                                wrksheet.Cells[h, i + 1] = "4091953036";
                            }
                            else
                            {
                                if (string.IsNullOrEmpty(dr.Cells[i].Value.ToString()))
                                {
                                    if (dulieu_truong3_loai2 !="")
                                    {
                                        wrksheet.Cells[h, i + 1] = dulieu_truong3_loai2;
                                    }
                                    else
                                    {
                                        wrksheet.Cells[h, i + 1] = "3333333333333";
                                    }
                                }
                                else
                                {
                                    wrksheet.Cells[h, i + 1] = dr.Cells[i].Value.ToString();
                                }
                            }
                        }
                        else
                        {
                            wrksheet.Cells[h, i + 1] = !string.IsNullOrEmpty(dr.Cells[i].Value.ToString()) ? dr.Cells[i].Value.ToString() : "";
                        }
                    }
                    else if (i == 13)
                    {
                        if (loaiphieu == "4")
                        {
                            if (truongso1_tobia!="06"||truongso1_tobia !="07")
                            {
                                wrksheet.Cells[h, i + 1] = !string.IsNullOrEmpty(dr.Cells[i].Value.ToString()) ? dr.Cells[i].Value.ToString() : "";
                            }
                            else
                            {
                                wrksheet.Cells[h, i + 1] = "";
                            }
                        }
                        else
                        {
                            wrksheet.Cells[h, i + 1] = !string.IsNullOrEmpty(dr.Cells[i].Value.ToString()) ? dr.Cells[i].Value.ToString() : "";
                        }
                    }
                    else if (i == 14)
                    {
                        if (loaiphieu == "4")
                        {
                            if (dulieu_truong2_loai1 != "")
                            {
                                wrksheet.Cells[h, i + 1] = !string.IsNullOrEmpty(dr.Cells[i].Value.ToString()) ? dr.Cells[i].Value.ToString() : "";
                            }
                            else
                            {
                                wrksheet.Cells[h, i + 1] = "";
                            }
                        }
                        else
                        {
                            wrksheet.Cells[h, i + 1] = !string.IsNullOrEmpty(dr.Cells[i].Value.ToString()) ? dr.Cells[i].Value.ToString() : "";
                        }
                    }
                    else if (i == 38||i==39|| i == 40|| i == 41|| i == 42|| i == 43|| i == 44|| i == 45|| i == 46|| i == 47|| i == 48|| i == 49|| i == 51|| i == 52|| i == 53|| i == 54|| i == 58|| i == 59|| i == 64|| i == 65|| i == 66|| i == 67)
                    {
                        if (loaiphieu == "4")
                        {
                            if (!string.IsNullOrEmpty(dr.Cells[i].Value.ToString()))
                            {
                                if (dr.Cells[i].Value.ToString()=="?")
                                {
                                    wrksheet.Cells[h, i + 1] = "?";
                                }
                                else if (dr.Cells[i].Value.ToString()!="0")
                                {
                                    wrksheet.Cells[h, i + 1] = ThemKyTubatKyPhiatruoc(dr.Cells[i].Value.ToString().Replace(",",""),8,"0");
                                }
                                else
                                {
                                    wrksheet.Cells[h, i + 1] = "";
                                }
                            }
                            else
                            {
                                wrksheet.Cells[h, i + 1] = "";
                            }
                        }
                        else
                        {
                            wrksheet.Cells[h, i + 1] = !string.IsNullOrEmpty(dr.Cells[i].Value.ToString()) ? dr.Cells[i].Value.ToString() : "";
                        }
                    }
                    else if (i==79)
                    {
                        if (loaiphieu == "4")
                        {
                            if (!string.IsNullOrEmpty(dr.Cells[i].Value.ToString()))
                            {
                                wrksheet.Cells[h, i + 1] = dr.Cells[i].Value.ToString();
                                wrksheet.Cells[h, i] = "";
                            }
                            else
                            {
                                wrksheet.Cells[h, i + 1] = "";
                            }
                        }
                        else
                        {
                            wrksheet.Cells[h, i + 1] = !string.IsNullOrEmpty(dr.Cells[i].Value.ToString()) ? dr.Cells[i].Value.ToString() : "";
                        }
                    }
                    else if (i == 80 || i == 81 || i == 82 || i == 83 || i == 84 || i == 85 || i == 86 || i == 87)
                    {
                        if (loaiphieu == "4")
                        {
                            if (!string.IsNullOrEmpty(dr.Cells[i].Value.ToString()))
                            {
                                if (dr.Cells[i].Value.ToString() == "?")
                                {
                                    wrksheet.Cells[h, i + 1] = "?";
                                }
                                else if (dr.Cells[i].Value.ToString() != "0")
                                {
                                    wrksheet.Cells[h, i + 1] = ThemKyTubatKyPhiatruoc(dr.Cells[i].Value.ToString().Replace(",", ""), 2, "0");
                                }
                                else
                                {
                                    wrksheet.Cells[h, i + 1] = "";
                                }
                            }
                            else
                            {
                                wrksheet.Cells[h, i + 1] = "";
                            }
                        }
                        else
                        {
                            wrksheet.Cells[h, i + 1] = !string.IsNullOrEmpty(dr.Cells[i].Value.ToString()) ? dr.Cells[i].Value.ToString() : "";
                        }
                    }
                    else if (i==93)
                    {
                        if (loaiphieu == "4")
                        {
                            if (!string.IsNullOrEmpty(dr.Cells[107].Value.ToString()))
                            {
                                if (dr.Cells[107].Value.ToString() != "?")
                                {
                                    int temp = int.Parse(dr.Cells[107].Value.ToString());
                                    if (temp>260401)
                                    {
                                        wrksheet.Cells[h, i + 1] = "1";
                                    }
                                    else
                                    {
                                        wrksheet.Cells[h, i + 1] = "";
                                    }
                                }
                            }
                            if (!string.IsNullOrEmpty(dr.Cells[108].Value.ToString()))
                            {
                                if (dr.Cells[108].Value.ToString() != "?")
                                {
                                    int temp = int.Parse(dr.Cells[108].Value.ToString());
                                    if (temp > 260401)
                                    {
                                        wrksheet.Cells[h, i + 1] = "1";
                                    }
                                    else
                                    {
                                        wrksheet.Cells[h, i + 1] = "";
                                    }
                                }
                            }
                        }
                        else
                        {
                            wrksheet.Cells[h, i + 1] = !string.IsNullOrEmpty(dr.Cells[i].Value.ToString()) ? dr.Cells[i].Value.ToString() : "";
                        }
                    }
                    else if (i == 101)
                    {
                        if (loaiphieu == "4")
                        {
                            if (!string.IsNullOrEmpty(dr.Cells[102].Value.ToString()))
                            {
                                wrksheet.Cells[h, i + 1] = "";
                            }
                            else
                            {
                                wrksheet.Cells[h, i + 1] = !string.IsNullOrEmpty(dr.Cells[i].Value.ToString()) ? dr.Cells[i].Value.ToString() : "";
                            }
                        }
                        else
                        {
                            wrksheet.Cells[h, i + 1] = !string.IsNullOrEmpty(dr.Cells[i].Value.ToString()) ? dr.Cells[i].Value.ToString() : "";
                        }
                    }
                    else if (i == 103 || i == 107 || i == 108)
                    {
                        if (loaiphieu == "4")
                        {
                            if (!string.IsNullOrEmpty(dr.Cells[i].Value.ToString()))
                            {
                                if (dr.Cells[i].Value.ToString() == "?")
                                {
                                    wrksheet.Cells[h, i + 1] = "?";
                                }
                                else
                                {
                                    wrksheet.Cells[h, i + 1] = ThemKyTubatKyPhiatruoc(dr.Cells[i].Value.ToString().Replace(",", ""), 8, "0");
                                }
                            }
                            else
                            {
                                wrksheet.Cells[h, i + 1] = "";
                            }
                        }
                        else
                        {
                            wrksheet.Cells[h, i + 1] = !string.IsNullOrEmpty(dr.Cells[i].Value.ToString()) ? dr.Cells[i].Value.ToString() : "";
                        }
                    }
                    else if (i == 111)
                    {
                        if (loaiphieu == "4")
                        {
                            if (!string.IsNullOrEmpty(dr.Cells[i].Value.ToString()))
                            {
                                if (dr.Cells[i].Value.ToString() == "?")
                                {
                                    wrksheet.Cells[h, i + 1] = "?";
                                }
                                else
                                {
                                    wrksheet.Cells[h, i + 1] = ThemKyTubatKyPhiatruoc(dr.Cells[i].Value.ToString().Replace(",", ""), 2, "0");
                                }
                            }
                            else
                            {
                                wrksheet.Cells[h, i + 1] = "";
                            }
                        }
                        else
                        {
                            wrksheet.Cells[h, i + 1] = !string.IsNullOrEmpty(dr.Cells[i].Value.ToString()) ? dr.Cells[i].Value.ToString() : "";
                        }
                    }
                    else if (i == 159)
                    {
                        if (loaiphieu == "4")
                        {
                            if (!string.IsNullOrEmpty(dr.Cells[i].Value.ToString()))
                            {
                                if (dr.Cells[i].Value.ToString() == "?")
                                {
                                    wrksheet.Cells[h, i + 1] = "?";
                                }
                                else
                                {
                                    wrksheet.Cells[h, i + 1] = ThemKyTubatKyPhiatruoc(dr.Cells[i].Value.ToString().Replace(",", ""), 12, "0");
                                }
                            }
                            else
                            {
                                wrksheet.Cells[h, i + 1] = "";
                            }
                        }
                        else
                        {
                            wrksheet.Cells[h, i + 1] = !string.IsNullOrEmpty(dr.Cells[i].Value.ToString()) ? dr.Cells[i].Value.ToString() : "";
                        }
                    }
                    else if (i == 160||i==161||i==162)
                    {
                        if (loaiphieu == "4")
                        {
                            if (!string.IsNullOrEmpty(dr.Cells[i].Value.ToString()))
                            {
                                if (dr.Cells[i].Value.ToString() == "?")
                                {
                                    wrksheet.Cells[h, i + 1] = "?";
                                }
                                else
                                {
                                    wrksheet.Cells[h, i + 1] = ThemKyTubatKyPhiatruoc(dr.Cells[i].Value.ToString().Replace(",", ""), 12, "0");
                                }
                            }
                            else
                            {
                                wrksheet.Cells[h, i + 1] = "";
                            }
                        }
                        else
                        {
                            wrksheet.Cells[h, i + 1] = !string.IsNullOrEmpty(dr.Cells[i].Value.ToString()) ? dr.Cells[i].Value.ToString() : "";
                        }
                    }
                    else if (i == 163)
                    {
                        if (loaiphieu == "4")
                        {
                            if (!string.IsNullOrEmpty(dr.Cells[i].Value.ToString()))
                            {
                                if (dr.Cells[i].Value.ToString() == "?")
                                {
                                    wrksheet.Cells[h, i + 1] = "?";
                                }
                                else
                                {
                                    if (dr.Cells[160].Value.ToString()=="")
                                    {
                                        if (dr.Cells[161].Value.ToString() == "")
                                        {
                                            if (dr.Cells[162].Value.ToString() == "")
                                            {
                                                wrksheet.Cells[h, 160 + 1] = ThemKyTubatKyPhiatruoc(dr.Cells[i].Value.ToString().Replace(",", ""), 12, "0");
                                                wrksheet.Cells[h, i + 1] = "";
                                            }
                                            else
                                            {
                                                if (dr.Cells[160].Value.ToString() == "")
                                                {
                                                    if (dr.Cells[161].Value.ToString()=="")
                                                    {
                                                        wrksheet.Cells[h, 160 + 1] =ThemKyTubatKyPhiatruoc(dr.Cells[162].Value.ToString().Replace(",", ""), 12,"0");
                                                        wrksheet.Cells[h, 161 + 1] = ThemKyTubatKyPhiatruoc(dr.Cells[i].Value.ToString().Replace(",", ""), 12, "0");
                                                        wrksheet.Cells[h, 162 + 1] = "";
                                                        wrksheet.Cells[h, i + 1] = "";
                                                    }
                                                    else
                                                    {
                                                        wrksheet.Cells[h, 160 + 1] = ThemKyTubatKyPhiatruoc(dr.Cells[161].Value.ToString().Replace(",", ""), 12, "0");
                                                        wrksheet.Cells[h, 161 + 1] = ThemKyTubatKyPhiatruoc(dr.Cells[162].Value.ToString().Replace(",", ""), 12, "0");
                                                        wrksheet.Cells[h, 162 + 1] = ThemKyTubatKyPhiatruoc(dr.Cells[163].Value.ToString().Replace(",", ""), 12, "0");
                                                        wrksheet.Cells[h, i + 1] = "";
                                                    }
                                                }
                                                else
                                                {
                                                    wrksheet.Cells[h, 163 + 1] = ThemKyTubatKyPhiatruoc(dr.Cells[163].Value.ToString().Replace(",", ""), 12, "0");
                                                }
                                            }
                                        }
                                        else
                                        {
                                            if (dr.Cells[160].Value.ToString() == "")
                                            {
                                                wrksheet.Cells[h, 160 + 1] = ThemKyTubatKyPhiatruoc(dr.Cells[161].Value.ToString().Replace(",", ""), 12, "0");
                                                wrksheet.Cells[h, 161 + 1] = ThemKyTubatKyPhiatruoc(dr.Cells[162].Value.ToString().Replace(",", ""), 12, "0");
                                                wrksheet.Cells[h, 162 + 1] = ThemKyTubatKyPhiatruoc(dr.Cells[163].Value.ToString().Replace(",", ""), 12, "0");
                                                wrksheet.Cells[h, i + 1] = "";
                                            }
                                            else
                                            {
                                                wrksheet.Cells[h, 163 + 1] = ThemKyTubatKyPhiatruoc(dr.Cells[163].Value.ToString().Replace(",", ""), 12, "0");
                                            }
                                        }
                                    }
                                    else
                                    {
                                        wrksheet.Cells[h, 163 + 1] = ThemKyTubatKyPhiatruoc(dr.Cells[163].Value.ToString().Replace(",", ""), 12, "0");
                                    }
                                }
                            }
                            else
                            {
                                wrksheet.Cells[h, i + 1] = "";
                            }
                        }
                        else
                        {
                            wrksheet.Cells[h, i + 1] = !string.IsNullOrEmpty(dr.Cells[i].Value.ToString()) ? dr.Cells[i].Value.ToString() : "";
                        }
                    }
                    else if (i == 169)
                    {
                        if (loaiphieu == "4")
                        {
                            if (!string.IsNullOrEmpty(dr.Cells[i].Value.ToString()))
                            {
                                if (dr.Cells[i].Value.ToString() == "?")
                                {
                                    wrksheet.Cells[h, i + 1] = "?";
                                }
                                else
                                {
                                    if (dr.Cells[166].Value.ToString() == "")
                                    {
                                        if (dr.Cells[167].Value.ToString() == "")
                                        {
                                            if (dr.Cells[168].Value.ToString() == "")
                                            {
                                                wrksheet.Cells[h, 166 + 1] = ThemKyTubatKyPhiatruoc(dr.Cells[i].Value.ToString().Replace(",", ""), 12, "0");
                                                wrksheet.Cells[h, i + 1] = "";
                                            }
                                            else
                                            {
                                                if (dr.Cells[166].Value.ToString() == "")
                                                {
                                                    if (dr.Cells[167].Value.ToString() == "")
                                                    {
                                                        wrksheet.Cells[h, 166 + 1] = ThemKyTubatKyPhiatruoc(dr.Cells[167].Value.ToString().Replace(",", ""), 12, "0");
                                                        wrksheet.Cells[h, 167 + 1] = ThemKyTubatKyPhiatruoc(dr.Cells[i].Value.ToString().Replace(",", ""), 12, "0");
                                                        wrksheet.Cells[h, 168 + 1] = "";
                                                        wrksheet.Cells[h, i + 1] = "";
                                                    }
                                                    else
                                                    {
                                                        wrksheet.Cells[h, 166 + 1] = ThemKyTubatKyPhiatruoc(dr.Cells[167].Value.ToString().Replace(",", ""), 12, "0");
                                                        wrksheet.Cells[h, 167 + 1] = ThemKyTubatKyPhiatruoc(dr.Cells[168].Value.ToString().Replace(",", ""), 12, "0");
                                                        wrksheet.Cells[h, 168 + 1] = ThemKyTubatKyPhiatruoc(dr.Cells[169].Value.ToString().Replace(",", ""), 12, "0");
                                                        wrksheet.Cells[h, i + 1] = "";
                                                    }
                                                }
                                                else
                                                {
                                                    wrksheet.Cells[h, 169 + 1] = ThemKyTubatKyPhiatruoc(dr.Cells[169].Value.ToString().Replace(",", ""), 12, "0");
                                                }
                                            }
                                        }
                                        else
                                        {
                                            if (dr.Cells[166].Value.ToString() == "")
                                            {
                                                wrksheet.Cells[h, 166 + 1] = ThemKyTubatKyPhiatruoc(dr.Cells[166].Value.ToString().Replace(",", ""), 12, "0");
                                                wrksheet.Cells[h, 167 + 1] = ThemKyTubatKyPhiatruoc(dr.Cells[167].Value.ToString().Replace(",", ""), 12, "0");
                                                wrksheet.Cells[h, 168 + 1] = ThemKyTubatKyPhiatruoc(dr.Cells[168].Value.ToString().Replace(",", ""), 12, "0");
                                                wrksheet.Cells[h, i + 1] = "";
                                            }
                                            else
                                            {
                                                wrksheet.Cells[h, 169 + 1] = ThemKyTubatKyPhiatruoc(dr.Cells[169].Value.ToString().Replace(",", ""), 12, "0");
                                            }
                                        }
                                    }
                                    else
                                    {
                                        wrksheet.Cells[h, 169 + 1] = ThemKyTubatKyPhiatruoc(dr.Cells[169].Value.ToString().Replace(",", ""), 12, "0");
                                    }
                                }
                            }
                            else
                            {
                                wrksheet.Cells[h, i + 1] = "";
                            }
                        }
                        else
                        {
                            wrksheet.Cells[h, i + 1] = !string.IsNullOrEmpty(dr.Cells[i].Value.ToString()) ? dr.Cells[i].Value.ToString() : "";
                        }
                    }
                    else
                    {
                        wrksheet.Cells[h, i + 1] = !string.IsNullOrEmpty(dr.Cells[i].Value.ToString()) ? dr.Cells[i].Value.ToString(): "";
                    }
                }
                h++;
            }
            string savePath = "";
            saveFileDialog1.Title = "Save Excel Files";
            saveFileDialog1.Filter = "Excel files (*.xls)|*.xls";
            saveFileDialog1.FileName = cbb_Batch.Text;
            saveFileDialog1.RestoreDirectory = true;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //Tô màu

                book.SaveCopyAs(saveFileDialog1.FileName);
                book.Saved = true;
                savePath = Path.GetDirectoryName(saveFileDialog1.FileName);
                App.Quit();
            }
            else
            {
                MessageBox.Show("Lỗi khi xuất excel!");
                return false;
            }
            Process.Start(savePath);
            return true;
        }
        //catch (Exception ex)
        //{
        //    MessageBox.Show(ex.Message);
        //    return false;
        //}

             */
        }

        private String getcharacter(int n, String str)
        {
            String kq = "";
            for (int i = 1; i <= n; i++)
            {
                kq = kq.Insert(kq.Length, str);
            }

            return kq;
        }

        private String ThemKyTubatKyPhiatruoc(String input, int iByte, string str)
        {
            if (input.Length >= iByte)
                return input.Substring(input.Length - iByte, iByte);

            return input.Insert(0, getcharacter(iByte - input.Length, str));
        }

        private String ThemKyTubatKyPhiatruocNeuTrongThiDeTrong(String input, int iByte, string str)
        {
            if (string.IsNullOrEmpty(input))
                return "";
            if (input.IndexOf('?') > 0)
                return "?";

            if (input.Length >= iByte)
                return input.Substring(input.Length - iByte, iByte);

            return input.Insert(0, getcharacter(iByte - input.Length, str));
        }
    }
}