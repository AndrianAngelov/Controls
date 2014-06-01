namespace Anyo.WindowsForms.Controls.Panels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Data;
    using System.Windows.Forms;
    using System.Drawing.Drawing2D;

    /// <summary>
    /// This class inherit Panel control and allows you to customize to rounded corners Panel.
    /// </summary>
    public partial class RoundedPanel : Panel
    {
        /// <summary>
        /// Specifies the fill gradient style for a RoundedPanel control.
        /// </summary>
        public enum GradientStyles
        {
            /// <summary>
            /// A pattern of horizontal lines.
            /// </summary>
            Horizontal,
            /// <summary>
            /// A pattern of vertical lines.
            /// </summary>
            Vertical,
            /// <summary>
            /// A pattern of lines that slant from upper left to lower right.
            /// </summary>
            ForwardDiagonal,
            /// <summary>
            /// A pattern of lines that slant from upper right to lower left.
            /// </summary>
            BackwardDiagonal
        }

        private Int32 borderWidth = 1;
        private Int32 radius = 2;

        private Color borderColor = Color.Black;
        private Color fillColorA ; 
        private Color fillColorB ;

        private GradientStyles gradientStyle = GradientStyles.Vertical;

        /// <summary>
        /// Gets or sets border thickness of the RoundedPanel.
        /// </summary>
        [Description("Gets or sets border thickness of the RoundedPanel."), Category("RoundedPanel")]
        public Int32 BorderWidth
        {
            get { return borderWidth; }
            set { borderWidth = value; }
        }

        /// <summary>
        /// Gets or sets rounded corners radius of the RoundedPanel.
        /// </summary>
        [Description("Gets or sets rounded corners radius of the RoundedPanel."), Category("RoundedPanel")]
        public Int32 Radius
        {
            get { return radius; }
            set { radius = value; }
        }

        /// <summary>
        /// Gets or sets border color of the RoundedPanel.
        /// </summary>
        [Description("Gets or sets border color of the RoundedPanel."), Category("RoundedPanel")]
        public Color BorderColor
        {
            get { return borderColor; }
            set { borderColor = value; }
        }

        /// <summary>
        ///  Gets or sets background top-middle gradient color of RoundedPanel.
        /// </summary>
        [Description("Gets or sets background top-middle gradient color of RoundedPanel."), Category("RoundedPanel")]
        public Color FillColorA
        {
            get { return fillColorA; }
            set { fillColorA = value; }
        }

        /// <summary>
        /// Gets or sets background middle-bottom gradient color of RoundedPanel.
        /// </summary>
        [Description("Gets or sets background middle-bottom gradient color of RoundedPanel."), Category("RoundedPanel")]
        public Color FillColorB
        {
            get { return fillColorB; }
            set { fillColorB = value; }
        }

        public RoundedPanel()
        {
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            LinearGradientBrush brush;
            LinearGradientMode mode;

            //
            // set LinearGradientMode
            //
            switch (gradientStyle)
            {
                case GradientStyles.Horizontal:
                    mode = LinearGradientMode.Horizontal;
                    break;
                case GradientStyles.Vertical:
                    mode = LinearGradientMode.Vertical;
                    break;
                case GradientStyles.ForwardDiagonal:
                    mode = LinearGradientMode.ForwardDiagonal;
                    break;
                case GradientStyles.BackwardDiagonal:
                    mode = LinearGradientMode.BackwardDiagonal;
                    break;
                default:
                    mode = LinearGradientMode.Vertical;
                    break;
            }

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            Rectangle newRect = new Rectangle(ClientRectangle.X + borderWidth, ClientRectangle.Y + borderWidth, ClientRectangle.Width - 2 * borderWidth, ClientRectangle.Height - 2 * borderWidth);
            GraphicsPath button = DrawRoundedRectangle(radius, newRect);

            brush = new LinearGradientBrush(newRect, fillColorA, fillColorB, mode);

            e.Graphics.FillPath(brush, button);
            e.Graphics.DrawPath(new Pen(borderColor, borderWidth), button);
        }

        private static GraphicsPath DrawRoundedRectangle(int radius, Rectangle newRectangle)
        {
            GraphicsPath gp = new GraphicsPath();
            //int radius = 4;
            int diameter = radius * 2;
            int d = diameter;
            gp.AddArc(newRectangle.X, newRectangle.Y, d, d, 180, 90);
            gp.AddArc(newRectangle.X + newRectangle.Width - d, newRectangle.Y, d, d, 270, 90);
            gp.AddArc(newRectangle.X + newRectangle.Width - d, newRectangle.Y + newRectangle.Height - d, d, d, 0, 90);
            gp.AddArc(newRectangle.X, newRectangle.Y + newRectangle.Height - d, d, d, 90, 90);
            gp.AddLine(newRectangle.X, newRectangle.Y + newRectangle.Height - d, newRectangle.X, newRectangle.Y + d / 2);
            return gp;
        }

    }
}
