using Microsoft.AspNetCore.Mvc;
using MVC_Prueba.Models;
using MVC_Prueba.Models.Data;

namespace MVC_Prueba.Controllers
{
    public class PdfController : Controller
    {
        private readonly IPdfService _pdfService;
        public PdfController(IPdfService pdfService)
        {
            _pdfService = pdfService;
        }

        public IActionResult IndexPdf()
        {
            var viewModel = ObtenerProductos();
            return View("IndexPdf", viewModel);
        }

        public IActionResult DescargarPdf(int id)
        {
            //
            var producto = ObtenerProductos().Find(p => p.Id == id);
            if (producto == null) return NotFound();
            var pdfBytes = _pdfService.GenerateProductPDF(producto);
            return File(pdfBytes, "application/pdf", $"{producto.Nombre}.pdf");
        }
        public static List<ProductViewModel> ObtenerProductos()
        {
            return new List<ProductViewModel>
            {
                new ProductViewModel{ Id=1, Nombre="maquina temporal", Descripcion="Esta es la descripcion del producto", Precio=20.99m, Stock=100, Categoria="Categoria 1" },
                new ProductViewModel{ Id=2, Nombre="varita de sauco", Descripcion="Esta es la Descripcion del producto 1", Precio=20.99m, Stock=100, Categoria="Categoria 1" },
                new ProductViewModel{ Id=3, Nombre="delorian", Descripcion="Esta es la Descripcion del producto 1", Precio=20.99m, Stock=100, Categoria="Categoria 1" },
                new ProductViewModel{ Id=4, Nombre="alcon milenario", Descripcion="Esta es la Descripcion del producto 1", Precio=20.99m, Stock=100, Categoria="Categoria 1" },
                new ProductViewModel{ Id=5, Nombre="pc cuantica", Descripcion="Esta es la Descripcion del producto 1", Precio=20.99m, Stock=100, Categoria="Categoria 1" }
            };
        }
    }
}
