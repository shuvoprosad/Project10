using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using Project10.Models;

namespace Project10.Models
{
    public class Room
    {
       
        public int Id { get; set; }
        [Required]
        [StringLength(55)]
        public string Roomname { get; set; }
        [Required]
        [StringLength(255)]
        public string Reason { get; set; }
        [Required]
        [StringLength(55)]
        public string Acceptance { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        [StringLength(55)]
        public string Time { get; set; }
        public User User{get;set;}
        public string UserId { get; set; }
        
    }
}