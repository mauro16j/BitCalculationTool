﻿using BidCalculationTool.Api.Exceptions;
using System.Net;
using System.Text.Json;

namespace BidCalculationTool.Api.Middleware;

internal sealed class ExceptionHandlerMiddleware
{
    private readonly ILogger<ExceptionHandlerMiddleware> _logger;
    private readonly RequestDelegate _next;

    public ExceptionHandlerMiddleware(ILogger<ExceptionHandlerMiddleware> logger, RequestDelegate next)
    {
        _logger = logger;
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            await ConvertException(context, ex);
        }
    }

    private Task ConvertException(HttpContext context, Exception exception)
    {
        HttpStatusCode httpStatusCode = HttpStatusCode.InternalServerError;

        context.Response.ContentType = "application/json";

        var result = string.Empty;

        switch (exception)
        {
            case BadRequestException badRequestException:
                httpStatusCode = HttpStatusCode.BadRequest;
                result = badRequestException.Message;
                break;
            case NotFoundException:
                httpStatusCode = HttpStatusCode.NotFound;
                break;
            case Exception:
                httpStatusCode = HttpStatusCode.BadRequest;
                break;
        }

        context.Response.StatusCode = (int)httpStatusCode;

        if (result == string.Empty)
        {
            result = JsonSerializer.Serialize(new { error = exception.Message });
        }

        return context.Response.WriteAsync(result);
    }
}
