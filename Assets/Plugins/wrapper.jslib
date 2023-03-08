mergeInto(LibraryManager.library, {

  ShowButton: function (id) {
    showButton(Pointer_stringify(id));
  },

  HideButton: function (id) {
   hideButton(Pointer_stringify(id));
  },

  ShowConfirmation: function () {
    showConfirmation();
  },

  ShowPopUpMsg: function (title, message, callback) {
    showPopUpMsg(Pointer_stringify(title),Pointer_stringify(message), Pointer_stringify(callback));
  },
  
    ShowInfoPanel: function (title, message, callback) {
    ShowInfoPanel(Pointer_stringify(title),Pointer_stringify(message), Pointer_stringify(callback));
  },
  
    OpenQuestionScreen: function (question, correctAnswerFeedback, wrongAnswerFeedback, correctAnswer, wrongAnswer_1, wrongAnswer_2, wrongAnswer_3, wrongAnswer_4, callback) {
    OpenQuestionScreen(Pointer_stringify(question),Pointer_stringify(correctAnswerFeedback), Pointer_stringify(wrongAnswerFeedback), Pointer_stringify(correctAnswer), Pointer_stringify(wrongAnswer_1), Pointer_stringify(wrongAnswer_2), Pointer_stringify(wrongAnswer_3), Pointer_stringify(wrongAnswer_4), Pointer_stringify(callback));
  },
  
  OpenDocumentRevisionScreen: function (characterName, callback) {
    OpenDocumentRevisionScreen(Pointer_stringify(characterName),Pointer_stringify(callback));
  },
  
  DisplayDialog: function (spriteID, characterName, dialogLine, callback) {
    DisplayDialog(Pointer_stringify(spriteID),Pointer_stringify(characterName), Pointer_stringify(dialogLine), Pointer_stringify(callback));
  },

  EndActivity: function () {
    endActivity();
  },

  HideUnityApp: function () {
    hideUnityApp();
  },
  ConsoleLog: function(msg){
    console.log(Pointer_stringify(msg));
  },
  DisplayMessage: function(msg,timer){
     displayMessage(Pointer_stringify(msg),timer)
  },
  ExecuteAnything: function(command){
    eval(Pointer_stringify(command));
  },
  ShowLoadScreen: function(msg){
    showLoadScreen(Pointer_stringify(msg));
  },
  HideLoadScreen: function(){
    hideLoadScreen();
  },
  FixMessage: function(msg){
    fixMessage(Pointer_stringify(msg));
  },
  UnfixMessage: function(){
    unfixMessage();
  },
  ShowMenuConfig: function(){
    showMenuConfig();
  },
  HideMenuConfig: function(){
    hideMenuConfig();
  },
  IncreaseFontSize: function(){
    IncreaseFontSize();
  },
  DecreaseFontSize: function(){
    decreaseFontSize();
  },
  LockCursor: function(){
    Configuracoes.lockCursor();
  },
  GoFullScreen: function(){
    Configuracoes.goFullScreen();
  },
  ExitFullScreen: function(){
    Configuracores.exitFullScreen();
  },
  GerarRelatorio: function(data){
     Relatorios.parseData(Pointer_stringify(data));
  },

});