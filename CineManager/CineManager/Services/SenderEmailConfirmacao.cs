using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;

namespace CineManager.Services
{
    public class SenderEmailConfirmacao : IEmailSender
    {
        public SenderEmailConfirmacao(IOptions<EmailConfirmacao> optionsAcessor)
        {
            Email = optionsAcessor.Value;
        }

        //Pega os dados do user id e do user secret do send grid
        public EmailConfirmacao Email { get; }

        //Tarefa que envia o email
        public Task SendEmailAsync(string email, string assunto, string mensagem){
            return Executar(Email.KeySendGrid, assunto, mensagem, email);
        }

        public Task Executar(string chaveApi, string assunto, string mensagem, string email)
        {
            var cliente = new SendGridClient(chaveApi);

            //cria o email
            var msg = new SendGridMessage()
            {
                From = new EmailAddress("cinemanagerteam@gmail.com", Email.UserSendGrid),
                Subject = assunto,
                PlainTextContent = mensagem,
                HtmlContent = mensagem
            };

            msg.AddTo(new EmailAddress(email));

            msg.SetClickTracking(false, false);

            return cliente.SendEmailAsync(msg);
        }
    }
}
