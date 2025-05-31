using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TINHTOANVANKHUONDAM.Class
{
    public class clsDam
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public double Length { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public clsDam(string id, string name, double lenght,double b,double h)
        {
            ID = id;
            Name = name;
            Length = lenght;
            Width = b;
            Height = h;
        }
    }
}
