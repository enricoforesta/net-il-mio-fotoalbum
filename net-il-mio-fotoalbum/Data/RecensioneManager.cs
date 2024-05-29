using net_il_mio_fotoalbum.Models;

namespace net_il_mio_fotoalbum.Data
{
    public static class RecensioneManager
    {
        public static void InserisciRecensione(Recensione recensione)
        {
            using FotoContext db = new FotoContext();
            db.Recensione.Add(recensione);
            db.SaveChanges();

        }
    }
}
