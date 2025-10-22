using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectLIB
{
    public partial class DeleteBook : Form
    {
        private DB _db = new DB();
        public DeleteBook()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            
            try
            {
                int BookID = int.Parse(BookIDtextBox.Text);
                if (BookID <= 0)
                {
                    MessageBox.Show("Некорректный ID книги для удаления.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
                }

                Book book_info = _db.GetBookById(BookID); 
                if (book_info == null)
                {
                    MessageBox.Show($"Книга с ID {BookID} не найдена.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }

                string message = $"Вы уверены, что хотите удалить книгу?\n\n" +
                                  $"ID: {book_info.BookId}\n" +
                                  $"Название: {book_info.Title}\n" +
                                  $"Автор: {book_info.Author}\n" +
                                  $"Год: {book_info.PublicationYear}";

                DialogResult result = MessageBox.Show(message, "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    if (_db.DeleteBook(BookID))
                    {
                        MessageBox.Show($"Книга с ID {BookID} успешно удалена!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Удаление отменено.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
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
