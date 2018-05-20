using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NLog;

namespace DependencyInjectionWithLazy.Infrastructure
{
    public class LoggerFilterAttribute : ActionFilterAttribute, IActionFilter
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        private string _actionName;
        private string _controllerName;
        private string _requestType;

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            _actionName = filterContext.ActionDescriptor.ActionName;
            _controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            _requestType = filterContext.HttpContext.Request.HttpMethod;

            _logger.Info($"Before call controller: {_controllerName}.{_actionName} ({_requestType})");
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            _logger.Info($"After call controller: {_controllerName}.{_actionName} ({_requestType})");
        }
    }
}