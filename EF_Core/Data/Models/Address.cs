namespace EF_Core.Data.Models
{
    //    [Owned] // for make it owned to class that have Navigational Property
    //   [Keyless]
    public class Address
    {
        //  public int Id { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }

    }
}
