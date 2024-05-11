﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UE.STOREDB.DOMAIN.Core.DTO
{
    public class CategoryDTO
    {
        public int Id { get; set; }

        public string? Description { get; set; }

        public bool? IsActive { get; set; }
    }

    public class CategoryListDTO 
    {
        public int Id { get; set; }
        public string? Description { get; set; }
    }

    public class CategoryProductstDTO
    {
        public int Id { get; set; }
        public string? Description { get; set; } 
        public ICollection<ProductListDTO> Products { get; set; }
    }

    public class CategoryCreateDTO
    {
        public string? Description { get; set; }
    }


}
