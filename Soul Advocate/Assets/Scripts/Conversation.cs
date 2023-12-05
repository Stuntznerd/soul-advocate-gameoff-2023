using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using DialogueEditor;
using System;

public class Conversation : MonoBehaviour
{
    [SerializeField]
    private NPCConversation introBanter;
    [SerializeField]
    private NPCConversation exitBanter;

    public static event Action OnExitBanterOver;

    private void Start()
    {
        GameManager.OnLevelComplete += StartExitBanter;
        // Assuming ConversationManager is properly set up and accessible
        if (ConversationManager.Instance != null && introBanter != null)
        {
            ConversationManager.Instance.StartConversation(introBanter);
        }
    }

    private void StartExitBanter() {
        if (ConversationManager.Instance != null && exitBanter != null)
        {
            ConversationManager.Instance.StartConversation(exitBanter);
        }
    }

    private

    void OnDisable() {
        GameManager.OnLevelComplete -= StartExitBanter;
    }
    
}
