using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebApiApp.Models;

namespace WebApiApp.Filters
{
    public class Ticket_EnsureEnteredDate : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            var ticket = context.ActionArguments["ticket"] as Ticket;
            if (ticket != null &&
                !string.IsNullOrEmpty(ticket.Owner) &&
                ticket.EnteredDate.HasValue == false)
            {
                context.ModelState.AddModelError("EnteredDate", "Enterdate is required");
                context.Result = new BadRequestObjectResult(context.ModelState);
            }
        }
    }
}
