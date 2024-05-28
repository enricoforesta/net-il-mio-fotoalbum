using System.ComponentModel.DataAnnotations;

namespace net_il_mio_fotoalbum.Models
{
    public class Foto
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Il titolo è necessario")]
        [StringLength(40, ErrorMessage = "Il titolo deve avere max 40 caratteri")]
        public string Titolo { get; set; }
        [Required(ErrorMessage = "La descrizione è necessaria")]
        public string Descrizione { get; set; }
        public bool Visibile { get; set; }

        public byte[]? ImageFile { get; set; }
        public string ImgSrc => ImageFile != null ? $"data:image/png;base64,{Convert.ToBase64String(ImageFile)}" : "";

        // classe ingredienti con collegamento N-N
        public List<Categoria>? Categorie { get; set; }

        public Foto() { }

        public Foto(string titolo, string descrizione, bool visibile, List<Categoria> categorie)
        {
            this.Titolo = titolo;
            this.Descrizione = descrizione;
            this.Visibile = visibile;
            this.Categorie = categorie;
        }
        // funzione che mi stampi tutte le categorie
        public string TutteLeCategorie()
        {
            return string.Join(", ", Categorie.Select(c => c.Nome));
        }
    }

}
