using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace MVC_Prueba.Models.Data
{
    public class PDFService : IPdfService
    {
        public byte[] GenerateProductPDF(ProductViewModel productViewModel)
        {
            var document = Document.Create(Container => {
                Container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(2, Unit.Centimetre);
                    page.PageColor(Colors.White);
                    page.DefaultTextStyle(x => x.FontSize(20));
                    page.Header()
                        .Text("Detalles Del Producto")
                        .SemiBold().FontSize(36).FontColor(Colors.Blue.Medium);
                    page.Content()
                        .PaddingVertical(1, Unit.Centimetre)
                        .Column(x =>
                        {
                            x.Spacing(20);
                            x.Item().Text($"Nombre:{productViewModel.Nombre}").FontSize(15).Bold();
                            x.Item().Text($"Descripcion:").FontSize(15).Bold();
                            x.Item().Text($"{productViewModel.Descripcion}").FontSize(12).LineHeight(1.2f);
                            x.Item().Text($"Precio:{productViewModel.Precio}").FontSize(13).Bold();
                            x.Item().Text($"Stock:{productViewModel.Stock}").FontSize(13).Bold();
                            x.Item().Text($"Categoria:{productViewModel.Categoria}").FontSize(15).Bold();
                        });

                    page.Footer()
                        .AlignCenter()
                        .Text(x =>
                        {
                            x.Span("Page ");
                            x.CurrentPageNumber();
                        });
                });
            });
            using var stream = new MemoryStream();
            document.GeneratePdf(stream);
            return stream.ToArray();
        }
    }
}
