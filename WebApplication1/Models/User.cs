using System.Collections;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Account> Accounts { get; set; } = new List<Account>();
    }
}