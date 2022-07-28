using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;

namespace SoftTradePlus
{
	/// <summary>
	/// Interaction logic for ManagersWindow.xaml
	/// </summary>
	public partial class ManagersWindow : Window
	{ 
		public ManagersWindow()
		{
			InitializeComponent();
			window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
			DataContext = new ManagerViewModel();
		}

		private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			MessageBoxResult result = MessageBox.Show("Do you want to close app?","Warning", MessageBoxButton.YesNo, MessageBoxImage.Question);
			if (result == MessageBoxResult.No)
			{
				e.Cancel = true;
			}
			else
			{
				Environment.Exit(0);
			}
		}

		private void addBtn_Click(object sender, RoutedEventArgs e)
		{
			SqlConnection sqlcon = new SqlConnection(@"Data Source = " + DBcon.DBserver + "; Initial Catalog = " + DBcon.DBname + ";Integrated Security = True");
			sqlcon.Open();
			try
			{
				string query = "insert into STP.dbo.Manager(name_manager) values(@name_manager)";
				SqlCommand command = new SqlCommand(query, sqlcon);
				command.Parameters.AddWithValue("@name_manager", managerNameTb.Text);
				command.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			finally
			{
				sqlcon.Close();
			}
			DataContext = new ManagerViewModel();
		}

		private void deleteBtn_Click(object sender, RoutedEventArgs e)
		{
			SqlConnection sqlcon = new SqlConnection(@"Data Source = " + DBcon.DBserver + "; Initial Catalog = " + DBcon.DBname + ";Integrated Security = True");
			sqlcon.Open();
			try
			{
				string query = "delete from Manager where id_manager = @id_manager";
				SqlCommand command = new SqlCommand(query, sqlcon);
				Manager selectedId = (Manager)managersTable.SelectedItem;
				command.Parameters.AddWithValue("@id_manager", selectedId.Id);
				command.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			finally
			{
				sqlcon.Close();
			}
			DataContext = new ManagerViewModel();
		}

		private void backBtn_Click(object sender, RoutedEventArgs e)
		{
			this.Hide();
			MenuWindow window = new MenuWindow();
			window.Show();
		}
	}
}
