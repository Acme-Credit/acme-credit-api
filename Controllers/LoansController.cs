using System.Collections.Generic;
using AcmeApi.Data;
using AcmeApi.DTOs;
using AcmeApi.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AcmeApi.Controllers
{   

    [ApiController]
    [Route("api/loans")]
    public class LoansController : ControllerBase
    {

        private readonly ILoanRepo _repository;
        private readonly IMapper _mapper;

        public LoansController(ILoanRepo loanRepo, IMapper mapper){
            _repository = loanRepo;
            _mapper = mapper;
        }

        
        // GET /api/loans
        [HttpGet]
        public ActionResult <IEnumerable<LoanReadDto>> GetAllLoans()
        {    
            var loans = _repository.GetAllLoans();
            var mappedLoans = _mapper.Map<IEnumerable<LoanReadDto>>(loans);
            return Ok(mappedLoans);
        } 

        // GET /api/loans/{loanId}
        [HttpGet("{loanId}")] 
        public ActionResult <LoanReadDto> GetLoanById(string loanId)
        {
            var loan = _repository.GetLoanById(loanId);
            if(loan == null)
            {
                return NotFound();
            }

            var mappedLoan = _mapper.Map<LoanReadDto>(loan);
            return Ok(mappedLoan);
        }
    }
}