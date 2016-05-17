using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Monument.Facade;

using Monument.ViewModels;

namespace Monument.Handler
{
    public class MaterialersHandler
    {
        public static StatueViewmodel StatueViewmodels { get; set; }
        public static Facade.Facade Facades { get; set; }

        public Materialer Materialers { get; set; }

        public MaterialersHandler(StatueViewmodel statueViewmodel)
        {
            StatueViewmodels = statueViewmodel;
            
        }

        public async void GetMaterialerList()
        {
            var facade = new Facade.Facade();
            await facade.GetMaterialerList();

        }


        public async void GetMaterialer()
        {
            var facade = new Facade.Facade();
            await facade.GetMaterialer(Materialers);
        }

        public async void PostMaterialer()
        {
            var facade = new Facade.Facade();
            await facade.PostMaterialer(StatueViewmodels.Materialer);
        }

        public async void UpdateMaterialer()
        {
            var facade = new Facade.Facade();
            await facade.PutMaterialer(Materialers);
        }

        public async void DeleteMaterialer()
        {
            var facade = new Facade.Facade();
            await facade.DeleteMaterialer(Materialers);
        }


    }
}
