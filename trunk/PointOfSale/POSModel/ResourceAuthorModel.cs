﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSModel
{
    public class ResourceAuthorModel
    {
        public int AuthorId { get; set; }
        public string Author { get; set; }
        public int Nationality { get; set; }
        public string Genere { get; set; }

        [Display(Name = "Is Active")]
        public bool IsActive { get; set; } = true;
        [Display(Name = "Created Date")]
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        [Display(Name = "Modified Date")]
        public Nullable<DateTime> ModifiedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }

        public string CountryName { get; set; }

        public List<ResourceAuthorModel> ResourceAuthorList { get; set; }
    }
}
