using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopify.DA.MapperObject
{
    public class GetImageMapper
    {
        public int ProductId { get; set; }
        public string Image { get; set; }
        public int Version { get; set; }
        public string FileName { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid CreatedBy { get; set; }

    }
}
