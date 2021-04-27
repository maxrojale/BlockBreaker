using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Paddle : MonoBehaviour
{
    [SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] float paddleMinPositionX = 1f;
    [SerializeField] float paddleMaxPositionX = 15f;

    void Update()
    {
        // Berechnung der Mausposition (Input.mousePosition.x)
        // Dividierung durch Screen Width (Ergebnis zwischen 0 und 1)
        // Multiplikation mit Anzahl der Unity World Units (Kameragröße 6)
        float mousePosInUnits = Input.mousePosition.x / Screen.width * screenWidthInUnits;
        // Berechnung der derzeitigen Position des Paddles
        Vector3 paddlePos = new Vector3(transform.position.x,transform.position.y,transform.position.z);
        // Festlegen der neuen Position in Abhängigkeit vom Mauscursor, mit serialisiertem Minimum und Maximum)
        paddlePos.x = Mathf.Clamp(mousePosInUnits, paddleMinPositionX, paddleMaxPositionX);
        // Änderung der Position. Übergabe des Vekors paddlePos
        transform.position = paddlePos;
    }
}
