using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL;
namespace BLFactory
{
     public class BlFactory
    {
        public IBL GetBL ()
        {
            return BL_imp.Instance;
        }
    }
}
