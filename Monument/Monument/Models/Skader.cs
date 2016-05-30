using System.ComponentModel;
using System.Runtime.CompilerServices;
using Monument.Annotations;

namespace Monument
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Skader : INotifyPropertyChanged
    {
        private string _skadeGrad;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Skader()
        {
            SkadeNoter = new HashSet<SkadeNoter>();
            StatueBehandling = new HashSet<StatueBehandling>();
        }

        [Key]
        public int Skade_id { get; set; }

        public int? fk_SkadeType_id { get; set; }

        [StringLength(1)]
        public string SkadeGrad
        {
            get { return _skadeGrad; }
            set { _skadeGrad = value; OnPropertyChanged();}
        }

        public int? FK_Statue_id { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SkadeNoter> SkadeNoter { get; set; }

        public virtual SkadeTyper SkadeTyper { get; set; }

        public virtual Statuer Statuer { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StatueBehandling> StatueBehandling { get; set; }

        //public override string ToString()
        //{
        //    return $"SkadeTyper: {SkadeTyper}";
        //}
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
