
namespace ProjectLIB
{
    partial class ChangeData
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
            this.title = new System.Windows.Forms.Label();
            this.Backbutton = new System.Windows.Forms.Button();
            this.ChangeDatabutton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.titletextBox = new System.Windows.Forms.TextBox();
            this.authortextBox = new System.Windows.Forms.TextBox();
            this.yeartextBox = new System.Windows.Forms.TextBox();
            this.placetextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.title.Location = new System.Drawing.Point(100, 85);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(153, 24);
            this.title.TabIndex = 0;
            this.title.Text = "Название книги";
            // 
            // Backbutton
            // 
            this.Backbutton.BackColor = System.Drawing.Color.Red;
            this.Backbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Backbutton.Location = new System.Drawing.Point(104, 364);
            this.Backbutton.Name = "Backbutton";
            this.Backbutton.Size = new System.Drawing.Size(99, 69);
            this.Backbutton.TabIndex = 1;
            this.Backbutton.Text = "Назад";
            this.Backbutton.UseVisualStyleBackColor = false;
            this.Backbutton.Click += new System.EventHandler(this.Backbutton_Click);
            // 
            // ChangeDatabutton
            // 
            this.ChangeDatabutton.BackColor = System.Drawing.Color.Chartreuse;
            this.ChangeDatabutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ChangeDatabutton.Location = new System.Drawing.Point(641, 364);
            this.ChangeDatabutton.Name = "ChangeDatabutton";
            this.ChangeDatabutton.Size = new System.Drawing.Size(183, 69);
            this.ChangeDatabutton.TabIndex = 2;
            this.ChangeDatabutton.Text = "Внести изменения";
            this.ChangeDatabutton.UseVisualStyleBackColor = false;
            this.ChangeDatabutton.Click += new System.EventHandler(this.addBooksbutton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(100, 135);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 24);
            this.label1.TabIndex = 3;
            this.label1.Text = "Автор";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(100, 200);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 24);
            this.label2.TabIndex = 4;
            this.label2.Text = "Год выпуска";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(100, 268);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(195, 24);
            this.label3.TabIndex = 5;
            this.label3.Text = "Место в бибилотеке";
            // 
            // titletextBox
            // 
            this.titletextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.titletextBox.Location = new System.Drawing.Point(421, 80);
            this.titletextBox.Name = "titletextBox";
            this.titletextBox.Size = new System.Drawing.Size(391, 29);
            this.titletextBox.TabIndex = 7;
            // 
            // authortextBox
            // 
            this.authortextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.authortextBox.Location = new System.Drawing.Point(421, 130);
            this.authortextBox.Name = "authortextBox";
            this.authortextBox.Size = new System.Drawing.Size(391, 29);
            this.authortextBox.TabIndex = 8;
            // 
            // yeartextBox
            // 
            this.yeartextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.yeartextBox.Location = new System.Drawing.Point(421, 195);
            this.yeartextBox.Name = "yeartextBox";
            this.yeartextBox.Size = new System.Drawing.Size(391, 29);
            this.yeartextBox.TabIndex = 9;
            // 
            // placetextBox
            // 
            this.placetextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.placetextBox.Location = new System.Drawing.Point(421, 263);
            this.placetextBox.Name = "placetextBox";
            this.placetextBox.Size = new System.Drawing.Size(391, 29);
            this.placetextBox.TabIndex = 10;
            // 
            // ChangeData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(894, 520);
            this.Controls.Add(this.placetextBox);
            this.Controls.Add(this.yeartextBox);
            this.Controls.Add(this.authortextBox);
            this.Controls.Add(this.titletextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ChangeDatabutton);
            this.Controls.Add(this.Backbutton);
            this.Controls.Add(this.title);
            this.Name = "ChangeData";
            this.Text = "ChangeData";
            this.Load += new System.EventHandler(this.AddBooks_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Button Backbutton;
        private System.Windows.Forms.Button ChangeDatabutton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox titletextBox;
        private System.Windows.Forms.TextBox authortextBox;
        private System.Windows.Forms.TextBox yeartextBox;
        private System.Windows.Forms.TextBox placetextBox;
    }
}