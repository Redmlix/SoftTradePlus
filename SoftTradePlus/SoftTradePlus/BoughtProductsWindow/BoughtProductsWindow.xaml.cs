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
	/// Interaction logic for BoughtProductsWindow.xaml
	/// </summary>
	public partial class BoughtProductsWindow : Window
	{
		public BoughtProductsWindow()
		{
			InitializeComponent();
			window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
			DataContext = new BoughtProductsViewModel();
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
				string query = "insert into STP.dbo.ClientProducts(id_client, id_product) " +
					"values(@id_client, @id_product)";
				SqlCommand command = new SqlCommand(query, sqlcon);
				if (clientsCb.SelectedItem != null && productsCb.SelectedItem != null)
				{
					ClientBuy selectedClient = (ClientBuy)clientsCb.SelectedItem;
					command.Parameters.AddWithValue("@id_client", selectedClient.Id);
					ProductBought selectedProduct = (ProductBought)productsCb.SelectedItem;
					command.Parameters.AddWithValue("@id_product", selectedProduct.Id);
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
			DataContext = new BoughtProductsViewModel();
		}

		private void deleteBtn_Click(object sender, RoutedEventArgs e)
		{
			SqlConnection sqlcon = new SqlConnection(@"Data Source = " + DBcon.DBserver + "; Initial Catalog = " + DBcon.DBname + ";Integrated Security = True");
			sqlcon.Open();
			try
			{
				SqlCommand command;
				BoughtProducts selectedId;
				if (boughtProductsTable.SelectedIndex >= 0)
				{
					for (int i = boughtProductsTable.SelectedItems.Count - 1; i >= 0; i--)
					{
						string query = "delete from ClientProducts where id_clientProducts = @id_clientProducts";
						command = new SqlCommand(query, sqlcon);
						selectedId = (BoughtProducts)boughtProductsTable.SelectedItems[i];
						command.Parameters.AddWithValue("@id_clientProducts", selectedId.Id);
						command.ExecuteNonQuery();
					}
				}
				else
				{
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
			DataContext = new BoughtProductsViewModel();
		}

		private void backBtn_Click(object sender, RoutedEventArgs e)
		{
			this.Hide();
			MenuWindow window = new MenuWindow();
			window.Show();
		}
	}
}
