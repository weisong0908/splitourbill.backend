using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BillsController(IBillRepository billRepository, IUserRepository userRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _billRepository = billRepository;
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
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

        [HttpGet("{billId}")]
        public async Task<IActionResult> GetBill(Guid billId)
        {
            var bill = await _billRepository.GetBillByBillId(billId);
            var billResponse = new BillResponse();
            billResponse.Id = bill.Id;
            billResponse.Initiator = _mapper.Map<UserSimpleResponse>(await _userRepository.GetUserById(bill.InitiatorId));
            billResponse.TotalAmount = bill.TotalAmount;
            billResponse.Remarks = bill.Remarks;
            billResponse.DateTime = bill.DateTime;
            billResponse.BillPurpose = (await _billRepository.GetBillPurposes()).SingleOrDefault(p => p.Id == bill.BillPurposeId).Name;

            var billSharings = await _billRepository.GetBillSharingsByBillId(billId);
            var billSharingsResponse = new List<BillSharingResponse>();
            foreach (var billSharing in billSharings)
            {
                billSharingsResponse.Add(new BillSharingResponse()
                {
                    Id = billSharing.Id,
                    Sharer = _mapper.Map<UserSimpleResponse>(await _userRepository.GetUserById(billSharing.SharerId)),
                    Amount = billSharing.Amount
                });
            }
            billResponse.BillSharings = billSharingsResponse;

            return Ok(billResponse);
        }
    }
}