using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Inventory
    {
        public Guid InventoryId { get; set; }
        public Guid ProductID { get; set; }
        public int Quantity { get; set; }
    }
}
