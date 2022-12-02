using Domain.Aggregates;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.MySql.Services
{
    public class VideoService : IVideoService
    {
        private readonly IServiceScopeFactory serviceScopeFactory;

        public VideoService(IServiceScopeFactory serviceScopeFactory)
        {
            this.serviceScopeFactory = serviceScopeFactory;
        }

        public async Task<int> Create(Video video)
        {
            using var dataContext = serviceScopeFactory.CreateScope()
                .ServiceProvider.GetRequiredService<DataContext>();

            await dataContext.Video.AddAsync(video);
            await dataContext.SaveChangesAsync();
            return video.Id;
        }

        public async Task<Video?> GetById(int id)
        {
            using var dataContext = serviceScopeFactory.CreateScope()
                .ServiceProvider.GetRequiredService<DataContext>();

            return await dataContext.Video.FirstOrDefaultAsync(x => x.Id == id) ?? null;
        }
    }
}
