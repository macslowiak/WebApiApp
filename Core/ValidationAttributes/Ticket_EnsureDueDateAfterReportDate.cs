using Core.Models;
using System.ComponentModel.DataAnnotations;

namespace Core.ValidationAttributes
{
    internal class Ticket_EnsureDueDateAfterReportDate : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var ticket = validationContext.ObjectInstance as Ticket;

            if (!ticket.ValidateDueDateAfterReportDate())
            {
                return new ValidationResult("Due date has to be after report date");
            }

            return ValidationResult.Success;
        }
    }
}