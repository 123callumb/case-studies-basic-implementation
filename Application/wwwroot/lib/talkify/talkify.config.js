talkify.config.remoteService.host = 'https://talkify.net';
talkify.config.remoteService.apiKey = '9b73f668-d784-4a80-a51b-2a24d5eff82d';

talkify.config.ui.audioControls.enabled = true;
talkify.config.ui.audioControls.voicepicker.enabled = true;
talkify.config.ui.audioControls.container = document.getElementById("player-and-voices");


var player = new talkify.TtsPlayer()
    .enableTextHighlighting()
    .forceVoice({ name: "Hazel" });