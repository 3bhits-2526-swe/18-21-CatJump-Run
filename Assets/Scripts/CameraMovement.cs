using UnityEngine;

public class SmoothCameraFollow : MonoBehaviour
{
    // Die öffentliche Variable, die im Start() zugewiesen wird.
    public GameObject player; 
    
    // --- Einstellungen ---
    // Maximale Distanz auf der X-Achse, bevor die Kamera anfängt zu folgen.
    public float xDeadZone = 3.0f;
    
    // Maximale Distanz auf der Y-Achse, bevor die Kamera anfängt zu folgen.
    public float yDeadZone = 2.0f;

    // Glättungsfaktor: Kleinere Werte = langsamerer "Drag"
    public float smoothSpeed = 0.125f;

    // Standard-Z-Position für 2D
    private const float Z_OFFSET = -10f;

    // Start-Methode für die Spieler-Zuweisung
    void Start()
    {
        // Sucht nach einem GameObject mit dem Tag "Player" und weist es zu.
        player = GameObject.FindWithTag("Player");
    }
    
    // Wichtig: LateUpdate() wird nach allen Spielerbewegungen aufgerufen
    void LateUpdate()
    {
        if (player == null)
            return;

        // Die aktuellen Kamerapositionen
        float currentX = transform.position.x;
        float currentY = transform.position.y;
        
        // Die Zielpositionen des Spielers
        float targetX = player.transform.position.x;
        float targetY = player.transform.position.y;
        
        // Die gewünschten neuen Positionen (starten bei den aktuellen Positionen)
        float desiredX = currentX;
        float desiredY = currentY;

        
        // --- X-ACHSE LOGIK (HORIZONTALER DRAG) ---
        float xDelta = targetX - currentX; // Horizontaler Abstand
        
        if (Mathf.Abs(xDelta) > xDeadZone)
        {
            if (xDelta > 0) // Spieler zieht nach rechts
            {
                // Setze den Zielpunkt so, dass der Spieler am rechten Rand der Dead Zone ist
                desiredX = targetX - xDeadZone;
            }
            else // Spieler zieht nach links
            {
                // Setze den Zielpunkt so, dass der Spieler am linken Rand der Dead Zone ist
                desiredX = targetX + xDeadZone;
            }
        }
        
        
        // --- Y-ACHSE LOGIK (VERTIKALER DRAG) ---
        float yDelta = targetY - currentY; // Vertikaler Abstand

        if (Mathf.Abs(yDelta) > yDeadZone)
        {
            if (yDelta > 0) // Spieler zieht nach oben
            {
                // Setze den Zielpunkt so, dass der Spieler am oberen Rand der Dead Zone ist
                desiredY = targetY - yDeadZone;
            }
            else // Spieler zieht nach unten
            {
                // Setze den Zielpunkt so, dass der Spieler am unteren Rand der Dead Zone ist
                desiredY = targetY + yDeadZone;
            }
        }

        // Führe die Glättung (Lerp) nur durch, wenn sich die gewünschten Positionen geändert haben
        if (desiredX != currentX || desiredY != currentY)
        {
            // Glatte Bewegung zur gewünschten Position
            float smoothedX = Mathf.Lerp(currentX, desiredX, smoothSpeed);
            float smoothedY = Mathf.Lerp(currentY, desiredY, smoothSpeed);

            // Die Endposition setzen (Z-Position beibehalten)
            Vector3 finalPosition = new Vector3(smoothedX, smoothedY, Z_OFFSET);
            transform.position = finalPosition;
        }
    }
}