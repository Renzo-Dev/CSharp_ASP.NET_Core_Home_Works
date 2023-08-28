document.addEventListener('DOMContentLoaded', () => {
    // кнопка добавление новый книги
    const bAddNewBook = document.getElementById('bAddNewBook');
    // Modal Windows Management Book
    const MWMB = document.querySelector('.modal__create__book__form');

    // открываем окно MWMB при нажатие на кнопку ( Добавить новую книгу )
    bAddNewBook.addEventListener('click', (e) => {
        e.preventDefault();
        MWMB.querySelector('.modal_button:first-child').value = "Создать";
        MWMB.style.display = 'flex';
    });
    // закрываем окно MWMB при нажатии на внутреннею кнопку ( Закрыть )
    MWMB.querySelector('input:last-child').addEventListener('click', (e) => {
        e.preventDefault();
        MWMB.reset();
        MWMB.style.display = 'none';
    });
    // открывает окно MWMB при нажатии на кнопку изменить
    const bEditBooks = document.querySelectorAll(".editB");
    bEditBooks.forEach(book => {
        book.addEventListener('click', (e) => {
            e.preventDefault();
            const row = e.target.closest('tr');
            // делаем запрос на получение данных о книге
            fetch(`/BookManagement?handler=Book&id=${row.querySelector('input:first-child').value}`, {
                method: "GET",
                headers: {
                    'Content-Type': 'application/json',
                    'Accept': 'application/json'
                }
            }).then(async response => await response.json()).then(data => {
                // если получили данные, выполняем действия дальше
                const sendEditBook = MWMB.querySelector('.modal_button:first-child');
                sendEditBook.value = "Изменить";
                MWMB.style.display = 'flex';
                MWMB.querySelector('#id').value = data.id;
                MWMB.querySelector('#book__title').value = data.title;
                MWMB.querySelector('#book__author').value = data.author;
                MWMB.querySelector('#book__Publisher').value = data.publisher;
                MWMB.querySelector('#book__PublicationYear').value = data.publicationYear;
                MWMB.querySelector('#book__Genre').value = data.genre;
                // событие при нажатии на кнопку изменить ( в меню изменений )
                sendEditBook.addEventListener('click', async (e) => {
                    e.preventDefault();
                    // Собираем данные из формы
                    const id = MWMB.querySelector('#id').value;
                    const title = MWMB.querySelector('#book__title').value;
                    const author = MWMB.querySelector('#book__author').value;
                    const publisher = MWMB.querySelector('#book__Publisher').value;
                    const publicationYear = MWMB.querySelector('#book__PublicationYear').value;
                    const genre = MWMB.querySelector('#book__Genre').value;

                    // Создаем объект с данными
                    const data = {
                        id: id,
                        title: title,
                        author: author,
                        publisher: publisher,
                        publicationYear: publicationYear,
                        genre: genre
                    };
                    // Отправляем POST запрос
                    try {
                        const response = await fetch('/BookManagement?handler=Update', {
                            method: 'POST',
                            headers: {
                                'Content-Type': 'application/json',
                                'Accept': 'application/json'
                            },
                            body: JSON.stringify(data)
                        });

                        if (response.ok) {
                            MWMB.style.display = 'none';
                            // Выполните действия, если обновление успешно
                        } else {
                            console.error('Ошибка при обновлении данных.');
                        }
                    } catch (error) {
                        console.error('Ошибка при отправке данных: ', error);
                    }
                });
            }).catch(error => {
                console.error('Ошибка получения данных: ', error);
            });
        });
    });
});