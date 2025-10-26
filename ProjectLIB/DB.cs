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
                using (MySqlCommand command = new MySqlCommand("sp_add_book", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("p_name", MySqlHelper.EscapeString(book.Title));
                    command.Parameters.AddWithValue("p_year", book.PublicationYear);
                    command.Parameters.AddWithValue("p_place", MySqlHelper.EscapeString(book.Place));
                    command.Parameters.AddWithValue("p_faculty_name", book.Faculty);
                    command.Parameters.AddWithValue("p_specialty_name", book.Specialty);
                    command.Parameters.AddWithValue("p_subject_name", book.Subject);
                    command.Parameters.AddWithValue("p_authors_temp", MySqlHelper.EscapeString(book.Author));
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

        public void MarkBookAsPrinted(int bookId)
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
                authors a ON a.id_au = ao.au_id 
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
                authors a ON a.id_au = ao.au_id
            WHERE b.status < 1
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

            try
            {
                openConnection();
                connection = getConnection();
                using (MySqlCommand command = new MySqlCommand("sp_update_book", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("p_book_id", bookId);
                    command.Parameters.AddWithValue("p_name", MySqlHelper.EscapeString(title));
                    command.Parameters.AddWithValue("p_year", year);
                    command.Parameters.AddWithValue("p_place", MySqlHelper.EscapeString(place));
                    command.Parameters.AddWithValue("p_faculty_name", facultyName);
                    command.Parameters.AddWithValue("p_specialty_name", specialtyName);
                    command.Parameters.AddWithValue("p_subject_name", subjectName);
                    command.Parameters.AddWithValue("p_authors_temp", MySqlHelper.EscapeString(author));
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
        public bool DeleteBook(int bookId, string reason)
        {
            string query = "INSERT INTO decommissioned_books (bookID, reason, decommissioned_date) VALUES (@book_id, @reason, @decommissioned_date)";
            try
            {
                openConnection();
                using (MySqlCommand command = new MySqlCommand(query, getConnection()))
                {
                    command.Parameters.AddWithValue("@book_id", bookId);
                    command.Parameters.AddWithValue("@reason", reason);
                    command.Parameters.AddWithValue("@decommissioned_date", DateTime.Now);
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении записи о списании книги: {ex.Message}");
                return false;
            }
            finally { closeConnection(); }
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
        public List<Book> Search(string searchTerm)
        {
                string sqlQuery = @"
                SELECT
                    b.bookID,
                    b.name AS book_name,
                    b.year,
                    b.place,
                    b.IsPrinted,
                    b.status,

                    s.subject_id,
                    s.subject_name,
    
                    sp.specialty_id,
                    sp.specialty_name,
    
                    f.faculty_id,
                    f.faculty_name,

                    GROUP_CONCAT(a.author ORDER BY a.author SEPARATOR ', ') AS authors
                FROM
                    libraryuniversity.books AS b
                LEFT JOIN
                    libraryuniversity.subjects AS s ON b.subject_id = s.subject_id
                LEFT JOIN
                    libraryuniversity.specialties AS sp ON b.specialty_id = sp.specialty_id
                LEFT JOIN
                    libraryuniversity.faculties AS f ON b.faculty_id = f.faculty_id    
                LEFT JOIN
                    libraryuniversity.authors_of_books AS aob ON b.bookID = aob.id_book
                LEFT JOIN
                    libraryuniversity.authors AS a ON aob.au_id = a.id_au
                WHERE
                    b.name LIKE @search_term OR
                    b.place LIKE @search_term OR
                    s.subject_name LIKE @search_term OR
                    CAST(b.year AS CHAR) LIKE @search_term OR
                    a.author LIKE @search_term
                GROUP BY
                    b.bookID, b.name, b.year, b.place, b.IsPrinted, b.status,
                    s.subject_id, s.subject_name, sp.specialty_id, sp.specialty_name, f.faculty_id, f.faculty_name;
                        ";
                openConnection();
            List<Book> searchResults = new List<Book>();
            using (MySqlCommand cmd = new MySqlCommand(sqlQuery,getConnection()))
                {
             
                    cmd.Parameters.AddWithValue("@search_term", "%" + MySqlHelper.EscapeString(searchTerm) + "%");  //Добавляем символы подстановки для поиска

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        

                        while (reader.Read())
                        {
                            
                            Book book = new Book
                            {

                                BookId = reader.GetInt32("bookID"),
                                Title = reader.GetString("book_name"), 
                                PublicationYear = reader.GetInt32("year"),
                                Place = reader.GetString("place"),
                                IsPrinted = reader.GetBoolean("IsPrinted"),
                                status = reader.GetInt32("status"),

                                SubjectId =  reader.GetInt32("subject_id"),
                                Subject =  reader.GetString("subject_name"),

                                SpecialtyId =  reader.GetInt32("specialty_id"),
                                Specialty = reader.GetString("specialty_name"),

                                FacultyId =  reader.GetInt32("faculty_id"),
                                Faculty = reader.GetString("faculty_name"),

                                Author = reader.GetString("authors"),
                            };

                            searchResults.Add(book);
                        }
                    }
                }
                return searchResults;
            
        }

        public  List<User> GetUsers()
        {
            List<User> userList = new List<User>();
            string sqlQuery = @"
                SELECT
                    u.id AS user_id,
                    u.first_name,
                    u.last_name,
                    u.middle_name,
                    u.role,
                    g.name AS group_name
                FROM
                    libraryuniversity.users AS u
                LEFT JOIN
                    libraryuniversity.groups AS g ON u.group = g.id
                WHERE u.role = 0
               ;";
            openConnection();
                using (MySqlCommand cmd = new MySqlCommand(sqlQuery, getConnection()))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            User user = new User
                            {
                                Id = reader.GetInt32("user_id"),
                                First_name = reader.GetString("first_name"),
                                Last_name = reader.GetString("last_name"),
                                Middle_name = reader.GetString("middle_name"),
                                Group =  reader.GetString("group_name")
                            };

                            userList.Add(user);
                        }
                    }
                }
            return userList;
        }
        public List<User> SearchUsers(string searchTerm)
        {
            List<User> userList = new List<User>();
            string sqlQuery = @"
            SELECT
                u.id AS user_id,
                u.first_name,
                u.last_name,
                u.middle_name,
                g.name AS group_name
            FROM
                libraryuniversity.users AS u
            LEFT JOIN
                libraryuniversity.groups AS g ON u.group = g.id
            WHERE
                (u.first_name LIKE @search_term OR
                u.last_name LIKE @search_term OR
                u.middle_name LIKE @search_term OR
                g.name LIKE @search_term) AND role = 0
            ;";

            openConnection();

                using (MySqlCommand cmd = new MySqlCommand(sqlQuery, getConnection()))
                {
                    cmd.Parameters.AddWithValue("@search_term", "%" + MySqlHelper.EscapeString(searchTerm) + "%");

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            User user = new User
                            {
                                Id = reader.GetInt32("user_id"),
                                First_name = reader.GetString("first_name"),
                                Last_name = reader.GetString("last_name"),
                                Middle_name = reader.GetString("middle_name"),
                                Group = reader.GetString("group_name")
                            };

                            userList.Add(user);
                        }
                    }
               }
            

            return userList;
        }
    }

}
