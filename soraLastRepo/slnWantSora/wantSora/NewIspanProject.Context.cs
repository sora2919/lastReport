﻿//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace wantSora
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class NewIspanProjectEntities : DbContext
    {
        public NewIspanProjectEntities()
            : base("name=NewIspanProjectEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ApplicationList> ApplicationList { get; set; }
        public virtual DbSet<CaseSkill> CaseSkill { get; set; }
        public virtual DbSet<CaseStatusList> CaseStatusList { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Certificate> Certificate { get; set; }
        public virtual DbSet<CertificateType> CertificateType { get; set; }
        public virtual DbSet<ChatBlockList> ChatBlockList { get; set; }
        public virtual DbSet<ChatMessage> ChatMessage { get; set; }
        public virtual DbSet<CheckIn> CheckIn { get; set; }
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<ExpertApplication> ExpertApplication { get; set; }
        public virtual DbSet<ExpertResume> ExpertResume { get; set; }
        public virtual DbSet<ExpertWorkList> ExpertWorkList { get; set; }
        public virtual DbSet<ExpertWorks> ExpertWorks { get; set; }
        public virtual DbSet<ForgetPassword> ForgetPassword { get; set; }
        public virtual DbSet<ForumCategory> ForumCategory { get; set; }
        public virtual DbSet<ForumPost> ForumPost { get; set; }
        public virtual DbSet<ForumPostCategory> ForumPostCategory { get; set; }
        public virtual DbSet<ForumPostComment> ForumPostComment { get; set; }
        public virtual DbSet<ForumStatus> ForumStatus { get; set; }
        public virtual DbSet<Keyword> Keyword { get; set; }
        public virtual DbSet<LoginHistory> LoginHistory { get; set; }
        public virtual DbSet<MemberAccount> MemberAccount { get; set; }
        public virtual DbSet<MemberCollection> MemberCollection { get; set; }
        public virtual DbSet<MemberRoleConn> MemberRoleConn { get; set; }
        public virtual DbSet<MemberStatusList> MemberStatusList { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderDetail> OrderDetail { get; set; }
        public virtual DbSet<PayWay> PayWay { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductPhoto> ProductPhoto { get; set; }
        public virtual DbSet<Rating> Rating { get; set; }
        public virtual DbSet<Resume> Resume { get; set; }
        public virtual DbSet<ResumeApplication> ResumeApplication { get; set; }
        public virtual DbSet<ResumeCertificate> ResumeCertificate { get; set; }
        public virtual DbSet<ResumeKeywordList> ResumeKeywordList { get; set; }
        public virtual DbSet<ResumeSkill> ResumeSkill { get; set; }
        public virtual DbSet<RoleInfo> RoleInfo { get; set; }
        public virtual DbSet<Salary> Salary { get; set; }
        public virtual DbSet<ServiceContact> ServiceContact { get; set; }
        public virtual DbSet<Skill> Skill { get; set; }
        public virtual DbSet<SkillType> SkillType { get; set; }
        public virtual DbSet<StatusChangeReason> StatusChangeReason { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<TaskKeywordList> TaskKeywordList { get; set; }
        public virtual DbSet<TaskList> TaskList { get; set; }
        public virtual DbSet<TaskNameList> TaskNameList { get; set; }
        public virtual DbSet<TaskPhoto> TaskPhoto { get; set; }
        public virtual DbSet<TeachToList> TeachToList { get; set; }
        public virtual DbSet<Town> Town { get; set; }
        public virtual DbSet<WorkingTime> WorkingTime { get; set; }
        public virtual DbSet<HumanList> HumanList { get; set; }
    
        public virtual int sp_alterdiagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_alterdiagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_creatediagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_creatediagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_dropdiagram(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_dropdiagram", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagramdefinition_Result> sp_helpdiagramdefinition(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagramdefinition_Result>("sp_helpdiagramdefinition", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagrams_Result> sp_helpdiagrams(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagrams_Result>("sp_helpdiagrams", diagramnameParameter, owner_idParameter);
        }
    
        public virtual int sp_renamediagram(string diagramname, Nullable<int> owner_id, string new_diagramname)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var new_diagramnameParameter = new_diagramname != null ?
                new ObjectParameter("new_diagramname", new_diagramname) :
                new ObjectParameter("new_diagramname", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_renamediagram", diagramnameParameter, owner_idParameter, new_diagramnameParameter);
        }
    
        public virtual int sp_upgraddiagrams()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_upgraddiagrams");
        }
    }
}
