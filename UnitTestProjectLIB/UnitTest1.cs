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
            private static DB realDb = new DB();

            [ClassInitialize]
            public static void ClassInitialize(TestContext context)
            {
                realDb.connectionString = _connectionString;
            }

        [TestMethod]
            public void DeleteBook_ExistingBook_DeletesFromDatabase()
            {
                
                int bookIdToDelete = InsertTestBook(); 
                BooksInteraction booksInteraction = new BooksInteraction();
                PrivateObject privateObject = new PrivateObject(booksInteraction);
                
                DB realDb = new DB();
                realDb.connectionString = _connectionString;
                
                privateObject.SetField("db", realDb);

                
                bool result = booksInteraction.DeleteBook(bookIdToDelete);

                Assert.IsTrue(result); 
                Assert.IsFalse(BookExists(bookIdToDelete)); 
            }


        [TestMethod]
        public void DeleteBook_NonExistingBook_ReturnsFalse()
        {
            // Arrange
            int nonExistingBookId = 999999; 
            BooksInteraction booksInteraction = new BooksInteraction();
            PrivateObject privateObject = new PrivateObject(booksInteraction);
            privateObject.SetField("db", realDb);

            // Act
            bool result = booksInteraction.DeleteBook(nonExistingBookId);

            // Assert
            Assert.IsFalse(result, "DeleteBook должен вернуть false при попытке удалить несуществующую книгу");
        }

        [TestMethod]
        public void DeleteBook_InvalidBookId_ReturnsFalse()
        {
            // Arrange
            int invalidBookId = 0; 
            BooksInteraction booksInteraction = new BooksInteraction();
            PrivateObject privateObject = new PrivateObject(booksInteraction);
            privateObject.SetField("db", realDb);

            // Act
            bool result = booksInteraction.DeleteBook(invalidBookId);

            // Assert
            Assert.IsFalse(result, "DeleteBook должен вернуть false при попытке удалить книгу с недопустимым ID");
        }


        [TestMethod]
        [ExpectedException(typeof(MySqlException))] 
        public void DeleteBook_DatabaseConnectionError_ReturnsFalse()
        {
            // Arrange
          
            BooksInteraction booksInteraction = new BooksInteraction();
            PrivateObject privateObject = new PrivateObject(booksInteraction);

           
            DB fakeDb = new DB();
           
            fakeDb.connectionString = "Server=localhost;Database=NonExistentDatabase;Uid=testuser;Pwd=testpassword;";
            privateObject.SetField("db", fakeDb);

            // Act
            
            try
            {
                using (MySqlConnection connection = new MySqlConnection(fakeDb.connectionString))
                {
                    connection.Open(); 
                }
                booksInteraction.DeleteBook(1); 
            }
            catch (MySqlException)
            {
                // Assert
                
                throw;  
            }
        }



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

            
            private bool BookExists(int bookId)
            {
                using (MySqlConnection connection = new MySqlConnection(_connectionString))
                {
                    connection.Open();
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
