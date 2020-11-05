﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSModel
{
    public class GradeModel
    {
        public int GradeId { get; set; }

        [DisplayName("Grade Name English")]
        public string GradeNameEng { get; set; }

        [DisplayName("Grade Name Nepali")]
        public string GradeNameNep { get; set; }
        public string Remarks { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public Nullable<int> UpdatedBy { get; set; }

        [DisplayName("Is Active")]
        public bool IsActive { get; set; } = true;
        public List<GradeModel> GradeList { get; set; }
    
    }
}
