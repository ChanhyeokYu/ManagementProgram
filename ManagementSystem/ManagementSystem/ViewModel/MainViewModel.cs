using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;


namespace ManagementSystem.ViewModel
{
    class MainViewModel : INotifyPropertyChanged
    {

        private Model.MainModel _model;
        private Core.Repo _repo;
        private System.Timers.Timer _timer;
        private string _connstring = @"Data Source=127.0.0.1;Initial Catalog=mydb;User ID=Admin;Password=1234;Encrypt=True;TrustServerCertificate=True;";

        public event PropertyChangedEventHandler? PropertyChanged;

        public MainViewModel() 
        { 
            _model = new Model.MainModel();
            _repo = new Core.Repo(_connstring);

            _timer = new System.Timers.Timer(1000);
            _timer.Elapsed += TmrMonitoring;
            _timer.Start();
        }

        public DataView DV_1
        {
            get { return _model.dv_1; }
            set { _model.dv_1 = value; OnPropertyChanged("DV_1"); }
        }
        private void TmrMonitoring(object? sender, ElapsedEventArgs e)
        {
            DV_1 = _repo.GetData().Copy().DefaultView;
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
