﻿using System.ComponentModel.DataAnnotations;

namespace AWEPP.Model
{
    public class TypeProducts
    {
        [Key]
        public int Id { get; set; }
        public required int Product { get; set; }
        public required string Description { get; set; }

    }
}
