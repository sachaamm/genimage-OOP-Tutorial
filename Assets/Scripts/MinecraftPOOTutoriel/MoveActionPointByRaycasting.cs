using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// script permettant de deplacer le point d'action quand on est en mode de jeu
public class MoveActionPointByRaycasting : MonoBehaviour
{
    public GameObject raycastZone;
    public GameObject actionPoint;

    Game gameScript;

    GameObject thirdPersonController;
    GameObject raycastZoneRoot;

    float upAndDownRaycastZoneSpeed = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        gameScript = GetComponent<Game>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(gameScript.GetCurrentGameState() != Game.GameState.IN_GAME)
        {
            return;
        }

        if (!thirdPersonController)
        {        
            thirdPersonController = GameObject.Find("ThirdPersonController");
            raycastZoneRoot = thirdPersonController.transform.Find("RaycastzoneRoot").gameObject;
        }

        if (raycastZoneRoot)
        {
            UpdateRaycastzonePos();
        }

        if (Input.GetKey(Shortcuts.moveUpRaycastzone))
        {
            raycastZoneRoot.transform.Translate(new Vector3(0,1,0) * upAndDownRaycastZoneSpeed);
        }

        if (Input.GetKey(Shortcuts.moveDownRaycastzone))
        {
            raycastZoneRoot.transform.Translate(new Vector3(0, -1, 0) * upAndDownRaycastZoneSpeed);
        }

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            // Debug.Log("Did Hit with " + hit.collider.gameObject.name);

            actionPoint.transform.position =
                new Vector3((int)hit.point.x, (int)hit.point.y, (int)hit.point.z)
                ;

        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
            // Debug.Log("Did not Hit");
        }
    }

    void UpdateRaycastzonePos()
    {
        Vector3 pos = raycastZone.transform.position;
        pos.y = raycastZoneRoot.transform.position.y;
        raycastZone.transform.position = pos;
    }
}
