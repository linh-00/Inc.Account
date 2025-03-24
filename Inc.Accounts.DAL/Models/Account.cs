using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Inc.Accounts.DAL.Models;

[Table("Account")]
public partial class Account
{
    [Key]
    public Guid Id { get; set; }

    [StringLength(80)]
    [Unicode(false)]
    public string NickName { get; set; } = null!;

    [Unicode(false)]
    public string FullName { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime BirthDate { get; set; }

    [StringLength(1)]
    [Unicode(false)]
    public string? Gender { get; set; }

    public bool IsVerify { get; set; }

    [Unicode(false)]
    public string? ProfilePicture { get; set; }

    [InverseProperty("Account")]
    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();

    [InverseProperty("Account")]
    public virtual ICollection<Contact> Contacts { get; set; } = new List<Contact>();

    [InverseProperty("Account")]
    public virtual ICollection<Document> Documents { get; set; } = new List<Document>();

    [InverseProperty("Account")]
    public virtual ICollection<Email> Emails { get; set; } = new List<Email>();
}
