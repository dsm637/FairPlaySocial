﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FairPlaySocial.DataAccess.Models;

[Index("FromApplicationUserId", Name = "IX_UserMessage_FromApplicationUserId")]
[Index("ToApplicationUserId", Name = "IX_UserMessage_ToApplicationUserId")]
public partial class UserMessage
{
    [Key]
    public long UserMessageId { get; set; }

    public long FromApplicationUserId { get; set; }

    public long ToApplicationUserId { get; set; }

    [Required]
    public string Message { get; set; }

    public bool ReadByDestinatary { get; set; }

    [Required]
    [StringLength(250)]
    public string SourceApplication { get; set; }

    [Required]
    [StringLength(100)]
    public string OriginatorIpaddress { get; set; }

    public DateTimeOffset RowCreationDateTime { get; set; }

    [Required]
    [StringLength(256)]
    public string RowCreationUser { get; set; }

    [ForeignKey("FromApplicationUserId")]
    [InverseProperty("UserMessageFromApplicationUser")]
    public virtual ApplicationUser FromApplicationUser { get; set; }

    [ForeignKey("ToApplicationUserId")]
    [InverseProperty("UserMessageToApplicationUser")]
    public virtual ApplicationUser ToApplicationUser { get; set; }
}