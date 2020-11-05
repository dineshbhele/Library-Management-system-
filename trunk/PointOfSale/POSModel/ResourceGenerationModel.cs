using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace POSModel
{
    public class ResourceGenerationModel
    {
        public ResourceGenerationModel()
        {
            IsAvailable = true;
        }
        public int GenerationId { get; set; }
        [DisplayName("Resource Name")]
        public int ResourceId { get; set; }
        [DisplayName("Generation Date")]
        public DateTime GenerationDate { get; set; }
        [DisplayName("Generation Copy Count")]
        public int GenerationCopyCount { get;  set; }
        public string Remarks { get; set; }

        public int ResourceCopyId { get; set; }
        public string ResourceName { get; set; }
        public int PublicationId { get; set; }

        public bool IsAvailable { get; set; } = true;

        public string GenerationDateNepali { get; set; }


        public List<ResourceGenerationModel> GetResourceGenerationList { get; set; }
    }
}
