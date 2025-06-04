namespace abdp12.DTOS;

public class PagedResultDTO<T>
{
    public int PageNum { get; set; }
    public int PageSize { get; set; }
    public int AllPages { get; set; }
    public List<T> Trips { get; set; }
}