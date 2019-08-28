using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    [Serializable]
    public class House
    {
        int floors;
        public int Floors
        {
            get
            {
                return floors;
            }
            set
            {
                floors = value;
            }
        }
        int apartments;
        public int Apartmens
        {
            get { return apartments; }
            set { apartments = value; }
        }
        public string StreetName;
    }
}
