using BE;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace BL
{
   // public delegate bool rent_to_bool (Renting rent);

    public interface IBL
    {
        void add_client(Client cli);//הוספת לקוח על ידי לקוח
        void del_client(long id);//מחיקה לקוח על ידי ת.ז
        void del_client(Client cli);//מחיקה לקוח על ידי לרוח
        void update_client(long id, update t, object obj);//עדכון לקוח על ידי השרת
        void update_client(Client cli, update t, object obj);//עדכון לקוח על ידי השרת
        void add_car(car ca); //הוספת רכב על ידי רכב
        void del_car(int car_number);//מחיקת רכב על ידי רישוי
        void del_car(car ca);//מחיקת רכב על ידי רכב
        /// <summary>
        /// changeing the name of the snif
        /// </summary>
        /// <param name="car_id"></param>
        /// <param name="snif_name"></param>
        void update_car(int car_id, update t, object obj);//עדכון רכב על ידי 
        void update_car(car ca, update t, object obj);//עדכון רכב על ידי 
        /// <summary>
        /// to update the address of the car snif
        /// </summary>
        /// <param name="car_id"></param>
        /// <param name="snif_name"></param>
        void add_rent(Renting rent);//הוספת הזמנה  
        void del_rent(Renting rent);//מחיקת הזמנה  
        void del_rent(long rent_code);//מחיקת הזמנה  
        void update_rent(Renting m, update t, object obj);//עדכון הזמנה
        void update_rent(long run_code, update t, object obj);//עדכון הזמנה
        void add_Fault(Fault fail);//הוספת תקלה
        void del_Fault(Fault fail);//מחיקת תקלה
        void del_Fault(int Fault_number);//מחיקת תקלה
        void update_Fault(Fault Fault_number, update t, object obj);//עדכון תקלה
        void update_Fault(int Fault_number, update t, object obj);//עדכון תקלה
        void add_Car_fault(int car_id, int fault_id);//הוספת תקלה_מכונית
        void add_Car_fault(int car_id, int fault_id, DateTime dt);//הוספת תקלה_מכונית
        void add_Car_fault(Car_Fault cf);//הוספת תקלה_מכונית
        void Del_car_fault(int a, int fault_id);//מחיקת תקלה_מכונית
        void Del_all_car_fault(int a);//מחיקת כל תקלה_מכונית
        IList return_list(retur t);
        //פונקציות חדשות
        bool is_clint_young(Client cli);////בודקת האם הנהג צעיר
        void close_rent(long rent_code);//סגירת הזמנה
        //פונקציות bl
        List<Renting> iretur(long id);//פונקציית החזרת
        float sum_rents(int id, DateTime start, DateTime end);//פונקציית חישוב
        double car_profits(int id);//מחשבתת ברווח של המכונית
        fault_type[] fault_list_from_bottom();
        List<Client> predicate_clients(Predicate<Renting> pred);//מחזיר רשימה של לקוחות שמתאימים לפרדיקט
        bool is_problem(int id);//נדיקה האם קיימת תקלה
        float total_price(long rent_numb);//תשלום סופי
        //פונקציות אחרות
        bool is_client_exist(long id);//בדיקה האם הלקוח קיים
        bool is_car_exist(int license_number);//בדיקה האם הרכב קיים
        bool is_rent_exist(long run_code);//בדיקה האם ההזמנה קיים
        bool is_fault_code_exist(int fault_coded);//בדיקה האם תקלה קיים
     
        /// <summary>
        /// פונקצייה בודקת את הגיל
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int get_time_from_last_rent(long id);
     /// <summary>
     /// פונקצייה בודקת את הרכבים שניתן להשכיר
     /// </summary>
     /// <returns></returns>
        bool can_rent();
     /// <summary>
     /// כל הרכבים הפנויים
     /// </summary>
     /// <returns></returns>
        List<car> return_avilable_cars();  //החזרה של הרכבים שלא מושכרים\
    /// <summary>
    /// יוצר רכב
    /// </summary>
        void createListOfCar();
      /// <summary>
      /// עדכון גיל ובודקת האם ההזמנה הסתיימה
      /// </summary>
      /// <param name="id"></param>
        void update_time_adn_distance(long id);
      /// <summary>
      /// ייצור הזמנה
      /// </summary>
        void createListOfRent();
     /// <summary>
     /// ייצור לקוח
     /// </summary>
        void createListOfClient();
      /// <summary>
      /// ייצור תקלה
      /// </summary>
        void createListOfFault();
      /// <summary>
      /// מסננת את הלקוחות שמתאימים לרכב
      /// </summary>
      /// <param name="cat"></param>
      /// <returns></returns>

        List<BE.Client> select_client(BE.catagory_of_vehicles cat);
       /// <summary>
        /// מסננת את הלקוחות שמתאימים לצרכן
       /// </summary>
       /// <param name="gi"></param>
       /// <returns></returns>
        List<BE.car> sinun_car(BE.gear gi, BE.catagory_of_vehicles cat, int mak, int dor);
        IEnumerable return_car_by_typr(string by_w);

    }
    /// <summary>
    /// פונקצייה שהוספנו למחלקה סטרינג 
    /// בחירה רנדומלית מתוך מערך איבר 
    /// </summary>
    /// 
    public static class MyExtensions
    {
        public static string random_from_arry(this string str, string[] st)
        {
            Random r = new Random();
            return (str = st[r.Next(0, st.Length)]);
        }
        public static string random_from_arry(this string str, string[] st1, string[] st2)
        {
            Random r = new Random();
            return (str = st1[r.Next(0, st1.Length)] + st2[r.Next(0, st2.Length)]);
        }
    }
}
