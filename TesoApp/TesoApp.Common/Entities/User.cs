namespace TesoApp.Common.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;
    public class User
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [MaxLength(50, ErrorMessage = "The maximun length for field {0} is {1} characters")]
        [Display(Name = "First name")]
        public string FullName { get; set; }

        [DataType(DataType.ImageUrl)]
        public string Picture { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [MaxLength(100, ErrorMessage = "The maximun length for field {0} is {1} characters")]
        [DataType(DataType.EmailAddress)]
        //[Index("User_Email_Index", IsUnique = true)]
        public string Email { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [MaxLength(20, ErrorMessage = "The maximun length for field {0} is {1} characters")]
        //[Index("User_NickName_Index", IsUnique = true)]
        [Display(Name = "Nick name")]
        public string NickName { get; set; }


        [Required(ErrorMessage = "The field {0} is required")]
        [MaxLength(20, ErrorMessage = "The maximun length for field {0} is {1} characters")]
        //[Index("User_NickName_Index", IsUnique = true)]
        [Display(Name = "Phone")]
        public string Phone { get; set; }
        public string Password { get; set; }


    }
}
