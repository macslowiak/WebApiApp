using System.ComponentModel.DataAnnotations;
using WebApiApp.Models;

namespace WebApiApp.ModelValidations
{
    public class Ticket_IsDueDateInFuture : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var ticket = validationContext.ObjectInstance as Ticket;

            if (ticket!=null && ticket.DueDate.HasValue && ticket.DueDate.Value < DateTime.Now)
            {
                if (!ticket.TicketId.HasValue)
                {
                    return new ValidationResult("Date must be a future date");
                }
            }
            return ValidationResult.Success;
        }
    }
}
