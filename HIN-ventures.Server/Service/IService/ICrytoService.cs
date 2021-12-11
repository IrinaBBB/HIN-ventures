using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HIN_ventures.Models;

namespace HIN_ventures.Server.Service.IService
{
    public interface ICrytoService
    {
        public Task<CryptoDto> CreateTransaction(CryptoDto request);
    }
}
