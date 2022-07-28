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
	class ProductViewModel : INotifyPropertyChanged
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

        private ObservableCollection<ProductType> productTypes;
        public ObservableCollection<ProductType> ProductTypes
        {
            get { return productTypes; }
            set
            {
                if (value == productTypes)
                    return;
                productTypes = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Product> products;
        public ObservableCollection<Product> Products
        {
            get { return products; }
            set
            {
                if (value == products)
                    return;
                products = value;
                OnPropertyChanged();
            }
        }

        public ProductViewModel()
        {
            products = new ObservableCollection<Product>();
            products.CollectionChanged += products_CollectionChanged;

            SqlConnection sqlcon = new SqlConnection(@"Data Source = " + DBcon.DBserver + "; Initial Catalog = " + DBcon.DBname + ";Integrated Security = True");
            string query = "Select * from STP.dbo.Product";
            try
            {
                sqlcon.Open();
                SqlCommand command = new SqlCommand(query, sqlcon);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Product newProduct = new Product
                    {
                        Id = reader.GetInt32("id_product"),
                        Name = reader.GetString("name_product"),
                        Price = reader.GetDecimal("price_product"),
                        Type = reader.GetInt32("type_product"),
                        Date = reader.GetDateTime("sub_expiring_product")
                    };
                    products.Add(newProduct);
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

            productTypes = new ObservableCollection<ProductType>();
            query = "Select * from STP.dbo.ProductType";
            try
            {
                sqlcon.Open();
                SqlCommand command = new SqlCommand(query, sqlcon);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    ProductType newProductType = new ProductType
                    {
                        Id = reader.GetInt32("id_productType"),
                        Name = reader.GetString("name_productType")
                    };

                    productTypes.Add(newProductType);
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

        private void products_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null && e.NewItems.Count > 0)
            {
                foreach (INotifyPropertyChanged item in e.NewItems.OfType<INotifyPropertyChanged>())
                {
                    item.PropertyChanged += products_PropertyChanged;
                }
            }
            if (e.OldItems != null && e.OldItems.Count > 0)
            {
                foreach (INotifyPropertyChanged item in e.OldItems.OfType<INotifyPropertyChanged>())
                {
                    item.PropertyChanged -= products_PropertyChanged;
                }
            }
        }

        private void products_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var row = sender as Product;
            SaveData(row);
        }

        private void SaveData(Product row)
        {
            SqlConnection sqlcon = new SqlConnection(@"Data Source = " + DBcon.DBserver + "; Initial Catalog = " + DBcon.DBname + ";Integrated Security = True");
            sqlcon.Open();
            try
            {
                string query = "update STP.dbo.Product set name_product = @name_product, price_product = @price_product, type_product = @type_product, sub_expiring_product = @sub_expiring_product" +
                    " where id_product = @id_product";
                SqlCommand command = new SqlCommand(query, sqlcon);
                command.Parameters.AddWithValue("@name_product", row.Name);
                command.Parameters.AddWithValue("@price_product", row.Price);
                command.Parameters.AddWithValue("@type_product", row.Type);
                command.Parameters.AddWithValue("@sub_expiring_product", row.Date);
                command.Parameters.AddWithValue("@id_product", row.Id);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
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
