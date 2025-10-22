using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;

namespace ProjectLIB
{
    public partial class GiveOutBooks : Form
    {
        private List<int> _books = null;
        private DB _db = new DB();
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

            try
            {
                bool operationSuccessful = false;
                int userId = int.Parse(IDReaderTextBox.Text.Trim());
                (string full_name, string group) = _db.GetFullNameAndGroupById(userId);
                if (!int.TryParse(IDReaderTextBox.Text.Trim(), out userId))
                {
                    MessageBox.Show("Пожалуйста, введите корректный ID пользователя.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (full_name == null && group == null)
                {
                    MessageBox.Show($"Пользователь с ID {userId}, {full_name},{group} не найден.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                List<Book> booksInfo = new List<Book>();
                StringBuilder confirmationMessage = new StringBuilder();
                confirmationMessage.AppendLine($"Вы уверены, что хотите выдать следующие книги:\n");

                foreach (int bookId in _books)
                {
                    Book book = _db.GetBookById(bookId);
                    if (book == null)
                    {
                        MessageBox.Show($"Книга с ID {bookId} не найдена. Операция будет отменена.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (book.status == 1)
                    {
                        MessageBox.Show($"Книга с ID {bookId} ({book.Title}) уже выдана. Операция будет отменена.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    booksInfo.Add(book);
                    confirmationMessage.AppendLine($"  ID: {book.BookId}, Название: {book.Title}, Автор: {book.Author}, Год: {book.PublicationYear}");
                }

                confirmationMessage.AppendLine($"\nЧитателю: {full_name} из группы {group}");

                DialogResult result = MessageBox.Show(confirmationMessage.ToString(), "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    foreach (Book bookToIssue in booksInfo) 
                    {

                        if (!_db.InsertIssuedBook( bookToIssue.BookId, userId))
                        {
                            throw new Exception($"Не удалось добавить запись о выдаче книги ID {bookToIssue.BookId}.");
                        }
                    }
                    operationSuccessful = true;
                    if (operationSuccessful)
                    {
                        MessageBox.Show($"Все выбранные книги успешно выданы пользователю с ID {userId}.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        _books = null;
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Выдача книг отменена.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
