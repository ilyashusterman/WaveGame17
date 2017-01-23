using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public float damage = 25f;
	public float movementSpeed = 10f;
	public GameObject explosion;



	//void OnTriggerEnter (Collider collider){
		//Debug.Log ("colliding with" + collider.gameObject.name);
        //Trigger explosion
      //  Projectile projectile = collider.gameObject.GetComponent<Projectile>();
        //Enemy enemy = collider.gameObject.GetComponent<Enemy>();
        //Boat player = collider.gameObject.GetComponent<Boat>();
       //Shark shark = collider.gameObject.GetComponent<Shark>();
   //     if (!projectile)
    //    {
   //     explosion.SetActive(true);
		//Destroy(projectile,0.1f);
        //    if (enemy)
        //    {
        //        enemy.takeDamage(damage);//TODO
		      //  Destroy(gameObject,0.2f);
        //    }
        //    else if (shark)
        //    {
        //        shark.takeDamage(damage);//TODO
        //        Destroy(gameObject, 0.2f);
        //    }
        //    else if (player)
        //    {
        //        player.takeDamage(damage);//TODO
        //        Destroy(gameObject, 0.2f);
        //    }
        //}
        //else
        //{
        //    explosion.SetActive(false);
   //     }
        //TODO Wait explosion length
   // }

    public float getDamage()
    {
        return damage;
    }
    public void hit()
    {
        explosion.SetActive(true);
        Destroy(gameObject, 0.2f);
    }

}
