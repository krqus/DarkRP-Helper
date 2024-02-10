using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DarkRP_Helper
{
    public partial class Dashboard : Form
    {

        private async Task RGB()
        {
            double t = _colorTick * _colorSpeed;
            var nextColor = Color.FromArgb((int)(Math.Sin(t) * 127 + 128), (int)(Math.Sin(t + 2) * 127 + 128), (int)(Math.Sin(t + 4) * 127 + 128));
            guna2Panel1.BorderColor = InterpolateColors(guna2Panel1.BorderColor, nextColor, _colorInterpolation);
            _colorTick++;
        }


        private int _colorTick;
        private readonly double _colorSpeed = 0.012;
        private readonly double _colorInterpolation = 0.1;

        private static Color InterpolateColors(Color color1, Color color2, double interpolation)
        {
            int red = (int)(color1.R + (color2.R - color1.R) * interpolation);
            int green = (int)(color1.G + (color2.G - color1.G) * interpolation);
            int blue = (int)(color1.B + (color2.B - color1.B) * interpolation);
            return Color.FromArgb(red, green, blue);
        }

        private async void colourfade_Tick(object sender, EventArgs e)
        {
            await RGB();
        }

        public Dashboard()
        {
            InitializeComponent();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            label1.Text +=  "Valenity!";
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void guna2GradientTileButton1_Click(object sender, EventArgs e)
        {
            MainHolder c = new MainHolder();
            CreateJob d = new CreateJob();
            c.label1.Text = "Job Creator";
            c.guna2Panel2.Controls.Clear();
            c.guna2Panel2.Controls.Add(d);
            c.Show();
        }

        private void guna2GradientTileButton3_Click(object sender, EventArgs e)
        {
            MainHolder c = new MainHolder();
            CreateShipment d = new CreateShipment();
            c.label1.Text = "Shipment Creator";
            c.guna2Panel2.Controls.Clear();
            c.guna2Panel2.Controls.Add(d);
            c.Show();
        }
    }
}
