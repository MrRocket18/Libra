
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.addBooksbutton = new System.Windows.Forms.Button();
            this.FindBooksbutton = new System.Windows.Forms.Button();
            this.FindReadersbutton = new System.Windows.Forms.Button();
            this.GiveOutBooksButton = new System.Windows.Forms.Button();
            this.ReturnBookbutton = new System.Windows.Forms.Button();
            this.EditBookDataButton = new System.Windows.Forms.Button();
            this.DeleteBookButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.NameLabel = new System.Windows.Forms.Label();
            this.comboBoxTableType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ResultLabel = new System.Windows.Forms.Label();
            this.ExitButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(16, 177);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1514, 520);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // addBooksbutton
            // 
            this.addBooksbutton.BackColor = System.Drawing.Color.Chartreuse;
            this.addBooksbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addBooksbutton.Location = new System.Drawing.Point(320, 61);
            this.addBooksbutton.Margin = new System.Windows.Forms.Padding(4);
            this.addBooksbutton.Name = "addBooksbutton";
            this.addBooksbutton.Size = new System.Drawing.Size(123, 108);
            this.addBooksbutton.TabIndex = 1;
            this.addBooksbutton.Text = "Добавить книгу";
            this.addBooksbutton.UseVisualStyleBackColor = false;
            this.addBooksbutton.Click += new System.EventHandler(this.addBooksbutton_Click);
            // 
            // FindBooksbutton
            // 
            this.FindBooksbutton.BackColor = System.Drawing.Color.Chartreuse;
            this.FindBooksbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FindBooksbutton.Location = new System.Drawing.Point(10, 61);
            this.FindBooksbutton.Margin = new System.Windows.Forms.Padding(4);
            this.FindBooksbutton.Name = "FindBooksbutton";
            this.FindBooksbutton.Size = new System.Drawing.Size(108, 108);
            this.FindBooksbutton.TabIndex = 2;
            this.FindBooksbutton.Text = "Поиск по книгам";
            this.FindBooksbutton.UseVisualStyleBackColor = false;
            this.FindBooksbutton.Click += new System.EventHandler(this.FindBooksbutton_Click);
            // 
            // FindReadersbutton
            // 
            this.FindReadersbutton.BackColor = System.Drawing.Color.Chartreuse;
            this.FindReadersbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FindReadersbutton.Location = new System.Drawing.Point(136, 61);
            this.FindReadersbutton.Margin = new System.Windows.Forms.Padding(4);
            this.FindReadersbutton.Name = "FindReadersbutton";
            this.FindReadersbutton.Size = new System.Drawing.Size(121, 108);
            this.FindReadersbutton.TabIndex = 3;
            this.FindReadersbutton.Text = "Поиск по читателям";
            this.FindReadersbutton.UseVisualStyleBackColor = false;
            this.FindReadersbutton.Click += new System.EventHandler(this.FindReadersbutton_Click);
            // 
            // GiveOutBooksButton
            // 
            this.GiveOutBooksButton.BackColor = System.Drawing.Color.Chartreuse;
            this.GiveOutBooksButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GiveOutBooksButton.Location = new System.Drawing.Point(470, 61);
            this.GiveOutBooksButton.Margin = new System.Windows.Forms.Padding(4);
            this.GiveOutBooksButton.Name = "GiveOutBooksButton";
            this.GiveOutBooksButton.Size = new System.Drawing.Size(121, 108);
            this.GiveOutBooksButton.TabIndex = 4;
            this.GiveOutBooksButton.Text = "Выдать книги";
            this.GiveOutBooksButton.UseVisualStyleBackColor = false;
            this.GiveOutBooksButton.Click += new System.EventHandler(this.GiveOutBooksButton_Click);
            // 
            // ReturnBookbutton
            // 
            this.ReturnBookbutton.BackColor = System.Drawing.Color.Chartreuse;
            this.ReturnBookbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ReturnBookbutton.Location = new System.Drawing.Point(618, 61);
            this.ReturnBookbutton.Margin = new System.Windows.Forms.Padding(4);
            this.ReturnBookbutton.Name = "ReturnBookbutton";
            this.ReturnBookbutton.Size = new System.Drawing.Size(108, 108);
            this.ReturnBookbutton.TabIndex = 5;
            this.ReturnBookbutton.Text = "Вернуть книгу";
            this.ReturnBookbutton.UseVisualStyleBackColor = false;
            this.ReturnBookbutton.Click += new System.EventHandler(this.ReturnBookbutton_Click);
            // 
            // EditBookDataButton
            // 
            this.EditBookDataButton.BackColor = System.Drawing.Color.Yellow;
            this.EditBookDataButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EditBookDataButton.Location = new System.Drawing.Point(1170, 61);
            this.EditBookDataButton.Margin = new System.Windows.Forms.Padding(4);
            this.EditBookDataButton.Name = "EditBookDataButton";
            this.EditBookDataButton.Size = new System.Drawing.Size(147, 108);
            this.EditBookDataButton.TabIndex = 6;
            this.EditBookDataButton.Text = "Изменить данные книги";
            this.EditBookDataButton.UseVisualStyleBackColor = false;
            this.EditBookDataButton.Click += new System.EventHandler(this.EditBookDataButton_Click);
            // 
            // DeleteBookButton
            // 
            this.DeleteBookButton.BackColor = System.Drawing.Color.Red;
            this.DeleteBookButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DeleteBookButton.Location = new System.Drawing.Point(1399, 61);
            this.DeleteBookButton.Margin = new System.Windows.Forms.Padding(4);
            this.DeleteBookButton.Name = "DeleteBookButton";
            this.DeleteBookButton.Size = new System.Drawing.Size(119, 108);
            this.DeleteBookButton.TabIndex = 7;
            this.DeleteBookButton.Text = "Удалить книгу";
            this.DeleteBookButton.UseVisualStyleBackColor = false;
            this.DeleteBookButton.Click += new System.EventHandler(this.DeleteBookButton_Click);
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
            // comboBoxTableType
            // 
            this.comboBoxTableType.FormattingEnabled = true;
            this.comboBoxTableType.Location = new System.Drawing.Point(769, 100);
            this.comboBoxTableType.Name = "comboBoxTableType";
            this.comboBoxTableType.Size = new System.Drawing.Size(167, 32);
            this.comboBoxTableType.TabIndex = 10;
            this.comboBoxTableType.SelectedIndexChanged += new System.EventHandler(this.comboBoxTableType_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(769, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 24);
            this.label2.TabIndex = 11;
            this.label2.Text = "Фильтр";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(946, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(227, 24);
            this.label3.TabIndex = 12;
            this.label3.Text = "Найдено совпадений:";
            // 
            // ResultLabel
            // 
            this.ResultLabel.AutoSize = true;
            this.ResultLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ResultLabel.Location = new System.Drawing.Point(1179, 23);
            this.ResultLabel.Name = "ResultLabel";
            this.ResultLabel.Size = new System.Drawing.Size(21, 24);
            this.ResultLabel.TabIndex = 13;
            this.ResultLabel.Text = "0";
            // 
            // ExitButton
            // 
            this.ExitButton.BackColor = System.Drawing.Color.Red;
            this.ExitButton.Location = new System.Drawing.Point(618, 11);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(108, 36);
            this.ExitButton.TabIndex = 14;
            this.ExitButton.Text = "Выйти";
            this.ExitButton.UseVisualStyleBackColor = false;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // MenuLib
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1540, 727);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.ResultLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxTableType);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DeleteBookButton);
            this.Controls.Add(this.EditBookDataButton);
            this.Controls.Add(this.ReturnBookbutton);
            this.Controls.Add(this.GiveOutBooksButton);
            this.Controls.Add(this.FindReadersbutton);
            this.Controls.Add(this.FindBooksbutton);
            this.Controls.Add(this.addBooksbutton);
            this.Controls.Add(this.dataGridView1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MenuLib";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button addBooksbutton;
        private System.Windows.Forms.Button FindBooksbutton;
        private System.Windows.Forms.Button FindReadersbutton;
        private System.Windows.Forms.Button GiveOutBooksButton;
        private System.Windows.Forms.Button ReturnBookbutton;
        private System.Windows.Forms.Button EditBookDataButton;
        private System.Windows.Forms.Button DeleteBookButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.ComboBox comboBoxTableType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label ResultLabel;
        private System.Windows.Forms.Button ExitButton;
    }
}