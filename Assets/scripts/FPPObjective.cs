using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPPObjective : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("GaryHead"))
        {
            FindObjectOfType<GameManager>().ClearObjective(tag);
        }
    }


    //void HoldItem(InputValue gatillo)
    //{
    //  si el gatiilo esta precionado se obtiene la posicion de la mano y el objeto se mantiene con dicha posicion hasta que lo suelte
    //  si el gatillo se solto, el objeto vuelve a su lugar original o cae
    //}
}
