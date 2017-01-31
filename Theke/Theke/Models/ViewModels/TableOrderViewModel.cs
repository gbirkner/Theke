using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Theke.Models.ViewModels
{
    public class TableOrderViewModel
    {


        public List<BarTable> bartablelist { get; set; }
        public List<BarOrder> barorderlist { get; set; }

        public TableOrderViewModel (List<BarTable> bartablelist, List<BarOrder> bartorderlist)
        {
            this.bartablelist = bartablelist;
            this.barorderlist = bartorderlist;
        }
    }
}