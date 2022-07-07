using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustTrail : MonoBehaviour
{

    [SerializeField] ParticleSystem snowEffect;
    // Start is called before the first frame update
    void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.tag == "Ground")
        {
            snowEffect.Play();
        }
    }

    /// <summary>
    /// Sent when another object leaves a trigger collider attached to
    /// this object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            snowEffect.Stop();
        }
    }
}
