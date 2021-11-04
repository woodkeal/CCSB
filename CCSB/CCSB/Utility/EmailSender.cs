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
            MailjetClient client = new MailjetClient("1609df55534324052dad44cfb3b309c7", "9622c8ae41db7e2d801dc24e62af50b6")
            {
            };
            MailjetRequest request = new MailjetRequest
            { 
                Resource = Send.Resource,
            }
            .Property(Send.FromEmail, "0318584@student.rocvantwente.nl")
            .Property(Send.FromName, "Appointment Scheduler")
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
