namespace SiteX.Web.ViewModels.BlogViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using SiteX.Data.Models;
    using SiteX.Data.Models.Blog;
    using SiteX.Services.Mapping;

    public class PostOutViewModel : IMapFrom<Post>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        public ApplicationUser Poster { get; set; }

        public DateTime Date { get; set; }

        public string PreviewImage { get; set; }

        public string PreviewBody { get; set; }

        public ICollection<Comment> Comments { get; set; } = new List<Comment>();

        public ICollection<Genre> Genres { get; set; } = new List<Genre>();

        public ICollection<PostImage> PostImages { get; set; } = new List<PostImage>();

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Post, PostOutViewModel>()
                  .ForMember(x => x.PreviewBody, opt =>
                  {
                      opt.MapFrom(x => x.Body.Substring(0, x.Body.Length >= 600 ? 600 : x.Body.Length));
                  })
                  .ForMember(x => x.Genres, opt =>
                  {
                      opt.MapFrom(x => x.PostGenres.Select(x => x.Genre).ToList());
                  })
                  .ForMember(x => x.PreviewImage, opt =>
                  {
                      opt.MapFrom(x => x.PostImages.Select(x => x.Path).FirstOrDefault());
                  })
                  .ForMember(x => x.Date, opt =>
                  {
                      opt.MapFrom(x => x.CreatedOn);
                  });

        }
    }
}
