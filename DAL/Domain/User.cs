using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared_Library;

namespace DAL.Domain
{
    public class User : DomainClass
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string FullName { get; set; }
       
        internal void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
