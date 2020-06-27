using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invincibility_Script : MonoBehaviour
{


    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            if (other.gameObject.GetComponent<Player_AreaTrigger_Script>() != null)
            {
                return;
            }

            SoundManager.PlaySound(SoundManager.Sound.PowerUp);
            other.GetComponent<PlayerCollision_Script>().IsInvincible = true;
            Destroy(gameObject);
        }
    }

}
