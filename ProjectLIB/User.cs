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
        public int Role { get; set; }
        public string First_name { get; set; }
        public string Last_name { get; set; }
        public string Middle_name { get; set; }
        public string Group { get; set; }

        public User() { }
        public User(int id, string login, string password, int role, string first_name, string last_name, string middle_name,string group)
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
        
    }
    
}

