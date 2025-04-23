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

        public int? FacultyId { get; set; }
        public int? SpecialtyId { get; set; }
        public int? SubjectId { get; set; }
        public Book() { }

        DB db = new DB();

        public Book(int bookId, string title, string author, int publicationYear,string place)
        {
            BookId = bookId;
            Title = title;
            Author = author;
            PublicationYear = publicationYear;
            Place = place;
        }
        public Book(int bookId, string title, string author, int publicationYear, string place, int? facultyId, int? specialtyId, int? subjectId)
        : this(bookId, title, author, publicationYear, place) 
        {
            FacultyId = facultyId;
            SpecialtyId = specialtyId;
            SubjectId = subjectId;
        }
        public override bool Equals(object obj)
        {
            
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            
            Book otherBook = (Book)obj;

            
            return 
                   Title == otherBook.Title &&
                   Author == otherBook.Author &&
                   PublicationYear == otherBook.PublicationYear &&
                   Place == otherBook.Place &&
                   FacultyId == otherBook.FacultyId &&
                   SpecialtyId == otherBook.SpecialtyId &&
                   SubjectId == otherBook.SubjectId;
        }


        public Book GetBookById(int bookId)
        {
            Book book = null;  

            try
            {

                    db.openConnection();
                    MySqlConnection connection = db.getConnection();
                   

                    
                    string query = @"
                    SELECT bookID, name, author, year, place, faculty_id, specialty_id, subject_id
                    FROM books
                    WHERE bookID = @bookId";

                    
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        
                        command.Parameters.AddWithValue("@bookId", bookId);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                           
                            if (reader.Read())
                            {
                                
                                book = new Book(
                                    Convert.ToInt32(reader["bookID"]),
                                    reader["name"].ToString(),
                                    reader["author"].ToString(),
                                    Convert.ToInt32(reader["year"]),
                                    reader["place"].ToString(),
                                    reader["faculty_id"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["faculty_id"]),
                                    reader["specialty_id"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["specialty_id"]),
                                    reader["subject_id"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["subject_id"])
                                );
                            }
                        }
                    }
                
            }
            catch (MySqlException ex)
            {
                
                MessageBox.Show($"Ошибка при получении информации о книге: {ex.Message}",
                                 "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null; 
            }
            catch (Exception ex)
            {
                
                MessageBox.Show($"Неизвестная ошибка при получении информации о книге: {ex.Message}",
                                 "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null; 
            }

            return book; 
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
