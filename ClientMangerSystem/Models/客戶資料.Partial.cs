namespace ClientMangerSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    [MetadataType(typeof(客戶資料MetaData))]
    public partial class 客戶資料
    {
    }
    
    public partial class 客戶資料MetaData
    {
        [Required]
        public int Id { get; set; }
        [DisplayName("客戶名稱")]
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string 客戶名稱 { get; set; }
        [DisplayName("統一編號")]
        [StringLength(8, ErrorMessage="欄位長度不得大於 8 個字元")]
        [Required]
        public string 統一編號 { get; set; }
        [DisplayName("電話")]
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string 電話 { get; set; }
        
        [DisplayName("傳真")]
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        public string 傳真 { get; set; }
        
        [DisplayName("地址")]
        [StringLength(100, ErrorMessage="欄位長度不得大於 100 個字元")]
        public string 地址 { get; set; }
        
        [DisplayName("電子信箱")]
        [StringLength(250, ErrorMessage="欄位長度不得大於 250 個字元")]
        public string Email { get; set; }

        [DisplayName("是否刪除")]
        [Required]
        public int is刪除 { get; set; }

        public virtual ICollection<客戶銀行資訊> 客戶銀行資訊 { get; set; }
        public virtual ICollection<客戶聯絡人> 客戶聯絡人 { get; set; }
    }
}
