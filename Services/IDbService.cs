using abdp12.DTOS;

namespace abdp12.Services;

public interface IDbService
{
    Task<PagedResultDTO<TripDTO>> GetTrips(int page, int pageSize);
    Task<(int Code, string Message)> DeleteClient(int clientId);
    Task<(int Code, string Message)> AttachClientToTrip(int tripId, AttachClientToTripDTO attachClientToTripDTO);
}