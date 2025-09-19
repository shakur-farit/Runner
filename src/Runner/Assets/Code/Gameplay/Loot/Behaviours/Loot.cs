using System;
using UnityEngine;

namespace Assets.Code.Gameplay.Loot.Behaviours
{
	public class Loot : MonoBehaviour
	{
    public event Action Pickedup;

    public LootTypeId TypeId { get; private set; }
    public int Value { get; private set; }

    public void Setup(LootTypeId typeId, int value)
    {
      TypeId = typeId;
      Value = value;
    }

    public void CallPickedup() => 
			Pickedup?.Invoke();
	}
}