using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AccessoPaso1.Models;

namespace AccessoPaso1.Controllers
{
    

    public class CatalogoController : Controller
    {
        private contextTienda db = new contextTienda();
        // GET: Catalogo
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult BuscaProd(string nomBuscar)
        {
            ViewBag.SearchKey = nomBuscar;
            using (db)
            {
                var query = from st in db.Productoes
                            where st.nombre.Contains(nomBuscar)

                            select st;
                var listProd = query.ToList();
                ViewBag.Listado = listProd;
            }
            return View();
        }

        public ActionResult prodCategoria(int idCat)
        {
            List<Producto> mercancia = null;
            var query = from p in db.Productoes
                        where p.id_categoria == idCat
                        select p;
            if(idCat == 1)
            {
                // List<producto> lacteos = query.ToList();
                mercancia = query.ToList();
                ViewBag.Catego = "Lacteos";
            }
            if(idCat == 2)
            {
                // List<producto> carnes =  query.ToList();
                mercancia = query.ToList();
                ViewBag.Catego = "Carnes";
            }
            if (idCat == 2)
            {
                // List<producto> carnes =  query.ToList();
                mercancia = query.ToList();
                ViewBag.Catego = "Panaderia";
            }
            if (idCat == 2)
            {
                // List<producto> carnes =  query.ToList();
                mercancia = query.ToList();
                ViewBag.Catego = "Frutas y Vegetales";
            }
            ViewBag.productos = mercancia;
            return View();
        }
    }
}