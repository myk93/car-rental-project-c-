using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BE
{
    public class Renting
    {
        public long running_code { get; set; }
        public DateTime start_rent { get; set; }
        public DateTime end_rent { get; set; }
        public int days { get; set; }
        public Drivers driver { get; set; }
        public int number_of_rishui { get; set; }
        public int number_of_pepole { get; set; }
        public float number_at_start { get; set; }
        public float number_at_end { get; set; }
        public float number_drove { get; set; }
        public bool is_defcive { get; set; }
        public float price { get; set; }
        public bool ended { get; set; }
        public override string ToString()
        {
            string t = string.Format("the order no' is {0} \n{1} \n rented the car license number {2} \n at {3} \n and can drive {4} people \n his kilomatrag' was {5} \n he rented it for {6} days ", running_code, driver.ToString(), number_of_rishui, start_rent.ToString("DD:MM::YY"), number_of_pepole, number_at_start, days);
            if (!ended)
                return t;
            t += string.Format(" /n the end of rent was at {0} \n he drove {1} Km \n end the price is {2}", end_rent.ToString("DD:MM::YY"), number_drove, price);
            if(is_defcive)
                t+="\n it had a defect";
            if(!is_defcive)
                t+="\n it did not had a defect";
            return t;
        }
        public Renting()
        {

        }
        public Renting(Renting rent)
        {
            running_code = rent.running_code;
            start_rent = rent.start_rent;
            end_rent = rent.end_rent;
            days = rent.days;
            driver = rent.driver;
            number_of_rishui = rent.number_of_rishui;
            number_of_pepole = rent.number_of_pepole;
            number_at_start = rent.number_at_start;
            number_at_end = rent.number_at_end;
            number_drove = rent.number_drove;
            is_defcive = rent.is_defcive;
            price = rent.price;
            ended = rent.ended;
        }
        public Renting(int days,Drivers drive ,car ca,int num_of_peo)
        {
            running_code = 0;
            start_rent = new DateTime();
            start_rent = DateTime.Now;
            this.days = days;
            driver = drive;
            number_of_rishui = ca.car_number;
            number_of_pepole = num_of_peo;
            number_at_start = ca.total_distance;
            is_defcive = false;
            ended = false;
        }
        public Renting(long run_code,Drivers dra,int car_num,int days,DateTime dt,DateTime dt1,bool a,float km,int aa,bool t,int tt)
        {
            running_code = run_code;
            driver = dra;
            number_of_rishui = car_num;
            this.days = days;
            start_rent = dt;
            end_rent = dt1;
            is_defcive = a;
            price = aa;
            number_at_start = km;
            ended = t;
            number_at_end = (number_drove = tt);
        }
        /*
          (int)mspar_nahgim.SelectedValue
         */

        public bool panuy { get; set; }
        public XElement ToXml()
        {
            XElement XRunningCode = new XElement("running_code", running_code);
            XElement XStartRent = new XElement("start_rent", new XElement("year", start_rent.Year), new XElement("month", start_rent.Month), new XElement("day", start_rent.Day));
            XElement XEndRent = new XElement("end_rent", new XElement("year", end_rent.Year), new XElement("month", end_rent.Month), new XElement("day", start_rent.Day));
            XElement XDays = new XElement("days", days);
            XElement Xdriver = new XElement("driver", new XElement("driver_1", new XElement("name", driver.first_name), new XElement("id", driver.first_id)), new XElement("driver_2", new XElement("name", driver.second_id), new XElement("id", driver.second_id)));
            XElement XCarNumber = new XElement("number_of_rishui", number_of_rishui);
            XElement XNumberOfPepole = new XElement("number_of_pepole", number_of_pepole);
            XElement XNumberAtStart = new XElement("number_at_start", number_at_start);
            XElement XNumberAtEnd = new XElement("number_at_end", number_at_end);
            XElement XNNumberDrove = new XElement("number_drove", number_drove);
            XElement XIsDefcive = new XElement("is_defcive", is_defcive);
            XElement Xprice = new XElement("price", price);
            XElement Xended = new XElement("ended", ended);
            return new XElement("Rent", XRunningCode, XStartRent, XEndRent, XDays, Xdriver, XCarNumber, XNumberOfPepole, XNumberAtStart, XNumberAtEnd, XNNumberDrove, XIsDefcive, Xprice, Xended);
        }
    }
}
