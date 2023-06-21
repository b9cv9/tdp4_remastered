using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bullet;
    public float offset;
    public Transform shotPoint;
    private float timeBtwShots;
    public float startTimeBtwShots;
    public int bullets_summ;

    void Update()
    {
        if (PlayerMovement.check_rotation_right == true) offset = 0;
        if (PlayerMovement.check_rotation_right == false) offset = 180;
        Vector3 diference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotateZ = Mathf.Atan2(diference.y, diference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotateZ + offset);

        if (bullets_summ > 0)
        {
            if (timeBtwShots <= 0)
            {
                if (Input.GetKey(KeyCode.Mouse0))
                {
                    Instantiate(bullet, shotPoint.position, Quaternion.identity);
                    timeBtwShots = startTimeBtwShots;
                }
            
            }
            else
            {
                timeBtwShots -= Time.deltaTime;
            }
        }
    }
}
