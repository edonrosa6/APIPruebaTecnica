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

                return Ok();
            } catch(Exception ex) {
                return BadRequest();
            }
        }

    }
}
