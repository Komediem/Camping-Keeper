using UnityEngine;

public class MenuCheck : MonoBehaviour
{
    public GameObject MainMenu;

    private void Start()
    {
        MainMenu.SetActive(false);

        Menu.Instance.StartGame();
    }
}