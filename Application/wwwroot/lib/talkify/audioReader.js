talkify.config.remoteService.host = 'https://talkify.net';
talkify.config.remoteService.apiKey = 'b8f0832c-75ec-4823-9fc8-cf3d4ccaa3d1';

talkify.config.ui.audioControls.enabled = true;
talkify.config.ui.audioControls.voicepicker.enabled = true;
talkify.config.ui.audioControls.container = document.getElementById("player-and-voices");


var player = new talkify.TtsPlayer()
    .enableTextHighlighting()
    .forceVoice({ name: "Hazel" });

var btnAudioAssist = document.querySelector('#audioAssistButton');
btnAudioAssist.addEventListener('click',
    (event) => {
        if (btnAudioAssist.classList.contains('active')) {
            btnAudioAssist.classList.remove('active');
            btnAudioAssist.querySelector('span').innerHTML = 'volume_off';
        } else {
            btnAudioAssist.classList.add('active');
            btnAudioAssist.querySelector('span').innerHTML = 'volume_up';
        }
    });

document.querySelectorAll('[data-voice]').forEach(item => {
    item.addEventListener('mouseover',
        (event) => {
            if (btnAudioAssist.classList.contains('active')) {
                var msg = event.target.getAttribute("data-voice");
                console.log(msg);
                if (msg !== '') {
                    player.playText(msg);
                } else {
                    player.playText(event.target.innerHTML);
                }
            }
        });
});