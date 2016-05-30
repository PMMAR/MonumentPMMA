using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Monument.Facade;

using Monument.ViewModels;

namespace Monument.Handler
{
    public class BehandlingstyperHandler
    {
        public static StatueViewmodel StatueViewmodels { get; set; }
        public static Facade.Facade Facades { get; set; }

        public Behandlingstyper Behandlingstyper { get; set; }

        public BehandlingstyperHandler(StatueViewmodel statueViewmodel)
        {
            StatueViewmodels = statueViewmodel;
            
        }

        public async void GetBehandlingstyperList()
        {
            var facade = new Facade.Facade();
            var liste = await facade.GetBehandlingstyperList();
            foreach (var listobj in liste)
            {
                StatueViewmodels.BehandlingstyperList.Add(listobj);
            }

        }


        public async void GetBehandlingstyper()
        {
            var facade = new Facade.Facade();
            await facade.GetBehandlingstyper(Behandlingstyper);
        }

        public async void PostBehandlingstyper()
        {
            var facade = new Facade.Facade();
            await facade.PostBehandlingstyper(StatueViewmodels.Behandlingstyper);
        }

        public async void UpdateBehandlingstyper()
        {
            var facade = new Facade.Facade();
            await facade.PutBehandlingstyper(Behandlingstyper);
        }

        public async void DeleteBehandlingstyper()
        {
            var facade = new Facade.Facade();
            await facade.DeleteBehandlingstyper(Behandlingstyper);
        }


    }
}
