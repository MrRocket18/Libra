using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ProjectLIB
{
    public partial class MenuLib : Form

    {
        public DB _db = new DB();

        public Form ReturnForm;
        public enum TableType
        {
            Books,
            Readers
        }
        public MenuLib(string FullName)
        {
            InitializeComponent();
            InitializeDataGridView();
            LoadData();
            this.StartPosition = FormStartPosition.CenterScreen;
            NameLabel.Text = FullName;
            comboBoxTableType.Items.Add("По книгам"); 
            comboBoxTableType.Items.Add("По читателям"); 
            comboBoxTableType.SelectedIndex = 0;
        }
        private void InitializeDataGridView()
        {
            
            DataGridViewCheckBoxColumn checkColumn = new DataGridViewCheckBoxColumn();
            checkColumn.Name = "Select"; 
            checkColumn.HeaderText = "Выбрать"; 
            dataGridView1.Columns.Add(checkColumn);
        }

        private void LoadData()
        {
            try
            {
                
                _db.openConnection(); 
                MySqlConnection connection = _db.getConnection(); 
                string query = "SELECT bookID, name, author, year, status, place, faculty_id, specialty_id, subject_id FROM books";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        dataGridView1.DataSource = dataTable;

                        foreach (DataGridViewColumn column in dataGridView1.Columns)
                        {
                            column.ReadOnly = true;
                        }
                        dataGridView1.Columns["Select"].ReadOnly = false;

                        ResultLabel.Text = dataTable.Rows.Count.ToString();
                    }

                }

            }

            catch (MySqlException ex)
            {
                MessageBox.Show($"Ошибка при подключении к базе данных или выполнении запроса: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _db.closeConnection();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["Select"].Index && e.RowIndex >= 0)
            {
                dataGridView1.EndEdit();
                dataGridView1.Rows[e.RowIndex].Cells["Select"].Value = !Convert.ToBoolean(dataGridView1.Rows[e.RowIndex].Cells["Select"].Value);
            }
        }
        public  void PopulateDataGridView(TableType tableType, DataGridView dataGridView)
        {
            try
            {


                    _db.openConnection();
                    MySqlConnection connection = _db.getConnection(); 

                    string query = "";
                    if (tableType == TableType.Readers)
                    {
                        
                        query = @"
                        SELECT id, last_name, first_name, middle_name, `group`
                        FROM users
                        WHERE role = 'Reader'"; 
                    }
                    else if (tableType == TableType.Books)
                    {
                        
                        query = @"
                        SELECT bookID, name, author, year,status, place, faculty_id, specialty_id, subject_id
                        FROM books"; 
                    }
                    else
                    {
                        
                        dataGridView.DataSource = null;
                        return;
                    }

                    
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        
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

        private List<int> GetSelectedBookIds()
        {
            List<int> selectedBookIds = new List<int>();

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["Select"].Value != null && Convert.ToBoolean(row.Cells["Select"].Value))
                {
                    if (row.Cells["bookID"].Value != null && int.TryParse(row.Cells["bookID"].Value.ToString(), out int bookId))
                    {
                        selectedBookIds.Add(bookId);
                    }
                }
            }

            return selectedBookIds;
        }
       
        

        private void addBooksbutton_Click(object sender, EventArgs e)
        {
            AddBooks books = new AddBooks();
            
            books.ShowDialog();
            LoadData();
        }

        private void FindReadersbutton_Click(object sender, EventArgs e)
        {
            Search search = new Search();
            search.NameLabel.Text = "Введите ID или фамилию читателя";
            search.ShowDialog();
            User reader = new User();
            if (search.status) 
            {
                reader.SearchReadersAndDisplay(search.SearchItem, dataGridView1, ResultLabel);

            }
        }
        private void FindBooksbutton_Click(object sender, EventArgs e)
        {
            Search search = new Search();
            search.NameLabel.Text = "Введите ID или название книги";
            search.ShowDialog();
            Book book = new Book();
            if (search.status)
            {
                book.SearchBooksAndDisplay(search.SearchItem, dataGridView1,ResultLabel);
            }

        }

        private void DeleteBookButton_Click(object sender, EventArgs e)
        {
            DeleteBook book = new DeleteBook();
            book.ShowDialog();
            LoadData();
        }

        private void GiveOutBooksButton_Click(object sender, EventArgs e)
        {
            List<int> selectedBookIds = GetSelectedBookIds();

            if (selectedBookIds.Count > 0)
            {
                GiveOutBooks books = new GiveOutBooks(selectedBookIds);
                books.ShowDialog();
                LoadData();
            }
            else
            {
                MessageBox.Show("Не выбрано ни одной книги.");
            }

        }


        private void ReturnBookbutton_Click(object sender, EventArgs e)
        {
            ReturnBook book = new ReturnBook();
            book.ShowDialog();
            LoadData();
        }

        private void EditBookDataButton_Click(object sender, EventArgs e)
        {
            List<int> selectedBookIds = GetSelectedBookIds();
            
                if (selectedBookIds.Count > 0)
                {
                    if (AreBooksIdenticalOptimized(selectedBookIds))
                    {
                        ChooseWay way = new ChooseWay(selectedBookIds);
                        way.ShowDialog();
                        LoadData();
                    }
                }
                else
                {
                    MessageBox.Show("Не выбрано ни одной книги.");
                }
            
        }
        public  bool AreBooksIdenticalOptimized(List<int> bookIds)
        {
          

            try
            {

                _db.openConnection();
                MySqlConnection connection = _db.getConnection(); 

                
                    StringBuilder queryBuilder = new StringBuilder(@"
                    SELECT bookID, name, author, year, status, place, faculty_id, specialty_id, subject_id
                    FROM books
                    WHERE bookID IN (");

                    for (int i = 0; i < bookIds.Count; i++)
                    {
                        queryBuilder.Append($"@bookId{i}");
                        if (i < bookIds.Count - 1)
                        {
                            queryBuilder.Append(",");
                        }
                    }
                    queryBuilder.Append(")");

                    string query = queryBuilder.ToString();

                    
                    List<Book> books = new List<Book>();
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        for (int i = 0; i < bookIds.Count; i++)
                        {
                            command.Parameters.AddWithValue($"@bookId{i}", bookIds[i]);
                        }

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int? facultyId = null;
                                if (reader["faculty_id"] != DBNull.Value)
                                {
                                    facultyId = Convert.ToInt32(reader["faculty_id"]);
                                }

                                int? specialtyId = null;
                                if (reader["specialty_id"] != DBNull.Value)
                                {
                                    specialtyId = Convert.ToInt32(reader["specialty_id"]);
                                }

                                int? subjectId = null;
                                if (reader["subject_id"] != DBNull.Value)
                                {
                                    subjectId = Convert.ToInt32(reader["subject_id"]);
                                }

                                books.Add(new Book(
                                    Convert.ToInt32(reader["bookID"]),
                                    reader["name"].ToString(),
                                    reader["author"].ToString(),
                                    Convert.ToInt32(reader["year"]),
                                    reader["place"].ToString(),
                                    facultyId,
                                    specialtyId,
                                    subjectId
                                ));
                            }
                        }
                    }

                    
                    if (books.Count != bookIds.Count)
                    {
                        List<int> notFoundIds = bookIds.Except(books.Select(b => b.BookId)).ToList();
                        MessageBox.Show( $"Не найдены книги с ID: {string.Join(",", notFoundIds)}");
                        return false;
                    }

                   
                    Book firstBook = books[0];
                    for (int i = 1; i < books.Count; i++)
                    {
                        if (!firstBook.Equals(books[i]))
                        {
                            MessageBox.Show($"Книги с ID {firstBook.BookId} и {books[i].BookId} не идентичны.");
                            return false;
                        }
                    }

                    
                    return true;
                
            }
            catch (MySqlException ex)
            {
                
                MessageBox.Show(($"Ошибка базы данных: {ex.Message}"));
                return false;
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(($"Неизвестная ошибка: {ex.Message}"));
                return false;
            }
        }

        private void comboBoxTableType_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            MenuLib.TableType tableType;

            if (comboBoxTableType.SelectedItem.ToString() == "По читателям") 
            {
                tableType = MenuLib.TableType.Readers;
            }
            else if (comboBoxTableType.SelectedItem.ToString() == "По книгам") 
            {
                tableType = MenuLib.TableType.Books;
            }
            else
            {
                MessageBox.Show("Выберите таблицу для отображения.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; 
            }
            PopulateDataGridView(tableType, dataGridView1);
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }
        
    }

}
