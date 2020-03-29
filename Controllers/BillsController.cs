using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using splitourbill_backend.Models.ResponseModels;
using splitourbill_backend.Persistence;

namespace splitourbill_backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BillsController : ControllerBase
    {
        private readonly IBillRepository _billRepository;
        private readonly IUnitOfWork _unitOfWork;

        public BillsController(IBillRepository billRepository, IUnitOfWork unitOfWork)
        {
            _billRepository = billRepository;
            _unitOfWork = unitOfWork;
        }

        [HttpGet("purposes")]
        public async Task<IActionResult> GetBillPurposes()
        {
            var billPusposes = await _billRepository.GetBillPurposes();

            var categories = billPusposes.Select(b => b.Category).Distinct();

            var billPusposesResponses = new List<BillPurposesResponse>();

            foreach (var category in categories)
            {
                var options = billPusposes.Where(b => b.Category == category).Select(b => b.Name);
                billPusposesResponses.Add(new BillPurposesResponse(category, options));
            }

            return Ok(billPusposesResponses);
        }
    }
}