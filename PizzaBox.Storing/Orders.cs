using System;
using System.Collections.Generic;

namespace PizzaBox.Storing
{
    public partial class Orders
    {
        public Orders()
        {
            Pizza = new HashSet<Pizza>();
        }

        public int OrderId { get; set; }
        public int ConfirmedUserId { get; set; }
        public int ConfirmedStoreId { get; set; }
        public decimal Price { get; set; }
        public DateTime OrderDate { get; set; }

        public virtual Store ConfirmedStore { get; set; }
        public virtual Users ConfirmedUser { get; set; }
        public virtual ICollection<Pizza> Pizza { get; set; }
    }
}
