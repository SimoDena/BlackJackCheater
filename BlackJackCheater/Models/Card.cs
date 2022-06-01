using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlackJackCheater.Models
{
    public class Card
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int Value { get; set; }

        public int Occurences { get; set; }

        [ForeignKey("IdMatch")]
        public Match Match { get; set; }
        public string IdMatch { get; set; }
    }
}
