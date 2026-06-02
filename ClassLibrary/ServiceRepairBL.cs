using System.Data;

namespace ClassLibrary
{
    public class ServiceRepairBL
    {
        ServiceRepairDB db = new ServiceRepairDB();

        public int AddService(ServiceRepair sr)
        {
            return db.AddServiceRecord(sr);
        }

        public void UpdateService(ServiceRepair sr)
        {
            db.UpdateServiceRecord(sr);
        }

        public void DeleteService(int serviceID)
        {
            db.DeleteServiceRecord(serviceID);
        }

        public DataTable GetVehicles()
        {
            return db.GetVehicles();
        }

        public DataTable GetParts()
        {
            return db.GetParts();
        }

        public DataTable GetAllServiceRecords()
        {
            return db.GetAllServiceRecords();
        }

        public DataTable FilterByStatus(string status)
        {
            return db.FilterByStatus(status);
        }

        public DataTable StatisticsByStatus()
        {
            return db.StatisticsByStatus();
        }

        public DataTable StatisticsByDate()
        {
            return db.StatisticsByDate();
        }
    }
}