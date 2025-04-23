
namespace ProjectLIB
{
    partial class GiveOutBooks
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
            this.GiveOutBooksLabel = new System.Windows.Forms.Label();
            this.BackButton = new System.Windows.Forms.Button();
            this.GiveOutBooksbutton = new System.Windows.Forms.Button();
            this.IdReaderLabel = new System.Windows.Forms.Label();
            this.IDReaderTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // GiveOutBooksLabel
            // 
            this.GiveOutBooksLabel.AutoSize = true;
            this.GiveOutBooksLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GiveOutBooksLabel.Location = new System.Drawing.Point(311, 51);
            this.GiveOutBooksLabel.Name = "GiveOutBooksLabel";
            this.GiveOutBooksLabel.Size = new System.Drawing.Size(145, 24);
            this.GiveOutBooksLabel.TabIndex = 0;
            this.GiveOutBooksLabel.Text = "Выдача книги";
            // 
            // BackButton
            // 
            this.BackButton.BackColor = System.Drawing.Color.Red;
            this.BackButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BackButton.Location = new System.Drawing.Point(70, 365);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(95, 57);
            this.BackButton.TabIndex = 1;
            this.BackButton.Text = "Отмена";
            this.BackButton.UseVisualStyleBackColor = false;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // GiveOutBooksbutton
            // 
            this.GiveOutBooksbutton.BackColor = System.Drawing.Color.Chartreuse;
            this.GiveOutBooksbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GiveOutBooksbutton.Location = new System.Drawing.Point(604, 365);
            this.GiveOutBooksbutton.Name = "GiveOutBooksbutton";
            this.GiveOutBooksbutton.Size = new System.Drawing.Size(127, 58);
            this.GiveOutBooksbutton.TabIndex = 2;
            this.GiveOutBooksbutton.Text = "Выдать книгу";
            this.GiveOutBooksbutton.UseVisualStyleBackColor = false;
            this.GiveOutBooksbutton.Click += new System.EventHandler(this.GiveOutBooksbutton_Click);
            // 
            // IdReaderLabel
            // 
            this.IdReaderLabel.AutoSize = true;
            this.IdReaderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.IdReaderLabel.Location = new System.Drawing.Point(66, 201);
            this.IdReaderLabel.Name = "IdReaderLabel";
            this.IdReaderLabel.Size = new System.Drawing.Size(114, 24);
            this.IdReaderLabel.TabIndex = 3;
            this.IdReaderLabel.Text = "ID читателя";
            // 
            // IDReaderTextBox
            // 
            this.IDReaderTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.IDReaderTextBox.Location = new System.Drawing.Point(253, 201);
            this.IDReaderTextBox.Name = "IDReaderTextBox";
            this.IDReaderTextBox.Size = new System.Drawing.Size(310, 29);
            this.IDReaderTextBox.TabIndex = 4;
            // 
            // GiveOutBooks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.IDReaderTextBox);
            this.Controls.Add(this.IdReaderLabel);
            this.Controls.Add(this.GiveOutBooksbutton);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.GiveOutBooksLabel);
            this.Name = "GiveOutBooks";
            this.Text = "GiveOutBooks";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label GiveOutBooksLabel;
        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.Button GiveOutBooksbutton;
        private System.Windows.Forms.Label IdReaderLabel;
        private System.Windows.Forms.TextBox IDReaderTextBox;
    }
}