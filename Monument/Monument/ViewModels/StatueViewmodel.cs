using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        //private Bruger _bruger;
        private Statuer _Statuer;
        private Adresse _Adresse;
        private Materialer _Materialer;
        public event PropertyChangedEventHandler PropertyChanged;
        
        public ObservableCollection<Statuer> StatuerList { get; set; }
        public ObservableCollection<Adresse> AdresseList { get; set; }

        public Statuer Statuer
        {
            get { return _Statuer; }
            set { _Statuer = value; OnPropertyChanged(); }
        }
        public Adresse Adresse
        {
            get { return _Adresse; }
            set { _Adresse = value; OnPropertyChanged(); }
        }
        public Materialer Materialer
        {
            get { return _Materialer; }
            set { _Materialer = value; OnPropertyChanged(); }
        }


        //////// Statue Commands //////////
        public Handler.StatuerHandler StatuerHandler { get;  }


        public ICommand AddStatuerCommand { get; set; }
        public ICommand DeleteStatuerCommand { get; set; }
        public ICommand UpdateStatuerCommand { get; set; }
        public ICommand GetStatuerCommand { get; set; }
        public ICommand GetStatuerListCommand { get; set; }

        ////////// Adresse Commands //////////
        public Handler.AdresseHandler AdresseHandler { get; }

        public ICommand AddAdresseCommand { get; set; }
        public ICommand DeleteAdresseCommand { get; set; }
        public ICommand UpdateAdresseCommand { get; set; }
        public ICommand GetAdresseCommand { get; set; }
        public ICommand GetAdresseListCommand { get; set; }

        ////////// Material Commands ////////
        /// 
        /// 

        public Handler.MaterialersHandler MaterialerHandler { get; }

        public ICommand AddMaterialerCommand { get; set; }
        public ICommand DeleteMaterialerCommand { get; set; }
        public ICommand UpdateMaterialerCommand { get; set; }
        public ICommand GetMaterialerCommand { get; set; }
        public ICommand GetMaterialerListCommand { get; set; }


        public StatueViewmodel()
        {
            StatuerHandler = new Handler.StatuerHandler(this);

            AddStatuerCommand = new RelayCommand(StatuerHandler.PostStatuer);
            DeleteStatuerCommand = new RelayCommand(StatuerHandler.DeleteStatuer);
            UpdateStatuerCommand = new RelayCommand(StatuerHandler.UpdateStatuer);
            GetStatuerCommand = new RelayCommand(StatuerHandler.GetStatuer);
            GetStatuerListCommand = new RelayCommand(StatuerHandler.GetStatuerList);

            AdresseHandler = new Handler.AdresseHandler(this);

            AddAdresseCommand = new RelayCommand(AdresseHandler.PostAdresse);
            DeleteAdresseCommand = new RelayCommand(AdresseHandler.DeleteAdresse);
            UpdateAdresseCommand = new RelayCommand(AdresseHandler.UpdateAdresse);
            GetAdresseCommand = new RelayCommand(AdresseHandler.GetAdresse);
            GetAdresseListCommand = new RelayCommand(AdresseHandler.GetAdresseList);

            MaterialerHandler = new Handler.MaterialersHandler(this);

            AddMaterialerCommand = new RelayCommand(MaterialerHandler.PostMaterialer);
            DeleteMaterialerCommand = new RelayCommand(MaterialerHandler.DeleteMaterialer);
            UpdateMaterialerCommand = new RelayCommand(MaterialerHandler.UpdateMaterialer);
            GetMaterialerCommand = new RelayCommand(MaterialerHandler.GetMaterialer);
            GetMaterialerListCommand = new RelayCommand(MaterialerHandler.GetMaterialerList);

            Statuer = new Statuer();
            Adresse = new Adresse();
            Materialer = new Materialer();
            StatuerList = new ObservableCollection<Statuer>();
            AdresseList = new ObservableCollection<Adresse>();

            StatuerHandler.GetStatuerList();
            AdresseHandler.GetAdresseList();

        }














        #region ProptertyChangedSupport
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        } 
        #endregion
    }
}
