namespace TesoApp.Common.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Service
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [MaxLength(50, ErrorMessage = "The maximun length for field {0} is {1} characters")]
        [Display(Name = "Name")]
        public string ShortDescription { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [MaxLength(50, ErrorMessage = "The maximun length for field {0} is {1} characters")]
        [Display(Name = "Name")]
        public string LongtDescription { get; set; }


        public int ServiceTypeId { get; set; }
        public ServiceType ServiceType { get; set; }

        public int ServiceStatusId { get; set; }
        public ServiceStatus ServiceStatus { get; set; }
    }
}
