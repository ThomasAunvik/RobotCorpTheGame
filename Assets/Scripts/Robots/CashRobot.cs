using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CashRobot : MonoBehaviour
{
    [SerializeField]
    private Animation levelAnimation;

    private void Start()
    {

    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            HitLeverTry();
        }
    }

    private void HitLeverTry()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, Vector3.forward);
        if (hit)
        {
            if (hit.collider.GetComponentInParent<CashRobot>())
            {
                PullLever();
            }
        }
    }

    void PullLever()
    {
        if (levelAnimation.isPlaying) return;
        
        levelAnimation.Play();
    }
}
