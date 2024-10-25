namespace EffectiveDelivery.Application.Deliveries.Requests;

public class GetDeliveryFilterRequest
{
    public required string CityDistrict { get; set; }
    public required DateTime FirstDeliveryDateTime { get; set; }    
}