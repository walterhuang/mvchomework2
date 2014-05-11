using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace MvcHomework2.Models
{
    public class CustomerVM
    {
        public int Id { get; set; }
        [DisplayName("客戶名稱")]
        public string CustomerName { get; set; }
        [DisplayName("聯絡人數量")]
        public int NumOfContacts { get; set; }
        [DisplayName("銀行帳戶數量")]
        public int NumOfBanks { get; set; }
    }
}