namespace Monument.Models
{
    public class Statue
    {
        public int Statue_Id { get; set; }
        public string Navn { get; set; }
        public string Adresse { get; set; }
        public string Prioritet { get; set; }

        public Statue(int statueId, string navn, string adresse, string prioritet)
        {
            Statue_Id = statueId;
            Navn = navn;
            Adresse = adresse;
            Prioritet = prioritet;
        }

        public override string ToString()
        {
            return $"Statue_Id: {Statue_Id}, Navn: {Navn}, Adresse: {Adresse}, Prioritet: {Prioritet}";
        }

        public Statue()
        {
            
        }
    }
}
