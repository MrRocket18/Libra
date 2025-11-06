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
    }
}
