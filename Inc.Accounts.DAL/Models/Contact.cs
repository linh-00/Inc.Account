using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Inc.Accounts.DAL.Models;

public partial class Contact
{
    [Key]
    public Guid Id { get; set; }

    public Guid AccountId { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string Type { get; set; } = null!;

    [StringLength(100)]
    [Unicode(false)]
    public string Value { get; set; } = null!;

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
    [InverseProperty("Contacts")]
    public virtual Account Account { get; set; } = null!;
}
