using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace fusers
{
    public class PurchaseHandler
    {

        public static bool PurchaseItem(int coreCount, int coreCost)
        {
            return coreCount >= coreCost;
        }
    }


}
