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
using System.Data.OleDb;
using System.Data;
using System.Windows.Controls.Primitives;
using WpfApplication1;

namespace Pramod_sms_app
{
	/// <summary>
	/// Interaction logic for Window1.xaml
	/// </summary>
	public partial class Window1 : Window
	{
		private string previousText;
		public Window1()
		{
			InitializeComponent();
			previousText = textBox1.Text;
		}

		
		
		private void button2_Click(object sender, RoutedEventArgs e)
		{
			OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\Users\yash\Desktop\Database1.accdb");
			con.Open();

			OleDbCommand cmd = new OleDbCommand("select Person.pName as Name,Person.pNumber from Person order by pName", con);
			DataTable ds = new DataTable("Person");
			OleDbDataAdapter da = new OleDbDataAdapter();
			da.SelectCommand = cmd;
			da.Fill(ds);

    dataGrid1.ItemsSource = ds.DefaultView; 
    }

		private void button1_Click(object sender, RoutedEventArgs e)
		{
			textBox1.Text = "";
			textBox2.Text = "";
		}

		private void button3_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\Users\yash\Desktop\Database1.accdb");
				con.Open();
				if (textBox1.Text == "" || textBox2.Text == "") { MessageBox.Show("fields are empty"); }
				else
				{
					OleDbCommand cmd = new OleDbCommand("insert into Person values('" + textBox1.Text.ToString() + "','" + textBox2.Text.ToString() + "')", con);
					int row;
		//			MessageBox.Show("Till here it is working");
					row = cmd.ExecuteNonQuery();
					if (row > 0)
					{
						MessageBox.Show("data has been inserted");
					}
					else { MessageBox.Show(" data not inserted"); }
				}

				//here
				OleDbCommand cmd1 = new OleDbCommand("select pName,pNumber from Person order by pName", con);
				DataTable ds = new DataTable("Person");
				OleDbDataAdapter da = new OleDbDataAdapter();
				da.SelectCommand = cmd1;
				da.Fill(ds);

				dataGrid1.ItemsSource = ds.DefaultView;
			}
			catch (Exception)
			{
				if (textBox1.Text == "" || textBox2.Text == "") { MessageBox.Show("Name and Number field must be filled"); }
				else
				{
					MessageBox.Show("INVALID OPERATION, DON'T ADD DUPLICATE VALUE OF PHONE NUMBER");
				}
			}
		}

		private void button4_Click(object sender, RoutedEventArgs e)
		{
			OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\Users\yash\Desktop\Database1.accdb");
			con.Open();
			if (textBox1.Text == "" && textBox2.Text == "") { MessageBox.Show("fields are empty"); }
			OleDbCommand cmd = new OleDbCommand("delete from Person where pNumber='" + textBox1.Text + "'", con);
			int row;
		//	MessageBox.Show("Till here it is working");
			row = cmd.ExecuteNonQuery();
			if (row > 0)
			{
			  MessageBox.Show("data has been deleted");
			}
			else { MessageBox.Show("not deleted"); }
			//for deletion
			
			//here

			OleDbCommand cmd1 = new OleDbCommand("select pName,pNumber from Person order by pName", con);
			DataTable ds = new DataTable("Person");
			OleDbDataAdapter da = new OleDbDataAdapter();
			da.SelectCommand = cmd1;
			da.Fill(ds);

			dataGrid1.ItemsSource = ds.DefaultView; 
		}

		private void button5_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\Users\yash\Desktop\Database1.accdb");
				con.Open();

				OleDbCommand cmd = new OleDbCommand("select pNumber from Person where(pName = '" + textBox2.Text + "')", con);
				String validate_email;
				validate_email = (String)cmd.ExecuteScalar();
				if (validate_email != null)
				{
					textBox1.Text = validate_email.ToString();
				}
			}
			catch (Exception ex) { MessageBox.Show("Not found"); }
		}

		private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
		{
			//if (string.IsNullOrEmpty(((TextBox)sender).Text))
			//  previousText = "ONLY NUMERIC DATA";
			//else
			//{
			//  double num = 0;
			//  bool success = double.TryParse(((TextBox)sender).Text, out num);
			//  if (success & num >= 0)
			//  {
			//    ((TextBox)sender).Text.Trim();
			//    previousText = ((TextBox)sender).Text;
			//  }
			//  else
			//  {
			//    ((TextBox)sender).Text = previousText;
			//    ((TextBox)sender).SelectionStart = ((TextBox)sender).Text.Length;
			//  }
			//}
		}

		private void button6_Click(object sender, RoutedEventArgs e)
		{
		var objForm2 = new MainWindow();
			objForm2._valueOfForm1 = textBox1.Text;
			objForm2.Show();
			this.Hide();
		}

		private void dataGrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			
				try
				{
					int num = dataGrid1.SelectedIndex;
					//		MessageBox.Show(num);
					this.textBox1.Text = ((DataRowView)dataGrid1.Items[num]).Row["pNumber"].ToString();
					this.textBox2.Text = ((DataRowView)dataGrid1.Items[num]).Row["Name"].ToString();


				}
				catch (Exception)
				{ }

			

		}

		private void textBox2_TextChanged(object sender, TextChangedEventArgs e)
		{

		}

	
					}
				}
			
		

		

		
		 		
	

