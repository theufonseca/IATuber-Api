using Domain.Enum;
using Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UseCases
{
    public class GetVideoStatusRequest : IRequest<GetVideoStatusResponse>
    {
        public int VideoId { get; set; }
    }

    public class GetVideoStatusResponse
    {
        public VIDEO_STATUS Status { get; set; }
        public string StatusText { get { return Status.ToString(); } }
    }

    public class GetVideoStatusRequestHandler : IRequestHandler<GetVideoStatusRequest, GetVideoStatusResponse>
    {
        private readonly IVideoService videoService;

        public GetVideoStatusRequestHandler(IVideoService videoService)
        {
            this.videoService = videoService;
        }

        public async Task<GetVideoStatusResponse> Handle(GetVideoStatusRequest request, CancellationToken cancellationToken)
        {
            if (request.VideoId == 0)
                throw new ArgumentException("VideoId needs to be filled");

            var video = await videoService.GetById(request.VideoId);

            if (video is null)
                throw new ArgumentException("Video not found");

            return new GetVideoStatusResponse { Status = video.Status };
        }
    }
}
