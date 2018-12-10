using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Buffteks.Models
{
    public class ProjectDetail
    {

        public Project TheProject {get; set;}

        public List<Client> ProjectClients { get; set; }
        
        public List<Member> ProjectMembers { get; set; }

        
    }
}