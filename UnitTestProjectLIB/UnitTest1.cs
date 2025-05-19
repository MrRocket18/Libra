using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Reflection;
using System.Windows.Forms;
using ProjectLIB;
using MySql.Data.MySqlClient;

namespace UnitTestProjectLIB
{




    


        [TestClass]
        public class BooksInteractionIntegrationTests
        {
            private static string _connectionString = "server=localhost;port=3306;username=root;password=root;database=libraryuniversity;"; // Замените на вашу реальную строку подключения

            [TestMethod]
            public void DeleteBook_ExistingBook_DeletesFromDatabase()
            {
                // Arrange
                int bookIdToDelete = InsertTestBook(); // Вставляем тестовую книгу в базу данных и получаем ее ID
                                                       // **Исправлено: Создаем экземпляр BooksInteraction без параметров**
                BooksInteraction booksInteraction = new BooksInteraction();
                PrivateObject privateObject = new PrivateObject(booksInteraction);
                // Создаем экземпляр реального класса DB и передаем connectionString
                DB realDb = new DB();
                realDb.connectionString = _connectionString;
                // Используем PrivateObject для внедрения зависимости _db
                privateObject.SetField("db", realDb);

                // Act
                bool result = booksInteraction.DeleteBook(bookIdToDelete);

                // Assert
                Assert.IsTrue(result); // Проверяем, что удаление прошло успешно
                Assert.IsFalse(BookExists(bookIdToDelete)); // Проверяем, что книга действительно удалена из базы данных
            }

            // Вспомогательный метод для вставки тестовой книги в базу данных
            private int InsertTestBook()
            {
                
                using (MySqlConnection connection = new MySqlConnection(_connectionString))
                {
                    connection.Open();
                string query = "INSERT INTO books (name, author, year, place, faculty_id, specialty_id, subject_id) " +
                               "VALUES (@books_name, @books_author, @books_year, @books_place, @facultyId, @specialtyId, @subjectId); " +
                               "SELECT LAST_INSERT_ID();";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@books_name", "InsertTestBook");
                        command.Parameters.AddWithValue("@books_author", "TestAuthor");
                        command.Parameters.AddWithValue("@books_year", 2000);
                        command.Parameters.AddWithValue("@books_place", "Test");

                        command.Parameters.AddWithValue("@facultyId", 1);
                        command.Parameters.AddWithValue("@specialtyId", 1);
                        command.Parameters.AddWithValue("@subjectId", 1);
                        object result = command.ExecuteScalar();
                        return Convert.ToInt32(result);
                    }

                }
                
                
            }

            // Вспомогательный метод для проверки, существует ли книга в базе данных
            private bool BookExists(int bookId)
            {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                // Исправлено: Используем правильное имя столбца в WHERE clause
                string query = "SELECT COUNT(*) FROM Books WHERE bookID = @Id;";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", bookId);
                    return Convert.ToInt32(command.ExecuteScalar()) > 0;
                }
            }
        }

            
        }
    
}
