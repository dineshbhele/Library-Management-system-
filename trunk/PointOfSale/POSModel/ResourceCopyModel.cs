using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSModel
{
    public class ResourceCopyModel
    {
        public ResourceCopyModel()
        {
            IsAvailable = true;
        }
        public int ResourceCopyId { get; set; }
        public int GenerationId { get; set; }
        [DisplayName("Resource Name")]
        public int ResourceId { get; set; }
        [DisplayName("Resource Copy Count")]
        public int ResourceCopyCount { get; set; }
        [DisplayName("Resource Copy Number")]
        public string ResourceCopyNumber { get; set; }
        public string Remarks { get; set; }
        [DisplayName("Is Available")]
        public bool IsAvailable { get; set; } = true;
        [DisplayName("Published Date")]
        public DateTime PublishedDate { get; set; }
        public string Edition { get; set; }
        public int GenerationCopyCount { get; set; }
        public string ResourceName { get; set; }
        public DateTime ResourceGenerationDate { get; set; }
        public List<ResourceCopyModel> GetResourceCopiesList { get; set; }
    }
}
