using Microsoft.AspNetCore.Mvc.Rendering;
using net_il_mio_fotoalbum.Data;

namespace net_il_mio_fotoalbum.Models
{
    public class FotoFormModel
    {
        public Foto? Foto { get; set; }
        public List<SelectListItem>? Categorie { get; set; }
        public List<string>? SelezionaCategorie { get; set; }

        public IFormFile? ImageFormFile { get; set; }

        public FotoFormModel()
        {
            
        }
        public FotoFormModel(Foto foto,  List<SelectListItem> categorie)
        {
            this.Foto = foto;
            this.Categorie = categorie;
            this.SelezionaCategorie = foto.Categorie?.Select(c => c.Id.ToString()).ToList() ?? new List<string>();
        }


        public static List<SelectListItem> CreaCategorie()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            var categorie = CategoriaManager.TutteCategorie(); 
            foreach (var item in categorie)
            {
                list.Add(new SelectListItem(item.Nome, item.Id.ToString()));
            }
            return list;
        }

        public byte[] SetImage()
        {
            if (ImageFormFile == null)
                return null;

            using var stream = new MemoryStream();
            this.ImageFormFile?.CopyTo(stream);
            Foto.ImageFile = stream.ToArray();

            return Foto.ImageFile;
        }

    }
}
