//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class Resume
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Resume()
        {
            this.ApplicationList = new HashSet<ApplicationList>();
            this.MemberCollection = new HashSet<MemberCollection>();
            this.OrderDetail = new HashSet<OrderDetail>();
            this.ResumeApplication = new HashSet<ResumeApplication>();
            this.ResumeCertificate = new HashSet<ResumeCertificate>();
            this.ResumeKeywordList = new HashSet<ResumeKeywordList>();
            this.ResumeSkill = new HashSet<ResumeSkill>();
        }
    
        public int AccountID { get; set; }
        public int ResumeID { get; set; }
        public Nullable<int> TownID { get; set; }
        public string Address { get; set; }
        public string Autobiography { get; set; }
        public Nullable<int> WorkingHoursID { get; set; }
        public byte[] Photo { get; set; }
        public Nullable<int> OnTop { get; set; }
        public Nullable<int> TaskNameID { get; set; }
        public bool IsExpertOrNot { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ApplicationList> ApplicationList { get; set; }
        public virtual ExpertResume ExpertResume { get; set; }
        public virtual MemberAccount MemberAccount { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MemberCollection> MemberCollection { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetail> OrderDetail { get; set; }
        public virtual TaskNameList TaskNameList { get; set; }
        public virtual Town Town { get; set; }
        public virtual WorkingTime WorkingTime { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ResumeApplication> ResumeApplication { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ResumeCertificate> ResumeCertificate { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ResumeKeywordList> ResumeKeywordList { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ResumeSkill> ResumeSkill { get; set; }
    }
}
