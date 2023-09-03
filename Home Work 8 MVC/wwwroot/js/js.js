const fadeImages = document.querySelectorAll('.fade-image');

function fadeInImages() {
    fadeImages.forEach(image => {
        const imageTop = image.getBoundingClientRect().top;
        const windowHeight = window.innerHeight;

        if (imageTop < windowHeight && imageTop > -image.height) {
            const opacity = 1 - (Math.abs(imageTop) / windowHeight);
            image.style.opacity = opacity;
        }
    });
}

window.addEventListener('scroll', fadeInImages);
window.addEventListener('resize', fadeInImages);

// Вызываем функцию при загрузке страницы
window.addEventListener('load', fadeInImages);