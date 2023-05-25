﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

[Table("ExerciseStatus")]
public partial class ExerciseStatus
{
    [Key]
    public int Id { get; set; }

    public int? UserId { get; set; }

    public int? ExerciseId { get; set; }

    public int? Status { get; set; }

    [ForeignKey("ExerciseId")]
    [InverseProperty("ExerciseStatuses")]
    public virtual Exercise Exercise { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("ExerciseStatuses")]
    public virtual User User { get; set; }
}