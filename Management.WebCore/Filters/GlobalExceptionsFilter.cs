﻿using Management.WebCore.Exceptions;
using Management.WebCore.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Management.WebCore.Filters;
/// <summary>
/// 全局异常拦截器
/// </summary>
public class GlobalExceptionsFilter:ExceptionFilterAttribute
{
    private readonly ILogger<GlobalExceptionsFilter> _loggerHelper;
    /// <summary>
    /// 
    /// </summary>
    /// <param name="loggerHelper"></param>
    public GlobalExceptionsFilter(ILogger<GlobalExceptionsFilter> loggerHelper)
    {
        _loggerHelper = loggerHelper;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="context"></param>
    [DebuggerStepThrough]
    public override void OnException(ExceptionContext context)
    {
        if (context.ExceptionHandled == false)
        {
            var ex = context.Exception as BusinessLogicException;
            ModelStateResult response = new ModelStateResult
            {
                StatusCode = ex?.Code??500,
                Message = ex?.Message??context.Exception.Message
            };
            _loggerHelper.LogError(context.HttpContext.Request.Path, context.Exception, context.HttpContext.Request.Body);
            context.Result = new ContentResult
            {
                Content = JsonConvert.SerializeObject(response),
                StatusCode = ex?.Code ?? 500,
                ContentType = "application/json;charset=utf-8"
            };
        }
        context.ExceptionHandled = true;
    }
}