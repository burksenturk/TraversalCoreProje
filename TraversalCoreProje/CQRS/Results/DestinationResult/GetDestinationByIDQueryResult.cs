namespace TraversalCoreProje.CQRS.Results.DestinationResult
{
    public class GetDestinationByIDQueryResult //güncellemek istediğim verilere ait değperler
    {
        public int DestinationID { get; set; }
        public string City { get; set; }
        public string DayNight { get; set; }
        public double Price { get; set; }
    }
}
