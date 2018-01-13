using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.UserSkins;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using BaoCaoLuong2018.MyForm;

namespace BaoCaoLuong2018
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            BonusSkins.Register();
            SkinManager.EnableFormSkins();
            UserLookAndFeel.Default.SetSkinStyle("DevExpress Style");
            //Application.Run(new FrmTienDo());
            if (new frm_ChangeServer().ShowDialog() != DialogResult.OK)
                return;
            bool temp = false;
            do
            {
                temp = false;
                
                frmLogin frLogin = new frmLogin();
                if (frLogin.ShowDialog() == DialogResult.OK)
                {
                    if (Global.StrCity == "CityS")
                    {
                        BaoCaoLuonng2017.Global.StrMachine = Global.StrPcName;
                        BaoCaoLuonng2017.Global.StrUserWindow = Global.StrDomainName;
                        BaoCaoLuonng2017.Global.StrIpAddress = "";
                        BaoCaoLuonng2017.Global.StrUsername = Global.StrUserName;
                        BaoCaoLuonng2017.Global.StrBatch = Global.StrBatch;
                        BaoCaoLuonng2017.Global.StrRole = Global.StrRole;
                        BaoCaoLuonng2017.Global.Strtoken = Global.Token;
                        BaoCaoLuonng2017.Global.StrCity = Global.StrCity;
                        BaoCaoLuonng2017.MyForm.frm_Main fm = new BaoCaoLuonng2017.MyForm.frm_Main();
                        if (fm.ShowDialog() == DialogResult.Yes)
                        {
                            fm.Close();
                            frLogin.txt_username_TextChanged(null, null);
                            temp = true;
                        }
                    }
                    else
                    {
                        frm_Main frMain = new frm_Main();
                        if (frMain.ShowDialog() == DialogResult.Yes)
                        {
                            frMain.Close();
                            temp = true;
                        }
                    }
                }
            }
            while (temp);
        }
    }
}
