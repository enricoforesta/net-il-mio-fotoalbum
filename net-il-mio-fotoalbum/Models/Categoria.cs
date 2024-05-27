using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace net_il_mio_fotoalbum.Models
{
    public class Categoria
    {
        public string Nome { get; set; }
        public List<Foto> fotos { get; set; }

        public Categoria() { }
        public Categoria(string nome, List<Foto> fotos) {
            this.Nome = nome;
            this.fotos = fotos;
        }
    }
}
