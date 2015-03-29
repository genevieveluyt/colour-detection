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
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.btnGetImage = new System.Windows.Forms.Button();
            this.labelFileName = new System.Windows.Forms.Label();
            this.btnPrevImg = new System.Windows.Forms.Button();
            this.btnNextImg = new System.Windows.Forms.Button();
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
            // txtOutput
            // 
            this.txtOutput.Location = new System.Drawing.Point(434, 12);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ReadOnly = true;
            this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtOutput.Size = new System.Drawing.Size(280, 167);
            this.txtOutput.TabIndex = 3;
            // 
            // txtFileName
            // 
            this.txtFileName.Location = new System.Drawing.Point(432, 234);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(282, 20);
            this.txtFileName.TabIndex = 4;
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
            // labelFileName
            // 
            this.labelFileName.AutoSize = true;
            this.labelFileName.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFileName.Location = new System.Drawing.Point(431, 208);
            this.labelFileName.Name = "labelFileName";
            this.labelFileName.Size = new System.Drawing.Size(183, 15);
            this.labelFileName.TabIndex = 7;
            this.labelFileName.Text = "File name (in resources folder):";
            // 
            // btnPrevImg
            // 
            this.btnPrevImg.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrevImg.Location = new System.Drawing.Point(644, 273);
            this.btnPrevImg.Name = "btnPrevImg";
            this.btnPrevImg.Size = new System.Drawing.Size(29, 30);
            this.btnPrevImg.TabIndex = 8;
            this.btnPrevImg.Text = "<";
            this.btnPrevImg.UseVisualStyleBackColor = true;
            this.btnPrevImg.Click += new System.EventHandler(this.btnPrevImg_Click);
            // 
            // btnNextImg
            // 
            this.btnNextImg.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNextImg.Location = new System.Drawing.Point(675, 273);
            this.btnNextImg.Name = "btnNextImg";
            this.btnNextImg.Size = new System.Drawing.Size(29, 30);
            this.btnNextImg.TabIndex = 9;
            this.btnNextImg.Text = ">";
            this.btnNextImg.UseVisualStyleBackColor = true;
            this.btnNextImg.Click += new System.EventHandler(this.btnNextImg_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(729, 322);
            this.Controls.Add(this.btnNextImg);
            this.Controls.Add(this.btnPrevImg);
            this.Controls.Add(this.labelFileName);
            this.Controls.Add(this.btnGetImage);
            this.Controls.Add(this.txtFileName);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.imgImage);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Emgu.CV.UI.ImageBox imgImage;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.Button btnGetImage;
        private System.Windows.Forms.Label labelFileName;
        private System.Windows.Forms.Button btnPrevImg;
        private System.Windows.Forms.Button btnNextImg;
    }
}

