using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;

namespace SoftTradePlus
{
	class ClientViewModel : INotifyPropertyChanged
	{
        #region INotifyPropertyChanged Impl
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        private ObservableCollection<ClientStatus> clientStatuses;
        public ObservableCollection<ClientStatus> ClientStatuses
        {
            get { return clientStatuses; }
            set
            {
                if (value == clientStatuses)
                    return;
                clientStatuses = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Manager> managers;
        public ObservableCollection<Manager> Managers
        {
            get { return managers; }
            set
            {
                if (value == managers)
                    return;
                managers = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Client> clients;
        public ObservableCollection<Client> Clients
        {
            get { return clients; }
            set
            {
                if (value == clients)
                    return;
                clients = value;
                OnPropertyChanged();
            }
        }

        public ClientViewModel()
        {
            clients = new ObservableCollection<Client>();
            clients.CollectionChanged += clients_CollectionChanged;

            SqlConnection sqlcon = new SqlConnection(@"Data Source = " + DBcon.DBserver + "; Initial Catalog = " + DBcon.DBname + ";Integrated Security = True");
            string query = "Select * from STP.dbo.Client";
            try
            {
                sqlcon.Open();
                SqlCommand command = new SqlCommand(query, sqlcon);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Client newClient = new Client
                    {
                        Id = reader.GetInt32("id_client"),
                        Name = reader.GetString("name_client"),
                        Status = reader.GetInt32("status_client"),
                        Manager = reader.GetInt32("manager_client"),
                    };
                    clients.Add(newClient);
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

            clientStatuses = new ObservableCollection<ClientStatus>();
            query = "Select * from STP.dbo.ClientStatus";
            try
            {
                sqlcon.Open();
                SqlCommand command = new SqlCommand(query, sqlcon);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    ClientStatus newClientStatus = new ClientStatus
                    {
                        Id = reader.GetInt32("id_clientStatus"),
                        Name = reader.GetString("name_clientStatus")
                    };

                    clientStatuses.Add(newClientStatus);
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

            managers = new ObservableCollection<Manager>();
            query = "Select * from STP.dbo.Manager";
            try
            {
                sqlcon.Open();
                SqlCommand command = new SqlCommand(query, sqlcon);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Manager newManager = new Manager
                    {
                        Id = reader.GetInt32("id_manager"),
                        Name = reader.GetString("name_manager")
                    };

                    managers.Add(newManager);
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
        private void clients_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null && e.NewItems.Count > 0)
            {
                foreach (INotifyPropertyChanged item in e.NewItems.OfType<INotifyPropertyChanged>())
                {
                    item.PropertyChanged += clients_PropertyChanged;
                }
            }
            if (e.OldItems != null && e.OldItems.Count > 0)
            {
                foreach (INotifyPropertyChanged item in e.OldItems.OfType<INotifyPropertyChanged>())
                {
                    item.PropertyChanged -= clients_PropertyChanged;
                }
            }
        }

        private void clients_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var row = sender as Client;
            SaveData(row);
        }

        private void SaveData(Client row)
        {
            SqlConnection sqlcon = new SqlConnection(@"Data Source = " + DBcon.DBserver + "; Initial Catalog = " + DBcon.DBname + ";Integrated Security = True");
            sqlcon.Open();
            try
            {
                string query = "update STP.dbo.Client set name_client = @name_client, status_client = @status_client, manager_client = @manager_client" +
                    " where id_client = @id_client";
                SqlCommand command = new SqlCommand(query, sqlcon);
                command.Parameters.AddWithValue("@name_client", row.Name);
                command.Parameters.AddWithValue("@status_client", row.Status);
                command.Parameters.AddWithValue("@manager_client", row.Manager);
                command.Parameters.AddWithValue("@id_client", row.Id);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Data not saved");
            }
            finally
            {
                sqlcon.Close();
            }
        }
    }
}
