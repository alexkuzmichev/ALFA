using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;

public class ScreensManager : MonoBehaviour
{
    public enum State
    {
        None,
        LoadingScreen,
        SelectAdventure,
        StartAdventure,
        TrackBadge
    }
    [SerializeField]
    private CanvasGroup loadingScreenCanvas;
    [SerializeField]
    private CanvasGroup selectAdventureCanvas;
    [SerializeField]
    private CanvasGroup startAdventureScreenCanvas;
    [SerializeField]
    private CanvasGroup trackBadgeCanvas;
    [SerializeField]
    private Button selectCosmosHackAdventureButton;
    [SerializeField]
    private Button startCosmosHackAdventureButton;

    State state = State.None;// LoadingScreen;
    private Dictionary<State, CanvasGroup> stateCanvases = new Dictionary<State, CanvasGroup>();

	void Start ()
    {
        stateCanvases.Add(State.LoadingScreen, loadingScreenCanvas);
        stateCanvases.Add(State.SelectAdventure, selectAdventureCanvas);
        stateCanvases.Add(State.StartAdventure, startAdventureScreenCanvas);
        stateCanvases.Add(State.TrackBadge, trackBadgeCanvas);

        
        selectCosmosHackAdventureButton.onClick.AddListener(SelectCosmosHackAdventure);
        startCosmosHackAdventureButton.onClick.AddListener(StartCosmosHackAdventure);

        HideCanvases();
        SetState(State.LoadingScreen);        
    }

    private void SelectCosmosHackAdventure()
    {
        SetState(State.StartAdventure);
    }

    private void StartCosmosHackAdventure()
    {
        StartPlayingMainSound();
    }

    private void StartPlayingMainSound()
    {
        Debug.Log("TODO play main sound");
        StartCoroutine(WaitForSoundEvent(1));
    }

    private void HideCanvases()
    {
        foreach (var canvasGroup in stateCanvases)
        {
            canvasGroup.Value.alpha = 0;
            canvasGroup.Value.interactable = false;
            canvasGroup.Value.blocksRaycasts = false;
        }
    }

    private void SetState(State targetState)
    {
        if (state != targetState && stateCanvases.ContainsKey(state))
        {
            stateCanvases[state].alpha = 0;
            stateCanvases[state].interactable = false;
            stateCanvases[state].blocksRaycasts = false;
        }

        state = targetState;
        if (stateCanvases.ContainsKey(state))
        {
            stateCanvases[state].alpha = 1;
            stateCanvases[state].interactable = true;
            stateCanvases[state].blocksRaycasts = true;
        }

        StartState(state);
    }

    private void StartState(State state)
    {
        switch (state)
        {
            case State.None:
                break;
            case State.LoadingScreen:
                StartCoroutine(WaitForLoadingAnimation(1));
                break;
            case State.SelectAdventure:
                break;
            case State.StartAdventure:
                break;
            case State.TrackBadge:
                StartBadgeTracking();
                break;
            default:
                break;
        }
    }

    private IEnumerator WaitForLoadingAnimation(int animationLength)
    {
        yield return new WaitForSeconds(animationLength);
        //VuforiaBehaviour.Instance.enabled = false;
        SetState(State.SelectAdventure);
    }

    private IEnumerator WaitForSoundEvent(int soundEventTime)
    {
        yield return new WaitForSeconds(soundEventTime);
        SetState(State.TrackBadge);
    }

    private void StartBadgeTracking()
    {
        //VuforiaBehaviour.Instance.enabled = true;
    }
}
