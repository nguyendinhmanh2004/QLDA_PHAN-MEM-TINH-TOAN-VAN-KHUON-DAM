using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TINHTOANVANKHUONDAM.Class
{
    public class VanKhuon
    {
        public string Name { get; set; }
        private double _gamaVK;
        private double _cuongDoGo;
        private double _dayVanDay;
        private double _dayVanThanh;

        public double GaMaVK
        {
            get { return _gamaVK; }
            set { _gamaVK = value; }
        }
        public double CuongDoGo
        {
            get { return _cuongDoGo; }
            set { _cuongDoGo = value; }
        }

        public double DayVanDay
        {
            get { return _dayVanDay; }
            set { _dayVanDay = value; }
        }

        public double DayVanThanh
        {
            get { return _dayVanThanh; }
            set { _dayVanThanh = value; }
        }

        public VanKhuon(double dayday, double daythanh,double gamago, string name,double cdg) 
        {
            _dayVanDay = dayday;
            _dayVanThanh= daythanh;
            _gamaVK = gamago;
            Name = name;
            _cuongDoGo = cdg;
        }
    }
}