using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BE
{
    public class Fault
    {
        public int fault_number { get; set; }

        public fault_type Ft { get; set; }
        
        public who_fault who { get; set; }

        public float total_price { get; set; }

        public string name_of_shop { get; set; }

        public Fault()
        {

        }
        public Fault(Fault a)
        {
            fault_number = a.fault_number;
            Ft = a.Ft;
            who = a.who;
            total_price = a.total_price;
            name_of_shop = a.name_of_shop;
        }
        public Fault(fault_type ft,who_fault Who ,int fn=0,int pri =0,string naos="")
        {
            fault_number = fn;
            Ft = ft;
            who = Who;
            total_price = pri;
            name_of_shop = naos;
        }
        public override string ToString()
        {
            return base.ToString();
        }
        public XElement ToXml()
        {
            XElement XFaultNumber = new XElement("fault_number", fault_number);
            XElement XfFaultType = new XElement("fault_type", Ft);
            XElement XWhoFault = new XElement("who", who);
            XElement XPrice = new XElement("price", total_price);
            XElement XnameOfShop = new XElement("shop", name_of_shop);
            return new XElement("Fault", XFaultNumber, XfFaultType, XWhoFault, XPrice, XnameOfShop);
        }
    }
}
