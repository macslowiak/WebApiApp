using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebApiApp.Models;

namespace WebApiApp.Filters
{
    public class Ticket_ValidateDates : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            var ticket = context.ActionArguments["ticket"] as Ticket;

            if (ticket != null &&
                !string.IsNullOrEmpty(ticket.Owner))
            {
                bool isValid = true;
                if (!ticket.DueDate.HasValue)
                {
                    context.ModelState.AddModelError("DueDate", "DueDate is Required");
                    isValid = false;
                }

                if (ticket.EnteredDate.HasValue &&
                    ticket.DueDate.HasValue &&
                    ticket.EnteredDate > ticket.DueDate)
                {
                    context.ModelState.AddModelError("EnteredDate", "EnteredDate should not be later than DueDate.");
                    isValid = false;
                }

                if (isValid == false)
                {
                    context.Result = new BadRequestObjectResult(context.ModelState);
                }
            }
        }
    }
}