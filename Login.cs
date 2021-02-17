using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Windows.Forms;



namespace SuperNova_Airline
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SQLiteConnection myConnection;
            myConnection = new SQLiteConnection("Data Source=SuperNova.sqlite");
            
            String query = "Select * from Passanger Where email = '" + userName.Text.Trim() + "'and password = '" + password.Text.Trim() + "'";
            SQLiteDataAdapter sda = new SQLiteDataAdapter(query,myConnection);
            DataTable dtbl = new DataTable();

            sda.Fill(dtbl);

            if (dtbl.Rows.Count == 1)
            {
                new booking().Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Incorrect Email or Password");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Create_Account().Show();
            this.Hide();
        }

        private void passward_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
