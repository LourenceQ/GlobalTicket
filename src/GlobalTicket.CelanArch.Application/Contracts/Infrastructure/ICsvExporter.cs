using GlobalTicket.CelanArch.Application.Features.Events.Queries.GetEventsExport;

namespace GlobalTicket.CelanArch.Application.Contracts.Infrastructure;
public interface ICsvExporter
{
    byte[] ExportEventsToCsv(List<EventExportDto> eventExportDto);
}
