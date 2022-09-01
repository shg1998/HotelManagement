﻿using Newtonsoft.Json;

namespace HotelManagement.Models
{
    public class Error
    {
        public string StatusCode { get; set; }
        public string Message { get; set; }
        public override string ToString() => JsonConvert.SerializeObject(this);
    }
}
