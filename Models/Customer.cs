﻿namespace ODataFilterEnumExample.Models
{
    public class Customer
    {
        public int Id { get; set; }

        public string? Name { get; set; }    

        public string? Description { get; set; }

        public CustomerType? CustomerType { get; set; }
    }
}
