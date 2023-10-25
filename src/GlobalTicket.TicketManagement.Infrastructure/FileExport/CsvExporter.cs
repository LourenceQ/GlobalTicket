using CsvHelper;
using GlobalTicket.CelanArch.Application.Contracts.Infrastructure;
using GlobalTicket.CelanArch.Application.Features.Events.Queries.GetEventsExport;
using System.Globalization;

namespace GlobalTicket.TicketManagement.Infrastructure.FileExport;
public class CsvExporter : ICsvExporter
{
    public byte[] ExportEventsToCsv(List<EventExportDto> eventExportDto)
    {
        using var memoryStream = new MemoryStream();
        using (var streamWriter = new StreamWriter(memoryStream))
        {
            using var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture, false);
            csvWriter.WriteRecord(eventExportDto);
        }

        return memoryStream.ToArray();
    }
}
