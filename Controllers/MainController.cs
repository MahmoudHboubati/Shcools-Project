using AutoMapper;
using vega.Persistence;

namespace vega.Controllers
{
    public abstract class MainController : BaseController
    {
        public MainController(VegaDbContext context, IMapper mapper)
        {
            this.mapper = mapper;
            this.context = context;
        }

        protected readonly VegaDbContext context;
        protected readonly IMapper mapper;
    }
}