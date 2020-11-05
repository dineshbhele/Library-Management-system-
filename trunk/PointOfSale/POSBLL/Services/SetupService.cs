﻿using POSDAL;
using POSModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebMatrix.WebData;

namespace POSBLL
{
    public class SetupService : ISetupService
    {
        PointOfSaleEntities _context;

        ReturnMessageModel rModel;

        public SetupService()
        {
            rModel = new ReturnMessageModel();
            _context = new PointOfSaleEntities();
        }

        #region ConfigChoiceCategory
        public List<ConfigChoiceCategoryModel> GetConfigChoiceCategoryList()
        {
            return _context.ConfigChoiceCategories.Select(x => new ConfigChoiceCategoryModel
            {
                CategoryId = x.CategoryId,
                Category = x.Category,
                CategoryNepali = x.CategoryNepali,
                CategoryDescription = x.CategoryDescription,
                IsActive = x.IsActive
            }).ToList();
        }
        public ReturnMessageModel CreateEditConfigChoiceCategory(ConfigChoiceCategoryModel iModel)
        {
            try
            {
                var cccRow = _context.ConfigChoiceCategories.Where(x => x.CategoryId == iModel.CategoryId).FirstOrDefault();
                if (cccRow == null)
                {
                    cccRow = new ConfigChoiceCategory();
                }

                cccRow.Category = iModel.Category;
                cccRow.CategoryNepali = iModel.CategoryNepali;
                cccRow.CategoryDescription = iModel.CategoryDescription;
                cccRow.IsActive = iModel.IsActive;
                if (cccRow.CategoryId == 0)
                {
                    _context.ConfigChoiceCategories.Add(cccRow);
                    _context.SaveChanges();
                }
                else
                {
                    _context.ConfigChoiceCategories.Attach(cccRow);
                    _context.Entry(cccRow).State = EntityState.Modified;
                    _context.SaveChanges();
                }

                rModel.Msg = "ConfigChoiceCategory Saved Successfully!!";
                rModel.Success = true;
                return rModel;
            }
            catch (Exception ex)
            {
                rModel.Msg = "ConfigChoiceCategory Save Failed!!";
                rModel.Success = false;
                return rModel;
            }
        }
        #endregion

        #region ConfigChoice
        public List<ConfigChoiceModel> GetConfigChoiceList(int CategoryId)
        {
            return (from cc in _context.ConfigChoices
                    join ccc in _context.ConfigChoiceCategories on cc.CategoryId equals ccc.CategoryId
                    where cc.CategoryId == CategoryId
                    select new ConfigChoiceModel
                     {
                         ChoiceId = cc.ChoiceId,
                         CategoryId = cc.CategoryId,
                         CategoryName = ccc.Category,
                         Choice = cc.Choice,
                         ChoiceNepali = cc.ChoiceNepali,
                         ChoiceDescription = cc.ChoiceDescription,
                         Val = cc.Val,
                         IsActive = cc.IsActive
                     }).ToList();
        }
        public ReturnMessageModel CreateEditConfigChoice(ConfigChoiceModel model)
        {
            try
            {
                var ccRow = _context.ConfigChoices.Where(x => x.ChoiceId == model.ChoiceId).FirstOrDefault();
                if (ccRow == null)
                {
                    ccRow = new ConfigChoice();
                }

                ccRow.CategoryId = model.CategoryId;
                ccRow.Choice = model.Choice;
                ccRow.ChoiceNepali = model.ChoiceNepali;
                ccRow.ChoiceDescription = model.ChoiceDescription;
                ccRow.Val = model.Val;
                ccRow.IsActive = model.IsActive;
                if (ccRow.ChoiceId == 0)
                {
                    _context.ConfigChoices.Add(ccRow);
                    _context.SaveChanges();
                }
                else
                {
                    _context.ConfigChoices.Attach(ccRow);
                    _context.Entry(ccRow).State = EntityState.Modified;
                    _context.SaveChanges();
                }

                rModel.Msg = "ConfigChoice Saved Successfully!!";
                rModel.Success = true;
                return rModel;
            }
            catch (Exception ex)
            {
                rModel.Msg = "ConfigChoice Save Failed!!";
                rModel.Success = false;
                return rModel;
            }
        }
        #endregion



        //roles
        #region roles
        public List<RoleModel> GetRoleList()
        {
            List<RoleModel> rList = _context.Database.SqlQuery<RoleModel>("Select RoleId,RoleName from webpages_Roles").ToList();
            return rList;

        }

        public ReturnMessageModel CreateEditUserRoles(RoleModel roModel)
        {
            try
            {

                if (roModel.RoleId == 0)
                {
                    _context.Database.ExecuteSqlCommand("insert into webpages_Roles (RoleName) VALUES ('" + roModel.RoleName + "')");
                    // var role = _context.Database.SqlQuery<RoleModel>("select * from webpages_Roles where UniqueId='" + roModel.UniqueId + "'").FirstOrDefault();
                    rModel.Msg = "Role Successfully Saved!";
                }
                else
                {
                    _context.Database.ExecuteSqlCommand("update webpages_Roles set [RoleName]='" + roModel.RoleName + "' where RoleId= " + roModel.RoleId);
                    //var role = _context.Database.SqlQuery<RoleModel>("select * from webpages_Roles where UniqueId='" + roModel.UniqueId + "'").FirstOrDefault();
                    rModel.Msg = "Role Updated Successfully!";
                }
                rModel.Success = true;
                return rModel;
            }

            catch (Exception ex)
            {
                rModel.Msg = " Saving Role Failed!!";
                rModel.Success = false;
                return rModel;
            }
        }
        #endregion



        #region Grade
        public List<GradeModel> GetGradeList()
        {
            return _context.Grades.Select(x => new GradeModel
            {
                GradeId = x.GradeId,
                GradeNameEng = x.GradeNameEng,
                GradeNameNep = x.GradeNameNep,
                Remarks = x.Remarks,
                IsActive = x.IsActive,
                CreatedBy = x.CreatedBy,
                CreatedDate = x.CreatedDate,
                UpdatedBy = x.UpdatedBy,
                UpdatedDate = x.UpdatedDate

            }).ToList();
        }


        public ReturnMessageModel CreateGrade(GradeModel gModel)
        {
            try
            {
                var gRow = _context.Grades.Where(x => x.GradeId == gModel.GradeId).FirstOrDefault();
                if (gRow == null)
                {
                    gRow = new Grade();
                }

                gRow.GradeId = gModel.GradeId;
                gRow.GradeNameEng = gModel.GradeNameEng;
                gRow.GradeNameNep = gModel.GradeNameNep;
                gRow.Remarks = gModel.Remarks;
                gRow.IsActive = gModel.IsActive;
                gRow.CreatedBy = gModel.CreatedBy;
                gRow.CreatedDate = gModel.CreatedDate;
                gRow.UpdatedBy = gModel.UpdatedBy;
                gRow.UpdatedDate = gModel.UpdatedDate;


                if (gRow.GradeId == 0)
                {
                    gRow.CreatedBy = WebSecurity.CurrentUserId;
                    gRow.CreatedDate = System.DateTime.Now;
                    _context.Grades.Add(gRow);
                    _context.SaveChanges();

                }
                else
                {
                    gRow.UpdatedBy = WebSecurity.CurrentUserId;
                    gRow.UpdatedDate = System.DateTime.Now;
                    _context.Grades.Attach(gRow);
                    _context.Entry(gRow).State = EntityState.Modified;
                    _context.SaveChanges();
                }

                rModel.Msg = "Grade Saved Successfully";
                rModel.Success = true;
                return rModel;
            }
            catch (Exception ex)
            {
                rModel.Msg = "Grade Saved Failed";
                rModel.Success = false;
                return rModel;

            }

        }

        #endregion



        #region Subject
        public List<SubjectModel> GetSubjectList()
        {
            return _context.Subjects.Select(x => new SubjectModel
            {
                SubjectId = x.SubjectId,
                SubjectName = x.SubjectName,
                IsActive = x.IsActive,
                CreatedBy = x.CreatedBy,
                CreatedDate = x.CreatedDate,
                ModifiedBy = x.ModifiedBy,
                ModifiedDate = x.ModifiedDate

            }).ToList();
        }


        public ReturnMessageModel CreateSubject(SubjectModel sModel)
        {
            try
            {
                var sRow = _context.Subjects.Where(x => x.SubjectId == sModel.SubjectId).FirstOrDefault();
                if (sRow == null)
                {
                    sRow = new Subject();
                }

                sRow.SubjectId = sModel.SubjectId;
                sRow.SubjectName = sModel.SubjectName;
                sRow.IsActive = sModel.IsActive;
                sRow.CreatedBy = sModel.CreatedBy;
                sRow.CreatedDate = sModel.CreatedDate;
                sRow.ModifiedDate = sModel.ModifiedDate;
                sRow.ModifiedBy = sModel.ModifiedBy;


                if (sRow.SubjectId == 0)
                {
                    sRow.CreatedBy = WebSecurity.CurrentUserId;
                    sRow.CreatedDate = System.DateTime.Now;
                    _context.Subjects.Add(sRow);
                    _context.SaveChanges();

                }
                else
                {
                    sRow.ModifiedBy = WebSecurity.CurrentUserId;
                    sRow.ModifiedDate = System.DateTime.Now;
                    _context.Subjects.Attach(sRow);
                    _context.Entry(sRow).State = EntityState.Modified;
                    _context.SaveChanges();
                }

                rModel.Msg = "Subject Saved Successfully";
                rModel.Success = true;
                return rModel;
            }
            catch (Exception ex)
            {
                rModel.Msg = "Subject Saved Failed";
                rModel.Success = false;
                return rModel;

            }

        }

        #endregion



        #region ResourceSetup

        public List<ResourceSetupModel> GetResourceSetupList()
        {
            return _context.ResourceSetups.Select(x => new ResourceSetupModel
            {
                ResourceId = x.ResourceId,
                ResourceTypeId = x.ResourceTypeId,
                ResourceName = x.ResourceName,
                PublicationId = x.PublicationId,
                PublicationName = x.ResourcePublication.Publisher ?? x.PublicationName,
                AuthorId = x.AuthorId,
                AuthorName = x.ResourceAuthor.Author ?? x.AuthorName,
                Remarks = x.Remarks,
                GradeId = x.GradeId,
                SubjectId = x.SubjectId,
                IsActive = x.IsActive,
                CreatedBy = x.CreatedBy,
                CreatedDate = x.CreatedDate,
                ModifiedBy = x.ModifiedBy,
                ModifiedDate = x.ModifiedDate,

                Publisher = x.ResourcePublication.Publisher,
                ResourceTypeName = x.ResourceType.ResourceTypeName,
                Author = x.ResourceAuthor.Author,
                GradeNameEng=x.Grade.GradeNameEng,
                SubjectName=x.Subject.SubjectName


            }).ToList();
        }


        public ReturnMessageModel CreateResourceSetup(ResourceSetupModel rsModel)
        {
            try
            {
                var rRow = _context.ResourceSetups.Where(x => x.ResourceId == rsModel.ResourceId).FirstOrDefault();
                if (rRow == null)
                {
                    rRow = new ResourceSetup();
                }

                //rRow.ResourceId = rsModel.ResourceId;
                rRow.ResourceTypeId = rsModel.ResourceTypeId;
                rRow.ResourceName = rsModel.ResourceName;
                rRow.PublicationId = rsModel.PublicationId;
                rRow.PublicationName = rsModel.PublicationName;
                rRow.AuthorId = rsModel.AuthorId;
                rRow.AuthorName = rsModel.AuthorName;
                rRow.Remarks = rsModel.Remarks;
                rRow.GradeId = rsModel.GradeId;
                rRow.SubjectId = rsModel.SubjectId;
                rRow.IsActive = rsModel.IsActive;
            

                if (rRow.ResourceId == 0)
                {
                    rRow.CreatedBy = WebSecurity.CurrentUserId;
                    rRow.CreatedDate = System.DateTime.Now;
                    _context.ResourceSetups.Add(rRow);
                    _context.SaveChanges();

                }
                else
                {
                    rRow.ModifiedBy = WebSecurity.CurrentUserId;
                    rRow.ModifiedDate = System.DateTime.Now;
                    _context.ResourceSetups.Attach(rRow);
                    _context.Entry(rRow).State = EntityState.Modified;
                    _context.SaveChanges();
                }

                rModel.Msg = "Resource Saved Successfully";
                rModel.Success = true;
                return rModel;
            }
            catch (Exception ex)
            {
                rModel.Msg = "Resource Saved Failed ";
                rModel.Success = false;
                return rModel;

            }

        }

        #endregion


        #region ResourceSubscriber

        public List<ResourceSubscriberModel> GetResourceSubscriberList()
        {
            return _context.ResourceSubscribers.Select(x => new ResourceSubscriberModel
            {
                SubscriberId = x.SubscriberId,
                FirstName = x.FirstName,
                MiddleName = x.MiddleName,
                LastName = x.LastName,
                MembershipNumber = x.MembershipNumber,
                IsStudent = x.IsStudent,
                IsEmployee = x.IsEmployee,
                IsActive = x.IsActive,
                CreatedBy = x.CreatedBy,
                CreatedDate = x.CreatedDate,
                ModifiedBy = x.ModifiedBy,
                ModifiedDate = x.ModifiedDate

            }).ToList();
        }


        public ReturnMessageModel CreateResourceSubscriber(ResourceSubscriberModel rsbModel)
        {
            try
            {
                var rRow = _context.ResourceSubscribers.Where(x => x.SubscriberId == rsbModel.SubscriberId).FirstOrDefault();
                if (rRow == null)
                {
                    rRow = new ResourceSubscriber();
                }

                rRow.SubscriberId = rsbModel.SubscriberId;
                rRow.FirstName = rsbModel.FirstName;
                rRow.MiddleName = rsbModel.MiddleName;
                rRow.LastName = rsbModel.LastName;
                rRow.MembershipNumber = rsbModel.MembershipNumber;
                rRow.IsStudent = rsbModel.IsStudent;
                rRow.IsEmployee = rsbModel.IsEmployee;
                rRow.IsActive = rsbModel.IsActive;
                rRow.CreatedBy = rsbModel.CreatedBy;
                rRow.CreatedDate = rsbModel.CreatedDate;
                rRow.ModifiedBy = rsbModel.ModifiedBy;
                rRow.ModifiedDate = rsbModel.ModifiedDate;


                if (rRow.SubscriberId == 0)
                {
                    rRow.CreatedBy = WebSecurity.CurrentUserId;
                    rRow.CreatedDate = System.DateTime.Now;
                    _context.ResourceSubscribers.Add(rRow);
                    _context.SaveChanges();

                }
                else
                {
                    rRow.ModifiedBy = WebSecurity.CurrentUserId;
                    rRow.ModifiedDate = System.DateTime.Now;
                    _context.ResourceSubscribers.Attach(rRow);
                    _context.Entry(rRow).State = EntityState.Modified;
                    _context.SaveChanges();
                }

                rModel.Msg = "Subscriber Saved Successfully";
                rModel.Success = true;
                return rModel;
            }
            catch (Exception ex)
            {
                rModel.Msg = "Subscriber Saved Failed";
                rModel.Success = false;
                return rModel;

            }

        }

        #endregion


    }
}
