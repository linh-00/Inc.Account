using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Inc.Accounts.DAL.Models;

[Table("Address")]
public partial class Address
{
    [Key]
    public Guid Id { get; set; }

    public Guid AccountId { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string Street { get; set; } = null!;

    [StringLength(13)]
    [Unicode(false)]
    public string Number { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string? Complement { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string Neighborhood { get; set; } = null!;

    [StringLength(100)]
    [Unicode(false)]
    public string City { get; set; } = null!;

    [StringLength(100)]
    [Unicode(false)]
    public string State { get; set; } = null!;

    [StringLength(100)]
    [Unicode(false)]
    public string Country { get; set; } = null!;

    [StringLength(20)]
    [Unicode(false)]
    public string ZipCode { get; set; } = null!;

    public bool IsPrimary { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [StringLength(150)]
    [Unicode(false)]
    public string CreatedBy { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [StringLength(150)]
    [Unicode(false)]
    public string? UpdatedBy { get; set; }

    [ForeignKey("AccountId")]
    [InverseProperty("Addresses")]
    public virtual Account Account { get; set; } = null!;
}
