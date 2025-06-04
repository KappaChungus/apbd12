using abdp12.DTOS;

namespace abdp12.Services;

public interface IDbService
{
    Task<PagedResultDTO<TripDTO>> GetTrips(int page, int pageSize);
}