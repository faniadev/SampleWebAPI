using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SampleWebAPI.ValidationAttributes;

namespace SampleWebAPI.Dtos
{
    [StudentFirstLastMustBeDifferent]
    public class StudentForCreateDto 
    {
        [Required(ErrorMessage = "Kolom FirstName harus diisi")]
        [MaxLength(20, ErrorMessage = "Tidak boleh lebih dari 20 karakter")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Kolom LastName harus diisi")]
        [MaxLength(20, ErrorMessage = "Tidak bolej lebih dari 20 karakter")]
        public string LastName { get; set; }
        
        [Required]
        public DateTime EnrollmentDate { get; set; }

        /*public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (FirstName == LastName)
            {
                yield return new ValidationResult("Firstname dan Lastname tidak boleh sama",
                    new[] { "StudentForCreateDto" });
            }
            
        }*/
    }
}
