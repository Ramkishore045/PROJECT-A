using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.IO;
using Microsoft.Data.SqlClient;
using ClinikMangementSystem.Models;
using System.Data;

namespace ClinikMangementSystem.DAL
{
    public class ClinikDAL
    {
        public string cnn = "";


        public ClinikDAL()
        {
            var builder = new ConfigurationBuilder().SetBasePath
                (Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            cnn = builder.GetSection("ConnectionStrings:Conn").Value;
        }
        

        public int NewDoctor(Doctor doc)
        {
            SqlConnection con = new SqlConnection(cnn);
            SqlCommand cmd = new SqlCommand("AddDoctor", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@fname", doc.FirstName);
            cmd.Parameters.AddWithValue("@lname", doc.LastName);
            cmd.Parameters.AddWithValue("@sex", doc.Sex);
            cmd.Parameters.AddWithValue("@spec", doc.Specialization);
            cmd.Parameters.AddWithValue("@vis", doc.VisitingHours);
            con.Open();
            int result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        public int NewPatient(Patient ptnts)
        {
            SqlConnection con = new SqlConnection(cnn);
            SqlCommand cmd = new SqlCommand("addpatient", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@fname", ptnts.FirstName);
            cmd.Parameters.AddWithValue("@lname", ptnts.LastName);
            cmd.Parameters.AddWithValue("@sex", ptnts.Sex);
            cmd.Parameters.AddWithValue("@dob", ptnts.Date_of_birth);
            con.Open();
            int result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        //public List<Schedules> ShowAllAppmnts()
        //{
        //    List<Schedules> ShowSchedules = new List<Schedules>();
        //    using (SqlConnection con = new SqlConnection(cnn))
        //    {
        //        using (SqlCommand cmd = new SqlCommand("Showappointments", con))
        //        {
        //            if (con.State == ConnectionState.Closed)
        //                con.Open();
        //            IDataReader reader = cmd.ExecuteReader();
        //            while (reader.Read())
        //            {
        //                ShowSchedules.Add(new Schedules()
        //                {
        //                    AppointmentId =int.Parse(reader["AppointmentId"].ToString()),
        //                    PatientId = int.Parse(reader["PatientID"].ToString()),
        //                    Specialization = reader["Specialization"].ToString(),
        //                    DoctorName = reader["DoctorName"].ToString(),
        //                    VisitDate = reader["VisitDate"].ToString(),
        //                    AppointmentTime = reader["AppointmentTime"].ToString()
        //                });
        //            }
        //            con.Close();
        //        }
        //    }
        //    return ShowSchedules;
        //}
        public int NewSchedule(Schedules sch)
        {
            SqlConnection con = new SqlConnection(cnn);
            SqlCommand cmd = new SqlCommand("Schpro", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@patientid", sch.PatientId);
            cmd.Parameters.AddWithValue("@spec", sch.Specialization);
            cmd.Parameters.AddWithValue("@doctorname", sch.DoctorName);
            cmd.Parameters.AddWithValue("@visitdate", sch.VisitDate);
            cmd.Parameters.AddWithValue("@appointtime", sch.AppointmentTime);
            con.Open();
            int result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        public List<Schedules> GetAllAppmnts()
        {
            List<Schedules> listSchedules = new List<Schedules>();
            using (SqlConnection con = new SqlConnection(cnn))
            {
                using (SqlCommand cmd = new SqlCommand("GetAppmnt", con))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    IDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        listSchedules.Add(new Schedules()
                        {
                            PatientId = int.Parse(reader["PatientID"].ToString()),
                            Specialization = reader["Specialization"].ToString(),
                            DoctorName = reader["DoctorName"].ToString(),
                            VisitDate = reader["VisitDate"].ToString(),
                            AppointmentTime = reader["AppointmentTime"].ToString()
                        });
                    }

                }
            }
            return listSchedules;
        }
        public int Delapp(int id)
        {
            SqlConnection con = new SqlConnection(cnn);
            SqlCommand cmd = new SqlCommand("Delapp", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            int result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        public int Verify(Login chck)
        {
            SqlConnection con = new SqlConnection(cnn);
            SqlCommand cmd = new SqlCommand("inlog", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@user", chck.UserName);
            cmd.Parameters.AddWithValue("@Pass", chck.Password);
            con.Open();
            IDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return (1);
            }
            con.Close();
            return (0);
        }
        public List<Doctor> getdoc()
        {
            SqlConnection conn = new SqlConnection(cnn);
            SqlCommand cmd = new SqlCommand("getdoc1", conn);
            conn.Open();
            IDataReader read = cmd.ExecuteReader();
            List<Doctor> Doc1 = new List<Doctor>();
            while (read.Read())
            {
                Doc1.Add(new Doctor()
                {
                    DoctorId = int.Parse(read["DoctorId"].ToString()),
                    FirstName = read["FirstName"].ToString(),
                    LastName = read["LastName"].ToString(),
                    Sex = read["sex"].ToString(),
                    Specialization = read["Specialization"].ToString(),
                });
            }

            return Doc1;
        }

        public List<Patient> getpat()
        {
            SqlConnection conn = new SqlConnection(cnn);
            SqlCommand cmd = new SqlCommand("getpat", conn);
            conn.Open();
            IDataReader read = cmd.ExecuteReader();
            List<Patient> pat = new List<Patient>();
            while (read.Read())
            {
                pat.Add(new Patient()
                {
                    PatientId = int.Parse(read["PatientId"].ToString()),
                    FirstName = read["FirstName"].ToString(),
                    LastName = read["LastName"].ToString(),
                    Sex = read["sex"].ToString(),
                    Age = int.Parse(read["Age"].ToString()),
                    Date_of_birth = read["Date_of_birth"].ToString(),
                });
            }

            return pat;
        }
    }
}
