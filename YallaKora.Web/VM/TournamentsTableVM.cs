﻿using DTOs;
using DTOs.ApplicationDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YallaKora.Web.VM
{
    public class TournamentsTableVM
    {
        public List<TournamentDto> Tournaments { get; set; }
        public SearchTerms Search { get; set; }
        public Pager Pager { get; set; }
    }
}
