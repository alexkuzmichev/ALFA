﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
        PlayingAdventure,
        TrackBadge,
        TrackPoster
    }
    [SerializeField]
    private CanvasGroup loadingScreenCanvas;
    [SerializeField]
    private CanvasGroup selectAdventureCanvas;
    [SerializeField]
    private CanvasGroup startAdventureScreenCanvas;
    [SerializeField]
    private CanvasGroup playingAdventureScreenCanvas;
    [SerializeField]
    private CanvasGroup trackBadgeCanvas;
    [SerializeField]
    private Button selectCosmosHackAdventureButton;
    [SerializeField]
    private Button startCosmosHackAdventureButton;
    [SerializeField]
    private Button startAgainGameButton;

    [SerializeField]
    private Button backToSelectAdventureScreenCanvasButton;

    [SerializeField]
    private BadgeTrackableEventHandler badgeTrackableEventHandler;
    [SerializeField]
    private BadgeTrackableEventHandler posterTrackableEventHandler;

    [SerializeField]
    private Sound_Manager soundManager;

    State state = State.None;// LoadingScreen;
    private Dictionary<State, CanvasGroup> stateCanvases = new Dictionary<State, CanvasGroup>();

    void Start()
    {
        stateCanvases.Add(State.LoadingScreen, loadingScreenCanvas);
        stateCanvases.Add(State.SelectAdventure, selectAdventureCanvas);
        stateCanvases.Add(State.StartAdventure, startAdventureScreenCanvas);
        stateCanvases.Add(State.PlayingAdventure, playingAdventureScreenCanvas);
        stateCanvases.Add(State.TrackBadge, trackBadgeCanvas);

        selectCosmosHackAdventureButton.onClick.AddListener(SelectCosmosHackAdventure);
        startCosmosHackAdventureButton.onClick.AddListener(StartCosmosHackAdventure);
        backToSelectAdventureScreenCanvasButton.onClick.AddListener(SetSelectAdventureCanvasState);
        startAgainGameButton.onClick.AddListener(Reload);

        HideCanvases();
        SetLoginState();
        badgeTrackableEventHandler.OnTrackingFoundAction += StartBadgeSound;
        posterTrackableEventHandler.OnTrackingFoundAction += StartPosterSound;
    }

    private void Reload()
    {
        SceneManager.LoadScene(0);
    }

    private void SetLoginState()
    {
        soundManager.main_sound_stop();
        soundManager.badge_sound_stop();
        soundManager.poster_sound_stop();
        SetState(State.LoadingScreen);
    }

    private void SetSelectAdventureCanvasState()
    {
        SetState(State.SelectAdventure);
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
        soundManager.main_sound_play();
        SetState(State.PlayingAdventure);
        StartCoroutine(WaitForSoundEvent(21));
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
                StartCoroutine(WaitForLoadingAnimation(5));
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
        yield return new WaitForSecondsRealtime(soundEventTime);
        SetState(State.TrackBadge);
    }

    private void StartBadgeTracking()
    {

        //VuforiaBehaviour.Instance.enabled = true;
    }

    private void StartBadgeSound()
    {
        if (state == State.TrackBadge)
        {
            soundManager.main_sound_stop();
            soundManager.poster_sound_stop();
            soundManager.badge_sound_play();
        }
    }

    private void StartPosterSound()
    {
        if (state == State.TrackBadge)
        {
            soundManager.main_sound_stop();
            soundManager.badge_sound_stop();
            soundManager.poster_sound_play();
        }
    }


}
