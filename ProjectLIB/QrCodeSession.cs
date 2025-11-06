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
    public partial class QrCodeSession : Form

    {
        private Book Book_info = new Book();
        private DB _db = new DB();
        public QrCodeSession(Book book_info)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            InfoBookTextBox.ReadOnly = true;
            Book_info = book_info;
            InfoBookTextBox.Text = $"ID: {book_info.BookId}{Environment.NewLine}" +
                                  $"Название: {book_info.Title}{Environment.NewLine}" +
                                  $"Автор: {book_info.Author}{Environment.NewLine}" +
                                  $"Год: {book_info.PublicationYear}";
            if (book_info.status == 0)
            {
                ReturnButton.Visible = false;
            }
            if (book_info.status == 1)
            {
                GiveOutButton.Visible = false;
            }
            if (book_info.status == 2)
            {
                DecommissButton.Visible = false;
            }
        }

        private void GiveOutButton_Click(object sender, EventArgs e)
        {
            List<int> books = new List<int> { Book_info.BookId };
            GiveOutBooks book = new GiveOutBooks(books);
            book.ShowDialog();
            ReturnButton.Visible = true;
            GiveOutButton.Visible = false;
        }

        private void ReturnButton_Click(object sender, EventArgs e)
        {
            if (_db.UpdateIssuedBook(Book_info.BookId)) 
            {
                MessageBox.Show("Книга успешно возвращена");
                ReturnButton.Visible = false;
                GiveOutButton.Visible = true;
            }
            else
            {
                MessageBox.Show("Ошибка при возвращении");
            }
        }

        private void DecommissButton_Click(object sender, EventArgs e)
        {
            DeleteBook book = new DeleteBook(Book_info.BookId);
            book.ShowDialog();
            DecommissButton.Visible = false;
        }
        private void QrCodeSession_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }
    }
}
