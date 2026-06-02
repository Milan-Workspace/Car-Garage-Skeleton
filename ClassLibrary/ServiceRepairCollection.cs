using System.Data;

namespace ClassLibrary
{
    public class ServiceRepairCollection
    {
        private ServiceRepair mThisService = new ServiceRepair();

        public ServiceRepair ThisService
        {
            get { return mThisService; }
            set { mThisService = value; }
        }

        public int Add()
        {
            ServiceRepairDB db = new ServiceRepairDB();
            return db.AddServiceRecord(mThisService);
        }

        public void Update()
        {
            ServiceRepairDB db = new ServiceRepairDB();
            db.UpdateServiceRecord(mThisService);
        }

        public void Delete()
        {
            ServiceRepairDB db = new ServiceRepairDB();
            db.DeleteServiceRecord(mThisService.ServiceID);
        }

        public DataTable StatisticsByStatus()
        {
            ServiceRepairDB db = new ServiceRepairDB();
            return db.StatisticsByStatus();
        }

        public DataTable StatisticsByDate()
        {
            ServiceRepairDB db = new ServiceRepairDB();
            return db.StatisticsByDate();
        }
    }
}