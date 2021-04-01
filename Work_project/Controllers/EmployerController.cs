using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Work_project.Models;

namespace Work_project.Controllers
{
    public class EmployerController : ApiController
    {
        public HttpResponseMessage Get()
        {
            string query = @"
                select EmployersId,EmployersName,EmployersSurname, EmployersYearofBirth,EmployersPhone from
                dbo.Employer
                ";
            DataTable table = new DataTable();
            using (var con = new SqlConnection(ConfigurationManager.
                ConnectionStrings["Employer"].ConnectionString))
            using (var cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }

            return Request.CreateResponse(HttpStatusCode.OK, table);

        }
        public string Post(Employer dep)
        {
            try
            {
                string query = @"
                        insert into dbo.Employer values
                        ( '" + dep.EmployersName + @"'
                        , '" + dep.EmployersSurname + @"'
                        ,'" + dep.EmployersYearofBirth + @"'
                        ,'" + dep.EmployersPhone + @"')
                        ";
                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.
                    ConnectionStrings["Employer"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }
                return "Added Successfully!!";
            }
            catch (Exception)
            {
                return "Faild to Add";
            }
        }
        public string Put(Employer dep)
        {
            try
            {
                string query = @"
                        update dbo.Employer set EmployersPhone =
                        '" + dep.EmployersPhone + @"'
                         where EmployersId=" + dep.EmployersId + @"
                         ";
                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.
                    ConnectionStrings["Employer"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }
                return "Updated Successfully!!";
            }
            catch (Exception)
            {
                return "Faild to Update";
            }
        }
        public string Delete(int id)
        {
            try
            {
                string query = @"
                         delete from dbo.Employer
                         where EmployersId=" + id + @"
                         ";
                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.
                    ConnectionStrings["Employer"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }
                return "Deleted Successfully!!";
            }
            catch (Exception)
            {
                return "Faild to Delete";
            }
        }
        [Route("api/Employer/GetAllEmployerNames")]
        [HttpGet]

        public HttpResponseMessage GetAllEmployerNames()
        {
            string query = @"
                    select EmployersName from dbo.Employer";

            DataTable table = new DataTable();
            using (var con = new SqlConnection(ConfigurationManager.
                ConnectionStrings["Employer"].ConnectionString))
            using (var cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }
            return Request.CreateResponse(HttpStatusCode.OK, table);
        }
    }

    
}
