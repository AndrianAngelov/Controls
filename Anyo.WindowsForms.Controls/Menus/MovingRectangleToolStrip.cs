namespace Anyo.WindowsForms.Controls.Menus
{
    using System;
    using System.Windows.Forms;
    using System.Drawing;
    using System.ComponentModel;
    using Anyo.WindowsForms.Controls.Menus.ToolStripRenderers;

    /// <remarks>Here's a VisualStudio designer and property window view of MovingRectangleToolStrip control: <br />
    /// <img src="../Images/MovingRectangleMenu_Hover.png" />
    /// <img src="../Images/MovingRectangleSubMenu_Hover.png" />
    /// <img src="../Images/MovingRectangleToolStripProperties.jpg" />
    /// </remarks>
    public partial class MovingRectangleToolStrip : ToolStrip
    {
        private MovingRectangleSelectorRenderer myToolStripRenderer;

        /// <summary>
        /// 
        /// </summary>
        public MovingRectangleToolStrip()
        {
            InitializeComponent();
            
            myToolStripRenderer = new MovingRectangleSelectorRenderer();

            myToolStripRenderer.MainMenuButtonHeaderColor_NormalHover = SystemColors.Control;
            myToolStripRenderer.MainMenuButtonHeaderColor_Clicked = Color.DarkOrange;

            myToolStripRenderer.MainMenuButtonBodyColor_NormalHover = SystemColors.Control;
            myToolStripRenderer.MainMenuButtonBodyColor_Clicked = SystemColors.Control;

            myToolStripRenderer.MainMenuButtonFooterColor_Normal = SystemColors.Control;
            myToolStripRenderer.MainMenuButtonFooterColor_Hover = Color.DarkOrange;
            myToolStripRenderer.MainMenuButtonFooterColor_Clicked = SystemColors.Control;
            
            myToolStripRenderer.MainMenuTextColor_Normal = Color.White;
            myToolStripRenderer.MainMenuTextColor_Hover = Color.White;
            myToolStripRenderer.MainMenuTextColor_Clicked = Color.Black;

            myToolStripRenderer.BackgroundToolStripColor = Color.SlateGray;

            myToolStripRenderer.MenuItemsBackgroundTopColor = Color.DarkOrange;
            myToolStripRenderer.MenuItemsBackgroundBottomColor = Color.DarkGoldenrod;
            myToolStripRenderer.MenuItemsContentBorderColor = Color.Cornsilk;
            myToolStripRenderer.MenuItemsTextColor_Normal = Color.Black;
            myToolStripRenderer.MenuItemsTextColor_HoverClicked = Color.White;

            this.Renderer = myToolStripRenderer;
            this.Dock = DockStyle.None;
        }

        /// <summary>
        /// Gets or sets the color of drop down button's header in main menu in normal and hover state.
        /// </summary>
        [Description("Gets or sets the color of drop down button's header in main menu in normal and hover state."),
         Category("MovingRectangleAppearance")]
        public Color MainMenuButtonHeaderColor_NormalHover
        {
            get { return this.myToolStripRenderer.MainMenuButtonHeaderColor_NormalHover; }
            set { this.myToolStripRenderer.MainMenuButtonHeaderColor_NormalHover = value; }
        }

        /// <summary>
        /// Gets or sets the color of drop down button's header in main menu when button is clicked.
        /// </summary>
        [Description("Gets or sets the color of drop down button's header in main menu when button is clicked. "), Category("MovingRectangleAppearance")]
        public Color MainMenuButtonHeaderColor_Clicked
        {
            get { return this.myToolStripRenderer.MainMenuButtonHeaderColor_Clicked; }
            set { this.myToolStripRenderer.MainMenuButtonHeaderColor_Clicked = value; }
        }

        /// <summary>
        /// Gets or sets the color of drop down button's body in main menu in normal and hover state.
        /// </summary>
        [Description("Gets or sets the color of drop down button's body in main menu in normal and hover state."), Category("MovingRectangleAppearance")]
        public Color MainMenuButtonBodyColor_NormalHover
        {
            get { return this.myToolStripRenderer.MainMenuButtonBodyColor_NormalHover; }
            set { this.myToolStripRenderer.MainMenuButtonBodyColor_NormalHover = value; }
        }


        /// <summary>
        /// Gets or sets the color of drop down button's body in main menu when button is clicked.
        /// </summary>
        [Description("Gets or sets the color of drop down button's body in main menu when button is clicked."), Category("MovingRectangleAppearance")]
        public Color MainMenuButtonBodyColor_Clicked
        {
            get { return this.myToolStripRenderer.MainMenuButtonBodyColor_Clicked; }
            set { this.myToolStripRenderer.MainMenuButtonBodyColor_Clicked = value; }
        }

        /// <summary>
        /// Gets or sets the color of drop down button's footer in main menu in normal state.
        /// </summary>
        [Description("Gets or sets the color of drop down button's footer in main menu in normal state."),Category("MovingRectangleAppearance")]
        public Color MainMenuButtonFooterColor_Normal
        {
            get { return this.myToolStripRenderer.MainMenuButtonFooterColor_Normal; }
            set { this.myToolStripRenderer.MainMenuButtonFooterColor_Normal = value; }
        }

        /// <summary>
        /// Gets or sets the color of drop down button's footer in main menu in hover state.
        /// </summary>
        [Description("Gets or sets the color of drop down button's footer in main menu in hover state."), Category("MovingRectangleAppearance")]
        public Color MainMenuButtonFooterColor_Hover
        {
            get { return this.myToolStripRenderer.MainMenuButtonFooterColor_Hover; }
            set { this.myToolStripRenderer.MainMenuButtonFooterColor_Hover = value; }
        }

        /// <summary>
        /// Gets or sets the color of drop down button's footer in main menu when button is clicked.
        /// </summary>
        [Description("Gets or sets the color of drop down button's footer in main menu when button is clicked."), Category("MovingRectangleAppearance")]
        public Color MainMenuButtonFooterColor_Clicked
        {
            get { return this.myToolStripRenderer.MainMenuButtonFooterColor_Clicked; }
            set { this.myToolStripRenderer.MainMenuButtonFooterColor_Clicked = value; }
        }

        /// <summary>
        /// Gets or sets the fore color of text in main menu when drop down button is in normal state.
        /// </summary>
        [Description("Gets or sets the fore color of text in main menu when drop down button is in normal state."), Category("MovingRectangleAppearance")]
        public Color MainMenuTextColor_Normal
        {
            get { return this.myToolStripRenderer.MainMenuTextColor_Normal; }
            set { this.myToolStripRenderer.MainMenuTextColor_Normal = value; }
        }

        /// <summary>
        /// Gets or sets the fore color of text in main menu when drop down button is in hover state.
        /// </summary>
        [Description("Gets or sets the fore color of text in main menu when drop down button is in hover state."), Category("MovingRectangleAppearance")]
        public Color MainMenuTextColor_Hover
        {
            get { return this.myToolStripRenderer.MainMenuTextColor_Hover; }
            set { this.myToolStripRenderer.MainMenuTextColor_Hover = value; }
        }

        /// <summary>
        /// Gets or sets the fore color of text in main menu when drop down button is clicked.
        /// </summary>
        [Description("Gets or sets the fore color of text in main menu when drop down button is clicked."), Category("MovingRectangleAppearance")]
        public Color MainMenuTextColor_Clicked
        {
            get { return this.myToolStripRenderer.MainMenuTextColor_Clicked; }
            set { this.myToolStripRenderer.MainMenuTextColor_Clicked = value; }
        }

        /// <summary>
        /// Gets or sets the color of ToolStrip background.
        /// </summary>
        [Description("Gets or sets the color of ToolStrip background."), Category("MovingRectangleAppearance")]
        public Color BackgroundToolStripColor
        {
            get { return this.myToolStripRenderer.BackgroundToolStripColor; }
            set { this.myToolStripRenderer.BackgroundToolStripColor = value; }
        }

        /// <summary>
        /// Gets or sets the top color of menu items content gradient background.
        /// </summary>
        [Description("Gets or sets the top color of menu items content gradient background."), Category("MovingRectangleAppearance")]
        public Color MenuItemsBackgroundTopColor
        {
            get { return this.myToolStripRenderer.MenuItemsBackgroundTopColor; }
            set { this.myToolStripRenderer.MenuItemsBackgroundTopColor = value; }
        }

        /// <summary>
        /// Gets or sets the bottom color of menu items content gradient background.
        /// </summary>
        [Description("Gets or sets the bottom color of menu items content gradient background."), Category("MovingRectangleAppearance")]
        public Color MenuItemsBackgroundBottomColor
        {
            get { return this.myToolStripRenderer.MenuItemsBackgroundBottomColor; }
            set { this.myToolStripRenderer.MenuItemsBackgroundBottomColor = value; }
        }

        /// <summary>
        /// Gets or sets the border color of menu items content gradient background.
        /// </summary>
        [Description("Gets or sets the border color of menu items content gradient background."), Category("MovingRectangleAppearance")]
        public Color MenuItemsContentBorderColor
        {
            get { return this.myToolStripRenderer.MenuItemsContentBorderColor; }
            set { this.myToolStripRenderer.MenuItemsContentBorderColor = value; }
        }

        /// <summary>
        /// Gets or sets text fore color of menu items in normal state.
        /// </summary>
        [Description("Gets or sets text fore color of menu items in normal state."), Category("MovingRectangleAppearance")]
        public Color MenuItemsTextColor_Normal
        {
            get { return this.myToolStripRenderer.MenuItemsTextColor_Normal; }
            set { this.myToolStripRenderer.MenuItemsTextColor_Normal = value; }
        }

        /// <summary>
        /// Gets or sets text fore color of menu items in hover and clicked state.
        /// </summary>
        [Description("Gets or sets text fore color of menu items in hover and clicked state."), Category("MovingRectangleAppearance")]
        public Color MenuItemsTextColor_HoverClicked
        {
            get { return this.myToolStripRenderer.MenuItemsTextColor_HoverClicked; }
            set { this.myToolStripRenderer.MenuItemsTextColor_HoverClicked = value; }
        }


        private void MovingRectangleToolStrip_ItemAdded(object sender, ToolStripItemEventArgs e)
        {
            //!=1 because this event rise from ToolStripControlHost first
            if (this.Items.Count != 1 && (e.Item is ToolStripDropDownButton))
            {
                e.Item.Margin = new Padding(0, 1, 10, 2);
                this.AutoSize = false;
                e.Item.AutoSize = false;
                this.Width = this.Width + 170;
                this.Height = 70;
            }
        }
    }
}
