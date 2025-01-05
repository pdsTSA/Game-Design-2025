using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerCreator : MonoBehaviour{
    public GameObject playerPrefab;
    private void Start() {
        InputSystem.settings.SetInternalFeatureFlag("USE_SPLIT_KEYBOARD", true);
        PlayerInput p1 = PlayerInput.Instantiate(
            playerPrefab, 
            playerIndex: 1, 
            controlScheme: "Keyboard1", 
            pairWithDevices: new InputDevice[] { Keyboard.current });
        PlayerInput p2 = PlayerInput.Instantiate(
            playerPrefab, 
            playerIndex: 2, 
            controlScheme: "Keyboard2", 
            pairWithDevices: new InputDevice[] { Keyboard.current });
        PlayerInput p3 = PlayerInput.Instantiate(
            playerPrefab, 
            playerIndex: 3, 
            controlScheme: "Keyboard3", 
            pairWithDevices: Keyboard.current);
        PlayerInput p4 = PlayerInput.Instantiate(
            playerPrefab, 
            playerIndex: 4, 
            controlScheme: "Keyboard4", 
            pairWithDevices: Keyboard.current);
        p2.SwitchCurrentControlScheme("Keyboard2", new InputDevice[] { Keyboard.current });
    }

}
