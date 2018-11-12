using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadgeTrackableEventHandler : DefaultTrackableEventHandler
{
    [SerializeField]
    GameObject[] hideOnTrackingFound;
    public event Action OnTrackingFoundAction;

    protected override void OnTrackingFound()
    {
        var rendererComponents = GetComponentsInChildren<Renderer>(true);
        var colliderComponents = GetComponentsInChildren<Collider>(true);
        var canvasComponents = GetComponentsInChildren<Canvas>(true);

        // Enable rendering:
        foreach (var component in rendererComponents)
            component.enabled = true;

        // Enable colliders:
        foreach (var component in colliderComponents)
            component.enabled = true;

        // Enable canvas':
        foreach (var component in canvasComponents)
            component.enabled = true;

        OnTrackingFoundSetActive(false);

        if (OnTrackingFoundAction != null)
        {
            OnTrackingFoundAction();
        }
    }

    private void OnTrackingFoundSetActive(bool active)
    {
        for (int i = 0; i < hideOnTrackingFound.Length; i++ )
        {
            hideOnTrackingFound[i].SetActive(active);
            Debug.Log(hideOnTrackingFound[i].name);
        }
    }

    protected override void OnTrackingLost()
    {
        var rendererComponents = GetComponentsInChildren<Renderer>(true);
        var colliderComponents = GetComponentsInChildren<Collider>(true);
        var canvasComponents = GetComponentsInChildren<Canvas>(true);

        // Disable rendering:
        foreach (var component in rendererComponents)
            component.enabled = false;

        // Disable colliders:
        foreach (var component in colliderComponents)
            component.enabled = false;

        // Disable canvas':
        foreach (var component in canvasComponents)
            component.enabled = false;

        OnTrackingFoundSetActive(true);
    }
}
