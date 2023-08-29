document.addEventListener('DOMContentLoaded', () => {
    const bAddNewUser = document.getElementById('bAddNewUser');
    const MWMU = document.querySelector('.modal__create__user__form');

    bAddNewUser.addEventListener('click', (e) => {
        e.preventDefault();
        MWMU.querySelector('.modal_button:first-child').value = "Создать";
        MWMU.style.display = 'flex';

        const sendNewUser = MWMU.querySelector('.modal_button:first-child');
        sendNewUser.addEventListener('click', handleCreateUser);
    });

    function handleCreateUser() {
        const dataToSend = {
            guid: 0,
            login: MWMU.querySelector('#user__login').value,
            password: MWMU.querySelector('#user__password').value,
            email: MWMU.querySelector('#user__email').value,
        };

        if (userDataIsValid(dataToSend)) {
            fetch(`/UsersManagement?handler=Create`, {
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
                    MWMU.reset();
                    MWMU.style.display = 'none';
                    window.location.href = "/UsersManagement";
                })
                .catch(error => {
                    console.error('Error user creating: ', error.status);
                });
        } else {
            alert("Не все поля заполнены");
        }
    }

    MWMU.querySelector('input:last-child').addEventListener('click', (e) => {
        e.preventDefault();
        MWMU.reset();
        MWMU.style.display = 'none';
    });

    const bEditUsers = document.querySelectorAll(".editU");
    bEditUsers.forEach(user => {
        user.addEventListener('click', handleEditUser);
    });

    function handleEditUser(e) {
        e.preventDefault();
        const row = e.target.closest('tr');

        fetch(`/UsersManagement?handler=User&guid=${row.querySelector('input:first-child').value}`, {
            method: "GET",
            headers: {
                'Content-Type': 'application/json',
                'Accept': 'application/json'
            }
        })
            .then(response => response.json())
            .then(data => {
                const sendEditUser = MWMU.querySelector('.modal_button:first-child');
                sendEditUser.value = "Изменить";
                MWMU.style.display = 'flex';
                MWMU.querySelector('#guid').value = data.guid;
                MWMU.querySelector('#user__login').value = data.login;
                MWMU.querySelector('#user__password').value = data.password;
                MWMU.querySelector('#user__email').value = data.email;

                sendEditUser.addEventListener('click', async (e) => {
                    e.preventDefault();
                    const newData = {
                        guid: MWMU.querySelector('#guid').value,
                        login: MWMU.querySelector('#user__login').value,
                        password: MWMU.querySelector('#user__password').value,
                        email: MWMU.querySelector('#user__email').value
                    };

                    fetch('/UsersManagement?handler=Update', {
                        method: "POST",
                        headers: {
                            "Content-Type": "application/json"
                        },
                        body: JSON.stringify(newData)
                    })
                        .then(resp => {
                            if (resp.ok) {
                                alert("Пользователь успешно изменен");
                                MWMU.reset();
                                MWMU.style.display = 'none';
                                window.location.href = "/UsersManagement";
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

function userDataIsValid(data) {
    return data.login.length > 0 &&
        data.password.length > 0 &&
        data.email.length > 0;
}
