'use strict'

class Validator {
    #validator_Str = ""; // строка для проверки валидности
    #_errors = ""; // ошибка
    Validator(validatorSTR) {
        this.#validator_Str = validatorSTR;
        this.#_errors = [];
        return this;
    }

    GetError = (index = 0) => {
        return this.#_errors;
    }

    loginValidation = () => {
        const loginRegex = /^[a-zA-Z0-9_]+$/;
        if (!loginRegex.test(this.#validator_Str)) {
            this.#_errors.push("неверный формат логина");
        } else if (this.#validator_Str.length < 4) {
            this.#_errors.push("Короткий логин ( мин 4 )");
        } else {
            if (this.#validator_Str.length > 20) {
                this.#_errors.push("Длинный логин ( макс 20 )");
            }
        }
        return this;
    }

    passwordValidation = () => {
        // Длина пароля от 8 до 64 символов.
        // Содержит хотя бы одну прописную (латинскую) букву.
        // Содержит хотя бы одну заглавную (латинскую) букву.
        // Содержит хотя бы одну цифру.
        // Содержит хотя бы один специальный символ из следующего набора: !@#$%^&*()_-+=.

        const passwordRegex = /^[a-zA-Z0-9!@#$%^&*()_\-+=.]+$/;
        // если логин не прошел проверку
        if (!passwordRegex.test(this.#validator_Str)) {
            this.#_errors.push("Некорректные символы")
        }
        return this;
    }

    checkPasswordStrength = () => {
        // Проверка сложности пароля
        let strength = 0;

        if (this.#validator_Str.match(/[a-z]+/)) {
            strength += 1;
        }

        if (this.#validator_Str.match(/[A-Z]+/)) {
            strength += 1;
        }

        if (this.#validator_Str.match(/[0-9]+/)) {
            strength += 1;
        }

        if (this.#validator_Str.match(/[$@#&!]+/)) {
            strength += 1;
        }

        return strength;
    }

    emailValidation = () => {
        const emailRegPattern = /(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|"(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:(2(5[0-5]|[0-4][0-9])|1[0-9][0-9]|[1-9]?[0-9]))\.){3}(?:(2(5[0-5]|[0-4][0-9])|1[0-9][0-9]|[1-9]?[0-9])|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])/;
        // если логин не прошел проверку
        if (!emailRegPattern.test(this.#validator_Str)) {
            this.#_errors.push("Некорректный формат почты")
        }
        return this;
    }
}