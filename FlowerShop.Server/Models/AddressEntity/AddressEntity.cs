namespace FlowerShop.Server.Models.AddressEntity
{ 
public class AddressEntity
{
    public AddressEntity() : base()
    { }

    public AddressEntity(Guid id, string fullStreet, string postalCode, string city, string voivodeship, string country, Guid userAddress)
    {
        this.id = id;
        FullStreet = fullStreet;
        PostalCode = postalCode;
        City = city;
        Voivodeship = voivodeship;
        Country = country;
        UserAddress = userAddress;
    }

    public virtual Guid id { get; set; }
    public virtual string FullStreet { get; set; }
    public virtual string PostalCode { get; set; }
    public virtual string City { get; set; }
    public virtual string Voivodeship { get; set; }
    public virtual string Country { get; set; }
    public virtual Guid UserAddress { get; set; }

}
}