using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Person : FallingItem
{
    public GameObject TargetPrefab, AngelPrefab;
    public override void HitLava()
    {
        base.HitLava();
    }
    public override void ItemDeath()
    {
      
        GameObject obj = Instantiate(AngelPrefab, transform.position, Quaternion.identity);
        obj.GetComponent<Angel>().Target = Instantiate(TargetPrefab, transform.position + Vector3.up, Quaternion.identity).transform;
        Destroy(gameObject);
    }
    public override IEnumerator SinkDeBoi()
    {
        Sinking = true;
        float Duration = 0;
        while (Duration < SinkTime)
        {
            yield return new WaitForSeconds(SinkInterval);
            Duration += SinkInterval;
            coll.size = new Vector2(0.44f * (1f - Duration / SinkTime), 1);
            coll.offset = new Vector2(0.44f * (1f - coll.size.x) / 2f-0.04f, 0);
        }
        ItemDeath();
    }
}

