using CleanArchitecture.Application.DTOs;
using CleanArchitecture.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CleanArchitecture.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IWebHostEnvironment _enviroment;

        public ProductController(IProductService productService, ICategoryService categoryService, 
                                 IWebHostEnvironment enviroment)
        {
            _productService = productService;
            _categoryService = categoryService;
            _enviroment = enviroment;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetAll();
            return View(products);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.CategoryId = new SelectList(await _categoryService.GetAll(), "Id", "Name");
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(ProductDTO productDTO)
        {
            if (!ModelState.IsValid)
                return View(productDTO);

            await _productService.Create(productDTO);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit (int? id)
        {
            if (id is null) 
                return NotFound();

            var productDTO = await _productService.GetById(id);

            if (productDTO is null)
                return NotFound();

            ViewBag.CategoryId = new SelectList(await _categoryService.GetAll(), "Id", "Name", productDTO.CategoryId);

            return View(productDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProductDTO productDTO)
        {
            if (!ModelState.IsValid)
                return View(productDTO);

            await _productService.Update(productDTO);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null) return NotFound();

            await _productService.Delete(id);

           return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id is null)
                return NotFound();

            var productDto = await _productService.GetById(id);

            if (productDto is null)
                return NotFound();

            var images = Path.Combine(_enviroment.WebRootPath, "images\\" + productDto.Image);
            ViewBag.ImageExist = System.IO.File.Exists(images);

            return View(productDto);
        }
    }
}
