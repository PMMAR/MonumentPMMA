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
using WebMonument;


namespace Monument.ViewModels
{
    public class StatueViewmodel : INotifyPropertyChanged
    {
        //private Bruger _bruger;
        private Statuer _Statuer;
        private Adresse _Adresse;
        private Materialer _Materialer;
        private StatuerType _StatuerType;
        private StatuerPlacering _StatuerPlacering;
        private StatueBehandling _StatueBehandling;
        public event PropertyChangedEventHandler PropertyChanged;
        
        public ObservableCollection<Statuer> StatuerList { get; set; }
        public ObservableCollection<Adresse> AdresseList { get; set; }
        public ObservableCollection<SkadeTyper> SkadeTypeList { get; set; }

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
        public StatuerType StatuerType
        {
            get { return _StatuerType; }
            set { _StatuerType = value; OnPropertyChanged(); }
        }
        public StatuerPlacering StatuerPlacering
        {
            get { return _StatuerPlacering; }
            set { _StatuerPlacering = value; OnPropertyChanged(); }
        }
        public StatueBehandling StatueBehandling
        {
            get { return _StatueBehandling; }
            set { _StatueBehandling = value; OnPropertyChanged(); }
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

        ////////// Statuertyper Commands ////////
        /// 
        /// 

        public Handler.StatuerTypesHandler StatuerTypeHandler { get; }

        public ICommand AddStatuerTypeCommand { get; set; }
        public ICommand DeleteStatuerTypeCommand { get; set; }
        public ICommand UpdateStatuerTypeCommand { get; set; }
        public ICommand GetStatuerTypeCommand { get; set; }
        public ICommand GetStatuerTypeListCommand { get; set; }

        public Handler.StatuerPlaceringsHandler StatuerPlaceringHandler { get; }

        public ICommand AddStatuerPlaceringCommand { get; set; }
        public ICommand DeleteStatuerPlaceringCommand { get; set; }
        public ICommand UpdateStatuerPlaceringCommand { get; set; }
        public ICommand GetStatuerPlaceringCommand { get; set; }
        public ICommand GetStatuerPlaceringListCommand { get; set; }

        public Handler.StatueBehandlingHandler StatueBehandlingHandler { get; }

        public ICommand AddStatueBehandlingCommand { get; set; }
        public ICommand DeleteStatueBehandlingCommand { get; set; }
        public ICommand UpdateStatueBehandlingCommand { get; set; }
        public ICommand GetStatueBehandlingCommand { get; set; }
        public ICommand GetStatueBehandlingListCommand { get; set; }

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

            StatuerTypeHandler = new Handler.StatuerTypesHandler(this);

            AddStatuerTypeCommand = new RelayCommand(StatuerTypeHandler.PostStatuerType);
            DeleteStatuerTypeCommand = new RelayCommand(StatuerTypeHandler.DeleteStatuerType);
            UpdateStatuerTypeCommand = new RelayCommand(StatuerTypeHandler.UpdateStatuerType);
            GetStatuerTypeCommand = new RelayCommand(StatuerTypeHandler.GetStatuerType);
            GetStatuerTypeListCommand = new RelayCommand(StatuerTypeHandler.GetStatuerTypeList);


            StatuerPlaceringHandler = new Handler.StatuerPlaceringsHandler(this);

            AddStatuerPlaceringCommand = new RelayCommand(StatuerPlaceringHandler.PostStatuerPlacering);
            DeleteStatuerPlaceringCommand = new RelayCommand(StatuerPlaceringHandler.DeleteStatuerPlacering);
            UpdateStatuerPlaceringCommand = new RelayCommand(StatuerPlaceringHandler.UpdateStatuerPlacering);
            GetStatuerPlaceringCommand = new RelayCommand(StatuerPlaceringHandler.GetStatuerPlacering);
            GetStatuerPlaceringListCommand = new RelayCommand(StatuerPlaceringHandler.GetStatuerPlaceringList);

            StatueBehandlingHandler = new Handler.StatueBehandlingHandler(this);

            AddStatueBehandlingCommand = new RelayCommand(StatueBehandlingHandler.PostStatueBehandling);
            DeleteStatueBehandlingCommand = new RelayCommand(StatueBehandlingHandler.DeleteStatueBehandling);
            UpdateStatueBehandlingCommand = new RelayCommand(StatueBehandlingHandler.UpdateStatueBehandling);
            GetStatueBehandlingCommand = new RelayCommand(StatueBehandlingHandler.GetStatueBehandling);
            GetStatueBehandlingListCommand = new RelayCommand(StatueBehandlingHandler.GetStatueBehandlingList);

            Statuer = new Statuer();
            Adresse = new Adresse();
            Materialer = new Materialer();
            StatuerType = new StatuerType();
            StatuerPlacering = new StatuerPlacering();
            StatueBehandling = new StatueBehandling();
            StatuerList = new ObservableCollection<Statuer>();
            AdresseList = new ObservableCollection<Adresse>();
            SkadeTypeList = new ObservableCollection<SkadeTyper>();

            StatuerHandler.GetStatuerList();
            AdresseHandler.GetAdresseList();
            SkadeType

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
