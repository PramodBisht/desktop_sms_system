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
using System.Net.Mail;

namespace Pramod_sms_app
{
	/// <summary>
	/// Interaction logic for Window2.xaml
	/// </summary>
	public partial class Window2 : Window
	{
		public Window2()
		{
			InitializeComponent();
		}

		public void AttachmentButton_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				MailMessage mail = new MailMessage();
				SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
				mail.From = new MailAddress(txtFrom.Text);
				mail.To.Add(txtTo.Text);
				mail.Subject = txtSubject.Text;
				mail.Body = txtMessage.Text;
				SmtpServer.Port = 587;
				SmtpServer.Credentials = new System.Net.NetworkCredential(usernameTB.Text, textBox1.Text);
				SmtpServer.EnableSsl = true;

				SmtpServer.Send(mail);
			}
			catch (Exception ex) { MessageBox.Show(ex.ToString()); }
		}
		

	public void SendButton_Click(object sender, RoutedEventArgs e)
	{
		try
		{
			MailMessage mail = new MailMessage();
			SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
			mail.From = new MailAddress(txtFrom.Text);
			mail.To.Add(txtTo.Text);
			mail.Subject = txtSubject.Text;
			mail.Body = txtMessage.Text;
			//Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
			//string filename = dlg.FileName;
			//pathTB.Text = filename;
			Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();



			// Set filter for file extension and default file extension 

			dlg.DefaultExt = ".txt";

			dlg.Filter = "txt files (*.txt)|*.txt|JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif|All files (*.*)|*.*";



			// Display OpenFileDialog by calling ShowDialog method 

			Nullable<bool> result = dlg.ShowDialog();



			// Get the selected file name and display in a TextBox 

			if (result == true)
			{

				// Open document 

				string filename1 = dlg.FileName;

				pathTB.Text = filename1;

				System.Net.Mail.Attachment attachment;

				attachment = new System.Net.Mail.Attachment(filename1);


				mail.Attachments.Add(attachment);

				SmtpServer.Port = 587;
				SmtpServer.Credentials = new System.Net.NetworkCredential(usernameTB.Text, textBox1.Text);
				SmtpServer.EnableSsl = true;

				SmtpServer.Send(mail);
			}
		}
		catch (Exception ep) { MessageBox.Show(ep.ToString()); }
		
			
		}
	

		
	}
}
