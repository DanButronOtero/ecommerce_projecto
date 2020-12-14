using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AccessoPaso1.Models;
namespace AccessoPaso1.Models
{
    public class Item
    {
        public Producto Product
        {
            get;
            set;
        }
        public int Cantidad
        {
            get;
            set;
        }
    }
}