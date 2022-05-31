using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Technical_Test_Repository.Models;
using Technical_Test_Repository.Repository;

namespace Technical_Test_Repository.Controllers
{
    public class ProductsController : Controller
    {
        private IProductRepository _productRepository;

        // GET: Products
        public ProductsController()
        {
            _productRepository = new ProductRepository(new MasterSelDBContext());
        }
        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var model = _productRepository.GetAll();
            return View(model);
        }

        [HttpGet]
        public ActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddProduct(Product model)
        {
            if (ModelState.IsValid)
            {
                _productRepository.Insert(model);
                _productRepository.Save();
                return RedirectToAction("Index", "Products");
            }
            return View();
        }

        [HttpGet]
        public ActionResult EditProduct(int ProductID)
        {
            Product model = _productRepository.GetById(ProductID);
            return View(model);
        }
        [HttpPost]
        public ActionResult EditProduct(Product model)
        {
            if (ModelState.IsValid)
            {
                _productRepository.Update(model);
                _productRepository.Save();
                return RedirectToAction("Index", "Products");
            }
            else
            {
                return View(model);
            }
        }

        [HttpGet]
        public ActionResult DeleteProduct(int ProductID)
        {
            Product model = _productRepository.GetById(ProductID);
            return View(model);
        }
        [HttpPost]
        public ActionResult Delete(int ProductID)
        {
            _productRepository.Delete(ProductID);
            _productRepository.Save();
            return RedirectToAction("Index", "Products");
        }
    }
}