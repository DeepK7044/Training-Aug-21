using AutoMapper;
using DominosAPI.DTOs;
using DominosAPI.IRepository;
using DominosAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DominosAPI.Repository
{
    public class OfferRepository : GenericRepository<Offer>, IOfferRepository
    {
        private readonly DominosDatabaseContext _context;
        private readonly IMapper _mapper;

        public OfferRepository(DominosDatabaseContext context, IMapper mapper) : base(context)
        {
            _context = context;
            _mapper = mapper;
        }

        public IQueryable<OfferDTO> GetAllOffers()
        {
            try
            {
                var Offers = _context.Offers.Select(offer => new OfferDTO()
                {
                    OfferId = offer.OfferId,
                    OfferUrl = offer.OfferUrl,
                    OfferTitle = offer.OfferTitle,
                    Description = offer.Description,
                    MaxDiscount = offer.MaxDiscount,
                    MinAmount = offer.MinAmount,
                    DiscountPercentage = offer.DiscountPercentage,
                    DiscountAmount = offer.DiscountAmount,
                    CreationTime=offer.CreationTime,
                    ModificationTime=offer.ModificationTime,
                    DeletionTime=offer.DeletionTime,
                    IsActive=offer.IsActive,
                    PaymentType = _context.PaymentTypes.FirstOrDefault(paymentType => paymentType.Id == offer.PaymentTypeId).PaymentMethod
                });
                return Offers;
            }

            catch (Exception)
            {
                throw;
            }
        }

        public OfferDTO GetOffer(int OfferId)
        {
            try
            {
                var Offer = _context.Offers.FirstOrDefault(offer => offer.OfferId == OfferId);
                return (_mapper.Map<OfferDTO>(Offer));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool UpdateOffer(int OfferId,Offer entity)
        {
            try
            {
                var ExistingOffer = _context.Offers.FirstOrDefault(offer=>offer.OfferId==OfferId);
                ExistingOffer.OfferTitle = entity.OfferTitle;
                ExistingOffer.OfferUrl = entity.OfferUrl;
                ExistingOffer.PaymentTypeId= entity.PaymentTypeId;
                ExistingOffer.ModificationTime = DateTime.Now;
                ExistingOffer.MaxDiscount = entity.MaxDiscount;
                ExistingOffer.MinAmount = entity.MinAmount;
                ExistingOffer.DiscountAmount = entity.DiscountAmount;
                ExistingOffer.Description = entity.Description;
                ExistingOffer.DiscountPercentage = entity.DiscountPercentage;
                ExistingOffer.IsActive = true;

                _context.Offers.Update(ExistingOffer);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override bool Delete(Offer entity)
        {
            try
            {
                entity.IsActive = false;
                entity.DeletionTime = DateTime.Now;
                Update(entity);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}

