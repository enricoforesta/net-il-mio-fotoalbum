﻿using Microsoft.EntityFrameworkCore;
using net_il_mio_fotoalbum.Models;

namespace net_il_mio_fotoalbum.Data
{
    public static class FotoManager
    { // Todo da fare poi i metodi che prende tutte le foto, tutte le categorie, inserire la foto, modificare la foto, eliminare la foto
        public static List<Foto> TutteFoto()
        {
            using FotoContext db = new FotoContext();

            return db.Foto?.ToList();
        }

        public static Foto CercaPerId(int id, bool include = true)
        {
            using FotoContext db = new FotoContext();
            if (include)
            {
                return db.Foto?.Where(f => f.Id == id).Include(f => f.Categorie).FirstOrDefault();
            }
            return db.Foto?.FirstOrDefault(f => f.Id == id);
        }


        public static void InserisciFoto(Foto foto, List<string> categorie)
        {
            using FotoContext db = new FotoContext();
            foto.Categorie = db.Categoria.Where(c => categorie.Contains(c.Id.ToString())).ToList();
            db.Foto.Add(foto);
            db.SaveChanges();
        }

        public static bool ModificaFoto(int id, string titolo, string descrizione, bool visibile, List<string> selezionaCategorie, byte[] immagine)
        {
            using FotoContext db = new FotoContext();
            var fotoDaModificare = db.Foto.Where(f => f.Id == id).Include(f => f.Categorie).FirstOrDefault();
            if (fotoDaModificare == null)
                return false;
            fotoDaModificare.Titolo = titolo;
            fotoDaModificare.Descrizione = descrizione;
            fotoDaModificare.Visibile = visibile;
            fotoDaModificare.Categorie.Clear();
            fotoDaModificare.Categorie = db.Categoria.Where(c => selezionaCategorie.Contains(c.Id.ToString())).ToList();
            if (immagine != null)
                fotoDaModificare.ImageFile = immagine;
            db.SaveChanges();
            return true;

        }

        public static bool EliminaFoto(int id)
        {
            using FotoContext db = new FotoContext();
            var fotoDaEliminare = db.Foto.FirstOrDefault(f => f.Id == id);
            if (fotoDaEliminare == null)
                return false;
            db.Foto.Remove(fotoDaEliminare);
            db.SaveChanges();
            return true;
        }

    }
}
