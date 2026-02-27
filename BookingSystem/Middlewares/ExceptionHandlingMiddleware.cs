using System.Net;
using System.Text.Json;

public class ExceptionHandlingMiddleware
{
	private readonly RequestDelegate _next;
	private readonly ILogger<ExceptionHandlingMiddleware> _logger;

	public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
	{
		_next = next;
		_logger = logger;
	}

	public async Task Invoke(HttpContext context)
	{
		try
		{
			await _next(context);
		}
		catch (Exception ex)
		{
			_logger.LogError(ex, "Unhandled exception");

			int statusCode = (int)MapStatusCode(ex);

			await WriteGenericError(context, statusCode);
		}
	}

	private static HttpStatusCode MapStatusCode(Exception ex)
	{
		if (ex is ArgumentException)
		{
			return HttpStatusCode.BadRequest;
		}

		if (ex is KeyNotFoundException)
		{
			return HttpStatusCode.NotFound;
		}

		return HttpStatusCode.InternalServerError;
	}

	private static string GetGenericMessage(int statusCode)
	{
		if (statusCode == (int)HttpStatusCode.BadRequest)
		{
			return "Invalid request";
		}

		if (statusCode == (int)HttpStatusCode.NotFound)
		{
			return "Resource not found";
		}

		return "An error occurred. Please try again later";
	}

	private static async Task WriteGenericError(HttpContext context, int statusCode)
	{
		if (context.Response.HasStarted)
		{
			return;
		}

		context.Response.Clear();
		context.Response.StatusCode = statusCode;
		context.Response.ContentType = "application/json";

		var payload = new
		{
			Message = GetGenericMessage(statusCode)
		};

		string json = JsonSerializer.Serialize(payload);
		await context.Response.WriteAsync(json);
	}
}