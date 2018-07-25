using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Caching;

namespace GruppG.Data
{
    public class Repository<PlaceHolder>  //Gemensam "samlingsklass" av metoder mm för flera klasser
    {
        System.Runtime.Caching.ObjectCache cache = MemoryCache.Default;
        List<PlaceHolder> items;
        string className;

        public Repository()
        {
            className = typeof(PlaceHolder).Name;  //Hämtar klassens riktiga namn
            
        }
    }
}