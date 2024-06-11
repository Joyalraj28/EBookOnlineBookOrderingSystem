using System;
using System.Collections.Generic;
using System.Linq;

namespace EBookOnlineBookOrderingSystem.Models.ViewModel
{
    public class PageBar
    {
        public int PageNumber { get; set; }
        public bool Active { get; set; }
    }

    public class PaginatedItemsViewModel<T>
    {
        public int FisrtPage => 1;
        public int LastPage => TotalPages;
        public IList<T> Items { get; set; }
        public List<PageBar> PageBarList => GetPageBar();
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalItems { get; set; }
        private List<PageBar> GetPageBar()
        {
            var pagebar = new List<PageBar>();
            for (int i = 1; i <= TotalPages; i++)
            {
                pagebar.Add(new PageBar { Active = i == CurrentPage, PageNumber = i });
            }
            return pagebar;
        }
        public int TotalPages => (int)Math.Ceiling((double)TotalItems / PageSize);
    }
    public class PaginationViewModel<T>
    {
        PaginatedItemsViewModel<T> paginatedItemsViewModel;

        public PaginationViewModel(IList<T> item,int pageSize=5)
        {

            paginatedItemsViewModel = new PaginatedItemsViewModel<T> 
            {
                CurrentPage = 1,
                Items = item,
                PageSize = pageSize,
                TotalItems = item.Count,
            };
        }

        
        private IList<T> GetItems()
        {
            // Sample data
            return paginatedItemsViewModel.Items;
        }

        public PaginatedItemsViewModel<T> GetPageItem(int page = 1)
        {
            var items = GetItems();
            var paginatedItems = items.Skip((page - 1) * paginatedItemsViewModel.PageSize).Take(paginatedItemsViewModel.PageSize).ToList();
            var totalItems = items.Count;

            var model = new PaginatedItemsViewModel<T>
            {
                Items = paginatedItems,
                CurrentPage = page,
                PageSize = paginatedItemsViewModel.PageSize,
                TotalItems = totalItems,
            };

            return model;
        }
    }
}