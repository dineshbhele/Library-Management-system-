using POSBLL.Interface;
using POSDAL;
using POSModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebMatrix.WebData;

namespace POSBLL.Services
{
    public class ResourceIssueService : IResourceIssueInterface
    {
        ReturnMessageModel rModel;
        public ResourceIssueService()
        {
            rModel = new ReturnMessageModel();
        }
        public ReturnMessageModel CreateResourceIssue(ResourceIssueModel riModel)
        {
            try
            {
                using (PointOfSaleEntities _context = new PointOfSaleEntities())
                {
                    var rtRow = _context.ResourceIssues.Where(x => x.IssueId == riModel.IssueId).FirstOrDefault();
                    if (rtRow == null)
                    {
                        rtRow = new ResourceIssue();
                    }

                    rtRow.ResourceCopyId = riModel.ResourceCopyId;
                    rtRow.IssueDate = CommonService.GetEnglishDate(riModel.IssueDateNepali);
                    rtRow.ReturnBackDate = CommonService.GetEnglishDate(riModel.ReturnDateNepali);
                    rtRow.ReturnedDate = CommonService.GetEnglishDate(riModel.ReturnDateNepali);
                    rtRow.Remarks = riModel.Remarks;
                   
                    rtRow.subscriber= riModel.SubscriberId;
                    
                    

                    _context.ResourceIssues.Add(rtRow);
                    _context.SaveChanges();

                    
                   
                    rModel.Msg = "Issue Saved Successfully";
                    rModel.Success = true;
                    return rModel;
                }


            }
            catch (Exception ex)
            {
                rModel.Msg = "Issue Saved Failed";
                rModel.Success = false;
                return rModel;

            }
        }

        //public ReturnMessageModel CreateIssue(ResourceIssueModel riModel)
        //{
        //    try
        //    {
        //        using (PointOfSaleEntities _context = new PointOfSaleEntities())
        //        {
        //            var rtRow = _context.ResourceIssues.Where(x => x.IssueId == riModel.IssueId).FirstOrDefault();
        //            if (rtRow == null)
        //            {
        //                rtRow = new ResourceIssue();
        //            }

        //            rtRow.ResourceCopyId = riModel.ResourceCopyId;
        //            rtRow.IssueDate = CommonService.GetEnglishDate(riModel.IssueDateNepali);
        //            rtRow.ReturnBackDate = CommonService.GetEnglishDate(riModel.ReturnDateNepali);
        //            //rtRow.ReturnedDate = CommonService.GetEnglishDate(riModel.GenerationDateNepali);
        //            rtRow.Remarks = riModel.Remarks;
        //            rtRow.subscriber = riModel.SubscriberId;





        //            if (riModel.IssueId == 0)
        //            {
        //                _context.ResourceIssues.Add(rtRow);
        //                _context.SaveChanges();

        //            }
        //            else
        //            {

        //                _context.ResourceIssues.Attach(rtRow);
        //                _context.Entry(rtRow).State = EntityState.Modified;
        //                _context.SaveChanges();
        //            }
        //            rModel.Msg = "Issue Saved Successfully";
        //            rModel.Success = true;
        //            return rModel;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        rModel.Msg = "Issue Saved Failed";
        //        rModel.Success = false;
        //        return rModel;

        //    }
        //}

        public List<ResourceIssueModel> GetResourceIssueList()
        {
            using (PointOfSaleEntities context = new PointOfSaleEntities())
            {
                var result = context.ResourceIssues.Select(x => new ResourceIssueModel   //where use in after resourceissue
                {
                    IssueId=x.IssueId,
                    ResourceCopyId=x.ResourceCopyId,
                    IssueDate=x.IssueDate,
                    ReturnBackDate=x.ReturnBackDate,
                    ReturnedDate=x.ReturnedDate,
                    Remarks=x.Remarks,
                    IsActive=x.ResourceCopy.ResourceSetup.IsActive,
                    IsAvailable=x.ResourceCopy.IsAvailable,
                    SubscriberId=x.subscriber,
                    //ResourceGenerationDate=x.ResourceGeneration.GenerationDate
                    FirstName = x.ResourceSubscriber.FirstName,
                    ResourceCopyNumber=x.ResourceCopy.ResourceCopyNumber,
                    
                    //ResourceTypeName=x.ResourceType.ResourceTypeName,
                    //Author=x.ResourceAuthor.Author,
                    //Publisher=x.ResourcePublication.Publisher,
                    //GradeNameEng=x.Grade1.GradeNameEng,
                    //SubjectName=x.Subject1.SubjectName

                }).ToList();
                return result;
            }
        }

        public List<ResourceIssueModel> GetSearchedResourceCopy(ResourceIssueModel db) { 

            using(PointOfSaleEntities context = new PointOfSaleEntities())
            {
                return context.Database.SqlQuery<ResourceIssueModel>("SpGetResourceCopy @resourceCopyId,@authorId,@publicationId,@gradeId,@subjectId",
                    new SqlParameter("resourceCopyId", db.ResourceId),
                    new SqlParameter("authorId", db.AuthorId ?? SqlInt32.Null),
                    new SqlParameter("publicationId", db.PublicationId ?? SqlInt32.Null),
                    new SqlParameter("gradeId", db.GradeId ?? SqlInt32.Null),
                    new SqlParameter("subjectId", db.SubjectId ?? SqlInt32.Null)
                    ).ToList();


            }
            }

       
    }
}
