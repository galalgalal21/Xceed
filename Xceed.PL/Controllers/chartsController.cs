using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Xceed.BLL.Interfaces;
using Xceed.PL.Models;

namespace Xceed.PL.Controllers
{
    public class chartsController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public chartsController(IUnitOfWork unitOfWork, IMapper _mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = _mapper;
        }

        public async Task<IActionResult> PieChart()
        
        {
            var data = await unitOfWork.EmployeeRep.GetAll();
            var model = mapper.Map<List<EmployeeVM>>(data);
            return View(model);
        }

        public async Task<IActionResult> LineChart()

        {
            var data = await unitOfWork.EmployeeRep.GetAll();
            var model = mapper.Map<List<EmployeeVM>>(data);
            return View(model);
        }
    }
}
