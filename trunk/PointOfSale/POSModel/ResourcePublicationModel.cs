﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSModel
{
    public class ResourcePublicationModel
    {
        public int PublicationId { get; set; }
        public string Publisher { get; set; }
        [DisplayName("Publisher Origin")]
        public int PublisherOrigin { get; set; }
        public string Genere { get; set; }

        [Display(Name = "Is Active")]
        public bool IsActive { get; set; } = true;
        [DisplayName("Created Date")]
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public Nullable<DateTime> ModifiedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public string CountryName { get; set; }

        public List<ResourcePublicationModel> ResourcePublicationList { get; set; }
    }
}
