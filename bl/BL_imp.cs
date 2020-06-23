using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using ClassLibrary1;
using factory;
using System.Collections;

namespace BL
{

    public class BL_imp : IBL
    {
        #region singelton
        private static readonly BL_imp instance = new BL_imp();

        static BL_imp() { }

        private BL_imp() { }

        public static BL_imp Instance { get { return instance; } }
        #endregion
        Idal Dal = new FactoryDAL().getDAL();
        #region client
        /// <summary>
        /// הוספת לקוח בדיקה שהוא לא קיים כבר
        /// </summary>
        /// <param name="cli"></param>
        public void add_client(Client cli)
        {
            if (Dal.is_client_exist(cli.Id1))
                throw new Exception("הקליינט הזה כבר קיים");

            Dal.add_client(cli);
        }//+
        /// <summary>
        /// מחיקת קליינט
        /// הפונקציה בודקת שהקליינט לא מעורב בהשכרה
        /// </summary>
        /// <param name="id"></param>
        public void del_client(long id)
        {
            if (!Dal.is_client_exist(id))
                throw new Exception("התעודת זהות הזאת לא קיימת");

            Client m = (from t in ((List<Client>)Dal.return_list(BE.retur.client))
                        where t.Id1 == id
                        select t).First();
            try
            {
                del_client(m);
            }
            catch (Exception e)
            {

                throw e;
            }

        }//+


        /// <summary>
        /// מחיקת קליינט
        /// הפונקציה בודקת שהקליינט לא מעורב בהשכרה
        /// </summary>
        /// <param name="id"></param>
        public void del_client(Client cli)
        {
            if (!is_client_exist(cli.Id1))
                throw new Exception("הקליינט הזה לא קיים");
            bool z = true;
            foreach (var item in (List<Renting>)Dal.return_list(BE.retur.renting))
            {
                if (!item.ended && cli.Id1 == item.driver.first_id)
                {
                    z = false;
                    break;
                }
            }
            if (z)
            {

               
                if (get_time_from_last_rent(cli.Id1) >= 30)
                    Dal.del_client(cli);
                else
                    throw new Exception("אי אפשר למחוק מישהו לפני שעבר 30 יום מההשכרה האחרונה שלו");
            }
            else
            {
                throw new Exception("אי אפשר למחוק קליינט כל עוד יש לו הזמנות פתוחות");
            }
        }//+
        /// <summary>
        /// הפונקציה מעדכנת לקוח ע"פ האנום שלו
        /// </summary>
        /// <param name="id"></param>
        /// <param name="t"></param>
        /// <param name="obj"></param>
        public void update_client(long id, update t, object obj)
        {
            if (!Dal.is_client_exist(id))
                throw new Exception("התעודת זהות אינה קיימת");

            Client cli = (((List<Client>)Dal.return_list(BE.retur.client)).Where<Client>(fufu => (fufu.Id1 == id))).FirstOrDefault();
            try
            {
                Dal.update_client(cli, t, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }//+
        /// <הגדרה>
        /// הפונקציה מעדכנת לקוח ע"פ האנום שלו
        /// </הגדרה>
        /// <param name="id"></param>
        /// <param name="t"></param>
        /// <param name="obj"></param>
        public void update_client(Client cli, update t, object obj)
        {
            if (!is_client_exist(cli.Id1))
                throw new Exception("הלקוח אינו קיים");

            try
            {
                Dal.update_client(cli, t, obj);
            }
            catch (Exception tem)
            {

                throw tem;
            }
        }//+ 
        #endregion
        #region car
        /// <summary>
        /// הוספה של רכב בדיקה שלא קיים קיים כבר
        /// </summary>
        /// <param name="ca"></param>
        public void add_car(car ca)
        {
            if (is_car_exist(ca.car_number) )
                throw new Exception("הרכב הזה כבר קיים");

            Dal.add_car(ca);
        }//+
        /// <summary>
        /// מחיקת רכב 
        /// בדיקה שהרכב לא נמצא בהשכרה
        /// </summary>
        /// <param name="car_number"></param>
        public void del_car(int car_number)
        {
            if (!Dal.is_car_exist(car_number))
                throw new Exception("המספר רכב הזאת לא קיימת");

            car m = (from t in ((List<car>)Dal.return_list(BE.retur.car))
                     where t.car_number == car_number
                     select t).First();
            try
            {
                del_car(m);
            }
            catch (Exception e)
            {

                throw e;
            }
        }//+
        /// <summary>
        /// מחיקת רכב 
        /// בדיקה שהרכב לא נמצא בהשכרה
        /// </summary>
        /// <param name="car_number"></param>
        public void del_car(car ca)
        {
            if (!is_car_exist(ca.car_number))
                throw new Exception("הרכב הזה לא קיים");

            Dal.del_car(ca);
            Dal.Del_all_car_fault(ca.car_number);
        }//+
        /// <summary>
        /// עידכון רכב
        /// בדיקה שהרכב קיים 
        /// בדיקה שאפשר לעדכן
        /// </summary>
        /// <param name="car_id"></param>
        /// <param name="t"></param>
        /// <param name="obj"></param>
        public void update_car(int car_id, update t, object obj)
        {
            if (!Dal.is_car_exist(car_id))
                throw new Exception("המספר רכב הזאת לא קיימת");

            car m = (from tem in ((List<car>)Dal.return_list(BE.retur.car))
                     where tem.car_number == car_id
                     select tem).First();

            try
            {
                Dal.update_car(m, t, obj);
            }
            catch (Exception e)
            {
                throw e;
            }
        }//+
        /// <summary>
        /// עידכון רכב
        /// בדיקה שהרכב קיים 
        /// בדיקה שאפשר לעדכן
        /// </summary>
        /// <param name="car_id"></param>
        /// <param name="t"></param>
        /// <param name="obj"></param>
        public void update_car(car ca, update t, object obj)
        {
            if (!is_car_exist(ca.car_number))
                throw new Exception("הרכב הזה לא קיים");

            try
            {
                Dal.update_car(ca, t, obj);
            }
            catch (Exception e)
            {

                throw e;
            }
        }//+
        #endregion
        #region rent
        /// <summary>
        /// פונקציה שמוסיפה לרשימת ההזמנות 
        /// בודקת שקיים רכב פנוי
        /// בודקת שהחוזה השכרה הזאת לא קיימת
        /// בודקת שהמספר של הנהג קיים
        /// בודקת שמספר הרכב קיים
        /// בודקת שהמשכיר בגיל שמתאים להשכרה
        /// בודקת שרמת הרישיון מתאימה לרכב 
        /// </summary>
        /// <param name="rent"></param>
        public void add_rent(Renting rent)
        {
            if (!can_rent())
                throw new Exception("אין רכב פנוי להשכרה");

            if (is_rent_exist(rent.running_code))
                throw new Exception("החוזה הזה כבר קיים");

            if (!is_client_exist(rent.driver.first_id))
                throw new Exception("המספר של הנהג הראשי אינו קיים");

            if (!is_car_exist(rent.number_of_rishui))
                throw new Exception("מספר הרכב אינו קיים");

            Client tempC = ((List<Client>)(Dal.return_list(retur.client))).Where(a => a.Id1 == rent.driver.first_id).First();
            car tempc = ((List<car>)(Dal.return_list(retur.car))).Where(a => a.car_number == rent.number_of_rishui).First();

            if ((tempC.rishoi.catgor == catagory_of_vehicles.A))
                if (tempc.rishion.type != catagory_of_vehicles.A)
                    throw new Exception("הרישיון שלך אינו מתאים לרכב הזה");

            if (tempC.rishoi.catgor < tempc.rishion.type)
                throw new Exception("הרישיון שלך אינו מתאים לרכב הזה");

            if (tempC.Age < 18)
                throw new Exception("המשכיר צעיר מדי מכדי להשכיר רכב זה");
            try
            {
                update_car(tempc, update.panuy, false);
            }
            catch (Exception e)
            {
                throw e;
            }
            Dal.add_rent(rent);
        }//+
        /// <summary>
        /// מוחקת חוזה השכרה
        /// בודקת שהחוזה הסתיים
        /// בודקת שהוא קיים
        /// </summary>
        /// <param name="rent"></param>
        public void del_rent(Renting rent)
        {
            if (!is_rent_exist(rent.running_code))
                throw new Exception("החוזה הזה כבר לא קיים");
            if (!rent.ended)
                throw new Exception("אי אפשר למחוק חוזה שעדיין בפעולה");

            Dal.del_rent(rent);
        }//+
        /// <summary>
        /// מוחקת חוזה השכרה
        /// בודקת שהחוזה הסתיים
        /// בודקת שהוא קיים
        /// </summary>
        /// <param name="rent"></param>
        public void del_rent(long rent_code)
        {
            if (is_rent_exist(rent_code))
                throw new Exception("הקוד הזמנה אינו תקין");

            Renting m = (from tem in ((List<Renting>)Dal.return_list(BE.retur.renting))
                         where tem.running_code == rent_code
                         select tem).FirstOrDefault();
            try
            {
                del_rent(m);
            }
            catch (Exception e)
            {

                throw e;
            }
        }//+
        /// <summary>
        /// עידכון חוזה
        /// בדיקה שהחוזה קיים 
        /// בדיקה שאפשר לעדכן
        /// </summary>
        /// <param name="car_id"></param>
        /// <param name="t"></param>
        /// <param name="obj"></param>
        public void update_rent(Renting rent, update t, object obj)
        {
            if (!is_rent_exist(rent.running_code))
                throw new Exception("החוזה הזה לא קיים");
            try
            {
                Dal.update_rent(rent, t, obj);
            }
            catch (Exception e)
            {

                throw new Exception (e.Message);
            }
        }
        /// <summary>
        /// עידכון חוזה
        /// בדיקה שהחוזה קיים 
        /// בדיקה שאפשר לעדכן
        /// </summary>
        /// <param name="car_id"></param>
        /// <param name="t"></param>
        /// <param name="obj"></param>
        public void update_rent(long run_code, update t, object obj)
        {
            if (is_rent_exist(run_code))
                throw new Exception("הקוד הזמנה אינו תקין");

            Renting m = (from tem in ((List<Renting>)Dal.return_list(BE.retur.renting))
                         where tem.running_code == run_code
                         select tem).FirstOrDefault();
            try
            {
                Dal.update_rent(m, t, obj);
            }
            catch (Exception e)
            {

                throw e;
            }
        }//+
        #endregion
        #region fault
        /// <summary>
        /// הוספת תקלה
        /// בדיקה שהתקלה לא קיימת
        /// </summary>
        /// <param name="fail"></param>
        public void add_Fault(Fault fail)
        {
            if (is_fault_code_exist(fail.fault_number))
                throw new Exception("התקלה הזה כבר קיימת");

            Dal.add_Fault(fail);
        }//+
        /// <summary>
        /// מחיקת תקלה וכל הקשרים שיש לרכב
        /// </summary>
        /// <param name="fail"></param>
        public void del_Fault(Fault fail)
        {
            if (!is_fault_code_exist(fail.fault_number))
                throw new Exception("התקלה הזה כבר לא קימת");

            Dal.del_Fault(fail);
            var a = from item in (List<Car_Fault>)(Dal.return_list(retur.car_fault))
                    where item.fault_number == fail.fault_number
                    select item;
            foreach (var item in a)
            {
                Del_car_fault(item.id, fail.fault_number);
            }
        }
        /// <summary>
        /// מחיקת תקלה וכל הקשרים שיש לרכב
        /// </summary>
        /// <param name="fail"></param>
        public void del_Fault(int Fault_number)
        {
            Fault fail = (from tem in ((List<Fault>)Dal.return_list(BE.retur.fault))
                       where tem.fault_number == Fault_number
                       select tem).FirstOrDefault();
            if (!is_fault_code_exist(fail.fault_number))
                throw new Exception("התקלה הזה לא קיים");

            try
            {
                del_Fault(fail);
            }
            catch (Exception e)
            {

                throw e;
            }
        }//+
        /// <summary>
        /// עידכון תקלה
        /// בדיקה שהתקלה קיים 
        /// בדיקה שאפשר לעדכן
        /// </summary>
        /// <param name="car_id"></param>
        /// <param name="t"></param>
        /// <param name="obj"></param>
        public void update_Fault(Fault fail, update t, object obj)
        {
            if (!is_fault_code_exist(fail.fault_number))
                throw new Exception("התקלה שנשלחה לא קיימת");
            try
            {
                Dal.update_Fault(fail, t, obj);
            }
            catch (Exception e)
            {

                throw e;
            }
        }//+
        /// <summary>
        /// עידכון תקלה
        /// בדיקה שהתקלה קיים 
        /// בדיקה שאפשר לעדכן
        /// </summary>
        /// <param name="car_id"></param>
        /// <param name="t"></param>
        /// <param name="obj"></param>
        public void update_Fault(int Fault_number, update t, object obj)
        {
            Fault m = (from tem in ((List<Fault>)Dal.return_list(BE.retur.fault))
                       where tem.fault_number == Fault_number
                       select tem).FirstOrDefault();
            try
            {
                Dal.update_Fault(m, t, obj);
            }
            catch (Exception e)
            {

                throw e;
            }
        } //+
        #endregion
        #region car fault
        /// <summary>
        /// מוסיף קשר בין תקלה לרכב
        /// בודק שהרכב קיים
        /// בודק שהתקלה קיימת
        /// ונותן זמן עכשיוי של התקלה
        /// </summary>
        /// <param name="car_id"></param>
        /// <param name="fault_id"></param>
        public void add_Car_fault(int car_id, int fault_id)
        {

            if (!Dal.is_car_exist(car_id))
                throw new Exception("המספר רכב לא קיים");

            if (!Dal.is_fault_code_exist(fault_id))
                throw new Exception("המספר תקלה לא קימת");

            add_Car_fault(new Car_Fault(car_id, fault_id, DateTime.Now));
        }//+
        /// <summary>
        /// מוסיף קשר בין תקלה לרכב
        /// בודק שהרכב קיים
        /// בודק שהתקלה קיימת
        /// </summary>
        /// <param name="car_id"></param>
        /// <param name="fault_id"></param>
        public void add_Car_fault(int car_id, int fault_id, DateTime dt)
        {
            if (!Dal.is_car_exist(car_id))
                throw new Exception("המספר רכב לא קיים");

            if (!Dal.is_fault_code_exist(fault_id))
                throw new Exception("המספר תקלה לא קימת");

            add_Car_fault(new Car_Fault(car_id, fault_id, dt));
        }//+
        /// <summary>
        /// מוסיף קשר בין תקלה לרכב
        /// בודק אם הקשר קיים
        /// </summary>
        /// <param name="car_id"></param>
        /// <param name="fault_id"></param>
        public void add_Car_fault(Car_Fault cf)
        {
            if (Dal.is_car_fault_conection(cf.id,cf.fault_number))
                throw new Exception("הקשר בין התקלה לרכב כבר קיים");

            Dal.add_Car_fault(cf);
        }//+
        /// <summary>
        /// מוחק קשר בין תקלה לרכב
        /// בודק שהרכב קיים
        /// בודק שהתקלה קיימת
        /// </summary>
        /// <param name="a"></param>
        /// <param name="fault_id"></param>
        public void Del_car_fault(int a, int fault_id)
        {
            if (!Dal.is_car_exist(a))
                throw new Exception("המספר רכב לא קיים");

            if (!Dal.is_fault_code_exist(fault_id))
                throw new Exception("המספר תקלה לא קימת");

            Car_Fault cf = ((List<Car_Fault>)(Dal.return_list(retur.car_fault))).Where(m => m.id == a && m.fault_number == fault_id).First();
            Dal.Del_car_fault(cf);

        }//+
        /// <summary>
        /// מחיקת כל הקשרים שקדשורים לתקלה שנשלחה
        /// </summary>
        /// <param name="p"></param>
        public void Del_car_fault(int p)
        {
            if (!Dal.is_car_fault_conection(p))
                throw new Exception("אין לתקלה זה רכבים מקושרים");

            try
            {
                Dal.Del_car_fault(p);
            }
            catch (Exception e)
            {
                throw e;
            }
        }//+
        /// <summary>
        /// מחיקת כל התקלות שקשורים לרכב
        /// </summary>
        /// <param name="p"></param>
        public void Del_all_car_fault(int a)
        {
            if (!Dal.is_car_fault_conection(a))
            {
                throw new Exception("אין לרכב זה תקלות");
            }
            Dal.Del_all_car_fault(a);
        }//
        #endregion
        #region other function
        /// <summary>
        /// הפונקציה הזאת עושה החלפה בין הזמנה שלא נסגרה להזמנה שנסגרה
        /// </summary>
        /// <param name="rent"></param>
        public void close_rent(Renting rent)
        {
            bool t = false;
            Renting rent1 = new Renting();
            foreach (var item in (List<Renting>)Dal.return_list(retur.renting))
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
                try
                {
                    del_rent(rent1);
                    add_rent(rent);
                }
                catch (Exception e)
                {

                    throw e;
                }
            }
        }
        /// <summary>
        /// הפונקציה מקבלת טווח תאריכים ותעודת זהות של לקוח
        /// </summary>
        /// <param name="id"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns>
        /// הפונקציה מחזירה את הסכום של כל ההזמנות שהלקוח ביצע בטווח תאריכים שנשלח
        /// </returns>
        public float sum_rents(int id, DateTime start, DateTime end)
        {
            if (start > end)
                throw new Exception("התאריך התחלה הוא לפני הסוף");

            return (from item in (List<Renting>)Dal.return_list(BE.retur.renting)
                    where item.driver.first_id == id && item.end_rent < end && item.end_rent > start
                    select item.price).Sum();
        }//+
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public float total_price(long rent_num)
        {
            Renting rent = (from item in (List<Renting>)Dal.return_list(retur.renting)
                            where item.running_code == rent_num
                            select item).First();

            Client cli = (from item in (List<Client>)Dal.return_list(retur.client)
                          where item.Id1 == rent.driver.first_id
                          select item).First();

            car ca = (from item in (List<car>)Dal.return_list(retur.car)
                      where item.car_number == rent.number_of_rishui
                      select item).First();

            var faults = (from item in (List<Fault>)Dal.return_list(retur.fault)
                          from item1 in (List<Car_Fault>)Dal.return_list(retur.car_fault)
                          where item1.id == ca.car_number && item1.fault_number == item.fault_number
                          select item);
            float temp = 0.0F;
            foreach (var item in faults)
            {
                temp += item.total_price;
            }

            if (cli.isVip)
            {
                if (cli.Age < 21)
                    temp += ca.car_info.Engine_capacety * 0.19F * rent.days;
                else if (cli.Age < 24)
                    temp += ca.car_info.Engine_capacety * 0.13F * rent.days;
                else
                    temp += ca.car_info.Engine_capacety * 0.08F * rent.days;
                if (ca.total_distance > 250)
                    temp += (ca.total_distance - 250) * 0.8F;
            }
            else
            {
                if (cli.Age < 21)
                    temp += ca.car_info.Engine_capacety * 0.21F * rent.days;
                else if (cli.Age < 24)
                    temp += ca.car_info.Engine_capacety * 0.15F * rent.days;
                else
                    temp += ca.car_info.Engine_capacety * 0.10F * rent.days;
                if (ca.total_distance > 200)
                    temp += (ca.total_distance - 200) * 0.8F;
            }
            foreach (var item in faults)
            {
                temp += item.total_price * 0.15F;//הוספה של מחיר כל התקלות פלוס קנס על התקלה 
            }
            if (rent.end_rent > DateTime.Now)
            {
                temp += ((DateTime.Now.Year - rent.end_rent.Year) * 365 + (DateTime.Now.Month - rent.end_rent.Month) * 30 + (DateTime.Now.Day - rent.end_rent.Day)) * 10;
            }
            return temp;
        }
        
        /*   public float total_price(long id)
        {
            if (!Dal.is_client_exist(id))
                throw new Exception("המספר זהות אינו קיים");

            float t = (from a in ((List<Renting>)Dal.return_list(BE.retur.renting))
                       where a.driver.first_id == id &&a.ended
                       select a.price).Sum();
            Client te = (from a in ((List<Client>)Dal.return_list(BE.retur.client))
                         where a.Id1 == id
                         select a).First();
            var renting_inv = from a in ((List<Renting>)Dal.return_list(BE.retur.renting))
                       where a.driver.first_id == id
                       select a;
            var cars_inv = from a in ((List<car>)Dal.return_list(BE.retur.car))
                        from a1 in ((List<Renting>)Dal.return_list(BE.retur.renting))
                       where a.car_number == a1.number_of_rishui
                       select a;
            var taklot = ((from a in ((List<Car_Fault>)Dal.return_list(BE.retur.car_fault))
                           from a1 in ((List<Fault>)Dal.return_list(BE.retur.fault))
                           from a2 in cars_inv
                           where a.id == a2.car_number && a.fault_number == a1.fault_number
                           select a1.total_price).Distinct()).Sum(a=>(int)a);
            t += taklot;
            return t;
        }*/
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool is_client_exist(long id)
        {
            try
            {
                return Dal.is_client_exist(id);
            }
            catch (Exception e)
            {

                throw e;
            }
        }//+
        public bool is_clint_young(Client cli)
        {
            if (!is_client_exist(cli.Id1))
                throw new Exception("הקליינט הזה לא קיים");

            if (cli.Age > 24 && cli.Vatk >= 2)
                return true;

            else if (cli.Age < 24 && cli.Vatk >= 3)
                return true;

            else
                return false;
        }//+
        public bool is_car_exist(int license_number)
        {
            try
            {
                return Dal.is_car_exist(license_number);
            }
            catch (Exception e)
            {

                throw e;
            }
        }//+
        public bool is_problem(int id)
        {
            car ca = ((List<car>)Dal.return_list(BE.retur.car)).Where(a => a.car_number == id).FirstOrDefault();
            if (is_car_exist(ca.car_number))
                throw new Exception("אין רכב כזה");

            return ca.takin;
        }//+
        public bool is_rent_exist(long run_code)
        {
            try
            {
                return Dal.is_rent_exist(run_code);
            }
            catch (Exception e)
            {

                throw e;
            }
        }//+
        public bool can_rent()
        {
            return Dal.return_list(BE.retur.car).Count > ((List<Renting>)(Dal.return_list(BE.retur.renting))).Where(a => !a.ended).Count() ? true : false;
        }//+
        public bool is_fault_code_exist(int fault_coded)
        {
            try
            {
                return Dal.is_fault_code_exist(fault_coded);
            }
            catch (Exception e)
            {

                throw e;
            }
        }//+

        public int get_time_from_last_rent(long id)
        {
            List<Renting> t = (from temp in (List<Renting>)Dal.return_list(BE.retur.renting)
                               where temp.driver.first_id == id
                               select temp).ToList<Renting>();
            if (t.Count == 0)
                return 100;
            t.OrderBy(a => a.end_rent);
            int tew = (DateTime.Now.Year - t[0].end_rent.Year) * 365 + (DateTime.Now.Month - t[0].end_rent.Month) * 30 + (DateTime.Now.Day - t[0].end_rent.Day);
            int dew = (DateTime.Now.Year - t[0].end_rent.Year) * 365 + (DateTime.Now.Month - t[0].end_rent.Month) * 30 + (DateTime.Now.Day - t[0].end_rent.Day);

            return (tew > dew ? dew : tew);
        }//-
        public double car_profits(int id)
        {
            return ((List<Renting>)Dal.return_list(retur.renting)).Where(a => a.number_of_rishui == id && a.ended).Select(m => m.price * 0.38).Sum();
        }//-

        public void update_time_adn_distance(long id)
        {
            Random rand = new Random();
            Client cli = ((List<Client>)Dal.return_list(retur.client)).Where(a => a.Id1 == id).First();
            Renting[] rent = ((List<Renting>)Dal.return_list(retur.renting)).Where(a => a.driver.first_id == id).ToArray();
            car[] cars = (from inter in (List<car>)(Dal.return_list(retur.car))
                          from inter1 in rent
                          where inter.car_number == inter1.number_of_rishui
                          select inter).Distinct().ToArray();
            int momo = 0;
            foreach (var item in rent)
            {
                momo = rand.Next(12);
                if (momo == 6)
                {
                    Fault fail = new Fault((fault_type)rand.Next(14), (who_fault)rand.Next(3),0, rand.Next(100, 1000), "musach");
                    add_Fault(fail);
                    momo = rand.Next(cars.Length);
                    add_Car_fault(cars[momo].car_number, fail.fault_number, DateTime.Now);
                    cars[momo].takin = false;
                }
            }
            foreach (var item in cars)
            {
                update_car(item, update.destance, rand.Next(100));
            }
        }

        public void close_rent(long rent_code)
        {
            if (!Dal.is_rent_exist(rent_code))
                throw new Exception("הקוד השכרה אינו קיים");

            try
            {
                Renting rent = ((List<Renting>)Dal.return_list(retur.renting)).Where(a => a.running_code == rent_code).First();
                Client cli = ((List<Client>)Dal.return_list(retur.client)).Where(a => a.Id1 == rent.driver.first_id).First();
                car ca = ((List<car>)Dal.return_list(retur.car)).Where(a => a.car_number == rent.number_of_rishui).First();
                int[] fau = ((List<Car_Fault>)Dal.return_list(retur.car_fault)).Where(a => a.id == rent.number_of_rishui).Select(te => te.fault_number).ToArray();
                var tem = (from item in (List<Fault>)(Dal.return_list(retur.fault))
                           from item1 in fau
                           where item.fault_number == item1
                           select item).Distinct();
                float temp = 0.0F;
                foreach (var item in tem)
                {
                    temp += item.total_price;
                }
                ca.moosker = false;
                update_time_adn_distance(ca.car_number);
                temp += ca.car_info.Engine_capacety * 0.01F * rent.days;//1אגורות לכל סמק
                temp += ca.car_people_able * 25 * rent.days;
                temp += rent.number_drove * 15 * rent.days;
                temp += 20 * rent.days;
                update_rent(rent_code, update.price, temp);
                update_rent(rent_code, update.destance, ca.total_distance);
                update_rent(rent_code, update.date_end, DateTime.Now);
                update_rent(rent_code, update.ended, true);
                if (cli.isVip)
                {
                    update_rent(rent, update.price_horada_achuz, 18);
                }
                if (!is_clint_young(cli))
                {
                    update_rent(rent, update.price_horada_shqulim, 10 * rent.days);
                }

            }
            catch (Exception e)
            {

                throw e;
            }
        }
        #region
        public void createListOfRent()
        {
            Random rand = new Random();
            car ca = ((List<car>)Dal.return_list(retur.car))[rand.Next(((List<car>)Dal.return_list(retur.car)).Count)];
            Client cl = ((List<Client>)Dal.return_list(retur.client))[rand.Next(((List<Client>)Dal.return_list(retur.client)).Count)];
            string[] name = new string[] { "mosh", "tom", "mair", "shmual" };
            string[] last_name = new string[] { "kroizer", "nachmani", "israly", "choen" };
            Drivers driv;
            driv.first_id = cl.Id1;
            driv.first_name = name[rand.Next(4)] + last_name[rand.Next(4)];
            if (rand.Next(2) == 1)
            {
                cl = ((List<Client>)Dal.return_list(retur.client))[rand.Next(((List<Client>)Dal.return_list(retur.client)).Count)];
                driv.second_id = cl.Id1;
                driv.second_name = name[rand.Next(4)] + last_name[rand.Next(4)];
            }
            else
            {
                driv.second_id = 9999999;
                driv.second_name = "";
            }
            try
            {
                add_rent(new Renting(rand.Next(1, 7), driv, ca, rand.Next(2, 8)));
            }
            catch (Exception)
            {

                throw;
            }

        }
        public void createListOfFault()
        {
            Random rand = new Random();
            string[] name_of_city = new string[2] { "yarushlim", "tal aviv" };
            string[] name_of_street = new string[6] { "yafo", "shamger", "uziel", "bagin", "bugrashov", "kishon" };
            string[] musacim = { "דני אמויאל", "קרסו", "חלקי חילוף", "מוסכי פורד", "דודו גרשון פנצרים", "גולין פנצרים", "פחחות וצבע", "צמפיון מוטורס", "הונדה" };

            addres ad;
            ad.building = rand.Next(1, 97);
            //use of extantion mathode

            ad.city = "".random_from_arry(name_of_city);
            ad.city = "".random_from_arry(name_of_street);
            try
            {
                add_Fault(new Fault((fault_type)rand.Next(15), (who_fault)rand.Next(2), 0, rand.Next(100, 1550), "".random_from_arry(musacim)));
            }
            catch (Exception e)
            {

                throw e;
            }

        }
        public void createListOfCar()
        {
            Random rand = new Random();
            List<car> cars = new List<car>();
            string[] name_of_car = new string[7] { "honda", "toyota", "ford", "pigo", "reno", "mazda", "bmw" };
            string[] model = new string[15] { "acord", "jazz", "lagend", "civic", "carola", "yaris", "focus", "magen", "307", "3", "5", "306", "7", "13", "323" };
            string[] name_of_city = new string[2] { "yarushlim", "tal aviv" };
            string[] name_of_street = new string[6] { "yafo", "shamger", "uziel", "bagin", "bugrashov", "kishon" };
            rishion_rachav rr;
            rr.test = ((DateTime.Now).AddYears(rand.Next(0, 4)).AddMonths(-rand.Next(0, 22)));
            rr.type = (catagory_of_vehicles)(rand.Next(5));
            car_type ct;

            ct.Engine_capacety = rand.Next(900, 5000);
            //use of extantion mathode

            ct.Manufacturer = "".random_from_arry(name_of_car);
            ct.model = "".random_from_arry(model);

            addres ad;

            ad.building = rand.Next(1, 97);
            ad.city = "".random_from_arry(name_of_city);
            ad.street = "".random_from_arry(name_of_street);

            try
            {
                add_car(new car(ct, (gear)rand.Next(0, 2), rand.Next(2, 7), rand.Next(1, 3) * 2, ad, rr, rand.Next(1999, 2015), rand.Next(0, 1500), DateTime.Now));
            }
            catch
            {
                Console.WriteLine("\ncatch\n");
            }
        }
        public void createListOfClient()//catgor,mispar_rishion,tokf
        {
            Random rand = new Random();
            List<Client> clis = new List<Client>();
            string[] name_of_city = new string[3] { "yarushlim", "tal aviv", "haifa" };
            string[] name_of_street = new string[7] { "yafo", "shamger", "uziel", "bagin", "bugrashov", "kishon", "chabd" };
            addres ad;

            ad.building = rand.Next(1, 97);
            ad.city = "".random_from_arry(name_of_city);
            ad.street = "".random_from_arry(name_of_street);

            rishion rr;
            rr.tokf = DateTime.Now.AddYears(rand.Next(4));
            rr.mispar_rishion = rand.Next(1000000, 100000000);
            rr.catgor = (catagory_of_vehicles)rand.Next(5);
            CreditCard cc;
            cc.cvc_number = rand.Next(100, 999);
            cc.exp_date = DateTime.Now.AddYears(rand.Next(4));
            cc.number_c = rand.Next(100000000, 1000000000).ToString();

            try
            {
                Dal.add_client(new Client(ad, DateTime.Now.AddYears(-rand.Next(13, 60)), rr, cc, rand.Next(6), rand.Next(0, 3)));
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion
        #region
        public List<car> return_avilable_cars()
        {
            return (List<car>)((List<car>)Dal.return_list(BE.retur.car)).Where(a => a.takin && !a.moosker);
        }//+
        public List<Renting> iretur(long id)//מחזיר רשימה של של כל ההזמנות של מישהו
        {
            return (List<Renting>)((List<Renting>)Dal.return_list(BE.retur.renting)).Where(a => a.driver.first_id == id);
        }//+
        public fault_type[] fault_list_from_bottom()
        {
            var t = from item in (List<Car_Fault>)Dal.return_list(BE.retur.car_fault)
                    select item.fault_number;
            BE.kamut_fault[] mispar = new kamut_fault[15];
            for (int i = 0; i < 15; i++)
			{
                mispar[i].a = (fault_type)i;
			}
            foreach (var item in t)
            {
                fault_type a = ((List<Fault>)Dal.return_list(BE.retur.fault)).Where(temp => temp.fault_number == item).Select(tem => tem.Ft).First();
                switch (a)
                {
                    case fault_type.pancher:
                        mispar[0].kamut++;
                        break;
                    case fault_type.blamim:
                        mispar[1].kamut++;
                        break;
                    case fault_type.pch:
                        mispar[2].kamut++;
                        break;
                    case fault_type.tzeva:
                        mispar[3].kamut++;
                        break;
                    case fault_type.tipulTen:
                        mispar[4].kamut++;
                        break;
                    case fault_type.chasmal:
                        mispar[5].kamut++;
                        break;
                    case fault_type.mnoah:
                        mispar[6].kamut++;
                        break;
                    case fault_type.plastica:
                        mispar[7].kamut++;
                        break;
                    case fault_type.betichut:
                        mispar[8].kamut++;
                        break;
                    case fault_type.light:
                        mispar[9].kamut++;
                        break;
                    case fault_type.mazgan:
                        mispar[10].kamut++;
                        break;
                    case fault_type.radio:
                        mispar[11].kamut++;
                        break;
                    case fault_type.marout:
                        mispar[12].kamut++;
                        break;
                    case fault_type.magavim:
                        mispar[13].kamut++;
                        break;
                    case fault_type.gir:
                        mispar[14].kamut++;
                        break;
                }
            }
            return (mispar.OrderBy(ti => ti.kamut).Select(m => m.a)).ToArray<fault_type>();
        }//+
        public List<Client> predicate_clients(Predicate<Renting> pred)
        {
            var temp = from item in ((List<Renting>)Dal.return_list(BE.retur.renting))
                       where pred(item)
                       select new { dri1 = item.driver.first_id, dri2 = item.driver.second_id };

            var tem= (List<Client>) (from item in temp
                                    from iem1 in (List<Client>)Dal.return_list(retur.client)
                                    where item.dri1 == iem1.Id1 || item.dri2 == iem1.Id1
                                    select iem1).Distinct();
            return tem;
        }//+

        public IList return_list(retur t)
        {
            try
            {
                return Dal.return_list(t);
            }
            catch (Exception e)
            {

                throw e;
            }
        }//+
        #endregion

        public List<BE.Client> select_client(catagory_of_vehicles cat)
        {

            List<Client> temp = (from item in ((List<Client>)Dal.return_list(BE.retur.client))
                                 where ((item.rishoi.catgor >= cat) && (item.Age >= 18))//בודקת את התנאי של הפונקצייה
                                 select item).ToList();

            if (temp == null)
                throw new Exception("אין לקוחות זמינים");

            return temp;
        }
        public List<BE.car> sinun_car(BE.gear gi, BE.catagory_of_vehicles cat, int mak, int dor) //מחזירה רשימה של מכוניות נבחרות בהזמנה 
        {
            List<car> ca = ((from item in (List<car>)Dal.return_list(BE.retur.car)
                             where !item.moosker && (item.car_gear == gi) && (item.rishion.type == cat) &&
                             item.takin && (item.number_of_car_doors == dor) && (item.car_people_able == mak)
                             select item).ToList<car>());
            if (ca == null)
                throw new Exception("אין מכוניות זמינות");
            return ca;
        }

        #endregion



        public IEnumerable return_car_by_typr(string by_w)
        {
            switch (by_w)
            {
                case "cat":
                     return (from item in (List<car>)return_list(retur.car)
                             orderby (int)item.rishion.type
                   group item by item.rishion.type into g
                   select g);
                case "model":
                     return from item in (List<car>)return_list(retur.car)
                            orderby (item.car_info.model[0])
                            group item by item.car_info.model into g
                            select g;
                case "manu":
                     return from item in (List<car>)return_list(retur.car)
                            orderby (item.car_info.Manufacturer[0])
                            group item by item.car_info.Manufacturer into g
                            select g;
                default:
                    throw new Exception("");
            }
           
        }


       
    }
}
