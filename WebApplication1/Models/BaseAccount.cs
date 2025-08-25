using Microsoft.AspNetCore.Http;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication1.Models
{
    public class BaseAccount
    {
        public string Username { get; set; }
        public string Password { get; set; }

        private readonly IHttpContextAccessor? _httpContextAccessor;
        private readonly IConfiguration? _configuration;

        // ✅ Needed for model binding (parameterless constructor)
        public BaseAccount() { }

        // ✅ Used when created via dependency injection
        public BaseAccount(IHttpContextAccessor httpContextAccessor, IConfiguration configuration)
        {
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
        }

        public bool Verify()
        {
            if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password))
                return false;

            DataTable dt = new DataTable();

            // Use IConfiguration to retrieve the connection string
            string connString = _configuration?.GetConnectionString("DefaultConnection");
            if (string.IsNullOrEmpty(connString))
                return false;

            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "dbo.Get_user_info";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 0;

                        // Assuming your stored procedure accepts Username & Password
                        //cmd.Parameters.AddWithValue("@Username", Username);
                        //cmd.Parameters.AddWithValue("@Password", Password);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(dt);
                        }
                    }
                }

                // Only proceed if user was found
                if (dt.Rows.Count > 0)
                {
                    var httpContext = _httpContextAccessor?.HttpContext;
                    if (httpContext != null)
                    {
                        //httpContext.Session.SetString("User", "Tanvir@gmail.com");

                        if (this.Username?.ToUpper() == "TANVIR@GMAIL.COM"
                            && this.Password == "1234")
                        {
                            return true;
                        }
                    }
                    
                }
            }
            catch (Exception ex)
            {
                // log the exception
                Console.WriteLine("Verify() failed: " + ex.Message);
                return false;
            }

            return false;
        }


        //public bool Verify()
        //{
        //    DataTable dt = new DataTable();
        //    // Use IConfiguration to retrieve the connection string
        //    string connString = _configuration?.GetConnectionString("ConnString");
        //    SqlConnection conn = new SqlConnection(connString); // Fix capitalization of 'SqlConnection'
        //    SqlConnection.Open();

        //    SqlCommand cmd = SqlConnection.CreateCommand();
        //    cmd.CommandText = "dbo.Get_user_info";
        //    cmd.CommandType = System.Data.CommandType.StoredProcedure;
        //    cmd.CommandTimeout = 0;

        //    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        //    adapter.Fill(dt);
        //    cmd.Dispose();
        //    conn.Close();

        //    // make sure we only use HttpContext when accessor is provided
        //    if (_httpContextAccessor == null) return false;

        //    var httpContext = _httpContextAccessor.HttpContext;

        //    if (httpContext != null)
        //    {
        //        httpContext.Session.SetString("User", "Tanvir@gmail.com");

        //        if (this.Username?.ToUpper() == "TANVIR@GMAIL.COM"
        //            && this.Password == "1234")
        //        {
        //            return true;
        //        }
        //    }

        //    return false;
        //}
    }
}
