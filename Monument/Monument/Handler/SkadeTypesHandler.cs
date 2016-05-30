using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Monument.Facade;

using Monument.ViewModels;

namespace Monument.Handler
{
    public class SkadeTypersHandler
    {
        public static StatueViewmodel StatueViewmodels { get; set; }
        public static Facade.Facade Facades { get; set; }

        public SkadeTyper SkadeTypers { get; set; }

        public SkadeTypersHandler(StatueViewmodel statueViewmodel)
        {
            StatueViewmodels = statueViewmodel;
            
        }

        public async void GetSkadeTyperList()
        {
            var facade = new Facade.Facade();
            var liste = await facade.GetSkadeTyperList();
            foreach (var listobj in liste)
            {
                StatueViewmodels.SkadeTypeList.Add(listobj);
            }

        }


        public async void GetSkadeTyper()
        {
            var facade = new Facade.Facade();
            await facade.GetSkadeTyper(SkadeTypers);
        }

        public async void PostSkadeTyper()
        {
            var facade = new Facade.Facade();
            await facade.PostSkadeTyper(SkadeTypers);
        }

        public async void UpdateSkadeTyper()
        {
            var facade = new Facade.Facade();
            await facade.PutSkadeTyper(SkadeTypers);
        }

        public async void DeleteSkadeTyper()
        {
            var facade = new Facade.Facade();
            await facade.DeleteSkadeTyper(SkadeTypers);
        }


    }
}
