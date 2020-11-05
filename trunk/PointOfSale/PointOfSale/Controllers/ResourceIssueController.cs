using POSBLL;
using POSBLL.Interface;
using POSBLL.Services;
using POSModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PointOfSale.Controllers
{
    public class ResourceIssueController : Controller
    {
        IResourceIssueInterface _iResourceIssue;
        ISetupService _iSetupService;
        IResourceInterface _iResourceService;
        IResourceAuthorInterface _iResourceAuthorService;
        IResourcePublicationInterface _iResourcePublicationService;
        ReturnMessageModel rModel;

        public ResourceIssueController()
        {
            _iResourceService = new ResourceService();
            _iResourceIssue = new ResourceIssueService();
            _iSetupService = new SetupService();
            _iResourceAuthorService = new ResourceAuthorService();
            _iResourcePublicationService = new ResourcePublicationService();
            rModel = new ReturnMessageModel();
        }

        //
        // GET: /ResourceIssue/

        public ActionResult Index()
        {
            return View();
        }

        #region Resource Issue suscriber


        public ActionResult ResourceIssueIndex(ResourceIssueModel riModel)
        {
            ViewBag.FirstName = new SelectList(_iSetupService.GetResourceSubscriberList(), "SubscriberId", "FirstName");
            if(riModel.SubscriberId > 0)
            {
                riModel.GetResourceIssueList = _iResourceIssue.GetResourceIssueList().Where(x => x.SubscriberId == riModel.SubscriberId && x.ReturnedDate == null).ToList();
               
            }
            return View(riModel);
        }

        #endregion


        #region Return

        public ActionResult ReturnIndex(ResourceIssueModel riModel )
        {
            ResourceIssueModel db = new ResourceIssueModel();
            db.GetResourceIssueList = _iResourceIssue.GetResourceIssueList();
            return View(db);
        }
        public ActionResult CreateReturn(int issueId)
        {

            ResourceIssueModel riModel = new ResourceIssueModel();
            
            riModel = _iResourceIssue.GetResourceIssueList().Where(x => x.IssueId == issueId).FirstOrDefault();

            riModel.ReturnedDateNepali = CommonService.GetCurrentNepaliDate(DateTime.Now);
            return PartialView("_CreateRetrun", riModel);


        }

        [HttpPost]
        public ActionResult CreateReturn(ResourceIssueModel riModel)
        {
            if (ModelState.IsValid)
            {
                var result = _iResourceIssue.CreateResourceIssue(riModel);
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(rModel, JsonRequestBehavior.AllowGet);
            }
        }



        #endregion

        #region Issue
        public ActionResult IssueIndex(ResourceIssueModel db)
        {
            //ResourceIssueModel db = new ResourceIssueModel();
            ViewBag.ResourceList = new SelectList(_iSetupService.GetResourceSetupList(), "ResourceId", "ResourceName");
            ViewBag.Author = new SelectList(_iResourceAuthorService.GetResourceAuthorList(), "AuthorId", "Author");
            ViewBag.Publisher = new SelectList(_iResourcePublicationService.GetResourcePublicationList(), "PublicationId", "Publisher");
            ViewBag.GradeNameEng = new SelectList(_iSetupService.GetGradeList(), "GradeId", "GradeNameEng");
            ViewBag.Subject = new SelectList(_iSetupService.GetSubjectList(), "SubjectId", "SubjectName");
            if(db.ResourceId >0)
            {
                db.GetResourceIssueList = _iResourceIssue.GetSearchedResourceCopy(db);

            }
            
            return View(db);

        }
        #endregion

        #region CreateResourceIssue

        public ActionResult CreateResourceIssue(int resourceCopyId,int subscriberId)
        {

            ResourceIssueModel riModel = new ResourceIssueModel();
            riModel.ResourceCopyNumber = _iResourceService.GetResourceCopiesList().Where(x => x.ResourceCopyId == resourceCopyId).FirstOrDefault().ResourceCopyNumber;
            riModel.ResourceCopyId = resourceCopyId;
            riModel.SubscriberId = subscriberId;
            riModel.IssueDateNepali = CommonService.GetCurrentNepaliDate(DateTime.Now);
            riModel.ReturnDateNepali = CommonService.GetCurrentNepaliDate(DateTime.Now.AddDays(+7));
            return PartialView("_CreateResourceIssue", riModel);
            
            
        }

        [HttpPost]
        public ActionResult CreateResourceIssue(ResourceIssueModel riModel)
        {
            if (ModelState.IsValid)
            {
                var result = _iResourceIssue.CreateResourceIssue(riModel);
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(rModel, JsonRequestBehavior.AllowGet);
            }
        }

      
        #endregion
    }
}
