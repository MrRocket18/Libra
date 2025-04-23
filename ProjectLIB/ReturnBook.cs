using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectLIB
{
    public partial class ReturnBook : Form
    {
        public ReturnBook()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

   

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ReturnBookButton_Click(object sender, EventArgs e)
        {
            BooksInteraction book = new BooksInteraction();
            try
            {
                int bookID = int.Parse(BookIDtextBox.Text);
                if (book.ReturnBook(bookID))
                {
                    this.Close();
                }

            }
            catch (FormatException)
            {
                MessageBox.Show("Пожалуйста, введите корректные значения для ID книги (целые числа).", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    
    }
}
