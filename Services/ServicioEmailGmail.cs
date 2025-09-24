using System.Net;
using System.Net.Mail;
using portafolio.Models;

namespace portafolio.Services{
    public interface IServicioEmail{
        Task Enviar(ContactoDTO _contacto);
    }

    public class ServicioEmailGmail:IServicioEmail{
        private readonly IConfiguration configuration;
       public ServicioEmailGmail(IConfiguration _configuration){
           this.configuration = _configuration;
       }
       public async Task Enviar(ContactoDTO _contacto){
           var emailEmisor =  configuration.GetValue<string>("CONFIGURACIONES_EMAIL:EMAIL");
           var password = configuration.GetValue<string>("CONFIGURACIONES_EMAIL:PASSWORD");
           var host = configuration.GetValue<string>("CONFIGURACIONES_EMAIL:HOST");
           var puerto = configuration.GetValue<int>("CONFIGURACIONES_EMAIL:PUERTO");

           var smtpCliente = new SmtpClient(host,puerto);
           smtpCliente.EnableSsl = true;
           smtpCliente.UseDefaultCredentials = false;

           smtpCliente.Credentials = new NetworkCredential(emailEmisor,password);
           var mensaje = new MailMessage(
               emailEmisor,
               emailEmisor,
               $"El cliente {_contacto.nombre} ({_contacto.email}) quiere contactarte ",
               _contacto.mensaje
           );

           await smtpCliente.SendMailAsync(mensaje); 
       }
    }
}