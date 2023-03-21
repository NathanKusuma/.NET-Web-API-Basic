using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Models
{
    public class HeaderTransaction
    {
        public int Id { get; set; }
        public DateTime TransactionDate { get; set; }
        public int UserId { get; set; }
        public int DetailId { get; set; }
    }

}