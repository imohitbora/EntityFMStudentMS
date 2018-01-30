namespace StudentManagement.Domain.Entities
{
    public class Address : BaseEntity
    {
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string City { get; set; }
        public int PinCode { get; set; }
    }
}
