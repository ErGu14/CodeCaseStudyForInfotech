﻿using Commercium.Service.Interfaces;
using Commercium.Shared.CategoryRMs;
using Commercium.Shared.ReturnRMs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Commercium.API.Controllers
{
    [ApiController]
    [Route("api/category")]
    public class CategoryController : CustomizingController
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [Authorize(Roles = "Admin, BusinessOwner, SalesRepresentative, User")]
        [HttpGet("{categoryId}")]
        public async Task<IActionResult> GetCategoryById(int categoryId)
        {
            var response = await _categoryService.GetCategoryByIdAsync(categoryId);
            return CreateReturn(response);
        }

  
        [Authorize(Roles = "Admin, BusinessOwner, SalesRepresentative, User")]
        [HttpGet("all")]
        public async Task<IActionResult> GetAllCategories()
        {
            var response = await _categoryService.GetAllCategoriesAsync();
            return CreateReturn(response);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("create")]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryRM createCategoryRM)
        {
            var response = await _categoryService.CreateCategoryAsync(createCategoryRM);
            return CreateReturn(response);
        }

       
        [Authorize(Roles = "Admin")]
        [HttpPut("update")]
        public async Task<IActionResult> UpdateCategory([FromBody] UpdateCategoryRM updateCategoryRM)
        {
            var response = await _categoryService.UpdateCategoryAsync(updateCategoryRM);
            return CreateReturn(response);
        }

      
        [Authorize(Roles = "Admin")]
        [HttpDelete("delete/{categoryId}")]
        public async Task<IActionResult> DeleteCategory(int categoryId)
        {
            var response = await _categoryService.DeleteCategoryAsync(categoryId);
            return CreateReturn(response);
        }

        [Authorize(Roles = "Admin, BusinessOwner, SalesRepresentative, User")]
        [HttpGet("{categoryId}/products")]
        public async Task<IActionResult> GetProductsByCategory(int categoryId)
        {
            var response = await _categoryService.GetProductsByCategoryAsync(categoryId);
            return CreateReturn(response);
        }

        [Authorize(Roles = "Admin, BusinessOwner, SalesRepresentative, User")]
        [HttpGet("{categoryId}/product-count")]
        public async Task<IActionResult> GetProductCountByCategory(int categoryId)
        {
            var response = await _categoryService.GetProductCountByCategoryAsync(categoryId);
            return CreateReturn(response);
        }


        [Authorize(Roles = "Admin, BusinessOwner, SalesRepresentative, User")]
        [HttpGet("top")]
        public async Task<IActionResult> GetTopCategories([FromQuery] int count)
        {
            var response = await _categoryService.GetTopCategoriesAsync(count);
            return CreateReturn(response);
        }
    }

}
