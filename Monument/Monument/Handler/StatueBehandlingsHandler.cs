using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Monument.Facade;

using Monument.ViewModels;

namespace Monument.Handler
{
    public class StatueBehandlingHandler
    {
        public static StatueViewmodel StatueViewmodels { get; set; }
        public static Facade.Facade Facades { get; set; }

        public StatueBehandling StatueBehandling { get; set; }

        public StatueBehandlingHandler(StatueViewmodel statueViewmodel)
        {
            StatueViewmodels = statueViewmodel;
            
        }

        public async void GetStatueBehandlingList()
        {
            var facade = new Facade.Facade();
            var liste = await facade.GetStatueBehandlingList();
            foreach (var listobj in liste)
            {
                StatueViewmodels.StatueBehandlingList.Add(listobj);
            }

        }


        public async void GetStatueBehandling()
        {
            var facade = new Facade.Facade();
            await facade.GetStatueBehandling(StatueBehandling);
        }

        public async void PostStatueBehandling()
        {
            var facade = new Facade.Facade();
            await facade.PostStatueBehandling(StatueViewmodels.StatueBehandling);
        }

        public async void UpdateStatueBehandling()
        {
            var facade = new Facade.Facade();
            await facade.PutStatueBehandling(StatueBehandling);
        }

        public async void DeleteStatueBehandling()
        {
            var facade = new Facade.Facade();
            await facade.DeleteStatueBehandling(StatueBehandling);
        }


    }
}
