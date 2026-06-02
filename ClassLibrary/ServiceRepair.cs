using System;

namespace ClassLibrary
{
    public class ServiceRepair
    {
        private int mServiceID;
        private int mVehicleID;
        private int? mPartID;
        private DateTime mServiceDate;
        private string mDescription;
        private string mLaborName;
        private string mStatus;

        public int ServiceID
        {
            get { return mServiceID; }
            set { mServiceID = value; }
        }

        public int VehicleID
        {
            get { return mVehicleID; }
            set { mVehicleID = value; }
        }

        public int? PartID
        {
            get { return mPartID; }
            set { mPartID = value; }
        }

        public DateTime ServiceDate
        {
            get { return mServiceDate; }
            set { mServiceDate = value; }
        }

        public string Description
        {
            get { return mDescription; }
            set { mDescription = value; }
        }

        public string LaborName
        {
            get { return mLaborName; }
            set { mLaborName = value; }
        }

        public string Status
        {
            get { return mStatus; }
            set { mStatus = value; }
        }

        public bool Find(int serviceID)
        {
            if (serviceID == 1)
            {
                mServiceID = 1;
                mVehicleID = 1;
                mPartID = null;
                mServiceDate = Convert.ToDateTime("05/05/2026");
                mDescription = "Brake Repair";
                mLaborName = "Hamza";
                mStatus = "Pending";

                return true;
            }

            return false;
        }

        public string Valid(string vehicleID, string partID, string serviceDate, string description, string laborName, string status)
        {
            string Error = "";
            DateTime DateTemp;
            int VehicleTemp;
            int PartTemp;

            if (vehicleID.Length == 0)
            {
                Error = Error + "Vehicle must be selected : ";
            }

            if (!int.TryParse(vehicleID, out VehicleTemp))
            {
                Error = Error + "Vehicle ID must be numeric : ";
            }

            if (partID.Length > 0)
            {
                if (!int.TryParse(partID, out PartTemp))
                {
                    Error = Error + "Part ID must be numeric : ";
                }
            }

            try
            {
                DateTemp = Convert.ToDateTime(serviceDate);

                if (DateTemp > DateTime.Now.Date)
                {
                    Error = Error + "Service date cannot be in the future : ";
                }
            }
            catch
            {
                Error = Error + "Service date is not valid : ";
            }

            if (description.Length == 0)
            {
                Error = Error + "Description may not be blank : ";
            }

            if (description.Length > 255)
            {
                Error = Error + "Description must be less than 255 characters : ";
            }

            if (laborName.Length == 0)
            {
                Error = Error + "Labor name may not be blank : ";
            }

            if (laborName.Length > 50)
            {
                Error = Error + "Labor name must be less than 50 characters : ";
            }

            if (status != "Pending" && status != "In Progress" && status != "Completed")
            {
                Error = Error + "Status must be Pending, In Progress or Completed : ";
            }

            return Error;
        }
    }
}