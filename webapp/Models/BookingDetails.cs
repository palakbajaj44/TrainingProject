using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapp.Models
{
    public class BookingDetails
    {

        [Key]
        public int UserId { get; set; }
        [Required]

        [Column(TypeName = "nvarchar(50)")]
        public string Name { get; set; }
        [Required]

        [Column(TypeName = "nvarchar(100)")]
        public string EventName { get; set; }
        [Required]

        public int NoOfTickets { get; set; }
        [Required]

        [Column(TypeName = "nvarchar(100)")]
        public string EventLocation { get; set; }
        [Required]

        public DateTime BookingDate { get; set; }
        




    } }