using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using BE;
using System.ComponentModel;
using System.Windows;
using System.IO;
using xml_control;

namespace ClassLibrary1
{
    public class DAL_xml : Idal
    {
        xml xml_control = new xml();
        #region singelton
        private static readonly DAL_xml instance = new DAL_xml();
        static DAL_xml() { }

        private DAL_xml()
        {
          
            xml_control.LoadCarData();
            xml_control.LoadClientData();
            xml_control.LoadFaultData();
            xml_control.LoadRentingData();
            xml_control.LoadCarFaultData();
        }

        XElement CreateFiles(string a)
        {
            return new XElement(a);
        }

        public static DAL_xml Instance { get { return instance; } }
        #endregion
        /// <summary>
        /// המרה מסטרינג לאנום
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T ParseTo<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value);
        }

        #region client
        public void add_client(BE.Client cli)
        {
            if (is_client_exist(cli.Id1))
                throw new Exception("קימת תעודת זהות");

            else if (cli.Id1 == 0)
                cli.Id1 = create_new_id();

            xml_control.Client_Root.Add(cli.ToXml());
            xml_control.Client_Root.Save(xml_control.Client_Path);

        }

        public void del_client(BE.Client cli)
        {
            try
            {
                (from item in xml_control.Client_Root.Elements()
                 where item.Element("ID").Value == cli.Id1.ToString()
                 select item).Remove();
                xml_control.Client_Root.Save(xml_control.Client_Path);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void update_client(BE.Client cli, BE.update t, object obj)
        {
            switch (t)
            {
                case update.vatek:
                    if (obj is int)
                    {
                        del_client(cli);
                        cli.Vatk = (int)obj;
                    }
                    else
                    {
                        throw new Exception("לא נשלח מספר של וטק");
                    }
                    break;
                case update.vip:
                    if (obj is bool)
                    {
                        del_client(cli);
                        cli.isVip = (bool)obj;
                    }
                    else
                    {
                        throw new Exception("האוביקט שנשלח אינו מסוג בוליאן");
                    }
                    break;
                case update.address:
                    {
                        if (obj is addres)
                        {
                            del_client(cli);
                            cli.Address1 = (addres)obj;
                        }
                        else
                        {
                            throw new Exception("this objet is not an addres");
                        }
                    }
                    break;
                case update.cradit_card:
                    {
                        if (obj is CreditCard)
                        {
                            del_client(cli);
                            cli.Card_dit = (CreditCard)obj;
                        }
                        else
                        {
                            throw new Exception("this objet is not a credit card");
                        }
                    }
                    break;
                case update.age:
                    {
                        if (obj is int)
                        {
                            del_client(cli);
                            cli.Age = (int)obj;
                        }
                        else
                        {
                            throw new Exception("this objet is not a age");
                        }
                    }
                    break;
                case update.rishion_nahg:
                    if (obj is rishion)
                    {
                        del_client(cli);
                        cli.rishoi = (rishion)obj;
                    }
                    else
                    {
                        throw new Exception("this objet is not a age");
                    }
                    break;
                default:
                    throw new Exception(string.Format("this {0} is not an updat option", t.ToString()));
            }
            add_client(cli);
        }
        #endregion
        #region car
        public void add_car(BE.car ca)
        {
            if (is_car_exist(ca.car_number))
                throw new Exception("קיים מספר רכב זה");

            else if (ca.car_number == 0)
                ca.car_number = create_new_license_number();

            xml_control.Car_Root.Add(ca.ToXml());
            xml_control.Car_Root.Save(xml_control.Car_Path);

        }

        public void del_car(BE.car ca)
        {
            try
            {
                (from item in xml_control.Car_Root.Elements()
                 where item.Element("car_number").Value == ca.car_number.ToString()
                 select item).Remove();
                xml_control.Car_Root.Save(xml_control.Car_Path);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void update_car(BE.car ca, BE.update t, object obj)
        {
            switch (t)
            {
                case update.date_test:
                    if (obj is DateTime?)
                    {
                        del_car(ca);
                        ca.date_of_fix = (DateTime)obj;
                    }
                    else
                    {
                        throw new Exception("this objet is not a DateTime");
                    }
                    break;
                case update.destance:
                    if (obj is int)
                    {
                        del_car(ca);
                        ca.total_distance += float.Parse(obj.ToString());
                    }
                    else
                    {
                        throw new Exception("this objet is not a bool");
                    }
                    break;
                case update.rishion_rachav:
                    if (obj is rishion_rachav)
                    {
                        del_car(ca);
                        ca.rishion = (rishion_rachav)obj;
                    }
                    else
                    {
                        throw new Exception("this objet is not an rishion rachav");
                    }
                    break;
                case update.takin:
                    if (obj is bool)
                    {
                        del_car(ca);
                        ca.takin = (bool)obj;
                    }
                    else
                    {
                        throw new Exception("this objet is not an boolean");
                    }
                    break;
                case update.panuy:
                    if (obj is bool)
                    {
                        del_car(ca);
                        ca.moosker = (bool)obj;
                    }
                    else
                    {
                        throw new Exception("this objet is not an boolean");
                    }
                    break;
                case update.mirchk:
                    if (obj is float)
                    {
                        del_car(ca);
                        ca.total_distance += (float)obj;
                    }
                    else
                    {
                        throw new Exception("this objet is not an mailage");
                    }
                    break;
                case update.address:
                    {
                        if (obj is addres)
                        {
                            del_car(ca);
                            ca.snif_address = (addres)obj;
                        }
                        else
                        {
                            throw new Exception("this objet is not an addres");
                        }
                    }
                    break;
                case update.mosif_n:
                    if (obj is int)
                    {
                        del_car(ca);
                        ca.car_people_able += (int)obj;
                    }
                    else
                    {
                        throw new Exception("this objet is not an pepole number");
                    }
                    break;
                case update.morid_n:
                    if (obj is int)
                    {
                        del_car(ca);
                        ca.car_people_able -= (int)obj;
                    }
                    else
                    {
                        throw new Exception("this objet is not an pepole number");
                    }
                    break;
                case update.ids:
                    {
                        del_car(ca);
                        if (obj is int || obj is long || obj is decimal)
                        {
                            if (ca.car_number > 10m || ca.car_number < 1m)
                            {
                                ca.car_number = create_new_license_number();
                            }
                            else
                            {
                                ca.car_number = (int)obj;
                            }
                        }
                        else
                        {
                            throw new Exception("this objet is not an id");
                        }
                    }
                    break;
                default:
                    throw new Exception(string.Format("this {0} is not an update option", t.ToString()));
            }
            add_car(ca);
        }
        #endregion
        #region rent
        public void add_rent(BE.Renting rent)
        {
            if (is_rent_exist(rent.running_code))
                throw new Exception("קיים מספר הזמנה זה");

            else if (rent.running_code == 0)
                rent.running_code = create_new_run_code();

            xml_control.Renting_Root.Add(rent.ToXml());
            xml_control.Renting_Root.Save(xml_control.Renting_Path);

        }

        public void del_rent(BE.Renting rent)
        {
            try
            {
                (from item in xml_control.Renting_Root.Elements()
                 where item.Element("running_code").Value == rent.running_code.ToString()
                 select item).Remove();
                xml_control.Renting_Root.Save(xml_control.Renting_Path);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void update_rent(BE.Renting rent, BE.update t, object obj)
        {
            switch (t)
            {
                case update.rishion_nahg:
                    if (obj is long)
                    {
                        del_rent(rent);
                        Drivers dra = new Drivers
                        {
                            first_id=rent.driver.first_id,
                            first_name = rent.driver.first_name,
                            second_id=(long)obj,
                        second_name=""
                        };
                        rent.driver = dra;
                    }
                    else
                    {
                        throw new Exception("this objet is not a float");
                    }
                    break;
                case update.date_end:
                    if (obj is DateTime)
                    {
                        del_rent(rent);
                        rent.end_rent = (DateTime)obj;
                    }
                    else
                    {
                        throw new Exception("this objet is not a float");
                    }
                    break;
                case update.destance:
                    if (obj is float || obj is int)
                    {
                        del_rent(rent);
                        rent.number_at_end = (int)obj;
                        rent.number_drove = rent.number_at_end - rent.number_at_start;
                    }
                    else
                    {
                        throw new Exception("this objet is not a float");
                    }
                    break;
                case update.defect:
                    if (obj is bool)
                    {
                        del_rent(rent);
                        rent.is_defcive = (bool)obj;
                    }
                    else
                    {
                        throw new Exception("this objet is not a bool");
                    }
                    break;
                case update.ended:
                    if (obj is bool)
                    {
                        del_rent(rent);
                        rent.ended = (bool)obj;
                    }
                    else
                    {
                        throw new Exception("this objet is not a bool");
                    }
                    break;
                case update.price:
                    if (obj is float)
                    {
                        del_rent(rent);
                        rent.price = (float)obj;
                    }
                    else
                    {
                        throw new Exception("this objet is not an pepole number");
                    }
                    break;
                case update.mosif_n:
                    if (obj is Drivers)
                    {
                        del_rent(rent);
                        rent.number_of_pepole = 2;
                    }
                    else
                    {
                        throw new Exception("this objet is not a \"driver object\"");
                    }
                    break;
                case update.morid_n://-
                    if (obj is int)
                    {
                        del_rent(rent);
                        rent.number_of_pepole = 1;
                    }
                    else
                    {
                        throw new Exception("this objet is not a \"int object\"");
                    }
                    break;
                case update.mispar_yamim:
                    if (obj is int)
                    {
                        del_rent(rent);
                        rent.days = (int)obj;
                        
                    }
                    else if (obj is DateTime)
                    {
                        del_rent(rent);
                        rent.end_rent = (DateTime)obj;
                        rent.days = (rent.end_rent - rent.start_rent).Days;
                    }
                    else
                    {
                        throw new Exception("this objet is not a \"int object\"");
                    }
                    break;
                case update.price_horada_achuz:
                    if (obj is int)
                    {
                        if ((int)obj > 100 || (int)obj < 0)
                            throw new Exception("המספר שנשלח הוא לא אחוז נדרש מספר בין 0 ל100 ");

                        del_rent(rent);
                        rent.price = rent.price - (int)obj * rent.price;
                    }
                    else
                    {
                        throw new Exception("צריך לשלוח משתנה מסוג אינטג'ר ");
                    }
                    break;
                case update.price_horada_shqulim:
                    if (obj is int)
                    {
                        if ((int)obj > rent.price || (int)obj < 0)
                            throw new Exception("המספר שנשלח צריך להיות גדול מ0 וקטן מהמחיר המקורי");

                        del_rent(rent);
                        rent.price = rent.price - (int)obj;
                    }
                    else
                    {
                        throw new Exception("צריך לשלוח משתנה מסוג אינטג'ר ");
                    }
                    break;
                case update.panuy:
                    if (obj is bool)
                    {
                        del_rent(rent);
                        rent.panuy = (bool)obj;
                    }
                    else
                    {
                        throw new Exception("this objet is not a \"int object\"");
                    }
                    break;
                default:
                    throw new Exception(string.Format("לא ניתן לעדכן {0} בהשכרה", t.ToString()));

            }
            add_rent(rent);
        }

        #endregion
        #region fault
        public void add_Fault(BE.Fault fail)
        {
            if (is_fault_code_exist(fail.fault_number))
                throw new Exception("קימת תעודת זהות");

            else if (fail.fault_number == 0)
                fail.fault_number = create_new_fault_code();

            xml_control.Fault_Root.Add(fail.ToXml());
            xml_control.Fault_Root.Save(xml_control.Fault_Path);
        }

        public void del_Fault(BE.Fault fail)
        {
            try
            {
                (from item in xml_control.Fault_Root.Elements()
                 where item.Element("fault_number").Value == fail.fault_number.ToString()
                 select item).Remove();
                xml_control.Fault_Root.Save(xml_control.Fault_Path);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void update_Fault(BE.Fault Fault_number, BE.update t, object obj)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region car_fault

        public void add_Car_fault(BE.Car_Fault cf)
        {
            if (this.return_list(retur.car_fault).Contains(cf))
                throw new Exception("הקשר בין התקלה לרכב כבר קיים");
            xml_control.Car_Fault_Root.Add(cf.ToXml());
            xml_control.Car_Fault_Root.Save(xml_control.Car_Fault_Path);

        }

        public void Del_car_fault(BE.Car_Fault temp)
        {
            try
            {
                (from item in xml_control.Car_Fault_Root.Elements()
                 where item.Element("car_number").Value == temp.id.ToString() && item.Element("fault_number").Value==temp.fault_number.ToString()
                 select item).Remove();
                xml_control.Car_Fault_Root.Save(xml_control.Car_Fault_Path);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Del_all_car_fault(int a)
        {
            try
            {
                (from item in xml_control.Car_Fault_Root.Elements()
                 where item.Element("car_number").Value == a.ToString()
                 select item).Remove();
                xml_control.Car_Fault_Root.Save(xml_control.Car_Fault_Path);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        #endregion
        #region other function
        public System.Collections.IList return_list(BE.retur t)
        {
            switch (t)
            {
                case retur.car:
                    return (from item in xml_control.Car_Root.Elements()
                            select new car
                            {
                                car_number = Convert.ToInt32(item.Element("car_number").Value),
                                snif_address = new addres
                                {
                                    city = (item.Element("snif_address").Element("city").Value),
                                    street = (item.Element("snif_address").Element("street").Value),
                                    building = int.Parse((item.Element("snif_address").Element("building").Value))
                                },
                                date_of_fix = new DateTime(int.Parse(item.Element("date_of_fix").Element("year").Value), int.Parse(item.Element("date_of_fix").Element("month").Value), int.Parse(item.Element("date_of_fix").Element("day").Value)),
                                year_of_build = Convert.ToInt32(item.Element("year_of_build").Value),
                                car_info = new car_type
                                {
                                    Manufacturer = item.Element("car_info").Element("Manufacturer").Value,
                                    model = item.Element("car_info").Element("model").Value,
                                    Engine_capacety = Convert.ToInt32(item.Element("car_info").Element("Engine_capacety").Value)
                                },
                                car_gear = ParseTo<gear>(item.Element("car_gear").Value),
                                car_people_able = int.Parse(item.Element("car_people_able").Value),
                                number_of_car_doors = int.Parse(item.Element("number_of_car_doors").Value),
                                total_distance = float.Parse(item.Element("total_distance").Value),
                                takin = bool.Parse(item.Element("takin").Value),
                                moosker = bool.Parse(item.Element("moosker").Value),
                                rishion = new rishion_rachav
                                {
                                    test = new DateTime(int.Parse(item.Element("Rishion").Element("date_test").Element("year").Value), int.Parse(item.Element("Rishion").Element("date_test").Element("month").Value), int.Parse(item.Element("Rishion").Element("date_test").Element("day").Value)),
                                    type = ParseTo<catagory_of_vehicles>(item.Element("Rishion").Element("catagory_of_vehicles").Value)
                                }
                            }).ToList();
                case retur.fault:
                    return (from item in xml_control.Fault_Root.Elements()
                            select new Fault
                            {
                                fault_number = int.Parse(item.Element("fault_number").Value),
                                Ft = ParseTo<fault_type>(item.Element("fault_type").Value),
                                who = ParseTo<who_fault>(item.Element("who").Value),
                                total_price = float.Parse(item.Element("price").Value),
                                name_of_shop = item.Element("shop").Value
                            }
                            ).ToList();
                case retur.renting:
                    return (from item in xml_control.Renting_Root.Elements()
                            select new Renting
                            {
                                running_code = long.Parse(item.Element("running_code").Value),
                                start_rent = new DateTime(int.Parse(item.Element("start_rent").Element("year").Value), int.Parse(item.Element("start_rent").Element("month").Value), int.Parse(item.Element("start_rent").Element("day").Value)),
                                end_rent = new DateTime(int.Parse(item.Element("end_rent").Element("year").Value), int.Parse(item.Element("end_rent").Element("month").Value), int.Parse(item.Element("end_rent").Element("day").Value)),
                                days = int.Parse(item.Element("days").Value),
                                driver = new Drivers
                                {
                                    first_id = long.Parse(item.Element("driver").Element("driver_1").Element("id").Value),
                                    second_id = long.Parse(item.Element("driver").Element("driver_1").Element("id").Value),
                                    first_name = (item.Element("driver").Element("driver_2").Element("name").Value),
                                    second_name = (item.Element("driver").Element("driver_2").Element("name").Value),
                                },
                                number_of_rishui = int.Parse(item.Element("number_of_rishui").Value),
                                number_of_pepole = int.Parse(item.Element("number_of_pepole").Value),
                                number_at_start = float.Parse(item.Element("number_at_start").Value),
                                number_at_end = float.Parse(item.Element("number_at_end").Value),
                                number_drove = float.Parse(item.Element("number_drove").Value),
                                is_defcive = bool.Parse(item.Element("is_defcive").Value),
                                price = float.Parse(item.Element("price").Value),
                                ended = bool.Parse(item.Element("ended").Value),

                            }
                            ).ToList();
                case retur.client:
                    return (from item in xml_control.Client_Root.Elements()
                            select new Client
                            {
                                Id1 = int.Parse(item.Element("ID").Value),
                                Address1 = new addres
                                {
                                    city = (item.Element("Addres").Element("city").Value),
                                    street = (item.Element("Addres").Element("street").Value),
                                    building = int.Parse((item.Element("Addres").Element("building").Value))
                                },
                                Birth_date = new DateTime(int.Parse(item.Element("Birth_date").Element("year").Value), int.Parse(item.Element("Birth_date").Element("month").Value), int.Parse(item.Element("Birth_date").Element("day").Value)),
                                Card_dit = new CreditCard
                                {
                                    number_c = item.Element("CraditCard").Element("card_number").Value,
                                    cvc_number = int.Parse(item.Element("CraditCard").Element("cvv_number").Value),
                                    exp_date = new DateTime(int.Parse(item.Element("CraditCard").Element("experiton_date").Element("year").Value), int.Parse(item.Element("CraditCard").Element("experiton_date").Element("month").Value), int.Parse(item.Element("CraditCard").Element("experiton_date").Element("day").Value))
                                },
                                misper_tklot = int.Parse(item.Element("misper_tklot").Value),
                                rishoi = new rishion
                                {
                                    catgor = ParseTo<catagory_of_vehicles>(item.Element("rishion").Element("rishion_type").Value),
                                    mispar_rishion = int.Parse(item.Element("rishion").Element("mispar_rishion").Value),
                                    tokf = new DateTime(int.Parse(item.Element("rishion").Element("experiton_date").Element("year").Value), int.Parse(item.Element("rishion").Element("experiton_date").Element("month").Value), int.Parse(item.Element("rishion").Element("experiton_date").Element("day").Value))
                                },
                                isVip = bool.Parse(item.Element("is_vip").Value),
                                Age = int.Parse(item.Element("age").Value),
                                Vatk = int.Parse(item.Element("vatk").Value),
                            }
                            ).ToList();
                case retur.car_fault:
                    return (from item in xml_control.Car_Fault_Root.Elements()
                            select new Car_Fault
                            {
                                fault_number = int.Parse(item.Element("fault_number").Value),
                                id = int.Parse(item.Element("car_number").Value),
                                date = new DateTime(int.Parse(item.Element("date").Element("year").Value), int.Parse(item.Element("date").Element("month").Value), int.Parse(item.Element("date").Element("day").Value)),
                                chazra_mitkun = new DateTime(int.Parse(item.Element("chazra_mitkun").Element("year").Value), int.Parse(item.Element("chazra_mitkun").Element("month").Value), int.Parse(item.Element("chazra_mitkun").Element("day").Value))
                            }
                           ).ToList();
            }
            throw new Exception("error");
        }

        public void close_rent(BE.Renting rent)
        {
            throw new NotImplementedException();
        }//-

        public bool is_client_exist(long id)
        {
            foreach (var item in xml_control.Client_Root.Elements())
            {
                if (item.Element("ID").Value == id.ToString())
                    return true;
            }
            return false;
        }

        public bool is_car_exist(int license_number)
        {
            foreach (var item in xml_control.Car_Root.Elements())
            {
                if (item.Element("car_number").Value == license_number.ToString())
                    return true;
            }
            return false;
        }

        public bool is_rent_exist(long run_code)
        {
            bool t = (from item in xml_control.Renting_Root.Elements()
                      where item.Element("running_code").Value == run_code.ToString()
                       select true).FirstOrDefault();
            return t;
        }

        public bool is_fault_code_exist(int fault_coded)
        {
            foreach (var item in xml_control.Fault_Root.Elements())
            {
                if (item.Element("fault_number").Value == fault_coded.ToString())
                    return true;
            }
            return false;
        }

        public bool is_car_fault_conection(int license_number)
        {
            foreach (var item in xml_control.Car_Fault_Root.Elements())
            {
                if (item.Element("id").Value == license_number.ToString())
                    return true;
            }
            return false;
        }
        public bool is_car_fault_conection(int license_number, int fault_number)
        {
            foreach (var item in xml_control.Car_Fault_Root.Elements())
            {
                if (item.Element("car_number").Value == license_number.ToString() && item.Element("fault_number").Value == fault_number.ToString())
                    return true;
            }
            return false;
        }
        public void Del_car_fault(int p)
        {
            throw new NotImplementedException();
        }//-

        long create_new_id()
        {
            Random t = new Random();
            bool tem = true;
            long a;
            do
            {
                a = t.Next(100000000, 1000000000);
                foreach (Client item in return_list(retur.client))
                {
                    tem = true;
                    if (a == item.Id1)
                    {
                        tem = false;
                        break;
                    }
                }

            } while (!tem);
            return a;
        }

        int create_new_license_number()
        {
            Random t = new Random();
            bool tem = true;
            int a;
            do
            {
                a = t.Next(100000000, 1000000000);
                foreach (car item in return_list(retur.car))
                {
                    tem = true;
                    if (a == item.car_number)
                    {
                        tem = false;
                        break;
                    }
                }

            } while (!tem);
            return a;
        }

        long create_new_run_code()
        {
            long[] b = (from a in xml_control.Renting_Root.Elements()
                        select long.Parse(a.Element("running_code").Value)).ToArray();
            if (b == null)
                return 10000000;
            Array.Sort(b);
            return b[b.Length - 1] + 1;
        }

        int create_new_fault_code()
        {

            Random t = new Random();
            bool tem = true;
            int a;
            do
            {
                a = t.Next(100000000, 1000000000);
                foreach (Fault item in return_list(retur.fault))
                {
                    tem = true;
                    if (a == item.fault_number)
                    {
                        tem = false;
                        break;
                    }
                }
            } while (!tem);
            return a;
        }

         long Idal.create_new_id()
        {

            Random t = new Random();
            bool tem = true;
            long a;
            do
            {
                a = t.Next(100000000, 1000000000);
                foreach (Client item in return_list(retur.client))
                {
                    tem = true;
                    if (a == item.Id1)
                    {
                        tem = false;
                        break;
                    }
                }

            } while (!tem);
            return a;
        }

         int Idal.create_new_license_number()
        {
            Random t = new Random();
            bool tem = true;
            int a;
            do
            {
                a = t.Next(100000000, 1000000000);
                foreach (car item in return_list(retur.car))
                {
                    tem = true;
                    if (a == item.car_number)
                    {
                        tem = false;
                        break;
                    }
                }

            } while (!tem);
            return a;
        }

         long Idal.create_new_run_code()
        {
            long[] b = (from a in xml_control.Renting_Root.Elements()
                        select long.Parse(a.Element("running_code").Value)).ToArray();
            if (b==null)
                return 10000000;
             Array.Sort(b);
             return b[b.Length - 1] + 1;
        }

         int Idal.create_new_fault_code()
        {
            Random t = new Random();
            bool tem = true;
            int a;
            do
            {
                a = t.Next(100000000, 1000000000);
                foreach (Fault item in return_list(retur.fault))
                {
                    tem = true;
                    if (a == item.fault_number)
                    {
                        tem = false;
                        break;
                    }
                }
            } while (!tem);
            return a;
        }

        #endregion


         
    }
}
