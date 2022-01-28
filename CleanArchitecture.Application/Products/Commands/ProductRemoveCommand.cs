namespace CleanArchitecture.Application.Products.Commands
{
    public class ProductRemoveCommand : ProductCommand 
    {
        public ProductRemoveCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
