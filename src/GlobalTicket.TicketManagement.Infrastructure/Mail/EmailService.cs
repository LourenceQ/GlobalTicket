﻿using GlobalTicket.CelanArch.Application.Contracts.Infrastructure;
using GlobalTicket.CelanArch.Application.Models.Mail;
using SendGrid.Helpers.Mail;
using SendGrid;

namespace GlobalTicket.TicketManagement.Infrastructure.Mail;
public class EmailService : IEmailService
{
    public EmailSettings _emailSettings { get; }

    public EmailService(EmailSettings emailSettings)
    {
        _emailSettings = emailSettings;
    }

    public async Task<bool> SendEmail(Email email)
    {

        var client = new SendGridClient(_emailSettings.ApiKey);

        var subject = email.Subject;
        var to = new EmailAddress(email.To);
        var emailBody = email.Body;

        var from = new EmailAddress
        {
            Email = _emailSettings.FromAddress,
            Name = _emailSettings.FromName
        };

        var sendGridMessage = MailHelper.CreateSingleEmail(from, to, subject, emailBody, emailBody);
        var response = await client.SendEmailAsync(sendGridMessage);


        if (response.StatusCode == System.Net.HttpStatusCode.Accepted || response.StatusCode == System.Net.HttpStatusCode.OK)
            return true;

        return false;
    }
}
