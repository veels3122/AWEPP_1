﻿using AWEPP.Model;
using AWEPP.Modelo;
using System.ComponentModel.DataAnnotations;
namespace AWEPP.Modelo
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required string PhoneNumber { get; set; }
        public required string UserName { get; set; }
        public required string date { get; set; }
        public required string Modified { get; set; }
        public required string ModifiedBy { get; set; }
        public virtual required Usertype Usertype { get; set; }
        public virtual required TypeAcces TypeAcces { get; set; }
        public virtual required TypeAccesUser TypeAccesUser { get; set; } 
        public required bool IsDeleted { get; set; }
    }
}
