using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows;

namespace SoftTradePlus
{
	class ProductsByClientsViewModel
	{
		public ObservableCollection<ProductsByClients> ViewList { get; set; }

        public ProductsByClientsViewModel()
		{
            ViewList = new ObservableCollection<ProductsByClients>();

            SqlConnection sqlcon = new SqlConnection(@"Data Source = " + DBcon.DBserver + "; Initial Catalog = " + DBcon.DBname + ";Integrated Security = True");
            string query = "Select * from STP.dbo.BoughtProductsView";
            try
            {
                sqlcon.Open();
                SqlCommand command = new SqlCommand(query, sqlcon);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    ProductsByClients newProductsByClients = new ProductsByClients
                    {
                        ClientName = reader.GetString("Client"),
                        Products = reader["Products"] as string
                    };
                    ViewList.Add(newProductsByClients);
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
        }
	}
}
