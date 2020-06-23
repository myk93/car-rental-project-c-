using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace factory
{
    public class FactoryDAL
    {
        public Idal getDAL()
        {
            return DAL_xml.Instance;
           // return Dal_imp.Instance;

        }
          
    }

}