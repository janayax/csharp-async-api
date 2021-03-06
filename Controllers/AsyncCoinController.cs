using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Threading;

namespace asyncAPI.Controllers
{

    [Route("api/[controller]")]
    public class AsyncCoinController: Controller
    {
        //GET api/asynccoin/5
        [HttpGet("{requestedAmount}")]
        public async Task<string> GetAsync(int requestedAmount)
        {
            //return $"{requestedAmount} AsyncCoin!";
            return await AcquireAsyncCoinAsync(requestedAmount);
        }

        public async Task<string> AcquireAsyncCoinAsync(int requestedAmount) 
        {
            var msg=string.Empty;
            msg += $"Your mining operation started at {DateTime.Now}" + Environment.NewLine;
            var result = await PretendToConnectToCoinServiceAsync(requestedAmount);
            msg+= $"Your mining operation finished at {DateTime.Now}" + Environment.NewLine;
            msg+= $"result: {result}";
            return msg;
        }

        private async Task<string> PretendToConnectToCoinServiceAsync(int requestedAmount)
        {
            //Simulate a long-running network connection
            //Thread.Sleep(requestedAmount*1000);
            await Task.Delay(requestedAmount*1000);
            return $"You've got {requestedAmount} AsyncCoin!";
        }
    }
}