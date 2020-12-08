using HcodeR.Crosscutting.Validations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HcodeR.API.Controllers.v1
{
    [ApiController]
    public class CustomController : ControllerBase
    {
        protected new IActionResult Response(ModelStateDictionary modelState)
        {
            return BadRequest(new { createdAt = DateTime.UtcNow, message = "Verifique os erros", data = new { }, notifications = ValidateModelState(modelState) });
        }

        protected new IActionResult Response(CodeResponse codeResponse, List<Notification> notifications = null, object data = null)
        {
            return ValidateResponse(codeResponse, data, notifications);
        }

        private IActionResult ValidateResponse(CodeResponse codeResponse, object data = null, List<Notification> notifications = null)
        {
            if (ValidateNotifications(notifications)) return BadRequest(new { createdAt = DateTime.UtcNow, message = "Verifique os erros", data, notifications = NotificationsFormated(notifications) });

            switch (codeResponse)
            {
                case CodeResponse.Get:
                    return Ok(new { createdAt = DateTime.UtcNow, message = "Registros listados com sucesso", data, notifications });
                case CodeResponse.Find:
                    if (data == null) return NotFound(new { createdAt = DateTime.UtcNow, message = "O registro solicitado não existe", data, notifications });
                    return Ok(new { createdAt = DateTime.UtcNow, message = "Registro obtido com sucesso", data, notifications });
                case CodeResponse.Post:
                    return Created("", new { createdAt = DateTime.UtcNow, message = "Cadastro efetuado com sucesso", data, notifications });
            }

            return NoContent();
        }

        private List<NotificationsFormated> ValidateModelState(ModelStateDictionary modelState)
        {
            var notifications = new List<NotificationsFormated>();

            if (!modelState.IsValid)
            {
                var messages = ModelState.Values.SelectMany(e => e.Errors).Select(e => e.ErrorMessage);

                foreach (var message in messages)
                {
                    notifications.Add(new NotificationsFormated(CodeNotification.Application.ToString(), message));
                }
            }

            return notifications;
        }

        private bool ValidateNotifications(List<Notification> notifications)
        {
            if (notifications != null)
            {
                if (notifications.Count > 0) return true;
            }

            return false;
        }

        private List<NotificationsFormated> NotificationsFormated(List<Notification> notifications)
        {
            var notificationsFormated = new List<NotificationsFormated>();

            foreach (var notification in notifications)
            {
                notificationsFormated.Add(new NotificationsFormated(notification.Code.ToString(), notification.Message));
            }

            return notificationsFormated;
        }
    }

    public enum CodeResponse
    {
        Get = 1,
        Find = 2,
        Post = 3,
        Put = 4,
        Patch = 5,
        Delete = 6
    }

    public class NotificationsFormated
    {
        public NotificationsFormated(string code, string message)
        {
            Code = code;
            Message = message;
        }

        public string Code { get; private set; }
        public string Message { get; private set; }
    }
}
