using alert_mns.Database;
using alert_mns.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace alert_mns.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly SqlConnection _sqlConnection;

        public UserController(IConfiguration configuration)
        {
            _sqlConnection = new SqlConnection(configuration);
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            string query = "SELECT * FROM user;";
            List<User> users = new List<User>();
            DataTable result = _sqlConnection.ExecuteQuery(query);

            foreach (DataRow row in result.Rows)
            {
                User user = new User
                {
                    Id = Convert.ToInt32(row["id"]),
                    LastName = Convert.ToString(row["lastName"]),
                    FirstName = Convert.ToString(row["firstName"]),
                    Email = Convert.ToString(row["email"]),
                    Password = Convert.ToString(row["password"]),
                    CreationDate = Convert.ToDateTime(row["creationDate"]),
                    ConnectionDate = Convert.ToDateTime(row["connectionDate"]),
                    Status = Convert.ToBoolean(row["status"])
                };
                users.Add(user);
            }

            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById(int id) 
        {
            string query = $"SELECT * FROM user WHERE id={id}";
            DataTable result = _sqlConnection.ExecuteQuery(query);

            DataRow row = result.Rows[0];
            User user = new User
            {
                Id = Convert.ToInt32(row["id"]),
                LastName = Convert.ToString(row["lastName"]),
                FirstName = Convert.ToString(row["firstName"]),
                Email = Convert.ToString(row["email"]),
                Password = Convert.ToString(row["password"]),
                CreationDate = Convert.ToDateTime(row["creationDate"]),
                ConnectionDate = Convert.ToDateTime(row["connectionDate"]),
                Status = Convert.ToBoolean(row["status"])
            };
            return Ok(user);
        }
       

        [HttpPost]
        public IActionResult CreateUser(User user)
        {
            try
            {
                string query = $"INSERT INTO user (lastName, firstName, email, password, status) VALUES ('{user.LastName}', '{user.FirstName}', '{user.Email}', '{user.Password}', '{user.Status}');";

                // Exécution de la requête
                _sqlConnection.ExecuteNonQuery(query);

                return Ok("Utilisateur créé avec succès !");
            }
            catch (Exception ex)
            {
                return BadRequest("Erreur lors de la création de l'utilisateur : " + ex.Message);
            }
        }
    }
}
