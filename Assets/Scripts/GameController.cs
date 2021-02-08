using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text[] buttonList;
    private string playerSide;

    private int moveCount = 0;

    public GameObject gameOverPanel;
    public Text gameOverText;

    public GameObject restartButton;


    public void Awake()
    {
        gameOverPanel.SetActive(false);
        SetGameControllerReferenceOnButton();
        playerSide = "X";
    }

    public void SetGameControllerReferenceOnButton()
    {
        foreach (var button in buttonList)
        {
            button.GetComponentInParent<ButtonEvent>().SetGameControllerReference(this);
        }
    }

    public string GetPlayerSide()
    {
        return playerSide;
    }

    public void EndTurn()
    {
        CheckForWinConditions();
        ChangeSide();
    }

    public void RestartGame()
    {
        playerSide = "X";
        moveCount = 0;
        gameOverPanel.SetActive(false);

        SetBoardInteractable(true);

        foreach (var button in buttonList)
        {
            button.text = "";
        }
    }

    private void CheckForWinConditions()
    {
        moveCount++;

        if (buttonList[0].text == playerSide && buttonList[1].text == playerSide && buttonList[2].text == playerSide)
        {
            GameOver(playerSide);
        }        
        else if (buttonList[3].text == playerSide && buttonList[4].text == playerSide && buttonList[5].text == playerSide)
        {
            GameOver(playerSide);
        }
        else if (buttonList[6].text == playerSide && buttonList[7].text == playerSide && buttonList[8].text == playerSide)
        {
            GameOver(playerSide);
        }
        else if (buttonList[0].text == playerSide && buttonList[3].text == playerSide && buttonList[6].text == playerSide)
        {
            GameOver(playerSide);
        }
        else if (buttonList[1].text == playerSide && buttonList[4].text == playerSide && buttonList[7].text == playerSide)
        {
            GameOver(playerSide);
        }
        else if (buttonList[2].text == playerSide && buttonList[5].text == playerSide && buttonList[8].text == playerSide)
        {
            GameOver(playerSide);
        }
        else if (buttonList[0].text == playerSide && buttonList[4].text == playerSide && buttonList[8].text == playerSide)
        {
            GameOver(playerSide);
        }
        else if (buttonList[2].text == playerSide && buttonList[4].text == playerSide && buttonList[6].text == playerSide)
        {
            GameOver(playerSide);
        }
        else if (moveCount >= 9)
        {
            GameOver("Draw");
        }
    }

    private void GameOver(string playerSide)
    {
        SetBoardInteractable(false);
        if(playerSide == "Draw")
        {
            SetGameOverText("It's a Draw!");
        } else
        {
            SetGameOverText(playerSide + " Wins!");
        } 
    }

    private void ChangeSide()
    {
        playerSide = (playerSide == "X") ? "O" : "X";
    }

    private void SetGameOverText(string resultText)
    {
        gameOverText.text = resultText;
        gameOverPanel.SetActive(true);
    }

    private void SetBoardInteractable(bool toggle)
    {
        foreach (var button in buttonList)
        {
            button.GetComponentInParent<Button>().interactable = toggle;
        }
    }

}
