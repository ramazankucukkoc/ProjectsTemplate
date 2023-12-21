namespace Core.Mailings
{
    public interface IMailService
    {
        Task SendMailAsync(Mail mail);
    }
}
