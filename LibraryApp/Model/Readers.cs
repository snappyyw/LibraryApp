//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LibraryApp.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Readers
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Readers()
        {
            this.Journal = new HashSet<Journal>();
        }
    
        public int Id { get; set; }
        public string FIO { get; set; }
        public Nullable<System.DateTime> DateOfBirth { get; set; }
        public string Telephone { get; set; }
        public bool IsEmployee { get; set; }
        public int ReaderRating { get; set; }
        public int IdUser { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Journal> Journal { get; set; }
        public virtual Users Users { get; set; }
    }
}
