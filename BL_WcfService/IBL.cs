using BE;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace BL_WcfService
{
   // public delegate bool rent_to_bool (Renting rent);
     [ServiceContract(Name = "BlServiceContract")] 
    public interface IBL
    {
         [OperationContract]  
         void add_client(Client cli);//הוספת לקוח על ידי השרת
         [OperationContract]
         void del_client(long id);//מחיקה לקוח על ידי השרת
       //  [OperationContract]  
        void del_client(Client cli);
        // [OperationContract]  
        void update_client(long id,update t,object obj);
         //   [OperationContract]  
        void update_client(Client cli, update t, object obj);//עדכון לקוח על ידי השרת
         [OperationContract]
        void add_car(car ca);//הוספת רכב על ידי השרת
         [OperationContract]
         void del_car(int car_number);//מחיקת רכב על ידי השרת
       //  [OperationContract]  
        void del_car(car ca);
        /// <summary>
        /// changeing the name of the snif
        /// </summary>
        /// <param name="car_id"></param>
        /// <param name="snif_name"></param>
        // [OperationContract]  
        void update_car(int car_id,update t,object obj);
         //  [OperationContract]  
        void update_car(car ca, update t, object obj);
        /// <summary>
        /// to update the address of the car snif
        /// </summary>
        /// <param name="car_id"></param>
        /// <param name="snif_name"></param>
         [OperationContract]
        void add_rent(Renting rent);//הוספת הזמנה על ידי השרת

      //   [OperationContract]  
         void del_rent(Renting rent);//מחיקת הזמנה על ידי השרת
         [OperationContract]  
        void del_rent(long rent_code);
        // [OperationContract]  
        void update_rent(Renting m, update t, object obj);
       //  [OperationContract]  
        void update_rent(long run_code, update t, object obj);
         [OperationContract]  
        void add_Fault(Fault fail);
         //[OperationContract]  
         void del_Fault(Fault fail);//הוספת תקלה על ידי השרת
         [OperationContract]
         void del_Fault(int Fault_number);//תקלה תקלה על ידי השרת
         //[OperationContract]  
        void update_Fault(Fault Fault_number, update t, object obj);
       //  [OperationContract]  
        void update_Fault(int Fault_number, update t, object obj);
         //[OperationContract]  
        void add_Car_fault(int car_id, int fault_id);
         //[OperationContract]  
        void add_Car_fault(int car_id, int fault_id, DateTime dt);//הוספת תקלה_מכונית על ידי השרת
         [OperationContract]
        void add_Car_fault(Car_Fault cf);//הוספת תקלה_מכונית על ידי השרת
         [OperationContract]
         void Del_car_fault(int a, int fault_id);//מחיקת תקלה_מכונית על ידי השרת
         [OperationContract]
         void Del_all_car_fault(int a);//מחיקת כל תקלה_מכונית על ידי השרת
        // [OperationContract]  
        IList return_list(retur t);
        //פונקציות חדשות
         [OperationContract]  
        bool is_clint_young(Client cli);//בודקת האם הנהג צעיר
         [OperationContract]  
        void close_rent(long rent_code);//סגירת הזמנה
        //פונקציות bl
         [OperationContract]  
        List<Renting> iretur(long id);//פונקציית החזרת  
         [OperationContract]  
        float sum_rents(int id, DateTime start, DateTime end);//פונקציית חישוב 
         [OperationContract]  
        double car_profits(int id);//מחשבתת ברווח של המכונית
         [OperationContract]  
        fault_type[] fault_list_from_bottom();//
        // [OperationContract]  
        List<Client> predicate_clients(Predicate<Renting> pred);//מחזיר רשימה של לקוחות שמתאימים לפרדיקט
         [OperationContract]  
        bool is_problem(int id);//נדיקה האם קיימת תקלה
         [OperationContract]  
        float total_price(long rent_numb);//תשלום סופי
         [OperationContract]  
        //פונקציות אחרות
        bool is_client_exist(long id);//בדיקה האם הלקוח קיים
         [OperationContract]
         bool is_car_exist(int license_number);//בדיקה האם הרכב קיים
         [OperationContract]
         bool is_rent_exist(long run_code);//בדיקה האם ההזמנה קיים
         [OperationContract]
         bool is_fault_code_exist(int fault_coded);//בדיקה האם תקלה קיים
         [OperationContract]  
     
        int get_time_from_last_rent(long id);//מחזירה את הגיל 
         [OperationContract]  
        bool can_rent();
         [OperationContract]  
        List<car> return_avilable_cars();  //החזרה של הרכבים שלא מושכרים\
         [OperationContract]  
        void createListOfCar();//ייצור אוטומט
         [OperationContract]  
        void update_time_adn_distance(long id);//עדכון זמן ומרחק
         [OperationContract]  
        void createListOfRent();//
         [OperationContract]  
        void createListOfClient();
         [OperationContract]  
        void createListOfFault();
         [OperationContract]  
        List<BE.Client> select_client(BE.catagory_of_vehicles cat);//מסננת את הלקוחות המתאימים
         [OperationContract]  
        List<BE.car> sinun_car(BE.gear gi, BE.catagory_of_vehicles cat, int mak, int dor);//מסננת את המכוניות 

    }
}
