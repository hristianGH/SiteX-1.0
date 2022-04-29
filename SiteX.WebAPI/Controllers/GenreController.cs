using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SiteX.Data.Models.Blog;
using SiteX.Services.Data.BlogService.Interface;
using SiteX.Web.ViewModels.BlogViewModels;
using System.Threading.Tasks;

namespace SiteX.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class GenreController : ControllerBase
    {
        private readonly IGenreService genreService;

        public GenreController(IGenreService genreService)
        {
            this.genreService = genreService;
        }
        [HttpGet("All")]
        public ActionResult Index()
        {
            var genres = this.genreService.GetGenres();
            return Ok(genres);
        }

 

        [HttpPost("Create")]
        public async Task<IActionResult> Create(GenreViewModel viewModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest();
            }

            await this.genreService.CreateAsync(viewModel);
            return this.Ok(viewModel);
        }

        // POST: GenreController/Edit/5
        [HttpPut("Edit")]
        public async Task<IActionResult> Edit(Genre genre)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest();
            }

            await this.genreService.EditAsync(genre);

            return this.Ok(genre);
        }

    }
}
