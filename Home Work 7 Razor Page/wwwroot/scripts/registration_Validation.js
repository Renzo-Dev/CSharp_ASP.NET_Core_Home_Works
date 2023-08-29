/*
*  Проблема: при нажатии на кнопку РЕГЕСТРАЦИЯ
*  Из за того, что validator пересоздается и обнуляет ошибки.
*  Если к примеру в логине есть ошибка, а в последущем поле ( пароль, почта ... ) нету ошибок,
*  то форма отправится.
*
*  Решение: Создать для каждого input свою переменную ошибки , и потом перед submit проверять
* */

window.addEventListener('load', () => {

    let registration_form = document.querySelector('.registration__form'); // получаем дескриптор формы
    let validator = new Validator();

    ////////////////////////////////////////////////////////////////////////
    /* Валидация Логина */

    // получаем элемент ввода логина
    let loginInput = registration_form.querySelector('#login');

    loginInput.addEventListener('input', function (e) {
        if (e.target.value.length > 0) {
            // задаем параметры для валидатора
            validator.Validator(e.target.value);
            // вызываем валидацию логина
            validator.loginValidation();
            // выводим ошибку в случае если есть ошибка
            if (validator.GetError().length > 0) {
                // задаем ошибку в поле ошибки
                registration_form.querySelector('#error_login').innerHTML = validator.GetError();
                return;
            }
        }
        // обнуляем ошибку
        registration_form.querySelector('#error_login').innerHTML = ' ';
    });

    ////////////////////////////////////////////////////////////////////////
    /* Валидация пароля */

    // получаем элемент ввода пароля
    let passwordInput = registration_form.querySelector('#password');
    // получаем полосу сложности пароля
    var strengthBar = document.getElementById("passwordStrength");

    passwordInput.addEventListener('input', function (e) {
        if (e.target.value.length > 0) {
            // задаем параметры для валидатора
            validator.Validator(e.target.value);
            // вызываем валидацию логина
            validator.passwordValidation();

            // выводим ошибку в случае если есть ошибка
            if (validator.GetError().length > 0) {
                // Задаем ошибку в поле ошибки
                registration_form.querySelector('#error_password').innerHTML = validator.GetError();
                strengthBar.className = "password-strength";
                strengthBar.style.width = "0";
            } else {
                registration_form.querySelector('#error_password').innerHTML = ' ';
                // Получаем сложность пароля
                let strength = validator.checkPasswordStrength();

                // Установка ширины линии в зависимости от сложности пароля
                strengthBar.style.width = (strength * 25) + "%";

                // Установка класса для определения цвета линии в зависимости от сложности пароля
                if (strength === 1) {
                    strengthBar.className = "weak password-strength";
                } else if (strength === 2 || strength === 3) {
                    strengthBar.className = "medium password-strength";
                } else if (strength === 4) {
                    strengthBar.className = "strong password-strength";
                }
            }
        } else {
            // очищаем
            strengthBar.className = "password-strength";
            // обнуляем ошибку
            registration_form.querySelector('#error_password').innerHTML = ' ';
        }
    });


    ////////////////////////////////////////////////////////////////////////
    /*Валидация Почта*/

    // получаем элемент ввода логина
    let emailInput = registration_form.querySelector('#email');

    emailInput.addEventListener('input', function (e) {
        if (e.target.value.length > 0) {
            // задаем параметры для валидатора
            validator.Validator(e.target.value);
            // вызываем валидацию логина
            validator.emailValidation();
            // выводим ошибку в случае если есть ошибка
            if (validator.GetError().length > 0) {
                // задаем ошибку в поле ошибки
                registration_form.querySelector('#error_email').innerHTML = validator.GetError();
                return;
            }
        }
        // обнуляем ошибку
        registration_form.querySelector('#error_email').innerHTML = ' ';
    });

    document.querySelector('#registration__button').addEventListener('click', async function () {
        if (validator.GetError().length === 0) {
            registration_form.submit();
        }
    });
});