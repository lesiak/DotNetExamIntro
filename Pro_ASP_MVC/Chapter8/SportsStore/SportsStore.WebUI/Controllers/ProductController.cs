﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportsStore.Domain.Abstract;
using SportsStore.WebUI.Models;

namespace SportsStore.WebUI.Controllers {
    public class ProductController : Controller {
        private IProductRepository repository;
        public int PageSize = 4;

        public ProductController(IProductRepository repository) {
            this.repository = repository;
        }

        // GET: Product
        public ViewResult List(string category, int page = 1) {
            ProductsListViewModel model = new ProductsListViewModel {
                Products = repository.Products
                    .Where(p => category == null || p.Category == category)
                    .OrderBy(p => p.ProductID)
                    .Skip((page - 1)*PageSize)
                    .Take(PageSize),
                PagingInfo = new PagingInfo {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = category == null
                        ? repository.Products.Count()
                        : repository.Products.Count(e => e.Category == category)
                },
                CurrentCategory = category
            };
            return View(model);
        }
    }
}