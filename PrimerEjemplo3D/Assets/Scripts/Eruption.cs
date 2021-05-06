using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eruption : MonoBehaviour
{
    public GameObject stone;
    public float fireRate = 0.5f;
    // private float nextFire = 0.0f;


    // Start is called before the first frame update
    void Start()
    {
        // usamos una corrutina
        StartCoroutine(Throwstone());
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(stone, transform.position, Random.rotation); //objeto a intanciar, posición inicial y rotación
        }*/

    }

    // las corrutinas siempre devuelven un IEnumerator
    IEnumerator Throwstone()
    {
        yield return new WaitForSeconds(2.0f);

        while (true)
        {
            Instantiate(stone, transform.position, Random.rotation);
            yield return new WaitForSeconds(fireRate);//devuelve la ejecucion a quien invoca la couritina, que cuando se vuelve a invocar, comieza desde donde quedó
        }
    }
}
