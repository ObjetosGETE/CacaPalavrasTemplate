using UnityEngine;
using UnityEngine.SceneManagement;
using System.Runtime.InteropServices;

public class FrontManager : MonoBehaviour
{  
    //carrega a cena pelo nome
    public void LoadSceneName(string name)
    {
        SceneManager.LoadScene(name);
    }
    
    //carrega a cena pelo indice numerico
    public void LoadSceneIndex(int id)
    {
        SceneManager.LoadScene(id);
    }

    private int _numbemScene;

    public void SetNumberScene(int p_value)
    {
        _numbemScene = p_value;
    }

    public int GetNumberScene()
    {
        return _numbemScene;
    }

    [DllImport("__Internal")]
    private static extern void ShowButton(string id);

    [DllImport("__Internal")]
    private static extern void HideButton(string id);
    
    [DllImport("__Internal")]
    private static extern void ShowConfirmation();

    [DllImport("__Internal")]
    private static extern void ShowPopUpMsg(string title, string message, string callback);

    [DllImport("__Internal")]
    private static extern void ShowInfoPanel(string title, string message, string callback);

    [DllImport("__Internal")]
    private static extern void DisplayDialog(string spriteID, string characterName, string dialogLine, string callback);

    [DllImport("__Internal")]
    private static extern void EndActivity();

    [DllImport("__Internal")]
    private static extern void HideUnityApp();

    [DllImport("__Internal")]
    private static extern void ConsoleLog(string msg);

    [DllImport("__Internal")]
    private static extern void ExecuteAnything(string command);

    [DllImport("__Internal")]
    private static extern void DisplayMessage(string msg, int timer);

    [DllImport("__Internal")]
    private static extern void ShowLoadScreen(string msg);

    [DllImport("__Internal")]
    private static extern void HideLoadScreen();

    [DllImport("__Internal")]
    private static extern void OpenDocumentRevisionScreen(string characterName, string callback);

    [DllImport("__Internal")]
    private static extern void FixMessage(string msg);

    [DllImport("__Internal")]
    private static extern void UnfixMessage();

    [DllImport("__Internal")]
    private static extern void OpenQuestionScreen(int id, string question, string correctAnswerFeedback, string wrongAnswerFeedback, string correctAnswer, string wrongAnswer_1, string wrongAnswer_2, string wrongAnswer_3, string wrongAnswer_4, string callback);

    [DllImport("__Internal")]
    private static extern void ShowMenuConfig();

    [DllImport("__Internal")]
    private static extern void HideMenuConfig();

    [DllImport("__Internal")]
    private static extern void IncreaseFontSize();

    [DllImport("__Internal")]
    private static extern void DecreaseFontSize();

    [DllImport("__Internal")]
    private static extern void LockCursor();

    [DllImport("__Internal")]
    private static extern void GoFullScreen();

    [DllImport("__Internal")]
    private static extern void ExitFullScreen();


    [DllImport("__Internal")]
    private static extern void GerarRelatorio(string data);

    /*
     * Faz uma chamada para executar qualquer codigo javascript no browser, usar somente quando necessario
     * o comando deve ser em formato string, junto com seus parametros, se necessario, exemplo
     * ExecuteExternalJs("alert('mensagem')");
     */
    public void ExecuteExternalJs(string command)
    {
        ExecuteAnything(command);
    }
    /* mostra tela de loading na ui*/
    public void UIShowLoadScreen(string msg)
    {
        ShowLoadScreen(msg);
    }
    /* oculta tela de loading na ui*/
    public void UIHideLoadScreen()
    {
        HideLoadScreen();
    }
    /*
     Mostra uma popUp com botao ok na tela, seus parametros sao todos strings
     callback = uma string com um comando em js para callback.
    */
    public void UIShowPopUp(ContentScriptableObject content, string callback)
    {
        UnityEngine.Debug.Log("Calling PopUp on Front with Title: " + content.Title);
        UnityEngine.Debug.Log("Calling PopUp on Front with content: " + content.Content);

        ShowPopUpMsg(content.Title, content.Content, callback);
    }

    //para mostrar ou ocultar botoes na ui, pelo seu id no html
    public void UIShowButton(string id) {
        ShowButton(id);
    }

    //oculta um botão na ui, pelo seu id no HTML
    public void UIHideButton(string id)
    {
        HideButton(id);
    }

    //mostra a janela de confirmação na ui
    public void UIShowConfirmation()
    {
        ShowConfirmation();
    }

    //dá um refresh no html, voltando pra tela inicial
    public void UIEndActivity()
    {
        EndActivity();
    }

    //faz o container da unity na ui sumir
    public void UIHideUnityApp()
    {
        HideUnityApp();
    }

    //pra poder utilizar o console.log do browser a partir do app da unity... pode ser util pra debugar
    public void UIConsoleLog(string msg)
    {
        ConsoleLog(msg);
    }

    /* função que mostra imagens simples na frente da aplicação unity dentro da UI
     * o parametro msg é a mensagem propriamente dita,
     * e o paramtero timer é o tempo que a mensagem ficará na tela, é um valor inteiro e em milisegundos, ou seja 1 segundo = 1000,
     * o parametro timer pode ser nulo, entao o tempo padrao de 1300ms será utilizado para mostrar a mensagem
     */
    public void UIDisplayMessage(string msg, int timer)
    {
        DisplayMessage(msg, timer);
    }

    //funçoes para as mensagens fixas
    public void UIFixMessage(string msg)
    {
        FixMessage(msg);
    }
   
    public void UIUnfixMessage()
    {
        UnfixMessage();
    }

    //mostra o menu de configuraçoes
    public void UIShowMenuConfig()
    {
        ShowMenuConfig();
    }
    //oculta o menu de configuraçoes
    public void UIHideMenuConfig()
    {
        HideMenuConfig();
    }

    //aumenta o texto na tela
    public void UIIncreaseFontSize()
    {
        IncreaseFontSize();
    }
    //diminui texto da ui
    public void UIDecreaseFontSize()
    {
        DecreaseFontSize();
    }
    //dá lock no cursor do canvas
    public void UILockCursor()
    {
        LockCursor();
    }
    //bota o container do app no html em fullscreen
    public void UIGoFullScreen()
    {
        GoFullScreen();
    }
    //sai do modo fullscreen
    public void UIExitFullScreen()
    {
        ExitFullScreen();
    }
    //Gera o relatorio, o parametro é uma string com um JSON dentro, ou um Json puro, nao sei
    //ao certo se eh possivel passar json puro do c# pra js, entao eh melhor inserir o json em uma
    //string usando JSON.stringfy, ou algo parecido
    public void UIGerarRelatorio(string data)
    {
        GerarRelatorio(data);
    }

    //Exibe janela de informações com um único botão para encerrar.
    //Clicar no botão executa a função de callback
    public void UIShowInfoPanel(string title, string message, string callback)
    {
        ShowInfoPanel(title, message, callback);
    }
    //Exibe janela de dialogo.
    public void UIDisplayDialog(string spriteID, string characterName, string dialogLine, string callback)
    {
        DisplayDialog(spriteID, characterName, dialogLine, callback);
    }
    public void UIOpenDocumentRevisionScreen(string characterName, string callback)
    {
        OpenDocumentRevisionScreen(characterName, callback);
    }

    public void UIOpenQuestionScreen(string question, string correctAnswerFeedback, string wrongAnswerFeedback, string correctAnswer, string wrongAnswer_1, string wrongAnswer_2, string wrongAnswer_3, string wrongAnswer_4, string callback)
    {
       OpenQuestionScreen(0, question, correctAnswerFeedback, wrongAnswerFeedback, correctAnswer, wrongAnswer_1, wrongAnswer_2, wrongAnswer_3, wrongAnswer_4, callback);
    }

    public void UIOpenQuestionScreen(QuestionScriptableObject question, string callback)
    {
        var q = question;

        OpenQuestionScreen(q.ID,q.QuestionStatement, q.CorrectAnswerFeedback, q.WrongAnswerFeedback,
            q.CorrectAnswer, q.WrongAnswer_1, q.WrongAnswer_2, q.WrongAnswer_3, q.WrongAnswer_4, callback);
    }

    public void DisableWebGLInputCapture()
    {
#if !UNITY_EDITOR && UNITY_WEBGL
        WebGLInput.captureAllKeyboardInput = false;
#endif
    }
    public void EnableWebGLInputCapture()
    {
#if !UNITY_EDITOR && UNITY_WEBGL
        WebGLInput.captureAllKeyboardInput = true;
#endif
    } 
}