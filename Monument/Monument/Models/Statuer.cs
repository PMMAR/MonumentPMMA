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


    [Table("Statuer")]
    public partial class Statuer : INotifyPropertyChanged
    {
        public Adresse _adresse;
        public int _fkPostNr;
        public string _byNavn;
        private string _prioritet;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Statuer()
        {
            Materialer = new HashSet<Materialer>();
            Skader = new HashSet<Skader>();
            StatuerNoter = new HashSet<StatuerNoter>();
            StatuerPlacering = new HashSet<StatuerPlacering>();
            StatuerType = new HashSet<StatuerType>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Statue_Id { get; set; }

        [StringLength(50)]
        public string Navn { get; set; }

        public int FK_PostNr
        {
            get { return _fkPostNr; }
            set { _fkPostNr = value;}
        }

        public string ByNavn
        {
            get { return _byNavn; }
            set { _byNavn = value;
                OnPropertyChanged(); }
        }


        [StringLength(1)]
        public string Prioritet
        {
            get
            {
                switch (_prioritet)
                {
                    case "0":
                        return "A";
                        break;
                    case "1":
                        return "B";
                        break;
                    case "2":
                        return "C";
                        break;
                    case "A":
                        return "A";
                        break;
                    case "B":
                        return "B";
                        break;
                    case "C":
                        return "C";
                        break;
                    default:
                        return "D";
                        break;
                };
            }
            set { _prioritet = value; OnPropertyChanged(); }
        }

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
            return $"{Navn}, Prioritet: {Prioritet}, {Adresse}";
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
