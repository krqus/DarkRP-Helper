using Guna.UI2.WinForms;
using Microsoft.Toolkit.Uwp.Notifications;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DarkRP_Helper
{
    public partial class CreateAmmo : UserControl
    {
        public CreateAmmo()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();

            save.Filter = "Shipment File | *.shpmnt | Lua File | *.lua";
            save.ShowDialog();

            File.AppendAllText(save.FileName, guna2TextBox3.Text);

            // Requires Microsoft.Toolkit.Uwp.Notifications NuGet package version 7.0 or greater
            new ToastContentBuilder()
                .AddText("Save Success")
                .AddText("Job has been successfully saved to " + save.FileName + ".")
                .Show(); // Not seeing the Show() method? Make sure you have version 7.0, and if you're using .NET 6 (or later), then your TFM must be net6.0-windows10.0.17763.0 or greater


        }

        private void CreateAmmo_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            guna2TextBox3.Text = "";
            string type = AmmoType.Text;
            string customName = ammonam3.Text;
            string customModel = AmmoModel.Text;
            string customPrice = AmmoPrice.Text;
            string customAmountGiven = "10";

            guna2TextBox3.Text = 
            @"DarkRP.createAmmoType(""" + type + @""", new
            {
                name = """ + customName + @""",
                model = """ + customModel + @""",
                price = " + customPrice + @",
                amountGiven = " + customAmountGiven + @"
            })";

        }
    }
}
