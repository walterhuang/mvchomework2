namespace MvcHomework2.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    [MetadataType(typeof(CustomerMetaData))]
    public partial class Customer
    {
    }
    
    public partial class CustomerMetaData
    {
        [Required]
        public int Id { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string Name { get; set; }
        
        [StringLength(8, ErrorMessage="欄位長度不得大於 8 個字元")]
        [Required]
        public string 統一編號 { get; set; }
        
        [StringLength(100, ErrorMessage="欄位長度不得大於 100 個字元")]
        public string Address { get; set; }
        
        [StringLength(250, ErrorMessage="欄位長度不得大於 250 個字元")]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public System.DateTime DateCreated { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string Phone { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        public string Fax { get; set; }
    
        public virtual ICollection<Contact> Contacts { get; set; }
        public virtual ICollection<客戶銀行資訊> 客戶銀行資訊 { get; set; }
    }
}
