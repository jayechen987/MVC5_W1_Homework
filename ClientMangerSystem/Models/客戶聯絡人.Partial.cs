namespace ClientMangerSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    [MetadataType(typeof(客戶聯絡人MetaData))]
    public partial class 客戶聯絡人 : IValidatableObject
    {
        private List<string> mailList;

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if ( this.mailList.Contains(this.Email))
            {
                yield return new ValidationResult("本人資料已使用該Mail信箱",
                    new string[] { "Email" });
            }
        }
    }
    
    public partial class 客戶聯絡人MetaData
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int 客戶Id { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        [DisplayName("職稱")]
        public string 職稱 { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        [DisplayName("姓名")]
        public string 姓名 { get; set; }
        
        [StringLength(250, ErrorMessage="欄位長度不得大於 250 個字元")]
        [Required]
        [DisplayName("Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        public string 手機 { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [DisplayName("電話")]
        [RegularExpression(@"\d{4}-\d{6}")]
        public string 電話 { get; set; }

        [DisplayName("是否刪除")]
        [Required]
        public bool is刪除 { get; set; }


        public virtual 客戶資料 客戶資料 { get; set; }
    }
    
}
