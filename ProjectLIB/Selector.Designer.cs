
namespace ProjectLIB
{
    partial class Selector
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
            this.facultiesСomboBox = new System.Windows.Forms.ComboBox();
            this.specialtiesСomboBox = new System.Windows.Forms.ComboBox();
            this.subjectsСomboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.BackButton = new System.Windows.Forms.Button();
            this.AddBooksbutton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // facultiesСomboBox
            // 
            this.facultiesСomboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.facultiesСomboBox.FormattingEnabled = true;
            this.facultiesСomboBox.Location = new System.Drawing.Point(266, 124);
            this.facultiesСomboBox.Name = "facultiesСomboBox";
            this.facultiesСomboBox.Size = new System.Drawing.Size(528, 37);
            this.facultiesСomboBox.TabIndex = 0;
            this.facultiesСomboBox.SelectedIndexChanged += new System.EventHandler(this.facultiesСomboBox_SelectedIndexChanged);
            // 
            // specialtiesСomboBox
            // 
            this.specialtiesСomboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.specialtiesСomboBox.FormattingEnabled = true;
            this.specialtiesСomboBox.Location = new System.Drawing.Point(266, 202);
            this.specialtiesСomboBox.Name = "specialtiesСomboBox";
            this.specialtiesСomboBox.Size = new System.Drawing.Size(528, 37);
            this.specialtiesСomboBox.TabIndex = 1;
            this.specialtiesСomboBox.SelectedIndexChanged += new System.EventHandler(this.specialtiesСomboBox_SelectedIndexChanged);
            // 
            // subjectsСomboBox
            // 
            this.subjectsСomboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.subjectsСomboBox.FormattingEnabled = true;
            this.subjectsСomboBox.Location = new System.Drawing.Point(266, 307);
            this.subjectsСomboBox.Name = "subjectsСomboBox";
            this.subjectsСomboBox.Size = new System.Drawing.Size(528, 37);
            this.subjectsСomboBox.TabIndex = 2;
            this.subjectsСomboBox.SelectedIndexChanged += new System.EventHandler(this.subjectsСomboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(27, 127);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 29);
            this.label1.TabIndex = 3;
            this.label1.Text = "Факультет";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(27, 210);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(196, 29);
            this.label2.TabIndex = 4;
            this.label2.Text = "Специальность";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(27, 307);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 29);
            this.label3.TabIndex = 5;
            this.label3.Text = "Предмет";
            // 
            // BackButton
            // 
            this.BackButton.BackColor = System.Drawing.Color.Red;
            this.BackButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BackButton.ForeColor = System.Drawing.Color.Black;
            this.BackButton.Location = new System.Drawing.Point(48, 459);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(95, 45);
            this.BackButton.TabIndex = 6;
            this.BackButton.Text = "Назад";
            this.BackButton.UseVisualStyleBackColor = false;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // AddBooksbutton
            // 
            this.AddBooksbutton.BackColor = System.Drawing.Color.Chartreuse;
            this.AddBooksbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddBooksbutton.Location = new System.Drawing.Point(605, 459);
            this.AddBooksbutton.Name = "AddBooksbutton";
            this.AddBooksbutton.Size = new System.Drawing.Size(189, 45);
            this.AddBooksbutton.TabIndex = 7;
            this.AddBooksbutton.Text = "Добавить книги";
            this.AddBooksbutton.UseVisualStyleBackColor = false;
            this.AddBooksbutton.Click += new System.EventHandler(this.AddBooksbutton_Click);
            // 
            // Selector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(714, 424);
            this.Controls.Add(this.AddBooksbutton);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.subjectsСomboBox);
            this.Controls.Add(this.specialtiesСomboBox);
            this.Controls.Add(this.facultiesСomboBox);
            this.Name = "Selector";
            this.Text = "Selector";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox facultiesСomboBox;
        private System.Windows.Forms.ComboBox specialtiesСomboBox;
        private System.Windows.Forms.ComboBox subjectsСomboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BackButton;
        public System.Windows.Forms.Button AddBooksbutton;
    }
}