using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL;
using BLFactory;
using BE;

namespace ConsoleApplication1
{//המון השקעה נכנסה לפרויקט עד עתה אני מקווה שאתה תיראה את מרחב הפונקציות ואת מימושן מימשתי בקנסול זה רק הדגמה של כל מיני פונקציות 
    class pl
    {
        static void Main(string[] args)
        {
            IBL bl = (new BlFactory()).GetBL();
            int b = 0;
            bool a = true;
            
            while (a)
            {
                Console.WriteLine("enter 1 to create a new client\nenter 2 to create a new car\nenter 3 to create a new fault\nenter 4 to create a new rent contract\nenter 5 to print your cliants\nenter 6 to print your cars\nenter 7 to print your faults\nenter 8 to print your contracts\nenter 9 to update stuf\nenter 10 to exit ");
                try
                {
                    b = int.Parse(Console.ReadLine());
                }
                 catch
                {
                    Console.WriteLine("enter a new number");
                }
                switch (b)
                {
                    case 1:
                        try
                        {
                            bl.createListOfClient();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case 2:
                        try
                        {
                            bl.createListOfCar();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case 3:
                        try
                        {
                            bl.createListOfFault();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case 4:
                        try
                        {
                            bl.createListOfRent();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case 5:
                        foreach (Client item in bl.return_list(retur.client))
                        {
                            
                            Console.WriteLine(item.ToString());
                        }
                        break;
                    case 6:
                        foreach (var item in (List<car>)bl.return_list(retur.car))
                        {
                            Console.WriteLine(item.ToString());
                        }
                        break;
                    case 7:
                        foreach (var item in (List<Fault>)bl.return_list(retur.fault))
                        {
                            Console.WriteLine(item.ToString());
                        }
                        break;
                    case 8:
                        foreach (var item in (List<Renting>)bl.return_list(retur.renting))
                        {
                            Console.WriteLine(item.ToString());
                        }
                        break;
                    case 9:
                        foreach (Client item in bl.return_list(retur.client))
                        {
                            bl.update_time_adn_distance(item.Id1);
                        }
                        break;
                    case 10:
                        a = false;
                        break;
                }
            }




           
        }
    }
}
