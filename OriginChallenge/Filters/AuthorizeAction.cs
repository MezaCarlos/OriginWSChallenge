using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using OriginChallenge.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OriginChallenge.Filters
{
    public class AuthorizeActionFilter : IAuthorizationFilter
    {
        private string numeroTarjeta;
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            try
            {
                numeroTarjeta = context.HttpContext.Session.GetString("Tarjeta");
                ControllerActionDescriptor descriptor = context.ActionDescriptor as ControllerActionDescriptor;

                //Si no esta logueado se redirecciona a la pagina de inicio
                //Si esta logueado la pagina de inicio es la de operacion
                if (numeroTarjeta == null)
                {
                    if (descriptor.ControllerName != "Home")
                    {
                        context.HttpContext.Response.Redirect("Home/Index");
                    }
                    
                }
                else
                {
                    if (descriptor.ControllerName == "Home")
                    {
                        context.HttpContext.Response.Redirect("Operacion/Index");
                    }
                }
            }
            catch (Exception)
            {

                context.HttpContext.Response.Redirect("Home/Index");
            }
        }
    }

    public class AuthorizeAttribute : TypeFilterAttribute
    {
        public AuthorizeAttribute()
            : base(typeof(AuthorizeActionFilter))
        {
            
        }
    }
}
