using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BE
{
    public class Client
    {
        public rishion rishoi { get; set; }
        public bool isVip { get; set; }
        public addres Address1 { get; set; }
        public DateTime Birth_date { get; set; }
        public long Id1 { get; set; }
        public CreditCard Card_dit { get; set; }
        public int Age { get; set; }
        public int Vatk { get; set; }
        public int misper_tklot { get; set; }

        public Client()
        {

        }
        public Client(Client cli)
        {
            rishoi = cli.rishoi;
            isVip = cli.isVip;
            Address1 = cli.Address1;
            Birth_date = cli.Birth_date;
            Id1 = cli.Id1;
            Card_dit = cli.Card_dit;
            Age = cli.Age;
            Vatk = cli.Vatk;
            misper_tklot = cli.Vatk;
        }
        public Client(addres ad,DateTime bd,rishion ri,CreditCard cc,int vat=0,int mis_tak=0,bool isv=false, int id=0)
        {
            rishoi = ri;
            isVip = isv;
            Address1 = ad;
            Birth_date = bd;
            Id1 = id;
            Card_dit = cc;
            Age = DateTime.Now.Year - bd.Year;
            Vatk = vat;
            misper_tklot = mis_tak;
        }
        public override string ToString()
        {
            string temp = string.Format(" {0} \n is id {1} \n he live at {2} \n he was born at {3} \n his age is{4} \n he has a vatk of {5} years \n and been involved in {6} taklot",rishoi,Id1,Address1,Birth_date.ToShortDateString(),Age,Vatk,misper_tklot);
            if (isVip)
                return temp + "and he is a vip renter";
            return temp + "and he is not a vip renter";
        }
        public XElement ToXml()
        {
            XElement XID = new XElement("ID", Id1);
            XElement XAddres = new XElement("Addres", new XElement("street",Address1.street),new XElement("city",Address1.city),new XElement("building",Address1.building));
            XElement XBirthDay = new XElement("Birth_date",new XElement("year",Birth_date.Year),new XElement("month",Birth_date.Month),new XElement("day",Birth_date.Day));
            XElement XCraditCard = new XElement("CraditCard", new XElement("card_number", Card_dit.number_c), new XElement("cvv_number", Card_dit.cvc_number), new XElement("experiton_date", new XElement("year", Card_dit.exp_date.Year), new XElement("month", Card_dit.exp_date.Month), new XElement("day", Card_dit.exp_date.Day)));
            XElement XProblemCount = new XElement("misper_tklot", misper_tklot);
            XElement XRishion = new XElement("rishion", new XElement("mispar_rishion", rishoi.mispar_rishion), new XElement("experiton_date", new XElement("year", rishoi.tokf.Year), new XElement("month", rishoi.tokf.Month), new XElement("day", rishoi.tokf.Day)), new XElement("rishion_type", rishoi.catgor.ToString()));
            XElement Xvip = new XElement("is_vip", isVip);
            XElement XAge = new XElement("age", Age);
            XElement Xvatk = new XElement("vatk", Vatk);
            return new XElement("Client", XID, XAddres, XBirthDay, XCraditCard, XProblemCount, XRishion, Xvip, XAge, Xvatk);
        }
    }
}
