using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using splitourbill_backend.Filters;
using splitourbill_backend.Models.RequestModels;
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
        [ObtainUserId]
        [Authorize("read:bills")]
        public async Task<IActionResult> GetBill(Guid billId)
        {
            var userId = new Guid(HttpContext.User.Claims.SingleOrDefault(c => c.Type == "user_id").Value);

            var bill = await _billRepository.GetBillByBillId(billId);
            var billResponse = _mapper.Map<BillResponse>(bill);
            billResponse.Initiator = _mapper.Map<UserSimpleResponse>(await _userRepository.GetUserById(bill.InitiatorId));
            billResponse.BillPurpose = (await _billRepository.GetBillPurposes()).SingleOrDefault(p => p.Id == bill.BillPurposeId).Name;

            var billSharings = await _billRepository.GetBillSharingsByBillId(billId);
            var billSharingsResponses = _mapper.Map<IEnumerable<BillSharingResponse>>(billSharings.Where(bs => bs.SharerId != userId));
            foreach (var billSharingsResponse in billSharingsResponses)
            {
                var user = await _userRepository.GetUserById(billSharings.SingleOrDefault(b => b.Id == billSharingsResponse.Id).SharerId);
                billSharingsResponse.Sharer = _mapper.Map<UserSimpleResponse>(user);
            }
            billResponse.BillSharings = billSharingsResponses;

            billResponse.BalanceAmount = billSharings.SingleOrDefault(bs => bs.SharerId == userId).Amount;

            return Ok(billResponse);
        }

        [HttpPut]
        [Authorize("write:bills")]
        public async Task<IActionResult> UpdateBill([FromBody] UpdateBillRequest updateBillRequest)
        {
            var bill = await _billRepository.GetBillByBillId(updateBillRequest.Id);
            bill.BillPurposeId = (await _billRepository.GetBillPurposes()).SingleOrDefault(p => p.Name == updateBillRequest.BillPurpose).Id;
            bill.TotalAmount = updateBillRequest.TotalAmount;
            bill.DateTime = updateBillRequest.DateTime;
            bill.Remarks = updateBillRequest.Remarks;

            var billSharingsInDb = await _billRepository.GetBillSharingsByBillId(updateBillRequest.Id);

            foreach (var billSharing in updateBillRequest.BillSharings)
            {
                var billSharingsIdsInDb = billSharingsInDb.Select(bs => bs.Id);

                //update bill sharings
                if (billSharingsIdsInDb.Contains(billSharing.Id))
                {
                    var billSharingInDb = billSharingsInDb.SingleOrDefault(bs => bs.Id == billSharing.Id);
                    if (!decimal.Equals(billSharingInDb.Amount, billSharing.Amount))
                        billSharingInDb.Amount = billSharing.Amount;
                }
                //remove old bill sharings
            }

            //update own share
            var ownSharing = billSharingsInDb.SingleOrDefault(bs => bs.SharerId == updateBillRequest.InitiatorId);
            if (!decimal.Equals(ownSharing.Amount, updateBillRequest.BalanceAmount))
                ownSharing.Amount = updateBillRequest.BalanceAmount;

            //add new bill sharings


            await _unitOfWork.CompleteAsync();

            return Ok("ok");
        }
    }
}