using abdp12.Data;
using abdp12.DTOS;
using Microsoft.EntityFrameworkCore;

namespace abdp12.Services;

public class DbService : IDbService
{
    MasterContext _context;
    public DbService(MasterContext context)
    {
        _context = context;
    }
    public async Task<PagedResultDTO<TripDTO>> GetTrips(int page, int pageSize)
    {
        var totalTrips = await _context.Trips.CountAsync();
        var allPages = (int)Math.Ceiling(totalTrips / (double)pageSize);

        var trips = await _context.Trips
            .OrderByDescending(t => t.DateFrom)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .Select(t => new TripDTO
            {
                Name = t.Name,
                Description = t.Description,
                DateFrom = t.DateFrom,
                DateTo = t.DateTo,
                MaxPeople = t.MaxPeople,
                Countries = t.IdCountries.Select(c => new CountryDTO 
                { 
                    Name = c.Name 
                }).ToList(),
                Clients = t.ClientTrips.Select(ct => new ClientDTO 
                { 
                    FirstName = ct.IdClientNavigation.FirstName, 
                    LastName = ct.IdClientNavigation.LastName
                }).ToList()
            })
            .ToListAsync();

        return new PagedResultDTO<TripDTO>
        {
            PageNum = page,
            PageSize = pageSize,
            AllPages = allPages,
            Trips = trips
        };

    }

    public async Task<(int Code, string Message)> DeleteClient(int clientId)
    {
        bool clientHasTrip = await _context.ClientTrips
            .AnyAsync(ct => ct.IdClient == clientId);

        if (clientHasTrip)
            return (400, "Client has trip reservation");

        int res = await _context.Clients
            .Where(c => c.IdClient == clientId)
            .ExecuteDeleteAsync();

        if (res == 0)
            return (404, "No such user");

        return (200, "Client deleted successfully");
    }
}