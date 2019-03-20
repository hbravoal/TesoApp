namespace TesoApp.Core.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Service
    {
        [Key]
        public int ServiceId { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [MaxLength(50, ErrorMessage = "The maximun length for field {0} is {1} characters")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        //[JsonIgnore]
        public virtual ICollection<Employee> Employees { get; set; }

    }
}
