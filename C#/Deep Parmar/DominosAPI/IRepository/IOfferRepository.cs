using DominosAPI.DTOs;
using DominosAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DominosAPI.IRepository
{
    public interface IOfferRepository:IGenericRepository<Offer>
    {
        IQueryable<OfferDTO> GetAllOffers();
        OfferDTO GetOffer(int OfferId);
        bool UpdateOffer(int OfferId,Offer entity);
    }
}
