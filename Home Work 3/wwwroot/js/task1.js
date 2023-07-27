window.addEventListener('load', () => {
    // const usersData = {
    //     firstName: 'Test',
    //     lastName: 'Test',
    //     Age: 30,
    //     BirthDate: "1990-08-15"
    // }
    async function GetUsers() {
        const response = await fetch("/users", {
            method: "GET",
            headers: {
                "Accept": "application/json",
                "Content-Type": "application/json"
            },
        });
        if (response.ok) {
            const users = await response.json();
            console.dir(users);
            users.forEach(user => {
                addRow(user);
            })
        } else {
            const error = await response.json();
            console.log(error.message);
        }
    }

    // добавить строку в таблицу
    function addRow(User) {
        // получаем таблицу
        const table = document.getElementById("users__container").querySelector("table")
        // создаем ячейку строки пользователя
        const tr = document.createElement("tr");
        tr.setAttribute("userID", User.guid); // добавляем в атрибуты строки ID пользователя

        // создаем ячейку для Имени
        const FirstName = document.createElement("td");
        FirstName.textContent = User.firstName;
        tr.append(FirstName);

        // создаем ячейку для Фамилии
        const LastName = document.createElement("td");
        LastName.textContent = User.lastName;
        tr.append(LastName);

        // создаем ячейку для Возраста
        const Age = document.createElement("td");
        Age.textContent = User.age;
        tr.append(Age);

        // создаем ячейку для Даты Рождения
        const BirthDate = document.createElement("td");
        BirthDate.textContent = User.birthDate.split('T'[0]);
        tr.append(BirthDate);

        // создаем кнопку Изменить
        const bEdit = document.createElement("button");
        bEdit.classList.add("user_tb__button");
        bEdit.textContent = "Edit";
        tr.append(bEdit);

        // создаем кнопку Удалить
        const bRemove = document.createElement("button");
        bRemove.classList.add("user_tb__button");
        bRemove.textContent = "Remove";
        bRemove.addEventListener('click', e => {
            e.preventDefault();
            deleteUser(User.guid);
        })
        tr.append(bRemove);

        // добавляем строку в таблицу
        table.append(tr);
    }

    GetUsers();
});