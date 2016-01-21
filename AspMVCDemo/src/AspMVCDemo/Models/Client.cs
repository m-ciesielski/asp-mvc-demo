using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspMVCDemo.Models
{
    public class Client
    {
        public int ID { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 2)]
        public string Name { get; set; }

        [StringLength(9, MinimumLength = 9)]
        public string NIP { get; set; }

        [StringLength(60, MinimumLength = 2)]
        public string Bank_account { get; set; }

        public virtual Address Address { get; set; }
    }
}
