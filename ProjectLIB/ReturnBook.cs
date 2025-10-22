using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;

namespace ProjectLIB
{
    public partial class ReturnBook : Form
    {
        private DB _db = new DB();
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
                int bookID = 0;
                bool operationSuccessful = false;

                if (!int.TryParse(BookIDtextBox.Text.Trim(), out int bookId))
                {
                    MessageBox.Show("Пожалуйста, введите корректный ID книги для возврата.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    bookID = int.Parse(BookIDtextBox.Text);
                }
                Book book_info = _db.GetBookById(bookID);

                if (book_info == null)
                {
                    MessageBox.Show($"Ошибка при получении информации о книге ID {bookId}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (book_info.status == 1)
                {
                    string message = $"Вы уверены, что хотите вернуть эту книгу?\n" +
                         $"ID: {book_info.BookId}\n" +
                         $"Название: {book_info.Title}\n" +
                         $"Автор: {book_info.Author}\n" +
                         $"Год: {book_info.PublicationYear}";

                    DialogResult result = MessageBox.Show(message, "Подтверждение возврата", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes) 
                    { 

                        if (_db.UpdateIssuedBook(bookId))
                        {
                            operationSuccessful = true;
                        }
                        else
                        {
                            operationSuccessful = false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Возврат книги отменен.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else 
                {
                    MessageBox.Show($"Ошибка при получении статуса книги ID {bookId}, книга имеет статус {book_info.GetStatusBook()}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (operationSuccessful)
                {
                    this.Close();
                    MessageBox.Show($"Книга с ID {bookId} успешно возвращена!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"Произошла ошибка при возвращении книги с ID: {bookId} ", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
