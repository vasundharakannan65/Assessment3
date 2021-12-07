using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopify.DA.MapperObject
{
    public class ImageMapper
    {
        public int ProductId { get; set; }
        public IFormFile File { get; set; }
    }
}
