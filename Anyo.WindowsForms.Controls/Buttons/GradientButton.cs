namespace Anyo.WindowsForms.Controls.Buttons
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Data;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Drawing.Drawing2D;

    /// <summary>
    /// Represents a Windows custom button control
    /// </summary>
    /// <remarks>Here's a VisualStudio property window view of GradientButton control: <br />
    /// <img src="../Images/GradientButtonProprties.jpg" />
    /// </remarks>
    public partial class GradientButton : Control
    {
        #region Enumerations
        private enum _States
        {
            Normal,
            MouseOver,
            Clicked
        }

        /// <summary>
        /// Specifies whether smoothing (antialiasing) is applied to lines and curves and the edges of filled areas.
        /// </summary>
        public enum SmoothingQualities
        {
            /// <summary>
            /// Specifies no antialiasing.
            /// </summary>
            None,
            /// <summary>
            /// Specifies no antialiasing.
            /// </summary>
            HighSpeed,
            /// <summary>
            /// Specifies antialiased rendering.
            /// </summary>
            AntiAlias,
            /// <summary>
            /// Specifies antialiased rendering.
            /// </summary>
            HighQuality
        }
        /// <summary>
        /// Specifies how a shape GradientButton will be drawn.
        /// </summary>
        public enum ButtonStyles
        {
            /// <summary>
            /// Specifies rectangles GradientButton
            /// </summary>
            Rectangle,
            /// <summary>
            /// Specifies rounded rectangles GradientButton
            /// </summary>
            RoundedEdgesRectangel,
            /// <summary>
            /// Specifies circular or oval GradientButton
            /// </summary>
            Ellipse,
        }

        /// <summary>
        /// Specifies the fill gradient style for a GradientButton control.
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
        /// <summary>
        /// Specifies whether the text or image in the object is top-centered, middle-centered, bottom-centered, or none(set specific x,y coordinates that start from top left corner).
        /// </summary>
        public enum Alignment
        {
            /// <summary>
            /// Disable general alignment and set specific x,y coordinates that start from top left corner
            /// </summary>
            None,
            /// <summary>
            /// The control's text or/and image is/are horizontally centered , vertically on top
            /// </summary>
            TopCenter,
            /// <summary>
            /// The control's text or/and image is/are horizontally and vertically centered
            /// </summary>
            Center,
            /// <summary>
            /// The control's text or/and image is/are horizontally centered , vertically on bottom
            /// </summary>
            BottomCenter,
        }

        #endregion

        #region Fields
        private bool _Active = true;
        private _States _State = _States.Normal;
        private Alignment imageAlignment = Alignment.None;
        private Alignment textAlignment = Alignment.Center;

        private GradientStyles gradientStyle = GradientStyles.Vertical;
        private ButtonStyles buttonStyle = ButtonStyles.RoundedEdgesRectangel;
        private SmoothingQualities smoothingQuality = SmoothingQualities.AntiAlias;

        private Color normalBorderColor = Color.Black;
        private Color normalColorA = Color.Orange;
        private Color normalColorB = Color.PeachPuff;

        private Color hoverBorderColor = Color.Linen;
        private Color hoverColorA = Color.PeachPuff;
        private Color hoverColorB = Color.Orange;

        private Color clickBorderColor = Color.Cornsilk;
        private Color clickColorA = Color.DarkOrange;
        private Color clickColorB = Color.DarkGoldenrod;

        private Int32 radius = 2;
        private Int32 borderWidth = 1;

        private Int32 imageCornerX;
        private Int32 imageCornerY;

        //private Int32 textX;
        //private Int32 textY;

        private float textX;
        private float textY;

        private Image image;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the GradienButton class.
        /// <div>Default values:</div>
        /// <list type="bullet">
        /// <item>
        /// <term>width=100</term>
        /// </item>
        /// <item>
        /// <term>height=25</term>
        /// </item>
        /// <item>
        /// <term>FontFamily/Size/Style : Microsoft San Serif/8.25f/Regular</term>
        /// </item>
        /// </list>
        /// </summary>
        public GradientButton()
        {
            // initiate button size and font
            base.Size = new Size(100, 25);
            base.Font = new Font("Microsoft San Serif", 8.25f, FontStyle.Regular);
            SetStyle(
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.ResizeRedraw |
                ControlStyles.DoubleBuffer |
                ControlStyles.Selectable |
                ControlStyles.UserMouse,
                true
                );
        }

        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the rendering quality for this Graphics.
        /// </summary>
        [Description("Gets or sets the rendering quality for this Graphics."), Category("GradientButton")]
        public SmoothingQualities SmoothingQuality
        {
            get
            {
                return smoothingQuality;
            }
            set
            {
                smoothingQuality = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the fill gradient style for a GradientButton control.
        /// </summary>
        [Description("Gets or sets the fill gradient style for a GradientButton control."), Category("GradientButton")]
        public GradientStyles GradientStyle
        {
            get
            {
                return gradientStyle;
            }
            set
            {
                gradientStyle = value;
                this.Invalidate();
            }

        }

        /// <summary>
        /// Gets or sets how a shape GradientButton will be drawn.
        /// </summary>
        [Description("Gets or sets how a shape GradientButton will be drawn."), Category("GradientButton")]
        public ButtonStyles ButtonStyle
        {
            get
            {
                return buttonStyle;
            }
            set
            {
                buttonStyle = value;
                this.Invalidate();
            }
        }

        /// <summary> 
        /// Gets or sets rounded corners radius of the GradientButton.
        /// </summary> 
        /// <example>  
        /// This sample shows how to call the <see cref="ButtonRadius"/> property.
        /// <code> 
        ///public UsersAccountsCenter()
        ///{
        ///    InitializeComponent();
        ///
        ///    GradienButton button=new GradientButton();
        ///    button.Buttonradius=5;
        ///} 
        /// </code> 
        /// </example>
        [Description("Gets or sets rounded corners radius of the GradientButton."), Category("GradientButton")]
        public Int32 ButtonRadius
        {
            get
            {
                return radius;
            }
            set
            {
                radius = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets border thickness of the GradientButton.
        /// </summary>
        [Description("Gets or sets border thickness of the GradientButton."), Category("GradientButton")]
        public Int32 BorderWidth
        {
            get
            {
                return borderWidth;
            }
            set
            {
                borderWidth = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets border color of GradientButton in Normal state.
        /// </summary>
        [Description("Gets or sets border color of GradientButton in Normal state."), Category("GradientButton")]
        public Color NormalBorderColor
        {
            get
            {
                return normalBorderColor;
            }
            set
            {
                normalBorderColor = value;
                this.Invalidate();
            }

        }

        /// <summary>
        /// Gets or sets top-middle gradient color of GradientButton in Normal state.
        /// </summary>
        [Description("Gets or sets top-middle gradient color of GradientButton in Normal state."), Category("GradientButton")]
        public Color NormalColorA
        {
            get
            {
                return normalColorA;
            }
            set
            {
                normalColorA = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets middle-bottom gradient color of GradientButton in Normal state.
        /// </summary>
        [Description("Gets or sets middle-bottom gradient color of GradientButton in Normal state."), Category("GradientButton")]
        public Color NormalColorB
        {
            get
            {
                return normalColorB;
            }
            set
            {
                normalColorB = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets border color of GradientButton when raise OnMouseEner event.
        /// </summary>
        [Description("Gets or sets border color of GradientButton when raise OnMouseEner event."), Category("GradientButton")]
        public Color HoverBorderColor
        {
            get
            {
                return hoverBorderColor;
            }
            set
            {
                hoverBorderColor = value;
                this.Invalidate();
            }

        }

        /// <summary>
        ///Gets or sets top-middle gradient color of GradientButton when raise OnMouseEner event. 
        /// </summary>
        [Description("Gets or sets top-middle gradient color of GradientButton when raise OnMouseEner event."), Category("GradientButton")]
        public Color HoverColorA
        {
            get
            {
                return hoverColorA;
            }
            set
            {
                hoverColorA = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets middle-bottom gradient color of GradientButton when raise OnMouseEner event. 
        /// </summary>
        [Description("Gets or sets middle-bottom gradient color of GradientButton when raise OnMouseEner event."), Category("GradientButton")]
        public Color HoverColorB
        {
            get
            {
                return hoverColorB;
            }
            set
            {
                hoverColorB = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets border color of GradientButton when raise OnMouseDown event.
        /// </summary>
        [Description("Gets or sets border color of GradientButton when raise OnMouseDown event."), Category("GradientButton")]
        public Color ClickBorderColor
        {
            get
            {
                return clickBorderColor;
            }
            set
            {
                clickBorderColor = value;
                this.Invalidate();
            }

        }

        /// <summary>
        /// Gets or sets top-middle gradient color of GradientButton when raise OnMouseDown event. 
        /// </summary>
        [Description("Gets or sets top-middle gradient color of GradientButton when raise OnMouseDown event."), Category("GradientButton")]
        public Color ClickColorA
        {
            get
            {
                return clickColorA;
            }
            set
            {
                clickColorA = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets middle-bottom gradient color of GradientButton when raise OnMouseDown event. 
        /// </summary>
        [Description("Gets or sets middle-bottom gradient color of GradientButton when raise OnMouseDown event."), Category("GradientButton")]
        public Color ClickColorB
        {
            get
            {
                return clickColorB;
            }
            set
            {
                clickColorB = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets GradientButton's iamge content. 
        /// </summary>
        [Category("GradientButton"), DefaultValue(typeof(Image), null)]
        [Description("Gets or sets GradientButton's iamge content.")]
        public Image AddImage
        {
            get
            {
                return image;
            }
            set
            {
                image = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets GradientButton's iamge content X position from top-left corner when general alignment is none.
        /// </summary>
        [Description("Gets or sets GradientButton's iamge content X position from top-left corner when general alignment is none."), Category("GradientButton")]
        public Int32 ImageCornerX
        {
            get
            {
                return imageCornerX;
            }
            set
            {
                imageCornerX = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets GradientButton's iamge content Y position from top-left corner when general alignment is none.
        /// </summary>
        [Description("Gets or sets GradientButton's iamge content Y position from top-left corner when general alignment is none."), Category("GradientButton")]
        public Int32 ImageCornerY
        {
            get
            {
                return imageCornerY;
            }
            set
            {
                imageCornerY = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the vertical alignment of the GradientButton's image content.
        /// </summary>
        [Description("Gets or sets the vertical alignment of the GradientButton's image content."), Category("GradientButton")]
        public Alignment ImageAlignment
        {
            get
            {
                return imageAlignment;
            }
            set
            {
                imageAlignment = value;
                this.Invalidate();
            }

        }

        /// <summary>
        /// Gets or sets GradientButton's text content X position from top-left corner when general alignment is none.
        /// </summary>
        [Description("Gets or sets GradientButton's text content X position from top-left corner when general alignment is none."), Category("GradientButton")]
        public float TextX
        {
            get
            {
                return textX;
            }
            set
            {
                textX = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets GradientButton's text content Y position from top-left corner when general alignment is none.
        /// </summary>
        [Description("Gets or sets GradientButton's text content Y position from top-left corner when general alignment is none."), Category("GradientButton")]
        public float TextY
        {
            get
            {
                return textY;
            }
            set
            {
                textY = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the vertical alignment of the GradientButton's text content.
        /// </summary>
        [Description("Gets or sets the vertical alignment of the GradientButton's text content."), Category("GradientButton")]
        public Alignment TextAlignment
        {
            get
            {
                return textAlignment;
            }
            set
            {
                textAlignment = value;
                this.Invalidate();
            }

        }

        /// <summary>
        /// Enable/Disable GradientButton control.
        /// </summary>
        [Description("Enable/Disable GradientButton control."), Category("GradientButton")]
        public bool Active
        {
            get
            {
                return _Active;
            }
            set
            {
                _Active = value;
                this.Invalidate();
            }
        }


        /// <summary>
        /// To make sure the control is invalidated(repainted) when the text is changed
        /// </summary>
        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = value;
                this.Invalidate();
            }
        }

        #endregion

        #region OnPaint
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            LinearGradientBrush brush;
            LinearGradientMode mode;

            #region set SmoothingMode,LinearGradientMode,ImageAligment and TextAligment
            //
            // set SmoothingMode
            //
            switch (smoothingQuality)
            {
                case SmoothingQualities.None:
                    e.Graphics.SmoothingMode = SmoothingMode.Default;
                    break;
                case SmoothingQualities.HighSpeed:
                    e.Graphics.SmoothingMode = SmoothingMode.HighSpeed;
                    break;
                case SmoothingQualities.AntiAlias:
                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    break;
                case SmoothingQualities.HighQuality:
                    e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
                    break;
            }

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

            //
            // set ImageAligment
            //
            try
            {
                switch (imageAlignment)
                {
                    case Alignment.None:
                        imageCornerX = ImageCornerX;
                        imageCornerY = ImageCornerY;
                        break;
                    case Alignment.TopCenter:
                        imageCornerX = (base.Size.Width / 2) - (image.Width / 2);
                        imageCornerY = 5;
                        break;
                    case Alignment.Center:
                        imageCornerX = (base.Size.Width / 2) - (image.Width / 2);
                        imageCornerY = (base.Size.Height / 2) - (image.Height / 2);
                        break;
                    case Alignment.BottomCenter:
                        imageCornerX = (base.Size.Width / 2) - (image.Width / 2);
                        imageCornerY = (base.Size.Height) - (image.Height - 5);
                        break;
                }
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show(ex.Message + 
                                "\n Please,first add an image,before set this Property");
            }

            //
            // set TextAligment
            //
            SizeF textSize = e.Graphics.MeasureString(this.Text, base.Font);
            switch (textAlignment)
            {
                case Alignment.None:
                    textX = TextX;
                    textY = TextY;
                    break;
                case Alignment.TopCenter:
                    textX = (base.Size.Width / 2) - (textSize.Width / 2);
                    textY = 5;
                    break;
                case Alignment.Center:
                    textX = (base.Size.Width / 2) - (textSize.Width / 2);
                    textY = (base.Size.Height / 2) - (textSize.Height / 2);
                    break;
                case Alignment.BottomCenter:
                    textX = (base.Size.Width / 2) - (textSize.Width / 2);
                    textY = (base.Size.Height) - (textSize.Height + 2);
                    break;
            }
            #endregion

            Rectangle newRect = new Rectangle(ClientRectangle.X + 1, ClientRectangle.Y + 1,
                                              ClientRectangle.Width - 3, ClientRectangle.Height - 3);
            GraphicsPath button = DrawRoundedRectangle(radius, newRect);
            Point imageCorner = new Point(imageCornerX, imageCornerY);

            #region set _States and ButtonStyles
            if (_Active)
            {
                switch (_State)
                {
                    #region Normal
                    case _States.Normal:
                        brush = new LinearGradientBrush(newRect, normalColorA, normalColorB, mode);
                        switch (buttonStyle)
                        {
                            case ButtonStyles.Rectangle:
                                e.Graphics.FillRectangle(brush, newRect);
                                e.Graphics.DrawRectangle(new Pen(normalBorderColor, 1), newRect);

                                break;
                            case ButtonStyles.Ellipse:
                                e.Graphics.FillEllipse(brush, newRect);
                                e.Graphics.DrawEllipse(new Pen(normalBorderColor, 1), newRect);

                                break;
                            case ButtonStyles.RoundedEdgesRectangel:
                                e.Graphics.FillPath(brush, button);
                                e.Graphics.DrawPath(new Pen(normalBorderColor, borderWidth), button);
                                if (image == null)
                                {
                                    imageAlignment = Alignment.None;
                                    break;
                                }
                                else
                                {
                                    e.Graphics.DrawImage(image, imageCorner);
                                }
                                //e.Graphics.DrawImageUnscaled(_Image, imageCorner);
                                break;

                        }
                        e.Graphics.DrawString(this.Text, base.Font, new SolidBrush(base.ForeColor), textX, textY);

                        break;
                    #endregion

                    #region MouseOver
                    case _States.MouseOver:
                        brush = new LinearGradientBrush(newRect, hoverColorA, hoverColorB, mode);
                        switch (buttonStyle)
                        {
                            case ButtonStyles.Rectangle:
                                e.Graphics.FillRectangle(brush, newRect);
                                e.Graphics.DrawRectangle(new Pen(hoverBorderColor, 1), newRect);
                                break;
                            case ButtonStyles.Ellipse:
                                e.Graphics.FillEllipse(brush, newRect);
                                e.Graphics.DrawEllipse(new Pen(hoverBorderColor, 1), newRect);
                                break;
                            case ButtonStyles.RoundedEdgesRectangel:
                                e.Graphics.FillPath(brush, button);
                                e.Graphics.DrawPath(new Pen(hoverBorderColor, borderWidth + 1), button);
                                if (image == null)
                                {
                                    imageAlignment = Alignment.None;
                                    break;
                                }
                                else
                                {
                                    e.Graphics.DrawImage(image, imageCorner);
                                }
                                break;
                        }
                        e.Graphics.DrawString(this.Text, base.Font, new SolidBrush(base.ForeColor), textX, textY);
                        break;
                    #endregion

                    #region Clicked
                    case _States.Clicked:
                        brush = new LinearGradientBrush(newRect, clickColorA, clickColorB, mode);
                        switch (buttonStyle)
                        {
                            case ButtonStyles.Rectangle:
                                e.Graphics.FillRectangle(brush, newRect);
                                e.Graphics.DrawRectangle(new Pen(clickBorderColor, 2), newRect);
                                break;
                            case ButtonStyles.Ellipse:
                                e.Graphics.FillEllipse(brush, newRect);
                                e.Graphics.DrawEllipse(new Pen(clickBorderColor, 2), newRect);
                                break;
                            case ButtonStyles.RoundedEdgesRectangel:
                                e.Graphics.FillPath(brush, button);
                                e.Graphics.DrawPath(new Pen(clickBorderColor, borderWidth + 2), button);
                                if (image == null)
                                {
                                    imageAlignment = Alignment.None;
                                    break;
                                }
                                else
                                {
                                    e.Graphics.DrawImage(image, imageCorner);
                                }
                                break;
                        }
                        e.Graphics.DrawString(this.Text, base.Font, new SolidBrush(hoverBorderColor), textX, textY);
                        break;
                    #endregion
                }
            }
            else
            {
                brush = new LinearGradientBrush(newRect, clickColorA, clickColorB, mode);
                switch (buttonStyle)
                {
                    case ButtonStyles.Rectangle:
                        e.Graphics.FillRectangle(brush, newRect);
                        e.Graphics.DrawRectangle(new Pen(normalBorderColor, 1), newRect);
                        break;
                    case ButtonStyles.Ellipse:
                        e.Graphics.FillEllipse(brush, newRect);
                        e.Graphics.DrawEllipse(new Pen(normalBorderColor, 1), newRect);
                        break;
                    case ButtonStyles.RoundedEdgesRectangel:
                        e.Graphics.FillPath(brush, button);
                        e.Graphics.DrawPath(new Pen(clickBorderColor, borderWidth + 2), button);
                        if (image == null)
                        {
                            imageAlignment = Alignment.None;
                            e.Graphics.DrawString(this.Text, base.Font, new SolidBrush(hoverBorderColor), textX, textY);
                            break;
                        }
                        else
                        {
                            e.Graphics.DrawImage(image, imageCorner);
                        }
                        e.Graphics.DrawString(this.Text, base.Font, new SolidBrush(hoverBorderColor), textX, textY);
                        break;
                }
            }
            #endregion
        }
        #endregion

        #region Override mouse events
        /// <summary>
        /// Raises the MouseLeave event.
        /// </summary>
        protected override void OnMouseLeave(System.EventArgs e)
        {
            if (_Active)
            {
                _State = _States.Normal;
                this.Invalidate();
                base.OnMouseLeave(e);
            }
            else
            {
                _State = _States.Normal;
                this.Invalidate();
                base.OnMouseLeave(e);
            }
        }

        /// <summary>
        /// Raises the MouseEnter event.
        /// </summary>
        protected override void OnMouseEnter(System.EventArgs e)
        {
            if (_Active)
            {
                _State = _States.MouseOver;
                this.Invalidate();
            }
        }
        /// <summary>
        /// Raises the MouseDown event.
        /// </summary>
        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
        {
            if (_Active)
            {
                _State = _States.Clicked;
                this.Invalidate();
                base.OnMouseDown(e);
            }
        }
        /// <summary>
        /// Raises the OnClick event. 
        /// </summary>
        protected override void OnClick(System.EventArgs e)
        {
            // prevent click when button is inactive
            if (_Active)
            {
                if (_State == _States.Clicked)
                {
                    base.OnClick(e);
                }
            }
        }

        #endregion

        #region Methods
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
        #endregion
    }

    ///// <summary>
    ///// Specifies whether smoothing (antialiasing) is applied to lines and curves and the edges of filled areas.
    ///// <list type="bullet">
    ///// <item>
    ///// <term>None</term>
    ///// <description>Specifies no antialiasing.</description>
    ///// </item>
    ///// <item>
    ///// <term>HighSpeed</term>
    ///// <description><span>HighSpeedSPAN</span>>Specifies no antialiasing.</description>
    ///// </item>
    ///// <item>
    ///// <term>AntiAlias</term>
    ///// <description> Specifies antialiased rendering.</description>
    ///// </item>
    ///// <item>
    ///// <term>HighQuality</term>
    ///// <description>Specifies antialiased rendering.</description>
    ///// </item>
    ///// </list>
    ///// </summary>

    ///// <summary>
    ///// Gets or sets the rendering quality for this Graphics. The available actions are:
    ///// <list type="bullet">
    ///// <item>
    ///// <term>None</term>
    ///// <description>Gets or sets the SmoothingMode property to none.</description>
    ///// </item>
    ///// <item>
    ///// <term>HighSpeed</term>
    ///// <description>Gets or sets the SmoothingMode property to smooth the line.</description>
    ///// </item>
    ///// <item>
    ///// <term>AntiAlias</term>
    ///// <description> Gets or sets the SmoothingMode property to smooth the line.</description>
    ///// </item>
    ///// <item>
    ///// <term>HighQuality</term>
    ///// <description>Gets or sets the SmoothingMode property to smooth the line.</description>
    ///// </item>
    ///// </list>
    ///// </summary>
}
