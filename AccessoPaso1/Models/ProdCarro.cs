using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AccessoPaso1.Models;

namespace AccessoPaso1.Controllers
{
    public class ProdCarro
    {
        private contextTienda db = new contextTienda();
        private List<Producto> products;
        public ProdCarro()
        {
            products = db.Productoes.ToList();
        }
        public List<Producto> findAll()
        {
            return this.products;
        }
        public Producto find(int id)
        {
            Producto pp = this.products.Single(p => p.Id_producto.Equals(id));
            return pp;
        }
    }
}