using Unity.Entities;
using UnityEngine;

namespace ECS.Hybrid.Components {
	public struct Weapon: IComponentData {
    }
    
    public class WeaponComponent : ComponentDataWrapper<Weapon> {
        
    }
}
