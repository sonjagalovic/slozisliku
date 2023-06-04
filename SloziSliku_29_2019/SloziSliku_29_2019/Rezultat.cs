using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SloziSliku_29_2019
{
    public class Rezultat
    {
        public int id;
        public string imeIgraca;
        public int brRedova;
        public int brKolona;
        public int ukupnoPoteza;
        public int vremeUSekundama;

        public Rezultat(int id, string imeIgraca, int brRedova, int brKolona, int ukupnoPoteza, int vremeUSekundama)
        {
            this.id = id;
            this.imeIgraca = imeIgraca;
            this.brRedova = brRedova;
            this.brKolona = brKolona;
            this.ukupnoPoteza = ukupnoPoteza;
            this.vremeUSekundama = vremeUSekundama;
        }
    }
}
