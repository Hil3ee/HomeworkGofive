using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Homework.Models.Domain
{
    public class Register
    {
        [Key]
        public string username { get; set; }
        public string password { get; set; }

        
    }
}
