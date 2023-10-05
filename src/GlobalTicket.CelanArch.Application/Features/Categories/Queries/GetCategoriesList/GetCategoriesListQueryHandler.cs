﻿using AutoMapper;
using GlobalTicket.CelanArch.Application.Contracts.Persistance;
using GloboTicket.TicketManagement.Domain.Entities;
using MediatR;

namespace GlobalTicket.CelanArch.Application.Features.Categories.Queries.GetCategoriesList;
public class GetCategoriesListQueryHandler
    : IRequestHandler<GetCategoriesListQuery, List<CategoryListVm>>
{
    private readonly IAsyncRepository<Category> _categoryRepository;
    private readonly IMapper _mapper;
    public GetCategoriesListQueryHandler(IAsyncRepository<Category> categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }
    public async Task<List<CategoryListVm>> Handle(GetCategoriesListQuery request, CancellationToken cancellationToken)
    {
        var allCategories = (await _categoryRepository.ListAllAsync()).OrderBy(x => x.Name);

        return _mapper.Map<List<CategoryListVm>>(allCategories);
    }
}
