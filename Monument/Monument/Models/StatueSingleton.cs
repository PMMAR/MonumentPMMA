using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Monument.Models;

namespace Monument.Models
{
    public class StatueSingleton
    {
        public ObservableCollection<Statue> Statuer { get; set; }
        private static StatueSingleton instance = new StatueSingleton();
        public int SelectedIndex { get; set; }

        public StatueSingleton()
        {
            Statuer = new ObservableCollection<Statue>();

        }

        public static StatueSingleton Instance
        {
            get
            {
                return instance;
            }
        }

    }
}
