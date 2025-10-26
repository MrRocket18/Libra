using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;
namespace ProjectLIB
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int PublicationYear { get; set; }
        public string Place { get; set; }
        public string Faculty { get; set; }
        public string Specialty { get; set; }
        public string Subject { get; set; }
        public int? FacultyId { get; set; }
        public int? SpecialtyId { get; set; }
        public int? SubjectId { get; set; }
        public bool IsPrinted { get; set; }
        public int status { get; set; }
        public byte[] QrCodeImageBytes { get; set; }
        public string QrCodeStatus { get; set; }
        public Book() { }

        DB db = new DB();

        public Book( string title, string author, int publicationYear,string place, string faculty, string specialty, string subject)
        {
            Title = title;
            Author = author;
            PublicationYear = publicationYear;
            Place = place;
            Faculty = faculty;
            Specialty = specialty;
            Subject = subject;
        }
        public Book(int bookId, string title, string author, int publicationYear, string place, int? facultyId, int? specialtyId, int? subjectId,int Status)
        {
            BookId = bookId;
            Title = title;
            Author = author;
            PublicationYear = publicationYear;
            Place = place;
            status = Status;
            FacultyId = facultyId;
            SpecialtyId = specialtyId;
            SubjectId = subjectId;
        }
        public  string GetStatusBook()
        {
            if (status == 0) {
                return "Не выдана";
            }
            else if (status == 1)
            {
                return "Выдана";
            }
            return "0";
        }
       
        public void SearchBooksAndDisplay(string searchTerm, DataGridView dataGridView, Label ResultLabel)
        {
            try
            {

                    db.openConnection();
                    MySqlConnection connection = db.getConnection();
                    
                    bool isIdSearch = int.TryParse(searchTerm, out int bookId);

                    
                    string query = @"
                    SELECT bookID, name, author, year, status, place, faculty_id, specialty_id, subject_id
                    FROM books
                    WHERE ";

                    if (isIdSearch)
                    {
                        query += "bookID = @searchTerm";
                    }
                    else if (!string.IsNullOrEmpty(searchTerm))
                    {
                        query += "name LIKE @searchTerm"; 
                    }
                    else
                    {
                        
                        MessageBox.Show("Введите ID или название книги для поиска.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dataGridView.DataSource = null; 
                        return;
                    }

                   
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        
                        if (isIdSearch)
                        {
                            command.Parameters.AddWithValue("@searchTerm", bookId);
                        }
                        else if (!string.IsNullOrEmpty(searchTerm))
                        {
                            command.Parameters.AddWithValue("@searchTerm", "%" + searchTerm + "%"); 
                        }

                        
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();

                            
                            adapter.Fill(dataTable);

                            
                            dataGridView.DataSource = dataTable;
                            
                            ResultLabel.Text = dataTable.Rows.Count.ToString();

                        }
                    }
                
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Ошибка базы данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine($"Ошибка базы данных: {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Неизвестная ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine($"Неизвестная ошибка: {ex.Message}");
            }
        }
    }
}
