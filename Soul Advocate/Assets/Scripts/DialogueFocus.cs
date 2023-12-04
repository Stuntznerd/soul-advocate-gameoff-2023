using UnityEngine;
using UnityEngine.Events;

public class FocusController : MonoBehaviour
{
    public GameObject Dimmer;
    public GameObject god_l; // Left object
    public GameObject god_r; // Right object

    // Unity Events
    public UnityEvent onFocusLeft;
    public UnityEvent onFocusRight;
    public UnityEvent onFocusOff;

    void Start()
    {
        // Bind the methods to the Unity Events, can also be done in the Unity Editor
        onFocusLeft.AddListener(FocusLeft);
        onFocusRight.AddListener(FocusRight);
        onFocusOff.AddListener(FocusOff);

        // Subscribe to the conversation events
        DialogueEditor.ConversationManager.OnConversationStarted += ActivateDimmer;
        DialogueEditor.ConversationManager.OnConversationEnded += FocusOff;
    }

    void OnDestroy()
    {
        // Unsubscribe to avoid memory leaks
        DialogueEditor.ConversationManager.OnConversationStarted -= ActivateDimmer;
        DialogueEditor.ConversationManager.OnConversationEnded -= FocusOff;
    }

    // Method to focus on god_l (left)
    public void FocusLeft()
    {
        // Swap positions only if god_r is in front of god_l
        if (god_r.transform.GetSiblingIndex() > god_l.transform.GetSiblingIndex())
        {
            SwapPositions(god_l, god_r);
        }
    }

    // Method to focus on god_r (right)
    public void FocusRight()
    {
        // Swap positions only if god_l is in front of god_r
        if (god_r.transform.GetSiblingIndex() < god_l.transform.GetSiblingIndex())
        {
            SwapPositions(god_l, god_r);
        }
    }

    // Helper method to swap the positions of two GameObjects
    private void SwapPositions(GameObject front, GameObject back)
    {
        int frontIndex = front.transform.GetSiblingIndex();
        front.transform.SetSiblingIndex(back.transform.GetSiblingIndex());
        back.transform.SetSiblingIndex(frontIndex);
    }

    // Method to reactivate the Dimmer at the start of a conversation
    private void ActivateDimmer()
    {
        if (Dimmer != null)
        {
            Dimmer.SetActive(true);
        }
    }

    // Method to turn off the Dimmer at the end of a conversation
    public void FocusOff()
    {
        if (Dimmer != null)
        {
            Dimmer.SetActive(false);
        }
    }
}
