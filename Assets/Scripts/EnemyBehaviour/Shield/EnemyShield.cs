using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyShield : MonoBehaviour
{
    public bool hasShield;
    public float maxShield = 0f;
    public EnemyControls ec;
    public bool correctBullet;
    public GameObject shield;

    void FixedUpdate()
    {
        chekcShield();
        ShieldDamage();
    }

    public void chekcShield()
    {

        if (shield != null)
        {
            hasShield = true;
        }
        else
        {
            hasShield = false;
        }
    }

    public void ShieldDamage()
    {
        if (ec.shield <= 0 && shield != null)
        {
            Destroy(shield);
            // ec.healthBarImage.color = new Color(255/255f, 0, 0);

        }
    }
}
// void OnCollisionExit(Collision collision)
// {
//     if (collision.gameObject.name == "DefaultBullet(Clone)")
//     {
//         correctBullet = true;
//     }
//     else
//     {
//         correctBullet = false;
//     }

// }
