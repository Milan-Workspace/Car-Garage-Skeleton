using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ClassLibrary
{
    public class ServiceRepairDB
    {
        private string connectionString =
            ConfigurationManager.ConnectionStrings["GarageDB"].ConnectionString;

        public void InsertServiceRecord(ServiceRepair sr)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("dbo.sp_InsertServiceRecord", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@VehicleID", sr.VehicleID);

                    if (sr.PartID == null)
                    {
                        cmd.Parameters.AddWithValue("@PartID", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@PartID", sr.PartID);
                    }

                    cmd.Parameters.AddWithValue("@ServiceDate", sr.ServiceDate);
                    cmd.Parameters.AddWithValue("@Description", sr.Description);
                    cmd.Parameters.AddWithValue("@LaborName", sr.LaborName);
                    cmd.Parameters.AddWithValue("@Status", sr.Status);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public DataTable GetVehicles()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = @"
            SELECT 
                VehicleId,
                CAST(VehicleId AS NVARCHAR(10)) + ' - Reg: ' +
                CAST(Registrationnumber AS NVARCHAR(50)) + ' - ' +
                CAST(Make AS NVARCHAR(50)) + ' ' +
                CAST(Model AS NVARCHAR(50)) AS VehicleDisplay
            FROM dbo.Vehicles
            ORDER BY VehicleId";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        public DataTable GetParts()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = @"
            SELECT 
                InventoryId,
                ItemName + ' - Stock: ' + CAST(Quantity AS NVARCHAR(10)) AS PartDisplay
            FROM dbo.Inventories
            ORDER BY ItemName";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
        }
    }
}