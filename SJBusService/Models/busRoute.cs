//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SJBusService.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class busRoute
    {
        public busRoute()
        {
            this.routeSchedules = new HashSet<routeSchedule>();
            this.routeStops = new HashSet<routeStop>();
        }
    
        public string busRouteCode { get; set; }
        public string routeName { get; set; }
    
        public virtual ICollection<routeSchedule> routeSchedules { get; set; }
        public virtual ICollection<routeStop> routeStops { get; set; }
    }
}