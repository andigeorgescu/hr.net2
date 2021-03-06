﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Personal.Entities
{
    [Table("Location", Schema = "HR")]
    public class Location
    {
      
        public int LocationId { get; set; }
        public string StreetAddress { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string StateProvince { get; set; }
    }
}
