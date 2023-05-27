﻿using MediatR;
using NxGNMovie.Application.Models.Response;
using NxGNMovie.Application.Models.Results;

namespace NxGNMovie.Application.Models.Request
{
    public class DeleteMovieRequest : IRequest<ServiceResult<DeleteMovieResponse>>
    {
        public long Id { get; set; }
    }
}
