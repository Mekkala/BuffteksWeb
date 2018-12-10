using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Buffteks.Models
{
    public class ProjectAssign 
    {
        public int ParticipantID { get; set; }
        public ProjectParticipant ProjectParticipant { get; set; }
        public string ProjectID { get; set; }
        public Project Project { get; set; }
    }
}