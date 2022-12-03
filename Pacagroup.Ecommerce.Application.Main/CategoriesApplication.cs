#region Region Using
using AutoMapper;
using Pacagroup.Ecommerce.Application.DTO;
using Pacagroup.Ecommerce.Application.Interface;
using Pacagroup.Ecommerce.Domain.Interface;
using Pacagroup.Ecommerce.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace Pacagroup.Ecommerce.Application.Main
{
    public class CategoriesApplication : ICategoriesApplication
    {
        private readonly ICategoriesDomain _categoriesDomain;
        private readonly IMapper _mapper;
        private readonly IAppLogger<CategoriesApplication> _logger;

        public CategoriesApplication(ICategoriesDomain categoriesDomain, IMapper mapper, IAppLogger<CategoriesApplication> logger)
        {
            _categoriesDomain = categoriesDomain;
            _mapper = mapper;
            _logger = logger;   
        }

        public async Task<Response<IEnumerable<CategoriesDto>>> GetAll()
        {
            var response = new Response<IEnumerable<CategoriesDto>>();
            try
            {
                var categories = await _categoriesDomain.GetAll();
                response.Data = _mapper.Map<IEnumerable<CategoriesDto>>(categories);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta Exitosa!!!";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
