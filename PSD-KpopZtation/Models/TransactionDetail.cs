//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PSD_KpopZtation.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TransactionDetail
    {
        public int TransactionID { get; set; }
        public int AlbumID { get; set; }
        public int Qty { get; set; }
    
        public virtual Album Album { get; set; }
        public virtual TransactionHeader TransactionHeader { get; set; }
    }
}
