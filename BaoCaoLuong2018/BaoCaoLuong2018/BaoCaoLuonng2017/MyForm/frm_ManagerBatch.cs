using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace BaoCaoLuong2018.BaoCaoLuonng2017.MyForm
{
    public partial class frm_ManagerBatch : DevExpress.XtraEditors.XtraForm
    {
        public frm_ManagerBatch()
        {
            InitializeComponent();
        }

        private void frm_ManagerBatch_Load(object sender, EventArgs e)
        {
            RefreshBatch();
        }

        private void RefreshBatch()
        {
            var temp = from var in Global.db_BCL.GetBatch_Full() select var;
            gridControl1.DataSource = temp;
        }

        private void btn_TaoBatch_Click(object sender, EventArgs e)
        {
            new frm_CreateBatch().ShowDialog();
            RefreshBatch();
        }

        private void repositoryItemButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            string fbatchname = gridView1.GetFocusedRowCellValue("fBatchName").ToString();
            string temp = Global.StrPath + "\\" + fbatchname;
            if (MessageBox.Show("Bạn chắc chắn muốn xóa batch: " + fbatchname + "?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    Global.db_BCL.XoaBatch(fbatchname);
                    Directory.Delete(temp, true);
                    MessageBox.Show("Đã xóa batch thành công!");
                }
                catch (Exception)
                {
                    MessageBox.Show("Xóa batch bị lỗi!");
                }
            }
            RefreshBatch();
        }

        private void gridView1_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                string BatchID = gridView1.GetFocusedRowCellValue("fBatchName") + "";
                string fielname = e.Column.FieldName;
                if (fielname == "CongKhaiBatch")
                {
                    bool check = (bool)e.Value;
                    if (check)
                    {
                        Global.db_BCL.UpdateCongKhaiBatch(BatchID, 1);
                    }
                    else
                    {
                        Global.db_BCL.UpdateCongKhaiBatch(BatchID, 0);
                    }
                    int rowHandle = gridView1.LocateByValue("fBatchName", BatchID);
                    RefreshBatch();
                    if (rowHandle != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
                        gridView1.FocusedRowHandle = rowHandle;
                }
                else if (fielname == "ChiaUser")
                {
                    var ktDeSo = (from w in Global.db_BCL.tbl_MissImage_DESOs where w.fBatchName == BatchID select w.IdImage).ToList();
                    var ktDeJP = (from w in Global.db_BCL.tbl_MissImage_DEJPs where w.fBatchName == BatchID select w.IdImage).ToList();
                    if (ktDeSo.Count > 0 || ktDeJP.Count > 0)
                    {
                        MessageBox.Show("Batch này đã được nhập!");
                    }
                    else
                    {
                        bool check = (bool)e.Value;
                        if (check)
                        {
                            Global.db_BCL.UpdateBatchChiaUser(BatchID, 1);
                        }
                        else
                        {
                            Global.db_BCL.UpdateBatchChiaUser(BatchID, 0);
                        }
                    }
                    int rowHandle = gridView1.LocateByValue("fBatchName", BatchID);
                    RefreshBatch();
                    if (rowHandle != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
                        gridView1.FocusedRowHandle = rowHandle;
                }
            }
            catch (Exception i)
            {
                MessageBox.Show("Lỗi : " + i.Message);
            }
        }
    }
}