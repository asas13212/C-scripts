using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationEvent : MonoBehaviour
{
    private PlayerMove playerMove ;
    // Start is called before the first frame update
    void Start()
    {
        playerMove = GetComponentInParent<PlayerMove>();
    }

    // Update is called once per frame
    public void AnimationTrigger()
    {
        playerMove.AttackOver();
    }
}
