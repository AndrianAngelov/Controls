namespace Anyo.WindowsForms.Controls.DataGridViewHeaderPainting
{
    using System;
    using System.Windows.Forms;
    using System.Drawing;
    using System.Drawing.Drawing2D;

    /// <summary>
    /// This class redraw the header of DataGridView control with orange gradient from colors: DarkGoldenrod,Orange,DarkOrange.
    /// </summary>
    /// <example>
    /// <img src="../Images/OrangeGradient.jpg" />
    /// <code>
    /// using Anyo.WindowsForms.Controls.DataGridViewHeaderPainting;
    /// 
    /// private void TestForm_Load(object sender, EventArgs e)
    /// {
    ///     OrangeGradientHeader header = new OrangeGradientHeader();
    ///     header.Painter(dataGridView1);
    /// }
    /// </code> 
    /// </example>
    public class OrangeGradientHeader
    {
        private DataGridView dataGridView;
        private DataGridViewCellStyle alternatingRowsCellsStyle = new System.Windows.Forms.DataGridViewCellStyle();
        private DataGridViewCellStyle headerCellsStyle = new System.Windows.Forms.DataGridViewCellStyle();
        private DataGridViewCellStyle hoverRowCellsStyle = new System.Windows.Forms.DataGridViewCellStyle();
        private DataGridViewCellStyle defaultRowsCellsStyle = new System.Windows.Forms.DataGridViewCellStyle();
        
        /// <summary>
        /// 
        /// </summary>
        public OrangeGradientHeader()
        {
            //this.dataGridView = dataGridView;

            //alternatingRowsCellsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            //this.dataGridView.AlternatingRowsDefaultCellStyle = alternatingRowsCellsStyle;
            //this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            //this.dataGridView.CausesValidation = false;
            //this.dataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            //headerCellsStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            //headerCellsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(150)))), ((int)(((byte)(0)))));
            //headerCellsStyle.ForeColor = System.Drawing.Color.White;
            //headerCellsStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            //headerCellsStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            //headerCellsStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            //this.dataGridView.ColumnHeadersDefaultCellStyle = headerCellsStyle;
            //this.dataGridView.ColumnHeadersHeight = 40;
            //this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            //hoverRowCellsStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            //hoverRowCellsStyle.BackColor = System.Drawing.SystemColors.Window;
            //hoverRowCellsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(130)))), ((int)(((byte)(9)))));
            //hoverRowCellsStyle.SelectionForeColor = System.Drawing.Color.White;
            //hoverRowCellsStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            //this.dataGridView.DefaultCellStyle = hoverRowCellsStyle;
            //this.dataGridView.EnableHeadersVisualStyles = false;
            //this.dataGridView.RowHeadersVisible = false;
            //defaultRowsCellsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(212)))), ((int)(((byte)(215)))));
            //this.dataGridView.RowsDefaultCellStyle = defaultRowsCellsStyle;
            //this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            //this.dataGridView.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(CellPainting);
        }

        /// <summary>
        /// Method that paint header of DataGridView control with gradient from colors: DarkGoldenrod,Orange,DarkOrange.
        /// </summary>
        /// <param name="dataGridView">DataGridView control which will redraws headers</param>
        public void Painter(DataGridView dataGridView)
        {
            this.dataGridView = dataGridView;

            alternatingRowsCellsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.dataGridView.AlternatingRowsDefaultCellStyle = alternatingRowsCellsStyle;
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.CausesValidation = false;
            this.dataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            headerCellsStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            headerCellsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(150)))), ((int)(((byte)(0)))));
            headerCellsStyle.ForeColor = System.Drawing.Color.White;
            headerCellsStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            headerCellsStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            headerCellsStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView.ColumnHeadersDefaultCellStyle = headerCellsStyle;
            this.dataGridView.ColumnHeadersHeight = 40;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            hoverRowCellsStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            hoverRowCellsStyle.BackColor = System.Drawing.SystemColors.Window;
            hoverRowCellsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(130)))), ((int)(((byte)(9)))));
            hoverRowCellsStyle.SelectionForeColor = System.Drawing.Color.White;
            hoverRowCellsStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView.DefaultCellStyle = hoverRowCellsStyle;
            this.dataGridView.EnableHeadersVisualStyles = false;
            this.dataGridView.RowHeadersVisible = false;
            defaultRowsCellsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(212)))), ((int)(((byte)(215)))));
            this.dataGridView.RowsDefaultCellStyle = defaultRowsCellsStyle;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(CellPainting);
        }

        private void Painting(DataGridViewCellPaintingEventArgs e)
        {

            if (e.RowIndex == -1)
            {
                Graphics gb = e.Graphics;
                gb.SmoothingMode = SmoothingMode.AntiAlias;

                Graphics g = e.Graphics;
                g.SmoothingMode = SmoothingMode.AntiAlias;

                #region Old
                Rectangle headerRectangle = new Rectangle(new Point(e.CellBounds.X, e.CellBounds.Y), new Size(e.CellBounds.Width, e.CellBounds.Height));
                Rectangle headerRectangle1 = new Rectangle(new Point(e.CellBounds.X, e.CellBounds.Y), new Size(e.CellBounds.Width, e.CellBounds.Height / 4 - 5));
                Rectangle headerRectangle2 = new Rectangle(new Point(e.CellBounds.X, e.CellBounds.Height / 4 - 5), new Size(e.CellBounds.Width, e.CellBounds.Height / 4 + 5));
                Rectangle headerRectangle3 = new Rectangle(new Point(e.CellBounds.X, (e.CellBounds.Height / 4) * 2), new Size(e.CellBounds.Width, e.CellBounds.Height / 4 + 6));
                Rectangle headerRectangle4 = new Rectangle(new Point(e.CellBounds.X, (e.CellBounds.Height / 4) * 3 + 5), new Size(e.CellBounds.Width, e.CellBounds.Height / 4 - 5));

                using (LinearGradientBrush bodyGradientRectangle1 = new LinearGradientBrush(headerRectangle1, Color.DarkGoldenrod, Color.Orange, LinearGradientMode.Vertical))
                {
                    g.FillRectangle(bodyGradientRectangle1, headerRectangle1);
                    e.PaintContent(e.ClipBounds);
                    e.Handled = true;
                }

                using (LinearGradientBrush bodyGradientRectangle2 = new LinearGradientBrush(headerRectangle2, Color.Orange, Color.Orange, LinearGradientMode.Vertical))
                {
                    g.FillRectangle(bodyGradientRectangle2, headerRectangle2);
                    e.PaintContent(e.ClipBounds);
                    e.Handled = true;
                }

                using (LinearGradientBrush bodyGradientRectangle3 = new LinearGradientBrush(headerRectangle3, Color.DarkOrange, Color.DarkOrange, LinearGradientMode.Vertical))
                {
                    g.FillRectangle(bodyGradientRectangle3, headerRectangle3);
                    e.PaintContent(e.ClipBounds);
                    e.Handled = true;
                }

                using (LinearGradientBrush bodyGradientRectangle4 = new LinearGradientBrush(headerRectangle4, Color.DarkOrange, Color.DarkGoldenrod, LinearGradientMode.Vertical))
                {
                    g.FillRectangle(bodyGradientRectangle4, headerRectangle4);
                    e.PaintContent(e.ClipBounds);
                    e.Handled = true;
                }

                gb.DrawLine(new Pen(SystemColors.ControlDark, 1),
                   new Point(e.CellBounds.X, e.CellBounds.Y), new Point(e.CellBounds.X, e.CellBounds.Height));
                #endregion
            }
        }

        private void CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            Painting(e);
        }
    }
}
