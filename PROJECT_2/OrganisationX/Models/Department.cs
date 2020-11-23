using System;
using System.Collections.Generic;

namespace OrganisationX.Models
{
    public partial class Department
    {
        public string DepartmentId { get; set; }
        public string DepartmentType { get; set; }
        public string BusinessTravel { get; set; }
        public string JobRole { get; set; }
        public int? JobLevel { get; set; }
        public int? JobInvolve { get; set; }
    }
}
