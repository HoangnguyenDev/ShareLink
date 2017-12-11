using ShareLink.Models.HomeViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShareLink.Data
{
    public interface IHomeRepository
    {
        Task<List<IndexViewModel>> GetIndex();
    }
}
