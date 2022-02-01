using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Rules
{
    public class BrandBusinessRules
    {
        IBrandRepository _brandRepository;

        public BrandBusinessRules(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        //Gerkhin 
        public async Task BrandNameCanNotBeDuplicatedWhenInserted(string name) 
        {
            var result = await _brandRepository.GetListAsync(b => b.Name == name);
            if (result.Items.Any()) {
                throw new BusinessException("Brand name exists");
            }
        }
    }
}
