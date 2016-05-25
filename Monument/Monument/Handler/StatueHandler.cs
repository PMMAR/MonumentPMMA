using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Monument.Facade;

using Monument.ViewModels;

namespace Monument.Handler
{
    public class StatuerHandler
    {
        public static StatueViewmodel StatueViewmodels { get; set; }
        public static Facade.Facade Facades { get; set; }

        public Statuer Statuer { get; set; }

        public StatuerHandler(StatueViewmodel statueViewmodel)
        {
            StatueViewmodels = statueViewmodel;
            
        }

        public async void GetStatuerList()
        {
            var facade = new Facade.Facade();
            var liste = await facade.GetStatuerList();
            foreach (var listobj in liste)
            {
                StatueViewmodels.StatuerList.Add(listobj);
            }

        }


        public async void GetStatuer()
        {
            var facade = new Facade.Facade();
            await facade.GetStatuer(Statuer);
        }

        public async void PostStatuer()
        {
            var facade = new Facade.Facade();
            var statue = await facade.PostStatuer(StatueViewmodels.Statuer);
            StatueViewmodels.Materialer.FK_Statue_Id = statue.Statue_Id;
            await facade.PostMaterialer(StatueViewmodels.Materialer);

        }

        public async void UpdateStatuer()
        {
            var facade = new Facade.Facade();
            await facade.PutStatuer(Statuer);
        }

        public async void DeleteStatuer()
        {
            var facade = new Facade.Facade();
            await facade.DeleteStatuer(Statuer);
        }


    }
}
