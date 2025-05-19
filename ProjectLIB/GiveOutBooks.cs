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
    public partial class GiveOutBooks : Form
    {
        public List<int> _books = null;
        public GiveOutBooks(List <int> books)
        {
            InitializeComponent();
            _books = books;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GiveOutBooksbutton_Click(object sender, EventArgs e)
        {
            BooksInteraction givebooks = new BooksInteraction();
            try
            {
                int readerID = int.Parse(IDReaderTextBox.Text);
                for (int i = 1; i <= _books.Count; i++)
                {
                    if (givebooks.IssueBook(_books[i - 1], readerID))
                    {
                        Book book_info = new Book();
                        User user_info = new User();
                        book_info = book_info.GetBookById(_books[i - 1]);
                        (string full_name, string group) = user_info.GetFullNameAndGroupById(readerID);
                        string message = $"Книга\n ID: {book_info.BookId}\n Название: {book_info.Title}\n Автор: {book_info.Author}\n Год выпуска: {book_info.PublicationYear}\n" +
                            $"Была выдана читателю: {full_name} из группы {group}";
                        MessageBox.Show(message, "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
                this.Close();

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
