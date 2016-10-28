using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClientMangerSystem.Models
{
    public class ClientViewModel
    {
        public 客戶資料 Client {get;set;}
        public 客戶聯絡人 ClientContact { get; set; }
        public 客戶銀行資訊 ClientBank { get; set; }
    }
}