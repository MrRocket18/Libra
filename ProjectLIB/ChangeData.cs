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
    public partial class ChangeData : Form

    {
        public List<int> _IDs;
        public bool status { get; set; }
        public string _title { get; set; }
        public string _author { get; set; }
        public string _place { get; set; }
        public int _year { get; set; }
        public ChangeData(List<int> Ids)
        {
            InitializeComponent();
            _IDs = Ids;
            GetInfoBooks();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void AddBooks_Load(object sender, EventArgs e)
        {

        }

        private void Backbutton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
            "Вы точно хотите выйти?. Изменённые данные не сохранятся.",
            "Сообщение",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Information,
            MessageBoxDefaultButton.Button1,
            MessageBoxOptions.DefaultDesktopOnly);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
            
        }
        private void GetInfoBooks()
        {
            Book info_book = new Book();
            info_book = info_book.GetBookById(_IDs[0]);
            titletextBox.Text = info_book.Title;
            authortextBox.Text = info_book.Author;
            placetextBox.Text = info_book.Place;
            yeartextBox.Text = info_book.PublicationYear.ToString();
        }

        private void addBooksbutton_Click(object sender, EventArgs e)
        {
            try
            {
                _title = titletextBox.Text;
                _author = authortextBox.Text;
                _place = placetextBox.Text;
                _year = int.Parse(yeartextBox.Text);
                status = true;
                this.Close();

                
            }
            catch (FormatException)
            {
                MessageBox.Show("Пожалуйста, введите корректные значения для года (целые числа).", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 

        }

    }

}
