using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class TankWeapon : MonoBehaviour {

    public GameObject Shell;//子弹预制体
    public float ShootPower;//射击力度
    public Transform ShootPoint;//发射点
    public float ShootCoolDowm;//炮弹冷却时间
    private AudioSource AudioSource;//射击音效
    private LayerMask enemyLayer;
    private bool isWeaponReady = true;//子弹冷却

	// Use this for initialization
	void Start () {
        AudioSource = GetComponent<AudioSource>();
	}

    public void Init(Team team)
    {
        enemyLayer = LayerManager.GetEnemyLayer(team);
    }
    public void Shoot()
    {
        if(!isWeaponReady) return;

        GameObject newShell = Instantiate(Shell, ShootPoint.position, ShootPoint.rotation) as GameObject;
        newShell.GetComponent<Shell>().Init(enemyLayer);
        Rigidbody r = newShell.GetComponent<Rigidbody>();
        r.velocity = ShootPoint.forward * ShootPower;//方向
        AudioSource.Play();
        isWeaponReady = false;
        StartCoroutine(WeaponCooldown());
    }

    IEnumerator WeaponCooldown()//协程，子弹冷却时间
    {
        yield return new WaitForSeconds(ShootCoolDowm);//定时器，射击
        isWeaponReady = true;
    }
}
