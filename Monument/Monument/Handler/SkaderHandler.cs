using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Monument.Facade;

using Monument.ViewModels;

namespace Monument.Handler
{
    public class SkadersHandler
    {
        public static StatueViewmodel StatueViewmodels { get; set; }
        public static Facade.Facade Facades { get; set; }

        public Skader Skaders { get; set; }

        public SkadersHandler(StatueViewmodel statueViewmodel)
        {
            StatueViewmodels = statueViewmodel;
            
        }

        public async void GetSkaderList()
        {
            var facade = new Facade.Facade();
            await facade.GetSkaderList();

        }


        public async void GetSkader()
        {
            var facade = new Facade.Facade();
            await facade.GetSkader(Skaders);
        }

        public async void PostSkader()
        {
            var facade = new Facade.Facade();
            await facade.PostSkader(StatueViewmodels.Skader);
        }

        public async void UpdateSkader()
        {
            var facade = new Facade.Facade();
            await facade.PutSkader(Skaders);
        }

        public async void DeleteSkader()
        {
            var facade = new Facade.Facade();
            await facade.DeleteSkader(Skaders);
        }


    }
}
