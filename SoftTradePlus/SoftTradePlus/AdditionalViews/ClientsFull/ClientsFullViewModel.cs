using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows;

namespace SoftTradePlus
{
	class ClientsFullViewModel
	{
        public ObservableCollection<ClientsFull> ViewList { get; set; }

        public ClientsFullViewModel()
        {
            ViewList = new ObservableCollection<ClientsFull>();

            SqlConnection sqlcon = new SqlConnection(@"Data Source = " + DBcon.DBserver + "; Initial Catalog = " + DBcon.DBname + ";Integrated Security = True");
            string query = "Select * from STP.dbo.ClientView";
            try
            {
                sqlcon.Open();
                SqlCommand command = new SqlCommand(query, sqlcon);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    ClientsFull newClientsFull = new ClientsFull
                    {
                        Name = reader.GetString("Name"),
                        Status = reader.GetString("Status"),
                        Manager = reader.GetString("Manager"),
                    };
                    ViewList.Add(newClientsFull);
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
