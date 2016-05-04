using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monument
{
    class StatueClass
    {
        public int Statue_Id { get; set; }
        public string Navn { get; set; }
        public string Adresse { get; set; }

        public StatueClass(int statueId, string navn, string adresse)
        {
            Statue_Id = statueId;
            Navn = navn;
            Adresse = adresse;
        }

        public override string ToString()
        {
            return $"Statue_Id: {Statue_Id}, Navn: {Navn}, Adresse: {Adresse}";
        }
    }
}
