using System;
using Microsoft.AspNetCore.Mvc;
using C19Tracking.API.Extensions;
using C19Tracking.API.Resources;

namespace C19Tracking.API.Controllers.Config
{
    public static class InvalidModelStateResponseFactory
    {
        public static IActionResult ProduceErrorResponse(ActionContext context)
        {
            var errors = context.ModelState.GetErrorMessages();
            var response = new ErrorResource(messages: errors); 
            return new BadRequestObjectResult(response);
        }
    }
}