using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Shopify.DA.Entities
{
    [Keyless]
    [Table("RoleClaim")]
    public partial class RoleClaim
    {
        public Guid UserId { get; set; }
        [Required]
        [StringLength(450)]
        public string LoginProvider { get; set; }
        [Required]
        [StringLength(450)]
        public string Name { get; set; }
        public string Value { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; }
    }
}
