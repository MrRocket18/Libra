using MySql.Data.MySqlClient;
using QRCoder;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Windows.Forms;




namespace ProjectLIB
{
    public partial class MenuLib : Form

    {
        private System.Drawing.Printing.PrintDocument printDocumentQrCode;
        public DB _db = new DB();
        private Book _bookToPrint = null;
        private Queue<byte[]> _qrCodesToPrintQueue = new Queue<byte[]>();
        private Queue<Book> _booksForPrintInfoQueue = new Queue<Book>();
        private SerialPort serialPort;


        public Form ReturnForm;
        public enum TableType
        {
            Books,
            Readers
        }
        public MenuLib(string FullName)
        {
            InitializeAndOpenSerialPort("COM7", 9600);
            InitializeComponent();
            LoadData(_db.GetAllBooksWithQrDetails());
            LoadDataForReaders(_db.GetUsers());
            this.StartPosition = FormStartPosition.CenterScreen;
            NameLabel.Text = FullName;
            printDocumentQrCode = new System.Drawing.Printing.PrintDocument();
            printDocumentQrCode.PrintPage += new PrintPageEventHandler(PrintDocumentQrCode_PrintPage);
  
        }

        private void LoadDataForReaders(List<User> users)
        {
            try
            {
                dataGridViewUsers.AutoGenerateColumns = false;
                dataGridViewUsers.DataSource = null;

                dataGridViewUsers.Rows.Clear();
                dataGridViewUsers.Columns.Clear();
                dataGridViewUsers.AutoGenerateColumns = false;

                FillDataGridViewReaders(users);

                ResultsLabelReaders.Text = users.Count.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данныхв таблицу читателей: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadData(List<Book> books)
        {
            try
            {
                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.DataSource = null;

                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();
                dataGridView1.AutoGenerateColumns = false;

                FillDataGridView(books);

                ResultLabel.Text = books.Count.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных в таблицу книг: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void FillDataGridViewReaders(List<User> users)
        {
            dataGridViewUsers.AutoGenerateColumns = false;
            DataGridViewTextBoxColumn userIdColumn = new DataGridViewTextBoxColumn();
            userIdColumn.DataPropertyName = "Id";
            userIdColumn.HeaderText = "ID";
            dataGridViewUsers.Columns.Add(userIdColumn);

            DataGridViewTextBoxColumn firstNameColumn = new DataGridViewTextBoxColumn();
            firstNameColumn.DataPropertyName = "First_name";
            firstNameColumn.HeaderText = "Фамилия";
            dataGridViewUsers.Columns.Add(firstNameColumn);

            DataGridViewTextBoxColumn lastNameColumn = new DataGridViewTextBoxColumn();
            lastNameColumn.DataPropertyName = "Last_name";
            lastNameColumn.HeaderText = "Имя";
            dataGridViewUsers.Columns.Add(lastNameColumn);

            DataGridViewTextBoxColumn middleNameColumn = new DataGridViewTextBoxColumn();
            middleNameColumn.DataPropertyName = "Middle_name";
            middleNameColumn.HeaderText = "Отчество";
            dataGridViewUsers.Columns.Add(middleNameColumn);

            DataGridViewTextBoxColumn groupNameColumn = new DataGridViewTextBoxColumn();
            groupNameColumn.DataPropertyName = "Group";
            groupNameColumn.HeaderText = "Группа";
            dataGridViewUsers.Columns.Add(groupNameColumn);

            dataGridViewUsers.DataSource = users;
        }


        private void FillDataGridView(List<Book> books)
        {

            DataGridViewCheckBoxColumn selectColumn = new DataGridViewCheckBoxColumn() {Name = "Select", HeaderText = "Выбрать" };
            dataGridView1.Columns.Add(selectColumn);

            DataGridViewTextBoxColumn bookIdColumn = new DataGridViewTextBoxColumn();
            bookIdColumn.Name = "BookID";
            bookIdColumn.HeaderText = "ID";
            bookIdColumn.DataPropertyName = "BookID"; 
            dataGridView1.Columns.Add(bookIdColumn);

            DataGridViewTextBoxColumn nameColumn = new DataGridViewTextBoxColumn();
            nameColumn.Name = "Name";
            nameColumn.HeaderText = "Навзание";
            nameColumn.DataPropertyName = "Title"; 
            dataGridView1.Columns.Add(nameColumn);
          
            DataGridViewTextBoxColumn authorColumn = new DataGridViewTextBoxColumn();
            authorColumn.Name = "Author";
            authorColumn.HeaderText = "Автор";
            authorColumn.DataPropertyName = "Author";
            dataGridView1.Columns.Add(authorColumn);
            
            DataGridViewTextBoxColumn yearColumn = new DataGridViewTextBoxColumn();
            yearColumn.Name = "Year";
            yearColumn.HeaderText = "Год выпуска";
            yearColumn.DataPropertyName = "PublicationYear"; 
            dataGridView1.Columns.Add(yearColumn);
           
            DataGridViewTextBoxColumn placeColumn = new DataGridViewTextBoxColumn();
            placeColumn.Name = "Place";
            placeColumn.HeaderText = "Место";
            placeColumn.DataPropertyName = "Place";
            dataGridView1.Columns.Add(placeColumn);
            
            DataGridViewTextBoxColumn facultyColumn = new DataGridViewTextBoxColumn();
            facultyColumn.Name = "Faculty";
            facultyColumn.HeaderText = "Факультет";
            facultyColumn.DataPropertyName = "Faculty";
            dataGridView1.Columns.Add(facultyColumn);
            
            DataGridViewTextBoxColumn specialtyColumn = new DataGridViewTextBoxColumn();
            specialtyColumn.Name = "Specialty";
            specialtyColumn.HeaderText = "Специальность";
            specialtyColumn.DataPropertyName = "Specialty"; 
            dataGridView1.Columns.Add(specialtyColumn);
           
            DataGridViewTextBoxColumn subjectColumn = new DataGridViewTextBoxColumn();
            subjectColumn.Name = "Subject";
            subjectColumn.HeaderText = "Предмет";
            subjectColumn.DataPropertyName = "Subject"; 
            dataGridView1.Columns.Add(subjectColumn);

            DataGridViewTextBoxColumn statusColumn = new DataGridViewTextBoxColumn();
            statusColumn.Name = "Status";
            statusColumn.HeaderText = "Статус";
            statusColumn.DataPropertyName = "status";
            dataGridView1.Columns.Add(statusColumn);

            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("BookID");       
            dataTable.Columns.Add("Title");       
            dataTable.Columns.Add("Author");      
            dataTable.Columns.Add("PublicationYear"); 
            dataTable.Columns.Add("status");     
            dataTable.Columns.Add("Place");       
            dataTable.Columns.Add("Faculty");     
            dataTable.Columns.Add("Specialty");   
            dataTable.Columns.Add("Subject");
            dataTable.Columns.Add("Highlight");


            for (int i = 0; i < books.Count; i++)
            {
                var book = books[i];

                DataRow row = dataTable.NewRow();
                row["BookId"] = book.BookId;
                row["Title"] = book.Title;
                row["Author"] = book.Author;
                row["PublicationYear"] = book.PublicationYear;
                row["status"] = book.GetStatusBook();
                row["Place"] = book.Place;
                row["Faculty"] = book.Faculty;
                row["Specialty"] = book.Specialty;
                row["Subject"] = book.Subject;

                row["Highlight"] = !book.IsPrinted;
                dataTable.Rows.Add(row);

            }

            dataGridView1.DataSource = dataTable;

            if (dataGridView1.Columns.Contains("Highlight"))
            {
                dataGridView1.Columns["Highlight"].Visible = false;
            }

            dataGridView1.RowPrePaint += (sender, e) =>
            {
                if (e.RowIndex >= 0 && e.RowIndex < dataTable.Rows.Count)
                {
                    DataRow row = dataTable.Rows[e.RowIndex];
                    bool highlight = Convert.ToBoolean(row["Highlight"]);

                    if (highlight)
                    {
                        dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Yellow;
                    }
                    else
                    {
                        dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = dataGridView1.DefaultCellStyle.BackColor;
                    }
                }
            };

            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.ReadOnly = true;
            }
            if (dataGridView1.Columns.Contains("Select"))
            {
                dataGridView1.Columns["Select"].ReadOnly = false;
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
        public byte[] GenerateQrCodeBytes(int bookID)
        {
            string qrCodeData = $"EduLib_B_ID: {bookID}";
            //Для пользователей навзание будет EduLib_U_ID
            try
            {
                QRCodeGenerator qrGenerator = new QRCodeGenerator();
                QRCodeData qrCodeDataObj = qrGenerator.CreateQrCode(qrCodeData, QRCodeGenerator.ECCLevel.Q);
                using (QRCode qrCode = new QRCode(qrCodeDataObj))
                {
                    using (Bitmap qrCodeBitmap = qrCode.GetGraphic(10))
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            qrCodeBitmap.Save(ms, ImageFormat.Png);
                            return ms.ToArray();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при генерации QR-кода для книги ID {bookID}: {ex.Message}");
                return null;
            }
        }
        //public  void PopulateDataGridView(TableType tableType, DataGridView dataGridView)
        //{
        //    try
        //    {


        //            _db.openConnection();
        //            MySqlConnection connection = _db.getConnection(); 

        //            string query = "";
        //            if (tableType == TableType.Readers)
        //            {
                        
        //                query = @"
        //                SELECT id, last_name, first_name, middle_name, `group`
        //                FROM users
        //                WHERE role = 'Reader'"; 
        //            }
        //            else if (tableType == TableType.Books)
        //            {
                        
        //                query = @"
        //                SELECT bookID, name, author, year,status, place, faculty_id, specialty_id, subject_id
        //                FROM books"; 
        //            }
        //            else
        //            {
                        
        //                dataGridView.DataSource = null;
        //                return;
        //            }

                    
        //            using (MySqlCommand command = new MySqlCommand(query, connection))
        //            {
                        
        //                using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
        //                {
        //                    DataTable dataTable = new DataTable();

                            
        //                    adapter.Fill(dataTable);

                            
        //                    dataGridView.DataSource = dataTable;
        //                    ResultLabel.Text = dataTable.Rows.Count.ToString();
        //                }
        //            }
                
        //    }
        //    catch (MySqlException ex)
        //    {
        //        MessageBox.Show($"Ошибка базы данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        Console.WriteLine($"Ошибка базы данных: {ex.Message}");
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"Неизвестная ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        Console.WriteLine($"Неизвестная ошибка: {ex.Message}");
        //    }
        //}

        private List<int> GetSelectedBookIds()
        {
            List<int> selectedBookIds = new List<int>();

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["Select"].Value != null && Convert.ToBoolean(row.Cells["Select"].Value))
                {
                    if (row.Cells["BookID"].Value != null && int.TryParse(row.Cells["BookID"].Value.ToString(), out int bookId))
                    {
                        selectedBookIds.Add(bookId);
                    }
                }
            }

            return selectedBookIds;
        }
       
        private void addBooksbutton_Click(object sender, EventArgs e)

        {

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV Files (*.csv)|*.csv|All files (*.*)|*.*"; 
            openFileDialog.Title = "Выберите CSV файл с данными книг";

           
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                LoadBooksFromFile(filePath); 
            }
        }

        
        private void LoadBooksFromFile(string filePath)
        {
            List<Book> booksToAdd = new List<Book>();
            char delimiter = ';'; 
            int successCount = 0;
            int errorCount = 0;

            try
            {

                using (StreamReader reader = new StreamReader(filePath, Encoding.UTF8))
                {

                    string headerLine = reader.ReadLine();
                    if (headerLine == null)
                    {
                        MessageBox.Show("CSV файл пуст или не содержит заголовка.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    int lineNumber = 1;

                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        lineNumber++;

                        if (string.IsNullOrWhiteSpace(line)) continue;

                        string[] parts = line.Split(delimiter);

                        if (parts.Length >= 7)
                        {
                            try
                            {

                                string title = parts[0].Trim();
                                string author = parts[1].Trim();
                                if (!int.TryParse(parts[2].Trim(), out int year))
                                {
                                    throw new FormatException($"Некорректное значение года: '{parts[2].Trim()}'");
                                }
                                string place = parts[3].Trim();
                                string facultyName = parts[4].Trim();
                                string specialtyName = parts[5].Trim();
                                string subjectName = parts[6].Trim();

                                Book book = new Book(title, author, year, place, facultyName, specialtyName, subjectName);
                                booksToAdd.Add(book);
                            }
                            catch (FormatException fe)
                            {
                                MessageBox.Show($"Ошибка форматирования в строке {lineNumber}: {fe.Message}. Строка пропущена.", "Ошибка строки", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                errorCount++;
                            }
                            catch (Exception ex)
                            {

                                MessageBox.Show($"Ошибка при обработке строки {lineNumber}: {ex.Message}. Строка пропущена.", "Ошибка строки", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                errorCount++;
                            }
                        }
                        else
                        {

                            MessageBox.Show($"Некорректная строка {lineNumber} в CSV (ожидалось минимум 7 полей): {line}. Строка пропущена.", "Ошибка строки", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            errorCount++;
                        }
                    }
                }


                if (booksToAdd.Any())
                {
                    for (int i = 0; i < booksToAdd.Count; i++)
                    {
                        try
                        {
                            _db.AddBook(booksToAdd[i]);
                            Console.WriteLine(booksToAdd[i]);
                            successCount++;
                        }
                        catch (Exception dbEx)
                        {
                            Console.WriteLine($"Ошибка при добавлении книги \"{booksToAdd[i].Title}\" (индекс {i}) в БД: {dbEx.Message}");
                            errorCount++;
                        }
                    }

                    string message = $"Загрузка завершена.\n";
                    message += $"Успешно добавлено: {successCount} книг.\n";
                    if (errorCount > 0)
                    {
                        message += $"Пропущено/ошибок: {errorCount} строк.\n";
                        message += "Пожалуйста, проверьте сообщения об ошибках в консоли или в предупреждениях.";
                    }
                    MessageBox.Show(message, "Результат загрузки", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (errorCount == 0) 
                {
                    MessageBox.Show("В выбранном файле не найдено корректных данных для загрузки книг.", "Нет данных", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                LoadData(_db.GetAllBooksWithQrDetails());
                
               
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show($"Файл не найден: {filePath}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show($"Нет доступа к файлу: {filePath}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Ошибка при работе с базой данных: {ex.Message}", "Ошибка БД", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла непредвиденная ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DeleteBookButton_Click(object sender, EventArgs e)
        {
            List<int> selectedBookId = GetSelectedBookIds();
            if (selectedBookId.Count() != 1)
            {
                MessageBox.Show($"Количество выбранных книг больше 1", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DeleteBook book = new DeleteBook(selectedBookId[0]);
            book.ShowDialog();
            LoadData(_db.GetAllBooksWithQrDetails());
        }

        private void GiveOutBooksButton_Click(object sender, EventArgs e)
        {
            List<int> selectedBookIds = GetSelectedBookIds();

            if (selectedBookIds.Count > 0)
            {
                GiveOutBooks books = new GiveOutBooks(selectedBookIds);
                books.ShowDialog();
                LoadData(_db.GetAllBooksWithQrDetails());
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
            LoadData(_db.GetAllBooksWithQrDetails());
        }

        private void EditBookDataButton_Click(object sender, EventArgs e)
        {

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV Files (*.csv)|*.csv|All files (*.*)|*.*";
            openFileDialog.Title = "Выберите CSV файл для обновления данных книг";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                char delimiter = ';'; 

                int updatedCount = 0;
                int errorCount = 0;

                try
                {
                    using (StreamReader reader = new StreamReader(filePath, Encoding.UTF8))
                    {
                        
                        if (!reader.EndOfStream)
                        {
                            string headerLine = reader.ReadLine();
                            Console.WriteLine($"Заголовок CSV: {headerLine}"); 
                        }

                        string line;
                        int lineNumber = 1; 

                        while ((line = reader.ReadLine()) != null)
                        {
                            lineNumber++;
                            Console.WriteLine($"Обработка строки {lineNumber}: {line}"); 
                            string[] parts = line.Split(delimiter);

                            if (parts.Length == 8)
                            {
                                try
                                {
                                    if (!int.TryParse(parts[0].Trim(), out int bookId))
                                    {
                                        throw new FormatException($"Некорректный ID книги: '{parts[0].Trim()}'");
                                    }

                                    string title = parts[1].Trim();
                                    string author = parts[2].Trim();

                                    if (!int.TryParse(parts[3].Trim(), out int year))
                                    {
                                        throw new FormatException($"Некорректное значение года: '{parts[3].Trim()}'");
                                    }

                                    string place = parts[4].Trim();
                                    string facultyName = parts[5].Trim();
                                    string specialtyName = parts[6].Trim();
                                    string subjectName = parts[7].Trim();
                                    if (_db.UpdateBook(bookId, title, author, year, place, facultyName, specialtyName, subjectName))
                                    {
                                        updatedCount++;
                                        
                                    }
                                    else
                                    {
                                        errorCount++;

                                    }
                                }
                                catch (FormatException fe)
                                {
                                    errorCount++;
                                    Console.WriteLine($"Ошибка форматирования в строке {lineNumber}: {fe.Message}. Строка: {line}");
                                }
                                catch (Exception ex)
                                {
                                    errorCount++;
                                    Console.WriteLine($"Ошибка при обработке строки {lineNumber}: {ex.Message}. Строка: {line}");
                                }
                            }
                            else
                            {
                                errorCount++;
                                Console.WriteLine($"Некорректное количество полей в строке {lineNumber} (ожидалось 8, получено {parts.Length}): {line}");
                            }
                        }
                    }


                    MessageBox.Show($"Обновлено книг: {updatedCount}, Ошибок: {errorCount}", "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadData(_db.GetAllBooksWithQrDetails());
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при чтении файла: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine($"Ошибка при чтении файла: {ex.Message}");
                }
            }
        }
        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void PrintButton_Click(object sender, EventArgs e)
        {
            List<int> Ids_for_print = GetSelectedBookIds();
            List<byte[]> tempQrCodes = new List<byte[]>();
            List<Book> tempBooksInfo = new List<Book>();

            if (Ids_for_print.Count() != 0)
            {
                for (int i = 0; i < Ids_for_print.Count(); i++)
                {
                    int bookId = Ids_for_print[i];
                    Book book = _db.GetBookById(bookId);

                    if (book != null)
                    {
                            byte[] qrCodeBytes = GenerateQrCodeBytes(bookId);
                            if (qrCodeBytes == null)
                            {
                                Console.WriteLine($"Не удалось сгенерировать QR-код для книги ID {bookId}");
                                continue;
                            }
                           
                            for (int copy = 0; copy < 3; copy++)
                            {
                                tempQrCodes.Add(qrCodeBytes);
                                tempBooksInfo.Add(book);
                            }
                            Console.WriteLine($"Подготовлено 3 копии QR-кода для книги ID {bookId}");
                    }
                }

                if (tempQrCodes.Count > 0)
                {
                    using (PrintDialog printDialog = new PrintDialog())
                    {
                        printDialog.Document = printDocumentQrCode;
                        printDialog.AllowPrintToFile = true;

                        if (printDialog.ShowDialog() == DialogResult.OK)
                        {
                            _qrCodesToPrintQueue = new Queue<byte[]>(tempQrCodes);
                            _booksForPrintInfoQueue = new Queue<Book>(tempBooksInfo);
                            printDocumentQrCode.Print();
                            
                        }
                        else
                        {
                            MessageBox.Show("Печать отменена пользователем.", "Отмена", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Не выбрано ни одной книги для печати или произошла ошибка при подготовке данных.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                LoadData(_db.GetAllBooksWithQrDetails());
            }
            else
            {
                MessageBox.Show("Не выбрано ни одной книги для печати.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void PrintDocumentQrCode_PrintPage(object sender, PrintPageEventArgs e)
        {
            if (_qrCodesToPrintQueue.Count == 0)
            {
                e.HasMorePages = false;
                return;
            }

            Graphics g = e.Graphics;

            float targetQrCodeWidthPixels = 120f;
            float targetQrCodeHeightPixels = 120f;

            const int qrCodesInOneRow = 6; 
            const int totalRows = 8;         

            float marginX = 10; 
            float marginY = 10; 

            int qrCodesDrawnOnPage = 0; 
            int currentRowIndex = 0;   

            
            while (_qrCodesToPrintQueue.Count > 0 && currentRowIndex < totalRows)
            {
             
                for (int i = 0; i < qrCodesInOneRow; i++)
                {
                    if (_qrCodesToPrintQueue.Count == 0) break;

                    byte[] qrCodeBytes = _qrCodesToPrintQueue.Dequeue();
                    Book book = _booksForPrintInfoQueue.Dequeue();

                    float x = marginX + i * (targetQrCodeWidthPixels + marginX);
                    float y = marginY + currentRowIndex * (targetQrCodeHeightPixels + marginY);

                    try
                    {
                        using (MemoryStream ms = new MemoryStream(qrCodeBytes))
                        using (Image qrCodeImage = Image.FromStream(ms))
                        {
                            g.DrawImage(qrCodeImage, x, y, targetQrCodeWidthPixels, targetQrCodeHeightPixels);

                            string bookInfo = $"ID: {book.BookId}";
                            using (Font font = new Font("Arial", 7, FontStyle.Regular))
                            using (StringFormat sf = new StringFormat())
                            {
                                sf.Alignment = StringAlignment.Center;
                                sf.LineAlignment = StringAlignment.Near;

                                float textY = y + targetQrCodeHeightPixels + (1/5);
                                RectangleF textRect = new RectangleF(x, textY, targetQrCodeWidthPixels, g.MeasureString(bookInfo, font).Height + 10);
                                g.DrawString(bookInfo, font, Brushes.Black, textRect, sf);
                            }
                            _db.MarkBookAsPrinted(book.BookId);
                            Console.WriteLine($"Нарисован QR-код {qrCodesDrawnOnPage + 1} (Книга {book.Title}) в строке {currentRowIndex}, колонке {i}.");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Ошибка при рисовании QR-кода {qrCodesDrawnOnPage + 1}: {ex.Message}");
                        e.Cancel = true;
                        return;
                    }
                    qrCodesDrawnOnPage++;
                }
                currentRowIndex++;
            }


            if (_qrCodesToPrintQueue.Count > 0)
            {
                e.HasMorePages = true;
                Console.WriteLine($"Нужна следующая страница. Осталось QR-кодов: {_qrCodesToPrintQueue.Count}");
            }
            else
            {
                e.HasMorePages = false;
                Console.WriteLine("Вся очередь на печать обработана.");
                if (!e.Cancel)
                {
                    MessageBox.Show("Печать завершена!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                _qrCodesToPrintQueue.Clear();
                _booksForPrintInfoQueue.Clear();

            }
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            string search = SearchTextBox.Text.Trim();
            if (search.Length == 0 )
            {
                MessageBox.Show("В поле поиска ничего нет!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData(_db.GetAllBooksWithQrDetails());
            }
            List<Book> book_result = _db.Search(search);
            if (book_result.Count == 0)
            {
                MessageBox.Show("Ничего не найденно!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData(_db.GetAllBooksWithQrDetails());
            }
            LoadData(book_result);
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            LoadData(_db.GetAllBooksWithQrDetails());
        }

        private void SearchReadersButton_Click(object sender, EventArgs e)
        {
            string search = SearchReadersTextBox.Text.Trim();
            if (search.Length == 0)
            {
                MessageBox.Show("В поле поиска ничего нет!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDataForReaders(_db.GetUsers());
            }
            List<User> user_result = _db.SearchUsers(search); 
            if (user_result.Count == 0)
            {
                MessageBox.Show("Ничего не найденно!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDataForReaders(_db.GetUsers());
            }
            LoadDataForReaders(user_result);
        }

        private void BackButton2_Click(object sender, EventArgs e)
        {
            LoadDataForReaders(_db.GetUsers());
        }
        private void InitializeAndOpenSerialPort(string portName, int baudRate)
        {
            serialPort = new SerialPort();
            serialPort.PortName = portName;
            serialPort.BaudRate = baudRate;
            serialPort.Parity = Parity.None;
            serialPort.StopBits = StopBits.One;
            serialPort.DataBits = 8;
            serialPort.Handshake = Handshake.None;
            serialPort.DataReceived += DataReceivedHandler;

            try
            {
                serialPort.Open();
                MessageBox.Show("COM-порт " + portName + " успешно открыт.");
            }
            catch (Exception)
            {
                MessageBox.Show("Сканер не подключён");
            }
        }

        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            string data = serialPort.ReadExisting().Trim();
            const string Prefix = "EduLib_B_ID: ";
            this.Invoke((MethodInvoker)delegate
            {
                MessageBox.Show("Считанный QR-код: " + data);
                if (data.StartsWith(Prefix))
                {
                    int bookID = int.Parse(data.Substring(Prefix.Length));
                    Book book_info = _db.GetBookById(bookID);
                    Console.WriteLine(bookID);
                    if (book_info != null)
                    {
                        QrCodeSession book = new QrCodeSession(book_info);
                        book.ShowDialog();
                        LoadData(_db.GetAllBooksWithQrDetails());
                    }
                    else
                    {
                        MessageBox.Show("Информация о книге не найдена");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Данный Qr код не из этой системы");
                    return;
                }

            });
        }

    }

}


