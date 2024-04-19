//using System;
//using AutoMapper;
//using MediatR;
//using WMBProject.Core.Bases.ResponseBase;
//using WMBProject.Core.Features.Customers.Commands.Models;
//using WMBProject.Core.Features.Customers.Commands.Responses;
//using WMBProject.Data.Entities;
//using WMBProject.Data.Enums;
//using WMBProject.Service.Customers;

//namespace WMBProject.Core.Features.Customers.Commands.Handlers
//{
//    public class CustomerHandlers : ResponseHandler, IRequestHandler<CreateCustomerCommand, Response<CustomerResponse>>,
//                                                     IRequestHandler<LoginCustomerCommand, Response<CustomerResponse>>
//    {
//        private readonly IMapper _mapper;
//        private readonly ICustomerService _customerService;
//        public CustomerHandlers(ICustomerService customerService, IMapper mapper)
//        {
//            _customerService = customerService;
//            _mapper = mapper;
//        }

//        public async Task<Response<CustomerResponse>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
//        {
//            var customerMapping = _mapper.Map<Customer>(request);
//            var result = await _customerService.CheckCreatetCustomer(customerMapping);
//            switch (result)
//            {
//                case CheckCustomer.Exist:
//                    return BadRequest<CustomerResponse>("The customer is already exist");
//                case CheckCustomer.NotExit:
//                    var customer = await _customerService.CreateCustomer(customerMapping);
//                    var newCustomerMapping = _mapper.Map<CustomerResponse>(customer);
//                    return Created(newCustomerMapping);
//                default:
//                   return BadRequest<CustomerResponse>("internal server error");
//            }
//        }

//        public async Task<Response<CustomerResponse>> Handle(LoginCustomerCommand request, CancellationToken cancellationToken)
//        {
//            var result = await _customerService.CheckLoginCustomer(request.Username, request.Password);

//            switch (result)
//            {
//                case CheckCustomer.NotExit:
//                    return BadRequest<CustomerResponse>("The customer is not exist");
//                case CheckCustomer.Exist:
//                    var customer =  _customerService.LoginCustomer(request.Username,request.Password);
//                    var newCustomerMapping = _mapper.Map<CustomerResponse>(customer);
//                    return Success(newCustomerMapping);
//                default:
//                    return BadRequest<CustomerResponse>("internal server error");
//            }
//        }
//    }
//}

