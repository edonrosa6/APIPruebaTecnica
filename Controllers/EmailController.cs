using System;
using System.Collections.Generic;
using System.Linq;

using APIPrueba.Contexts;
using APIPrueba.Entities;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

namespace APIPrueba.Controllers
{
    [Route("api/[controller]")]
    public class EmailController : ControllerBase
    {
        private readonly AppDbContext context;

        public EmailController(AppDbContext context) 
        {
            this.context = context;
        }

        [HttpGet]
        public IEnumerable<SendMail> GetAll() 
        {
            return context.SendMail.ToList();
        }

        [HttpPost]
        public ActionResult Post([FromBody] SendMail email)
        {
            try {
                context.SendMail.Add(email);
                context.SaveChanges();

                var mensaje = new MimeMessage();
                mensaje.From.Add(new MailboxAddress(email.Nombre, "edsonrosales123@gmail.com"));
                mensaje.To.Add(new MailboxAddress(email.Nombre, email.Correo));
                mensaje.Subject = email.Nombre + " " + email.Correo;
                mensaje.Body = new TextPart("plain")
                {
                    Text = $"Ciudad y Estado: {email.CiudadYEstado} Telefono: {email.Telefono} Correo: {email.Correo}"
                };

                using (var cliente = new SmtpClient())
                {
                    cliente.Connect("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
                    cliente.Authenticate("edsonrosales123@gmail.com", "edsonrosales123");
                    cliente.Send(mensaje);
                    cliente.Disconnect(true);     
                }

                return Ok();
            } catch(Exception ex) {
                return BadRequest();
            }
        }

    }
}
