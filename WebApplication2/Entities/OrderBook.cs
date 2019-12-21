using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Entities
{
    public class OrderBook
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Users")]
        public int UserId { get; set; }

        [ForeignKey(nameof(Books))]
        public int BookId { get; set; }

        public Users Users { get; set; }

        public Books Books { get; set; }

        public DateTime orderDate { get; set; }
    }
}