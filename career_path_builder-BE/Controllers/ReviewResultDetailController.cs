﻿using demo_model;
using demo_service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace career_path_builder_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewResultDetailController : ControllerBase
    {
        private readonly IReviewResultDetailService _reviewResultDetailService;
        public ReviewResultDetailController(IReviewResultDetailService reviewResultDetailService)
        {
            _reviewResultDetailService = reviewResultDetailService;
        }

        [HttpGet]
        [Route("getAllReviewResultDetail")]
        public async Task<IActionResult> getAllReviewResultDetail()
        {
            var getlist = _reviewResultDetailService.GetAllReviewResultDetail();
            return Ok(getlist);
        }

        [HttpPost]
        [Route("addReviewResultDetail")]
        public async Task<IActionResult> addReviewResultDetail(List<Add_Review_Result_Detail> add_Review_Result_Detail)
        {
            var add = _reviewResultDetailService.AddReviewResultDetail(add_Review_Result_Detail);
            return Ok(add);
        }
    }
}
