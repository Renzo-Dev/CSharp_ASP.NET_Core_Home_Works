window.addEventListener('load', () => {
    // событие на нажатие кнопки "Отправить сообщение модератору"
    const bMessageForModerator = document.getElementById(`message__for__moderator`);
    bMessageForModerator.addEventListener('click', () => {
        // открываем модельное окно        
        let wModel = document.querySelector(".modal-content");
        wModel.style.display = 'flex';
    });

    const ModelButtonClosed = document.querySelector(".modal-bth-close");
    ModelButtonClosed.addEventListener('click', () => {
        let wModel = document.querySelector(".modal-content");
        wModel.style.display = 'none';
    });

    const ModelButtonSubmit = document.querySelector(".modal-bth-submit ");
    ModelButtonSubmit.addEventListener('click', (event) => {
        event.preventDefault();
        // Сообщение для отправки
        const message = document.querySelector(".modal__text").value;
        // Автор сообщения
        const author = document.querySelector(".modal__author").value;

        if (message.length > 0 && author.length > 0) {

            responseMessage(message, author);
        }
    });

    async function responseMessage(message, author) {
        // отправляем сообщение для модератора серверу
        const url = '/MessagesModerator'; // Путь к вашей Razor Page
        const response = await fetch(url, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
                "Accept": "application/json"
            },
            body: JSON.stringify({
                message: message,
                author: author
            })
        });
        if (response.ok) {
            window.alert("Сообщение отправлено");
            document.querySelector(".modal-content").style.display = 'none';
        } else {
            window.alert("Ошибка отправки сообщения");
        }
    }
});