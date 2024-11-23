function startCamera(videoElementId) {
    const video = document.getElementById(videoElementId);
    navigator.mediaDevices.getUserMedia({ video: true })
        .then(stream => {
            video.srcObject = stream;
            video.play();
        })
        .catch(err => {
            console.error("Error accediendo a la cámara: " + err);
        });
}

function capturePhoto(videoElementId, canvasElementId) {
    const video = document.getElementById(videoElementId);
    const canvas = document.getElementById(canvasElementId);
    const context = canvas.getContext('2d');
    context.drawImage(video, 0, 0, canvas.width, canvas.height);

    return canvas.toDataURL('image/png'); // Devuelve la imagen en Base64
}
