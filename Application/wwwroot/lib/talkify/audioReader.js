
/*
 * Talkify.js allows us to send a request for an text to speech audio sample that can
 * be played on the website. Here we have set up the talkify apiKey required for the service.
 * You are allocated 1000 free requests a month on the free account. This is enough for
 * testing purposes for this case studies project.
 */

talkify.config.remoteService.host = 'https://talkify.net';
talkify.config.remoteService.apiKey = '298c9307-7ac8-4654-8cf5-7de63ff4f95f';

// Setting up the audio controls for the webpage to allow the user to pause or replay the sounds
talkify.config.ui.audioControls.enabled = true;
talkify.config.ui.audioControls.voicepicker.enabled = true;
talkify.config.ui.audioControls.container = document.getElementById("player-and-voices");

// Configure the audio player with the voice of Hazel (GB).
var player = new talkify.TtsPlayer()
    .enableTextHighlighting()
    .forceVoice({ name: "Hazel" });

var btnAudioAssist = document.querySelector('#audioAssistButton');

// Add the click event listener to the audio assist button and make the button toggelable
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

// Find each element with the data-voice attribute and add a mouse over event listener to
// use the audio player to play the inner Text of the element or the specified msg written in
// the data-voice attribute. This is used for custom messages for specific elements.
var EnableVoiceAssist = function() {
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
}

EnableVoiceAssist();