using System.Linq;
using UnityEngine;

public class SelectiveDamageable : Damageable {

    public GameObject[] projectiles;

    public void InflictDamageBy(float damage, bool explosion, GameObject source, GameObject by) {
        if (projectiles.All(p => p.GetType() == by.GetType())) {
            base.InflictDamage(damage, explosion, source);
        }
    }

    public override void InflictDamage(float damage, bool isExplosionDamage, GameObject damageSource) {
        // Doesn't do anything here si that ProjectileDemo.OnHit can call the base method safely
    }
}
