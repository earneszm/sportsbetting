using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Eagle;

namespace sportsbetting.Controllers
{
    public class HomeController : SportsBettingBaseController
    {
        public ActionResult Index()
        {
            //using (FluentModel dataContext = new FluentModel())
            //{
            //    var bet = new Bet();
            //    bet.HomeTeam = "Siena";
            //    bet.AwayTeam = "Albany";
            //    bet.FinalScore = 100;

            //    dataContext.Add(bet);

            //    dataContext.SaveChanges();

            //    var newBet = dataContext.Bets.FirstOrDefault();

            //}

                return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}