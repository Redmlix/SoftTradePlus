using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SoftTradePlus
{
	/// <summary>
	/// Interaction logic for ClientWindow.xaml
	/// </summary>
	public partial class ClientsWindow : Window
	{
		public ClientsWindow()
		{
			InitializeComponent();
			window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
			DataContext = new ClientViewModel();
		}

		private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			MessageBoxResult result = MessageBox.Show("Do you want to close app?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Question);
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
				string query = "insert into STP.dbo.Client(name_client, status_client, manager_client) " +
					"values(@name_client, @status_client, @manager_client)";
				SqlCommand command = new SqlCommand(query, sqlcon);
				if (clientNameTb.Text != "" && clientStatusCb.SelectedItem != null && clientManagerCb.SelectedItem != null)
				{
					command.Parameters.AddWithValue("@name_client", clientNameTb.Text);
					ClientStatus selectedStatusItem = (ClientStatus) clientStatusCb.SelectedItem;
					command.Parameters.AddWithValue("@status_client", selectedStatusItem.Id);
					Manager selectedManagerItem = (Manager)clientManagerCb.SelectedItem;
					command.Parameters.AddWithValue("@manager_client", selectedManagerItem.Id);
					command.ExecuteNonQuery();
				}
				else
				{
					command.Cancel();
					MessageBox.Show("Write/Choose data to add");
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			finally
			{
				sqlcon.Close();
			}
			DataContext = new ClientViewModel();
			clientNameTb.Text = null;
		}

		private void deleteBtn_Click(object sender, RoutedEventArgs e)
		{
			SqlConnection sqlcon = new SqlConnection(@"Data Source = " + DBcon.DBserver + "; Initial Catalog = " + DBcon.DBname + ";Integrated Security = True");
			sqlcon.Open();
			try
			{
				string query = "delete from Client where id_client = @id_client";
				SqlCommand command = new SqlCommand(query, sqlcon);
				Client selectedId = (Client)clientsTable.SelectedItem;
				if (selectedId != null)
				{
					command.Parameters.AddWithValue("@id_client", selectedId.Id);
					command.ExecuteNonQuery();
				}
				else
				{
					command.Cancel();
					MessageBox.Show("Choose record before deleting");
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			finally
			{
				sqlcon.Close();
			}
			DataContext = new ClientViewModel();
		}

		private void backBtn_Click(object sender, RoutedEventArgs e)
		{
			this.Hide();
			MenuWindow window = new MenuWindow();
			window.Show();
		}
	}
}
