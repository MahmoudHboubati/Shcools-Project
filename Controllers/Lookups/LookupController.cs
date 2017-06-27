using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using vega.Persistence;

namespace vega.Controllers.Lookups
{
    public abstract class LookupController : MainController
    {
        public LookupController(VegaDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}