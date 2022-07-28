using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace SoftTradePlus
{
	class Client : INotifyPropertyChanged
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

        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                if (value == name)
                    return;
                name = value;
                OnPropertyChanged();
            }
        }

        private int status;
        public int Status
        {
            get { return status; }
            set
            {
                if (value == status)
                    return;
                status = value;
                OnPropertyChanged();
            }
        }

        private int manager;
        public int Manager
        {
            get { return manager; }
            set
            {
                if (value == manager)
                    return;
                manager = value;
                OnPropertyChanged();
            }
        }
    }
}
