namespace CleanArchitecture.Application.Products.Commands
{
    public class ProductUpdateCommand : ProductCommand
    {
        public ProductUpdateCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
