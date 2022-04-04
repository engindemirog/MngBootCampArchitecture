using Application.Features.Brands.Commands.CreateBrand;
using Application.Features.Brands.Dtos;
using Core.ElasticSearch;
using Core.ElasticSearch.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ElasticTestController : BaseController
    {
        IElasticSearch _elasticSearch;

        public ElasticTestController(IElasticSearch elasticSearch)
        {
            _elasticSearch = elasticSearch;
        }

        [HttpGet]
        public async Task<IActionResult> Get() 
        {
            var result = await _elasticSearch.CreateNewIndexAsync(new IndexModel
            {
                IndexName ="brands",
                AliasName = "alsbrands",
                NumberOfReplicas = 1,
                NumberOfShards = 1
            });

            var model = new ElasticSearchInsertUpdateModel 
            { IndexName = "brands", Item = new CreateBrandCommand { Name = "BMW" } };

            var result2 = await _elasticSearch.InsertAsync(model);

            var result3 = _elasticSearch.GetIndexList().Keys;

            var result4 = await _elasticSearch.GetSearchByField<BrandListDto>(new SearchByFieldParameters { IndexName="brands",FieldName="Name",Value="BMW"});

            return Ok(result4);
        }
    }
}
