using AutoMapper;
using DominosAPI.DTOs;
using DominosAPI.IRepository;
using DominosAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DominosAPI.Repository
{
    public class PizzaStoreRepository:GenericRepository<PizzaStore>, IPizzaStoreRepository
    {
        private readonly DominosDatabaseContext _context;
        private readonly IMapper _mapper;

        public PizzaStoreRepository(DominosDatabaseContext context, IMapper mapper) : base(context)
        {
            _context = context;
            _mapper = mapper;
        }

        public IQueryable<PizzaStoreDTO> GetPizzaStores()
        {
            try
            {
                var PizzaStores = _context.PizzaStores.Select(store => new PizzaStoreDTO()
                {
                    StoreId=store.StoreId,
                    StoreName=store.StoreName,
                    TableCapacity=store.TableCapacity,
                    ChairCapacity=store.ChairCapacity,
                    OpeningTime=store.OpeningTime,
                    ClosingTime=store.ClosingTime,
                    ContactNumber=store.ContactNumber,
                    CreationTime=store.CreationTime,
                    ModificationTime=store.ModificationTime,
                    DeletionTime=store.DeletionTime,
                    Address = _context.Addresses.SingleOrDefault(Address => Address.StoreId == store.StoreId).Address1,
                    Pincode = _context.Addresses.FirstOrDefault(address => address.StoreId == store.StoreId).PincodeId,
                    Rating=store.Rating,
                    Status = store.Status,
                });

                return PizzaStores;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public PizzaStoreDTO GetPizzaStore(int StoreId)
        {
            try
            {
                var PizzaStore = _context.PizzaStores.Find(StoreId);
                var PizzaStoreDTO = _mapper.Map<PizzaStoreDTO>(PizzaStore);
                PizzaStoreDTO.Address = _context.Addresses.FirstOrDefault(Address => Address.StoreId == StoreId).Address1;
                PizzaStoreDTO.Pincode = _context.Addresses.FirstOrDefault(Address => Address.StoreId == StoreId).PincodeId;

                return PizzaStoreDTO;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public IQueryable<object> GetAllPizzaStore(int Pincode)
        {
            try
            {
                var PizzaStores = from s in _context.PizzaStores 
                                  join p in _context.Addresses
                                  on s.StoreId equals p.StoreId
                                  where p.PincodeId == Pincode
                                  select new
                                  {
                                      s.StoreId,
                                      s.StoreName,
                                      s.ContactNumber,
                                      s.TableCapacity,
                                      s.ChairCapacity,
                                      s.OpeningTime,
                                      s.ClosingTime,
                                      p.Address1,
                                      p.PincodeId,
                                      s.CreationTime,
                                      s.ModificationTime,
                                      s.DeletionTime,
                                      s.Rating,
                                      s.Status,
                                  };
                

                return PizzaStores;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public bool UpdatePizzaStore(int StoreId, PizzaStoreDTO entity)
        {
            try
            {
                var ExistingPizzaStore = _context.PizzaStores.FirstOrDefault(store => store.StoreId == StoreId);
                var Address = _context.Addresses.FirstOrDefault(Address => Address.StoreId == StoreId);


                ExistingPizzaStore.StoreName = entity.StoreName;
                ExistingPizzaStore.TableCapacity= entity.TableCapacity;
                ExistingPizzaStore.ChairCapacity= entity.ChairCapacity;
                ExistingPizzaStore.ContactNumber = entity.ContactNumber;
                ExistingPizzaStore.OpeningTime = entity.OpeningTime;
                ExistingPizzaStore.ClosingTime = entity.ClosingTime;
                ExistingPizzaStore.ModificationTime = DateTime.Now;
                ExistingPizzaStore.Rating = entity.Rating;
                ExistingPizzaStore.Status = true;

                Address.Address1 = entity.Address;
                Address.PincodeId = entity.Pincode;
                _context.Addresses.Update(Address);
                _context.SaveChanges();
                return true;
      
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void AddPizzaStore(PizzaStoreDTO entity)
        {
            try
            {
                _context.Database.ExecuteSqlRaw($"execute Sp_AddEntityData @Choice=2,@Name='{entity.StoreName}',@TableCapacity={entity.TableCapacity},@ChairCapacity={entity.ChairCapacity},@PhoneNumber='{entity.ContactNumber}',@OpeningTime='08:00:00 PM',@ClosingTime='08:00:00 PM',@Address='{entity.Address}',@Pincode={entity.Pincode},@IsActive=true");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override bool Delete(PizzaStore entity)
        {
            try
            {
                entity.Status = false;
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
