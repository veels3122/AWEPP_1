﻿using System.ComponentModel.DataAnnotations;

namespace AWEPP.Model
{
    public class Contacts
    {
        [Key]
        public int Id { get; set; }
        public required string Contact { get; set; }
        public bool IsDeleted { get; internal set; }

    }
}
