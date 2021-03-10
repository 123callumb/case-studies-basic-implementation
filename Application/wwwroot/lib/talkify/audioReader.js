talkify.config.remoteService.host = 'https://talkify.net';
talkify.config.remoteService.apiKey = '298c9307-7ac8-4654-8cf5-7de63ff4f95f';

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
            player.pause();
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
                if (msg !== '') {
                    player.playText(msg);
                } else {
                    player.playText(event.target.innerText);
                }
            }
        });
});