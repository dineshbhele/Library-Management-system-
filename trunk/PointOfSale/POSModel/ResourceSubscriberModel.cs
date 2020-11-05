﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSModel
{
    public class ResourceSubscriberModel
    {
        public int SubscriberId { get; set; }

        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Middle Name")]
        public string MiddleName { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [DisplayName("Is Student")]
        public bool IsStudent { get; set; } = true;

        [DisplayName("Is Employee")]
        public bool IsEmployee { get; set; } = true;

        [DisplayName("Is Active")]
        public bool IsActive { get; set; } = true;
        public System.DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public System.DateTime MemberDate { get; set; }

        [DisplayName("Membership Number")]
        public int MembershipNumber { get; set; }

        public List<ResourceSubscriberModel> ResourceSubscriberList { get; set; }
    }
}
