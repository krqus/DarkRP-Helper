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
using System.Windows.Documents;
using System.Windows.Forms;

namespace DarkRP_Helper
{
    public partial class CreateJob : UserControl
    {

        public CreateJob()
        {
            InitializeComponent();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            JobColor.Text = colorDialog1.Color.R + "," + colorDialog1.Color.G + "," + colorDialog1.Color.B;
            guna2Button3.FillColor = colorDialog1.Color;
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            guna2TextBox3.Text = JobID.Text + " = DarkRP.createJob(\"" + JobName.Text + "\", {" + Environment.NewLine +
                "    color = Color(" + JobColor.Text + ")," + Environment.NewLine +
                "    model = \"" + PlayerModel.Text + "\"," + Environment.NewLine +
                "    description = \"" + JobInfo.Text + "\"," + Environment.NewLine +
                "    weapons = {\"" + Weapon.Text + "\"}," + Environment.NewLine +
                "    command = \"" + JobCommand.Text + "\"," + Environment.NewLine +
                "    max = " + MaxPlayers.Text + "," + Environment.NewLine +
                "    salary = " + Salary.Text + "," + Environment.NewLine;

            if (superadmin.Checked)
            {
                guna2TextBox3.Text += "    admin = 2," + Environment.NewLine;
            }
            else if (admin.Checked)
            {
                guna2TextBox3.Text += "    admin = 1," + Environment.NewLine;
            }
            else if (everybody.Checked)
            {
                guna2TextBox3.Text += "    admin = 0," + Environment.NewLine;
            }

            if (Vote.Checked)
            {
                guna2TextBox3.Text +=
                    "    vote = true," + Environment.NewLine;
            }
            else
            {
                guna2TextBox3.Text +=
                    "    vote = false," + Environment.NewLine;
            }

            if (License.Checked)
            {
                guna2TextBox3.Text +=
                    "    hasLicense = true," + Environment.NewLine;
            }
            else
            {
                guna2TextBox3.Text +=
                    "    hasLicense = false," + Environment.NewLine;
            }

            guna2TextBox3.Text +=
                "    category = \"" + JobCategory.Text + "\"," + Environment.NewLine;

            if (Demote.Checked)
            {
                guna2TextBox3.Text +=
                    "    canDemote = true," + Environment.NewLine;
            }
            else
            {
                guna2TextBox3.Text +=
                    "    canDemote = false," + Environment.NewLine;
            }

            if (Mayor.Checked)
            {
                guna2TextBox3.Text +=
                    "    mayor = true," + Environment.NewLine;
            }
            else if (Chief.Checked)
            {
                guna2TextBox3.Text +=
                    "    chief = true," + Environment.NewLine;
            }
            else if (Medic.Checked)
            {
                guna2TextBox3.Text +=
                    "    medic = true," + Environment.NewLine;
            }
            else if (Cook.Checked)
            {
                guna2TextBox3.Text +=
                    "    cook = true," + Environment.NewLine;
            }
            else if (Hobo.Checked)
            {
                guna2TextBox3.Text +=
                    "    hobo = true," + Environment.NewLine;
            }

            // Custom Checks

            if (BountyHunter.Checked)
            {
                guna2TextBox3.Text +=
                    "    BountyHunter = true," + Environment.NewLine;
            }

            if (PoliceOfficer.Checked)
            {
                guna2TextBox3.Text +=
                    "    isCP = true," + Environment.NewLine;
            }

            // PlayerSpawn

            if (!String.IsNullOrEmpty(Health.Text) || !String.IsNullOrEmpty(Armor.Text))
            {
                guna2TextBox3.Text +=
                    "    PlayerSpawn = function(ply)" + Environment.NewLine;
            }

            if (!String.IsNullOrEmpty(Health.Text))
            {
                guna2TextBox3.Text +=
                "        ply:SetHealth(" + Health.Text + ")" + Environment.NewLine +
                "        ply:SetMaxHealth(" + Health.Text + ")" + Environment.NewLine;
            }

            if (!String.IsNullOrEmpty(Armor.Text))
            {
                guna2TextBox3.Text +=
                "        ply:SetArmor(" + Armor.Text + ")" + Environment.NewLine +
                "        ply:SetMaxArmor(" + Armor.Text + ")" + Environment.NewLine;
            }

            if (!String.IsNullOrEmpty(Health.Text) || !String.IsNullOrEmpty(Armor.Text))
            {
                guna2TextBox3.Text +=
                "    end," + Environment.NewLine;
            }

            // PlayerSpawn End

            // Juggernaut
            if (Juggernaut.Checked)
            {
                guna2TextBox3.Text +=
                    "    PlayerDeath = function(ply, weapon, killer)" + Environment.NewLine +
                    "        if killer:IsPlayer() then" + Environment.NewLine +
                    "            ply:changeTeam(GAMEMODE.DefaultTeam, true)" + Environment.NewLine +
                    "            killer:changeTeam(" + JobID.Text + ", true)" + Environment.NewLine +
                    "            DarkRP.notify(killer, 1, 4, \"You have became the " + JobName.Text + "!\")" + Environment.NewLine +
                    "            DarkRP.notify(ply, 1, 4, \"You are no longer the " + JobName.Text + "!\")" + Environment.NewLine +
                    $"            killer:addMoney({CashKill.Text})" + Environment.NewLine +
                    "    end," + Environment.NewLine;
            }



            // Juggernaut


            if (!String.IsNullOrEmpty(JobIDRequirement.Text))
            {
                guna2TextBox3.Text +=
                    "    NeedToChangeFrom = " + JobIDRequirement.Text + "," + Environment.NewLine;
            }

            guna2TextBox3.Text +=
                "})";
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();

            save.Filter = "Job File | *.job | Lua File | *.lua";
            save.ShowDialog();

            File.AppendAllText(save.FileName, guna2TextBox3.Text);

            // Requires Microsoft.Toolkit.Uwp.Notifications NuGet package version 7.0 or greater
            new ToastContentBuilder()
                .AddText("Save Success")
                .AddText("Job has been successfully saved to "+ save.FileName + ".")
                .Show(); // Not seeing the Show() method? Make sure you have version 7.0, and if you're using .NET 6 (or later), then your TFM must be net6.0-windows10.0.17763.0 or greater

        }


        private void CreateJob_Load(object sender, EventArgs e)
        {
            var PAID = new
            {
                IS_BOUNTY_HUNTER = "This custom job check requires Brick's Bounty Hunter",
                IS_POLICE_OFFICER = "This custom job check requires Realistic Police"
            };

            var STRINGS = new
            {
                CAN_BE_DEMOTED = "Is this job able to be demoted by others?",
                REQUIRES_VOTE = "Do players need to be voted into the job? (Used for jobs like Mayor and Police)",
                SUPERADMIN = "Must be superadmin to use the job",
                ADMIN = "Must be admin to use the job",
                EVERYBODY = "Everybody can use the job",
                JUGGERNAUT = "This job is for people who want to have an event. When the juggernaut is killed the player who killed the juggernaut will recieve a cash reward and turn into the juggernaut."
            };
            //
            Paid.SetToolTip(BountyHunter, PAID.IS_BOUNTY_HUNTER);
            Paid.SetToolTip(PoliceOfficer, PAID.IS_POLICE_OFFICER);
            //
            Base.SetToolTip(Demote, STRINGS.CAN_BE_DEMOTED);
            Base.SetToolTip(Vote, STRINGS.REQUIRES_VOTE);
            Base.SetToolTip(superadmin, STRINGS.SUPERADMIN);
            Base.SetToolTip(admin, STRINGS.ADMIN);
            Base.SetToolTip(everybody, STRINGS.EVERYBODY);
            //
            Exclusive.SetToolTip(Juggernaut, STRINGS.JUGGERNAUT);
        }

        private void Juggernaut_Click(object sender, EventArgs e)
        {
            if (Juggernaut.Checked)
            {
                label37.Visible = true;
                CashKill.Visible = true;
            }
            else
            {
                label37.Visible = false;
                CashKill.Visible = false;
            }
        }
    }
}