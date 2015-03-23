using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Web.Models
{
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [MaxLength(500)]
        public string Title { get; set; }

        [MaxLength(5000)]
        public string Foreword { get; set; }

        public int Pages { get; set; }

        public string Author { get; set; }
    }
}