using Microsoft.AspNetCore.Mvc;

namespace WebApiApp.Models
{
    public class Ticket
    {
        [FromQuery(Name ="ticketid")]
        public int TicketId { get; set; }

        [FromRoute(Name = "projectid")]
        public int ProjectId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
