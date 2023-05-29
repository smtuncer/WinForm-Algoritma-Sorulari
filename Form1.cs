using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SelcukMehmetTuncer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var result = (Convert.ToDouble(textBox1.Text) + Convert.ToDouble(textBox2.Text)) * Convert.ToDouble(textBox3.Text);
                textBox4.Text = result.ToString();
            }
            catch
            {
                textBox4.Text = "Hata";
                MessageBox.Show("Sayı girilmelidir.", "Hata");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 1; i <= 200; i++)
            {
                if (i % 3 == 0 && i % 5 == 0)
                {
                    listBox2.Items.Add("zigzag");
                }
                else if (i % 3 == 0)
                {
                    listBox2.Items.Add("zig");
                }
                else if (i % 5 == 0)
                {
                    listBox2.Items.Add("zag");
                }
                else
                {
                    listBox2.Items.Add(i.ToString());
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                var textboxValue = Convert.ToInt32(textBox5.Text);
                var result = "";
                if (textboxValue >= 1 && textboxValue <= 15)
                {
                    for (int i = 0; i <= textboxValue; i++)
                    {
                        for (int x = 0; x <= textboxValue; x++)
                        {
                            if (i == 0)
                            {
                                if (((i + 1) * x).ToString().Length==3)
                                {
                                    result = result + ((i + 1) * x).ToString() + "  ";
                                }
                                else if (((i + 1) * x).ToString().Length == 2)
                                {
                                    result = result + ((i + 1) * x).ToString() + "    ";
                                }
                                else
                                {
                                    result = result + ((i + 1) * x).ToString() + "      ";
                                }
                            }
                            else if (x == 0)
                            {
                                if (((1 + x) * i).ToString().Length == 3)
                                {
                                    result = result + ((1 + x) * i).ToString() + "  ";
                                }
                                else if (((1 + x) * i).ToString().Length == 2)
                                {
                                    result = result + ((1 + x) * i).ToString() + "    ";
                                }
                                else
                                {
                                    result = result + ((1 + x) * i).ToString() + "      ";
                                }
                            }
                            else
                            {
                                if ((x * i).ToString().Length == 3)
                                {
                                    result = result + (x * i).ToString() + "  ";
                                }
                                else if ((x * i).ToString().Length == 2)
                                {
                                    result = result + (x * i).ToString() + "    ";
                                }
                                else
                                {
                                    result = result + (x * i).ToString() + "      ";
                                }
                            }
                        }
                        result = result + "\n";
                    }
                }
                else
                {
                    MessageBox.Show("1 ve 15 arası sayı girilmelidir.", "Hata");
                }
                label9.Text = result;
            }
            catch
            {
                MessageBox.Show("Bir tam sayı girilmelidir", "Hata");
                label9.Text = "";
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                var textboxValue = Convert.ToInt32(textBox6.Text);
                if (textboxValue <= 0)
                {
                    MessageBox.Show("Pozitif bir sayı girilmelidir", "Hata");
                    label7.Text = "Hata";
                }
                else
                {
                    int result = 0;
                    int x = 0;
                    int y = 1;
                    if (textboxValue == 1 || textboxValue == 2)
                    {
                        label7.Text = "1";
                    }
                    else
                    {
                        for (int i = 2; i <= textboxValue; i++)
                        {
                            result = x + y;
                            x = y;
                            y = result;
                        }
                        label7.Text = result.ToString();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Pozitif bir sayı girilmelidir", "Hata");
                label7.Text = "Hata";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();
            StreamReader streamReader = File.OpenText(openFileDialog.FileName);
            string fileContent;
            double gecici;
            List<double> numbers = new List<double>();
            while ((fileContent = streamReader.ReadLine()) != null)
            {
                string[] readLineNumbers = Regex.Split(fileContent, @"[^0-9\,-]+");
                foreach (var item in readLineNumbers)
                {
                    if (item != "")
                    {
                        numbers.Add(Convert.ToDouble(item));
                    }
                }
            }
            for (int i = 0; i < numbers.Count; i++)
            {
                for (int x = i; x < numbers.Count; x++)
                {
                    if (numbers[i] < numbers[x])
                    {
                        gecici = numbers[x];
                        numbers[x] = numbers[i];
                        numbers[i] = gecici;
                    }
                }
            }
            for (int i = 0; i < numbers.Count; i++)
            {
                listBox1.Items.Add(numbers[i]);
            }
            streamReader.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox4.Enabled = false;
            textBox1.Text = "0";
            textBox2.Text = "0";
            textBox3.Text = "0";
            textBox5.Text = "1";
            textBox6.Text = "1";
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
