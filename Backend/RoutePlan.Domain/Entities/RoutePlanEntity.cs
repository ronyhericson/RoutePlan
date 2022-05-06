using System;

namespace RoutePlan.Domain.Entities
{
    public class RoutePlanEntity
    {
        public int id { get; set; }
        public DateTime date_created { get; set; }
        public string origin { get; set; }
        public string destiny { get; set; }
        public decimal price { get; set; }
        
    }
}