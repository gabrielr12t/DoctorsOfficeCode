using DoctorsOffice.Core.Models.Base;
using System;
using System.Collections.Generic;

namespace DoctorsOffice.Core.Models
{
    public class Patient : ModelBase
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
