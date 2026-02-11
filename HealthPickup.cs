using Mirror.Examples.Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public Camera PlayerCamera;
    public GameObject Item;
    public GameObject Player;
    public float distanceThreshold;
    float Distance;
    PlayerHeath PH;
    // Update is called once per frame
    private void Start()
    {
        PH = Player.GetComponent<PlayerHeath>();
    }

    void Update()
    {
        Distance = Vector3.Distance(Player.transform.position, Item.transform.position);
        ClickObjectHealth();
    }
    public void ClickObjectHealth()
    {
        if(Distance < distanceThreshold)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                RaycastHit hit;
                Ray ray = PlayerCamera.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit))
                {
                    MeshCollider MeshRen = hit.collider as MeshCollider;
                    if (Input.GetKeyDown(KeyCode.Q) && hit.collider as MeshCollider && MeshRen.gameObject.tag == "Medkit")
                    {
                        Debug.Log("Player Health " + PH.playerHealth);
                        MeshRen.gameObject.SetActive(false);
                        Debug.Log("Is clicking should work");

                        float RPHA = Random.Range(0, 50);

                        PH.AddHealth(RPHA);

                        if(PH.playerHealth > 100)
                        {
                            PH.playerHealth = 100;
                        }
                    }

                }

            }
        }
       
    }
}
