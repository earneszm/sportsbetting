using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace sportsbetting.Models
{
    public class CreateBet
    {
        public string Team1 { get; set; }
        public string Team2 { get; set; }

        [Required]
        public decimal? Spread { get; set; }
        [Required]
        public int? Line { get; set; }

        public List<SelectListItem> TeamList { get; set; }

        public CreateBet()
        {
            TeamList = StaticData.Teams.Select(x => new SelectListItem() { Value = x.Key.ToString(), Text = x.Value.Name }).ToList();
        }
    }
}