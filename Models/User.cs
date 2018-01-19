using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Project10.Models;

namespace Project10.Models
{
    
    public class User:IdentityUser
    {
        
        public ICollection<Room> Rooms { get; set; }
    
        public User()
        {
            Rooms = new Collection<Room>();
        }
    }
}