using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Produsele pot fi de 3 tipuri:
//- generice(denumire, pret)
//- perisabile(denumire, pret, data expirarii, conditii de pastrare)
//- electrocasnice(clasa de eficienta energetica, puterea maxima consumata)

namespace Proiect_POO
{
    public abstract class Produs
    {
        public string Denumire;
        public decimal Pret;
        public int Stoc;

        public Produs(string denumire, decimal pret, int stoc)
        {
            Denumire = denumire;
            Pret = pret;
            Stoc = stoc;
        }
    }

    public class ProdusGeneric:Produs
    {
        public ProdusGeneric(string denumire, decimal pret, int stoc) : 
            base(denumire, pret, stoc) { }
        public override string ToString()
        {
            return $"ID: Nume: {Denumire}, Pret: {Pret}, Stoc: {Stoc}";
        }
    }
    public class ProdusPerisabil : Produs
    {
        public DateTime DataExpirarii;
        public string ConditiiDePastrare;

        public ProdusPerisabil(string denumire, decimal pret, int stoc, DateTime data_expirarii, string conditii_pastrare) :
            base(denumire, pret, stoc)
        {
            DataExpirarii = data_expirarii;
            ConditiiDePastrare = conditii_pastrare;
        }
        public override string ToString()
        {
            return $"ID: Nume: {Denumire}, Pret: {Pret}, Stoc: {Stoc}, Data Expirarii: {DataExpirarii}, Conditii de patrare: {ConditiiDePastrare}";
        }
    }
    public class ProdusElectrocasnic : Produs
    {
        public string ClasaEnergie;
        public int PutereMaximaCons;
        public ProdusElectrocasnic(string denumire, decimal pret, int stoc, string clasaEnergie, int putereMax) :
            base(denumire, pret, stoc)
        {
            ClasaEnergie = clasaEnergie;
            PutereMaximaCons = putereMax;
        }
        public override string ToString()
        {
            return $"ID: Nume: {Denumire}, Pret: {Pret}, Stoc: {Stoc}, Clasa de eficienta energetica {ClasaEnergie}, Putere maxima consumata {PutereMaximaCons}W" ;
        }
    }
}
