using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boom : Rod
{
    private Transform _Rod;
    public void Bang(Vector3 pos ,bool flag =false)
    {
        var hits = Physics2D.CircleCastAll(pos , 3 , Vector2.zero);
        //vi tri
        //ban kinh
        //khoanh cach
        foreach(var hit in hits)
        {   if (hit.collider == null) continue;
            if(hit.transform.tag == Config.TAG_GOLD)
            {
                //xoa gold
                Destroy(hit.transform.gameObject);
                AudioManager.Instance.PlaySFX("bomno");

            }
            else if(hit.transform.tag ==Config.TAG_BOOM)
            {
                //kich hoat no boom
                hit.transform.tag = Config.TAG_GOLD;
                hit.transform.GetComponent<Boom>().Bang(hit.point, true);
                AudioManager.Instance.PlaySFX("bomno");

            }

            //neu flag =true thi xoa chinh no
            //neu khong ghi gi coi nhu fale
           
        }
       // if (flag = true)
         //  Destroy(gameObject);
    }
}
