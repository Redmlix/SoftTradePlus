using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows;

namespace SoftTradePlus
{
    class ManagerClientsViewModel
    {
        public ObservableCollection<ManagerClients> ViewList { get; set; }

        public ManagerClientsViewModel()
        {
            ViewList = new ObservableCollection<ManagerClients>();

            SqlConnection sqlcon = new SqlConnection(@"Data Source = " + DBcon.DBserver + "; Initial Catalog = " + DBcon.DBname + ";Integrated Security = True");
            string query = "Select * from STP.dbo.ManagerClientsView";
            try
            {
                sqlcon.Open();
                SqlCommand command = new SqlCommand(query, sqlcon);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    ManagerClients newManagerClients = new ManagerClients
                    {
                        Manager = reader.GetString("Manager"),
                        Clients = reader["Clients"] as string,
                    };
                    ViewList.Add(newManagerClients);
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
