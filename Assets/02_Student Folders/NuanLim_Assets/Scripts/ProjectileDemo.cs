﻿using UnityEngine;

[RequireComponent(typeof(ProjectileBase), typeof(SelectiveDamageable))]
public class ProjectileDemo : ProjectileStandard {

    private ProjectileBase _base;

    private void Start() {
        _base = GetComponent<ProjectileBase>();
    }

    protected override void OnHit(Vector3 point, Vector3 normal, Collider coll) {
        // damage
        if (!areaOfDamage) {
            SelectiveDamageable damageable = coll.GetComponent<SelectiveDamageable>();
            if (damageable != null) {
                damageable.InflictDamageBy(damage, false, _base.owner, gameObject);
            }
        }

        base.OnHit(point, normal, coll);
    }
}
