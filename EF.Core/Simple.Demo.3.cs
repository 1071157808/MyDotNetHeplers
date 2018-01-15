using System;
using System.ComponentModel.DataAnnotations;
namespace ContosoUniversity.Models.SchoolViewModels {
    public class EnrollmentDateGroup {
        [Required]
        [StringLength (50)]
        [Column ("FirstName")]
        [Display (Name = "Last Name", ErrorMessage = "First name cannot be longer than 50 characters."))]
    public string LastName { get; set; }

    [DataType (DataType.Date)]
    [DisplayFormat (DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime? EnrollmentDate { get; set; }
    public int StudentCount { get; set; }
    //下面的这个字段不会被设置为列，因为没有set
    [Display (Name = "Full Name")]
    public string FullName {
        get {
            return LastName + ", " + FirstMidName;
        }
    }
}