using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BE
{
    public class car
    {
        public int car_number { get; set; }//
        public DateTime? date_of_fix { get; set; }
        public int year_of_build { get; set; }
        public car_type car_info { get; set; }
        public gear car_gear { get; set; }
        public int car_people_able { get; set; }
        public int number_of_car_doors { get; set; }
        public float total_distance { get; set; }
        public addres snif_address { get; set; }
        public bool takin { get; set; }
        public bool moosker { get; set; }
        public rishion_rachav rishion { get; set; }
        public car()
        {

        }
        public car(car a)
        {
            car_number = a.car_number;
            date_of_fix = a.date_of_fix;
            car_info = a.car_info;
            car_gear = a.car_gear;
            car_people_able = a.car_people_able;
            number_of_car_doors = a.number_of_car_doors;
            total_distance = a.total_distance;
            snif_address = a.snif_address;
            takin = a.takin;
            rishion = a.rishion;
        }
        public car(car_type ct, gear g, int cpa, int nod, addres a, rishion_rachav rc, int year, float dis = 0, DateTime? dt = null, bool t = true, int ca_num = 0,bool moos=false)
        {
            car_number = ca_num;
            date_of_fix = dt;
            car_info = ct;
            car_gear = g;
            car_people_able = cpa;
            number_of_car_doors = nod;
            total_distance = dis;
            snif_address = a;
            takin = t;
            rishion = rc;
            year_of_build = year;
            moosker = moos;
        }
        public override string ToString()
        {
            string temp = string.Format("this car ditales are {0} \nhe has {1} gear \nhe have {2} doors\nhe can hold {3} people\nhe was build at {4} \nhis lisence number {5}\nhe drove {6}Km\n",car_info.ToString(),car_gear.ToString(),number_of_car_doors,car_people_able,date_of_fix.Value.ToShortDateString(),car_number,total_distance);
            return temp;
        }
        public XElement ToXml()
        {
            XElement XCarNumber = new XElement("car_number", car_number);
            XElement XAddres = new XElement("snif_address", new XElement("street", snif_address.street), new XElement("city", snif_address.city), new XElement("building", snif_address.building));
            XElement XDateOfFix = new XElement("date_of_fix", new XElement("year", date_of_fix.Value.Year), new XElement("month", date_of_fix.Value.Month), new XElement("day", date_of_fix.Value.Day));
            XElement XYearOfBuild = new XElement("year_of_build", year_of_build);
            XElement XCarInfo = new XElement("car_info", new XElement("Manufacturer", car_info.Manufacturer), new XElement("model", car_info.model), new XElement("Engine_capacety", car_info.Engine_capacety));
            XElement XCarGear = new XElement("car_gear", car_gear.ToString());
            XElement XCarPeopl = new XElement("car_people_able", car_people_able);
            XElement XNumOfDoors = new XElement("number_of_car_doors", number_of_car_doors);
            XElement XTotalDistance = new XElement("total_distance", total_distance);
            XElement XTakin = new XElement("takin", takin);
            XElement XMosker = new XElement("moosker", moosker);
            XElement XRishion = new XElement("Rishion", new XElement("catagory_of_vehicles",rishion.type), new XElement("date_test",new XElement("year", rishion.test.Year), new XElement("month", rishion.test.Month), new XElement("day", rishion.test.Day)));
            return new XElement("car", XCarNumber, XAddres, XDateOfFix, XYearOfBuild, XCarInfo, XCarGear, XCarPeopl, XNumOfDoors, XTotalDistance, XTakin, XMosker, XRishion);
        }

    }
}