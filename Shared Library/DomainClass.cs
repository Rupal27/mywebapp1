using System;
using System.ComponentModel.DataAnnotations;
using Shared_Library.Interface;

namespace Shared_Library
{
    public class DomainClass : IDomain
    {
        [Required]
        public int ID { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime CreatedOn { get; set; }

        [Required]
        [DataType((DataType.Date))]
        public DateTime ModifiedOn { get; set; }
    }
}
