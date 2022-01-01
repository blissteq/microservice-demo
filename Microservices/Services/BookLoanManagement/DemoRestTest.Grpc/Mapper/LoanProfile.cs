using AutoMapper;
using DemoRestTest.Abstraction.BookLoan.Model;
using DemoRestTest.Grpc.Protos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoRestTest.Grpc.Mapper
{
    public class LoanProfile: Profile
    {
        public LoanProfile()
        {
            CreateMap<Loan, LoanModel>().ReverseMap();
        }
    }
}
