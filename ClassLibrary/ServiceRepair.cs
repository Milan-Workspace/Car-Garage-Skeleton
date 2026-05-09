using System;

namespace ClassLibrary
{
    public class ServiceRepair
    {
        public int ServiceID { get; set; }
        public int VehicleID { get; set; }
        public int? PartID { get; set; }
        public DateTime ServiceDate { get; set; }
        public string Description { get; set; }
        public string LaborName { get; set; }
        public string Status { get; set; }
    }
}