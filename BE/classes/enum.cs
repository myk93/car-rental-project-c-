using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public enum fault_type
    {
        pancher=130, blamim=134, pch=500, tzeva=350, tipulTen=1000, chasmal=221, mnoah=881, plastica=180, betichut=85, light=220, mazgan=330, radio=425,
        marout=95, magavim=33, gir=550
    }
    public enum who_fault 
    {
        Negligence, blay
    }
    public enum gear
    {
        automety ,yadni
    }
    public enum catagory_of_vehicles
    {
        A,
        B,
        C,
        D,
        E
    }
    public enum update
    {  
        number_of_pass,mirchk,address,cradit_card,price,pirut_htakla,gorm_htakla,musch,mosif_n,morid_n,
        mispar_yamim, ids, age, price_horada_shqulim, price_horada_achuz,rishion_nahg,rishion_rachav,panuy,vatek,takin,vip,chazra,ended,defect,destance,date_end,date_test
    }
    public enum retur
    {
        car, fault, renting, client, car_fault
    }
    
}
