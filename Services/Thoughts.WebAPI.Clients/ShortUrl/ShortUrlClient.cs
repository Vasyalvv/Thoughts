﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Microsoft.Extensions.Configuration;

using Thoughts.Interfaces;
using Thoughts.Interfaces.Base;
using Thoughts.WebAPI.Clients.Base;
using baseEntities = Thoughts.Domain.Base.Entities;

namespace Thoughts.WebAPI.Clients.ShortUrl
{
    public class ShortUrlClient: BaseClient, IShortUrlManager
    {
        public ShortUrlClient(IConfiguration Configuration):base(Configuration,WebApiControllersPath.ShortUrlV1)
        {

        }

        public async Task<int> AddUrlAsync(string Url, CancellationToken Cancel = default)
        {
            if (!Regex.IsMatch(Url, @"^https?://"))
                throw new FormatException("Строка адреса не имеет схемы");

            var response = await PostAsync<string>($"{WebApiControllersPath.ShortUrlV1}", Url);
            return await response.Content.ReadAsAsync<int>();
        }

        public async Task<bool> DeleteUrlAsync(int Id, CancellationToken Cancel = default)
        {
            var response = await DeleteAsync($"{WebApiControllersPath.ShortUrlV1}/{Id}");
            return response.IsSuccessStatusCode;
        }

        public async Task<string> GetAliasByIdAsync(int Id, int Length, CancellationToken Cancel = default)
        {
            var response = await GetAsync<string>($"{WebApiControllersPath.ShortUrlV1}/alias/{Id}?Length={Length}");
            return response;
        }

        public async Task<IEnumerable<baseEntities.ShortUrl>> GetStatistic(int Id = 0, int Length=0, CancellationToken Cancel = default)
        {
            var response = await GetAsync<IEnumerable<baseEntities.ShortUrl>>($"{WebApiControllersPath.ShortUrlV1}/getstat/{Id}?Length={Length}");
            return response;
        }

        public async Task<Uri?> GetUrlAsync(string Alias, CancellationToken Cancel = default)
        {
            var response = await GetAsync<Uri?>($"{WebApiControllersPath.ShortUrlV1}?Alias={Alias}");
            return response;
        }

        public async Task<Uri?> GetUrlByIdAsync(int Id, CancellationToken Cancel = default)
        {
            var response = await GetAsync<Uri?>($"{WebApiControllersPath.ShortUrlV1}/{Id}");
            return response;
        }

        public async Task<bool> ResetStatistic(int Id = 0, CancellationToken Cancel = default)
        {
            var response = await GetAsync<bool>($"{WebApiControllersPath.ShortUrlV1}/resetstat/{Id}");
            return response;
        }

        public async Task<bool> UpdateUrlAsync(int Id, string Url, CancellationToken Cancel = default)
        {
            var response = await PostAsync<string>($"{WebApiControllersPath.ShortUrlV1}/{Id}", Url);
            return await response.Content.ReadAsAsync<bool>();
        }

    }
}
