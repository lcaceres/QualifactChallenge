﻿namespace QualifactChallenge.PresentationLayer.Models
{
    public class PaginationViewModel<T>
    {
        public List<T> Items { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
    }
}
