using System.Data;

namespace ClassLibrary
{
    public class ServiceRepairBL
    {
        ServiceRepairDB db = new ServiceRepairDB();

        // INSERT
        public void AddService(ServiceRepair sr)
        {
            db.InsertServiceRecord(sr);
        }

        // GET VEHICLES (for dropdown)
        public DataTable GetVehicles()
        {
            return db.GetVehicles();
        }

        // GET PARTS (for dropdown)
        public DataTable GetParts()
        {
            return db.GetParts();
        }
    }
}