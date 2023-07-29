using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] private Vector3 directionVector;
    public void SetDirectionVector(Vector2 value) {
        directionVector.x = value.x;
        directionVector.z = value.y;
    }

    private void SetDirectionAngle(Vector3 value) {
        if (value != Vector3.zero) {
            if (value.x >= 0) transform.rotation = Quaternion.AngleAxis(Mathf.Asin(value.z) * 180 / Mathf.PI, Vector3.down);
            else transform.rotation = Quaternion.AngleAxis(Mathf.Asin(value.z) * 180 / Mathf.PI + 180, Vector3.up);
        }
    }

    private void Update() {
        SetDirectionAngle(directionVector);
    }
}
