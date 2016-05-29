using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Monument.Facade;

using Monument.ViewModels;

namespace Monument.Handler
{
    public class StatuerPlaceringsHandler
    {
        public static StatueViewmodel StatueViewmodels { get; set; }
        public static Facade.Facade Facades { get; set; }

        public StatuerPlacering StatuerPlacerings { get; set; }

        public StatuerPlaceringsHandler(StatueViewmodel statueViewmodel)
        {
            StatueViewmodels = statueViewmodel;
            
        }

        public async void GetStatuerPlaceringList()
        {
            var facade = new Facade.Facade();
            await facade.GetStatuerPlaceringList();

        }


        public async void GetStatuerPlacering()
        {
            var facade = new Facade.Facade();
            await facade.GetStatuerPlacering(StatuerPlacerings);
        }

        public async void PostStatuerPlacering()
        {
            var facade = new Facade.Facade();
            await facade.PostStatuerPlacering(StatueViewmodels.StatuerPlacering);
        }

        public async void UpdateStatuerPlacering()
        {
            var facade = new Facade.Facade();
            await facade.PutStatuerPlacering(StatuerPlacerings);
        }

        public async void DeleteStatuerPlacering()
        {
            var facade = new Facade.Facade();
            await facade.DeleteStatuerPlacering(StatuerPlacerings);
        }


    }
}
