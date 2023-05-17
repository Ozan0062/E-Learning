﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;


[Table("Favorite")]
public partial class Favorite
{
    [Key]
    public int Id { get; set; }

    public int? UserId { get; set; }

    public int? CourseId { get; set; }

    [ForeignKey("CourseId")]
    [InverseProperty("Favorites")]
    public virtual Course Course { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("Favorites")]
    public virtual User User { get; set; }
}