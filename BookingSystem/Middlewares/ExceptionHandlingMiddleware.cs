using System.Net;
using System.Text.Json;

/// <summary>
/// Middleware for handling exceptions globally and returning standardized error responses
/// </summary>
public class ExceptionHandlingMiddleware
{
	private readonly RequestDelegate _next;
	private readonly ILogger<ExceptionHandlingMiddleware> _logger;

	/// <summary>
	/// Initializes a new instance of the middleware with the next request delegate and a logger
	/// </summary>
	public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
	{
		_next = next;
		_logger = logger;
	}

	/// <summary>
	/// Invokes the middleware to handle exceptions during request processing
	/// </summary>
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

			await WriteError(context, statusCode);
		}
	}

	/// <summary>
	/// Maps specific exception types to appropriate HTTP status codes
	/// </summary>
	private static HttpStatusCode MapStatusCode(Exception ex)
	{
		if (ex is ArgumentException)
			return HttpStatusCode.BadRequest;

		if (ex is KeyNotFoundException)
			return HttpStatusCode.NotFound;

		return HttpStatusCode.InternalServerError;
	}

	/// <summary>
	/// Returns a generic error message based on the status code
	/// </summary>
	private static string GetGenericMessage(int statusCode)
	{
		if (statusCode == (int)HttpStatusCode.BadRequest)
			return "Invalid request";

		if (statusCode == (int)HttpStatusCode.NotFound)
			return "Resource not found";

		return "An error occurred. Please try again later";
	}

	/// <summary>
	/// Writes a JSON-formatted error response to the client
	/// </summary>
	private static async Task WriteError(HttpContext context, int statusCode)
	{
		if (context.Response.HasStarted)
			return;

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