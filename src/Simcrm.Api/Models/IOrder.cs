namespace Simcrm.Api.Controllers
{
    public interface IOrder
    {
        int Quantity { get; set; }
        string ProductCode { get; set; }
    }
}