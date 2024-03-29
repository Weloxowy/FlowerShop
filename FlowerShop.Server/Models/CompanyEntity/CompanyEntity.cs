using System.Diagnostics.Metrics;

namespace FlowerShop.Server.Models
{
    public class CompanyEntity
    {
        public CompanyEntity() : base() 
        { }

        public CompanyEntity(Guid id, string companyName, string nip, string regon, Guid companyAddress, Guid user)
        {
            this.id = id;
            this.CompanyName = companyName;
            this.NIP = nip;
            this.REGON = regon;
            this.CompanyAddress = companyAddress;
            this.User = user;
        }

        public virtual Guid id { get; set; }
        public virtual string CompanyName { get; set; }
        public virtual string NIP { get; set; }
        public virtual string REGON { get; set; }
       public virtual Guid CompanyAddress { get; set; } //Adres firmy może się różnić od adresu dostawy! Jeżeli to pole juest null to jest identyczne jak pole z UserEntity
        public virtual Guid User { get; set; }

    }
}
