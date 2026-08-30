using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace sistemaUñas_MimoraNails.Filters
{
    public class SesionAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var usuario = context.HttpContext.Session.GetString("Usuario");

            if (string.IsNullOrEmpty(usuario))
            {
                context.Result = new RedirectToActionResult(
                    "Index",
                    "Login",
                    null
                );
            }

            base.OnActionExecuting(context);
        }
    }
}