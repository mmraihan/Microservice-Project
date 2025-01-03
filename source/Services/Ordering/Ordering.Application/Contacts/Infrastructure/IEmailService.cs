﻿using Ordering.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Contacts.Infrastructure
{
    public interface IEmailService
    {
        Task<bool> SendEmailAsync(EmailMessage emailMessage);
    }
}
