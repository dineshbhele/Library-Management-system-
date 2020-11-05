﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POSModel;

namespace POSBLL
{
    public interface ISetupService
    {
        #region ConfigChoiceCategory
        List<ConfigChoiceCategoryModel> GetConfigChoiceCategoryList();
        ReturnMessageModel CreateEditConfigChoiceCategory(ConfigChoiceCategoryModel cccModel);
        #endregion

        #region ConfigChoice
        List<ConfigChoiceModel> GetConfigChoiceList(int CategoryId);
        ReturnMessageModel CreateEditConfigChoice(ConfigChoiceModel ccModel);
        #endregion

      
        //#region DownloadPublication
        //List<DownloadPublicationModel> GetDownloadPublicationList();
        //ReturnMessageModel CreateEditDownloadPublication(DownloadPublicationModel sModel);
        //#endregion

        //user roles
        #region user roles
        List<RoleModel> GetRoleList();

        ReturnMessageModel CreateEditUserRoles(RoleModel roModel);
        #endregion


        #region Grade
        List<GradeModel> GetGradeList();

       ReturnMessageModel CreateGrade(GradeModel gModel);

        #endregion

        #region Subject
        List<SubjectModel> GetSubjectList();

        ReturnMessageModel CreateSubject(SubjectModel sModel);

        #endregion


        #region ResourceSetup
        List<ResourceSetupModel> GetResourceSetupList();

        ReturnMessageModel CreateResourceSetup(ResourceSetupModel rsModel);

        #endregion

        #region ResourceSubscriber
        List<ResourceSubscriberModel> GetResourceSubscriberList();

        ReturnMessageModel CreateResourceSubscriber(ResourceSubscriberModel rsModel);

        #endregion
    }
}
