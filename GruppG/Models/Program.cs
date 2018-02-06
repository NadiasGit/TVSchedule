using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GruppG.Models
{
    public class Program
    {
        public int ProgramId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Day { get; set; }
        public DateTime Time { get; set; }
        public string Category { get; set; }
        public int Channel { get; set; }  //Foreign Key)
        public bool Recommend { get; set; }

        /* 2018-02-06 To do:
        Starttime
        Endtime
        Programstart

        Red ut om vi behöver alla tre. Lägg därefter in properties här i Program (model)...
        Det som vi vill visa i Index är:

        Programtitel / Tid / Kanal (mer info) */



        //Properties (information) som ska vara med enl upg (samma som i upg 3)   Du får gärna döpa om till bättre namn om du vill :D
        //    *Titel/namn/program
        //    *Beskrivning
        //    *Tid (datum och tid kanske blir samma property?)
        //    *Datum (startdatum = inlämningsdatum och en vecka framåt)
        //    *Längd
        //    *Kanal (vi ska ha minst 5 kanaler)
        //    *Kategori
        //    *Behöver vi ev: populär/rekomenderad (ej krav)
    }
}