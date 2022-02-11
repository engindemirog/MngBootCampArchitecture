using Application.Features.Brands.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Queries.GetBrandList
{
    public class GetBrandListQuery:IRequest<BrandListModel>,ICachableRequest
    {
        public PageRequest PageRequest { get; set; }

        public bool BypassCache { get; set; }

        public string CacheKey => "brands-list";

        public TimeSpan? SlidingExpiration { get; set; }

        public class GetBrandListQueryHandler : IRequestHandler<GetBrandListQuery, BrandListModel>
        {
            IBrandRepository _brandRepository;
            IMapper _mapper;

            public GetBrandListQueryHandler(IBrandRepository brandRepository, IMapper mapper)
            {
                _brandRepository = brandRepository;
                _mapper = mapper;
            }

            public async Task<BrandListModel> Handle(GetBrandListQuery request, CancellationToken cancellationToken)
            {
                var brands = await _brandRepository.GetListAsync(
                    index:request.PageRequest.Page,
                    size:request.PageRequest.PageSize);

                var mappedBrands = _mapper.Map<BrandListModel>(brands);
                return mappedBrands;
            }
        }
    }
}
