﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BitcoGG_API.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BitcoGG_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoinController : ControllerBase
    {
        private readonly ICoinService _coinService;

        public CoinController(ICoinService coinService)
        {
            _coinService = coinService;
        }

        [HttpGet]
        //Get coins from api
        public async Task<IActionResult> Get()
        {
            var coins = await _coinService.GetCoins();
            return Ok(coins);
        }

        [HttpGet("{id}")]
        //Get specific coin
        public async Task<IActionResult> GetSpecific(int id)
        {
            var coins = await _coinService.GetSpecificCoin(id);
            return Ok(coins);
        }
        [HttpGet("News")]
        //Get the news from api
        public async Task<IActionResult> GetNews()
        {
            var news = await _coinService.GetNews();
            return Ok(news);
        }
    }
}