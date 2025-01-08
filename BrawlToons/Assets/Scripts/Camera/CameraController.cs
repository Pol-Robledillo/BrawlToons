using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraController : MonoBehaviour
{
     public GameObject intermediateObject, mainCamera, player1, player2;
     Vector3 intermediatePosition;
     float distanceBetweenPlayers, distanceInitialBetweenPlayers, distanceInitialBetweenCameraAndMidPoint, standardDistanceUnit,
           player1ActualPosX, player2ActualPosX, cameraActualHeight, cameraInitialHeight;

     bool establishCameraInitialPos = true;

     //[Header("Settings")]
     public float cameraMinDistanceAllowed;
     public float cameraMaxDistanceAllowed;
     public float cameraGapY;
     public float cameraMaxHeightAllowed;
     public float playersMaxDistanceAllowed;
     public 
     void Start()
     {
         distanceInitialBetweenPlayers = Vector3.Distance(player1.transform.position, player2.transform.position);
         intermediatePosition = Vector3.Lerp(player1.transform.position, player2.transform.position, 0.5f);
         intermediateObject.transform.position = intermediatePosition;
         distanceInitialBetweenCameraAndMidPoint = Vector3.Distance(mainCamera.transform.position, intermediateObject.transform.position);
         standardDistanceUnit = (distanceInitialBetweenCameraAndMidPoint / distanceBetweenPlayers);
         if (cameraMaxDistanceAllowed <= cameraMinDistanceAllowed) { cameraMaxDistanceAllowed = (cameraMinDistanceAllowed + 1); }
         if (playersMaxDistanceAllowed <= distanceInitialBetweenPlayers) { playersMaxDistanceAllowed = distanceInitialBetweenPlayers; }
     }
     public void IntermediatePosition()
     {
         intermediatePosition = Vector3.Lerp(player1.transform.position, player2.transform.position, 0.5f);
         intermediateObject.transform.position = intermediatePosition;
         if (distanceBetweenPlayers >= cameraMinDistanceAllowed && distanceBetweenPlayers <= cameraMaxDistanceAllowed)
         {
             mainCamera.transform.position = new Vector3
                 (intermediateObject.transform.position.x, (intermediateObject.transform.position.y + cameraGapY),
                 (intermediateObject.transform.position.z - (distanceBetweenPlayers * standardDistanceUnit)));

         }
         else
         {
             mainCamera.transform.position = new Vector3(intermediateObject.transform.position.x, (intermediateObject.transform.position.y + cameraGapY), mainCamera.transform.position.z);
         }
         distanceBetweenPlayers = Vector3.Distance(player1.transform.position, player2.transform.position);
         if (distanceBetweenPlayers < cameraMinDistanceAllowed) { player1ActualPosX = player1.transform.position.x; player2ActualPosX = player2.transform.position.x; }
         else
         {
             player1.transform.position = new Vector3(player1ActualPosX, player1.transform.position.y, player1.transform.position.z);
             player2.transform.position = new Vector3(player2ActualPosX, player2.transform.position.y, player2.transform.position.z);
         }
         if(mainCamera.transform.position.y < (cameraInitialHeight + cameraMaxHeightAllowed)) { cameraInitialHeight = transform.position.y; }
         else { mainCamera.transform.position = new Vector3(mainCamera.transform.position.x, cameraActualHeight, mainCamera.transform.position.z);}
         if (establishCameraInitialPos) { cameraActualHeight = mainCamera.transform.position.y; establishCameraInitialPos = false; }
     }

     // Update is called once per frame
     void Update()
     {
         IntermediatePosition();
     }
 
}