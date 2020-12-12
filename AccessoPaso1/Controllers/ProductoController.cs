using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AccessoPaso1.Models;

namespace AccessoPaso1.Controllers
{
    public class ProductoController : Controller
    {
        private contextTienda db = new contextTienda();

        // GET: Producto
        public ActionResult Index()
        {
            var producto = db.Productoes.Include(p => p.Categoria);
            return View(producto.ToList());
        }

        // GET: Producto/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = db.Productoes.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        // GET: Producto/Create
        public ActionResult Create()
        {
            ViewBag.id_categoria = new SelectList(db.Categorias, "Id_categoria", "nombre");
            return View();
        }

        // POST: Producto/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_producto,nombre,descripcion,precio,imgen,existencia,stock,id_categoria")] Producto producto)
        {
            if (ModelState.IsValid)
            {
                db.Productoes.Add(producto);
                db.SaveChanges();
                int id = producto.Id_producto;
                var prod = db.Productoes.Find(id);
                DateTime hoy = DateTime.Now;
                prod.ult_actualizacion = hoy;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_categoria = new SelectList(db.Categorias, "Id_categoria", "nombre", producto.id_categoria);
            return View(producto);
        }

        // GET: Producto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = db.Productoes.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_categoria = new SelectList(db.Categorias, "Id_categoria", "nombre", producto.id_categoria);
            return View(producto);
        }

        // POST: Producto/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_producto,nombre,descripcion,precio,ult_actualizacion,imgen,existencia,stock,id_categoria")] Producto producto)
        {
            if (ModelState.IsValid)
            {
                int id = producto.Id_producto;
                var prod = db.Productoes.Find(id);
                decimal precio_ant = prod.precio;
                decimal precio_act = producto.precio;
                // db.Entry(producto).State = EntityState.Modified;
                prod.nombre = producto.nombre;
                prod.descripcion = producto.descripcion;
                prod.precio = producto.precio;
                prod.imgen = producto.imgen;
                prod.existencia = producto.existencia;
                prod.stock = producto.stock;
                prod.id_categoria = producto.id_categoria;
                if (precio_act != precio_ant)
                {
                    DateTime hoy = DateTime.Now;
                    prod.ult_actualizacion = hoy;
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_categoria = new SelectList(db.Categorias, "Id_categoria", "nombre", producto.id_categoria);
            return View(producto);
        }

        // GET: Producto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = db.Productoes.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        // POST: Producto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Producto producto = db.Productoes.Find(id);
            db.Productoes.Remove(producto);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
