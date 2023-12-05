using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tovn
{
    public class Citi
    {
        public string Name;
        public int Piple;
        public double Razmer;
        public Citi(string name, int piple, double razmer) 
        {
            Name = name;
            Piple = piple;
            Razmer = razmer;
        }
        public Citi() { }
    }
}
