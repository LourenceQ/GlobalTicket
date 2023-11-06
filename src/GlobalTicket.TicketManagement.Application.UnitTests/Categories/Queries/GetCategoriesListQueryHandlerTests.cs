using AutoMapper;
using GlobalTicket.CelanArch.Application.Contracts.Persistance;
using GlobalTicket.CelanArch.Application.Features.Categories.Queries.GetCategoriesList;
using GlobalTicket.CelanArch.Application.Profiles;
using GlobalTicket.TicketManagement.Application.UnitTests.Mocks;
using GlobalTicket.TicketManagement.Domain.Entities;
using Moq;
using Shouldly;
using Xunit;

namespace GlobalTicket.TicketManagement.Application.UnitTests.Categories.Queries;

public class GetCategoriesListQueryHandlerTests
{
    private readonly IMapper _mapper;
    private readonly Mock<IAsyncRepository<Category>> _mockCategoryRepository;
    public GetCategoriesListQueryHandlerTests()
    {
        _mockCategoryRepository = RepositoryMocks.GetCategoryRepository();
        var configurationProvider = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<MappingProfile>();
        });

        _mapper = configurationProvider.CreateMapper();
    }

    [Fact]
    public async Task GetCategoriesListTest()
    {
        var handler = new GetCategoriesListQueryHandler(_mockCategoryRepository.Object, _mapper);

        var result = await handler.Handle(new GetCategoriesListQuery(), CancellationToken.None);

        result.ShouldBeOfType<List<CategoryListVm>>();

        result.Count.ShouldBe(4);
    }
}
