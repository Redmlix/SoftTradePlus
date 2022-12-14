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
				if (productNameTb.Text != "" && productPriceTb.Text != "" && productTypeCb.SelectedItem != null)
				{
					command.Parameters.AddWithValue("@name_product", productNameTb.Text);
					command.Parameters.AddWithValue("@price_product", productPriceTb.Text);
					ProductType selectedProductTypeItem = (ProductType)productTypeCb.SelectedItem;
					command.Parameters.AddWithValue("@type_product", selectedProductTypeItem.Id);
					if (productDateCalendar.SelectedDate != null)
					{
						// if selected date is not null we convert date format
						// not converting to DateTime will make that ToString won't have setting for date format
						DateTime selectedDate = (DateTime)productDateCalendar.SelectedDate;
						command.Parameters.AddWithValue("@sub_expiring_product", selectedDate.ToString("yyyy-MM-dd"));
					}
					else
					{
						// if selected date is null - just save as it is
						command.Parameters.AddWithValue("@sub_expiring_product", productDateCalendar.SelectedDate.ToString());
					}
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
				SqlCommand command;
				Product selectedId;
				if (productsTable.SelectedIndex >= 0)
				{
					for (int i = productsTable.SelectedItems.Count - 1; i >= 0; i--)
					{
						string query = "delete from Product where id_product = @id_product";
						command = new SqlCommand(query, sqlcon);
						selectedId = (Product)productsTable.SelectedItems[i];
						command.Parameters.AddWithValue("@id_product", selectedId.Id);
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
