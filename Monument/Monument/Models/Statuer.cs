using System.ComponentModel;
using System.Runtime.CompilerServices;
using Monument.Annotations;
using Monument;

namespace Monument
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;



    public partial class Statuer : INotifyPropertyChanged
    {
        public Adresse _adresse;
        public int _fkPostNr;
        public string _byNavn;

        
        public Statuer(int statueId, string navn, string prioritet)
        {
            Materialer = new HashSet<Materialer>();
            Skader = new HashSet<Skader>();
            StatuerNoter = new HashSet<StatuerNoter>();
            StatuerPlacering = new HashSet<StatuerPlacering>();
            StatuerType = new HashSet<StatuerType>();

            //Til testen
            Navn = navn;
            Prioritet = prioritet;
            Statue_Id = statueId;
        }

        /// <summary>
        /// Ignore this
        /// </summary>
        //public Statuer(int statueId, string navn, string prioritet, ICollection<Materialer> materialer, ICollection<Skader> skader, ICollection<StatuerNoter> statuerNoter, ICollection<StatuerPlacering> statuerPlacering, ICollection<StatuerType> statuerType)
        //{
        //    Statue_Id = statueId;
        //    Navn = navn;
        //    Prioritet = prioritet;
        //    Materialer = materialer;
        //    Skader = skader;
        //    StatuerNoter = statuerNoter;
        //    StatuerPlacering = statuerPlacering;
        //    StatuerType = statuerType;
        //}

        

        
        public int Statue_Id { get; set; }
        
        public string Navn { get; set; }

        public int FK_PostNr
        {
            get { return _fkPostNr; }
            set { _fkPostNr = value; OnPropertyChanged(); }
        }

        public string ByNavn
        {
            get { return _byNavn; }
            set { _byNavn = value; OnPropertyChanged(); }
        }


   
        public string Prioritet { get; set; }

        public virtual Adresse Adresse
        {
            get { return _adresse; }
            set
            {
                _adresse = value; OnPropertyChanged();
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Materialer> Materialer { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Skader> Skader { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StatuerNoter> StatuerNoter { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StatuerPlacering> StatuerPlacering { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StatuerType> StatuerType { get; set; }


        public override string ToString()
        {
            return $"Statue_Id: {Statue_Id}, Navn: {Navn}, FK_PostNr: {FK_PostNr}, Prioritet: {Prioritet}";
        }

        #region PropertyChangedSupport
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

    }
}
