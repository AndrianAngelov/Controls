using System.Windows.Forms.Design;

namespace Anyo.WindowsForms.Controls.Navigations
{
    partial class DataGridNavigation
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.currentPageBox = new System.Windows.Forms.Label();
            this.firstPage_btn = new Anyo.WindowsForms.Controls.Buttons.GradientButton();
            this.prev_btn = new Anyo.WindowsForms.Controls.Buttons.GradientButton();
            this.next_btn = new Anyo.WindowsForms.Controls.Buttons.GradientButton();
            this.lastPage_btn = new Anyo.WindowsForms.Controls.Buttons.GradientButton();
            this.SuspendLayout();
            // 
            // currentPageBox
            // 
            this.currentPageBox.BackColor = System.Drawing.Color.White;
            this.currentPageBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.currentPageBox.Location = new System.Drawing.Point(80, 0);
            this.currentPageBox.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.currentPageBox.Name = "currentPageBox";
            this.currentPageBox.Size = new System.Drawing.Size(60, 25);
            this.currentPageBox.TabIndex = 2;
            this.currentPageBox.Text = "1/1";
            this.currentPageBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // firstPage_btn
            // 
            this.firstPage_btn.Active = true;
            this.firstPage_btn.BorderWidth = 1;
            this.firstPage_btn.ButtonRadius = 2;
            this.firstPage_btn.ButtonStyle = Anyo.WindowsForms.Controls.Buttons.GradientButton.ButtonStyles.RoundedEdgesRectangel;
            this.firstPage_btn.ClickBorderColor = System.Drawing.Color.Cornsilk;
            this.firstPage_btn.ClickColorA = System.Drawing.Color.DarkOrange;
            this.firstPage_btn.ClickColorB = System.Drawing.Color.Orange;
            this.firstPage_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.firstPage_btn.ForeColor = System.Drawing.Color.White;
            this.firstPage_btn.GradientStyle = Anyo.WindowsForms.Controls.Buttons.GradientButton.GradientStyles.Vertical;
            this.firstPage_btn.HoverBorderColor = System.Drawing.Color.Linen;
            this.firstPage_btn.HoverColorA = System.Drawing.Color.PeachPuff;
            this.firstPage_btn.HoverColorB = System.Drawing.Color.Orange;
            this.firstPage_btn.ImageAlignment = Anyo.WindowsForms.Controls.Buttons.GradientButton.Alignment.None;
            this.firstPage_btn.ImageCornerX = 0;
            this.firstPage_btn.ImageCornerY = 0;
            this.firstPage_btn.Location = new System.Drawing.Point(0, 0);
            this.firstPage_btn.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.firstPage_btn.Name = "firstPage_btn";
            this.firstPage_btn.NormalBorderColor = System.Drawing.Color.White;
            this.firstPage_btn.NormalColorA = System.Drawing.Color.SlateGray;
            this.firstPage_btn.NormalColorB = System.Drawing.Color.SlateGray;
            this.firstPage_btn.Size = new System.Drawing.Size(40, 25);
            this.firstPage_btn.SmoothingQuality = Anyo.WindowsForms.Controls.Buttons.GradientButton.SmoothingQualities.AntiAlias;
            this.firstPage_btn.TabIndex = 0;
            this.firstPage_btn.Text = "|<";
            this.firstPage_btn.TextAlignment = Anyo.WindowsForms.Controls.Buttons.GradientButton.Alignment.Center;
            this.firstPage_btn.TextX = 11.71658F;
            this.firstPage_btn.TextY = 3.621095F;
            this.firstPage_btn.Click += new System.EventHandler(this.firstPage_btn_Click);
            // 
            // prev_btn
            // 
            this.prev_btn.Active = true;
            this.prev_btn.BorderWidth = 1;
            this.prev_btn.ButtonRadius = 2;
            this.prev_btn.ButtonStyle = Anyo.WindowsForms.Controls.Buttons.GradientButton.ButtonStyles.RoundedEdgesRectangel;
            this.prev_btn.ClickBorderColor = System.Drawing.Color.Cornsilk;
            this.prev_btn.ClickColorA = System.Drawing.Color.DarkOrange;
            this.prev_btn.ClickColorB = System.Drawing.Color.Orange;
            this.prev_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.prev_btn.ForeColor = System.Drawing.Color.White;
            this.prev_btn.GradientStyle = Anyo.WindowsForms.Controls.Buttons.GradientButton.GradientStyles.Vertical;
            this.prev_btn.HoverBorderColor = System.Drawing.Color.Linen;
            this.prev_btn.HoverColorA = System.Drawing.Color.PeachPuff;
            this.prev_btn.HoverColorB = System.Drawing.Color.Orange;
            this.prev_btn.ImageAlignment = Anyo.WindowsForms.Controls.Buttons.GradientButton.Alignment.None;
            this.prev_btn.ImageCornerX = 0;
            this.prev_btn.ImageCornerY = 0;
            this.prev_btn.Location = new System.Drawing.Point(40, 0);
            this.prev_btn.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.prev_btn.Name = "prev_btn";
            this.prev_btn.NormalBorderColor = System.Drawing.Color.White;
            this.prev_btn.NormalColorA = System.Drawing.Color.SlateGray;
            this.prev_btn.NormalColorB = System.Drawing.Color.SlateGray;
            this.prev_btn.Size = new System.Drawing.Size(40, 25);
            this.prev_btn.SmoothingQuality = Anyo.WindowsForms.Controls.Buttons.GradientButton.SmoothingQualities.AntiAlias;
            this.prev_btn.TabIndex = 1;
            this.prev_btn.Text = "<<";
            this.prev_btn.TextAlignment = Anyo.WindowsForms.Controls.Buttons.GradientButton.Alignment.Center;
            this.prev_btn.TextX = 9.490019F;
            this.prev_btn.TextY = 3.621095F;
            this.prev_btn.Click += new System.EventHandler(this.prev_btn_Click);
            // 
            // next_btn
            // 
            this.next_btn.Active = true;
            this.next_btn.BorderWidth = 1;
            this.next_btn.ButtonRadius = 2;
            this.next_btn.ButtonStyle = Anyo.WindowsForms.Controls.Buttons.GradientButton.ButtonStyles.RoundedEdgesRectangel;
            this.next_btn.ClickBorderColor = System.Drawing.Color.Cornsilk;
            this.next_btn.ClickColorA = System.Drawing.Color.DarkOrange;
            this.next_btn.ClickColorB = System.Drawing.Color.Orange;
            this.next_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.next_btn.ForeColor = System.Drawing.Color.White;
            this.next_btn.GradientStyle = Anyo.WindowsForms.Controls.Buttons.GradientButton.GradientStyles.Vertical;
            this.next_btn.HoverBorderColor = System.Drawing.Color.Linen;
            this.next_btn.HoverColorA = System.Drawing.Color.PeachPuff;
            this.next_btn.HoverColorB = System.Drawing.Color.Orange;
            this.next_btn.ImageAlignment = Anyo.WindowsForms.Controls.Buttons.GradientButton.Alignment.None;
            this.next_btn.ImageCornerX = 0;
            this.next_btn.ImageCornerY = 0;
            this.next_btn.Location = new System.Drawing.Point(140, 0);
            this.next_btn.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.next_btn.Name = "next_btn";
            this.next_btn.NormalBorderColor = System.Drawing.Color.White;
            this.next_btn.NormalColorA = System.Drawing.Color.SlateGray;
            this.next_btn.NormalColorB = System.Drawing.Color.SlateGray;
            this.next_btn.Size = new System.Drawing.Size(40, 25);
            this.next_btn.SmoothingQuality = Anyo.WindowsForms.Controls.Buttons.GradientButton.SmoothingQualities.AntiAlias;
            this.next_btn.TabIndex = 3;
            this.next_btn.Text = ">>";
            this.next_btn.TextAlignment = Anyo.WindowsForms.Controls.Buttons.GradientButton.Alignment.Center;
            this.next_btn.TextX = 9.490019F;
            this.next_btn.TextY = 3.621095F;
            this.next_btn.Click += new System.EventHandler(this.next_btn_Click);
            // 
            // lastPage_btn
            // 
            this.lastPage_btn.Active = true;
            this.lastPage_btn.BorderWidth = 1;
            this.lastPage_btn.ButtonRadius = 2;
            this.lastPage_btn.ButtonStyle = Anyo.WindowsForms.Controls.Buttons.GradientButton.ButtonStyles.RoundedEdgesRectangel;
            this.lastPage_btn.ClickBorderColor = System.Drawing.Color.Cornsilk;
            this.lastPage_btn.ClickColorA = System.Drawing.Color.DarkOrange;
            this.lastPage_btn.ClickColorB = System.Drawing.Color.Orange;
            this.lastPage_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lastPage_btn.ForeColor = System.Drawing.Color.White;
            this.lastPage_btn.GradientStyle = Anyo.WindowsForms.Controls.Buttons.GradientButton.GradientStyles.Vertical;
            this.lastPage_btn.HoverBorderColor = System.Drawing.Color.Linen;
            this.lastPage_btn.HoverColorA = System.Drawing.Color.PeachPuff;
            this.lastPage_btn.HoverColorB = System.Drawing.Color.Orange;
            this.lastPage_btn.ImageAlignment = Anyo.WindowsForms.Controls.Buttons.GradientButton.Alignment.None;
            this.lastPage_btn.ImageCornerX = 0;
            this.lastPage_btn.ImageCornerY = 0;
            this.lastPage_btn.Location = new System.Drawing.Point(180, 0);
            this.lastPage_btn.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.lastPage_btn.Name = "lastPage_btn";
            this.lastPage_btn.NormalBorderColor = System.Drawing.Color.White;
            this.lastPage_btn.NormalColorA = System.Drawing.Color.SlateGray;
            this.lastPage_btn.NormalColorB = System.Drawing.Color.SlateGray;
            this.lastPage_btn.Size = new System.Drawing.Size(40, 25);
            this.lastPage_btn.SmoothingQuality = Anyo.WindowsForms.Controls.Buttons.GradientButton.SmoothingQualities.AntiAlias;
            this.lastPage_btn.TabIndex = 4;
            this.lastPage_btn.Text = ">|";
            this.lastPage_btn.TextAlignment = Anyo.WindowsForms.Controls.Buttons.GradientButton.Alignment.Center;
            this.lastPage_btn.TextX = 11.71658F;
            this.lastPage_btn.TextY = 3.621095F;
            this.lastPage_btn.Click += new System.EventHandler(this.lastPage_btn_Click);
            // 
            // DataGridNavigation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.firstPage_btn);
            this.Controls.Add(this.prev_btn);
            this.Controls.Add(this.currentPageBox);
            this.Controls.Add(this.next_btn);
            this.Controls.Add(this.lastPage_btn);
            this.Name = "DataGridNavigation";
            this.Size = new System.Drawing.Size(220, 25);
            this.ResumeLayout(false);

        }

        #endregion

        private Anyo.WindowsForms.Controls.Buttons.GradientButton next_btn;
        private Anyo.WindowsForms.Controls.Buttons.GradientButton prev_btn;
        private Anyo.WindowsForms.Controls.Buttons.GradientButton firstPage_btn;
        private Anyo.WindowsForms.Controls.Buttons.GradientButton lastPage_btn;
        private System.Windows.Forms.Label currentPageBox;
    }
}
