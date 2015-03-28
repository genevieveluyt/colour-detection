namespace Polygon_Detection
{
    partial class Form1
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.imgImage = new Emgu.CV.UI.ImageBox();
            this.txtResults = new System.Windows.Forms.TextBox();
            this.txtImagePath = new System.Windows.Forms.TextBox();
            this.btnGetImage = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.imgImage)).BeginInit();
            this.SuspendLayout();
            // 
            // imgImage
            // 
            this.imgImage.Location = new System.Drawing.Point(54, 38);
            this.imgImage.Name = "imgImage";
            this.imgImage.Size = new System.Drawing.Size(282, 206);
            this.imgImage.TabIndex = 2;
            this.imgImage.TabStop = false;
            // 
            // txtResults
            // 
            this.txtResults.Location = new System.Drawing.Point(376, 38);
            this.txtResults.Multiline = true;
            this.txtResults.Name = "txtResults";
            this.txtResults.ReadOnly = true;
            this.txtResults.Size = new System.Drawing.Size(267, 206);
            this.txtResults.TabIndex = 3;
            // 
            // txtImagePath
            // 
            this.txtImagePath.Location = new System.Drawing.Point(54, 298);
            this.txtImagePath.Name = "txtImagePath";
            this.txtImagePath.Size = new System.Drawing.Size(282, 20);
            this.txtImagePath.TabIndex = 4;
            // 
            // btnGetImage
            // 
            this.btnGetImage.Location = new System.Drawing.Point(375, 292);
            this.btnGetImage.Name = "btnGetImage";
            this.btnGetImage.Size = new System.Drawing.Size(119, 31);
            this.btnGetImage.TabIndex = 5;
            this.btnGetImage.Text = "Get Image";
            this.btnGetImage.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(679, 478);
            this.Controls.Add(this.btnGetImage);
            this.Controls.Add(this.txtImagePath);
            this.Controls.Add(this.txtResults);
            this.Controls.Add(this.imgImage);
            this.Name = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.imgImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Emgu.CV.UI.ImageBox imgImage;
        private System.Windows.Forms.TextBox txtResults;
        private System.Windows.Forms.TextBox txtImagePath;
        private System.Windows.Forms.Button btnGetImage;
    }
}

