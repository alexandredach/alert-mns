namespace alert_mns.Entities
{
    public class WorkTime
    {
        public int Id { get; set; }
        public DateOnly WorkDate { get; set; } // vraiment utile ?
        public DateTime ArrivalTime { get; set; }
        public DateTime DepartureTime { get; set; }
    }
}
