using BL_WcfService.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL_WcfService
{
    public class BLClientAdapter: IBL   
    {
        BlServiceContractClient bl;
        BL.IBL bll;
        public BLClientAdapter()
        {
            bl = new BlServiceContractClient();
           bll = new BLFactory.BlFactory().GetBL();
        }
        public void add_client(BE.Client cli)
        {
            bl.add_client(cli);
        }

        public void del_client(long id)
        {
            bl.del_client(id);
        }

        public void del_client(BE.Client cli)
        {
            bl.del_client(cli.Id1);
        }

        public void update_client(long id, BE.update t, object obj)
        {
            bll.update_client(id, t, obj);
           // throw new Exception("לא ניתן למימוש בשרת בגלל object");
        }

        public void update_client(BE.Client cli, BE.update t, object obj)
        {
            bll.update_client(cli, t, obj);
           // throw new Exception("לא ניתן למימוש בשרת בגלל object");

        }

        public void add_car(BE.car ca)
        {
            bl.add_car(ca);
        }

        public void del_car(int car_number)
        {
            bl.del_car(car_number);
        }

        public void del_car(BE.car ca)
        {
            bl.del_car(ca.car_number);
        }

        public void update_car(int car_id, BE.update t, object obj)
        {
            bll.update_car(car_id, t, obj);
           // throw new Exception("לא ניתן למימוש בשרת בגלל object");
        }

        public void update_car(BE.car ca, BE.update t, object obj)
        {
            bll.update_car(ca.car_number, t, obj);
          //  throw new Exception("לא ניתן למימוש בשרת בגלל object");
        }

        public void add_rent(BE.Renting rent)
        {
            bl.add_rent(rent);
        }

        public void del_rent(BE.Renting rent)
        {
            bl.del_rent(rent.running_code);
        }

        public void del_rent(long rent_code)
        {
            bl.del_rent(rent_code);
        }

        public void update_rent(BE.Renting m, BE.update t, object obj)
        {
            bll.update_rent(m, t, obj);
        }

        public void update_rent(long run_code, BE.update t, object obj)
        {
            bll.update_rent(run_code, t, obj);
        }

        public void add_Fault(BE.Fault fail)
        {
            bl.add_Fault(fail);
        }

        public void del_Fault(BE.Fault fail)
        {
            bl.del_Fault(fail.fault_number);       
        }

        public void del_Fault(int Fault_number)
        {
            bl.del_Fault(Fault_number);
        }

        public void update_Fault(BE.Fault Fault_number, BE.update t, object obj)
        {
            bll.update_Fault(Fault_number, t, obj);
        }

        public void update_Fault(int Fault_number, BE.update t, object obj)
        {
            bll.update_Fault(Fault_number, t, obj);            
        }

        public void add_Car_fault(int car_id, int fault_id)
        {
            bll.add_Car_fault(car_id, fault_id);
            
        }

        public void add_Car_fault(int car_id, int fault_id, DateTime dt)
        {
            bll.add_Car_fault(car_id, fault_id,dt);

        }

        public void add_Car_fault(BE.Car_Fault cf)
        {
            bll.add_Car_fault(cf);
             
        }

        public void Del_car_fault(int a, int fault_id)
        {
            bll.Del_car_fault(a, fault_id);
           
        }

        public void Del_all_car_fault(int a)
        {
            bl.Del_all_car_fault(a);
        }

        public System.Collections.IList return_list(BE.retur t)
        {
            return bll.return_list(t);
        }

        public bool is_clint_young(BE.Client cli)
        {
            return bl.is_clint_young(cli);
        }

        public void close_rent(long rent_code)
        {
            bl.close_rent(rent_code);
        }

        public List<BE.Renting> iretur(long id)
        {
           return bl.iretur(id);
        }

        public float sum_rents(int id, DateTime start, DateTime end)
        {
            return bl.sum_rents(id, start, end);
        }

        public double car_profits(int id)
        {
            return bl.car_profits(id);
        }

        public BE.fault_type[] fault_list_from_bottom()
        {
            return (BE.fault_type[]) bl.fault_list_from_bottom().AsEnumerable();
        }

        public List<BE.Client> predicate_clients(Predicate<BE.Renting> pred)
        {
            return bll.predicate_clients(pred);
        }

        public bool is_problem(int id)
        {
            return bl.is_problem(id);
        }

        public float total_price(long rent_numb)
        {
            return bl.total_price(rent_numb);
        }

        public bool is_client_exist(long id)
        {
            return bl.is_client_exist(id);
        }

        public bool is_car_exist(int license_number)
        {
            return bl.is_car_exist(license_number);
        }

        public bool is_rent_exist(long run_code)
        {
            return bl.is_rent_exist(run_code);
        }

        public bool is_fault_code_exist(int fault_coded)
        {
            return bl.is_fault_code_exist(fault_coded);
        }

        public int get_time_from_last_rent(long id)
        {
            return bl.get_time_from_last_rent(id);
        }

        public bool can_rent()
        {
            return bl.can_rent();
        }

        public List<BE.car> return_avilable_cars()
        {
            return bl.return_avilable_cars();
        }

        public void createListOfCar()
        {
            bl.createListOfCar();
        }

        public void update_time_adn_distance(long id)
        {
            bl.update_time_adn_distance(id);
        }

        public void createListOfRent()
        {
            bl.createListOfRent();
        }

        public void createListOfClient()
        {
            bl.createListOfClient();
        }

        public void createListOfFault()
        {
            bl.createListOfFault();
        }

        public List<BE.Client> select_client(BE.catagory_of_vehicles cat)
        {
            return bl.select_client(cat);
        }

        public List<BE.car> sinun_car(BE.gear gi, BE.catagory_of_vehicles cat, int mak, int dor)
        {
            return bl.sinun_car(gi, cat, mak, dor);
        }
    }
}
