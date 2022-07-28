using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
	/// Interaction logic for AdditionalViews.xaml
	/// </summary>
	public partial class AdditionalViews : Window
	{
		public AdditionalViews()
		{
			InitializeComponent();
			window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
			List<string> cbItems = new List<string> { "Clients by managers", "Products by clients", "Clients by status", "Products-full", "Clients-full"};
			viewPickCb.ItemsSource = cbItems;
		}

		private void viewPickCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			switch(viewPickCb.SelectedItem.ToString().Trim())
			{
				case "Clients by managers":
					DataContext = new ManagerClientsViewModel();
					break;
				case "Products by clients":
					DataContext = new ProductsByClientsViewModel();
					break;
				case "Clients by status":
					DataContext = new StatusClientsViewModel();
					break;
				case "Products-full":
					DataContext = new ProductsFullViewModel();
					break;
				case "Clients-full":
					DataContext = new ClientsFullViewModel();
					break;
				default:
					DataContext = null;
					break;
			}
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

		private void backBtn_Click(object sender, RoutedEventArgs e)
		{
			this.Hide();
			MenuWindow window = new MenuWindow();
			window.Show();
		}
	}
}
