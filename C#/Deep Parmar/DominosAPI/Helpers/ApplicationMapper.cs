using AutoMapper;
using DominosAPI.Authentication;
using DominosAPI.DTOs;
using DominosAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DominosAPI.Helpers
{
    public class ApplicationMapper:Profile
    {
        public ApplicationMapper()
        {
            CreateMap<Employee, EmployeeDTO>().ReverseMap();
            CreateMap<Address, EmployeeDTO>().ReverseMap();
            CreateMap<Offer, OfferDTO>().ReverseMap();
            CreateMap<Pizza, PizzaDTO>().ReverseMap();
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<PizzaStore, PizzaStoreDTO>().ReverseMap();
            CreateMap<Topping, ToppingDTO>().ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<RegisterModel, UserDTO>()
                .ForMember(dest=>dest.EmailAddress,opt=>opt.MapFrom(src=>src.Email))
                .ReverseMap();
            CreateMap<ContactU, ContactUsDTO>().ReverseMap();
            CreateMap<Address, AddressDTO>()
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address1))
                .ForMember(dest => dest.Pincode, opt => opt.MapFrom(src => src.PincodeId))
                .ReverseMap();
            CreateMap<Cart, CartItemsDTO>().ReverseMap();
            CreateMap<VpizzaOrderTopping, OrderDetailsDTO>().ReverseMap();
        }
    }
}
