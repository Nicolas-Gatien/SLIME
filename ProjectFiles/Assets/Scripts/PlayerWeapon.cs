using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    public GameObject bullet;
    public GameObject bulletSound;
    public GameObject bomb;

    public Transform firePoint;
    public float shootTime;

    public float gunShootTime;
    public float bombDropTime;

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        shootTime += Time.deltaTime;
        if(SpecialManager.state == SpecialManager.playerState)
        {
            if ((Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Mouse1)) && shootTime > gunShootTime && mousePos.y < 6.5f)
            {
                FindObjectOfType<CameraShake>().ShakeScreen(1);
                Instantiate(bulletSound, firePoint.position, firePoint.rotation);

                Instantiate(bullet, firePoint.position, firePoint.rotation);
                shootTime = 0;
            }
        }
        if(SpecialManager.state == SpecialManager.flyingState)
        {
            if ((Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Mouse1)) && shootTime > bombDropTime && mousePos.y < 6.5f)
            {
                Instantiate(bulletSound, firePoint.position, firePoint.rotation);

                GameObject curBomb = Instantiate(bomb, firePoint.position, firePoint.rotation);
                curBomb.GetComponent<Bomb>().evil = false;
                shootTime = 0;
            }
        }
       
    }


}
