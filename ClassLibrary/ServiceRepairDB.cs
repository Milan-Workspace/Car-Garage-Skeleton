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

        public int AddServiceRecord(ServiceRepair sr)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("dbo.sp_InsertServiceRecord", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@VehicleID", sr.VehicleID);
                cmd.Parameters.AddWithValue("@PartID", sr.PartID == null ? (object)DBNull.Value : sr.PartID);
                cmd.Parameters.AddWithValue("@ServiceDate", sr.ServiceDate);
                cmd.Parameters.AddWithValue("@Description", sr.Description);
                cmd.Parameters.AddWithValue("@LaborName", sr.LaborName);
                cmd.Parameters.AddWithValue("@Status", sr.Status);

                con.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public void UpdateServiceRecord(ServiceRepair sr)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("dbo.sp_UpdateServiceRecord", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ServiceID", sr.ServiceID);
                cmd.Parameters.AddWithValue("@VehicleID", sr.VehicleID);
                cmd.Parameters.AddWithValue("@PartID", sr.PartID == null ? (object)DBNull.Value : sr.PartID);
                cmd.Parameters.AddWithValue("@ServiceDate", sr.ServiceDate);
                cmd.Parameters.AddWithValue("@Description", sr.Description);
                cmd.Parameters.AddWithValue("@LaborName", sr.LaborName);
                cmd.Parameters.AddWithValue("@Status", sr.Status);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteServiceRecord(int serviceID)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("dbo.sp_DeleteServiceRecord", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ServiceID", serviceID);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public DataTable GetVehicles()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT 
                        VehicleId AS VehicleID,
                        CAST(VehicleId AS NVARCHAR(10)) + ' - Reg: ' +
                        CAST(Registrationnumber AS NVARCHAR(50)) + ' - ' +
                        CAST(Make AS NVARCHAR(50)) + ' ' +
                        CAST(Model AS NVARCHAR(50)) AS VehicleDisplay
                    FROM dbo.Vehicles
                    ORDER BY VehicleId";

                using (SqlCommand cmd = new SqlCommand(query, con))
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
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
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public DataTable FindServiceRecord(int serviceID)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("dbo.sp_FindServiceRecord", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ServiceID", serviceID);

                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public DataTable GetAllServiceRecords()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("dbo.sp_SelectAllServiceRecords", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public DataTable FilterByStatus(string status)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("dbo.sp_FilterServiceRecordsByStatus", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Status", status);

                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public DataTable StatisticsByStatus()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("dbo.sp_ServiceStatsByStatus", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public DataTable StatisticsByDate()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("dbo.sp_ServiceStatsByDate", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;

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