//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace POS.DBModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class VENTA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public VENTA()
        {
            this.DETALLE_VENTA = new HashSet<DETALLE_VENTA>();
        }
    
        public long id { get; set; }
        public Nullable<System.DateTime> fecha { get; set; }
        public Nullable<int> fk_id_apertura { get; set; }
        public Nullable<int> total_venta { get; set; }
        public Nullable<int> subtotal_debito { get; set; }
        public Nullable<int> subtotal_credito { get; set; }
    
        public virtual APERTURA APERTURA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DETALLE_VENTA> DETALLE_VENTA { get; set; }
    }
}