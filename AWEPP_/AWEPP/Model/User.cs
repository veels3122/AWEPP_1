﻿using AWEPP.Model;
using System.ComponentModel.DataAnnotations;

namespace AWEPP.Modelo
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Passaword { get; set; }
        public required string PhoneNumber { get; set; }
        public required string UserName { get; set; }
        public required string date { get; set; }
        public required string Modified { get; set; }
        public required string ModifiedBy { get; set; }
        public virtual required int UsertypeId { get; set; }
        public virtual required int TypeAccesId { get; set; }
        public virtual required int TypeAccesUserId { get; set; }
    }
}
