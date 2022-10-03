using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbreInterfaces : MonoBehaviour
{
    public static AbreInterfaces instance;
    public int interfaces = 0;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider != null)
                {
                    hit.collider.transform.TryGetComponent<PlaceableObject>(out PlaceableObject placeable);
                    if (!placeable.placed)
                    {
                        return;
                    }

                    else if(interfaces != 1)
                    {
                        if(hit.collider.gameObject.TryGetComponent(out Painel painel))
                        {
                            painel.painel.SetActive(true);
                            interfaces = 1;
                        }
                    }
                }
            }
        }
    }
}
