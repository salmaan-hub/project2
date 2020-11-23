﻿using System;
using System.Collections.Generic;

namespace OrganisationX.Models
{
    public partial class WorkRecord
    {
        public string WorkRid { get; set; }
        public string Promo { get; set; }
        public int? NumOfComp { get; set; }
        public int? YearsAtCurrComp { get; set; }
        public int? YearsRole { get; set; }
        public int? TotalWorkingYears { get; set; }
    }
}
