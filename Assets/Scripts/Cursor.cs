using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : MonoBehaviour {
    public Sprite validSprite;
    public Sprite invalidSprite;

    // Use this for initialization
    void Start () {
        UnityEngine.Cursor.visible = false;
        transform.position = GetWorldPositionOnPlane(Input.mousePosition, 0); 
    }
	
	// Update is called once per frame
	void Update () {
        if (UseValidCursor()) { GetComponent<SpriteRenderer>().sprite = validSprite; }
        else { GetComponent<SpriteRenderer>().sprite = invalidSprite; }
        FollowMouse();
	}

    private void FollowMouse() {
        transform.position = GetWorldPositionOnPlane(Input.mousePosition, 0);
    }

    bool UseValidCursor() {
        Vector3 shootPosition = GetWorldPositionOnPlane(Input.mousePosition, 0);
        if(GameObject.FindGameObjectWithTag("Player") == null) {
            return false;
        }
        Character character = GameObject.FindGameObjectWithTag("Player").GetComponent<Character>();
        if(character == null) {
            return false;
        }
        var distance = Vector3.Distance(GetWorldPositionOnPlane(Input.mousePosition, 0), character.transform.position);
        return (distance >= character.swordMinRange) && shootPosition.y <= character.swordMaxHeight;
    }

    Vector3 GetWorldPositionOnPlane(Vector3 screenPosition, float z) {
        Ray ray = Camera.main.ScreenPointToRay(screenPosition);
        Plane xy = new Plane(Vector3.forward, new Vector3(0, 0, z));
        float distance;
        xy.Raycast(ray, out distance);
        return ray.GetPoint(distance);
    }
}
