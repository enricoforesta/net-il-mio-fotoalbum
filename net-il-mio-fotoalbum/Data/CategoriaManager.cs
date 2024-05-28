using net_il_mio_fotoalbum.Models;

namespace net_il_mio_fotoalbum.Data
{
    public static class CategoriaManager
    {

        public static List<Categoria> TutteCategorie()
        {
            using FotoContext db = new FotoContext();

            return db.Categoria.ToList();
        }

        public static void InserisciCategoria(Categoria categoria)
        {
            using FotoContext db = new FotoContext();
            db.Categoria.Add(categoria);
            db.SaveChanges();
        }

         public static bool EliminaCategoria(int id)
        {
            using FotoContext db = new FotoContext();
            var categoriaDaEliminare = db.Categoria.FirstOrDefault(c => c.Id == id);
            if (categoriaDaEliminare == null)
                return false;
            db.Categoria.Remove(categoriaDaEliminare);
            db.SaveChanges();
            return true;
        }
    }
}
