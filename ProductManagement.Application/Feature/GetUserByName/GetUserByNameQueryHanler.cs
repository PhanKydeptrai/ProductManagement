﻿using MediatR;
using ProductManagement.Domain.Entities;
using ProductManagement.Domain.IRepositories;

namespace ProductManagement.Application.Feature.GetUserByName;

public class GetUserByNameQueryHanler : IRequestHandler<GetUserByNameQuery, Result<List<User>>>
{
    private readonly IUserRepository _userRepository;
    public GetUserByNameQueryHanler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public async Task<Result<List<User>>> Handle(GetUserByNameQuery request, CancellationToken cancellationToken)
    {
        Result<List<User>> result = new Result<List<User>>
        {
            IsSuccess = true,
            Value = new List<User>(),
            Errors = new List<string>()
        };

        IQueryable userQuery = await _userRepository.GetQueryAbleOfUser();

        if(!string.IsNullOrWhiteSpace(request.UserName))
        {
            userQuery = userQuery.Cast<User>().Where(a => a.UserName.Contains(request.UserName));
        }

        result.Value = userQuery.Cast<User>().ToList();

        return result;
    }
}

