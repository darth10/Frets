namespace Frets
{
    partial class FretControl
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
            this._drawer = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this._drawer)).BeginInit();
            this.SuspendLayout();
            // 
            // _drawer
            // 
            this._drawer.Dock = System.Windows.Forms.DockStyle.Fill;
            this._drawer.Location = new System.Drawing.Point(0, 0);
            this._drawer.Name = "_drawer";
            this._drawer.Size = new System.Drawing.Size(120, 380);
            this._drawer.TabIndex = 0;
            this._drawer.TabStop = false;
            // 
            // FretControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._drawer);
            this.MaximumSize = new System.Drawing.Size(120, 380);
            this.MinimumSize = new System.Drawing.Size(120, 380);
            this.Name = "FretControl";
            this.Size = new System.Drawing.Size(120, 380);
            ((System.ComponentModel.ISupportInitialize)(this._drawer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox _drawer;
    }
}
