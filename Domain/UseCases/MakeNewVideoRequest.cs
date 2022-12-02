using Domain.Aggregates;
using Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UseCases
{
    public class MakeNewVideoRequest : IRequest<MakeNewVideoResponse>
    {
        public string Theme { get; set; }
    }

    public class MakeNewVideoResponse
    {
        public int Id { get; set; }
    }

    public class MakeNewVideoRequestHandler : IRequestHandler<MakeNewVideoRequest, MakeNewVideoResponse>
    {
        private readonly INewVideoMessage newVideoMessage;
        private readonly IVideoService videoService;

        public MakeNewVideoRequestHandler(INewVideoMessage newVideoMessage, IVideoService videoService)
        {
            this.newVideoMessage = newVideoMessage;
            this.videoService = videoService;
        }

        public async Task<MakeNewVideoResponse> Handle(MakeNewVideoRequest request, CancellationToken cancellationToken)
        {
            var theme = request.Theme.Trim();

            if (string.IsNullOrEmpty(theme))
                throw new ArgumentException("Theme is null or empty");

            var newVideo = Video.NewVideo(request.Theme);

            var id = await videoService.Create(newVideo);
            await newVideoMessage.Post(id);

            return new MakeNewVideoResponse { Id = id };
        }
    }
}
