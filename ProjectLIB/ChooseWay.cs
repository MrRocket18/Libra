using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectLIB
{
    public partial class ChooseWay : Form
    {
        public List<int> _Ids;


        public ChooseWay(List<int> Ids)
        {
            InitializeComponent();
            _Ids = Ids;
            this.StartPosition = FormStartPosition.CenterScreen;

        }

        private void OnlyDatabutton_Click(object sender, EventArgs e)
        {
            ChangeData changeData = new ChangeData(_Ids);
            changeData.ShowDialog();
            BooksInteraction book = new BooksInteraction();
            if (changeData.status)
            {
                for (int i = 0; i < _Ids.Count(); i++)
                {
                    book.UpdateBook(_Ids[i], changeData._title, changeData._author, changeData._year, changeData._place);
                }
            }
        }

        private void OnlyAffiliationbutton_Click(object sender, EventArgs e)
        {
            Selector select = new Selector();
            BooksInteraction book = new BooksInteraction();
            select.AddBooksbutton.Text = "Изменить категории книг";
            select.ShowDialog();
            

            if (select.status)
            {
                int FacultId = select.FacultyId;
                int SpecId = select.SpecialtyId;
                int SubId = select.SubjectId;
                for (int i=0; i < _Ids.Count(); i++)
                {
                    book.UpdateBookCategories(_Ids[i], FacultId, SpecId, SubId);
                }
                  
            }
            
        }

        private void AllChangebutton_Click(object sender, EventArgs e)
        {
            ChangeData changeData = new ChangeData(_Ids);
            Selector select = new Selector();
            changeData.ShowDialog();
            BooksInteraction book = new BooksInteraction();
            if (changeData.status)
            {
                select.AddBooksbutton.Text = "Сохранить изменения";
                select.ShowDialog();
                if (select.status)
                {
                    
                    for (int i = 0; i < _Ids.Count(); i++)
                    {
                        book.UpdateBookAll(_Ids[i], changeData._title, changeData._author, changeData._year, changeData._place, select.FacultyId, select.SpecialtyId, select.SubjectId);
                    }
                }
                
            }
        }

        private void Backbutton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
