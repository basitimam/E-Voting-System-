using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Configuration;

namespace K180274_Q2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Email_Input_TextChanged(object sender, EventArgs e)
        {

        }

        private void Password_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Submit_Click(object sender, EventArgs e)
        {

            var dataPath = ConfigurationManager.AppSettings["dataPath"];
         

            string info = File.ReadAllText(dataPath);
            string[] infoArr = info.Split(",");

            string Email = Email_Input.Text;
            string Pwd = Password.Text;


            for (int i=0; i< infoArr.Length; i++)
            {
                if(Email == infoArr[i])
                {
                    if(Pwd == Encoding.UTF8.GetString(Convert.FromBase64String(infoArr[i+1])))
                    {
                        //public static string stationId = infoArr[i+2];
                        Form2 form = new Form2(infoArr[i+2]);
                        
                        form.Show();


                        break;
                    }
                    else
                    {
                        string message = "Incorrect PASSWORD";
                        string title = "ERROR!";
                        MessageBox.Show(message, title);

                        break;
                    }
                }
                else
                {
                    if(i == infoArr.Length -1)
                    {
                        string message = "Incorrect EMAIL";
                        string title = "Email Not Found!";
                        MessageBox.Show(message, title);

                    }
                    else
                    {
                        continue;
                    }
                }
                
            }
            



           
        }
    }
}
