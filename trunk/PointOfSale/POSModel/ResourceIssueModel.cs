using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace POSModel
{
    public class ResourceIssueModel
    {

        public ResourceIssueModel()
        {
            IsAvailable = true;
            IsActive = true;

        }
        public int IssueId { get; set; }
        public int ResourceCopyId { get; set; }
        public System.DateTime IssueDate { get; set; }
        public System.DateTime ReturnBackDate { get; set; }
        public System.DateTime? ReturnedDate { get; set; }
        public string Remarks { get; set; }

        public bool IsActive { get; set; }
        public bool IsAvailable { get; set; } = true;
        //public int subscriber { get; set; }
        public string FirstName { get; set; }
        public string ResourceCopyNumber { get; set; }

        public int ResourceId { get; set; }
        [DisplayName("Resource Type Name")]
        
        public string ResourceTypeName { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public string GradeNameEng { get; set; }
        public string SubjectName { get; set; }
        public string SubId { get; set; }
        public int SubscriberId { get; set; }

        public int? AuthorId { get; set; }

        public int? GradeId { get; set; }

        public int? SubjectId { get; set; }

        public int? PublicationId { get; set; }

        public string GenerationDateNepali { get; set; }
        public string IssueDateNepali { get; set; }
        public string ReturnDateNepali { get; set; }
        public string ReturnedDateNepali { get; set; }



        public List<ResourceIssueModel> GetResourceIssueList { get; set; }
    }
}
