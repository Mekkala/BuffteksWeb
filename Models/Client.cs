using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Buffteks.Models
{
    public class Client : ProjectParticipant
    {
        [Display(Name = "Company Name")]        
        public string CompanyName {get; set;}
    }
}