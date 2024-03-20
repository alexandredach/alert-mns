using alert_mns.Database;
using alert_mns.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace alert_mns.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly SqlConnection _sqlConnection;

        public MessageController(IConfiguration configuration)
        {
            _sqlConnection = new SqlConnection(configuration);
        }

        [HttpPost]
        public IActionResult CreateMessage(Message message)
        {
            try
            {
                string query = $"INSERT INTO message (content, attachment, dispatch_date) VALUES ('{message.Content}', '{message.Attachment}', '{message.DispatchDate}');";

                // Exécution de la requête
                _sqlConnection.ExecuteNonQuery(query);

                return Ok("Message créé avec succès !");
            }
            catch (Exception ex)
            {
                return BadRequest("Erreur lors de la création du message : " + ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAllMessages() 
        {
            string query = "SELECT id, content FROM message;";
            List<Message> messages = new List<Message>();
            DataTable result = _sqlConnection.ExecuteQuery(query);

            foreach (DataRow row in result.Rows)
            {
                Message message = new Message
                {
                    Id = Convert.ToInt32(row["id"]),
                    Content = Convert.ToString(row["content"])
                };
                messages.Add(message);
            }

            return Ok(messages);
        }
    }
}
