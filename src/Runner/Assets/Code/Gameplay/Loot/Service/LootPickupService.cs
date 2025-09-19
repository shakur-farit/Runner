namespace Assets.Code.Gameplay.Loot.Service
{
  public class LootPickupService : ILootPickupService
  {
    private readonly ICoinService _coinService;

    public LootPickupService(ICoinService coinService) => 
      _coinService = coinService;

    public void Pickup(LootTypeId typeId, int value)
    {
      switch (typeId)
      {
        case LootTypeId.Coin:
          _coinService.ChangeCoinCount(value);
          break;
      }
    }
  }
}