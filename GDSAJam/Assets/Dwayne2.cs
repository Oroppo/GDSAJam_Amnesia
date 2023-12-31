using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Dwayne2 : FallingItem
{
    //Flash VFX
    public Material FlashMat;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public override void HitLava()
    {
        base.HitLava();
    }
    public override void ItemDeath()
    {
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
            coll.size = new Vector2(1.312824f, (1f - Duration / SinkTime)* 0.47f);
            coll.offset = new Vector2(0, 0.47f*(1f - coll.size.y)/ 2f -0.12f);
            if (Duration >= (SinkTime - 1))
            {
                GetComponent<SpriteRenderer>().material = FlashMat;
            }
        }
        ItemDeath();

    }


}

