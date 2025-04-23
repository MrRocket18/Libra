using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data;

namespace ProjectLIB
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }  
        public string Role { get; set; }
        public string First_name { get; set; }
        public string Last_name { get; set; }
        public string Middle_name { get; set; }
        public string Group { get; set; }

        public User() { }

        DB db = new DB();

        public User(int id, string login, string password, string role, string first_name, string last_name, string middle_name,string group)
        {
            Id = id;
            Login = login;
            Password = password;
            Role = role;
            First_name = first_name;
            Last_name = last_name;
            Middle_name = middle_name;
            Group = group;
        }

        
        public User FindUserByLogin(string login, string pass)
        {
            User user = null;
            try
               {
                db.openConnection();
                MySqlConnection connection = db.getConnection();


                string query = "SELECT id, first_name, last_name, middle_name, `group`, login, password, role  FROM users WHERE login = @login";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@login", login);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read()) 
                            {
                                
                                user = new User(
                                    Convert.ToInt32(reader["id"]),
                                    reader["login"].ToString(),
                                    reader["password"].ToString(),  
                                    reader["role"].ToString(),
                                    reader["first_name"].ToString(),
                                    reader["last_name"].ToString(),
                                    reader["middle_name"].ToString(),
                                    reader["group"] == DBNull.Value ? string.Empty : reader["group"].ToString()

                                );
                                if (user.Password != pass)
                                {
                                  return null;  
                                }
                            }
                            
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show($"Ошибка при поиске пользователя: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null; 
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Неизвестная ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;  
                }
            

            return user;  
        }
        public (string FullName, string Group) GetFullNameAndGroupById(int userId)
        {
            string fullName = null;
            string group = null;
            
            
                try
                {
                    db.openConnection();
                    MySqlConnection connection = db.getConnection();
                    string query = "SELECT first_name, last_name, middle_name, `group` FROM users WHERE id = @user_id";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
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
            
            return (fullName, group);
        }
        public void SearchReadersAndDisplay(string searchTerm, DataGridView dataGridView, Label ResultLabel)
        {
            try
            {
                db.openConnection();
                MySqlConnection connection = db.getConnection();



                // 1. Определяем тип поиска (ID или фамилия)
                bool isIdSearch = int.TryParse(searchTerm, out int readerId);

                // 2. Создаем SQL-запрос с параметрами
                string query = @"
                    SELECT id, first_name, last_name, middle_name, `group`
                    FROM users
                    WHERE role = 'Reader' "; // Фильтруем только читателей

                if (isIdSearch)
                {
                    query += " AND id = @searchTerm";
                }
                else if (!string.IsNullOrEmpty(searchTerm))
                {
                    query += " AND first_name LIKE @searchTerm";
                }
                else
                {
                    // Если searchTerm пуст, выводим сообщение и выходим
                    MessageBox.Show("Введите ID или фамилию для поиска.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridView.DataSource = null; // Очищаем DataGridView
                    return;
                }

                // 3. Создаем MySqlCommand
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    // 4. Добавляем параметры
                    if (isIdSearch)
                    {
                        command.Parameters.AddWithValue("@searchTerm", readerId);
                    }
                    else if (!string.IsNullOrEmpty(searchTerm))
                    {
                        command.Parameters.AddWithValue("@searchTerm", "%" + searchTerm + "%"); // Используем LIKE для частичного соответствия
                    }

                    // 5. Создаем MySqlDataAdapter и DataTable
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();

                        // 6. Заполняем DataTable
                        adapter.Fill(dataTable);

                        // 7. Привязываем DataTable к DataGridView
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

