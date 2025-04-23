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
    public partial class Selector : Form
    {
        public int FacultyId { get; set; }
        public int SpecialtyId { get; set; }
        public int SubjectId { get; set; }

        public bool status { get; set; }

        DB db = new DB();
        public Selector()
        {
            InitializeComponent();
            LoadFaculties();
            SetDropDownWidth(facultiesСomboBox);
            this.StartPosition = FormStartPosition.CenterScreen;

            facultiesСomboBox.DisplayMember = "Text";
            specialtiesСomboBox.DisplayMember = "Text";
            subjectsСomboBox.DisplayMember = "Text";
        }
        private void LoadFaculties()
        {
            facultiesСomboBox.Items.Clear();



            try
            {

                db.openConnection();
                MySqlConnection connection = db.getConnection();
                string query = "SELECT faculty_id, faculty_name FROM faculties";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            facultiesСomboBox.Items.Add(new { Value = Convert.ToInt32(reader["faculty_id"]), Text = reader["faculty_name"].ToString() });
                        }
                    }
                }

            }


            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке факультетов: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        private void LoadSpecialties(int facultyId)
        {
            specialtiesСomboBox.Items.Clear();

            
                try
                {
                    db.openConnection();
                    MySqlConnection connection = db.getConnection();
                    string query = "SELECT specialty_id, specialty_name FROM specialties WHERE faculty_id = @facultyId";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@facultyId", facultyId);
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                specialtiesСomboBox.Items.Add(new { Value = Convert.ToInt32(reader["specialty_id"]), Text = reader["specialty_name"].ToString() });
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при загрузке специальностей: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            
        }
        private void LoadSubjects(int specialtyId)
        {
            subjectsСomboBox.Items.Clear();

            
            
                try
                {
                    db.openConnection();
                    MySqlConnection connection = db.getConnection();
                    string query = "SELECT subject_id, subject_name FROM subjects WHERE specialty_id = @specialtyId";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@specialtyId", specialtyId);
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                subjectsСomboBox.Items.Add(new { Value = Convert.ToInt32(reader["subject_id"]), Text = reader["subject_name"].ToString() });
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при загрузке предметов: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            status = false;
            this.Close();
            
        }

        private void AddBooksbutton_Click(object sender, EventArgs e)
        {
            if (facultiesСomboBox.SelectedItem != null)
            {
                var selectedFaculty = facultiesСomboBox.SelectedItem;
                FacultyId = (int)selectedFaculty.GetType().GetProperty("Value").GetValue(selectedFaculty, null);
                if (specialtiesСomboBox.SelectedItem != null)
                {
                    var selectedSpecialty = specialtiesСomboBox.SelectedItem;
                    SpecialtyId = (int)selectedSpecialty.GetType().GetProperty("Value").GetValue(selectedSpecialty, null);
                    if (subjectsСomboBox.SelectedItem != null)
                    {
                        var selectedSubject = subjectsСomboBox.SelectedItem;
                        SubjectId = (int)selectedSubject.GetType().GetProperty("Value").GetValue(selectedSubject, null);
                        status = true;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Предмет не выбран!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        status = false;
                    }
                }
                else
                {
                    MessageBox.Show("Специальность не выбрана!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    status = false;
                }
            }
            else
            {
                MessageBox.Show("Факультет не выбран!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                status = false;
            }

        }

        private void facultiesСomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (facultiesСomboBox.SelectedItem != null)
            {
                var selectedFaculty = facultiesСomboBox.SelectedItem;
                int facultyId = (int)selectedFaculty.GetType().GetProperty("Value").GetValue(selectedFaculty, null);
                LoadSpecialties(facultyId);
                SetDropDownWidth(specialtiesСomboBox);
            }
        }

        private void specialtiesСomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (specialtiesСomboBox.SelectedItem != null)
            {
                var selectedSpecialty = specialtiesСomboBox.SelectedItem;
                int specialtyId = (int)selectedSpecialty.GetType().GetProperty("Value").GetValue(selectedSpecialty, null);
                LoadSubjects(specialtyId);
                SetDropDownWidth(subjectsСomboBox);
            }
        }

        private void subjectsСomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void SetDropDownWidth(ComboBox comboBox)
        {
            int maxWidth = 0;
            Graphics g = comboBox.CreateGraphics(); 

            foreach (var item in comboBox.Items)
            {
                SizeF size = g.MeasureString(item.GetType().GetProperty("Text").GetValue(item, null).ToString(), comboBox.Font);
                if (size.Width > maxWidth)
                {
                    maxWidth = (int)size.Width;
                }
            }
            comboBox.DropDownWidth = maxWidth + 20; 
            g.Dispose(); 
        }
    }
}
