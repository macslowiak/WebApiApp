using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using WebApiApp.ModelValidations;

namespace WebApiApp.Models
{
    public class Ticket
    {
        public int? TicketId { get; set; }

        [Required]
        public int? ProjectId { get; set; }

        [Required]
        public string? Title { get; set; }

        public string? Description { get; set; }

        public string? Owner { get; set; }

        [Ticket_EnsureDueDataForTicektOwner]
        [Ticket_IsDueDateInFuture]
        public DateTime? DueDate { get; set; }
    }
}