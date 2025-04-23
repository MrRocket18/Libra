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
    public partial class DeleteBook : Form
    {
        public DeleteBook()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            BooksInteraction book = new BooksInteraction();
            try
            {
                int BookID = int.Parse(BookIDtextBox.Text);
                if (book.DeleteBook(BookID))
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

        private void Backbutton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
