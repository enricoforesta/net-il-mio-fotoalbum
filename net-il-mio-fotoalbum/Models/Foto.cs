using System.ComponentModel.DataAnnotations;

namespace net_il_mio_fotoalbum.Models
{
    public class Foto
    {
        [Key]
        public int Id { get; set; }
        public string? Titolo { get; set; }
        public string? Descrizione { get; set; }
        public bool Visibile { get; set; }

        public byte[]? ImageFile { get; set; }
        public string ImgSrc => ImageFile != null ? $"data:image/png;base64,{Convert.ToBase64String(ImageFile)}" : "";

        // classe ingredienti con collegamento N-N
        public List<Categoria> Categoria { get; set; }

        public Foto() { }

        public Foto(string? titolo, string? descrizione, bool visibile, List<Categoria> categoria)
        {
            this.Titolo = titolo;
            this.Descrizione = descrizione;
            this.Visibile = visibile;
            this.Categoria = categoria;
        }
        // funzione che mi stampi tutte le categorie
        public string TutteLeCategorie()
        {
            return string.Join(", ", Categoria.Select(c => c.Nome));
        }
    }

}
