using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Theke.Models.ViewModels
{
    public class BarTableViewModel
    {
        public int BarTableID { get; set; }
        public Nullable<int> SeatAmount { get; set; }
        public string TableName { get; set; }
        public int hasOpenPaymentStatus { get; set; }

    }
}