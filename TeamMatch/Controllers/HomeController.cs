using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using TeamMatch.Models;

namespace TeamMatch.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _configuration;

        public HomeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // HOME
        public IActionResult Index()
        {
            return View();
        }

        // ABOUT
        public IActionResult About()
        {
            return View();
        }

        public IActionResult FindTeam()
        {
            List<User> users = new List<User>();

            string connectionString =
                _configuration.GetConnectionString("TeamMatchConnection")!;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT FirstName, LastName, Major, Skills FROM Users";

                SqlCommand cmd = new SqlCommand(query, con);

                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    users.Add(new User
                    {
                        FirstName = reader["FirstName"].ToString(),
                        LastName = reader["LastName"].ToString(),
                        Major = reader["Major"].ToString(),
                        Skills = reader["Skills"].ToString()
                    });
                }
            }

            return View(users);
        }

        // PROFILE
        // PROFILE
        public IActionResult Profile()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Profile(User user)
        {
            string connectionString =
    _configuration.GetConnectionString("TeamMatchConnection")!;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = @"UPDATE Users SET
                         FirstName = @FirstName,
                         LastName = @LastName,
                         Password = @Password,
                         Gender = @Gender,
                         Major = @Major,
                         Skills = @Skills
                         WHERE Email = @Email";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
                cmd.Parameters.AddWithValue("@LastName", user.LastName);
                cmd.Parameters.AddWithValue("@Email", user.Email);
                cmd.Parameters.AddWithValue("@Password", user.Password);
                cmd.Parameters.AddWithValue("@Gender", user.Gender);
                cmd.Parameters.AddWithValue("@Major", user.Major);
                cmd.Parameters.AddWithValue("@Skills", user.Skills);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            ViewBag.Message = "Profile updated successfully";

            return View();
        }
        // LOGIN PAGE
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            string connectionString =
                _configuration.GetConnectionString("TeamMatchConnection")!;

            using (SqlConnection con =
                   new SqlConnection(connectionString))
            {
                string query =
                    "SELECT * FROM Users WHERE Email=@Email AND Password=@Password";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@Email", email);

                cmd.Parameters.AddWithValue("@Password", password);

                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    // SESSION
                    HttpContext.Session.SetString("UserEmail", email);

                    // COOKIE
                    CookieOptions options = new CookieOptions();

                    options.Expires = DateTime.Now.AddDays(7);

                    Response.Cookies.Append("UserEmail", email, options);

                    return RedirectToAction("Profile");
                }
            }

            ViewBag.Message = "Invalid Email or Password";

            return View();
        }

        // SIGNUP PAGE
        [HttpGet]
        public IActionResult Signup()
        {
            return View();
        }

        // REGISTER USER
        [HttpPost]
        public IActionResult Signup(User user)
        {
            string connectionString =
    _configuration.GetConnectionString("TeamMatchConnection")!;

            using (SqlConnection con =
                   new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO Users
                (FirstName, LastName, Email, Password, Gender, Major, Skills)
                VALUES
                (@FirstName, @LastName, @Email, @Password, @Gender, @Major, @Skills)";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
                cmd.Parameters.AddWithValue("@LastName", user.LastName);
                cmd.Parameters.AddWithValue("@Email", user.Email);
                cmd.Parameters.AddWithValue("@Password", user.Password);
                cmd.Parameters.AddWithValue("@Gender", user.Gender);
                cmd.Parameters.AddWithValue("@Major", user.Major);
                cmd.Parameters.AddWithValue("@Skills", user.Skills);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            ViewBag.Message = "Registration Successful";

            return View();
        }
    }
}