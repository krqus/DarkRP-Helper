using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DarkRP_Helper
{
    public partial class CreateShipment : UserControl
    {
        public CreateShipment()
        {
            InitializeComponent();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            int price = Convert.ToInt32(ShipmentPrice.Text);
            int shipmentamount = Convert.ToInt32(ShipmentAmount.Text);
            int gunprice = price / shipmentamount;
            WeaponPrice.Text = gunprice.ToString();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            int price = Convert.ToInt32(WeaponPrice.Text);
            int shipmentamount = Convert.ToInt32(ShipmentAmount.Text);
            int gunprice = price * shipmentamount;
            ShipmentPrice.Text = gunprice.ToString();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            guna2TextBox3.Text = "";
            // Constructing the DarkRP shipment creation code with user input
            guna2TextBox3.Text = "DarkRP.createShipment(\"" + ShipmentName.Text + "\", {" + Environment.NewLine +
                                 "    entity = \"" + WeaponEntity.Text + "\"," + Environment.NewLine +
                                 "    model = \"" + ShipmentModel.Text + "\"," + Environment.NewLine;

            // Weapon & Shipment Check
            if (ShipmentType.Text == "Weapon and Shipment")
            {
                // Creating a shipment with both weapon and shipment items
                guna2TextBox3.Text += "    amount = " + ShipmentAmount.Text + "," + Environment.NewLine +
                                      "    price = " + ShipmentPrice.Text + "," + Environment.NewLine +
                                      "    pricesep = " + WeaponPrice.Text + "," + Environment.NewLine +
                                      "    noship = false," + Environment.NewLine +
                                      "    separate = true," + Environment.NewLine;
            }
            else if (ShipmentType.Text == "Weapon Only")
            {
                // Creating a shipment with only a weapon item
                guna2TextBox3.Text += "    amount = 1," + Environment.NewLine +
                                      "    price = " + WeaponPrice.Text + "," + Environment.NewLine +
                                      "    pricesep = " + WeaponPrice.Text + "," + Environment.NewLine +
                                      "    noship = false," + Environment.NewLine +
                                      "    separate = true," + Environment.NewLine;
            }
            else if (ShipmentType.Text == "Shipment Only")
            {
                // Creating a shipment with only a shipment item
                guna2TextBox3.Text += "    amount = " + ShipmentAmount.Text + "," + Environment.NewLine +
                                      "    price = " + ShipmentPrice.Text + "," + Environment.NewLine +
                                      "    pricesep = " + WeaponPrice.Text + "," + Environment.NewLine +
                                      "    noship = false," + Environment.NewLine +
                                      "    separate = false," + Environment.NewLine;
            }
            // Weapon & Shipment Check End

            // Adding the category for the shipment
            guna2TextBox3.Text += "    category = \"" + Category.Text + "\"," + Environment.NewLine;

            // Allowed Check
            if (!String.IsNullOrEmpty(AllowedTeam.Text))
            {
                // Specifying the allowed teams for the shipment
                guna2TextBox3.Text += "    allowed = {" + Environment.NewLine +
                                      "        " + AllowedTeam.Text + Environment.NewLine +
                                      "    }," + Environment.NewLine;
            }

            guna2TextBox3.Text += "})";


        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }
    }
}
