namespace Matrix
{
    ///----------------------------------------------------------------------------------------------------------------
    /// <inheritdoc />
    partial class Form1
    {
        ///------------------------------------------------------------------------------------------------------------
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        ///------------------------------------------------------------------------------------------------------------
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

        #region Windows Form Designer generated code
        ///------------------------------------------------------------------------------------------------------------
        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            //// 
            //// Form1 (Main frame)
            //// 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            // Size of the window in pixels
            this.ClientSize = new System.Drawing.Size(
                Consts.WIDTH_OF_APPLICATION_WINDOW, Consts.HEIGHT_OF_APPLICATION_WINDOW
                );
            this.Name = "Matrix";
            this.Text = "Matrix";
            // Maximize the window, aka fullscreen
            WindowState = System.Windows.Forms.FormWindowState.Maximized;
            // Hide the borders of the window
            FormBorderStyle = FormBorderStyle.None;
            // Set the background color to black
            this.BackColor = System.Drawing.Color.Black;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
        }
        #endregion
    }
}
