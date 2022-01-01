using DemoRestTest.Grpc.Protos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoRest.API.GrpcService
{
    public class LoanGrpcService
    {
        private readonly LoanProtoService.LoanProtoServiceClient _loanProtoService;

        public LoanGrpcService(LoanProtoService.LoanProtoServiceClient loanProtoService)
        {
            _loanProtoService = loanProtoService ?? throw new ArgumentNullException(nameof(loanProtoService));
        }

        public async Task<LoanModel> GetLoan(int id )
        {
            var loanRequest = new GetLoanRequest { Id = id };
            return await _loanProtoService.GetLoanAsync(loanRequest);
        }

        public async Task<LoanModel> CreateLoan(LoanModel loan)
        {
            var loanRequest = new CreateLoanRequest { Loan = loan };
            return await _loanProtoService.CreateLoanAsync(loanRequest);
        }
    }
}
