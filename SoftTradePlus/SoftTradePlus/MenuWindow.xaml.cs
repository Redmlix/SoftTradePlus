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

namespace SoftTradePlus
{
	/// <summary>
	/// Interaction logic for MenuWindow.xaml
	/// </summary>
	public partial class MenuWindow : Window
	{
		public MenuWindow()
		{
			InitializeComponent();
			window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
		}

		private void managersBtn_Click(object sender, RoutedEventArgs e)
		{
			this.Hide();
			ManagersWindow window = new ManagersWindow();
			window.Show();
		}

		private void clientsBtn_Click(object sender, RoutedEventArgs e)
		{
			this.Hide();
			ClientsWindow window = new ClientsWindow();
			window.Show();
		}

		private void productsBtn_Click(object sender, RoutedEventArgs e)
		{
			this.Hide();
			ProductsWindow window = new ProductsWindow();
			window.Show();
		}

		private void additViewsBtn_Click(object sender, RoutedEventArgs e)
		{
			this.Hide();
			AdditionalViews window = new AdditionalViews();
			window.Show();
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
	}
}
