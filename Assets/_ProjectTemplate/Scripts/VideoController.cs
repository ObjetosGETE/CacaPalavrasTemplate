using System;
using UnityEngine;
using UnityEngine.Rendering;

/*
 ################------VIDEO CONTROLLER-------################

Esse script grência o controle dos gráficos do jogo
Alterando a qualidade gráfica, trocando o volumeprofile para acessibilidade
de daltonismo.

O GameManager gerência chamadas externas para esse script 

 #############################################################
 */

public class VideoController : MonoBehaviour
{
    #region VAR
    private Volume volume;

    public VolumeProfile GlobalVolume;
    public VolumeProfile[] daltonismProfile;
    #endregion

    public void StartMain()
    {
        volume = GetComponentInChildren<Volume>();
    }

    //altera o perfil para acessibilidade no modo daltonismo conforme a posição do array
    
    public void SetProfile(int p_value)
    {
        volume.profile = daltonismProfile[p_value];
    }
        
    //altera a resolução da tela, se está em fullscreen e qualidade gráfica
    
    public void SetResolution(string p_value)
    {
        //regra da string largura , altura , fullscreen(bool)
        string[] _resolution = p_value.Split(',');
        int _width = Convert.ToInt32(_resolution[0]);
        int _height = Convert.ToInt32(_resolution[1]);
        bool _fullscreen = Convert.ToBoolean(_resolution[2]);
        int _quality = Convert.ToInt32(_resolution[3]);

        Screen.SetResolution(_width, _height, _fullscreen);
        QualitySettings.SetQualityLevel(_quality);
    }

    //altera a qualidade gráfica
    public void SetQuality(int p_value)
    {
        QualitySettings.SetQualityLevel(p_value);
    }

    public void RestoreDefaultSettings()
    {
        SetProfile(0);
        SetQuality(3);
    }
}
