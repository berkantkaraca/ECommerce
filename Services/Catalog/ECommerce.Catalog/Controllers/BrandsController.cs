﻿using ECommerce.Catalog.Dtos.BrandDtos;
using ECommerce.Catalog.Services.BrandServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Catalog.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly IBrandService _brandService;

        public BrandsController(IBrandService BrandService)
        {
            _brandService = BrandService;
        }

        [HttpGet]
        public async Task<IActionResult> BrandList()
        {
            var values = await _brandService.GetAllBrandAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBrandById(string id)
        {
            var values = await _brandService.GetByIdBrandAsync(id);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBrand(CreateBrandDto createBrandDto)
        {
            await _brandService.CreateBrandAsync(createBrandDto);
            return Ok("Marka eklendi.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBrand(UpdateBrandDto updateBrandDto)
        {
            await _brandService.UpdateBrandAsync(updateBrandDto);
            return Ok("Marka güncellendi.");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBrand(string id)
        {
            await _brandService.DeleteBrandAsync(id);
            return Ok("Marka silindi.");
        }
    }
}
