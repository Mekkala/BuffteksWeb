using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

 namespace Buffteks.Models
{
    public class Project
    {
        [Key]
        public string ID { get; set; }

        [Display(Name = "Project Name")]                
        public string ProjectName { get; set; }
        [Display(Name = "Project Description")]                
        public string Description { get; set; }
        public ICollection<ProjectAssign> Participants { get; set; }

        public override string ToString(){
            return $"Project Name: {this.ProjectName} Description: {this.Description}";
        }
    }
}