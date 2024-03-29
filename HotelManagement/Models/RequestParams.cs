﻿namespace HotelManagement.Models
{
    public class RequestParams
    {
        private const int MaxPageSize = 45;
        public int PageNumber { get; set; } = 1;

        private int _pageSize;
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }
    }
}
