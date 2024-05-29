namespace net_il_mio_fotoalbum.Models
{

    public class Recensione
    {
        public int Id { get; set; }
        public string? Email { get; set; }
        public string? Testo { get; set; }

        public Recensione() { }

        public Recensione(string email, string testo)
        {
            this.Email = email;
            this.Testo = testo;
        }
    }

}
