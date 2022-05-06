using System;

namespace RoutePlan.Domain.ViewModel
{
    public class RoutePlanViewModel
    {
        public int id { get; set; }
        public DateTime date_created { get; set; }
        public string origin { get; set; }
        public string destiny { get; set; }
        public decimal price { get; set; }
        
    }
}