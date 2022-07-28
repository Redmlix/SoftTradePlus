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
	class BoughtProductsViewModel : INotifyPropertyChanged
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

        private ObservableCollection<BoughtProducts> boughtProducts;
        public ObservableCollection<BoughtProducts> BoughtProducts
        { 
            get { return boughtProducts; }
            set
            {
                if (value == boughtProducts)
                    return;
                boughtProducts = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<ClientBuy> clientBuyers;
        public ObservableCollection<ClientBuy> ClientBuyers
        {
            get { return clientBuyers; }
            set
            {
                if (value == clientBuyers)
                    return;
                clientBuyers = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<ProductBought> productBoughts;
        public ObservableCollection<ProductBought> ProductBoughts
        {
            get { return productBoughts; }
            set
            {
                if (value == productBoughts)
                    return;
                productBoughts = value;
                OnPropertyChanged();
            }
        }

        public BoughtProductsViewModel()
        {
            boughtProducts = new ObservableCollection<BoughtProducts>();
            boughtProducts.CollectionChanged += boughtProducts_CollectionChanged;

            SqlConnection sqlcon = new SqlConnection(@"Data Source = " + DBcon.DBserver + "; Initial Catalog = " + DBcon.DBname + ";Integrated Security = True");
            string query = "Select * from STP.dbo.ClientProducts";
            try
            {
                sqlcon.Open();
                SqlCommand command = new SqlCommand(query, sqlcon);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    BoughtProducts newBoughtProducts = new BoughtProducts
                    {
                        Id = reader.GetInt32("id_clientProducts"),
                        Client = reader.GetInt32("id_client"),
                        Product = reader.GetInt32("id_product"),
                    };
                    boughtProducts.Add(newBoughtProducts);
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

            clientBuyers = new ObservableCollection<ClientBuy>();
            query = "Select id_client, name_client from STP.dbo.Client";
            try
            {
                sqlcon.Open();
                SqlCommand command = new SqlCommand(query, sqlcon);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    ClientBuy newClientBuy = new ClientBuy
                    {
                        Id = reader.GetInt32("id_client"),
                        Name = reader.GetString("name_client")
                    };

                    clientBuyers.Add(newClientBuy);
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

            productBoughts = new ObservableCollection<ProductBought>();
            query = "Select id_product, name_product from STP.dbo.Product";
            try
            {
                sqlcon.Open();
                SqlCommand command = new SqlCommand(query, sqlcon);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    ProductBought newProductBought = new ProductBought
                    {
                        Id = reader.GetInt32("id_product"),
                        Name = reader.GetString("name_product")
                    };

                    ProductBoughts.Add(newProductBought);
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

        private void boughtProducts_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null && e.NewItems.Count > 0)
            {
                foreach (INotifyPropertyChanged item in e.NewItems.OfType<INotifyPropertyChanged>())
                {
                    item.PropertyChanged += boughtProducts_PropertyChanged;
                }
            }
            if (e.OldItems != null && e.OldItems.Count > 0)
            {
                foreach (INotifyPropertyChanged item in e.OldItems.OfType<INotifyPropertyChanged>())
                {
                    item.PropertyChanged -= boughtProducts_PropertyChanged;
                }
            }
        }

        private void boughtProducts_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var row = sender as BoughtProducts;
            SaveData(row);
        }

        private void SaveData(BoughtProducts row)
        {
            SqlConnection sqlcon = new SqlConnection(@"Data Source = " + DBcon.DBserver + "; Initial Catalog = " + DBcon.DBname + ";Integrated Security = True");
            sqlcon.Open();
            try
            {
                string query = "update STP.dbo.ClientProducts set id_client = @id_client, id_product = @id_product" +
                    " where id_clientProducts = @id_clientProducts";
                SqlCommand command = new SqlCommand(query, sqlcon);
                command.Parameters.AddWithValue("@id_client", row.Client);
                command.Parameters.AddWithValue("@id_product", row.Product);
                command.Parameters.AddWithValue("@id_clientProducts", row.Id);
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
