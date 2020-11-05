using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSModel
{
    public class ResourceTypeModel
    {
        public int ResourceTypeId { get; set; }
        [DisplayName("Resource Type Name")]
        public string ResourceTypeName { get; set; }
        [DisplayName("Resource Type Code")]
        public string ResourceTypeCode { get; set; }

        [Display(Name = "Is Active")]
        public bool IsActive { get; set; } = true;
        [DisplayName("Created Date")]
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public Nullable<DateTime> ModifiedDate { get; set; }
        public int? ModifiedBy { get; set; }

        public List<ResourceTypeModel> ResourceTypeList { get; set; }
    }
}
