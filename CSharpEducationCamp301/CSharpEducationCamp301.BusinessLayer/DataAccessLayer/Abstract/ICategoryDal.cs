using CSharpEducationCamp301.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpEducationCamp301.DataAccessLayer.Abstract
{
    public interface ICategoryDal : IGenericDal<Category>
    {
        void Delete(Category entity);
    }
}
