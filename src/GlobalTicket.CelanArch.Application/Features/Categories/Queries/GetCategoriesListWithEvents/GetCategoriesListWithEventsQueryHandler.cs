﻿using AutoMapper;
using GlobalTicket.CelanArch.Application.Contracts.Persistance;
using MediatR;

namespace GlobalTicket.CelanArch.Application.Features.Categories.Queries.GetCategoriesListWithEvents;
public class GetCategoriesListWithEventsQueryHandler
    : IRequestHandler<GetCategoriesListWithEventsQuery, List<CategoryEventListVm>>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public GetCategoriesListWithEventsQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }



    public async Task<List<CategoryEventListVm>> Handle(GetCategoriesListWithEventsQuery request, CancellationToken cancellationToken)
    {
        var list = await _categoryRepository.GetCategoriesWithEvents(request.IncludeHistory);

        return _mapper.Map<List<CategoryEventListVm>>(list);
    }
}
