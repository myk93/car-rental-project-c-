using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
namespace ClassLibrary1
{
    public interface Idal
    {
     
        void add_client(Client cli);//הוספת לקוח
        
      //  void del_client(int id);
        void del_client(Client cli);// מחיקת לקוח
       	     
      //  void update_client(int id,update t,object obj);
        void update_client(Client cli, update t, object obj);//עדכון לקוח
        
        void add_car(car ca); //הוספת מכונית
        void del_car(car ca);//מחיקת רכב
        
        /// <summary>
        /// עדכון רכב
        /// </summary>
        /// <param name="car_id"></param>
        /// <param name="snif_name"></param>
        void update_car(car ca, update t, object obj);
        /// <summary>
        /// מחלקת הזמנה 
        /// </summary>
        /// <param name="car_id"></param>
        /// <param name="snif_name"></param>
      
        void add_rent(Renting rent);//הוספת הזמנה
         
        void del_rent(Renting rent);//מחיקת הזמנה 
         
        void update_rent(Renting m, update t, object obj);//עדכון הזמנה
        
        void add_Fault(Fault fail);//הוספת תקלה
        
        void del_Fault(Fault fail);//מחיקת תקלה
        
        void update_Fault(Fault Fault_number, update t, object obj);//עדכון תקלה

        void add_Car_fault(Car_Fault cf);//הוספת תקלה לרכב
        void Del_car_fault(Car_Fault temp);//מחיקת תקלה תרכב
        void Del_all_car_fault(int a);//מחיקת כל התקלות רכבים
        /// <summary>
        /// הפונקצי מקבלת אנום מסוג 
        /// retur
        /// </summary>
        /// <param name="t"></param>
        /// <returns>
        ///  הפונקציה מחזירה את הרשימה לפי מה שנשלח
        /// </returns>
        IList return_list(retur t);//מחזירה את כל הרשימות
        
        //פונקציות חדשות
        /// <summary>
        /// הפונקציה הזאת עושה החלפה בין הזמנה שלא נסגרה להזמנה שנסגרה
        /// </summary>
        /// <param name="rent"></param>
        void close_rent(Renting rent);

        bool is_client_exist(long id);//בודקת האם הלקוח קיים
        bool is_car_exist(int license_number);//בודקת האם הרכב קיים
        bool is_rent_exist(long run_code);//בודקת האם ההזמנה קיים
        bool is_fault_code_exist(int fault_coded);//בודקת האם בתקלה_מכונית קיים
        bool is_car_fault_conection(int license_number);//האם קיים קשר בין תקלה לרכב
        bool is_car_fault_conection(int license_number, int fault_number);//האם קיים קשר בין תקלה לרכב

        /// <summary>
        /// הפונקציה מוחקת את כל השגיאות 
        /// </summary>
        /// <param name="p"></param>
        void Del_car_fault(int p);
      /// <summary>
      /// פונקציות אתחול אוטומטיות של:
      /// לקוח רכב 
      /// תקלה
      /// </summary>
      /// <returns></returns>
        long create_new_id();
         int create_new_license_number();
         long create_new_run_code();
         int create_new_fault_code();
    }
}
/*
*/