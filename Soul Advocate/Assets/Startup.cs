using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using DialogueEditor;

public class Startup : MonoBehaviour
{
    [SerializeField]
    private NPCConversation conversation;

    private void Start()
    {
        // Assuming ConversationManager is properly set up and accessible
        if (ConversationManager.Instance != null && conversation != null)
        {
            ConversationManager.Instance.StartConversation(conversation);
        }
    }
}
