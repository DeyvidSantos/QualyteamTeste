using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace QualyteamTeste.Models
{
    public class Document
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "The Code cant be empty")]
        [RegularExpression("^[0-9]\\d*$", ErrorMessage = "The code must be only numbers")] 
        [Index(IsUnique = true)]  
        public int Code { get; set; } 
        [Required]
        public string Title { get; set; }
        [Required]
        public string Process { get; set; }
        [Required]
        public string Category { get; set; }
        [NotMapped]
        public IFormFile File { get; set; }
        
        public string? FilePath { get; set; }
    }
}   