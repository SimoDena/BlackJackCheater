using System;
using System.ComponentModel.DataAnnotations;

namespace BlackJackCheater.Models
{
    public class Match
    {
        [Key]
        public string IdMatch { get; set; }

        public DateTimeOffset CreationTime { get; set; }

        public int NumberOfUsers { get; set; }
    }
}
