namespace MvcHomework2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(V_CustomerDetailSumMetaData))]
    public partial class V_CustomerDetailSum
    {
    }
    
    public partial class V_CustomerDetailSumMetaData
    {
        [Required]
        public int Id { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        public string CustomerName { get; set; }
        public Nullable<int> NumOfBanks { get; set; }
        public Nullable<int> NumOfContacts { get; set; }
    }
}
