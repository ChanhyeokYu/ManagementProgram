using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Model
{
    class MainModel : INotifyPropertyChanged
    {

        private int num = 1;    

        public int Num
        {
            set
            { num = value;
                Num2 = value * 2;
                OnPropertyChanged("Num");
            }
            get
            {
                return num;
            }
        }

        private int num2 = 1;

        public int Num2
        { 
            get { return num2; }
            set 
            { 
                num2 = value;
                OnPropertyChanged("Num2");
            }   
        }


        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
