using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;


/*using this tutorial, linked here 
https://www.youtube.com/watch?v=cxRnK8aIUSI
*/

public class TeleportationManager : MonoBehaviour
{
    [SerializeField] private InputActionAsset actionAsset;
    [SerializeField] private XRRayInteractor rayInteractor;
    [SerializeField] private TeleportationProvider provider;

    private InputAction _thumbstick;
    private bool _isActive;


    // Start is called before the first frame update
    void Start()
    {
        var activate = actionAsset.FindActionMap("XRI LeftHand Locomotion").FindAction("Teleport Mode Activate");
        activate.Enable();
        activate.performed += OnTeleportActivate;

        var cancel = actionAsset.FindActionMap("XRI LeftHand Locomotion").FindAction("Teleport Mode Cancel");
        cancel.Enable();
        cancel.performed += OnCancelActivate;

        _thumbstick = actionAsset.FindActionMap("XRI LeftHand Locomotion").FindAction("Move");
        _thumbstick.Enable();

        }

    // Update is called once per frame
    void Update()
    {
        if (!_isActive) 
            {
            return;
            }
        if (_thumbstick.triggered)
            return;

        if (!rayInteractor.TryGetCurrent3DRaycastHit(out RaycastHit hit)) 
            {
            rayInteractor.enabled = false;
            _isActive = false;
            }

        TeleportRequest request = new TeleportRequest()
            {
            destinationPosition = hit.point,
            };

        provider.QueueTeleportRequest(request);
        rayInteractor.enabled = false;
        _isActive = false;
    }

    private void OnTeleportActivate(InputAction.CallbackContext context) 
        {
        rayInteractor.enabled = true;
        _isActive = true;
        }
    private void OnCancelActivate(InputAction.CallbackContext context) {
        rayInteractor.enabled = false;
        _isActive = false;
        }
}
