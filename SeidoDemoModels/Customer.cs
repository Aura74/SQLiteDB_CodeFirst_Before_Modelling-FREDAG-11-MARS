using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SeidoDemoModels
{
    public class Customer
    {
        //List<Order> Orders = new List<Order>();

        [Key]
        [Column("CustomerID")]
        public Guid CustomerID { get; set; }
        //public int CustomerID { get; set; }

        [Column(TypeName = "nvarchar (200)")]
        public string Comment { get; set; }
        public int totalPrice { get; set; }

        public virtual List<Order> Orders { get; set; } = new List<Order>();

        //public int totalPrice
        //{
        //    get
        //    {
        //        var totalprice = 0;
        //        foreach (var x in Orders)
        //        {
        //            totalprice += x.Price;
        //        }
        //        return totalprice;
        //    }
        //}

        // Häs skapas id, Comments 
        public Customer() // halsband
        {
            CustomerID = Guid.NewGuid();
            Comment = $"{CustomerID} specific comment";

            var totalpriceTillfällig = 0;
            foreach (var x in Orders)
            {
                totalpriceTillfällig += x.Price;
            }
            //return totalprice;

            this.totalPrice = totalpriceTillfällig;
        }
    }
}
