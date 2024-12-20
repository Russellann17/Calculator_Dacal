﻿using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Calculator_Dacal.FormDesign // Adjust based on your project name
{
    public class RoundButton : Button
    {
        public int BorderRadius { get; set; } = 20;
        public Image ButtonImage { get; set; }

        // Settable hover color
        public Color HoverColor { get; set; } = Color.LightGray;

        private Color originalBackColor;

        public RoundButton()
        {
            originalBackColor = this.BackColor;
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
            Graphics graphics = pevent.Graphics;
            graphics.SmoothingMode = SmoothingMode.AntiAlias;

            using (GraphicsPath path = GetRoundedRectanglePath(ClientRectangle, BorderRadius))
            {
                this.Region = new Region(path);
                using (SolidBrush brush = new SolidBrush(this.BackColor))
                {
                    graphics.FillPath(brush, path);
                }
                if (ButtonImage != null)
                {
                    int imageX = (Width - ButtonImage.Width) / 2;
                    int imageY = (Height - ButtonImage.Height) / 2;
                    graphics.DrawImage(ButtonImage, new Rectangle(imageX, imageY, ButtonImage.Width, ButtonImage.Height));
                }
                TextRenderer.DrawText(graphics, this.Text, this.Font, ClientRectangle, this.ForeColor,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            }
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            originalBackColor = this.BackColor; // Store original color
            this.BackColor = HoverColor; // Change to assigned hover color
            Invalidate(); // Redraw to show hover effect
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            this.BackColor = originalBackColor; // Reset to original color
            Invalidate(); // Redraw to remove hover effect
        }

        private GraphicsPath GetRoundedRectanglePath(Rectangle rect, int radius)
        {
            int diameter = radius * 2;
            GraphicsPath path = new GraphicsPath();
            path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90);
            path.AddArc(rect.Right - diameter, rect.Y, diameter, diameter, 270, 90);
            path.AddArc(rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90);
            path.AddArc(rect.X, rect.Bottom - diameter, diameter, diameter, 90, 90);
            path.CloseFigure();
            return path;
        }
    }
}
