namespace SiteX.Data.Models.Team
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using SiteX.Data.Common.Models;

    public class Member : BaseDeletableModel<Guid>
    {
        [Required]
        [MaxLength(30)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(30)]
        public string LastName { get; set; }

        [Required]
        public string Picture { get; set; }

        [Required]
        [MaxLength(700)]
        public string Description { get; set; }

        public ApplicationUser Account { get; set; }

        public string AccountId { get; set; }

    }
}
