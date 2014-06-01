namespace Anyo.WindowsForms.Controls.Menus.ToolStripRenderers
{
    using System;
    using System.Windows.Forms;
    using System.Drawing;
    using System.Drawing.Drawing2D;

    /// <summary>
    /// This class used to customize the look and feel of a ToolStrip and controls that inherit ToolStrip control.
    /// </summary>
    /// <example>
    /// <img src="../Images/MovingRectangleMenu_Hover.png" />
    /// <img src="../Images/MovingRectangleSubMenu_Hover.png" />
    /// <code>
    /// using Anyo.WindowsForms.Controls.Menus.ToolStripRenderers;
    /// 
    /// public TestForm()
    /// {
    ///     InitializeComponent();
    ///     
    ///     MovingRectangleSelectorRenderer customRenderer = new MovingRectangleSelectorRenderer();
    ///
    ///     customRenderer.MainMenuButtonHeaderColor_NormalHover = SystemColors.Control;
    ///     customRenderer.MainMenuButtonHeaderColor_Clicked = Color.DarkOrange;
    ///
    ///     customRenderer.MainMenuButtonBodyColor_NormalHover = SystemColors.Control;
    ///     customRenderer.MainMenuButtonBodyColor_Clicked = SystemColors.Control;
    ///
    ///     customRenderer.MainMenuButtonFooterColor_Normal = SystemColors.ButtonShadow;
    ///     customRenderer.MainMenuButtonFooterColor_Hover = Color.DarkOrange;
    ///     customRenderer.MainMenuButtonFooterColor_Clicked = SystemColors.Control;
    ///
    ///     customRenderer.MainMenuTextColor_Normal = Color.Black;
    ///     customRenderer.MainMenuTextColor_Hover = Color.Black;
    ///     customRenderer.MainMenuTextColor_Clicked = Color.Black;
    ///
    ///     customRenderer.BackgroundToolStripColor = Color.White;
    ///
    ///     customRenderer.MenuItemsBackgroundTopColor = Color.DarkOrange;
    ///     customRenderer.MenuItemsBackgroundBottomColor = Color.DarkGoldenrod;
    ///     customRenderer.MenuItemsContentBorderColor = Color.Cornsilk;
    ///     customRenderer.MenuItemsTextColor_Normal = Color.Black;
    ///     customRenderer.MenuItemsTextColor_HoverClicked = Color.White;
    ///
    ///     toolStrip1.Renderer = customRenderer;
    /// }
    /// </code> 
    /// </example>
    public class MovingRectangleSelectorRenderer : ToolStripRenderer
    {
        #region Fields
        private Color mainMenuButtonHeaderColor_NormalHover;
        private Color mainMenuButtonHeaderColor_Clicked;

        private Color mainMenuButtonBodyColor_NormalHover;
        private Color mainMenuButtonBodyColor_Clicked;

        private Color mainMenuButtonFooterColor_Normal;
        private Color mainMenuButtonFooterColor_Hover;
        private Color mainMenuButtonFooterColor_Clicked;

        private Color mainMenuTextColor_Normal;
        private Color mainMenuTextColor_Hover;
        private Color mainMenuTextColor_Clicked;

        private Color backgroundColor;

        private Color menuItemsBackgroundTopColor;
        private Color menuItemsBackgroundBottomColor;
        private Color menuItemsContentBorderColor;
        private Color menuItemsTextColor_Normal;
        private Color menuItemsTextColor_HoverClicked;
        #endregion

        /// <summary>
        /// 
        /// </summary>
        public MovingRectangleSelectorRenderer() 
        {

        }

        #region Properties
        /// <summary>
        /// Gets or sets the color of drop down button's header in main menu in normal and hover state.
        /// </summary>
        public Color MainMenuButtonHeaderColor_NormalHover
        {
            get { return this.mainMenuButtonHeaderColor_NormalHover; }
            set { this.mainMenuButtonHeaderColor_NormalHover = value; }
        }

        /// <summary>
        /// Gets or sets the color of drop down button's header in main menu when button is clicked.
        /// </summary>
        public Color MainMenuButtonHeaderColor_Clicked
        {
            get { return this.mainMenuButtonHeaderColor_Clicked; }
            set { this.mainMenuButtonHeaderColor_Clicked = value; }
        }

        /// <summary>
        /// Gets or sets the color of drop down button's body in main menu in normal and hover state.
        /// </summary>
        public Color MainMenuButtonBodyColor_NormalHover
        {
            get { return this.mainMenuButtonBodyColor_NormalHover; }
            set { this.mainMenuButtonBodyColor_NormalHover = value; }
        }

        /// <summary>
        /// Gets or sets the color of drop down button's body in main menu when button is clicked.
        /// </summary>
        public Color MainMenuButtonBodyColor_Clicked
        {
            get { return this.mainMenuButtonBodyColor_Clicked; }
            set { this.mainMenuButtonBodyColor_Clicked = value; }
        }

        /// <summary>
        /// Gets or sets the color of drop down button's footer in main menu in normal state.
        /// </summary>
        public Color MainMenuButtonFooterColor_Normal
        {
            get { return this.mainMenuButtonFooterColor_Normal; }
            set { this.mainMenuButtonFooterColor_Normal = value; }
        }

        /// <summary>
        /// Gets or sets the color of drop down button's footer in main menu in hover state.
        /// </summary>
        public Color MainMenuButtonFooterColor_Hover
        {
            get { return this.mainMenuButtonFooterColor_Hover; }
            set { this.mainMenuButtonFooterColor_Hover = value; }
        }

        /// <summary>
        /// Gets or sets the color of drop down button's footer in main menu when button is clicked.
        /// </summary>
        public Color MainMenuButtonFooterColor_Clicked
        {
            get { return this.mainMenuButtonFooterColor_Clicked; }
            set { this.mainMenuButtonFooterColor_Clicked = value; }
        }

        /// <summary>
        /// Gets or sets the fore color of text in main menu when drop down button is in normal state.
        /// </summary>
        public Color MainMenuTextColor_Normal
        {
            get { return this.mainMenuTextColor_Normal; }
            set { this.mainMenuTextColor_Normal = value; }
        }

        /// <summary>
        /// Gets or sets the fore color of text in main menu when drop down button is in hover state.
        /// </summary>
        public Color MainMenuTextColor_Hover
        {
            get { return this.mainMenuTextColor_Hover; }
            set { this.mainMenuTextColor_Hover = value; }
        }

        /// <summary>
        /// Gets or sets the fore color of text in main menu when drop down button is clicked.
        /// </summary>
        public Color MainMenuTextColor_Clicked
        {
            get { return this.mainMenuTextColor_Clicked; }
            set { this.mainMenuTextColor_Clicked = value; }
        }

        /// <summary>
        /// Gets or sets the color of ToolStrip background.
        /// </summary>
        public Color BackgroundToolStripColor
        {
            get { return this.backgroundColor; }
            set { this.backgroundColor = value; }
        }

        /// <summary>
        /// Gets or sets the top color of menu items content gradient background.
        /// </summary>
        public Color MenuItemsBackgroundTopColor
        {
            get { return this.menuItemsBackgroundTopColor; }
            set { this.menuItemsBackgroundTopColor = value; }
        }

        /// <summary>
        /// Gets or sets the bottom color of menu items content gradient background.
        /// </summary>
        public Color MenuItemsBackgroundBottomColor
        {
            get { return this.menuItemsBackgroundBottomColor; }
            set { this.menuItemsBackgroundBottomColor = value; }
        }

        /// <summary>
        /// Gets or sets the border color of menu items content gradient background.
        /// </summary>
        public Color MenuItemsContentBorderColor
        {
            get { return this.menuItemsContentBorderColor; }
            set { this.menuItemsContentBorderColor = value; }
        }

        /// <summary>
        /// Gets or sets text fore color of menu items in normal state.
        /// </summary>
        public Color MenuItemsTextColor_Normal
        {
            get { return this.menuItemsTextColor_Normal; }
            set { this.menuItemsTextColor_Normal = value; }
        }

        /// <summary>
        /// Gets or sets text fore color of menu items in hover and clicked state.
        /// </summary>
        public Color MenuItemsTextColor_HoverClicked
        {
            get { return this.menuItemsTextColor_HoverClicked; }
            set { this.menuItemsTextColor_HoverClicked = value; }
        }
        #endregion

        #region Events overrides
        /// <summary>
        /// DropDownButtons's appearance
        /// </summary>
        protected override void OnRenderDropDownButtonBackground(ToolStripItemRenderEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality;

            SolidBrush headerBrush;
            SolidBrush bodyBrush;
            SolidBrush footerBrush;
            SolidBrush dropDownArrowBrush;

            Rectangle headerRectangle = new Rectangle(new Point(e.Item.ContentRectangle.X, e.Item.ContentRectangle.Y), new Size(e.Item.Size.Width, e.Item.ContentRectangle.Y + 3));
            Rectangle bodyRectangle = new Rectangle(new Point(e.Item.ContentRectangle.X, e.Item.ContentRectangle.Y), new Size(e.Item.Size.Width, e.Item.Size.Height - 3));
            Rectangle footerRectangle = new Rectangle(new Point(e.Item.ContentRectangle.X, e.Item.Size.Height - 5), new Size(e.Item.Size.Width, e.Item.Size.Height - 3));

            Point[] dropDownArrow = new Point[]
                { 
                  new Point(e.Item.Size.Width/2 , e.Item.Size.Height - 16),
                  new Point(e.Item.Size.Width/2 +6  , e.Item.Size.Height - 16),
                  new Point(e.Item.Size.Width/2 +3  , e.Item.Size.Height - 9)
                };

            #region Normal
            if (!e.Item.Pressed && !e.Item.Selected)
            {
                //using (LinearGradientBrush footerGradient = new LinearGradientBrush(footerRectangle, SystemColors.Control, SystemColors.Control, LinearGradientMode.Vertical))
                using (footerBrush = new SolidBrush(this.MainMenuButtonFooterColor_Normal))
                {
                    g.FillRectangle(footerBrush, footerRectangle);
                    g.FillPolygon(footerBrush, dropDownArrow, FillMode.Alternate);
                }
                e.Item.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
                e.Item.ForeColor = this.MainMenuTextColor_Normal;
            }
            #endregion

            #region Hover
            if (e.Item.Selected && !e.Item.Pressed)
            {
                //using (LinearGradientBrush footerGradient = new LinearGradientBrush(footerRectangle, Color.DarkOrange, Color.DarkGoldenrod, LinearGradientMode.Vertical))
                using (footerBrush = new SolidBrush(this.MainMenuButtonFooterColor_Hover))
                {
                    g.FillRectangle(footerBrush, footerRectangle);
                }
                using (dropDownArrowBrush = new SolidBrush(this.MainMenuButtonFooterColor_Normal))
                {
                    g.FillPolygon(dropDownArrowBrush, dropDownArrow, FillMode.Alternate);
                }
                //e.Item.Font = new Font("Tahoma", 8.25f, FontStyle.Bold,GraphicsUnit.Point);
                e.Item.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
                e.Item.ForeColor = this.MainMenuTextColor_Hover;
            }
            #endregion

            #region Clicked
            if (e.Item.Pressed)
            {
                //using (LinearGradientBrush bodyGradient = new LinearGradientBrush(bodyRectangle, SystemColors.Control, SystemColors.Control, LinearGradientMode.Vertical))
                using (bodyBrush = new SolidBrush(this.MainMenuButtonBodyColor_Clicked))
                {
                    g.FillRectangle(bodyBrush, bodyRectangle);
                }

                //using (LinearGradientBrush headerGradient = new LinearGradientBrush(bodyRectangle, Color.DarkOrange, Color.DarkGoldenrod, LinearGradientMode.Vertical))
                using (headerBrush = new SolidBrush(this.MainMenuButtonHeaderColor_Clicked))
                {
                    g.FillRectangle(headerBrush, headerRectangle);
                }

                using (dropDownArrowBrush = new SolidBrush(this.BackgroundToolStripColor))
                {
                    g.FillPolygon(dropDownArrowBrush, dropDownArrow, FillMode.Alternate);
                }

                e.Item.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
                e.Item.ForeColor = this.MainMenuTextColor_Clicked;
            }
            #endregion
        }

        /// <summary>
        /// This method renders the MovingRectangleToolsStrip control's background.
        /// </summary>
        protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality;
            Pen pen;

            //This is the line that passes through the footerRectangle of all items
            using (pen = new Pen(this.MainMenuButtonFooterColor_Normal, 1))
            {
                g.DrawLine(pen, new Point(e.AffectedBounds.X + 20, e.AffectedBounds.Height - 5),
                                new Point(e.AffectedBounds.Width - 200, e.AffectedBounds.Height - 5));
            }

            //This is the line that passes through between the main menu and all menu items
            //it is just like separator 
            using (pen = new Pen(this.BackgroundToolStripColor, 1))
            {
                g.DrawLine(pen, new Point(e.ConnectedArea.X, e.ConnectedArea.Y),
                                new Point(e.ConnectedArea.X + e.ToolStrip.Width, e.ConnectedArea.Y));
            }
        }

        /// <summary>
        /// Dropdown menu items's content background
        /// </summary>
        protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
        {
            base.OnRenderMenuItemBackground(e);

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality;

            if (e.Item.Selected || e.Item.Pressed)
            {
                using (LinearGradientBrush selectedDropDownItem = new LinearGradientBrush(e.Item.ContentRectangle,
                                                                                          this.MenuItemsBackgroundTopColor,
                                                                                          this.MenuItemsBackgroundBottomColor,
                                                                                          LinearGradientMode.Vertical))
                {
                    e.Item.ForeColor = this.MenuItemsTextColor_HoverClicked;
                    g.FillRectangle(selectedDropDownItem, e.Item.ContentRectangle);
                    g.DrawRectangle(new Pen(this.MenuItemsContentBorderColor, 1), e.Item.ContentRectangle);
                }
            }
            else
            {
                e.Item.ForeColor = this.MenuItemsTextColor_Normal;
            }
        }

        /// <summary>
        /// Dropdown menus left vertical separator
        /// </summary>
        /// <param name="e"></param>
        protected override void OnRenderImageMargin(ToolStripRenderEventArgs e)
        {
            base.OnRenderImageMargin(e);

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality;

            Rectangle rec = new Rectangle(new Point(e.AffectedBounds.X, e.AffectedBounds.Y), new Size(e.AffectedBounds.X + 1, e.AffectedBounds.Height));
            g.FillRectangle(new SolidBrush(this.BackgroundToolStripColor), rec);
        }

        /// <summary>
        /// Dropdown menu items's arrow
        /// </summary>
        /// <param name="e"></param>
        protected override void OnRenderArrow(ToolStripArrowRenderEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality;

            Point[] menuItemsArrow = new Point[]
            {
                new Point(e.Item.ContentRectangle.Width - 12, e.Item.ContentRectangle.Height/2+3),
                new Point(e.Item.ContentRectangle.Width - 5, e.Item.ContentRectangle.Height/2),
                new Point(e.Item.ContentRectangle.Width - 12, e.Item.ContentRectangle.Height/2-3)
            };

            if (e.Item.IsOnDropDown)
            {
                if (e.Item.Selected || e.Item.Pressed)
                {
                    g.FillPolygon(new SolidBrush(this.MenuItemsTextColor_HoverClicked), menuItemsArrow, FillMode.Alternate);
                }

                if (!e.Item.Pressed && !e.Item.Selected)
                {
                    g.FillPolygon(new SolidBrush(this.BackgroundToolStripColor), menuItemsArrow, FillMode.Alternate);
                }

            }
        }
        #endregion
    }
}
