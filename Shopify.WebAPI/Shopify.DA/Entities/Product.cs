using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Shopify.DA.Entities
{
    [Table("Product")]
    public partial class Product
    {
        public Product()
        {
            ProductImages = new HashSet<ProductImage>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public int BrandId { get; set; }
        [StringLength(75)]
        public string Description { get; set; }
        [Column(TypeName = "decimal(8, 3)")]
        public decimal Price { get; set; }
        public int Stock { get; set; }
        [Column(TypeName = "decimal(4, 2)")]
        public decimal Discount { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ExpiryDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedAt { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ModifiedAt { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid? ModifiedBy { get; set; }

        [ForeignKey(nameof(CategoryId))]
        [InverseProperty("Products")]
        public virtual Category Category { get; set; }
        [ForeignKey(nameof(CreatedBy))]
        [InverseProperty(nameof(User.ProductCreatedByNavigations))]
        public virtual User CreatedByNavigation { get; set; }
        [ForeignKey(nameof(ModifiedBy))]
        [InverseProperty(nameof(User.ProductModifiedByNavigations))]
        public virtual User ModifiedByNavigation { get; set; }
        [InverseProperty(nameof(ProductImage.Product))]
        public virtual ICollection<ProductImage> ProductImages { get; set; }
    }
}
