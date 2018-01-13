using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid;
using System.Data.SqlClient;

namespace BaoCaoLuong2018.MyForm
{
    public partial class frm_ChiTietTienDo : DevExpress.XtraEditors.XtraForm
    {
        public string Loai;
        public string BatchID;
        public string City;
        public frm_ChiTietTienDo()
        {
            InitializeComponent();
        }

        public bool Cal(int width, GridView view)
        {
            view.IndicatorWidth = view.IndicatorWidth < width ? width : view.IndicatorWidth;
            return true;
        }

        private void LoadSttGridView(RowIndicatorCustomDrawEventArgs e, GridView dgv)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            SizeF size = e.Graphics.MeasureString(e.Info.DisplayText, e.Appearance.Font);
            int width = Convert.ToInt32(size.Width) + 20;
            BeginInvoke(new MethodInvoker(delegate { Cal(width, dgv); }));
        }
        private void DoRowDoubleClick(GridView view, Point pt)
        {
            GridHitInfo info = view.CalcHitInfo(pt);
            if (info.RowHandle < 0)
                return;
            ShowImage showwImage = new ShowImage();
            showwImage.BatchName = gridView1.GetRowCellValue(info.RowHandle, "BatchName") + "";
            showwImage.BatchID = gridView1.GetRowCellValue(info.RowHandle, "BatchID") + "";
            showwImage.IdImage = gridView1.GetRowCellValue(info.RowHandle, "IDImage") + "";
            showwImage.City = lb_City.Text;
            showwImage.Loai = Loai;
            showwImage.ShowDialog();
        }
        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(MousePosition);
            DoRowDoubleClick(view, pt);
        }
        BaseEdit _inplaceEditor;
        private void gridView1_ShownEditor(object sender, EventArgs e)
        {
            _inplaceEditor = ((GridView)sender).ActiveEditor;
            _inplaceEditor.DoubleClick += inplaceEditor_DoubleClick;
        }

        private void gridView1_HiddenEditor(object sender, EventArgs e)
        {
            if (_inplaceEditor != null)
            {
                _inplaceEditor.DoubleClick -= inplaceEditor_DoubleClick;
                _inplaceEditor = null;
            }
        }

        void inplaceEditor_DoubleClick(object sender, EventArgs e)
        {
            BaseEdit editor = (BaseEdit)sender;
            GridControl grid = (GridControl)editor.Parent;
            Point pt = grid.PointToClient(MousePosition);
            GridView view = (GridView)grid.FocusedView;
            DoRowDoubleClick(view, pt);
        }
        private void frm_ChiTietTienDo_Load(object sender, EventArgs e)
        {
            gridView1.DoubleClick += gridView1_DoubleClick;
            gridView1.ShownEditor += gridView1_ShownEditor;
            gridView1.HiddenEditor += gridView1_HiddenEditor;
            if (BatchID.IndexOf("All") >= 0)
            {
                if (Loai == "DESO")
                {
                    lb_TongSoHinh.Text = (from w in Global.Db.tbl_Images join b in Global.Db.tbl_Batches on w.BatchID equals (b.BatchID) where b.City == lb_City.Text select w.IDImage).Count().ToString();
                    lb_SoHinhChuaNhap.Text = (from w in Global.Db.tbl_Images join b in Global.Db.tbl_Batches on w.BatchID equals (b.BatchID) where b.City == lb_City.Text & w.TienDoDeSo == "Hình chưa nhập" select w.IDImage).Count().ToString();
                    lb_SoHinhDangNhap.Text = (from w in Global.Db.tbl_Images join b in Global.Db.tbl_Batches on w.BatchID equals (b.BatchID) where b.City == lb_City.Text & w.TienDoDeSo == "Hình đang nhập" select w.IDImage).Count().ToString();
                    lb_SoHinhChoCheck.Text = (from w in Global.Db.tbl_Images join b in Global.Db.tbl_Batches on w.BatchID equals (b.BatchID) where b.City == lb_City.Text & w.TienDoDeSo == "Hình chờ check" select w.IDImage).Count().ToString();
                    lb_SoHinhDangCheck.Text = (from w in Global.Db.tbl_Images join b in Global.Db.tbl_Batches on w.BatchID equals (b.BatchID) where b.City == lb_City.Text & w.TienDoDeSo == "Hình đang check" select w.IDImage).Count().ToString();
                    lb_SoHinhHoanThanh.Text = (from w in Global.Db.tbl_Images join b in Global.Db.tbl_Batches on w.BatchID equals (b.BatchID) where b.City == lb_City.Text & w.TienDoDeSo == "Hình hoàn thành" select w.IDImage).Count().ToString();
                    gridControl1.DataSource = null;
                    string ConnectionString = Global.Db.Connection.ConnectionString;
                    SqlConnection con = new SqlConnection(ConnectionString);
                    DataTable data = new DataTable();

                    SqlCommand cmd = new SqlCommand("ChiTietTienDo_All", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@City", lb_City.Text);
                    cmd.Parameters.AddWithValue("@Type", "DESO");
                    con.Open();
                    data.Load(cmd.ExecuteReader());
                    gridControl1.DataSource = data;
                    con.Close();
                    //gridControl1.DataSource = Global.Db.ChiTietTienDo_All(lb_City.Text,"DESO");
                    gridView1.RowCellStyle += GridView1_RowCellStyle;
                }
                else if (Loai == "DEJP")
                {
                    lb_TongSoHinh.Text = (from w in Global.Db.tbl_Images join b in Global.Db.tbl_Batches on w.BatchID equals (b.BatchID) where b.City == lb_City.Text select w.IDImage).Count().ToString();
                    lb_SoHinhChuaNhap.Text = (from w in Global.Db.tbl_Images join b in Global.Db.tbl_Batches on w.BatchID equals (b.BatchID) where b.City == lb_City.Text & w.TienDoDeJP == "Hình chưa nhập" select w.IDImage).Count().ToString();
                    lb_SoHinhDangNhap.Text = (from w in Global.Db.tbl_Images join b in Global.Db.tbl_Batches on w.BatchID equals (b.BatchID) where b.City == lb_City.Text & w.TienDoDeJP == "Hình đang nhập" select w.IDImage).Count().ToString();
                    lb_SoHinhChoCheck.Text = (from w in Global.Db.tbl_Images join b in Global.Db.tbl_Batches on w.BatchID equals (b.BatchID) where b.City == lb_City.Text & w.TienDoDeJP == "Hình chờ check" select w.IDImage).Count().ToString();
                    lb_SoHinhDangCheck.Text = (from w in Global.Db.tbl_Images join b in Global.Db.tbl_Batches on w.BatchID equals (b.BatchID) where b.City == lb_City.Text & w.TienDoDeJP == "Hình đang check" select w.IDImage).Count().ToString();
                    lb_SoHinhHoanThanh.Text = (from w in Global.Db.tbl_Images join b in Global.Db.tbl_Batches on w.BatchID equals (b.BatchID) where b.City == lb_City.Text & w.TienDoDeJP == "Hình hoàn thành" select w.IDImage).Count().ToString();
                    gridControl1.DataSource = null;
                    gridControl1.DataSource = Global.Db.ChiTietTienDo_All(lb_City.Text, "DEJP");
                    gridView1.RowCellStyle += GridView1_RowCellStyle;
                }
            }
            else
            {
                if (Loai == "DESO")
                {
                    lb_TongSoHinh.Text = (from w in Global.Db.tbl_Images join b in Global.Db.tbl_Batches on w.BatchID equals (b.BatchID) where b.City == lb_City.Text & w.BatchID == BatchID select w.IDImage).Count().ToString();
                    lb_SoHinhChuaNhap.Text = (from w in Global.Db.tbl_Images join b in Global.Db.tbl_Batches on w.BatchID equals (b.BatchID) where b.City == lb_City.Text & w.BatchID == BatchID & w.TienDoDeSo == "Hình chưa nhập" select w.IDImage).Count().ToString();
                    lb_SoHinhDangNhap.Text = (from w in Global.Db.tbl_Images join b in Global.Db.tbl_Batches on w.BatchID equals (b.BatchID) where b.City == lb_City.Text & w.BatchID == BatchID & w.TienDoDeSo == "Hình đang nhập" select w.IDImage).Count().ToString();
                    lb_SoHinhChoCheck.Text = (from w in Global.Db.tbl_Images join b in Global.Db.tbl_Batches on w.BatchID equals (b.BatchID) where b.City == lb_City.Text & w.BatchID == BatchID & w.TienDoDeSo == "Hình chờ check" select w.IDImage).Count().ToString();
                    lb_SoHinhDangCheck.Text = (from w in Global.Db.tbl_Images join b in Global.Db.tbl_Batches on w.BatchID equals (b.BatchID) where b.City == lb_City.Text & w.BatchID == BatchID & w.TienDoDeSo == "Hình đang check" select w.IDImage).Count().ToString();
                    lb_SoHinhHoanThanh.Text = (from w in Global.Db.tbl_Images join b in Global.Db.tbl_Batches on w.BatchID equals (b.BatchID) where b.City == lb_City.Text & w.BatchID == BatchID & w.TienDoDeSo == "Hình hoàn thành" select w.IDImage).Count().ToString();
                    gridControl1.DataSource = null;
                    gridControl1.DataSource = Global.Db.ChiTietTienDo(BatchID,lb_City.Text,"DESO");
                    gridView1.RowCellStyle += GridView1_RowCellStyle;
                }
                else if (Loai == "DEJP")
                {

                    lb_TongSoHinh.Text = (from w in Global.Db.tbl_Images join b in Global.Db.tbl_Batches on w.BatchID equals (b.BatchID) where b.City == lb_City.Text & w.BatchID == BatchID select w.IDImage).Count().ToString();
                    lb_SoHinhChuaNhap.Text = (from w in Global.Db.tbl_Images join b in Global.Db.tbl_Batches on w.BatchID equals (b.BatchID) where b.City == lb_City.Text & w.BatchID == BatchID & w.TienDoDeJP == "Hình chưa nhập" select w.IDImage).Count().ToString();
                    lb_SoHinhDangNhap.Text = (from w in Global.Db.tbl_Images join b in Global.Db.tbl_Batches on w.BatchID equals (b.BatchID) where b.City == lb_City.Text & w.BatchID == BatchID & w.TienDoDeJP == "Hình đang nhập" select w.IDImage).Count().ToString();
                    lb_SoHinhChoCheck.Text = (from w in Global.Db.tbl_Images join b in Global.Db.tbl_Batches on w.BatchID equals (b.BatchID) where b.City == lb_City.Text & w.BatchID == BatchID & w.TienDoDeJP == "Hình chờ check" select w.IDImage).Count().ToString();
                    lb_SoHinhDangCheck.Text = (from w in Global.Db.tbl_Images join b in Global.Db.tbl_Batches on w.BatchID equals (b.BatchID) where b.City == lb_City.Text & w.BatchID == BatchID & w.TienDoDeJP == "Hình đang check" select w.IDImage).Count().ToString();
                    lb_SoHinhHoanThanh.Text = (from w in Global.Db.tbl_Images join b in Global.Db.tbl_Batches on w.BatchID equals (b.BatchID) where b.City == lb_City.Text & w.BatchID == BatchID & w.TienDoDeJP == "Hình hoàn thành" select w.IDImage).Count().ToString();
                    gridControl1.DataSource = null;
                    gridControl1.DataSource = Global.Db.ChiTietTienDo(BatchID, lb_City.Text, "DEJP");
                    gridView1.RowCellStyle += GridView1_RowCellStyle;
                }
            }
        }

        private void GridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            GridView View = sender as GridView;
            if (e.Column.FieldName == "ThongTin")
            {
                string category = View.GetRowCellDisplayText(e.RowHandle, View.Columns["ThongTin"]);
                if (category == "Hình đang nhập")
                    e.Appearance.BackColor = Color.HotPink;
                else if (category == "Hình chờ check")
                {
                    e.Appearance.BackColor = Color.OrangeRed;
                    e.Appearance.ForeColor = Color.White;
                }
                else if (category == "Hình đang check")
                {
                    e.Appearance.BackColor = Color.Purple;
                    e.Appearance.ForeColor = Color.White;
                }
                else if (category == "Hình hoàn thành")
                {
                    e.Appearance.BackColor = Color.Green;
                    e.Appearance.ForeColor = Color.White;
                }
            }
        }

        private void repositoryItemPopupContainerEdit1_Click(object sender, EventArgs e)
        {
            string idimage = gridView1.GetFocusedRowCellValue("IDImage").ToString();
            string batchID = gridView1.GetFocusedRowCellValue("BatchID").ToString();
            gridControl2.DataSource = null;
            if(Loai=="DESO" || BatchID=="AllDESO")
            {
                gridControl2.DataSource = Global.Db.ChiTietUser(batchID, idimage,lb_City.Text,"DESO");
            }
            else if (Loai == "DEJP" || BatchID == "AllDEJP")
            {
                gridControl2.DataSource = Global.Db.ChiTietUser(batchID, idimage, lb_City.Text, "DEJP");
            }
        }

        private void gridView1_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            LoadSttGridView(e, gridView1);
        }

        private void rb_deso_CheckedChanged(object sender, EventArgs e)
        {
            //frm_ChiTietTienDo_Load(null, null);
        }

        private void rb_dejp_CheckedChanged(object sender, EventArgs e)
        {
            //frm_ChiTietTienDo_Load(null, null);
        }
    }
}