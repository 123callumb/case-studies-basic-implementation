﻿using Microsoft.EntityFrameworkCore;
using Services.EntityFramework.DbEntities;
using Services.GenericRepository;
using Services.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.QuoteManagement.Implementation
{
    public class QuoteManager : IQuoteManager
    {
        private readonly IGenericQuerier _genericQuerier;
        private readonly IGenericRepo _genericRepo;
        public QuoteManager(IGenericQuerier genericQuerier, IGenericRepo genericRepo)
        {
            _genericQuerier = genericQuerier;
            _genericRepo = genericRepo;
        }

        public async Task<QuoteDTO> GetQuote(int quoteID)
        {
            return await _genericQuerier.Load(QuoteDTO.MapToDTO, w => w.QuoteId == quoteID).FirstOrDefaultAsync();
        }
        public async Task<List<QuoteOverviewDTO>> GetQuotes()
        {
            return await _genericQuerier.Load(QuoteOverviewDTO.MapToDTO).OrderBy(q => q.QuoteDate).ToListAsync();
        }

        public async Task<List<QuoteOverviewDTO>> GetVendorQuotes(int vendorID)
        {
            return await _genericQuerier.Load(QuoteOverviewDTO.MapToDTO, w => w.VendorItem.VendorId == vendorID).ToListAsync();
        }

        public async Task<bool> RequestQuote(VendorItemDTO item, int quantity)
        {           
            Quote q = new Quote()
            {
                QuantityRequested = quantity,
                VendorItemId = item.ItemID,
                QuoteDate = DateTime.Now
            };
            return (await _genericRepo.Add(q)) > 0;
        }
    }
}
