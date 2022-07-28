using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace SoftTradePlus
{
	class BoughtProducts : INotifyPropertyChanged
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

        private int id;
        public int Id
        {
            get { return id; }
            set
            {
                if (value == id)
                    return;
                id = value;
                OnPropertyChanged();
            }
        }

        private int client;
        public int Client
        {
            get { return client; }
            set
            {
                if (value == client)
                    return;
                client = value;
                OnPropertyChanged();
            }
        }

        private int product;
        public int Product
        {
            get { return product; }
            set
            {
                if (value == product)
                    return;
                product = value;
                OnPropertyChanged();
            }
        }
    }
}
