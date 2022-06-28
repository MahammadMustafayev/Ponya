using Ponya_Back.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ponya_Back.ViewModel.AboutViewModel
{
    public class AboutVM
    {
        public List<AboutUs> AboutUs { get; set; }
        public List<Proggress> Proggresses { get; set; }
        public List<OurTeam> OurTeams { get; set; }
    }
}
