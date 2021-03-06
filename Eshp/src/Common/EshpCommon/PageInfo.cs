﻿namespace EshpCommon
{
    public class PageRequest
    {
        public int PageNumber { get; set; }

        public int ResultsInPage { get; set; }

        public PageRequest(int page, int count)
        {
            PageNumber = page;
            ResultsInPage = count;
        }
    }

    public class PageResult<T> where T: class
    {
        public int PageNumber { get; set; }

        public int PagesCount { get; set; }

        public T Results { get; set; }
    }
}
