namespace WebApi_ASPNETCore.Domain.Base
{
    public abstract class baseEntity
    {
        public Guid Id { get;private set; }

        public baseEntity()
        {
            Id = Guid.NewGuid();
        }
    }
}
