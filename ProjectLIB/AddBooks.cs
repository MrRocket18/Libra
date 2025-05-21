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
                string title = titletextBox.Text; 
                string author = authortextBox.Text; 
                string place = placetextBox.Text; 


                int year = int.Parse(yeartextBox.Text);
                
                int count = int.Parse(counttextBox.Text);

                if (count <= DateTime.Today.Year)
                {
                    if ((count <= 60) && (year >= 1)) 
                    {
                        Selector select = new Selector();
                        BooksInteraction books = new BooksInteraction();
                        select.ShowDialog();
                        if (select.status)
                        {
                            List<int> IDs = books.AddBooks(title, author, place, count, year, select.FacultyId, select.SpecialtyId, select.SubjectId); //3
                            if (IDs.Count != 0)
                            {
                                string message = "Книги успешно добавлены! ID добавленных книг:\n" + string.Join(", ", IDs);
                                MessageBox.Show(message, "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            this.Close();
                        }
                    }
                    MessageBox.Show("Пожалуйста, введите корректные значения для количества книг (от 1 до 60).", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                MessageBox.Show("Пожалуйста, введите корректные значения для года (Не больше текущего года).", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            catch (FormatException)
            {
                MessageBox.Show("Пожалуйста, введите корректные значения для года и количества (целые числа).", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); 
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); 
            } 

        }

    }

}
