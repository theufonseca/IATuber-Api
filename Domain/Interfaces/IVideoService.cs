using Domain.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IVideoService
    {
        Task<int> Create(Video video);
        Task<Video?> GetById(int id);
    }
}
