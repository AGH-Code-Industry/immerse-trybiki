using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] GameObject shopUI;

    private bool playerNeerShop;
    private bool playerInShop;

    private void Start()
    {
        InputManager.input.Player.ShopInteraction.performed += EnterExitShop;
        shopUI.SetActive(false);
        playerInShop = false;
        PlayerArrows.instance.SpawnShopArrow(this);
    }

    private void EnterExitShop(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        if (playerInShop)
        {
            playerInShop = false;
            shopUI.SetActive(false);
            InputManager.input.Player.MeleeAttack.Enable();
            return;
        }

        if (playerNeerShop)
        {
            GetComponent<UpgradeManager>().RefreshShop();
            InputManager.input.Player.MeleeAttack.Disable();
            playerInShop = true;
            shopUI.SetActive(true);
            return;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerNeerShop = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerNeerShop = false;
            EnterExitShop(new UnityEngine.InputSystem.InputAction.CallbackContext());
        }
    }
}
