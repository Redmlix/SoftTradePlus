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
	class ManagerViewModel : INotifyPropertyChanged
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

        public ManagerViewModel()
		{
            managers = new ObservableCollection<Manager>();
            managers.CollectionChanged += managers_CollectionChanged;

            SqlConnection sqlcon = new SqlConnection(@"Data Source = " + DBcon.DBserver + "; Initial Catalog = " + DBcon.DBname + ";Integrated Security = True");
            string query = "Select * from STP.dbo.Manager";
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

        private void managers_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null && e.NewItems.Count > 0)
            {
                foreach (INotifyPropertyChanged item in e.NewItems.OfType<INotifyPropertyChanged>())
                {
                    item.PropertyChanged += managers_PropertyChanged;
                }
            }
            if (e.OldItems != null && e.OldItems.Count > 0)
            {
                foreach (INotifyPropertyChanged item in e.OldItems.OfType<INotifyPropertyChanged>())
                {
                    item.PropertyChanged -= managers_PropertyChanged;
                }
            }
        }

        private void managers_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var row = sender as Manager;
            SaveData(row);
        }

        private void SaveData(Manager row)
        {
            SqlConnection sqlcon = new SqlConnection(@"Data Source = " + DBcon.DBserver + "; Initial Catalog = " + DBcon.DBname + ";Integrated Security = True");
            sqlcon.Open();
			try
			{
                string query = "update STP.dbo.Manager set name_manager = @name_manager where id_manager = @id_manager";
                SqlCommand command = new SqlCommand(query, sqlcon);
                command.Parameters.AddWithValue("@name_manager", row.Name);
                command.Parameters.AddWithValue("@id_manager", row.Id);
                command.ExecuteNonQuery();
            }
            catch(Exception ex)
			{
                MessageBox.Show("Use Correct/Existing data \n\n" + ex.Message, "Data not saved");
			}
			finally
            {
                sqlcon.Close();
			}
        }
    }
}
