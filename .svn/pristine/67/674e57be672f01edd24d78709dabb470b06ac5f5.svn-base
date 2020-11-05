
using POSModel;
using PointOfSale.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebMatrix.WebData;
using POSBLL;
using System.IO;
using System.Text.RegularExpressions;
using POSDAL;
using POSBLL.Interface;
using POSBLL.Services;

namespace PointOfSale.Controllers
{
    [Authorize]
    public class SetupController : Controller
    {
        ISetupService _iSetupService;
        IResourceInterface _iResourceService;
        ICountryInterface _iCountryService;
        IResourceAuthorInterface _iResourceAuthorService;
        IResourcePublicationInterface _iResourcePublicationService;
       

        ReturnMessageModel rModel;
        PointOfSaleEntities context;

        public SetupController()
        {
            _iSetupService = new SetupService();
            rModel = new ReturnMessageModel();
            _iResourceService = new ResourceService();
            context = new PointOfSaleEntities();
            _iCountryService = new CountryService();
            context = new PointOfSaleEntities();
            _iResourceAuthorService = new ResourceAuthorService();
            context = new PointOfSaleEntities();
            _iResourcePublicationService = new ResourcePublicationService();
            context = new PointOfSaleEntities();
        }

        //ConfigChoiceCategory
        #region ConfigChoiceCategory
        public ActionResult ConfigChoiceCategoryList()
        {
            ConfigChoiceCategoryModel cccModel = new ConfigChoiceCategoryModel();
            cccModel.ConfigChoiceCategoryList = _iSetupService.GetConfigChoiceCategoryList();
            return View(cccModel);
        }

        public ActionResult CreateEditConfigChoiceCategory(int? CategoryId)
        {
            ConfigChoiceCategoryModel cccModel = new ConfigChoiceCategoryModel();
            if (CategoryId != null)
            {
                cccModel = _iSetupService.GetConfigChoiceCategoryList().Where(x => x.CategoryId == CategoryId).FirstOrDefault();
            }
            return PartialView("_CreateEditConfigChoiceCategory", cccModel);
        }

        [HttpPost]
        public ActionResult CreateEditConfigChoiceCategory(ConfigChoiceCategoryModel cccModel)
        {
            if (ModelState.IsValid)
            {
                var result = _iSetupService.CreateEditConfigChoiceCategory(cccModel);
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(rModel, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        //ConfigChoice
        #region ConfigChoice
        public ActionResult ConfigChoiceList(int catId)
        {
            ConfigChoiceModel cccModel = new ConfigChoiceModel();
            cccModel.ConfigChoiceList = _iSetupService.GetConfigChoiceList(catId);
            cccModel.CategoryId = catId;
            cccModel.CategoryName = CommonService.GetConfigChoiceCategoryById(catId).Category;
            return View(cccModel);
        }

        public ActionResult CreateEditConfigChoice(int categoryId, int? choiceId)
        {
            ConfigChoiceModel cccModel = new ConfigChoiceModel();
            if (choiceId != null)
            {
                cccModel = _iSetupService.GetConfigChoiceList(categoryId).Where(x => x.ChoiceId == choiceId).FirstOrDefault();
            }
            return PartialView("_CreateEditConfigChoice", cccModel);
        }

        [HttpPost]
        public ActionResult CreateEditConfigChoice(ConfigChoiceModel cccModel)
        {
            if (ModelState.IsValid)
            {
                var result = _iSetupService.CreateEditConfigChoice(cccModel);
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(rModel, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion





        //User Roles Section
        #region
        public ActionResult UserRolesIndex()
        {
            RoleModel roModel = new RoleModel();
            roModel.RoleList = _iSetupService.GetRoleList();
            return View(roModel);
        }
        public ActionResult CreateEditUserRoles(int? roleId)
        {

            RoleModel roModel = new RoleModel();
            if (roleId != null)
            {
                roModel = _iSetupService.GetRoleList().Where(x => x.RoleId == roleId).FirstOrDefault();
            }
            return PartialView("_CreateEditRole", roModel);

        }
        [HttpPost]
        public ActionResult CreateEditUserRoles(RoleModel roModel)
        {
            if (ModelState.IsValid)
            {
                var result = _iSetupService.CreateEditUserRoles(roModel);
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(rModel, JsonRequestBehavior.AllowGet);
            }

        }
        #endregion



        #region Grade
        public ActionResult GradeIndex()
        {
            GradeModel gModel = new GradeModel();
            gModel.GradeList = _iSetupService.GetGradeList();

            return View(gModel);
        }

        public ActionResult CreateGrade(int? gradeId)
        {
            GradeModel gModel = new GradeModel();
            if (gradeId != null)
            {
                gModel = _iSetupService.GetGradeList().Where(x => x.GradeId == gradeId).FirstOrDefault();
            }
            return PartialView("_CreateGrade", gModel);
        }

        [HttpPost]
        public ActionResult CreateGrade(GradeModel gModel)
        {
            if (ModelState.IsValid)
            {
                var result = _iSetupService.CreateGrade(gModel);
                return Json(result, JsonRequestBehavior.AllowGet);
            }

            else
            {
                return Json(rModel, JsonRequestBehavior.AllowGet);
            }
        }


        #endregion



        #region Subject

        public ActionResult SubjectIndex()
        {
            SubjectModel sModel = new SubjectModel();
            sModel.SubjectList = _iSetupService.GetSubjectList();

            return View(sModel);
        }

        public ActionResult CreateSubject(int? SubjectId)
        {
            SubjectModel sModel = new SubjectModel();
            if (SubjectId != null)
            {
                sModel = _iSetupService.GetSubjectList().Where(x => x.SubjectId == SubjectId).FirstOrDefault();
            }
            return PartialView("_CreateSubject", sModel);
        }

        [HttpPost]
        public ActionResult CreateSubject(SubjectModel sModel)
        {
            if (ModelState.IsValid)
            {
                var result = _iSetupService.CreateSubject(sModel);
                return Json(result, JsonRequestBehavior.AllowGet);
            }

            else
            {
                return Json(rModel, JsonRequestBehavior.AllowGet);
            }
        }

        #endregion



        #region ResourceSetup

        public ActionResult ResourceSetupIndex()
        {
            ResourceSetupModel rsModel = new ResourceSetupModel();
            rsModel.ResourceSetupList = _iSetupService.GetResourceSetupList();

            return View(rsModel);
        }

        public ActionResult CreateResourceSetup(int? ResourceId)
        {
            ResourceSetupModel rsModel = new ResourceSetupModel();


            ViewBag.ResourceTypeNameList = new SelectList(_iResourceService.GetResourceTypeList(), "ResourceTypeId", "ResourceTypeName");
            ViewBag.ResourcePublisherList = new SelectList(_iResourcePublicationService.GetResourcePublicationList(), "PublicationId", "Publisher");
            ViewBag.ResourceAuthorList = new SelectList(_iResourceAuthorService.GetResourceAuthorList(), "AuthorId", "Author");
            ViewBag.ResourceGradeNameList = new SelectList(_iSetupService.GetGradeList(), "GradeId", "GradeNameEng");
            ViewBag.ResourceSubjectList = new SelectList(_iSetupService.GetSubjectList(), "SubjectId", "SubjectName");



            if (ResourceId != null)
            {
                rsModel = _iSetupService.GetResourceSetupList().Where(x => x.ResourceId == ResourceId).FirstOrDefault();
            }
            return PartialView("_CreateResourceSetup", rsModel);
        }

        [HttpPost]
        public ActionResult CreateResourceSetup(ResourceSetupModel rsModel)
        {
            if (ModelState.IsValid)
            {
                var result = _iSetupService.CreateResourceSetup(rsModel);
                return Json(result, JsonRequestBehavior.AllowGet);
            }

            else
            {
                return Json(rModel, JsonRequestBehavior.AllowGet);
            }
        }

        #endregion


        #region ResourceSubscriber

        public ActionResult ResourceSubscriberIndex()
        {
            ResourceSubscriberModel rsbModel = new ResourceSubscriberModel();
            rsbModel.ResourceSubscriberList = _iSetupService.GetResourceSubscriberList();

            return View(rsbModel);
        }

        public ActionResult CreateResourceSubscriber(int? SubscriberId)
        {
            ResourceSubscriberModel rsbModel = new ResourceSubscriberModel();
            if (SubscriberId != null)
            {
                rsbModel = _iSetupService.GetResourceSubscriberList().Where(x => x.SubscriberId == SubscriberId).FirstOrDefault();
            }
            return PartialView("_CreateResourceSubscriber", rsbModel);
        }

        [HttpPost]
        public ActionResult CreateResourceSubscriber(ResourceSubscriberModel rsbModel)
        {
            if (ModelState.IsValid)
            {
                var result = _iSetupService.CreateResourceSubscriber(rsbModel);
                return Json(result, JsonRequestBehavior.AllowGet);
            }

            else
            {
                return Json(rsbModel, JsonRequestBehavior.AllowGet);
            }
        }

        #endregion

    }



}
