using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Monument.Facade;

using Monument.ViewModels;

namespace Monument.Handler
{
    public class StatuerTypesHandler
    {
        public static StatueViewmodel StatueViewmodels { get; set; }
        public static Facade.Facade Facades { get; set; }

        public StatuerType StatuerTypes { get; set; }

        public StatuerTypesHandler(StatueViewmodel statueViewmodel)
        {
            StatueViewmodels = statueViewmodel;
            
        }

        public async void GetStatuerTypeList()
        {
            var facade = new Facade.Facade();
            await facade.GetStatuerTypeList();

        }


        public async void GetStatuerType()
        {
            var facade = new Facade.Facade();
            await facade.GetStatuerType(StatuerTypes);
        }

        public async void PostStatuerType()
        {
            var facade = new Facade.Facade();
            await facade.PostStatuerType(StatueViewmodels.StatuerType);
        }

        public async void UpdateStatuerType()
        {
            var facade = new Facade.Facade();
            await facade.PutStatuerType(StatuerTypes);
        }

        public async void DeleteStatuerType()
        {
            var facade = new Facade.Facade();
            await facade.DeleteStatuerType(StatuerTypes);
        }


    }
}
