using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows;

namespace SoftTradePlus
{
    class ProductsFullViewModel
    {
        public ObservableCollection<ProductsFull> ViewList { get; set; }

        public ProductsFullViewModel()
        {
            ViewList = new ObservableCollection<ProductsFull>();

            SqlConnection sqlcon = new SqlConnection(@"Data Source = " + DBcon.DBserver + "; Initial Catalog = " + DBcon.DBname + ";Integrated Security = True");
            string query = "Select * from STP.dbo.ProductView";
            try
            {
                sqlcon.Open();
                SqlCommand command = new SqlCommand(query, sqlcon);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    ProductsFull newProductsFull = new ProductsFull
                    {
                        Name = reader.GetString("Name"),
						Price = reader.GetDecimal("Price"),
                        Type = reader.GetString("Type"),
                        Date = reader["Expiring date"] as string
                    };
                    ViewList.Add(newProductsFull);
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