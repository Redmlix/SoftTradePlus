using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
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
	/// Interaction logic for ProductsWindow.xaml
	/// </summary>
	public partial class ProductsWindow : Window
	{
		public ProductsWindow()
		{
			InitializeComponent();
			window.WindowStartupLocation = WindowStartupLocation.CenterScreen;

			// Making that all dates will try to convert to yyyy-MM-dd format
			CultureInfo ci = CultureInfo.CreateSpecificCulture(CultureInfo.CurrentCulture.Name);
			ci.DateTimeFormat.ShortDatePattern = "yyyy-MM-dd";
			Thread.CurrentThread.CurrentCulture = ci;

			DataContext = new ProductViewModel();
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
				string query = "insert into STP.dbo.Product(name_product, price_product, type_product, sub_expiring_product) " +
					"values(@name_product, @price_product, @type_product, @sub_expiring_product)";
				SqlCommand command = new SqlCommand(query, sqlcon);
				command.Parameters.AddWithValue("@name_product", productNameTb.Text);
				command.Parameters.AddWithValue("@price_product", productPriceTb.Text);
				command.Parameters.AddWithValue("@type_product", productTypeCb.SelectedIndex + 1);  // id in combobox starts with 0 but id in db starts with 1
				command.Parameters.AddWithValue("@sub_expiring_product", productDateCalendar.SelectedDate.ToString());
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
			DataContext = new ProductViewModel();
			productNameTb.Text = null;
			productPriceTb.Text = null;
		}

		private void deleteBtn_Click(object sender, RoutedEventArgs e)
		{
			SqlConnection sqlcon = new SqlConnection(@"Data Source = " + DBcon.DBserver + "; Initial Catalog = " + DBcon.DBname + ";Integrated Security = True");
			sqlcon.Open();
			try
			{
				string query = "delete from Product where id_product = @id_product";
				SqlCommand command = new SqlCommand(query, sqlcon);
				Product selectedId = (Product)productsTable.SelectedItem;
				if (selectedId != null)
				{
					command.Parameters.AddWithValue("@id_product", selectedId.Id);
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
			DataContext = new ProductViewModel();
		}

		private void backBtn_Click(object sender, RoutedEventArgs e)
		{
			this.Hide();
			MenuWindow window = new MenuWindow();
			window.Show();
		}

		private void productPriceValidation(object sender, System.Windows.Input.TextCompositionEventArgs e)
		{
			bool approvedDecimalPoint = false;

			if (e.Text == ".")
			{
				if (!((TextBox)sender).Text.Contains("."))
					approvedDecimalPoint = true;
			}

			if (!(char.IsDigit(e.Text, e.Text.Length - 1) || approvedDecimalPoint))
				e.Handled = true;
		}

		private void productTypeCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			// Check if you choose lifetime license it blocks datepicker
			if (productTypeCb.SelectedIndex == 1)
			{
				productDateCalendar.SelectedDate = null;
				productDateCalendar.IsEnabled = false;
			}
			else
			{
				productDateCalendar.IsEnabled = true;
			}
		}
	}
}
