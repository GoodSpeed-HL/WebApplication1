using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Account
    {
        public int Id { get; set; }

        public string Type { get; set; }

        public double Balance { get; set; }

        [IgnoreDataMember]
        public User User { get; set; }
    }
}
