using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Customers
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsSubscribed { get; set; }
        public MemberShipType MemberShipType { get; set; }
        public byte MemberShipTypeId { get; set; }
        [Display (Name = "Date of Birth")]
        public DateTime? DateofBirth {get; set;}
    }
}