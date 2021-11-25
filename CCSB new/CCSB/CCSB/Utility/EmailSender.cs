using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mailjet.Client;
using Mailjet.Client.Resources;
using Microsoft.AspNetCore.Identity.UI.Services;
using Newtonsoft.Json.Linq;

namespace CCSB.Utility
{
    public class EmailSender : IEmailSender
    {
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            MailjetClient client = new MailjetClient("2fd69b32bf4a5a7939f7e69b989115a7", "0e84cb6af76e96d80b57b89c0cc6a136")
            {
            };
            MailjetRequest request = new MailjetRequest
            { 
                Resource = Send.Resource,
            }
            .Property(Send.FromEmail, "camperencarvanstalling@gmail.com")
            .Property(Send.FromName, "CCSB")
            .Property(Send.Subject, subject)
            .Property(Send.HtmlPart, htmlMessage)
            .Property(Send.Recipients, new JArray {
                 new JObject {
                 {"Email", email}
                 }
            });
            MailjetResponse response = await client.PostAsync(request);
        }
    }
}
