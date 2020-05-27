using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitNessCompanionApp.Model
{
    class EmailItem
    {
        public EmailItem(string toEmail, string fromEmail, string subject, string message)
        {
            ToEmail = toEmail;
            FromEmail = fromEmail;
            Subject = subject;
            Message = message;
        }

        [JsonProperty("toEmail")]
        public string ToEmail { get; set; }

        [JsonProperty("fromEmail")]
        public string FromEmail { get; set; }

        [JsonProperty("subject")]
        public string Subject { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
