using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Caching;
using GruppG.Models.db;
using System.Data.Entity;

namespace GruppG.Data
{
    public class Repository<PlaceHolder> /*where PlaceHolder : U4Entities*/ //Gemensam "samlingsklass" av metoder mm för flera klasser
    {
        System.Runtime.Caching.ObjectCache cache = MemoryCache.Default;
        List<PlaceHolder> items;
        string className;
        DbSet dbSet;

        public Repository()
        {
            className = typeof(PlaceHolder).Name;  //Hämtar klassens riktiga namn
            items = cache[className] as List<PlaceHolder>;
            if (items == null)
            {
                items = new List<PlaceHolder>();
            }
        }

        public void Commit()
        {
            cache[className] = items;
        }

        

        public IQueryable<PlaceHolder> Collection()
        {
            return items.AsQueryable();
        }

        public void Delete(int id)
        {
            //var p = Find(id);
            //if (context.Entry(p).State == EntityState.Detached)
            //    dbSet.Attach(p);

            //dbSet.Remove(p);
        }
    }
}