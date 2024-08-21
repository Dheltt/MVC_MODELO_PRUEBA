namespace MVC_Prueba.Models.Data
{
    public interface IPdfService
    {
        byte[] GenerateProductPDF(ProductViewModel productViewModel);
    }
}
