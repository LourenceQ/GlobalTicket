﻿using MediatR;

namespace GlobalTicket.CelanArch.Application.Features.Categories.Queries.GetCategoriesList;
public class GetCategoriesListQuery : IRequest<List<CategoryListVm>>
{
}
