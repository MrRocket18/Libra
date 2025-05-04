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
    public partial class AddBooks : Form
    {
        public AddBooks()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void AddBooks_Load(object sender, EventArgs e)
        {

        }

        private void Backbutton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
            "Вы точно хотите выйти?. Введенные данные не сохранятся.",
            "Сообщение",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Information,
            MessageBoxDefaultButton.Button1);
            if (result == DialogResult.Yes)
            {
                
                this.Close();
            }
                

        }

        private void addBooksbutton_Click(object sender, EventArgs e)
        {
            try
            {
                string title = titletextBox.Text; //1
                string author = authortextBox.Text; //1
                string place = placetextBox.Text; //1


                int year = int.Parse(yeartextBox.Text); //1 
                int count = int.Parse(counttextBox.Text); //1

                Selector select = new Selector(); 
                BooksInteraction books = new BooksInteraction();
                select.ShowDialog();
                if (select.status) //2
                {
                    List<int> IDs = books.AddBooks(title, author, place, count, year, select.FacultyId, select.SpecialtyId, select.SubjectId); //3
                    if (IDs.Count != 0) //4
                    {
                        string message = "Книги успешно добавлены! ID добавленных книг:\n" + string.Join(", ", IDs); //5
                        MessageBox.Show(message, "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    this.Close();//6
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Пожалуйста, введите корректные значения для года и количества (целые числа).", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); //7
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); //8
            } 

        }

    }

}
