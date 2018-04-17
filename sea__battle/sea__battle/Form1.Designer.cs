namespace sea__battle
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
        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.small_button = new System.Windows.Forms.Button();
            this.midle_button = new System.Windows.Forms.Button();
            this.big_button = new System.Windows.Forms.Button();
            this.biggest_button = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button6 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button7 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // small_button
            // 
            this.small_button.Location = new System.Drawing.Point(234, 408);
            this.small_button.Name = "small_button";
            this.small_button.Size = new System.Drawing.Size(68, 29);
            this.small_button.TabIndex = 6;
            this.small_button.Text = "Small(1)";
            this.small_button.UseVisualStyleBackColor = true;
            this.small_button.Click += new System.EventHandler(this.Boat_Click);
            // 
            // midle_button
            // 
            this.midle_button.Location = new System.Drawing.Point(160, 408);
            this.midle_button.Name = "midle_button";
            this.midle_button.Size = new System.Drawing.Size(68, 29);
            this.midle_button.TabIndex = 5;
            this.midle_button.Text = "Midle(2)";
            this.midle_button.UseVisualStyleBackColor = true;
            this.midle_button.Click += new System.EventHandler(this.Boat_Click);
            // 
            // big_button
            // 
            this.big_button.Location = new System.Drawing.Point(86, 408);
            this.big_button.Name = "big_button";
            this.big_button.Size = new System.Drawing.Size(68, 29);
            this.big_button.TabIndex = 4;
            this.big_button.Text = "Big(3)";
            this.big_button.UseVisualStyleBackColor = true;
            this.big_button.Click += new System.EventHandler(this.Boat_Click);
            // 
            // biggest_button
            // 
            this.biggest_button.Location = new System.Drawing.Point(12, 408);
            this.biggest_button.Name = "biggest_button";
            this.biggest_button.Size = new System.Drawing.Size(68, 29);
            this.biggest_button.TabIndex = 3;
            this.biggest_button.Text = "Biggest(4)";
            this.biggest_button.UseVisualStyleBackColor = true;
            this.biggest_button.Click += new System.EventHandler(this.Boat_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.DodgerBlue;
            this.pictureBox2.Location = new System.Drawing.Point(399, 42);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(351, 351);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox2_Paint);
            this.pictureBox2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox2_MouseDown);
            this.pictureBox2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox2_MouseUp);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.DodgerBlue;
            this.pictureBox1.Location = new System.Drawing.Point(12, 42);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(352, 351);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(603, 408);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(55, 29);
            this.button6.TabIndex = 7;
            this.button6.Text = "Vertical";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.vertical_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(664, 408);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(69, 29);
            this.button1.TabIndex = 8;
            this.button1.Text = "Horizontal";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.horizontal_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(481, 406);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 31);
            this.label1.TabIndex = 9;
            this.label1.Text = "Horizontal";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.LawnGreen;
            this.button7.Location = new System.Drawing.Point(348, 408);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 29);
            this.button7.TabIndex = 10;
            this.button7.Text = "Start";
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.Start_Clicked);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(767, 461);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.small_button);
            this.Controls.Add(this.midle_button);
            this.Controls.Add(this.big_button);
            this.Controls.Add(this.biggest_button);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }
        
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button biggest_button;
        private System.Windows.Forms.Button big_button;
        private System.Windows.Forms.Button midle_button;
        private System.Windows.Forms.Button small_button;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button7;
    }
}

