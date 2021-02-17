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
    public partial class Create_Account : Form
    {
       
        SQLiteDataAdapter sda;
        SQLiteConnection myConnection;
        DataSet dset;


        public Create_Account()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            myConnection = new SQLiteConnection("Data Source=SuperNova.sqlite");
            
            string query = "INSERT INTO Passanger(username, cell, NID, email, address, password) VALUES ('"+this.txtName.Text+ "', '" + this.txtCell.Text+ "','" + this.txtNID.Text+ "','" + this.txtEmail.Text + "','" + this.txtAddress.Text+ "','" + this.txtPassword.Text+ "');";
            SQLiteCommand cmd = new SQLiteCommand(query, myConnection);
            SQLiteDataReader myReader;

            try {
                myConnection.Open();
                myReader = cmd.ExecuteReader();
                MessageBox.Show("Saved");
                while (myReader.Read())
                {

                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
