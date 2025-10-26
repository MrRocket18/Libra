
namespace ProjectLIB
{
    partial class MenuLib
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
            this.label1 = new System.Windows.Forms.Label();
            this.NameLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ResultLabel = new System.Windows.Forms.Label();
            this.ExitButton = new System.Windows.Forms.Button();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.BooksTabControl = new System.Windows.Forms.TabControl();
            this.BooksTabPage = new System.Windows.Forms.TabPage();
            this.SearchTextBox = new System.Windows.Forms.TextBox();
            this.BackButton = new System.Windows.Forms.Button();
            this.SearchButton = new System.Windows.Forms.Button();
            this.PrintButton = new System.Windows.Forms.Button();
            this.DeleteBookButton = new System.Windows.Forms.Button();
            this.EditBookDataButton = new System.Windows.Forms.Button();
            this.ReturnBookbutton = new System.Windows.Forms.Button();
            this.GiveOutBooksButton = new System.Windows.Forms.Button();
            this.addBooksbutton = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ReadersTabPage = new System.Windows.Forms.TabPage();
            this.SearchReadersTextBox = new System.Windows.Forms.TextBox();
            this.BackButton2 = new System.Windows.Forms.Button();
            this.SearchReadersButton = new System.Windows.Forms.Button();
            this.dataGridViewUsers = new System.Windows.Forms.DataGridView();
            this.ResultsLabelReaders = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.BooksTabControl.SuspendLayout();
            this.BooksTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.ReadersTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUsers)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 24);
            this.label1.TabIndex = 8;
            this.label1.Text = "Библиотекарь:";
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Location = new System.Drawing.Point(186, 23);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(177, 24);
            this.NameLabel.TabIndex = 9;
            this.NameLabel.Text = "Имя пользователя";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(1019, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(227, 24);
            this.label3.TabIndex = 12;
            this.label3.Text = "Найдено совпадений:";
            // 
            // ResultLabel
            // 
            this.ResultLabel.AutoSize = true;
            this.ResultLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ResultLabel.Location = new System.Drawing.Point(1252, 71);
            this.ResultLabel.Name = "ResultLabel";
            this.ResultLabel.Size = new System.Drawing.Size(21, 24);
            this.ResultLabel.TabIndex = 13;
            this.ResultLabel.Text = "0";
            // 
            // ExitButton
            // 
            this.ExitButton.BackColor = System.Drawing.Color.Red;
            this.ExitButton.Location = new System.Drawing.Point(1420, 4);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(108, 43);
            this.ExitButton.TabIndex = 14;
            this.ExitButton.Text = "Выйти";
            this.ExitButton.UseVisualStyleBackColor = false;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // BooksTabControl
            // 
            this.BooksTabControl.Controls.Add(this.BooksTabPage);
            this.BooksTabControl.Controls.Add(this.ReadersTabPage);
            this.BooksTabControl.Location = new System.Drawing.Point(0, 50);
            this.BooksTabControl.Name = "BooksTabControl";
            this.BooksTabControl.SelectedIndex = 0;
            this.BooksTabControl.Size = new System.Drawing.Size(1539, 676);
            this.BooksTabControl.TabIndex = 15;
            // 
            // BooksTabPage
            // 
            this.BooksTabPage.BackColor = System.Drawing.Color.White;
            this.BooksTabPage.Controls.Add(this.SearchTextBox);
            this.BooksTabPage.Controls.Add(this.BackButton);
            this.BooksTabPage.Controls.Add(this.ResultLabel);
            this.BooksTabPage.Controls.Add(this.SearchButton);
            this.BooksTabPage.Controls.Add(this.label3);
            this.BooksTabPage.Controls.Add(this.PrintButton);
            this.BooksTabPage.Controls.Add(this.DeleteBookButton);
            this.BooksTabPage.Controls.Add(this.EditBookDataButton);
            this.BooksTabPage.Controls.Add(this.ReturnBookbutton);
            this.BooksTabPage.Controls.Add(this.GiveOutBooksButton);
            this.BooksTabPage.Controls.Add(this.addBooksbutton);
            this.BooksTabPage.Controls.Add(this.dataGridView1);
            this.BooksTabPage.Location = new System.Drawing.Point(4, 33);
            this.BooksTabPage.Name = "BooksTabPage";
            this.BooksTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.BooksTabPage.Size = new System.Drawing.Size(1531, 639);
            this.BooksTabPage.TabIndex = 0;
            this.BooksTabPage.Text = "Книги";
            // 
            // SearchTextBox
            // 
            this.SearchTextBox.Location = new System.Drawing.Point(8, 131);
            this.SearchTextBox.Name = "SearchTextBox";
            this.SearchTextBox.Size = new System.Drawing.Size(981, 29);
            this.SearchTextBox.TabIndex = 30;
            // 
            // BackButton
            // 
            this.BackButton.Location = new System.Drawing.Point(1149, 121);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(114, 39);
            this.BackButton.TabIndex = 29;
            this.BackButton.Text = "назад";
            this.BackButton.UseVisualStyleBackColor = true;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // SearchButton
            // 
            this.SearchButton.Location = new System.Drawing.Point(1014, 121);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(105, 39);
            this.SearchButton.TabIndex = 28;
            this.SearchButton.Text = "поиск";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // PrintButton
            // 
            this.PrintButton.BackColor = System.Drawing.Color.Chartreuse;
            this.PrintButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PrintButton.Location = new System.Drawing.Point(433, 16);
            this.PrintButton.Margin = new System.Windows.Forms.Padding(4);
            this.PrintButton.Name = "PrintButton";
            this.PrintButton.Size = new System.Drawing.Size(108, 108);
            this.PrintButton.TabIndex = 27;
            this.PrintButton.Text = "Печать";
            this.PrintButton.UseVisualStyleBackColor = false;
            this.PrintButton.Click += new System.EventHandler(this.PrintButton_Click);
            // 
            // DeleteBookButton
            // 
            this.DeleteBookButton.BackColor = System.Drawing.Color.Red;
            this.DeleteBookButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DeleteBookButton.Location = new System.Drawing.Point(730, 16);
            this.DeleteBookButton.Margin = new System.Windows.Forms.Padding(4);
            this.DeleteBookButton.Name = "DeleteBookButton";
            this.DeleteBookButton.Size = new System.Drawing.Size(119, 108);
            this.DeleteBookButton.TabIndex = 24;
            this.DeleteBookButton.Text = "Списать книгу";
            this.DeleteBookButton.UseVisualStyleBackColor = false;
            this.DeleteBookButton.Click += new System.EventHandler(this.DeleteBookButton_Click);
            // 
            // EditBookDataButton
            // 
            this.EditBookDataButton.BackColor = System.Drawing.Color.Yellow;
            this.EditBookDataButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EditBookDataButton.Location = new System.Drawing.Point(560, 16);
            this.EditBookDataButton.Margin = new System.Windows.Forms.Padding(4);
            this.EditBookDataButton.Name = "EditBookDataButton";
            this.EditBookDataButton.Size = new System.Drawing.Size(147, 108);
            this.EditBookDataButton.TabIndex = 23;
            this.EditBookDataButton.Text = "Изменить данные книг";
            this.EditBookDataButton.UseVisualStyleBackColor = false;
            this.EditBookDataButton.Click += new System.EventHandler(this.EditBookDataButton_Click);
            // 
            // ReturnBookbutton
            // 
            this.ReturnBookbutton.BackColor = System.Drawing.Color.Chartreuse;
            this.ReturnBookbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ReturnBookbutton.Location = new System.Drawing.Point(306, 16);
            this.ReturnBookbutton.Margin = new System.Windows.Forms.Padding(4);
            this.ReturnBookbutton.Name = "ReturnBookbutton";
            this.ReturnBookbutton.Size = new System.Drawing.Size(108, 108);
            this.ReturnBookbutton.TabIndex = 22;
            this.ReturnBookbutton.Text = "Вернуть книгу";
            this.ReturnBookbutton.UseVisualStyleBackColor = false;
            this.ReturnBookbutton.Click += new System.EventHandler(this.ReturnBookbutton_Click);
            // 
            // GiveOutBooksButton
            // 
            this.GiveOutBooksButton.BackColor = System.Drawing.Color.Chartreuse;
            this.GiveOutBooksButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GiveOutBooksButton.Location = new System.Drawing.Point(158, 16);
            this.GiveOutBooksButton.Margin = new System.Windows.Forms.Padding(4);
            this.GiveOutBooksButton.Name = "GiveOutBooksButton";
            this.GiveOutBooksButton.Size = new System.Drawing.Size(121, 108);
            this.GiveOutBooksButton.TabIndex = 21;
            this.GiveOutBooksButton.Text = "Выдать книги";
            this.GiveOutBooksButton.UseVisualStyleBackColor = false;
            this.GiveOutBooksButton.Click += new System.EventHandler(this.GiveOutBooksButton_Click);
            // 
            // addBooksbutton
            // 
            this.addBooksbutton.BackColor = System.Drawing.Color.Chartreuse;
            this.addBooksbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addBooksbutton.Location = new System.Drawing.Point(8, 16);
            this.addBooksbutton.Margin = new System.Windows.Forms.Padding(4);
            this.addBooksbutton.Name = "addBooksbutton";
            this.addBooksbutton.Size = new System.Drawing.Size(123, 108);
            this.addBooksbutton.TabIndex = 20;
            this.addBooksbutton.Text = "Добавить книги";
            this.addBooksbutton.UseVisualStyleBackColor = false;
            this.addBooksbutton.Click += new System.EventHandler(this.addBooksbutton_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(8, 183);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1514, 454);
            this.dataGridView1.TabIndex = 19;
            // 
            // ReadersTabPage
            // 
            this.ReadersTabPage.BackColor = System.Drawing.Color.White;
            this.ReadersTabPage.Controls.Add(this.ResultsLabelReaders);
            this.ReadersTabPage.Controls.Add(this.label4);
            this.ReadersTabPage.Controls.Add(this.SearchReadersTextBox);
            this.ReadersTabPage.Controls.Add(this.BackButton2);
            this.ReadersTabPage.Controls.Add(this.SearchReadersButton);
            this.ReadersTabPage.Controls.Add(this.dataGridViewUsers);
            this.ReadersTabPage.Location = new System.Drawing.Point(4, 33);
            this.ReadersTabPage.Name = "ReadersTabPage";
            this.ReadersTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.ReadersTabPage.Size = new System.Drawing.Size(1531, 639);
            this.ReadersTabPage.TabIndex = 1;
            this.ReadersTabPage.Text = "Читатели";
            // 
            // SearchReadersTextBox
            // 
            this.SearchReadersTextBox.Location = new System.Drawing.Point(8, 71);
            this.SearchReadersTextBox.Name = "SearchReadersTextBox";
            this.SearchReadersTextBox.Size = new System.Drawing.Size(981, 29);
            this.SearchReadersTextBox.TabIndex = 34;
            // 
            // BackButton2
            // 
            this.BackButton2.Location = new System.Drawing.Point(1149, 61);
            this.BackButton2.Name = "BackButton2";
            this.BackButton2.Size = new System.Drawing.Size(114, 39);
            this.BackButton2.TabIndex = 33;
            this.BackButton2.Text = "назад";
            this.BackButton2.UseVisualStyleBackColor = true;
            this.BackButton2.Click += new System.EventHandler(this.BackButton2_Click);
            // 
            // SearchReadersButton
            // 
            this.SearchReadersButton.Location = new System.Drawing.Point(1014, 61);
            this.SearchReadersButton.Name = "SearchReadersButton";
            this.SearchReadersButton.Size = new System.Drawing.Size(105, 39);
            this.SearchReadersButton.TabIndex = 32;
            this.SearchReadersButton.Text = "поиск";
            this.SearchReadersButton.UseVisualStyleBackColor = true;
            this.SearchReadersButton.Click += new System.EventHandler(this.SearchReadersButton_Click);
            // 
            // dataGridViewUsers
            // 
            this.dataGridViewUsers.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewUsers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewUsers.Location = new System.Drawing.Point(8, 123);
            this.dataGridViewUsers.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridViewUsers.Name = "dataGridViewUsers";
            this.dataGridViewUsers.RowHeadersWidth = 51;
            this.dataGridViewUsers.RowTemplate.Height = 24;
            this.dataGridViewUsers.Size = new System.Drawing.Size(1514, 454);
            this.dataGridViewUsers.TabIndex = 31;
            // 
            // ResultsLabelReaders
            // 
            this.ResultsLabelReaders.AutoSize = true;
            this.ResultsLabelReaders.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ResultsLabelReaders.Location = new System.Drawing.Point(1243, 18);
            this.ResultsLabelReaders.Name = "ResultsLabelReaders";
            this.ResultsLabelReaders.Size = new System.Drawing.Size(21, 24);
            this.ResultsLabelReaders.TabIndex = 36;
            this.ResultsLabelReaders.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(1010, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(227, 24);
            this.label4.TabIndex = 35;
            this.label4.Text = "Найдено совпадений:";
            // 
            // MenuLib
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1540, 727);
            this.Controls.Add(this.BooksTabControl);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MenuLib";
            this.Text = "Form1";
            this.BooksTabControl.ResumeLayout(false);
            this.BooksTabPage.ResumeLayout(false);
            this.BooksTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ReadersTabPage.ResumeLayout(false);
            this.ReadersTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUsers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label ResultLabel;
        private System.Windows.Forms.Button ExitButton;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.TabControl BooksTabControl;
        private System.Windows.Forms.TabPage BooksTabPage;
        private System.Windows.Forms.TextBox SearchTextBox;
        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.Button PrintButton;
        private System.Windows.Forms.Button DeleteBookButton;
        private System.Windows.Forms.Button EditBookDataButton;
        private System.Windows.Forms.Button ReturnBookbutton;
        private System.Windows.Forms.Button GiveOutBooksButton;
        private System.Windows.Forms.Button addBooksbutton;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TabPage ReadersTabPage;
        private System.Windows.Forms.TextBox SearchReadersTextBox;
        private System.Windows.Forms.Button BackButton2;
        private System.Windows.Forms.Button SearchReadersButton;
        private System.Windows.Forms.DataGridView dataGridViewUsers;
        public System.Windows.Forms.Label ResultsLabelReaders;
        private System.Windows.Forms.Label label4;
    }
}