using sistema_fichas.Business;
using sistema_fichas.Repository.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace sistema_fichas.Repository
{
    public class ContactoRepository : GenericRepository<Contacto>, IContactoRepository
    {
        public ContactoRepository(DbContext _context) : base(_context) { }

        public Contacto GetById(int Id) {
            return FindBy(x => x.ID == Id).FirstOrDefault();
        }

        public IEnumerable<Contacto> GetAll(bool? OnlyActives) 
        {
            if (OnlyActives.Value)
                return FindBy(x => x.Estado != 0);
            else
                return GetAll();
        }

        public IEnumerable<Contacto> GetAllByClienteId(int Id, bool? OnlyActives = true)
        {
            if (OnlyActives.Value)
                return FindBy(x => x.Estado != 0 && x.Cliente_ID == Id);
            else
                return GetAll();
        }

        public IEnumerable<Contacto> GetAllByCriteria(string attributeName, string attributeValue) 
        {
            ParameterExpression model = Expression.Parameter(typeof(Contacto), "x");
            Expression attribute = Expression.Property(model, attributeName);
            Expression value = Expression.Constant(attributeValue);
            Expression search = Expression.Call(attribute, "Contains", null, value);

            Expression<Func<Contacto, bool>> lambda = Expression.Lambda<Func<Contacto, bool>>(search, model);
            return FindBy(lambda);
        }

    }
}
