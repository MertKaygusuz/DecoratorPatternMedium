using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.DbClasses
{
    public class Users
    {
        [Key]
        public string UserId { get; set; }

        [MaxLength(20)]
        public string Name { get; set; }

        [MaxLength(20)]
        public string Surname { get; set; }

        public ICollection<UserShoppingCarts> UserShoppingCarts { get; set; }
    }
}
