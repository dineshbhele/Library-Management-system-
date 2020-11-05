using POSModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSBLL.Interface
{
    public interface IResourceIssueInterface
    {
        List<ResourceIssueModel> GetResourceIssueList();
        ReturnMessageModel CreateResourceIssue(ResourceIssueModel riModel);
        List<ResourceIssueModel> GetSearchedResourceCopy(ResourceIssueModel db);
        //ReturnMessageModel CreateIssue(ResourceIssueModel riModel);



        #region
       
        #endregion

    }
}
