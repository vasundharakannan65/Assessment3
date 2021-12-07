using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Shopify.DA.Entities
{
    [Table("Product_Image")]
    public partial class ProductImage
    {
        [Key]
        public int Id { get; set; }
        public int ProductId { get; set; }
        [Required]
        [StringLength(250)]
        public string Image { get; set; }
        public int Version { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? FileName { get; set; }
        public bool IsActive { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedAt { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ModifiedAt { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid? ModifiedBy { get; set; }

        [ForeignKey(nameof(CreatedBy))]
        [InverseProperty(nameof(User.ProductImageCreatedByNavigations))]
        public virtual User CreatedByNavigation { get; set; }
        [ForeignKey(nameof(ModifiedBy))]
        [InverseProperty(nameof(User.ProductImageModifiedByNavigations))]
        public virtual User ModifiedByNavigation { get; set; }
        [ForeignKey(nameof(ProductId))]
        [InverseProperty("ProductImages")]
        public virtual Product Product { get; set; }
    }
}
