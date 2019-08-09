using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Selling
    {
        public Guid SellingId { get; set; }
        public Guid ClientId { get; set; }
        public Guid ProductID { get; set; }
        public string Total { get; set; }
    }
}
