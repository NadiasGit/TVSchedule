﻿using System;
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
        public string Channel { get; set; }
        public bool Recommend { get; set; }


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