using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace ProjectLIB
{
    public class BooksInteraction
    {
        DB db = new DB();
        public List<int> AddBooks(string booksName, string booksAuthor, string booksPlace, int numberOfBooks, int booksYear, int FacultyId, int SpecialtyId, int SubjectId)
        {
            db.openConnection();
            MySqlConnection connection = db.getConnection();
            List<int> bookIds = new List<int>();
            for (int i = 1; i <= numberOfBooks; i++)
            {
                try
                {
                    string query = "INSERT INTO books (name, author, year, place, faculty_id, specialty_id, subject_id) " +
                                   "VALUES (@books_name, @books_author, @books_year, @books_place, @facultyId, @specialtyId, @subjectId); " +
                                   "SELECT LAST_INSERT_ID();";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@books_name", MySqlHelper.EscapeString(booksName));
                        command.Parameters.AddWithValue("@books_author", MySqlHelper.EscapeString(booksAuthor));
                        command.Parameters.AddWithValue("@books_year", booksYear);
                        command.Parameters.AddWithValue("@books_place", booksPlace);

                        command.Parameters.AddWithValue("@facultyId", FacultyId);
                        command.Parameters.AddWithValue("@specialtyId", SpecialtyId);
                        command.Parameters.AddWithValue("@subjectId", SubjectId);

                        object result = command.ExecuteScalar();

                        if (result == null || result == DBNull.Value)
                        {
                            MessageBox.Show($"Ошибка при добавлении книг в библиотеку: ID не найден!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            bookIds.Clear();
                            return bookIds;
                        }
                        int bookId = Convert.ToInt32(result);
                        bookIds.Add(Convert.ToInt32(result));
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при добавлении книг в библиотеку: '{ex}'", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    bookIds.Clear();
                    return bookIds;
                }
            }
            return bookIds;
        }
        public bool DeleteBook(int bookId)
        {
            db.openConnection();
            MySqlConnection connection = db.getConnection();
            try
            {

                if (bookId <= 0)
                {
                    MessageBox.Show("Некорректный ID книги для удаления.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                Book book_info = new Book();
                book_info = book_info.GetBookById(bookId);
                string message = $"Вы уверены, что хотите удалить книгу?\n\n" +
                                  $"ID: {book_info.BookId}\n" +
                                  $"Название: {book_info.Title}\n" +
                                  $"Автор: {book_info.Author}\n" +
                                  $"Год: {book_info.PublicationYear}"; 
                                  


                DialogResult result = MessageBox.Show(message, "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Question);


                if (result == DialogResult.Yes)
                {
                    
                    string deleteQuery = "DELETE FROM books WHERE bookID = @book_id";

                    using (MySqlCommand deleteCommand = new MySqlCommand(deleteQuery, connection))
                    {
                        deleteCommand.Parameters.AddWithValue("@book_id", bookId);

                        int rowsAffected = deleteCommand.ExecuteNonQuery();


                        if (rowsAffected > 0)
                        {
                            MessageBox.Show($"Книга с ID {bookId} успешно удалена!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return true;
                        }
                        else
                        {
                            MessageBox.Show($"Книга с ID {bookId} не найдена или не удалена.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return false;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Удаление отменено.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Ошибка при удалении книги: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Неизвестная ошибка при удалении книги: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public bool IssueBook(int bookId, int userId)
        {

            try
            {
                db.openConnection();
                MySqlConnection connection = db.getConnection();

                
                if (!BookExists(connection, bookId))
                {
                    MessageBox.Show($"Книга с ID {bookId} не найдена.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }

                
                if (!UserExists(connection, userId))
                {
                    MessageBox.Show($"Пользователь с ID {userId} не найден.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }

                
                if (IsBookIssued(connection, bookId))
                {
                    MessageBox.Show($"Книга с ID {bookId} уже выдана.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }

                Book book_info = new Book();
                book_info = book_info.GetBookById(bookId);
                User user_info = new User();
                (string full_name, string group) = user_info.GetFullNameAndGroupById(userId);
                string message = $"Вы уверены что хотите видать:\n Книга\n ID: {book_info.BookId}\n Название: {book_info.Title}\n Автор: {book_info.Author}\n Год выпуска: {book_info.PublicationYear}\n" +
                            $"Читателю: {full_name} из группы {group}";



                DialogResult result = MessageBox.Show(message, "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                MySqlTransaction transaction = null;

                if (result == DialogResult.Yes)
                {


                    try
                    {
                        transaction = connection.BeginTransaction();


                        string issueQuery = "INSERT INTO issued_books (bookID, userID, issue_date) VALUES (@book_id, @user_id, @issue_date)";
                        using (MySqlCommand issueCommand = new MySqlCommand(issueQuery, connection, transaction))
                        {
                            issueCommand.Parameters.AddWithValue("@book_id", bookId);
                            issueCommand.Parameters.AddWithValue("@user_id", userId);
                            issueCommand.Parameters.AddWithValue("@issue_date", DateTime.Now);

                            int rowsAffected = issueCommand.ExecuteNonQuery();
                            if (rowsAffected == 0)
                            {
                                throw new Exception("Не удалось добавить запись о выдаче книги.");
                            }
                        }


                        string updateStatusQuery = "UPDATE books SET status = 'Выдана' WHERE bookID = @book_id";
                        using (MySqlCommand updateStatusCommand = new MySqlCommand(updateStatusQuery, connection, transaction))
                        {
                            updateStatusCommand.Parameters.AddWithValue("@book_id", bookId);

                            int rowsAffected = updateStatusCommand.ExecuteNonQuery();
                            if (rowsAffected == 0)
                            {
                                throw new Exception("Не удалось обновить статус книги.");
                            }
                        }

                        transaction.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        if (transaction != null)
                        {
                            transaction.Rollback();
                        }
                        MessageBox.Show($"Ошибка при выдаче книги: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    finally
                    {
                        if (transaction != null)
                        {
                            transaction.Dispose();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Выдача книги отменена.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Ошибка при выдаче книги: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Неизвестная ошибка при выдаче книги: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public bool ReturnBook(int bookId)
        {
            
            {
                try
                {
                    db.openConnection();
                    MySqlConnection connection = db.getConnection();


                    if (!IsBookIssued(connection, bookId))
                    {
                        MessageBox.Show($"Книга с ID {bookId} не выдана или уже возвращена.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }

                   
                    MySqlTransaction transaction = null;
                    Book book_info = new Book();
                    book_info = book_info.GetBookById(bookId);
                    string message = $"Вы уверены, что хотите вернуть эту книгу?\n" +
                                      $"ID: {book_info.BookId}\n" +
                                      $"Название: {book_info.Title}\n" +
                                      $"Автор: {book_info.Author}\n" +
                                      $"Год: {book_info.PublicationYear}";



                    DialogResult result = MessageBox.Show(message, "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            transaction = connection.BeginTransaction();


                            string returnQuery = "UPDATE issued_books SET return_date = @return_date WHERE bookID = @book_id AND return_date IS NULL";
                            using (MySqlCommand returnCommand = new MySqlCommand(returnQuery, connection, transaction))
                            {
                                returnCommand.Parameters.AddWithValue("@book_id", bookId);
                                returnCommand.Parameters.AddWithValue("@return_date", DateTime.Now);

                                int rowsAffected = returnCommand.ExecuteNonQuery();
                                if (rowsAffected == 0)
                                {
                                    throw new Exception("Не удалось обновить запись о возврате книги.");
                                }
                            }


                            string updateStatusQuery = "UPDATE books SET status = 'Не выдана' WHERE bookID = @book_id";
                            using (MySqlCommand updateStatusCommand = new MySqlCommand(updateStatusQuery, connection, transaction))
                            {
                                updateStatusCommand.Parameters.AddWithValue("@book_id", bookId);

                                int rowsAffected = updateStatusCommand.ExecuteNonQuery();
                                if (rowsAffected == 0)
                                {
                                    throw new Exception("Не удалось обновить статус книги.");
                                }
                            }

                            transaction.Commit();
                            MessageBox.Show($"Книга с ID {bookId} успешно возвращена!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return true;
                        }
                        catch (Exception ex)
                        {
                            if (transaction != null)
                            {
                                transaction.Rollback();
                            }
                            MessageBox.Show($"Ошибка при возврате книги: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                        finally
                        {
                            if (transaction != null)
                            {
                                transaction.Dispose();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Возварт отменен.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show($"Ошибка при возврате книги: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Неизвестная ошибка при возврате книги: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }
        public  bool UpdateBook(int bookId, string newBookName, string newBookAuthor, int newBookYear, string newBookPlace)
        {
            try
            {


                    db.openConnection();
                    MySqlConnection connection = db.getConnection();

                    string query = "UPDATE books SET name = @newBookName, author = @newBookAuthor, year = @newBookYear, place = @newBookPlace WHERE bookID = @bookId";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@bookId", bookId);
                        command.Parameters.AddWithValue("@newBookName", newBookName);
                        command.Parameters.AddWithValue("@newBookAuthor", newBookAuthor);
                        command.Parameters.AddWithValue("@newBookYear", newBookYear);
                        command.Parameters.AddWithValue("@newBookPlace", newBookPlace);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show($"Книга с ID {bookId} успешно обновлена.");
                            return true;
                        }
                        else
                        {
                            
                            MessageBox.Show($"Книга с ID {bookId} не найдена", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false; 
                        }
                    }
                
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Ошибка при обновлении книги: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Неизвестная ошибка при обновлении книги: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
               
                return false;
            }
        }

        private bool BookExists(MySqlConnection connection, int bookId)
        {
            string query = "SELECT COUNT(*) FROM books WHERE bookID = @book_id";
            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@book_id", bookId);
                return Convert.ToInt32(command.ExecuteScalar()) > 0;
            }
        }

        private bool UserExists(MySqlConnection connection, int userId)
        {
            string query = "SELECT COUNT(*) FROM users WHERE id = @user_id";  
            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@user_id", userId);
                return Convert.ToInt32(command.ExecuteScalar()) > 0;
            }
        }

        private bool IsBookIssued(MySqlConnection connection, int bookId)
        {
            string query = "SELECT COUNT(*) FROM issued_books WHERE bookID = @book_id AND return_date IS NULL"; 
            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@book_id", bookId);
                return Convert.ToInt32(command.ExecuteScalar()) > 0;
            }
        }
        public bool UpdateBookCategories(int bookId, int? newFacultyId, int? newSpecialtyId, int? newSubjectId)
        {
            try
            {

                db.openConnection();
                MySqlConnection connection = db.getConnection();

                string query = "UPDATE books SET faculty_id = @newFacultyId, specialty_id = @newSpecialtyId, subject_id = @newSubjectId WHERE bookID = @bookId";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@bookId", bookId);
                        command.Parameters.AddWithValue("@newFacultyId", newFacultyId.HasValue ? (object)newFacultyId.Value : DBNull.Value);
                        command.Parameters.AddWithValue("@newSpecialtyId", newSpecialtyId.HasValue ? (object)newSpecialtyId.Value : DBNull.Value);
                        command.Parameters.AddWithValue("@newSubjectId", newSubjectId.HasValue ? (object)newSubjectId.Value : DBNull.Value);


                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show($"Категории книги с ID {bookId} успешно обновлены.");
                            return true; 
                        }
                        else
                        {
                            
                            MessageBox.Show($"Книга с ID {bookId} не найдена", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false; 
                        }
                    }
                
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Ошибка при обновлении категорий книги: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine($"Ошибка при обновлении категорий книги: {ex.Message}");
                return false; 
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Неизвестная ошибка при обновлении категорий книги: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine($"Неизвестная ошибка при обновлении категорий книги: {ex.Message}");
                return false; 
            }
        }
        public bool UpdateBookAll(int bookId, string newBookName, string newBookAuthor, int newBookYear, string newBookPlace, int? newFacultyId, int? newSpecialtyId, int? newSubjectId)
        {
            try
            {


                    db.openConnection();
                    MySqlConnection connection = db.getConnection();

                    string query = @"
                    UPDATE books
                    SET
                        name = @newBookName,
                        author = @newBookAuthor,
                        year = @newBookYear,
                        place = @newBookPlace,
                        faculty_id = @newFacultyId,
                        specialty_id = @newSpecialtyId,
                        subject_id = @newSubjectId
                    WHERE bookID = @bookId";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@bookId", bookId);
                        command.Parameters.AddWithValue("@newBookName", newBookName);
                        command.Parameters.AddWithValue("@newBookAuthor", newBookAuthor);
                        command.Parameters.AddWithValue("@newBookYear", newBookYear);
                        command.Parameters.AddWithValue("@newBookPlace", newBookPlace);
                        command.Parameters.AddWithValue("@newFacultyId", newFacultyId.HasValue ? (object)newFacultyId.Value : DBNull.Value);
                        command.Parameters.AddWithValue("@newSpecialtyId", newSpecialtyId.HasValue ? (object)newSpecialtyId.Value : DBNull.Value);
                        command.Parameters.AddWithValue("@newSubjectId", newSubjectId.HasValue ? (object)newSubjectId.Value : DBNull.Value);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show($"Книга с ID {bookId} успешно обновлена.");
                            return true; 
                        }
                        else
                        {
                            
                            MessageBox.Show($"Книга с ID {bookId} не найдена", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false; 
                        }
                    }
                
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Ошибка при обновлении книги: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                return false; 
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Неизвестная ошибка при обновлении книги: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                return false; 
            }
        }
    }
}

    

