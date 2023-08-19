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

    const ModelButtonSubmit = document.querySelector(".modal-bth-submit");
    ModelButtonSubmit.addEventListener('click', () => {
        const message = document.querySelector(".modal__text").value;
        // const author = document.querySelector()
        if (message.length > 0) {

            // // сообщение для отправки
            // const message = document.getElementById();
            // // отправляем сообщение для модератора серверу
            // const repsonse = fetch('/',{
            //     method: "POST",
            //     body: JSON.stringify({
            //         message: 
            //     })
            // });
        }
    });
});