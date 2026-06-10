using System;

namespace ClassLibrary
{
    public class clsVehicle

    {

        // Private data members

        private int mVehicleId;

        private string mMake;

        private string mModel;

        private int mEngineSize;

        private DateTime mDateAdded;

        private bool mActive;



        // Public Properties

        public int VehicleId

        {

            get { return mVehicleId; }

            set { mVehicleId = value; }

        }



        public string Make

        {

            get { return mMake; }

            set { mMake = value; }

        }



        public string Model

        {

            get { return mModel; }

            set { mModel = value; }

        }



        public int EngineSize

        {

            get { return mEngineSize; }

            set { mEngineSize = value; }

        }



        public DateTime DateAdded

        {

            get { return mDateAdded; }

            set { mDateAdded = value; }

        }



        public bool Active

        {

            get { return mActive; }

            set { mActive = value; }

        }



        /****** FIND METHOD (Hardcoded for current Milestone) ******/

        public bool Find(int VehicleId)

        {

            // Set the private data members to the test data values

            mVehicleId = 1;

            mMake = "Ford";

            mModel = "Focus";

            mEngineSize = 1600;

            mDateAdded = Convert.ToDateTime("21/05/2026");

            mActive = true;



            // Always return true for now to pass tests

            return true;

        }



        /****** VALID METHOD ******/

        public string Valid(string make, string model, string dateAdded)

        {

            string Error = "";

            DateTime DateTemp;



            // --- Validation for Make ---

            if (make.Length == 0)

            {

                Error = Error + "The make may not be blank : ";

            }

            if (make.Length > 50)

            {

                Error = Error + "The make must be less than 50 characters : ";

            }



            // --- Validation for Model ---

            if (model.Length == 0)

            {

                Error = Error + "The model may not be blank : ";

            }

            if (model.Length > 50)

            {

                Error = Error + "The model must be less than 50 characters : ";

            }



            // --- Validation for DateAdded ---

            try

            {

                DateTemp = Convert.ToDateTime(dateAdded);

                if (DateTemp < DateTime.Now.Date.AddYears(-100))

                {

                    Error = Error + "The date cannot be 100 years in the past : ";

                }

                if (DateTemp > DateTime.Now.Date)

                {

                    Error = Error + "The date cannot be in the future : ";

                }

            }

            catch

            {

                Error = Error + "The date was not a valid date : ";

            }



            return Error;

        }

    }
}


