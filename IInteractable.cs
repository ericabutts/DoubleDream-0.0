public interface IInteractable
{
    void Interact();

    
    bool hasBeenClicked { get; set; }

    string message {get; set;}

    bool isObjective {get; set;}

}