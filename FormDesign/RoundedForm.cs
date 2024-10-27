using System;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Forms;

namespace Calculator_Dacal.FormDesign
{
    public class RoundedForm : Form
    {
        public RoundedForm()
        {
            this.FormBorderStyle = FormBorderStyle.None; // Remove the border for rounded effect
            this.StartPosition = FormStartPosition.CenterScreen; // Center the form on the screen
            this.Size = new Size(400, 300); // Set the size of the form
            this.BackColor = Color.LightBlue; // Set background color
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            using (GraphicsPath path = new GraphicsPath())
            {
                int radius = 20; // Set the radius for the corners
                path.AddArc(0, 0, radius, radius, 180, 90);
                path.AddArc(this.Width - radius, 0, radius, radius, 270, 90);
                path.AddArc(this.Width - radius, this.Height - radius, radius, radius, 0, 90);
                path.AddArc(0, this.Height - radius, radius, radius, 90, 90);
                path.CloseFigure();

                this.Region = new Region(path);
            }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // RoundedForm
            // 
            this.ClientSize = new System.Drawing.Size(485, 563);
            this.Name = "RoundedForm";
            this.ResumeLayout(false);

        }
    }
}