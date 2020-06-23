using BL_WcfService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ref_factory
{
    public class Class1
    {
        public IBL GetBL()
        {
            return BL_imp.Instance;
        }
    }
}
