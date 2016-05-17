using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Monument.Annotations;
using Monument.Common;
using Monument.Handler;


namespace Monument.ViewModels
{
    public class StatueViewmodel : INotifyPropertyChanged
    {
        private Bruger _bruger;
        private Statuer _Statuer;
        public event PropertyChangedEventHandler PropertyChanged;

        public Statuer Statuer
        {
            get { return _Statuer; }
            set { _Statuer = value; OnPropertyChanged(); }
        }

        public Handler.StatuerHandler StatuerHandler { get;  }


        public ICommand AddStatuerCommand { get; set; }
        public ICommand DeleteStatuerCommand { get; set; }
        public ICommand UpdateStatuerCommand { get; set; }
        public ICommand GetStatuerCommand { get; set; }
        public ICommand GetStatuerListCommand { get; set; }

        public StatueViewmodel()
        {
            StatuerHandler = new Handler.StatuerHandler(this);
            AddStatuerCommand = new RelayCommand(StatuerHandler.PostStatuer);
            DeleteStatuerCommand = new RelayCommand(StatuerHandler.DeleteStatuer);
            UpdateStatuerCommand = new RelayCommand(StatuerHandler.UpdateStatuer);
            GetStatuerCommand = new RelayCommand(StatuerHandler.GetStatuer);
            GetStatuerListCommand = new RelayCommand(StatuerHandler.GetStatuerList);

            Statuer = new Statuer();

        }














        #region MyRegion
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        } 
        #endregion
    }
}
