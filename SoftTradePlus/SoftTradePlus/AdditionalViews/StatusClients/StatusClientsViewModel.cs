using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows;

namespace SoftTradePlus
{
	class StatusClientsViewModel
	{
        public ObservableCollection<StatusClients> ViewList { get; set; }

        public StatusClientsViewModel()
        {
            ViewList = new ObservableCollection<StatusClients>();

            SqlConnection sqlcon = new SqlConnection(@"Data Source = " + DBcon.DBserver + "; Initial Catalog = " + DBcon.DBname + ";Integrated Security = True");
            string query = "Select * from STP.dbo.StatusClientsView";
            try
            {
                sqlcon.Open();
                SqlCommand command = new SqlCommand(query, sqlcon);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    StatusClients newStatusClients = new StatusClients
                    {
                        Status = reader.GetString("Status"),
                        Clients = reader["Clients"] as string,
                    };
                    ViewList.Add(newStatusClients);
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
