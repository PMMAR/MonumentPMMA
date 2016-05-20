using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Monument.Facade;

using Monument.ViewModels;

namespace Monument.Handler
{
    public class AdresseHandler
    {
        public static StatueViewmodel StatueViewmodels { get; set; }
        public static Facade.Facade Facades { get; set; }

        public Adresse Adresse { get; set; }

        public AdresseHandler(StatueViewmodel statueViewmodel)
        {
            StatueViewmodels = statueViewmodel;
            
        }

        public async void GetAdresseList()
        {
            var facade = new Facade.Facade();
            var liste = await facade.GetAdresseList();
            foreach (var listobj in liste)
            {
                StatueViewmodels.AdresseList.Add(listobj);
            }

        }


        public async void GetAdresse()
        {
            var facade = new Facade.Facade();
            await facade.GetAdresse(Adresse);
        }

        public async void PostAdresse()
        {
            var facade = new Facade.Facade();
            await facade.PostAdresse(StatueViewmodels.Adresse);
        }

        public async void UpdateAdresse()
        {
            var facade = new Facade.Facade();
            await facade.PutAdresse(Adresse);
        }

        public async void DeleteAdresse()
        {
            var facade = new Facade.Facade();
            await facade.DeleteAdresse(Adresse);
        }


    }
}
