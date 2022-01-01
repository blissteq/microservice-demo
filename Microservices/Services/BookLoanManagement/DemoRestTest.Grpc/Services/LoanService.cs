using AutoMapper;
using DemoRestTest.Abstraction.BookLoan.Model;
using DemoRestTest.Abstraction.BookLoan.Repository;
using DemoRestTest.Abstraction.BookLoan.Service;
using DemoRestTest.Grpc.Protos;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoRestTest.Grpc.Services
{
    public class LoanService : LoanProtoService.LoanProtoServiceBase
    {
        private readonly ILoanApplication _service;
        private readonly ILogger<LoanService> _logger;
        private readonly IMapper _mapper;

        public LoanService(ILoanApplication service, Logger<LoanService> logger, IMapper mapper)
        {
            _service= service;
            _logger = logger;
            _mapper = mapper;
        }
        public override async Task<LoanModel> GetLoan(GetLoanRequest request, ServerCallContext context)
        {

            var loan = await _service.GetLoan(request.Id);
            if (loan == null)
            {
                throw new RpcException(new Status(StatusCode.NotFound, $"Discount with ProductName={request.Id} is not found."));
            }
            var loanModel = _mapper.Map<LoanModel>(loan);
            return loanModel;
        }

        public override async Task<LoanModel> CreateLoan(CreateLoanRequest request, ServerCallContext context)
        {
            var loan = _mapper.Map<Loan>(request.Loan);
            await _service.AddLoan(loan);

            var loanModel = _mapper.Map<LoanModel>(loan);
            return loanModel;

        }

        public override async Task<LoanModel> UpdateLoan(UpdateLoanRequest request, ServerCallContext context)
        {
            var loan = _mapper.Map<Loan>(request.Loan);
            await _service.UpdateLoan(loan);

            var loanModel = _mapper.Map<LoanModel>(loan);
            return loanModel;
        }

        public override async Task<DeleteLoanResponse> DeleteLoan(DeleteLoanRequest request, ServerCallContext context)
        {
            var deleted = await _service.DeleteLoan(request.Id);
            var response = new DeleteLoanResponse
            {
                Success = deleted
            };
            return response;
        }
    }
}
