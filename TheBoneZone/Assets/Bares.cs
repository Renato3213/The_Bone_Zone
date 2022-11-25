using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class Bares : MonoBehaviour
{
    public TextMeshProUGUI slots;
    List<GameObject> descansandoAqui = new List<GameObject>();
    public Transform entrada, saida;
    public int limiteEsqueletos = 5;

    public float multiplier = 5;
    void Awake()
    {
        ControlaListas.instance.pubsLivres.Add(this);
        GameManager.instance.maxSkeletons += limiteEsqueletos;
        GameManager.instance.UpdateSkeletonCount();
    }

    private void FixedUpdate()
    {
        if (descansandoAqui.Count == 0) return;


        for (int i = 0; i < descansandoAqui.Count; i++)
        {
            Skeleton skeleton = descansandoAqui[i].GetComponent<Skeleton>();

            if (skeleton.happiness >= 100)
            {
                skeleton.happiness = skeleton.happiness > 100 ? 100 : skeleton.happiness;
                descansandoAqui[i].transform.position = saida.position;
                descansandoAqui[i].transform.GetComponent<NavMeshAgent>().enabled = true;
                descansandoAqui.Remove(descansandoAqui[i]);
                AtualizaInterface();
            }
            else
            {
                skeleton.happiness += Time.fixedDeltaTime * multiplier;
            }
        }
       
    }

    void AtualizaInterface()
    {
        slots.text = "" + descansandoAqui.Count + "/" + limiteEsqueletos;
    }

    void LiberaEsqueleto(GameObject esqueleto)
    {
        esqueleto.transform.position = saida.position;
        esqueleto.transform.GetComponent<NavMeshAgent>().enabled = true;
        esqueleto.GetComponent<Skeleton>().Recover();
        descansandoAqui.Remove(esqueleto);
        AtualizaInterface();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Esqueleto"))
        {
            Debug.Log("opa");
            if (descansandoAqui.Count == limiteEsqueletos)
            {
                other.transform.GetComponent<Skeleton>().Recover();
                return;
            }
            descansandoAqui.Add(other.gameObject);
            AtualizaInterface();
            other.transform.GetComponent<NavMeshAgent>().enabled = false;
            other.transform.position = GameManager.instance.deposit.transform.position;
            UnitSelection.Instance.Deselect(other.gameObject);

            if (descansandoAqui.Count == limiteEsqueletos)
            {
                ControlaListas.instance.pubsLivres.Remove(this);
            }
        }
    }
}
