using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for comf2.xaml
    /// </summary>
    public partial class comf2 : Window
    {
        public comf2()
        {
            InitializeComponent();
            fetch();
               
        }
        private void fetch() {
            TextReader tr = new StreamReader("phoneno.txt");
            textBox2.Text = tr.ReadLine();
            passwordBox2.Password = tr.ReadLine();
            textBox3.Text = tr.ReadLine();
            passwordBox1.Password = tr.ReadLine();
         //   MessageBox.Show(textBox2.Text+" "+textBox3.Text+" "+passwordBox2.Password+" "+passwordBox1.Password);
        
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            String phone1, phone2, pass1, pass2; ;
            phone1 = textBox2.Text;
            phone2 = textBox3.Text;
            pass1 = passwordBox2.Password;
            pass2 = passwordBox1.Password;
            save_to_file(phone1,pass1,phone2,pass2);
            
        }

        private void save_to_file(String phone1, String pass1, String phone2, String pass2) {
            TextWriter tw = new StreamWriter("phoneno.txt");
            
            // write a line of text to the file
            tw.WriteLine(phone1);
            tw.WriteLine(pass1);
            tw.WriteLine(phone2);
            tw.WriteLine(pass2);

            // close the stream
            tw.Close();
        
        
        }
        private void textBox2_TextChanged(object sender, TextChangedEventArgs e)
        {
            for (int i = 0; i < textBox2.Text.Length; i++)
            {
                if (!char.IsNumber(textBox2.Text[i]))
                {
                    MessageBox.Show("Please enter a valid number");
                    textBox2.Text = "";
                    return;
                }

            }
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
           
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
           
        }

        private void textBox3_TextChanged(object sender, TextChangedEventArgs e)
        { 
            
            for (int i = 0; i < textBox3.Text.Length; i++)
            {
                if (!char.IsNumber(textBox3.Text[i]))
                {
                    MessageBox.Show("Please enter a valid number");
                    textBox3.Text = "";
                    return;
                }

            }
        }
    }
}
