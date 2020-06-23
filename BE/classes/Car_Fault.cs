using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BE
{
    public class Car_Fault
    {
        public int id { get; set; }
        public int fault_number { get; set; }
        public DateTime date { get; set; }
        public DateTime chazra_mitkun { get; set; }

        public Car_Fault(int Id,int ft,DateTime Date,DateTime cm)
        {
            id = Id;
            fault_number = ft;
            date = Date;
            chazra_mitkun = cm;
        }
        public Car_Fault(int Id, int ft, DateTime cm)
        {
            id = Id;
            fault_number = ft;
            date = DateTime.Now;
            chazra_mitkun = cm;
        }
        public Car_Fault(Car_Fault temp)
        {
            id = temp.id;
            fault_number = temp.fault_number;
            date = temp.date;
        }
        public override string ToString()
        {
            return string.Format("the car {0} had a {1} problem in {2}", id, fault_number, date.ToShortDateString());
        }
        public Car_Fault()
        {

        }
        public XElement ToXml()
        {
            XElement XCarNumber = new XElement("car_number", id);
            XElement XFaultNumber = new XElement("fault_number", fault_number);
            XElement Xdate = new XElement("date", new XElement("year", date.Year), new XElement("month", date.Month), new XElement("day", date.Day));
            XElement Xchazra_mitkun = new XElement("chazra_mitkun", new XElement("year", chazra_mitkun.Year), new XElement("month", chazra_mitkun.Month), new XElement("day", chazra_mitkun.Day));
            return new XElement("Car_Fault", XCarNumber, XFaultNumber, Xdate, Xchazra_mitkun);
        }
    }
}
