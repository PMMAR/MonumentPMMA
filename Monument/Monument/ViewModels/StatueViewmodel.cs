﻿using System;
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
        private StatuerType _StatuerType;
        private StatuerPlacering _StatuerPlacering;
        private StatueBehandling _StatueBehandling;
        private Behandlingstyper _Behandlingstyper;
        private Skader _Skader;
        public event PropertyChangedEventHandler PropertyChanged;
        
        public ObservableCollection<Statuer> StatuerList { get; set; }
        public ObservableCollection<Adresse> AdresseList { get; set; }
        public ObservableCollection<StatueBehandling> StatueBehandlingList { get; set; }
        public ObservableCollection<Behandlingstyper> BehandlingstyperList { get; set; }
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
        public Behandlingstyper Behandlingstyper
        {
            get { return _Behandlingstyper; }
            set { _Behandlingstyper = value; OnPropertyChanged(); }
        }

        public Skader Skader
        {
            get { return _Skader; }
            set { _Skader = value; OnPropertyChanged(); }
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

        public Handler.BehandlingstyperHandler BehandlingstyperHandler { get; }

        public ICommand AddBehandlingstyperCommand { get; set; }
        public ICommand DeleteBehandlingstyperCommand { get; set; }
        public ICommand UpdateBehandlingstyperCommand { get; set; }
        public ICommand GetBehandlingstyperCommand { get; set; }
        public ICommand GetBehandlingstyperListCommand { get; set; }


        public Handler.SkadeTypersHandler SkadeTyperHandler { get; }

        public ICommand AddSkadeTyperCommand { get; set; }
        public ICommand DeleteSkadeTyperCommand { get; set; }
        public ICommand UpdateSkadeTyperCommand { get; set; }
        public ICommand GetSkadeTyperCommand { get; set; }
        public ICommand GetSkadeTyperListCommand { get; set; }



        public Handler.SkadersHandler SkaderHandler { get; }

        public ICommand AddSkaderCommand { get; set; }
        public ICommand DeleteSkaderCommand { get; set; }
        public ICommand UpdateSkaderCommand { get; set; }
        public ICommand GetSkaderCommand { get; set; }
        public ICommand GetSkaderListCommand { get; set; }

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

            BehandlingstyperHandler = new Handler.BehandlingstyperHandler(this);

            AddBehandlingstyperCommand = new RelayCommand(BehandlingstyperHandler.PostBehandlingstyper);
            DeleteBehandlingstyperCommand = new RelayCommand(BehandlingstyperHandler.DeleteBehandlingstyper);
            UpdateBehandlingstyperCommand = new RelayCommand(BehandlingstyperHandler.UpdateBehandlingstyper);
            GetBehandlingstyperCommand = new RelayCommand(BehandlingstyperHandler.GetBehandlingstyper);
            GetBehandlingstyperListCommand = new RelayCommand(BehandlingstyperHandler.GetBehandlingstyperList);

            SkadeTyperHandler = new Handler.SkadeTypersHandler(this);

            AddSkadeTyperCommand = new RelayCommand(SkadeTyperHandler.PostSkadeTyper);
            DeleteSkadeTyperCommand = new RelayCommand(SkadeTyperHandler.DeleteSkadeTyper);
            UpdateSkadeTyperCommand = new RelayCommand(SkadeTyperHandler.UpdateSkadeTyper);
            GetSkadeTyperCommand = new RelayCommand(SkadeTyperHandler.GetSkadeTyper);
            GetSkadeTyperListCommand = new RelayCommand(SkadeTyperHandler.GetSkadeTyperList);

            SkaderHandler = new Handler.SkadersHandler(this);

            AddSkaderCommand = new RelayCommand(SkaderHandler.PostSkader);
            DeleteSkaderCommand = new RelayCommand(SkaderHandler.DeleteSkader);
            UpdateSkaderCommand = new RelayCommand(SkaderHandler.UpdateSkader);
            GetSkaderCommand = new RelayCommand(SkaderHandler.GetSkader);
            GetSkaderListCommand = new RelayCommand(SkaderHandler.GetSkaderList);

            Statuer = new Statuer();
            Adresse = new Adresse();
            Materialer = new Materialer();
            StatuerType = new StatuerType();
            StatuerPlacering = new StatuerPlacering();
            StatueBehandling = new StatueBehandling();
            Skader = new Skader();
            StatuerList = new ObservableCollection<Statuer>();
            AdresseList = new ObservableCollection<Adresse>();
            StatueBehandlingList = new ObservableCollection<StatueBehandling>();
            BehandlingstyperList = new ObservableCollection<Behandlingstyper>();
            SkadeTypeList = new ObservableCollection<SkadeTyper>();

            StatuerHandler.GetStatuerList();
            AdresseHandler.GetAdresseList();
            //StatueBehandlingHandler.GetStatueBehandlingList();
            BehandlingstyperHandler.GetBehandlingstyperList();
            SkadeTyperHandler.GetSkadeTyperList();

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
