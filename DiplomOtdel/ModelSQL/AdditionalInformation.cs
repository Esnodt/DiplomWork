//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DiplomOtdel.ModelSQL
{
    using System;
    using System.Collections.Generic;
    
    public partial class AdditionalInformation
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AdditionalInformation()
        {
            this.MainInfo = new HashSet<MainInfo>();
        }
    
        public int ID { get; set; }
        public Nullable<System.DateTime> DateOfBirth { get; set; }
        public string Nationality { get; set; }
        public string Citizenship { get; set; }
        public string PhoneNumber { get; set; }
        public int idGender { get; set; }
    
        public virtual GenderTable GenderTable { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MainInfo> MainInfo { get; set; }
    }
}
