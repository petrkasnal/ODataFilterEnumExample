using AutoMapper;
using AutoMapper.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using ODataFilterEnumExample.Dtos;
using ODataFilterEnumExample.Models;

namespace ODataFilterEnumExample.Controllers
{
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly IMapper _mapper;

        public CustomerController(IMapper mapper)
        {
            _mapper = mapper;
        }

        // Test url: https://localhost:7000/Customer?$filter=CustomerType in ('New', 'External')
        [HttpGet(Name = "Customers")]
        public IEnumerable<CustomerDto> Customers(ODataQueryOptions<CustomerDto> query)
        {
            var data = new List<Customer>() {
                new Customer() {
                    Id = 1,
                    Name = "Test",
                    CustomerType = Models.CustomerType.New
                },
                new Customer() {
                    Id = 2,
                    Name = "Test2",
                    CustomerType = Models.CustomerType.External
                }
            }.AsQueryable();

            var dtoData = data.GetQuery(_mapper, query).ToList();

            return dtoData;
        }
    }
}
