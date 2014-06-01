using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Anyo.WindowsForms.Controls.Buttons;
using Anyo.WindowsForms.Controls.Navigations;
using Anyo.WindowsForms.Controls.DataGridViewHeaderPainting;
using Anyo.WindowsForms.Controls.Menus.ToolStripRenderers;

namespace TestingControls
{
    public partial class TestForm : Form
    {
        public TestForm()
        {
            InitializeComponent();

            MovingRectangleSelectorRenderer customRenderer = new MovingRectangleSelectorRenderer();

            //customRenderer.MainMenuButtonHeaderColor_NormalHover = SystemColors.Control;
            //customRenderer.MainMenuButtonHeaderColor_Clicked = Color.DarkOrange;

            //customRenderer.MainMenuButtonBodyColor_NormalHover = SystemColors.Control;
            //customRenderer.MainMenuButtonBodyColor_Clicked = SystemColors.Control;

            //customRenderer.MainMenuButtonFooterColor_Normal = SystemColors.Control;
            //customRenderer.MainMenuButtonFooterColor_Hover = Color.DarkOrange;
            //customRenderer.MainMenuButtonFooterColor_Clicked = SystemColors.Control;

            //customRenderer.MainMenuTextColor_Normal = Color.White;
            //customRenderer.MainMenuTextColor_Hover = Color.White;
            //customRenderer.MainMenuTextColor_Clicked = Color.Black;

            //customRenderer.BackgroundToolStripColor = Color.SlateGray;

            //customRenderer.MenuItemsBackgroundTopColor = Color.DarkOrange;
            //customRenderer.MenuItemsBackgroundBottomColor = Color.DarkGoldenrod;
            //customRenderer.MenuItemsContentBorderColor = Color.Cornsilk;
            //customRenderer.MenuItemsTextColor_Normal = Color.Black;
            //customRenderer.MenuItemsTextColor_HoverClicked = Color.White;

            customRenderer.MainMenuButtonHeaderColor_NormalHover = SystemColors.Control;
            customRenderer.MainMenuButtonHeaderColor_Clicked = Color.DarkOrange;

            customRenderer.MainMenuButtonBodyColor_NormalHover = SystemColors.Control;
            customRenderer.MainMenuButtonBodyColor_Clicked = SystemColors.Control;

            customRenderer.MainMenuButtonFooterColor_Normal = SystemColors.ButtonShadow;
            customRenderer.MainMenuButtonFooterColor_Hover = Color.DarkOrange;
            customRenderer.MainMenuButtonFooterColor_Clicked = SystemColors.Control;

            customRenderer.MainMenuTextColor_Normal = Color.Black;
            customRenderer.MainMenuTextColor_Hover = Color.Black;
            customRenderer.MainMenuTextColor_Clicked = Color.Black;

            customRenderer.BackgroundToolStripColor = Color.White;

            customRenderer.MenuItemsBackgroundTopColor = Color.DarkOrange;
            customRenderer.MenuItemsBackgroundBottomColor = Color.DarkGoldenrod;
            customRenderer.MenuItemsContentBorderColor = Color.Cornsilk;
            customRenderer.MenuItemsTextColor_Normal = Color.Black;
            customRenderer.MenuItemsTextColor_HoverClicked = Color.White;

            toolStrip1.Renderer = customRenderer;

            OrangeGradientHeader header = new OrangeGradientHeader();
            header.Painter(dataGridView1);
            //this.toolStrip1.Renderer = new Anyo.WindowsForms.Controls.Menus.ToolStripRenderers.MovingRectangleSelectorRenderer();
            //gradientButton1.ImageAlignment = Anyo.WindowsForms.Controls.Buttons.GradientButton.Alignment.Center;

        }

        private void toolStripDropDownButton1_Click(object sender, EventArgs e)
        {

        }

        private void TestForm_Load(object sender, EventArgs e)
        {
            
            this.dataGridNavigation1.DataGridName = this.dataGridView1;

            //1)Directly access data from SQL Server databas
            this.dataGridNavigation1.PageSize = 10;
            this.dataGridNavigation1.ConnectionString = @"Server=21f9220a-bb75-4164-b8a6-a25000a4b2da.sqlserver.sequelizer.com;Database=db21f9220abb754164b8a6a25000a4b2da;User ID=pyouamqnnmgtfzpb;Password=ZB3Af4a2KkqRYru2dDQWuDCxKTXZHDcCKuNFDgSR6QmXm6QnivRQnXRu7DXuehrg;";
            this.dataGridNavigation1.CommandString = @"SELECT * FROM aspnet_Users";
            this.dataGridNavigation1.FillDataGridWithRecords(DataGridNavigation.Display.FirstPage);

            //2)From already filled DataTable object
            DataTable dt = GetTable();
            this.dataGridNavigation1.PageSize = 10;
            this.dataGridNavigation1.AllPages = dt;
            this.dataGridNavigation1.FillDataGridWithRecords(DataGridNavigation.Display.FirstPage);
        }
        static DataTable GetTable()
        {
            //
            // Here we create a DataTable with four columns.
            //
            DataTable table = new DataTable();
            table.Columns.Add("Product", typeof(string));
            table.Columns.Add("Category", typeof(string));
            table.Columns.Add("Vendor", typeof(string));
            table.Columns.Add("Date", typeof(DateTime));

            //
            // Here we add five DataRows.
            //
            table.Rows.Add("Apples", "Food", "Fruits Inc.", DateTime.Now);
            table.Rows.Add("Avocado", "Food", "Fruits Inc.", DateTime.Now);
            table.Rows.Add("Cherry", "Food", "Fruits Inc.", DateTime.Now);
            table.Rows.Add("Apricot", "Ambrosia", "NorthEastAttitude", DateTime.Now);
            table.Rows.Add("Nectarine", "Food", "Fruits Inc.", DateTime.Now);
            
            return table;
        }

        //private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        //{
        //    OrangeGradient.Painter(e);
        //}
    }
}
