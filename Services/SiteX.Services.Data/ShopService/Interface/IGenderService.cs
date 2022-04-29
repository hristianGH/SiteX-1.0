namespace SiteX.Services.Data.ShopService.Interface
{
    using System.Collections.Generic;

    public interface IGenderService
    {
        public IEnumerable<string> GetGenders();
    }
}
