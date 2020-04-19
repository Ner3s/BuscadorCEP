﻿using Refit;
using System.Threading.Tasks;

namespace BuscadorCEP
{
    public interface ICepApiService
    {
        [Get("/ws/{cep}/json")]
        Task<CepResponse> GetAddressAsync(string cep);
    }
}
