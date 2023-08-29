document.addEventListener('DOMContentLoaded', () => {
    const bAddNewBook = document.getElementById('bAddNewBook');
    const MWMB = document.querySelector('.modal__create__book__form');

    bAddNewBook.addEventListener('click', (e) => {
        e.preventDefault();
        MWMB.querySelector('.modal_button:first-child').value = "Создать";
        MWMB.style.display = 'flex';
        const sendNewBook = MWMB.querySelector('.modal_button:first-child');
        sendNewBook.addEventListener('click', handleCreateBook);
    });

    function handleCreateBook() {
        const dataToSend = {
            id: 0,
            title: MWMB.querySelector('#book__title').value,
            author: MWMB.querySelector('#book__author').value,
            publisher: MWMB.querySelector('#book__Publisher').value,
            publicationYear: MWMB.querySelector('#book__PublicationYear').value,
            genre: MWMB.querySelector('#book__Genre').value
        };

        if (dataIsValid(dataToSend)) {
            fetch(`/BookManagement?handler=Create`, {
                method: "POST",
                headers: {
                    'Content-Type': 'application/json',
                    'Accept': 'application/json'
                },
                body: JSON.stringify(dataToSend)
            })
                .then(response => response.json())
                .then(data => {
                    alert(data.status);
                    MWMB.reset();
                    MWMB.style.display = 'none';
                    window.location.href = "/BookManagement";
                })
                .catch(error => {
                    console.error('Error book creating: ', error.status);
                });
        } else {
            alert("Не все поля заполнены");
        }
    }

    MWMB.querySelector('input:last-child').addEventListener('click', (e) => {
        e.preventDefault();
        MWMB.reset();
        MWMB.style.display = 'none';
    });

    const bEditBooks = document.querySelectorAll(".editB");
    bEditBooks.forEach(book => {
        book.addEventListener('click', handleEditBook);
    });

    function handleEditBook(e) {
        e.preventDefault();
        const row = e.target.closest('tr');

        fetch(`/BookManagement?handler=Book&id=${row.querySelector('input:first-child').value}`, {
            method: "GET",
            headers: {
                'Content-Type': 'application/json',
                'Accept': 'application/json'
            }
        })
            .then(response => response.json())
            .then(data => {
                const sendEditBook = MWMB.querySelector('.modal_button:first-child');
                sendEditBook.value = "Изменить";
                MWMB.style.display = 'flex';
                MWMB.querySelector('#id').value = data.id;
                MWMB.querySelector('#book__title').value = data.title;
                MWMB.querySelector('#book__author').value = data.author;
                MWMB.querySelector('#book__Publisher').value = data.publisher;
                MWMB.querySelector('#book__PublicationYear').value = data.publicationYear;
                MWMB.querySelector('#book__Genre').value = data.genre;

                sendEditBook.addEventListener('click', async (e) => {
                    e.preventDefault();
                    const newData = {
                        id: MWMB.querySelector('#id').value,
                        title: MWMB.querySelector('#book__title').value,
                        author: MWMB.querySelector('#book__author').value,
                        publisher: MWMB.querySelector('#book__Publisher').value,
                        publicationYear: MWMB.querySelector('#book__PublicationYear').value,
                        genre: MWMB.querySelector('#book__Genre').value
                    };

                    fetch('/BookManagement?handler=Update', {
                        method: "POST",
                        headers: {
                            "Content-Type": "application/json"
                        },
                        body: JSON.stringify(newData)
                    })
                        .then(resp => {
                            if (resp.ok) {
                                alert("Книга успешно изменена");
                                MWMB.reset();
                                MWMB.style.display = 'none';
                                window.location.href = "/BookManagement";
                            }
                        })
                        .catch(error => {
                            console.error(error);
                        });
                });
            })
            .catch(error => {
                console.error('Ошибка получения данных: ', error);
            });
    }
});

function dataIsValid(data) {
    return data.author.length > 0 &&
        parseInt(data.publicationYear) > 0 &&
        data.title.length > 0 &&
        data.genre.length > 0 &&
        data.publisher.length > 0;
}