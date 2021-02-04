﻿using Microsoft.EntityFrameworkCore;
using Services.DTOs;
using Services.GenericRepository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.VendorItemManagement.Implementation
{
    public class VendorItemManager : IVendorItemManager
    {
        private readonly IGenericQuerier _genericQuereir;
        public VendorItemManager(IGenericQuerier genericQuerier)
        {
            _genericQuereir = genericQuerier;
        }
        public async Task<List<VendorItemDTO>> LoadVendorItems()
        {
            return await _genericQuereir.Load(VendorItemDTO.MapToDTO).ToListAsync();
        }
    }
}
