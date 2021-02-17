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
    public partial class booking : Form
    {
        double price;
        double subtotal;
        double total;
        double seatClass;
        double tax;
        double seatForAdult = 1;
        double seatForChild = 1;
        int seatlimit;
        string destination;
        string boarding;

        SQLiteDataAdapter sda;
        SQLiteConnection myConnection;
        DataSet dset;

        public bool ComboBox1 { get; private set; }

        public booking()
        {
            InitializeComponent();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Boarding Combox
            comboBox2.Items.Add("London");
            comboBox2.Items.Add("Singapur");
            comboBox2.Items.Add("China");

            //Destination Combox
            comboBox1.Items.Add("London");
            comboBox1.Items.Add("Singapur");
            comboBox1.Items.Add("China");

            //Seat Limit Combox
            comboBox3.Items.Add("1");
            comboBox3.Items.Add("2");
            comboBox3.Items.Add("3");
            comboBox3.Items.Add("4");
            comboBox3.Items.Add("5");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            myConnection = new SQLiteConnection("Data Source=SuperNova.sqlite");

            string query = "INSERT INTO Report(seat_class, t_type, category, price) VALUES ('" + txtClass.ToString() + "', '" + txtType.ToString() + "','" + txtAge.ToString() + "','" + txtPrice + "');";
            SQLiteCommand cmd = new SQLiteCommand(query, myConnection);
            SQLiteDataReader myReader;

            try
            {
                myConnection.Open();
                myReader = cmd.ExecuteReader();
                MessageBox.Show("Select Seat");
                while (myReader.Read())
                {

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //seat Class
            if (rbStandard.Checked)
            {
                seatClass = 1.0;
            }
            else if (rbBussiness.Checked)
            {
                seatClass = 1.5;
            }
            else if (rbFirst.Checked)
            {
                seatClass = 2.0;
            }

            //Age
            if (rbAdult.Checked)
            {
                seatForAdult = 1.0;
            }
            if (rbChild.Checked)
            {
                seatForChild = 0.5;
            }

            //To and From
            if (comboBox2.Text == "London" && comboBox1.Text == "Singapur")
            {
                price = 10000;
            }

            if (comboBox2.Text == "China" && comboBox1.Text == "Singapur")
            {
                price = 15000;
            }

            if (comboBox2.Text == "London" && comboBox1.Text == "China")
            {
                price = 20000;
            }

            if (comboBox1.Text == "London" && comboBox2.Text == "Singapur")
            {
                price = 10000;
            }

            if (comboBox1.Text == "China" && comboBox2.Text == "Singapur")
            {
                price = 15000;
            }

            if (comboBox1.Text == "London" && comboBox2.Text == "China")
            {
                price = 20000;
            }

            seatlimit = Convert.ToInt32(comboBox3.Text);


            subtotal = price * seatClass * seatForAdult * seatForChild * seatlimit;

            if(lblSubTotal.Text != "0")
            {
                lblSubTotal.Text = "";
            }
            lblSubTotal.Text += subtotal;

            tax = (subtotal * 15) / 100;

            if (lblTax.Text != "0")
            {
                lblTax.Text = "";
            }
            lblTax.Text += tax;

            if (rbReturn.Checked)
                total = (subtotal + tax) * 2;

            if (rbSingle.Checked)
                total = subtotal + tax;

            if (lblTotal.Text != "0")
            {
                lblTotal.Text = "";
            }
            lblTotal.Text += total;
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            //Class
            if (rbStandard.Checked)
                txtClass.Text = "Standard";

            if (rbBussiness.Checked)
                txtClass.Text = "Bussiness";

            if (rbFirst.Checked)
                txtClass.Text = "First Class";

            //Ticket
            if (rbSingle.Checked)
                txtType.Text = "Single";
            if (rbReturn.Checked)
                txtType.Text = "Return";

            //Age
            if (rbAdult.Checked)
                txtAge.Text = "Adult";

            if (rbChild.Checked)
                txtAge.Text = "Child";

            //From and To

            txtFrom.Text = comboBox2.Text;
            destination = txtFrom.ToString();
            txtTo.Text = comboBox1.Text;
            boarding = txtTo.ToString();

            //Price

            txtPrice.Text += total;

            myConnection = new SQLiteConnection("Data Source=SuperNova.sqlite");

            string query1 = "INSERT INTO Report(from, to) VALUES ( destination , boarding )";
            SQLiteCommand cmd = new SQLiteCommand(query1, myConnection);
            SQLiteDataReader myReader;
            try
            {
                myConnection.Open();
                myReader = cmd.ExecuteReader();
                MessageBox.Show("ok");
            }

            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           

        }

        private void lblClass_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblSubTotal_Click(object sender, EventArgs e)
        {

        }
    }
}