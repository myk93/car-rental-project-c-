using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DS;

namespace ClassLibrary1
{
    public sealed class Dal_imp : Idal
    {
        static long run = 10000000;

        #region singelton
        private static readonly Dal_imp instance = new Dal_imp();
        static Dal_imp() { }

        private Dal_imp() { }

        public static Dal_imp Instance { get { return instance; } }
        #endregion
        #region client
        /// <summary>
        /// מוסיף קלינט לרשימה ובודק אם תז שלו תקינה
        /// במקרה שלא יצור לה ת"ז חדשה
        /// </summary>
        /// <param name="cli"></param>
        public void add_client(Client cli)
        {
            if (cli.Id1 == 0)
            {
                rishion r = cli.rishoi;
                cli.Id1 = create_new_id();
                r.mispar_rishion = (int)cli.Id1;
                cli.rishoi = r;
            }
            DataSource.Client_list.Add(cli);
        }//++
        /// <summary>
        /// הפונקציה מאפשרת לנו לעדכן אחד מהשדות בקליינט הבאים ע"י אנום
        /// כתובת
        /// מספר כרטיס
        /// גיל
        /// רישיון נהג
        /// </summary>
        /// <param name="cli"></param>
        /// <param name="t"></param>
        /// <param name="obj"></param>
        public void update_client(Client cli, update t, object obj)
        {
            switch (t)
            {
                case update.vatek:
                    if (obj is int)
                    {
                        DataSource.Client_list.Remove(cli);
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
                        DataSource.Client_list.Remove(cli);
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
                            DataSource.Client_list.Remove(cli);
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
                        DataSource.Client_list.Remove(cli);
                        if (obj is CreditCard)
                        {
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
                            DataSource.Client_list.Remove(cli);
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
                        DataSource.Client_list.Remove(cli);
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

            DataSource.Client_list.Add(cli);
        }//+
        /// <summary>
        /// מאפשר למחוק קליינט ע"י התעודת זהות שלו או ע"י שליחת האוביקט שלו
        /// </summary>
        /// <param name="id"></param> 
        public void del_client(Client cli)
        {
            DataSource.Client_list.Remove(cli);
        }//+
        #endregion
        #region car
        /// <summary>
        /// מוסיף רכב לרשימה ובודק אם מספר הרכב שלו תקין
        /// במקרה שלא יצור לה מספר רכב חדש        
        /// </summary>
        /// <param name="ca"></param>
        public void add_car(car ca)
        {
            if (ca.car_number == 0)
                ca.car_number = create_new_license_number();

            DataSource.car_list.Add(ca);
        }//+
        /// <summary>
        /// הפונקציה מאפשרת לנו לעדכן אחד מהשדות בקליינט הבאים ע"י אנום
        /// מירחק שננסע
        /// כתובת
        /// הוספה/הורדה נהגים
        /// בדיקה שמספר הרכב תקין ומעדכן אותו
        /// </summary>
        /// <param name="cli"></param>
        /// <param name="t"></param>
        /// <param name="obj"></param>
        public void update_car(car ca, update t, object obj)
        {
            switch (t)
            {
                case update.date_test:
                    if (obj is DateTime?)
                    {
                        DataSource.car_list.Remove(ca);
                        ca.date_of_fix = (DateTime)obj;
                    }
                    else
                    {
                        throw new Exception("this objet is not a DateTime");
                    }
                    break;
                case update.destance:
                    if (obj is float)
                    {
                        DataSource.car_list.Remove(ca);
                        ca.total_distance += (float)obj;
                    }
                    else
                    {
                        throw new Exception("this objet is not a bool");
                    }
                    break;
                case update.rishion_rachav:
                    if (obj is rishion_rachav)
                    {
                        DataSource.car_list.Remove(ca);
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
                        DataSource.car_list.Remove(ca);
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
                        DataSource.car_list.Remove(ca);
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
                        DataSource.car_list.Remove(ca);
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
                            DataSource.car_list.Remove(ca);
                            ca.snif_address = (addres)obj;
                        }
                        else
                        {
                            throw new Exception("this objet is not an addres");
                        }
                    }
                    break;
                case update.mosif_n:
                    DataSource.car_list.Remove(ca);
                    if (obj is int)
                    {
                        DataSource.car_list.Remove(ca);
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
                        DataSource.car_list.Remove(ca);
                        ca.car_people_able -= (int)obj;
                    }
                    else
                    {
                        throw new Exception("this objet is not an pepole number");
                    }
                    break;
                case update.ids:
                    {
                        DataSource.car_list.Remove(ca);
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
            DataSource.car_list.Add(ca);
        }//+
        /// <summary>
        /// מוחק רכב עי מספר הרכב או ע"י אוביקט מיסוג רכב אם האוביקט/מספר הרחב לא קיים ישלח הודעת שגיאה
        /// </summary>
        /// <param name="car_number">
        /// מספר רכב
        /// </param>
        public void del_car(car ca)
        {
            DataSource.car_list.Remove(ca);
        }//+
        #endregion
        #region rent
        /// <summary>
        ///להוסיף חוזה השכרה
        /// </summary>
        /// <param name="rent"></param>
        public void add_rent(Renting rent)
        {
            if (rent.running_code == 0)
            {
                rent.running_code = create_new_run_code();
            }
            DataSource.Renting_list.Add(rent);
        }//+
        /// <summary>
        /// למחוק חוזה השכרה
        /// </summary>
        /// <param name="rent"></param>
        public void del_rent(Renting rent)
        {
            DataSource.Renting_list.Remove(rent);
        }//+
        /// <summary>
        /// הפונקציה מאפשרת לנו לעדכן אחד מהשדות בקליינט הבאים ע"י אנום
        /// מחיר
        /// כתובת
        /// הוספה/הורדה נהגים מורשים
        /// מספר ימים
        /// </summary>
        /// <param name="run_code"></param>
        /// <param name="t"></param>
        /// <param name="obj"></param>
        public void update_rent(Renting rent, update t, object obj)
        {
            switch (t)
            {
                case update.date_end:
                    if (obj is DateTime)
                    {
                        DataSource.Renting_list.Remove(rent);
                        rent.end_rent = (DateTime)obj;
                    }
                    else
                    {
                        throw new Exception("this objet is not a float");
                    }
                    break;
                case update.destance:
                    if (obj is float||obj is int)
                    {
                        DataSource.Renting_list.Remove(rent);
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
                        DataSource.Renting_list.Remove(rent);
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
                        DataSource.Renting_list.Remove(rent);
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
                        DataSource.Renting_list.Remove(rent);
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
                        DataSource.Renting_list.Remove(rent);
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
                        DataSource.Renting_list.Remove(rent);
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
                        DataSource.Renting_list.Remove(rent);
                        rent.days = (int)obj;
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

                        DataSource.Renting_list.Remove(rent);
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

                        DataSource.Renting_list.Remove(rent);
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
                        DataSource.Renting_list.Remove(rent);
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
            DataSource.Renting_list.Add(rent);
        }//+
        #endregion
        #region fault
        /// <summary>
        /// פונקציה להוספת תקלה
        /// </summary>
        /// <param name="fail"></param>
        public void add_Fault(Fault fail)
        {
            if (fail.fault_number == 0)
                fail.fault_number = create_new_fault_code();

            DataSource.Fault_list.Add(fail);
        }//+
        /// <summary>
        /// פונקציה למחיקת תקלה
        /// </summary>
        /// <param name="fail"></param>
        public void del_Fault(Fault fail)
        {
            DataSource.Fault_list.Remove(fail);
        }//+
        /// <summary>
        /// פומנקציה לעדכון תקלה
        /// </summary>
        /// <param name="Fault"></param>
        /// <param name="t"></param>
        /// <param name="obj"></param>
        public void update_Fault(Fault Fault, update t, object obj)
        {
            switch (t)
            {
                case update.price:
                    if (obj is float)
                    {
                        Fault.total_price = (float)obj;
                        DataSource.Fault_list.Remove(Fault);
                    }
                    else
                    {
                        throw new Exception("לא נשלח מחיר");
                    }
                    break;
                case update.pirut_htakla:
                    if (obj is fault_type)
                    {
                        DataSource.Fault_list.Remove(Fault);
                        Fault.Ft = (fault_type)obj;
                    }
                    else
                    {
                        throw new Exception("לא נשלח סוג התקלה");
                    }
                    break;
                case update.gorm_htakla:
                    if (obj is who_fault)
                    {
                        DataSource.Fault_list.Remove(Fault);
                        Fault.who = (who_fault)obj;
                    }
                    else
                    {
                        throw new Exception("לא נשלח מקור התקלה");
                    }
                    break;
                case update.musch:
                    if (obj is string)
                    {
                        DataSource.Fault_list.Remove(Fault);
                        Fault.name_of_shop = (string)obj;
                    }
                    else
                    {
                        throw new Exception("לא נשלח שם המוסך");
                    }
                    break;
                case update.price_horada_shqulim:
                    if (obj is float)
                    {
                        DataSource.Fault_list.Remove(Fault);
                        Fault.total_price = Fault.total_price - (float)obj;
                    }
                    else
                    {
                        throw new Exception("לא נשלח סוג מחיר");
                    }
                    break;
                case update.price_horada_achuz:
                    if (obj is float)
                    {
                        DataSource.Fault_list.Remove(Fault);
                        Fault.total_price = Fault.total_price - Fault.total_price * (float)obj / 100 + Fault.total_price * (float)obj % 100;
                    }
                    else
                    {
                        throw new Exception("לא נשלח סוג מחיר");
                    }
                    break;
                default:
                    break;
            }
            DataSource.Fault_list.Add(Fault);
        }//+
        #endregion
        #region car fault
        /// <summary>
        ///  הפונקציה מוסיפה קשר בין תקלה לרכב ומעדכנת את כמות התקלות של הנהג הרישמי
        /// </summary>
        /// <param name="cf"></param>
        public void add_Car_fault(Car_Fault cf)
        {
            if (DataSource.Car_Fault_list.Contains(cf))
                throw new Exception("הקשר בין התקלה לרכב כבר קיים");

            DataSource.Car_Fault_list.Add(cf);

            long t = (from item in DataSource.Renting_list
                      where item.number_of_rishui == cf.id
                      select item.driver.first_id).FirstOrDefault();
            if (t!=0)
            {
                Client b = (DataSource.Client_list.Where(a => a.Id1 == t)).First();
                DataSource.Client_list.Remove(b);
                b.misper_tklot++;
                DataSource.Client_list.Add(b);
            }

        }//+
        /// <summary>
        /// הפונקציה מוציאה מהרשימה את שמקשרת בין התקלה לרכב
        /// </summary>
        /// <param name="temp"></param>
        public void Del_car_fault(Car_Fault temp)
        {
            DataSource.Car_Fault_list.Remove(temp);
        }//+
        /// <summary>
        /// הפונקציה מקבלת מספר רכב ומחוקת את כל הקשרים שיש בין הרכבים לתקלות וגם מוחק את כל התקלות מרשימת התקלות
        /// </summary>
        /// <param name="a"></param>
        public void Del_all_car_fault(int a)
        {
            var temp = DataSource.Car_Fault_list.Where(item => item.id == a);
            foreach (var item in temp)
            {
                DataSource.Car_Fault_list.Remove(item);
                DataSource.Fault_list.RemoveAll(am => am.fault_number == item.fault_number);
            }
        }//+
        #endregion
        #region other function
        #region פונקציות שיוצרות מספר זיהוי חדש
        /// <summary>
        /// פונקציה שיוצרת מספר תעודת זהות חדשה
        /// </summary>
        /// <returns></returns>
        public long create_new_id()
        {
            Random t = new Random();
            bool tem = true;
            long a;
            do
            {
                a = t.Next(100000000, 1000000000);
                foreach (var item in DataSource.Client_list)
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
        }//+
        /// <summary>
        /// פונקציה שיוצרת מספר רכב חדשה
        /// </summary>
        /// <returns></returns>
        public int create_new_license_number()
        {
            Random t = new Random();
            bool tem = true;
            int a;
            do
            {
                a = t.Next(1000000, 10000000);
                foreach (var item in DataSource.car_list)
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
        }//+
        /// <summary>
        ///פונקציה מוסיפה למשתנה הסטטי אחד ושולחת חזרה למישתמש
        /// </summary>
        /// <returns></returns>
        public long create_new_run_code()
        {
            return Dal_imp.run++;
        }//+
        /// <summary>
        /// פונקציה שיוצרת מספר תקלה חדשה
        /// </summary>
        /// <returns></returns>
        public int create_new_fault_code()
        {
            Random t = new Random();
            bool tem = true;
            int a;
            do
            {
                a = t.Next(1000000, 10000000);
                foreach (var item in DataSource.Fault_list)
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
        }//+
        #endregion
        #region פונקציות שבודקות האם הלקוח/הזמנה/רכב/תקלה קימיים
        public bool is_client_exist(long id)
        {
            foreach (var item in DataSource.Client_list)
            {
                if (id == item.Id1)
                    return true;
            }
            return false;
        }
        public bool is_car_exist(int license_number)
        {
            foreach (var item in DataSource.car_list)
            {
                if (license_number == item.car_number)
                    return true;
            }
            return false;
        }
        public bool is_rent_exist(long run_code)
        {
            foreach (var item in DataSource.Renting_list)
            {
                if (run_code == item.running_code)
                    return true;
            }
            return false;
        }
        public bool is_fault_code_exist(int fault_code)
        {
            foreach (var item in DataSource.Fault_list)
            {
                if (fault_code == item.fault_number)
                    return true;
            }
            return false;
        }
        public bool is_car_fault_conection(int license_number, int fault_number)
        {
            foreach (var item in DataSource.Car_Fault_list)
            {
                if (fault_number == item.fault_number&&item.id==license_number)
                    return true;
            }
            return false;
        }
        #endregion

        /// <summary>
        /// הפונקציה הזאת עושה החלפה בין הזמנה שלא נסגרה להזמנה שנסגרה
        /// </summary>
        /// <param name="rent"></param>
        public void close_rent(Renting rent)
        {
            bool t = false;
            Renting rent1 = new Renting();
            foreach (var item in DataSource.Renting_list)
            {
                if (item.running_code == rent.running_code)
                {
                    t = true;
                    rent1 = item;
                    break;
                }
            }
            if (t)
            {
                DataSource.Renting_list.Remove(rent1);
                DataSource.Renting_list.Add(rent);
            }
        }
        /// <summary>
        /// הפונקצי מקבלת אנום מסוג 
        /// retur
        /// </summary>
        /// <param name="t"></param>
        /// <returns>
        ///  הפונקציה מחזירה את הרשימה לפי מה שנשלח
        /// </returns>
        IList Idal.return_list(retur t)
        {
            switch (t)
            {
                case retur.car:
                    return DataSource.car_list;
                case retur.fault:
                    return DataSource.Fault_list;
                case retur.renting:
                    return DataSource.Renting_list;
                case retur.client:
                    return DataSource.Client_list;
                case retur.car_fault:
                    return DataSource.Car_Fault_list;
                default:
                    throw new Exception("אין רשימה כזאת");
            }
        }
        /// <summary>
        /// פונקציה בוליאנית שבודקת האם קיים קשר בין תקלה למכונית
        /// </summary>
        /// <param name="license_number"></param>
        /// <returns>
        /// מחזירה אמת או שקר
        /// </returns>
        public bool is_car_fault_conection(int license_number)
        {
            foreach (var item in DataSource.Car_Fault_list)
            {
                if (item.id == license_number)
                    return true;
            }
            return false;
        }
        /// <summary>
        /// הפונקציה מוחקת את כל השגיאות 
        /// </summary>
        /// <param name="p"></param>
        public void Del_car_fault(int p)
        {
            DataSource.Car_Fault_list.RemoveAll(am => am.fault_number == p);
        }
        #endregion


      
    }
}
