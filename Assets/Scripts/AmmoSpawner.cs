using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoSpawner : MonoBehaviour
{
    public GameObject AmmoPrefab = null;
    public Vector2 TimeDelayRange = Vector2.zero;
    public float AmmoLifeTime = 2f;
    public float AmmoSpeed = 4f;
    public float AmmoDamage = 100f;

    // Start is called before the first frame update
    void Start()
    {
        FireAmmo();
    }

    private void FireAmmo()
    {
        GameObject Obj = Instantiate(AmmoPrefab, transform.position, transform.rotation) as GameObject;
        Ammo AmmoComp = Obj.GetComponent<Ammo>();
        Mover MoveComp = Obj.GetComponent<Mover>();
        AmmoComp.LifeTime = AmmoLifeTime;
        AmmoComp.Damage = AmmoDamage;
        MoveComp.Speed = AmmoSpeed;

        Invoke("FireAmmo", Random.Range(TimeDelayRange.x, TimeDelayRange.y));
    }
}
