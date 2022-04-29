namespace SiteX.Web.ViewModels.BlogViewModels
{
    using System.ComponentModel.DataAnnotations;

    public class GenreViewModel
    {
        [Required]
        [MaxLength(100)]
        [MinLength(3)]
        public string Name { get; set; }
    }
}
