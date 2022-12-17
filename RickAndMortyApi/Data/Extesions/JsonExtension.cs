﻿using Newtonsoft.Json;
using System.Text;

namespace RickAndMortyApi.Data.Extesions
{
    public static class Extensions
    {
        public static StringContent AsJson(this object o)
            => new StringContent(JsonConvert.SerializeObject(o), Encoding.UTF8, "application/json");
    }
}
