using sportsbetting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace sportsbetting.Controllers
{
    public class BetController : SportsBettingBaseController
    {

        public ActionResult Create()
        {
            var viewModel = new CreateBet();
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(CreateBet bet)
        {
            return View(bet);
        }
    }
}