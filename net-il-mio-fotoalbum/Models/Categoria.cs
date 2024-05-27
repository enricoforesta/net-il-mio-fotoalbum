using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.ComponentModel.DataAnnotations;

namespace net_il_mio_fotoalbum.Models
{
    public class Categoria
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public List<Foto> Foto { get; set; }

        public Categoria() { }
        public Categoria(string nome, List<Foto> foto) {
            this.Nome = nome;
            this.Foto = foto;
        }
       

    }
}
