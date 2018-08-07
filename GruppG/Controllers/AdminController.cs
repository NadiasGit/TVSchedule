using GruppG.Data;
using GruppG.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GruppG.Controllers
{
    public class AdminController : Controller
    {
        private ProgramData pd = new ProgramData();
        ProgramChannelVM viewModel = new ProgramChannelVM();
        ProgramChannelVM finalItem = new ProgramChannelVM();

        // GET: Admin
        public ActionResult Index(DateTime? date, int? id = null)
        {
            //Visa en pufflista 

            //Lista på dagens program 
            //Filtrera datum och kanal


            var channel = viewModel.GetChannels();
            var program = viewModel.GetPrograms();

            if (date == null && id == null)
            {
                var programStart = program.Where(d => d.Programstart.Value.ToShortDateString() == viewModel.Today.ToShortDateString()).ToList();
                finalItem.ProgramListVM = programStart;
            }
            else if (date != null && id == null)
            {
                var programDate = program.Where(d => d.Programstart.Value.ToShortDateString() == date.Value.ToShortDateString()).OrderBy(d => d.Programstart).ToList();

                finalItem.ProgramListVM = programDate;
            }
            else if (date == null && id != null)
            {
                //Har bytt ut kategori mot kanal
                var programDate = program.Where(d => d.Programstart.Value.ToShortDateString() == viewModel.Today.ToShortDateString()).OrderBy(d => d.Programstart).Where(c => c.Chanel == id).ToList();

                finalItem.ProgramListVM = programDate;
            }
            else
            {
                var channelDate = program.Where(d => d.Programstart.Value.ToShortDateString() == date.Value.ToShortDateString()).OrderBy(d => d.Programstart).ToList();
                var progDate = channelDate.Where(c => c.Chanel == id).ToList();

                finalItem.ProgramListVM = progDate;
            }

            ViewBag.Message = ("Inget på TV idag :( ... ");

            finalItem.ChannelListVM = channel;
            //finalItem.CategoryListVM = cat;
            return View(finalItem);
        }

        //Create puff

        //Edit puffar

        //Delete puffar


    }
}