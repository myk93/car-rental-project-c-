using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public struct addres
    {
        public string city;
        public string street;
        public int building;
        public override string ToString()
        {
            return string.Format("the name of the city is {0} \nthe name of the street is {1} \nbuilding number {2} ", city, street, building);
        }
        public string ToString(params string[] am)
        {
            string temp = "";
            bool[] t = new bool[] { false, false, false };
            foreach (var item in am)
            {
                switch (item)
                {
                    case "city":
                        t[0] = true;
                        break;
                    case "street":
                        t[1] = true;
                        break;
                    case "building":
                        t[2] = true;
                        break;
                }
            }
            if (t[0])
            {
                temp += "the name of the city is" + city;
            }
            if (t[1])
            {
                temp += "the name of the street is" + street;
            }
            if (t[2])
            {
                temp += "building number " + building.ToString();
            }
            return temp;
        }
        public addres(string ci,string str,int build)
        {
            city = ci;
            street = str;
            building = build;
        }
    }//+
    public struct CreditCard
    {
        public int cvc_number;
        public string number_c;
        public DateTime exp_date;       
        public override string ToString()
        {
            return "the credit card number is " + number_c + "the cvc number is " + cvc_number.ToString() + " is Exp date is " + exp_date.ToString("MM:YYYY");
        }
    }//-
    public struct Drivers
    {
        public long first_id;
        public string first_name;
        public long second_id;
        public string second_name;
        public Drivers(long fId, string fName, long sId = 9999999, string sName = "")
        {
            first_id = fId;
            first_name = fName;
            second_id = sId;
            second_name = sName;
        }
        public override string ToString()
        {
            if (second_id==9999999)
                return string.Format("the driver name is {0} and his id is{1}", first_name, first_id);
            return string.Format("the main driver is {0} and his id is {1} \n the secondry driver is {2} and his id is {3}", first_name, first_id, second_name, second_id);
        }
    }//+
    public struct rishion
    {
        public int mispar_rishion;
        public DateTime tokf;
        public catagory_of_vehicles catgor;
        public override string ToString()
        {
            return string.Format("\nthe rishaion number {0} \nexp date {1} \ndrive lavel-{2}", mispar_rishion, tokf.ToShortDateString(), catgor);
        }
    }//+
    public struct rishion_rachav
    {
        public catagory_of_vehicles type;
        public DateTime test;
        public rishion_rachav(catagory_of_vehicles cov,DateTime dt)
        {
            type = cov;
            test = dt;
        }
        public override string ToString()
        {
            return string.Format("pepole above level {0} can drive this car \n this car need to have test at {1}",type,test.ToShortDateString());
        }
    }//+
    public struct car_type
    {
        public string Manufacturer;
        public string model;
        public int Engine_capacety;
        public car_type(string man,string model ,int en)
        {
            Manufacturer = man;
            this.model = model;
            Engine_capacety = en;
        }
        public override string ToString()
        {
            return string.Format("\nthe car Manufacturer {0} \nthe model is {1} \nthe Engine capacety is {2} ",Manufacturer,model,Engine_capacety);
        }
    }//+
    public struct kamut_fault
    {
        public fault_type a;
        public int kamut;
    }//+
}
