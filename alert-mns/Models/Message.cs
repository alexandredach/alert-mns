namespace alert_mns.Entities
{
    public class Message
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string Attachment { get; set; }
        public DateTime DispatchDate { get; set; }
    }
}
