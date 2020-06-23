using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DS
{
    public class DataSource
    {
        readonly public static List<car> car_list = new List<car>();
        readonly public static List<Renting> Renting_list = new List<Renting>();
        readonly public static List<Car_Fault> Car_Fault_list = new List<Car_Fault>();
        readonly public static List<Client> Client_list = new List<Client>();
        readonly public static List<Fault> Fault_list = new List<Fault>();
    }
}
