window.addEventListener('load', () => {

    let login_form = document.querySelector('.login__form'); // получаем дескриптор формы
    let validator = new Validator();

    ////////////////////////////////////////////////////////////////////////
    /* Валидация Логина */

    // получаем элемент ввода логина
    let loginInput = login_form.querySelector('#login');

    loginInput.addEventListener('input', function (e) {
        if (e.target.value.length > 0) {
            // задаем параметры для валидатора
            validator.Validator(e.target.value);
            // вызываем валидацию логина
            validator.loginValidation();
            // выводим ошибку в случае если есть ошибка
            if (validator.GetError().length > 0) {
                // задаем ошибку в поле ошибки
                login_form.querySelector('#error_login').innerHTML = validator.GetError();
                return;
            }
        }
        // обнуляем ошибку
        document.querySelector('.error_auth').style.visibility = 'hidden';
        login_form.querySelector('#error_login').innerHTML = ' ';
    });

    ////////////////////////////////////////////////////////////////////////
    /* Валидация пароля */

    // получаем элемент ввода пароля
    let passwordInput = login_form.querySelector('#password');

    passwordInput.addEventListener('input', function (e) {
        if (e.target.value.length > 0) {
            // задаем параметры для валидатора
            validator.Validator(e.target.value);
            // вызываем валидацию логина
            validator.passwordValidation();
            console.log(validator.GetError().length)

            // выводим ошибку в случае если есть ошибка
            if (validator.GetError().length > 0) {
                // Задаем ошибку в поле ошибки
                login_form.querySelector('#error_password').innerHTML = validator.GetError();
            } else {
                login_form.querySelector('#error_password').innerHTML = ' ';
            }
        } else {
            // обнуляем ошибку
            document.querySelector('.error_auth').style.visibility = 'hidden';
            login_form.querySelector('#error_password').innerHTML = ' ';
        }
    });

    // получаем кнопку "Войти"
    let button_submit = document.querySelector("#login__button");
    button_submit.addEventListener('click', () => {
        // проверяем количество ошибок
        if (validator.GetError().length === 0) {
            if (loginInput.value.length > 0 && passwordInput.value.length > 0) {
                // делаем запрос на доступ вход на сайт
                fetch(`/Authentication?login=${loginInput.value}&password=${passwordInput.value}`, {
                    method: 'GET',
                    headers: {
                        'Content-Type': 'application/json' // Указываем тип контента как JSON
                    },
                }).then(response => {
                    if (!response.ok) {
                        // Обработка статуса ответа, отличного от 200 (OK)
                        if (response.status === 401) {
                            // Если статус 401 (Unauthorized)
                            console.error('Пользователь не аутентифицирован.');
                            document.querySelector('.error_auth').style.visibility = 'visible';
                        } else {
                            // Другие статусы ошибок
                            console.error('Произошла ошибка: ' + response.status);
                        }
                    } else {
                        window.location.href = "/";
                    }
                })
                    .catch(error => {
                        // Обработка ошибок, связанных с сетью или другими проблемами
                        console.error('Произошла ошибка:', error);
                    });
            } else {
                if (loginInput.value.length === 0) {
                    login_form.querySelector('#error_login').innerHTML = "Логин не введен!";
                }
                if (passwordInput.value.length === 0) {
                    login_form.querySelector('#error_password').innerHTML = "Введите пароль!!";
                }
            }
        }
    });
});