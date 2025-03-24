using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Inc.Accounts.DAL.Models;

public partial class Email
{
    [Key]
    public Guid Id { get; set; }

    public Guid AccountId { get; set; }

    [StringLength(350)]
    [Unicode(false)]
    public string Address { get; set; } = null!;

    public bool? IsPrimary { get; set; }

    public bool IsVerified { get; set; }

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
    [InverseProperty("Emails")]
    public virtual Account Account { get; set; } = null!;
}
