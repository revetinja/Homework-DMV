using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace drugi
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }


        private void RegisterButton_Click(object sender, EventArgs e)
        {
            try
            {
                string date = "";
                if (File.Exists("RegisteredVehicles.txt")) // It checks if file exists
                {
                    if (!Directory.Exists(@"C:\DMW\Backup")) // Checks for folder, if it exists
                    {
                        Directory.CreateDirectory(@"C:\DMW\Backup"); // And if it doesn't exist, it creates it
                    }
                    date = DateTime.Now.ToString("HH:mm:ss dd-MM-YYYY"); // Sets the date format
                    File.Move("RegisteredVehicles.txt", @"C:\DMW\Backup\RegisteredVehicles" + date + ".txt"); // It moves file to another folder and adding date to it's name
                    File.Create("RegisteredVehicles.txt"); // Creates a new file instead of the old one, because old one is transfered to another folder
                }
                else MessageBox.Show("File does not exist");

                //getting values 
                dateTimePicker1.CustomFormat = "MMddYY"; // Sets the date format
                File.AppendAllText(@"C:\DMW\Backup\RegisteredVehicles" + datum + ".txt", textBox1.Text.Substring(0, 17) + textBox2.Text.Substring(0, 15) + textBox3.Text.Substring(0, 15) + dateTimePicker1.Value.ToString().Substring(0, 6) + numericUpDown1.Value.ToString().Substring(0, 1) + numericUpDown2.Value.ToString().Substring(0, 2)); // Adds text from GUI form that is entered to a file
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                label7.Text = File.ReadAllLines("RegisteredVehicles.txt").Last(); // Reads last line from file
            }
            catch (Exception)
            {
                MessageBox.Show("There is no file RegisteredVehicles in directory " + Path.GetDirectoryName("RegisteredVehicles.txt")); // Catch exception
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
