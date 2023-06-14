using UnityEngine;

public class UnitClick : MonoBehaviour
{
    [SerializeField]
    Camera myCam;

    public LayerMask clickable;
    public LayerMask ground;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = myCam.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out hit, Mathf.Infinity, clickable))
            {
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    UnitSelection.Instance.ShiftClickSelect(hit.collider.gameObject.GetComponent<Skeleton>());
                }
                else
                {
                    UnitSelection.Instance.ClickSelect(hit.collider.gameObject.GetComponent<Skeleton>());
                }
            }
            else
            {
                if (!Input.GetKey(KeyCode.LeftShift))
                {
                    UnitSelection.Instance.DeselectAll();
                }
            }
        }
    }
}
