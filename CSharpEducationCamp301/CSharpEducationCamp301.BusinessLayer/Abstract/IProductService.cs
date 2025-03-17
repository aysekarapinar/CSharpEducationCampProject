﻿using CSharpEducationCamp301.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpEducationCamp301.BusinessLayer.Abstract
{
    public interface IProductService:IGenericService<Product>
    {
        void TDelete();
        List<object> TGetProductWithCategory();
    }
}
