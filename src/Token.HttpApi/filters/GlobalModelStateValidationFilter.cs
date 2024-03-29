﻿using System.Diagnostics;
using GoYes.Module;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Token.HttpApi.filters;

public class GlobalModelStateValidationFilter : ActionFilterAttribute
{
    [DebuggerStepThrough]
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        if (context.ModelState.IsValid)
        {
            return;
        }

        ModelStateResult modelStateResult = new();
        foreach (ModelStateEntry value in context.ModelState.Values)
        foreach (ModelError error in value.Errors)
        {
            modelStateResult.Message = modelStateResult.Message + error.ErrorMessage + "|";
        }

        context.Result = new ObjectResult(modelStateResult);
    }
}
