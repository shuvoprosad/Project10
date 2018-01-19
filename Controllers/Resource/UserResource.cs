using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Project10.Controllers.Resource
{
    public class UserResource
    {
        [Required]
        [StringLength(100)]
        public string username { get; set; }
        [Required]
        [EmailAddress]
        public string email { get; set; }
        [Required]
        [StringLength(100)]
        public string phone { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string password { get; set; }

        public ICollection<RoomResource> Rooms { get; set; }

        public UserResource()
        {
            Rooms = new Collection<RoomResource>();
        }
    }
}