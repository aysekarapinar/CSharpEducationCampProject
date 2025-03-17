using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpEducationCamp301.EntityLayer.Concrete
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public bool CategoryStatus { get; set; }
        public List<Product> Products { get; set; }

        public static implicit operator ValueTuple(Category v)
        {
            throw new NotImplementedException();
        }
    }
}
/*
    Field-Variable-Property
*/

/*
 * int x; --> Direkt sınıfın içine tanımlanırsa Field olur
*/
/*
 get, set alırsa Property olur.
 */
/*
 Bir değer method içinde tanımlanırsa Variable olur.
*/

