using System.Collections.Generic;

namespace HcodeR.Crosscutting.Validations
{
    public abstract class CustomValidation
    {
        protected readonly List<Notification> _notifications;

        public CustomValidation()
        {
            _notifications = new List<Notification>();
        }

        public void AddNotification(CodeNotification code, string message)
        {
            _notifications.Add(new Notification(code, message));
        }
    }

    public class Notification
    {
        public Notification(CodeNotification code, string message)
        {
            Code = code;
            Message = message;
        }

        public CodeNotification Code { get; private set; }
        public string Message { get; private set; }
    }
}
