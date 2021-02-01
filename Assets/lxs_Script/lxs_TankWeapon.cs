using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class lxs_TankWeapon : MonoBehaviour {

    public GameObject Shell;
    public float ShootPower;
    public Transform ShootPoint;
    public float ShootCoolDowm;//炮弹冷却时间


    private AudioSource AudioSource;
    private LayerMask enemyLayer;
    private bool isWeaponReady = true;

	// Use this for initialization
	void Start () {
        AudioSource = GetComponent<AudioSource>();
		
	}

    public void Init(lxs_Team team)
    {
        enemyLayer = lxs_LayerManager.GetEnemyLayer(team);
    }
    public void Shoot()
    {
        if(!isWeaponReady) return;


        GameObject newShell = Instantiate(Shell, ShootPoint.position, ShootPoint.rotation) as GameObject;
        newShell.GetComponent<lxs_Shell>().Init(enemyLayer);
        Rigidbody r = newShell.GetComponent<Rigidbody>();
        r.velocity = ShootPoint.forward * ShootPower;//方向
        //AudioSource.Play();


        isWeaponReady = false;
        StartCoroutine(WeaponCooldown());
    }

    IEnumerator WeaponCooldown()//协程
    {
        yield return new WaitForSeconds(ShootCoolDowm);//定时器，射击
        isWeaponReady = true;
    }
}
