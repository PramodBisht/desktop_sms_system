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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Net;
using System.Threading;
using Pramod_sms_app;
namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    ///
  
    public partial class MainWindow : Window
    {
			public string _valueOfForm1 = "";

        string Id, pass, sendTo, messge,sv;
        int cl = 0;

        int x = 0;
       
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += (s, e) =>
            {
							textBox3.Text = _valueOfForm1;

                GlassEffectHelper.EnableGlassEffect(this);
            };
            
            
        }
   //public   String[] BulkMessages(String sendTo) {
   //         for (int i = 0; i < sendTo.Length; i++) {
   //             if (sendTo[i] == ';') {
   //                 cl++;
   //             }
   //         }
   //        
   //         String []bk = new String[cl + 1];
   //         int ct ;
   //         int m = 0;
   //         for (int i = 0; i < cl + 1; i++)
   //         {
   //             ct = 0;
   //         for(;ct!=10;m++){
           
               
   //             bk[i] = bk[i] + sendTo[m];
        
   //             ct++;
   //         }
   //         m=m+2;
   //     }
   //         //for (int l = 0; l < cl + 1; l++) {
   //         //    MessageBox.Show(bk[l]);
   //         //}
   //         return bk;
        
   //     }


        private void button1_Click(object sender, RoutedEventArgs e)
        {
            press();

            GC.Collect();
        }
        public void press() {
            cl = 0;
            
            sv = comboBox1.Text;
      

            sendTo = textBox3.Text;
    
          
            for (int i = 0; i < sendTo.Length; i++)
            {
                if (sendTo[i] == ';'||sendTo[i]==',')
                {
                    cl++;
                }
            }
            if(sendTo==" "){
            cl=-1;
            }
        
            String[] bk = new String[cl + 1];
            int ct;
            int m = 0;
            for (int i = 0; i < cl + 1; i++)
            {
                ct = 0;
                for (; ct != 10; m++)
                {


                    bk[i] = bk[i] + sendTo[m];

                    ct++;
                }
                m = m + 2;
            }
            for (int l = 0; l < cl + 1; l++)
            {
                // MessageBox.Show(bk[l]+"  "+ bk[l].Length);
            }

            //area 

            for (int i = 0; i < cl + 1; i++)
            {
                sendTo = bk[i];


               
                if (sendTo.Length != 10)
                {
                    MessageBox.Show("This is invalid no");
                    continue;

                }


                messge = StringFromRichTextBox(richTextBox1);
             
                messge = messge + x;
         
                if (sv == "way2sms")
                {
                    x++;
                 
                    sendSMS sc = new sendSMS();
                 
                    TextReader tr = new StreamReader("phoneno.txt");
                    Id = tr.ReadLine();
                    pass = tr.ReadLine();
                  
                    sc.send(Id, pass, messge, sendTo, sv);
                
                }
                else
                {

                    x++;
                
                    sendSMS sd = new sendSMS(); 
                    TextReader tr = new StreamReader("phoneno.txt");
                    tr.ReadLine();
                    tr.ReadLine();
                    Id = tr.ReadLine();
                    pass = tr.ReadLine();

                    sd.send(Id, pass, messge, sendTo, sv);
                }
          
                //  GC.Collect();
             //   int milliseconds = 5000;
               //  Thread.Sleep(milliseconds);
              //  GC.Collect();

            }
        
        }

      
        class sendSMS
        {
            public void send(string uid, string password, string message, string no,string sv)
            {
                
                string mess = null;
                mess = message;
                try
                {
        //            if (sv == "freesms8")
        //            {
        //                HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create("http://www.freesms8.in/QuickSent.aspx?uid=" + uid + "&pwd=" + password +
        //"&msg=" + message + "&phone=" + no);

        //                HttpWebResponse myResp = (HttpWebResponse)myReq.GetResponse();
        //                System.IO.StreamReader respStreamReader = new System.IO.StreamReader(myResp.GetResponseStream());
        //                string rs = respStreamReader.ReadToEnd();
        //                respStreamReader.Close();
        //                myResp.Close();
        //                MessageBox.Show("Message Sent Successful");
        //            }
        //            else
                    {

           //    MessageBox.Show(uid+" "+password+" "+mess+" "+no);
                        HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create("http://ubaid.tk/sms/sms.aspx?uid=" + uid + "&pwd=" + password +
        "&msg=" + mess + "&phone=" + no + "&provider=" + sv);

                        HttpWebResponse myResp = (HttpWebResponse)myReq.GetResponse();
                        System.IO.StreamReader respStreamReader = new System.IO.StreamReader(myResp.GetResponseStream());
                        string rs = respStreamReader.ReadToEnd();
                        respStreamReader.Close();
                        myResp.Close();
                        if (rs == "1")
                        {
                            MessageBox.Show("Message Sent Successfully");
                        }else  if (rs == "-1")
                        {
                            MessageBox.Show("server erro");
                        }else 
                             if (rs == "-2")
                        {
                            MessageBox.Show("Invalid username");
                        }else 
                                  if (rs == "-3")
                        {
                            MessageBox.Show("Invalid message text");
                        }else 
                                       if (rs == "-4")
                        {
                            MessageBox.Show("Login Failed");
                        } else
                                           if (rs == "-5")
                                           {
                                               MessageBox.Show("IP blocked");
                                           }
                    }
                }
                catch (Exception er)
                {
                    MessageBox.Show(er.Message);
                }
                
            }
        }
        string StringFromRichTextBox(RichTextBox rtb)
        {
            TextRange textRange = new TextRange(
         
                rtb.Document.ContentStart,
              
                rtb.Document.ContentEnd
            );

         
            return textRange.Text;
        }
       

        private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void richTextBox1_TextChanged(object sender, TextChangedEventArgs e)
        {

            if (StringFromRichTextBox(richTextBox1).Length >= 135)
            {

                MessageBox.Show("Message length is limited to 140 only");
                //  richTextBox1.IsDocumentEnabled = false;
             //   richTextBox1.IsReadOnly = true;
            }
            else {

              //  richTextBox1.IsReadOnly = false;
            }
        }

        private void textBox2_TextChanged(object sender, TextChangedEventArgs e)
        {

        }



        private void Window_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

        }

        private void userid_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
           
        }

        
        private void textBox3_TextChanged(object sender, TextChangedEventArgs e)
        {
            //for (int i = 0; i < textBox3.Text.Length; i++)
            //{
            //    if ((char.IsNumber(textBox3.Text[i])) || textBox3.Text[i] == ';' || textBox3.Text[i] == ',')
            //    {
            //        // MessageBox.Show("Please enter a valid number");
            //        //   textBox3.Text = "";
            //        //if (textBox3.Text[i] == ';' || textBox3.Text[i] == ',') {
            //        //    //textBox3.Text[i] = textBox3.Text[i] + " ";
            //        //}
            //      //  return;
            //    }
            //    else {
            //        MessageBox.Show("Please enter a valid number");

            //      //  textBox3.Text = "";
            //        return;
            //    }

            //}

            for (int i = 0; i < textBox3.Text.Length; i++)
            {
                if (!char.IsNumber(textBox3.Text[i]))
                {
                    if (!(textBox3.Text[i] == ';' || textBox3.Text[i] == ',' || textBox3.Text[i] == ' '))
                    {
                        MessageBox.Show("Please enter a valid number");
                        textBox3.Text = "";
                     //   return;
                    }
                }

            }


        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            comf2 con = new comf2();
            con.Show();
          
        }

				private void button2_Click(object sender, RoutedEventArgs e)
				{
					var newWindow = new Window1();
					newWindow.Show();
				}

				private void button3_Click(object sender, RoutedEventArgs e)
				{
					var newWindow = new Window2();
					newWindow.Show();
				}

				
    }
   
    
}
