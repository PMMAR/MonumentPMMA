using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Monument.Annotations;
using Monument.Models;

namespace Monument.ViewModels
{
    public class StatueViewmodel : INotifyPropertyChanged
    {
        private Bruger _brugerClass;
        private Statue _statue;
        public event PropertyChangedEventHandler PropertyChanged;

        public Statue Statue
        {
            get { return _statue; }
            set { _statue = value; OnPropertyChanged(); }
        }

        public ICommand AddStatueCommand { get; set; }
        public ICommand DeleteStatueCommand { get; set; }
        public ICommand UpdateStatueCommand { get; set; }
        public ICommand GetStatueCommand { get; set; }
















        #region MyRegion
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        } 
        #endregion
    }
}
