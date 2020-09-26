using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2 {
    class Silnik {
        public Silnik(double pojD) : this(1900, 23.5) {
            pojZbDomyslna = pojD;
        }
        public Silnik(uint poj, double ilePal) {
            pojemnosc = poj;
            ilePaliwa = ilePal;
            pojBaku = pojZbDomyslna;
        }
        public uint pojemnosc { get; set; }
        public double pojZbDomyslna = 60;
        public double ilePaliwa { get; set; }
        public double pojBaku { get; set; }

        public double mpg(double lkm) {
            return (282.5/lkm);
        }
        public double litry (double mile) {
            return (282.5 / mile);
        }
    }
}
