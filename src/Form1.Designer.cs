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
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.imgImage)).BeginInit();
            this.SuspendLayout();
            // 
            // imgImage
            // 
            this.imgImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imgImage.Location = new System.Drawing.Point(12, 12);
            this.imgImage.Name = "imgImage";
            this.imgImage.Size = new System.Drawing.Size(400, 300);
            this.imgImage.TabIndex = 2;
            this.imgImage.TabStop = false;
            // 
            // txtResults
            // 
            this.txtResults.Location = new System.Drawing.Point(434, 12);
            this.txtResults.Multiline = true;
            this.txtResults.Name = "txtResults";
            this.txtResults.ReadOnly = true;
            this.txtResults.Size = new System.Drawing.Size(280, 167);
            this.txtResults.TabIndex = 3;
            // 
            // txtImagePath
            // 
            this.txtImagePath.Location = new System.Drawing.Point(432, 234);
            this.txtImagePath.Name = "txtImagePath";
            this.txtImagePath.Size = new System.Drawing.Size(282, 20);
            this.txtImagePath.TabIndex = 4;
            this.txtImagePath.Text = "rectangle-01.jpg";
            // 
            // btnGetImage
            // 
            this.btnGetImage.Location = new System.Drawing.Point(507, 273);
            this.btnGetImage.Name = "btnGetImage";
            this.btnGetImage.Size = new System.Drawing.Size(119, 31);
            this.btnGetImage.TabIndex = 5;
            this.btnGetImage.Text = "Get Image";
            this.btnGetImage.UseVisualStyleBackColor = true;
            this.btnGetImage.Click += new System.EventHandler(this.btnGetImage_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(431, 208);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "Filename (in resources folder):";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(729, 322);
            this.Controls.Add(this.label1);
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
        private System.Windows.Forms.Label label1;
    }
}

