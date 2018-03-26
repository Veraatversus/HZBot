
namespace HZBot
{
    public interface IHideOutCost
    {
        HideOut HideOut { get; set; }
        int price_gold { get; set; }
        int price_glue { get; set; }
        int price_stone { get; set; }
    }
}
