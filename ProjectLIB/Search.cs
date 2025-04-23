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
    public partial class Search : Form
    {
        public string SearchItem="";
        public bool status;
        public Search()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            status = false;
            this.Close();
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            status = true;
            SearchItem = SearchTextBox.Text;
            this.Close();
        }
    }
}
