//using Boo.Lang;
using System;
using System.Collections.Generic;
using UnityEngine;
//using UnityScript.Steps;

/*
 ################------INPUT CONTROLLER-------################

Esse script gerência todas as entradas de input de teclado
qualquer alteração de tecla padão deve ser trocada dentro do script

Alterações do cursor também podem ser chamadas, passando a própria Texture2D
como parâmetro de troca.

O GameManager gerência chamadas externas para esse script 

 #############################################################
 */

public class InputController : MonoBehaviour
{
    #region VAR
    private Texture2D currentCursor;
    private Vector2 hotspot = Vector2.zero;

    private readonly Dictionary<char, KeyCode> _keycodeCache = new Dictionary<char, KeyCode>();
    private KeyCode[] key = new KeyCode[10] {
    KeyCode.D,
    KeyCode.A,
    KeyCode.W,
    KeyCode.S,
    KeyCode.None,
    KeyCode.None,
    KeyCode.None,
    KeyCode.None,
    KeyCode.None,
    KeyCode.None
    };

    private float axisX;
    private float axisY;

    public float horizontalInput { get; private set; }
    public float verticalInput { get; private set; }
    #endregion

    public void StartMain()
    {
        #region SET INPUTS BEGIN

        #endregion
    }

    public void UpdateMain()
    {
        #region Horizontal Axis
        if (Input.GetKey(key[0]))
        {
            if (axisX <= 1)
                axisX += 3 * Time.deltaTime;
        }
        else if (Input.GetKey(key[1]))
        {
            if (axisX >= -1)
                axisX -= 3 * Time.deltaTime;
        }
        else if (!Input.GetKey(key[0]) && !Input.GetKey(key[1]))
        {
            if (axisX != 0)
            {
                if (axisX > 0.01)
                    axisX -= 3 * Time.deltaTime;
                else if (axisX < -0.01)
                    axisX += 3 * Time.deltaTime;
                else
                    axisX = 0;
            }
        }
        horizontalInput = Mathf.Clamp(axisX, -1, 1);
        #endregion

        #region Vertical Axis
        if (Input.GetKey(key[2]))
        {
            if (axisY <= 1)
                axisY += 3 * Time.deltaTime;
        }
        else if (Input.GetKey(key[3]))
        {
            if (axisY >= -1)
                axisY -= 3 * Time.deltaTime;
        }
        else if (!Input.GetKey(key[2]) && !Input.GetKey(key[3]))
        {
            if (axisY != 0)
            {
                if (axisY > 0.01)
                    axisY -= 3 * Time.deltaTime;
                else if (axisY < -0.01)
                    axisY += 3 * Time.deltaTime;
                else
                    axisY = 0;
            }
        }
        verticalInput = Mathf.Clamp(axisY, -1, 1);
        #endregion
    }

    internal void RestoreDefaultSettings()
    {
        throw new NotImplementedException();
    }

    public void SetKeyInput(string p_value)
    {
        string[] _temp1 = p_value.Split(',');

        foreach(var item in _temp1)
        {
            string[] _btnCurrent = item.Split('=');

            switch (_btnCurrent[0])
            {
                case "HorizontalPositivo":
                    key[0] = (KeyCode)Enum.Parse(typeof(KeyCode), _btnCurrent[1].ToUpper());
                    break;
                case "HorizontalNegativo":
                    key[1] = (KeyCode)Enum.Parse(typeof(KeyCode), _btnCurrent[1].ToUpper());
                    break;
                case "VerticalPositivo":
                    key[2] = (KeyCode)Enum.Parse(typeof(KeyCode), _btnCurrent[1].ToUpper());
                    break;
                case "VerticalNegativo":
                    key[3] = (KeyCode)Enum.Parse(typeof(KeyCode), _btnCurrent[1].ToUpper());
                    break;
                default:
                    print("Tecla não atribuida");
                    break;
            }
        }   
    }
}