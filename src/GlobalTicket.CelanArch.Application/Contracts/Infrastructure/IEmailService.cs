using GlobalTicket.CelanArch.Application.Models.Mail;

namespace GlobalTicket.CelanArch.Application.Contracts.Infrastructure;
public interface IEmailService
{
    Task<bool> SendEmail(Email email);
}
