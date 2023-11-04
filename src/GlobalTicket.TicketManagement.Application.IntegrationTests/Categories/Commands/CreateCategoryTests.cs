using AutoMapper;
using GlobalTicket.CelanArch.Application.Contracts.Persistance;
using GlobalTicket.CelanArch.Application.Profiles;
using GlobalTicket.TicketManagement.API.IntegrationTests;
using GlobalTicket.TicketManagement.Application.Features.Categories.Commands.CreateCateogry;
using GlobalTicket.TicketManagement.Domain.Entities;
using Moq;
using Shouldly;

namespace GloboTicket.TicketManagement.API.IntegrationTests.Categories.Commands;
public class CreateCategoryTests
{
    private readonly IMapper _mapper;
    private readonly Mock<IAsyncRepository<Category>> _mockCategoryRepository;

    public CreateCategoryTests()
    {
        _mockCategoryRepository = RepositoryMocks.GetCategoryRepository();
        var configurationProvider = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<MappingProfile>();
        });

        _mapper = configurationProvider.CreateMapper();
    }

    [Fact]
    public async Task Handle_ValidCategory_AddedToCategoriesRepo()
    {
        var handler = new CreateCategoryCommandHandler(_mapper, _mockCategoryRepository.Object);

        await handler.Handle(new CreateCategoryCommand() { Name = "Test" }, CancellationToken.None);

        var allCategories = await _mockCategoryRepository.Object.ListAllAsync();
        allCategories.Count.ShouldBe(5);
    }
}
