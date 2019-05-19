using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Net;

namespace Reservator.API.CustomFilters
{
	public class ExceptionFilter : IExceptionFilter
	{
		private readonly ILogger<ExceptionFilter> logger;

		public ExceptionFilter(ILogger<ExceptionFilter> logger)
		{
			this.logger = logger;
		}

		public void OnException(ExceptionContext context)
		{
			HttpStatusCode status;

			if (context.Exception is UnauthorizedAccessException)
			{
				status = HttpStatusCode.Unauthorized;
			}
			else if (context.Exception is ArgumentException)
			{
				status = HttpStatusCode.BadRequest;
			}
			else
			{
				status = HttpStatusCode.InternalServerError;
			}

			logger.LogError(context.Exception.Message, context.Exception);

			context.ExceptionHandled = true;
			HttpResponse response = context.HttpContext.Response;
			response.StatusCode = (int)status;
			response.ContentType = "application/json";
			string error = context.Exception.StackTrace;
			response.WriteAsync(error);
		}
	}
}
