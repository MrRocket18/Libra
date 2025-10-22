using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;

namespace ProjectLIB
{
    
        public class DB
        {
            MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=root;database=libraryuniversity;");
            public string connectionString { get; set; }
            public void openConnection()
            {
                if (connection.State == System.Data.ConnectionState.Closed)
                {
                    connection.Open();
                }
            }
            public void closeConnection()
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }

            public MySqlConnection getConnection()
            {
                return connection;
            }


        public void AddBook(Book book)
        {
            try
            {
                openConnection();
                connection = getConnection();
                Console.WriteLine(book.Faculty);
                Console.WriteLine(book.Specialty);
                Console.WriteLine(book.Subject);
                // Создаем команду для вызова хранимой процедуры
                using (MySqlCommand command = new MySqlCommand("sp_add_book", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Добавляем параметры процедуры
                    command.Parameters.AddWithValue("p_name", MySqlHelper.EscapeString(book.Title));
                    command.Parameters.AddWithValue("p_year", book.PublicationYear);
                    command.Parameters.AddWithValue("p_place", MySqlHelper.EscapeString(book.Place));

                    // Теперь передаем названия, а не ID
                    command.Parameters.AddWithValue("p_faculty_name", book.Faculty);
                    command.Parameters.AddWithValue("p_specialty_name", book.Specialty);
                    command.Parameters.AddWithValue("p_subject_name", book.Subject);

                    command.Parameters.AddWithValue("p_authors_temp", MySqlHelper.EscapeString(book.Author));

                    // Выполняем процедуру
                    command.ExecuteNonQuery();
                    Console.WriteLine($"Книга \"{book.Title}\" успешно добавлена.");
                }

                closeConnection();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Ошибка MySQL при добавлении книги: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла общая ошибка: {ex.Message}");
                throw;
            }
        }

        public void MarkBookAsPrinted(int bookId, byte[] qrCodeBytes)
        {


            string updateSql = "UPDATE books SET IsPrinted = TRUE WHERE BookId = @BookId;";

            try
            {
                openConnection();
                using (MySqlCommand command = new MySqlCommand(updateSql, getConnection()))
                {
                    command.Parameters.AddWithValue("@BookId", bookId);


                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected == 0)
                    {
                        Console.WriteLine($"Предупреждение: Книга с ID {bookId} не найдена для маркировки как напечатанной.");
                    }
                    else
                    {
                        Console.WriteLine($"Книга с ID {bookId} успешно помечена как напечатанная и QR-код сохранен.");
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"MySQL Error in MarkBookAsPrinted (BookId: {bookId}): {ex.Message}");
                throw;
            }
            finally
            {
                closeConnection();
            }
        }
        public Book GetBookById(int bookId)
        {
            Book book = null;
            string selectSql = @"
            SELECT
                b.bookID, 
                b.name, 
                b.year, 
                b.status, 
                b.place,
                b.faculty_id, 
                
                b.specialty_id, 
                
                b.subject_id, 
       
                b.IsPrinted,
                GROUP_CONCAT(a.author ORDER BY a.id_au SEPARATOR ', ') AS authors
            FROM 
                books b
            LEFT JOIN 
                authors_of_books ao ON b.bookID = ao.id_book
            LEFT JOIN 
                authors a ON a.id_au IN (
                    ao.first_au_id, 
                    ao.second_au_id, 
                    ao.third_au_id, 
                    ao.fourth_au_id, 
                    ao.fifth_au_id, 
                    ao.sixth_au_id, 
                    ao.seventh_au_id, 
                    ao.eighth_au_id, 
                    ao.ninth_au_id, 
                    ao.tenth_au_id
                ) AND a.id_au > 0 
            WHERE b.bookID = @BookId
            GROUP BY 
                b.bookID, 
                b.name, 
                b.year, 
                b.status, 
                b.place,
                b.faculty_id, 
                
                b.specialty_id, 
                
                b.subject_id, 
                
                b.IsPrinted;";

            try
            {
                openConnection();
                using (MySqlCommand command = new MySqlCommand(selectSql, getConnection()))
                {
                    command.Parameters.AddWithValue("@BookId", bookId);
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                           
                            int id = reader.GetInt32("bookID");
                            string title = reader.GetString("name");
                            string author = reader.GetString("authors");
                            int year = reader.GetInt32("year");
                            string place = reader["place"].ToString();
                            int status = reader.GetInt32("status");
                            int? faculty_id = reader["faculty_id"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["faculty_id"]);
                            int? specialty_id  = reader["specialty_id"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["specialty_id"]);
                            int? subject_id = reader["subject_id"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["subject_id"]);
                            bool isPrinted = reader.GetBoolean("IsPrinted");

                            book = new Book(id,title, author, year,place,faculty_id,specialty_id,subject_id,status) 
                            {
              
                                IsPrinted = isPrinted,
 
                            };
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"MySQL Error in GetBookById (BookId: {bookId}): {ex.Message}");
                throw;
            }
            finally
            {
                closeConnection();
            }
            return book; 
        }
        public List<Book> GetAllBooksWithQrDetails()
        {
            List<Book> books = new List<Book>();
            
            string query = @"
            SELECT
                b.bookID, 
                b.name, 
                b.year, 
                b.status, 
                b.place,
                b.faculty_id, 
                f.faculty_name,
                b.specialty_id, 
                s.specialty_name,
                b.subject_id, 
                sub.subject_name,
                b.IsPrinted,
                GROUP_CONCAT(a.author ORDER BY a.id_au SEPARATOR ', ') AS authors
            FROM 
                books b
            LEFT JOIN 
                faculties f ON b.faculty_id = f.faculty_id
            LEFT JOIN 
                specialties s ON b.specialty_id = s.specialty_id
            LEFT JOIN 
                subjects sub ON b.subject_id = sub.subject_id
            LEFT JOIN 
                authors_of_books ao ON b.bookID = ao.id_book
            LEFT JOIN 
                authors a ON a.id_au IN (
                    ao.first_au_id, 
                    ao.second_au_id, 
                    ao.third_au_id, 
                    ao.fourth_au_id, 
                    ao.fifth_au_id, 
                    ao.sixth_au_id, 
                    ao.seventh_au_id, 
                    ao.eighth_au_id, 
                    ao.ninth_au_id, 
                    ao.tenth_au_id
                ) AND a.id_au > 0  
            GROUP BY 
                b.bookID, 
                b.name, 
                b.year, 
                b.status, 
                b.place,
                b.faculty_id, 
                f.faculty_name,
                b.specialty_id, 
                s.specialty_name,
                b.subject_id, 
                sub.subject_name,
                b.IsPrinted;";

            openConnection();
            using (MySqlCommand command = new MySqlCommand(query, getConnection()))
            {
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    foreach (DataRow row in dataTable.Rows)
                    {
                        books.Add(new Book
                        {
                            BookId = Convert.ToInt32(row["bookID"]),
                            Title = row["name"].ToString(),
                            Author = row["authors"].ToString(),
                            PublicationYear = Convert.ToInt32(row["year"]),
                            Place = row["place"].ToString(),

                            FacultyId = Convert.ToInt32(row["faculty_id"]),
                            SpecialtyId = Convert.ToInt32(row["specialty_id"]),
                            SubjectId = Convert.ToInt32(row["subject_id"]),

                            Faculty = row["faculty_name"] != DBNull.Value ? row["faculty_name"].ToString() : string.Empty,
                            Specialty = row["specialty_name"] != DBNull.Value ? row["specialty_name"].ToString() : string.Empty,
                            Subject = row["subject_name"] != DBNull.Value ? row["subject_name"].ToString() : string.Empty,

                            status = Convert.ToInt32(row["status"]),
                            IsPrinted = Convert.ToBoolean(row["IsPrinted"])
                        });
                    }
                }
            }
            return books;
           
        }
        public bool UpdateBook(int bookId, string title, string author, int year, string place, string facultyName, string specialtyName, string subjectName)
        {

            string query = @"
            UPDATE books
            SET name = @title,
                author = @author,
                year = @year,
                place = @place,
                faculty_id = (SELECT faculty_id FROM faculties WHERE faculty_name = @FacultyName),
                specialty_id = (SELECT specialty_id FROM specialties WHERE specialty_name = @SpecialtyName),
                subject_id = (SELECT subject_id FROM subjects WHERE subject_name = @SubjectName)
            WHERE bookID = @bookId";

            try
            {
                openConnection();
                using (MySqlCommand command = new MySqlCommand(query, getConnection()))
                {
                    command.Parameters.AddWithValue("@bookId", bookId);
                    command.Parameters.AddWithValue("@title", title);
                    command.Parameters.AddWithValue("@author", author);
                    command.Parameters.AddWithValue("@year", year);
                    command.Parameters.AddWithValue("@place", place);
                    command.Parameters.AddWithValue("@FacultyName", facultyName);
                    command.Parameters.AddWithValue("@SpecialtyName", specialtyName);
                    command.Parameters.AddWithValue("@SubjectName", subjectName);


                    int rowsAffected = command.ExecuteNonQuery();
                    closeConnection();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при обновлении книги с ID {bookId}: {ex.Message}");
                return false;
            }
        }
        public bool DeleteBook(int bookId)
        {
            string deleteQuery = "DELETE FROM books WHERE bookID = @book_id";
            try
            {
                openConnection();
                using (MySqlCommand deleteCommand = new MySqlCommand(deleteQuery, getConnection()))
                {
                    deleteCommand.Parameters.AddWithValue("@book_id", bookId); 
                    int rowsAffected = deleteCommand.ExecuteNonQuery();
                    closeConnection();
                    return rowsAffected > 0; 
                }
                
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Ошибка MySQL при удалении книги с ID {bookId}: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Неизвестная ошибка при выполнении запроса на удаление книги с ID {bookId}: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public bool InsertIssuedBook( int bookId, int userId)
        {
            string query = "INSERT INTO issued_books (bookID, userID, issue_date) VALUES (@book_id, @user_id, @issue_date)";
            try
            {   
                openConnection();
                using (MySqlCommand command = new MySqlCommand(query, getConnection()))
                {
                    command.Parameters.AddWithValue("@book_id", bookId);
                    command.Parameters.AddWithValue("@user_id", userId);
                    command.Parameters.AddWithValue("@issue_date", DateTime.Now);
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении записи о выдаче книги: {ex.Message}");
                return false;
            }
            finally { closeConnection(); }
        }

        public (string FullName, string Group) GetFullNameAndGroupById(int userId)
        {
            string fullName = null;
            string group = null;
            try
            {
                openConnection();
                string query = "SELECT first_name, last_name, middle_name, `group` FROM users WHERE id = @user_id";
                using (MySqlCommand command = new MySqlCommand(query, getConnection()))
                {
                    command.Parameters.AddWithValue("@user_id", userId);
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string firstName = reader["first_name"].ToString();
                            string lastName = reader["last_name"].ToString();
                            string middleName = reader["middle_name"] == DBNull.Value ? string.Empty : reader["middle_name"].ToString();
                            fullName = $"{firstName} {lastName} {middleName}";
                            group = reader["group"].ToString();
                            Console.WriteLine(fullName, group);

                        }
                    }
                }
                
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return (null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Неизвестная ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return (null, null);
            }
            finally { closeConnection(); }
            return (fullName, group);
        }
        public bool UpdateIssuedBook(int bookId)
        {

            openConnection();
            string returnQuery = "UPDATE issued_books SET return_date = @return_date WHERE bookID = @book_id AND return_date IS NULL";
            using (MySqlCommand returnCommand = new MySqlCommand(returnQuery, getConnection()))
            {
                returnCommand.Parameters.AddWithValue("@book_id", bookId);
                returnCommand.Parameters.AddWithValue("@return_date", DateTime.Now);
                int rowsAffected = returnCommand.ExecuteNonQuery();
                if (rowsAffected == 0)
                {
                    closeConnection();
                    throw new Exception($"Не удалось обновить запись о возврате для книги ID {bookId}. Возможно, она уже была возвращена или не найдена в выданных.");
                }
            }
            closeConnection();
            return true;
        }
    }

}
