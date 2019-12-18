using AmadeusShowcase.Service.DTOs;
using AmadeusShowcase.Service.Services;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Mvc;

namespace AmadeusShowcase.Web.Controllers
{
    public class SearchController : Controller
    {
        private readonly IAirportService aps;
        private readonly ICurrencyService cs;
        private readonly IFlightService fs;

        public SearchController(IAirportService aps, ICurrencyService cs, IFlightService fs)
        {
            this.aps = aps;
            this.cs = cs;
            this.fs = fs;
        }

        public ActionResult Index()
        {
            ViewBag.AirportFromId = new SelectList(aps.MapAirportsToDTO().AsEnumerable(), "Id", "Iata");
            ViewBag.AirportToId = new SelectList(aps.MapAirportsToDTO().AsEnumerable(), "Id", "Iata");
            ViewBag.CurrencyId = new SelectList(cs.MapCurrenciesToDTO().AsEnumerable(), "Id", "Code");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "Id,AirportFromId,AirportToId,DepartureDate,ReturnDate,NumOfPassengers,CurrencyId")] SearchDTO searchDTO)
        {
            searchDTO.AirportFrom = aps.GetAirportById(searchDTO.AirportFromId);
            searchDTO.AirportTo = aps.GetAirportById(searchDTO.AirportToId);
            searchDTO.Currency = cs.GetCurrencyById(searchDTO.CurrencyId);

            if (ModelState.IsValid)
            {
                try
                {
                    List<FlightDTO> flights = fs.FindFlights(searchDTO);
                    return View("Results", flights);
                }
                catch ()
                {
                    //neki mehanizam logiranja grešaka, npr:
                    //Logger.Log(e.StackTrace, ...)

                    //namapirati greške u neke user-friendly poruke i vratiti poruku u View


                    return View("Error");
                }
            }

            ViewBag.AirportFromId = new SelectList(aps.MapAirportsToDTO().AsEnumerable(), "Id", "Iata");
            ViewBag.AirportToId = new SelectList(aps.MapAirportsToDTO().AsEnumerable(), "Id", "Iata");
            ViewBag.CurrencyId = new SelectList(cs.MapCurrenciesToDTO().AsEnumerable(), "Id", "Code");
            return View();
        }
    }
}
