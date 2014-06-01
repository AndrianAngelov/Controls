namespace Anyo.WindowsForms.Controls.Navigations
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Data;
    using System.Text;
    using System.Windows.Forms;
    using Anyo.WindowsForms.Controls.Buttons;
    using System.Reflection;
    using System.Data.SqlClient;

    /// <summary>
    /// Represents a Windows custom paging control
    /// </summary>
    /// <remarks>Two ways of using: <br />
    /// <p>1)Directly access data from SQL Server database</p>
    /// <p>2)From already filled DataTable object</p>
    /// <example>  
    /// <code>
    /// using Anyo.WindowsForms.Controls.Navigations;
    /// 
    /// private void TestForm_Load(object sender, EventArgs e)
    /// {
    ///     this.dataGridNavigation1.DataGridName = this.dataGridView1;
    /// 
    ///     //1)Directly access data from SQL Server databas
    ///     this.dataGridNavigation1.PageSize = 10;
    ///     this.dataGridNavigation1.ConnectionString = @"Server=*******;
    ///                                                   Database=*******;
    ///                                                   User ID=******;
    ///                                                   Password=******;";
    ///     this.dataGridNavigation1.CommandString = @"SELECT * FROM aspnet_Users";
    ///     this.dataGridNavigation1.FillDataGridWithRecords(DataGridNavigation.Display.FirstPage);
    /// 
    ///     //2)From already filled DataTable object
    ///     DataTable dt = GetTable();
    ///     this.dataGridNavigation1.PageSize = 10;
    ///     this.dataGridNavigation1.AllPages = dt;
    ///     this.dataGridNavigation1.FillDataGridWithRecords(DataGridNavigation.Display.FirstPage);
    /// }
    /// </code> 
    /// </example>
    /// </remarks>
    /// <remarks>Here's a VisualStudio property window view of DataGridNavigation control: <br/>
    /// <img src="../Images/DataGridNavigationProprties.jpg" />
    /// </remarks>
    public partial class DataGridNavigation : UserControl
    {
        #region Enumerations
        #region GUI Enumerations
        private enum Get
        {
            NewWidth,
            NewHeight
        }

        /// <summary>
        /// Specifies whether the text in the buttons is top-centered, middle-centered, bottom-centered, or none(set specific x,y coordinates that start from top left corner).
        /// </summary>
        public enum Alignment
        {
            /// <summary>
            /// Disable general alignment and set specific x,y coordinates that start from top left corner
            /// </summary>
            None,
            /// <summary>
            /// The control's text is horizontally centered , vertically on top
            /// </summary>
            TopCenter,
            /// <summary>
            /// The control's text is horizontally and vertically centered
            /// </summary>
            Center,
            /// <summary>
            /// The control's text is horizontally centered , vertically on bottom
            /// </summary>
            BottomCenter,
        }

        private enum TargetType
        {
            GradientButton,
            Label,
            AllTypes,
        }
        #endregion

        #region Data Access Logic Enumerations
        /// <summary>
        /// Specifies which page of record in DataGridNavigation to show in DataGridView control. 
        /// </summary>
        public enum Display
        {
            /// <summary>
            /// Show in DataGridView control first page of records in DataGridNavigation.
            /// </summary>
            FirstPage,
            /// <summary>
            /// Show in DataGridView control last page of of records in DataGridNavigation.
            /// </summary>
            LastPage
        }
        #endregion
        #endregion

        #region Fields
        #region GUI Fieleds
        private int defaultButtonsDistance;
        private int newButtonsDistance;
        private int buttonsWidth;
        private int buttonsHeignt;

        private float textLocationX;
        private float textLocationY;
        private Alignment textAlignment;
        private Font buttonsFont;
        private Font currentPageFont;

        private Color normalBorderColor;
        private Color normalColorA;
        private Color normalColorB;

        private Color hoverBorderColor;
        private Color hoverColorA;
        private Color hoverColorB;

        private Color clickBorderColor;
        private Color clickColorA;
        private Color clickColorB;
        #endregion

        #region Data Access Logic Fieleds
        private SqlDataAdapter da;
        private SqlCommand cmd;
        private DataTable dtAllPages;
        private DataGridView dataGridName;

        private string connectionStr;
        private string cmdStr;
        private int pageSize;
        private int currentPageIndex = 1;
        private string currentPageBoxText;
        private int totalPages;
        #endregion
        #endregion

        #region Constructor
        /// <summary>
        /// 
        /// </summary>
        public DataGridNavigation()
        {
            InitializeComponent();

            this.defaultButtonsDistance = (this.Controls[0].Location.X) - (this.Controls[0].Location.X + this.Controls[0].Width);
            this.buttonsWidth = this.Controls[0].Width;
            this.buttonsHeignt = this.Controls[0].Height;

            textAlignment = Alignment.Center;
            buttonsFont = UserControl.DefaultFont;
            currentPageFont = UserControl.DefaultFont;
            buttonsFont = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            base.AutoScaleMode = AutoScaleMode.None;

            normalBorderColor = (this.Controls[0] as GradientButton).NormalBorderColor;
            normalColorA = (this.Controls[0] as GradientButton).NormalColorA;
            normalColorB = (this.Controls[0] as GradientButton).NormalColorB;

            hoverBorderColor = (this.Controls[0] as GradientButton).HoverBorderColor;
            hoverColorA = (this.Controls[0] as GradientButton).HoverColorA;
            hoverColorB = (this.Controls[0] as GradientButton).HoverColorB;

            clickBorderColor = (this.Controls[0] as GradientButton).ClickBorderColor;
            clickColorA = (this.Controls[0] as GradientButton).ClickColorA;
            clickColorB = (this.Controls[0] as GradientButton).ClickColorB;
        }
        #endregion

        #region Properties
        #region GUI Properties
        /// <summary>
        /// Gets and sets distance between buttons/buttons and page viewer/buttons in DataGridNavigation control.<br/>
        /// (Category:DataGridNavigation_GUI)
        /// </summary>
        [Description("Gets and sets distance between buttons/buttons and page viewer/buttons in DataGridNavigation control."), Category("DataGridNavigation_GUI")]
        public int ButtonsDistance
        {
            get
            {
                return this.newButtonsDistance;
            }
            set
            {
                int defautButtonDistance = this.newButtonsDistance;
                this.newButtonsDistance = value;
                int oldButtonDistance = defautButtonDistance;

                if (this.newButtonsDistance != oldButtonDistance)
                {
                    GetNewButtonsLocation(this.newButtonsDistance);
                    this.Width = GetControlNewSize(Get.NewWidth);
                }
            }
        }

        /// <summary>
        /// Gets and sets width of all buttons and page viewer in DataGridNavigation control.<br/>
        /// (Category:DataGridNavigation_GUI)
        /// </summary>
        [Description("Gets and sets width of all buttons and page viewer in DataGridNavigation control."), Category("DataGridNavigation_GUI")]
        public int ButtonsWidth
        {
            get
            {
                return this.buttonsWidth;
            }
            set
            {
                this.buttonsWidth = value;

                SetProperty(TargetType.GradientButton, "Width", this.buttonsWidth);
                SetProperty(TargetType.Label, "Width", this.buttonsWidth + 20);

                int newDistance = this.ButtonsDistance;
                GetNewButtonsLocation(newDistance);

                this.Width = GetControlNewSize(Get.NewWidth);
            }
        }

        /// <summary>
        /// Gets and sets height of all buttons and current page viewer in DataGridNavigation control.<br/>
        /// (Category:DataGridNavigation_GUI)
        /// </summary>
        [Description("Gets and sets height of all buttons and page viewer in DataGridNavigation control."), Category("DataGridNavigation_GUI")]
        public int ButtonsHeight
        {
            get
            {
                return this.buttonsHeignt;
            }
            set
            {
                this.buttonsHeignt = value;

                SetProperty(TargetType.AllTypes, "Height", this.buttonsHeignt);
                this.Height = GetControlNewSize(Get.NewHeight);
            }
        }

        /// <summary>
        /// Gets or sets the vertical alignment of the GradientButton's text content.<br/>
        /// (Category:DataGridNavigation_GUI)
        /// </summary>
        [Description("Gets or sets the vertical alignment of the GradientButton's text content."), Category("DataGridNavigation_GUI")]
        public Alignment TextAlignment
        {
            get
            {
                return this.textAlignment;
            }
            set
            {
                this.textAlignment = value;
                this.Invalidate();
            }

        }

        /// <summary>
        /// Gets or sets GradientButton's text content X position from top-left corner when general alignment is none.<br/>
        /// (Category:DataGridNavigation_GUI)
        /// </summary>
        [Description("Gets or sets GradientButton's text content X position from top-left corner when general alignment is none."), Category("DataGridNavigation_GUI")]
        public float TextX
        {
            get
            {
                return this.textLocationX;
            }
            set
            {
                this.textLocationX = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets GradientButton's text content Y position from top-left corner when general alignment is none.<br/>
        /// (Category:DataGridNavigation_GUI)
        /// </summary>
        [Description("Gets or sets GradientButton's text content Y position from top-left corner when general alignment is none."), Category("DataGridNavigation_GUI")]
        public float TextY
        {
            get
            {
                return this.textLocationY;
            }
            set
            {
                this.textLocationY = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Sets the font of the buttons.<br/>
        /// (Category:DataGridNavigation_GUI)
        /// </summary>
        [Description("Sets the font of the buttons."), Category("DataGridNavigation_GUI")]
        public Font FontButtons
        {
            get
            {
                return this.buttonsFont;
            }
            set
            {
                this.buttonsFont = value;

                SetProperty(TargetType.GradientButton, "Font", this.buttonsFont);
            }
        }

        /// <summary>
        /// Sets the font of the current page viewer.<br/>
        /// (Category:DataGridNavigation_GUI)
        /// </summary>
        [Description("Sets the font of the current page viewer."), Category("DataGridNavigation_GUI")]
        public Font FontCurrentPage
        {
            get
            {
                return this.currentPageFont;
            }
            set
            {
                this.currentPageFont = value;
                SetProperty(TargetType.Label, "Font", this.currentPageFont);
            }
        }

        /// <summary>
        /// Gets or sets border color of DataGridNavigation buttons in Normal state.<br/>
        /// (Category:DataGridNavigation_GUI)
        /// </summary>
        [Description("Gets or sets border color of DataGridNavigation buttons in Normal state."), Category("DataGridNavigation_GUI")]
        public Color NormalBorderColor
        {
            get
            {
                return this.normalBorderColor;
            }
            set
            {
                this.normalBorderColor = value;
                SetProperty(TargetType.GradientButton, "NormalBorderColor", this.normalBorderColor);
            }

        }

        /// <summary>
        /// Gets or sets top-middle gradient color of DataGridNavigation buttons in Normal state.<br/>
        /// (Category:DataGridNavigation_GUI)
        /// </summary>
        [Description("Gets or sets top-middle gradient color of DataGridNavigation buttons in Normal state."), Category("DataGridNavigation_GUI")]
        public Color NormalColorA
        {
            get
            {
                return this.normalColorA;
            }
            set
            {
                this.normalColorA = value;
                SetProperty(TargetType.GradientButton, "NormalColorA", this.normalColorA);
            }
        }

        /// <summary>
        /// Gets or sets middle-bottom gradient color of DataGridNavigation buttons in Normal state.<br/>
        /// (Category:DataGridNavigation_GUI)
        /// </summary>
        [Description("Gets or sets middle-bottom gradient color of DataGridNavigation buttons in Normal state."), Category("DataGridNavigation_GUI")]
        public Color NormalColorB
        {
            get
            {
                return this.normalColorB;
            }
            set
            {
                this.normalColorB = value;
                SetProperty(TargetType.GradientButton, "NormalColorB", this.normalColorB);
            }
        }

        /// <summary>
        /// Gets or sets border color of DataGridNavigation buttons when raise OnMouseEner event.<br/>
        /// (Category:DataGridNavigation_GUI)
        /// </summary>
        [Description("Gets or sets border color of DataGridNavigation buttons when raise OnMouseEner event."), Category("DataGridNavigation_GUI")]
        public Color HoverBorderColor
        {
            get
            {
                return this.hoverBorderColor;
            }
            set
            {
                this.hoverBorderColor = value;
                SetProperty(TargetType.GradientButton, "HoverBorderColor", this.hoverBorderColor);
            }

        }

        /// <summary>
        /// Gets or sets top-middle gradient color of DataGridNavigation buttons when raise OnMouseEner event.<br/>
        /// (Category:DataGridNavigation_GUI)
        /// </summary>
        [Description("Gets or sets top-middle gradient color of DataGridNavigation buttons when raise OnMouseEner event."), Category("DataGridNavigation_GUI")]
        public Color HoverColorA
        {
            get
            {
                return this.hoverColorA;
            }
            set
            {
                this.hoverColorA = value;
                SetProperty(TargetType.GradientButton, "HoverColorA", this.hoverColorA);
            }
        }

        /// <summary>
        /// Gets or sets middle-bottom gradient color of DataGridNavigation buttons when raise OnMouseEner event.<br/>
        /// (Category:DataGridNavigation_GUI) 
        /// </summary>
        [Description("Gets or sets middle-bottom gradient color of DataGridNavigation buttons when raise OnMouseEner event. "), Category("DataGridNavigation_GUI")]
        public Color HoverColorB
        {
            get
            {
                return this.hoverColorB;
            }
            set
            {
                this.hoverColorB = value;
                SetProperty(TargetType.GradientButton, "HoverColorB", this.hoverColorB);
            }
        }

        /// <summary>
        /// Gets or sets border color of DataGridNavigation buttons when raise OnMouseDown event.<br/>
        /// (Category:DataGridNavigation_GUI)
        /// </summary>
        [Description("Gets or sets border color of DataGridNavigation buttons when raise OnMouseDown event."), Category("DataGridNavigation_GUI")]
        public Color ClickBorderColor
        {
            get
            {
                return this.clickBorderColor;
            }
            set
            {
                clickBorderColor = value;
                SetProperty(TargetType.GradientButton, "ClickBorderColor", this.clickBorderColor);
            }

        }

        /// <summary>
        /// Gets or sets top-middle gradient color of DataGridNavigation buttons when raise OnMouseDown event.<br/>
        /// (Category:DataGridNavigation_GUI) 
        /// </summary>
        [Description("Gets or sets top-middle gradient color of DataGridNavigation buttons when raise OnMouseDown event."), Category("DataGridNavigation_GUI")]
        public Color ClickColorA
        {
            get
            {
                return this.clickColorA;
            }
            set
            {
                this.clickColorA = value;
                SetProperty(TargetType.GradientButton, "ClickColorA", this.clickColorA);
            }
        }

        /// <summary>
        /// Gets or sets middle-bottom gradient color of DataGridNavigation buttons when raise OnMouseDown event.<br/>
        /// (Category:DataGridNavigation_GUI) 
        /// </summary>
        [Description("Gets or sets middle-bottom gradient color of DataGridNavigation buttons when raise OnMouseDown event."), Category("DataGridNavigation_GUI")]
        public Color ClickColorB
        {
            get
            {
                return this.clickColorB;
            }
            set
            {
                this.clickColorB = value;
                SetProperty(TargetType.GradientButton, "ClickColorB", this.clickColorB);
            }
        }
        #endregion

        #region Data Access Logic Properties
        /// <summary>
        /// Gets or sets the DataGridView object that displays records held by DataGridnavigation control.<br/>
        /// (Category:DataGridNavigation_DataAccessLogic)
        /// </summary>
        [Description("Gets or sets the DataGridView object that displays records held by DataGridnavigation control."), Category("DataGridNavigation_DataAccessLogic")]
        public DataGridView DataGridName
        {
            get
            {
                return dataGridName;
            }
            set
            {
                dataGridName = value;
            }
        }

        /// <summary>
        /// Gets or sets the connection string to specific SQL server database.<br/>
        /// (Category:DataGridNavigation_DataAccessLogic)
        /// </summary>
        [Description("Gets or sets the connection string to specific SQL server database."), Category("DataGridNavigation_DataAccessLogic")]
        public string ConnectionString
        {
            get
            {
                return this.connectionStr;
            }
            set
            {
                this.connectionStr = value;
            }
        }

        /// <summary>
        /// Gets or sets the command string to retrieve data from SQL server database.<br/>
        /// (Category:DataGridNavigation_DataAccessLogic)
        /// </summary>
        [Description("Gets or sets the command string to retrieve data from SQL server database."), Category("DataGridNavigation_DataAccessLogic")]
        public string CommandString
        {
            get
            {
                return this.cmdStr;
            }
            set
            {
                this.cmdStr = value;
            }
        }

        /// <summary>
        /// Gets or sets already filled DataTable object that display in DataGridView control.<br/>
        /// (Category:DataGridNavigation_DataAccessLogic)
        /// </summary>
        [Description("AllPages"), Category("DataGridNavigation_DataAccessLogic")]
        public DataTable AllPages
        {
            get
            {
                return this.dtAllPages;
            }
            set
            {
                this.dtAllPages = value;
            }
        }

        /// <summary>
        /// Gets or sets the number of records to display on a page in a DataGridView control.<br/>
        /// (Category:DataGridNavigation_DataAccessLogic)
        /// </summary>
        [Description("Gets or sets the number of records to display on a page in a DataGridView control."), Category("DataGridNavigation_DataAccessLogic")]
        public int PageSize
        {
            get
            {
                return this.pageSize;
            }
            set
            {
                this.pageSize = value;
            }
        }

        #endregion
        #endregion

        #region Events
        private void firstPage_btn_Click(object sender, EventArgs e)
        {
            GetFirstPage();
        }

        private void next_btn_Click(object sender, EventArgs e)
        {
            GetNextPage();
        }

        private void prev_btn_Click(object sender, EventArgs e)
        {
            GetPreviousPage();
        }

        private void lastPage_btn_Click(object sender, EventArgs e)
        {
            GetLastPage();
        }
        #endregion

        #region Methods
        #region GUI Methods
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            foreach (Control control in this.Controls)
            {
                if (control is GradientButton)
                {
                    SizeF textSize = e.Graphics.MeasureString(control.Text, base.Font);
                    switch (textAlignment)
                    {
                        case Alignment.None:
                            (control as GradientButton).TextAlignment = GradientButton.Alignment.None;
                            (control as GradientButton).TextX = this.textLocationX;
                            (control as GradientButton).TextY = this.textLocationY;
                            break;
                        case Alignment.TopCenter:
                            (control as GradientButton).TextAlignment = GradientButton.Alignment.TopCenter;
                            textLocationX = (control.Size.Width / 2) - (textSize.Width / 2);
                            textLocationY = 2;
                            break;
                        case Alignment.Center:
                            (control as GradientButton).TextAlignment = GradientButton.Alignment.Center;
                            textLocationX = (control.Size.Width / 2) - (textSize.Width / 2);
                            textLocationY = (control.Size.Height / 2) - (textSize.Height / 2);
                            break;
                        case Alignment.BottomCenter:
                            (control as GradientButton).TextAlignment = GradientButton.Alignment.BottomCenter;
                            textLocationX = (control.Size.Width / 2) - (textSize.Width / 2);
                            textLocationY = (control.Size.Height) - (textSize.Height + 2);
                            break;
                    }
                }
            }
        }

        //set value in common property in diffrent instance of one type like:
        //on all type GradientButton, propery width ,value=80 at same time;
        private void SetProperty(TargetType targetControlType, string propertyName, object value)
        {
            PropertyInfo property;

            foreach (Control control in this.Controls)
            {
                switch (targetControlType)
                {
                    case TargetType.GradientButton:
                    case TargetType.Label:
                        string controlTypeName = targetControlType.ToString();

                        if (control.GetType().Name == controlTypeName)
                        {
                            property = control.GetType().GetProperty(propertyName);
                            property.SetValue(control, value, null);
                        }
                        break;
                    case TargetType.AllTypes:
                        property = control.GetType().GetProperty(propertyName);
                        property.SetValue(control, value, null);
                        break;
                }
            }
        }

        private void GetNewButtonsLocation(int newButtonsDistance)
        {
            int newLocationX;
            newLocationX = this.Controls[0].Width + newButtonsDistance;

            foreach (Control control in this.Controls)
            {
                if (!control.Equals(this.Controls[0]))
                {
                    control.Location = new Point(newLocationX, control.Location.Y);
                    newLocationX += control.Width + newButtonsDistance;
                }
            }
        }

        private int GetControlNewSize(Get newWidthOrNewHeight)
        {
            int currentControlWidth = 0;
            int currentControlHeight = 0;
            int buttonsDistance = this.ButtonsDistance;

            if (newWidthOrNewHeight == Get.NewWidth)
            {
                for (int currentIndex = 0; currentIndex < this.Controls.Count; currentIndex++)
                {
                    if (currentIndex < this.Controls.Count - 1)
                    {
                        currentControlWidth += this.Controls[currentIndex].Width + buttonsDistance;
                    }
                    else
                    {
                        currentControlWidth += this.Controls[currentIndex].Width;
                    }
                    //currentControlHeight += this.Controls[currentIndex].Height;

                }
                return currentControlWidth;
            }
            else
            {
                currentControlHeight = this.ButtonsHeight;
                return currentControlHeight;
            }
        }
        #endregion

        #region Data Access Logic Methods
        /// <summary>
        /// Fill DataGridView control with records held by DataGridnavigation.
        /// </summary>
        /// <param name="firstOrLastPage">set which page to display when DataGridView control is loaded</param>
        public void FillDataGridWithRecords(Display firstOrLastPage)
        {
            if (this.AllPages==null)
            {
                SqlConnection dbCon = new SqlConnection(this.ConnectionString);
                this.cmd = new SqlCommand(this.CommandString, dbCon); 
            }
            try
            {
                if (this.AllPages == null)
                {
                    this.da = new SqlDataAdapter(cmd);
                    this.dtAllPages = new DataTable();
                    this.da.Fill(dtAllPages);
                }

                this.totalPages = CalculateTotalPages();

                if (this.totalPages==0)
                {
                    InsertEmptyRows(dtAllPages,pageSize);
                    this.totalPages = 1;
                    GetFirstPage();
                }
                else
                {
                    if (firstOrLastPage == Display.FirstPage)
                    {
                        GetFirstPage();
                    }
                    if (firstOrLastPage == Display.LastPage)
                    {
                        GetLastPage();
                    }
                    else
                    {
                        GetFirstPage();
                    }
                }
            }
            catch(DivideByZeroException)
            {
                MessageBox.Show("Please first set PageSize property of DataGridNavigation control before use FillDataGridWithRecords() method.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private int CalculateTotalPages()
        {
            int rowsCount = this.dtAllPages.Rows.Count;
            this.totalPages = rowsCount / this.pageSize;

            if (this.totalPages != 0 && ((rowsCount % this.pageSize) > 0))
            {
                this.totalPages += 1;
                return this.totalPages;
            }

            return this.totalPages;
        }

        private DataTable GetCurrentRecords(int currentPageNumber)
        {
            DataTable dtCurrentPage = new DataTable();

            int previousPagesRowsCounter;

            dtCurrentPage = this.dtAllPages.Clone();

            if (currentPageNumber == 1)
            {
                for (int i = 0; i < pageSize; i++)
                {
                    dtCurrentPage.ImportRow(this.dtAllPages.Rows[i]);
                }
            }
            else
            {
                previousPagesRowsCounter = (currentPageNumber - 1) * pageSize;

                if (currentPageNumber == totalPages)
                {
                    int countRowsWithRecordsInLastPage = this.dtAllPages.Rows.Count - previousPagesRowsCounter;
                    int neededEmptyRows = pageSize - countRowsWithRecordsInLastPage;

                    for (int i = previousPagesRowsCounter; i < this.dtAllPages.Rows.Count; i++)
                    {
                        dtCurrentPage.ImportRow(this.dtAllPages.Rows[i]);
                    }

                    //Fill last page with empty rows if number of record are less than page size
                    if (neededEmptyRows > 0)
                    {
                        InsertEmptyRows(dtCurrentPage, neededEmptyRows);
                    }
                }
                else
                {
                    for (int i = previousPagesRowsCounter; i < previousPagesRowsCounter + pageSize; i++)
                    {
                        dtCurrentPage.ImportRow(this.dtAllPages.Rows[i]);
                    }
                }
            }
            return dtCurrentPage;
        }

        private static void InsertEmptyRows(DataTable dtCurrentPage, int neededEmptyRows)
        {
            DataRow newRow;
            for (int i = 0; i < neededEmptyRows; i++)
            {
                newRow = dtCurrentPage.NewRow();
                dtCurrentPage.Rows.Add(newRow);
            }
        }

        private string SetCurrentPageBoxText()
        {
            this.currentPageBoxText = String.Format(@"{0}/{1}", this.currentPageIndex, this.totalPages);
            return currentPageBoxText;
        }

        private void GetFirstPage()
        {
            this.currentPageIndex = 1;
            this.dataGridName.DataSource = GetCurrentRecords(this.currentPageIndex);
            this.currentPageBox.Text = SetCurrentPageBoxText();
        }

        private void GetPreviousPage()
        {
            if (this.currentPageIndex > 1)
            {
                this.currentPageIndex--;
                this.dataGridName.DataSource = GetCurrentRecords(this.currentPageIndex);
                this.currentPageBox.Text = SetCurrentPageBoxText();
            }
        }

        private void GetNextPage()
        {
            if (this.currentPageIndex < this.totalPages)
            {
                this.currentPageIndex++;
                this.dataGridName.DataSource = GetCurrentRecords(this.currentPageIndex);
                this.currentPageBox.Text = SetCurrentPageBoxText();
            }
        }

        private void GetLastPage()
        {
            this.currentPageIndex = totalPages;
            this.dataGridName.DataSource = GetCurrentRecords(this.currentPageIndex);
            this.currentPageBox.Text = SetCurrentPageBoxText();
        }

        #endregion
        #endregion
    }
}
