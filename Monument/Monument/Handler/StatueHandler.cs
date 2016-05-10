using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Monument.Facade;
using Monument.Models;
using Monument.ViewModels;

namespace Monument.Handler
{
    public class StatueHandler
    {
        public static StatueViewmodel StatueViewModels { get; set; }
        public static StatueSingleton StatueSingletons { get; set; }
        public static Facade.Facade Facades { get; set; }

        public Statue Statue { get; set; }

        public StatueHandler(StatueViewmodel statueViewModels)
        {
            StatueViewModels = statueViewModels;
        }

        public async void GetStatueList()
        {
            var facade = new Facade.Facade();
            await facade.GetStatueList();

        }


        public async void GetStatue()
        {
            var facade = new Facade.Facade();
            await facade.GetStatue(Statue);
        }

        public async void PostGuest()
        {
            var facade = new Facade.Facade();
            await facade.PostStatue(Statue);
        }

        public async void UpdateGuest()
        {
            var facade = new Facade.Facade();
            await facade.PutStatue(Statue);
        }

        public async void DeleteGuest()
        {
            var facade = new Facade.Facade();
            await facade.DeleteStatue(Statue);
        }


    }
}
