using DAL.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    public interface IUnitOfWorkBase<T_DbContext> : IDisposable
    where T_DbContext : DbContext

    {
        int SaveChanges();
        Task<int> SaveChangesAsync();

        T_DbContext DbReadOnly { get; }
    }


    public class UnitOfWork : IUnitOfWorkBase<ApplicationDbContext> //, IUowNestedSet<ApplicationDbContext, NestedSetAppNode, NestedSetAppTree>
    {
        private bool _disposed { get; set; }
        private ApplicationDbContext _db { get; set; }


        public ApplicationDbContext DbReadOnly { get { return _db; } }



        //****************************************
        //PRIVATE REPO.
        //****************************************

        //AdminSetting
        private GenericRepository<AffiliatedSite> _ReAffiliatedSite { get; set; }
        private GenericRepository<ContactDetail> _ReContactDetail { get; set; }
        private GenericRepository<EmailForward> _ReEmailForward { get; set; }
        private GenericRepository<EmailSender> _ReEmailSender { get; set; }
        private GenericRepository<LogException> _ReLogException { get; set; }
        private GenericRepository<Login> _ReLogin { get; set; }
        private GenericRepository<MessagePosted> _ReMessagePosted { get; set; }
        //private GenericRepository<SiteDisplayData> _ReSiteDisplayData { get; set; }








        //****************************************
        //PUBLIC REPO. CREATORS
        //****************************************

        public GenericRepository<AffiliatedSite> ReAffiliatedSite
        {
            get
            {
                return this._ReAffiliatedSite ?? (this._ReAffiliatedSite = new GenericRepository<AffiliatedSite>(this._db));
            }
        }



        public GenericRepository<ContactDetail> ReContactDetail
        {
            get
            {
                return this._ReContactDetail ?? (this._ReContactDetail = new GenericRepository<ContactDetail>(this._db));
            }
        }




        public GenericRepository<EmailForward> ReEmailForward
        {
            get
            {
                return this._ReEmailForward ?? (this._ReEmailForward = new GenericRepository<EmailForward>(this._db));
            }
        }


        public GenericRepository<EmailSender> ReEmailSender
        {
            get
            {
                return this._ReEmailSender ?? (this._ReEmailSender = new GenericRepository<EmailSender>(this._db));
            }
        }
        public GenericRepository<LogException> ReLogException
        {
            get
            {
                return this._ReLogException ?? (this._ReLogException = new GenericRepository<LogException>(this._db));
            }
        }

        public GenericRepository<Login> ReLogin
        {
            get
            {
                return this._ReLogin ?? (this._ReLogin = new GenericRepository<Login>(this._db));
            }
        }

        public GenericRepository<MessagePosted> ReMessagePosted
        {
            get
            {
                return this._ReMessagePosted ?? (this._ReMessagePosted = new GenericRepository<MessagePosted>(this._db));
            }
        }
        
        //public GenericRepository<SiteDisplayData> ReSiteDisplayData
        //{
        //    get
        //    {
        //        return this._ReSiteDisplayData ?? (this._ReSiteDisplayData = new GenericRepository<SiteDisplayData>(this._db));
        //    }
        //}



        ////AppContent
        //public GenericRepository<SectionContent> ReSectionContent
        //{
        //    get
        //    {
        //        return this._ReSectionContent ?? (this._ReSectionContent = new GenericRepository<SectionContent>(this._db));
        //    }
        //}


        ////Contatti 
        //public GenericRepository<EmailSent> ReEmailSent
        //{
        //    get
        //    {
        //        return this._ReEmailSent ?? (this._ReEmailSent = new GenericRepository<EmailSent>(this._db));
        //    }
        //}
        //public GenericRepository<InternalMessageFromUser> ReInternalMessageFromUser
        //{
        //    get
        //    {
        //        return this._ReInternalMessageFromUser ?? (this._ReInternalMessageFromUser = new GenericRepository<InternalMessageFromUser>(this._db));
        //    }
        //}
        //public GenericRepository<SendUsAMessage> ReSendUsAMessage
        //{
        //    get
        //    {
        //        return this._ReSendUsAMessage ?? (this._ReSendUsAMessage = new GenericRepository<SendUsAMessage>(this._db));
        //    }
        //}


        ////Payment
        //public GenericRepository<MemberDonation> ReMemberDonation
        //{
        //    get
        //    {
        //        return this._ReMemberDonation ?? (this._ReMemberDonation = new GenericRepository<MemberDonation>(this._db));
        //    }
        //}

        ////SectionShowSelect
        //public GenericRepository<SelectSectionToShow> ReSelectSectionToShow
        //{
        //    get
        //    {
        //        return this._ReSelectSectionToShow ?? (this._ReSelectSectionToShow = new GenericRepository<SelectSectionToShow>(this._db));
        //    }
        //}


        //UploadIdDocController
        //public GenericRepository<UploadUserIdentityDocument> ReUploadUserIdentityDocument
        //{
        //    get
        //    {
        //        return this._ReUploadUserIdentityDocument ?? (this._ReUploadUserIdentityDocument = new GenericRepository<UploadUserIdentityDocument>(this._db));
        //    }
        //}

        ////UserAccount
        //public GenericRepository<ApplicationUser> ReApplicationUser
        //{
        //    get
        //    {
        //        return this._ReApplicationUser ?? (this._ReApplicationUser = new GenericRepository<ApplicationUser>(this._db));
        //    }
        //}
        //public GenericRepository<MembershipPidCard> ReMembershipPidCard
        //{
        //    get
        //    {
        //        return this._ReMembershipPidCard ?? (this._ReMembershipPidCard = new GenericRepository<MembershipPidCard>(this._db));
        //    }
        //}



















        //****************************************
        //CONSTRUCTOR
        //****************************************
        public UnitOfWork(ApplicationDbContext db = null)
        {
            this._disposed = false;
            this._db = (ApplicationDbContext)db ?? new ApplicationDbContext();
        }






        public int SaveChanges()
        {
            int countSaveChanges = 0;


            //*ADD (Step: 07)*/
            //_mlHandlerAdd.SetMlKeyForProperiesInProxyTable();

            //countSaveChanges = _db.SaveChanges();

            //*ADD (Step: 09, 10, 11)*/
            //_mlHandlerAdd.AddLanguageDbObject_AddLanguageToDbObject();


            try
            {
                countSaveChanges = countSaveChanges + _db.SaveChanges();
            }
            catch (Exception ex)
            {
                if (ex.GetType() == typeof(DbEntityValidationException))
                {
                    DbEntityValidationException exDbValidation = ex as DbEntityValidationException;
                    string errorMessage = "";


                    foreach (DbEntityValidationResult itemField in exDbValidation.EntityValidationErrors)
                    {
                        foreach (DbValidationError validationError in itemField.ValidationErrors)
                        {
                            string tempValidationMess = "[" + validationError.PropertyName + ":: " + validationError.ErrorMessage + "]. ";

                            Debug.Print("Model Validation Error: " + tempValidationMess + "\n");
                            errorMessage = errorMessage + tempValidationMess;
                        }
                    }
                    #region MyRegion
                    //Elmah.ErrorSignal.FromCurrentContext().Raise(exDbValidation);
                    //exDbValidation.Data.Add("ZR_MESSAGE",errorMessage);
                    //Elmah.ErrorSignal.FromCurrentContext().Raise(exDbValidation); 
                    #endregion


                }

                throw ex;
            }


            return countSaveChanges;
        }
        public async Task<int> SaveChangesAsync()
        {
            int countSaveChanges = 0;


            //*ADD (Step: 07)*/
            //_mlHandlerAdd.SetMlKeyForProperiesInProxyTable();

            //countSaveChanges = await _db.SaveChangesAsync();

            //*ADD (Step: 09, 10, 11)*/
            //_mlHandlerAdd.AddLanguageDbObject_AddLanguageToDbObject();

            try
            {
                countSaveChanges = countSaveChanges + await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                if (ex.GetType() == typeof(DbEntityValidationException))
                {
                    DbEntityValidationException exDbValidation = ex as DbEntityValidationException;
                    string errorMessage = "";


                    foreach (DbEntityValidationResult itemField in exDbValidation.EntityValidationErrors)
                    {
                        foreach (DbValidationError validationError in itemField.ValidationErrors)
                        {
                            string tempValidationMess = "[" + validationError.PropertyName + ":: " + validationError.ErrorMessage + "]. ";

                            Debug.Print("ZR** Model Validation Error: " + tempValidationMess + "\n");
                            errorMessage = errorMessage + tempValidationMess;
                        }
                    }
                    #region MyRegion
                    //Elmah.ErrorSignal.FromCurrentContext().Raise(exDbValidation);
                    //exDbValidation.Data.Add("ZR_MESSAGE",errorMessage);
                    //Elmah.ErrorSignal.FromCurrentContext().Raise(exDbValidation); 
                    #endregion


                }

                throw ex;
            }


            return countSaveChanges;
        }


        public void Dispose()
        {
            if (!_disposed)
            {
                _db.Dispose();
                //_dbw.Dispose();
                _disposed = true;

            }
        }


    }
}
