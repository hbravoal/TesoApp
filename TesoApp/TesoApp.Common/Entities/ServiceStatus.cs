namespace TesoApp.Common.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class ServiceStatus : IEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [MaxLength(50, ErrorMessage = "The maximun length for field {0} is {1} characters")]
        [Display(Name = "Name")]
        public string Name { get; set; }
    }
}
