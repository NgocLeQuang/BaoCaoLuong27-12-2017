using BaoCaoLuong2018.Properties;
using System;
using System.Windows.Forms;

namespace BaoCaoLuong2018.BaoCaoLuonng2017.MyForm
{
    public partial class frm_ChangeZoom : DevExpress.XtraEditors.XtraForm
    {
        public frm_ChangeZoom()
        {
            InitializeComponent();
        }

        private void frm_ChangeZoom_Load(object sender, EventArgs e)
        {
            trackBarControl1.EditValue = Settings.Default.ZoomImage;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Settings.Default.ZoomImage = Convert.ToInt32(trackBarControl1.EditValue);
            MessageBox.Show("Thay đổi Zoom thành công!");
        }
    }
}