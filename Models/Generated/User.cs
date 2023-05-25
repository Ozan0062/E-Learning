﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

[Table("User")]
public partial class User
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public string Email { get; set; }

    [Required]
    public string Password { get; set; }

    [Required]
    public string Address { get; set; }

    [Required]
    public string City { get; set; }

    public int PostalCode { get; set; }

    public int PhoneNumber { get; set; }

    [InverseProperty("User")]
    public virtual ICollection<ExerciseStatus> ExerciseStatuses { get; } = new List<ExerciseStatus>();

    [InverseProperty("User")]
    public virtual ICollection<Favorite> Favorites { get; } = new List<Favorite>();
}