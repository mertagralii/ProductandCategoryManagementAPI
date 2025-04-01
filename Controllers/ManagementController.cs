using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductandCategoryManagementAPI.Data;
using ProductandCategoryManagementAPI.Model;

namespace ProductandCategoryManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagementController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public ManagementController( DatabaseContext context)
        {
            _context = context;
        }

        #region Product CRUD İşlemler

        [HttpGet("ProductList")]
        public IActionResult ProductList() // Ürün Listeleme
        {
            var productList = _context.Products.Include(x => x.Category).ToList();

            if (productList == null)
            {
                return Ok("Herhangi bir ürün bulunamadı.");
            }
            return Ok(productList);
        }

        [HttpPost("CreateProduct")]
        public IActionResult CreateProduct([FromBody] Product product) // Ürün Ekleme
        {
            var Selectedcategory = _context.Categories.SingleOrDefault(x => x.Id == product.Category.Id);

            if (Selectedcategory == null)
            {
                return Ok("Seçtiğiniz Id'ye ait kategori bulunamadı.");
            }
            product.Category = Selectedcategory;

            var createdProduct = _context.Products.Add(product);
                
            if (createdProduct == null)
            {
                return Ok("Ürün eklenirken bir hata oluştu.");
            }
            _context.SaveChanges();
            return Ok("Ürün başarıyla eklendi.");
        }

        [HttpPut("UpdateProduct")]
        public IActionResult UpdateProduct([FromBody]Product product) // Ürün Güncelleme
        {
            var Selectedcategory = _context.Categories.SingleOrDefault(x => x.Id == product.Category.Id);

            if (Selectedcategory == null)
            {
                return Ok("Seçtiğiniz Id'ye ait kategori bulunamadı.");
            }

            var selectedProduct = _context.Products.SingleOrDefault(x => x.Id == product.Id);
            if (selectedProduct == null)
            {
                return Ok($"{product.Id}'li Ürün bulunamadı.");
            }
            selectedProduct.Name = product.Name;
            selectedProduct.Price = product.Price;
            selectedProduct.Category = Selectedcategory;
            _context.SaveChanges();
            return Ok("Ürün başarıyla güncellendi.");
        }

        [HttpDelete("DeleteProduct")]
        public IActionResult DeleteProduct(int Id) // Ürün Silme
        {
             var selectedProduct = _context.Products.SingleOrDefault(x => x.Id == Id);
            if (selectedProduct == null)
            {
                return Ok($"{Id}'li Silinecek Ürün bulunamadı.");
            }
            _context.Products.Remove(selectedProduct);
            _context.SaveChanges();
            return Ok("Ürün başarıyla silindi.");
        }
        #endregion

        #region Category CRUD İşlemler

        [HttpGet("CategoryList")]
        public IActionResult CategoryList()  // Kategori Listeleme
        {
            var categoryList = _context.Categories.ToList();
            if (categoryList == null)
            {
                return Ok("Kategori Bulunamadı");
            }
            return Ok(categoryList);
        }

        [HttpPost("CreateCategory")]
        public IActionResult CreateCategory([FromBody] Category category) // Kategori Ekleme
        {
            var createdCategory = _context.Categories.Add(category);
            if (createdCategory == null)
            {
                return Ok("Kategori eklenirken bir hata oluştu.");
            }
            _context.SaveChanges();
            return Ok("Kategori başarıyla eklendi.");
        }

        [HttpPut("UpdateCategory")]
        public IActionResult UpdateCategory([FromBody] Category category) // Kategori Güncelleme
        {
            var selectedCategory = _context.Categories.SingleOrDefault(x => x.Id == category.Id);
            if (selectedCategory == null)
            {
                return Ok($"{category.Id}'li Kategori bulunamadı.");
            }
            selectedCategory.CategoryName = category.CategoryName;
            _context.SaveChanges();
            return Ok("Kategori başarıyla güncellendi.");
        }

        [HttpDelete("DeleteCategory")]
        public IActionResult DeleteCategory(int Id) // Kategori Silme
        {
            var selectedCategory = _context.Categories.SingleOrDefault(x => x.Id == Id);
            if (selectedCategory == null)
            {
                return Ok($"{Id}'li Silinecek Kategori bulunamadı.");
            }
            _context.Categories.Remove(selectedCategory);
            _context.SaveChanges();
            return Ok("Kategori başarıyla silindi.");
        }


        #endregion

    }
}
