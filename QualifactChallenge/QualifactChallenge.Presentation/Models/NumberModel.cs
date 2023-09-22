using System.ComponentModel.DataAnnotations;

namespace QualifactChallenge.PresentationLayer.Models
{
    public class NumberModel
    {
        [Required]
        [Display(ResourceType =typeof(Resource), Name ="Input1")]
        [Range(1, int.MaxValue, ErrorMessage = "The value must be a positive integer.")]
        public int Input1 { get; set; }

        [Required]
        [Display(ResourceType = typeof(Resource), Name = "Input2")]
        [Range(1, int.MaxValue, ErrorMessage = "The value must be a positive integer.")]
        public int Input2 { get; set; }

        [Required]
        [Display(ResourceType = typeof(Resource), Name = "SampleSize")]
        [Range(0, int.MaxValue, ErrorMessage = "The value must be a positive integer.")]
        public int SampleSize { get; set; }
    }
}
