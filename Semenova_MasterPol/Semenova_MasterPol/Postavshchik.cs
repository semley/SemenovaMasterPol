//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Semenova_MasterPol
{
    using System;
    using System.Collections.Generic;
    
    public partial class Postavshchik
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Postavshchik()
        {
            this.PostavshchikMaterialHistory = new HashSet<PostavshchikMaterialHistory>();
            this.Material = new HashSet<Material>();
        }
    
        public int Postavshchik_ID { get; set; }
        public string Postavshchik_Type { get; set; }
        public string Postavshchik_Name { get; set; }
        public string INN { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PostavshchikMaterialHistory> PostavshchikMaterialHistory { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Material> Material { get; set; }
    }
}
