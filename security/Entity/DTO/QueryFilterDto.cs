namespace Entity.DTO
{
    public class QueryFilterDto
    {
        public int PageNumber { get; internal set; }
        public int PageSize { get; internal set; }
        public string? ColumnOrder { get; internal set; }
        public string? DirectionOrder { get; internal set; }
        public object Filter { get; internal set; }
    }
}