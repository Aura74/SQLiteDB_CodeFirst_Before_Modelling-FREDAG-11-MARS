using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SeidoDemoModels
{
    public class Order // Pärla
    {
        public const int basePrice = 50;

        [Key]
        [Column("OrderID")]
        public Guid OrderID { get; set; }
        //public int OrderID { get; set; }

        [Column("CustomerID")]
        public Guid CustomerID { get; set; }
        //public int CustomerID { get; set; }

        [Column(TypeName = "nvarchar (200)")]
        public string Comment { get; set; }


        public int Diameter { get; set; }
        public string Color { get; set; }
        public string Shape { get; set; }
        public string Type { get; set; }

        public int Price { get; set; } //= basePrice;
        //private int price;
        //public int Price
        //{
        //    get
        //    {
        //        if (Type == "Saltvatten")
        //        {
        //            return basePrice * Diameter * 2;
        //        }
        //        else
        //        {
        //            return basePrice * Diameter;
        //        }
        //    }
        //    set { Price = value; }
        //}
        
        public Order(Guid CustomerID)
        {
            var rnd = new Random();

            OrderID = Guid.NewGuid();
            this.CustomerID = CustomerID;
            Comment = $"{OrderID} specific comment for Customer {CustomerID}";

            string[] _color = "Svart Vit Rosa".Split(' ');
            this.Color = _color[rnd.Next(0, _color.Length)];

            string[] _shape = "Rund Droppformad".Split(' ');
            this.Shape = _shape[rnd.Next(0, _shape.Length)];

            string[] _type = "Sötvatten Saltvatten".Split(' ');
            this.Type = _type[rnd.Next(0, _type.Length)];

            int _size = rnd.Next(5, 26);
            this.Diameter = _size;

            int price = 0;
            if (Type == "Saltvatten")
            {
                price = basePrice * Diameter * 2;
            }
            else
            {
                price = basePrice * Diameter;
            }
            this.Price = price;
            }
        //set { Price = value; }
    }
}
//}
