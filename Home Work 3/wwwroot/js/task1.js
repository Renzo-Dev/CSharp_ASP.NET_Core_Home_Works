window.addEventListener('load', () => {
    // Отправка формы ввода данных пользователя
    document.getElementById("button__submit").addEventListener('click', e => {
        e.preventDefault();
        const form = document.forms["userForm"];
        const Guid = form.elements["id"].value;
        const firstName = form.elements["FirstName"].value;
        const lastName = form.elements["LastName"].value;
        const Age = form.elements["Age"].value;
        const BirthDate = form.elements["BirthDate"].value;
        if (Guid == 0)
            createUser(firstName, lastName, Age, BirthDate);
        else
            editUser(Guid, firstName, lastName, Age, BirthDate);
    });

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
            users.forEach(user => {
                addRow(user);
            })
        } else {
            const error = await response.json();
            console.log(error.message);
        }
    }

    async function createUser(firstName, lastName, age, birthDate) {
        const response = await fetch("/users", {
            method: "POST",
            headers: {"Accept": "application/json", "Content-Type": "application/json"},
            body: JSON.stringify({
                FirstName: firstName,
                LastName: lastName,
                Age: parseInt(age),
                BirthDate: birthDate
            })
        });
        if (response.ok) {
            const user = await response.json();
            addRow(user);
            resetInputForm();
        } else {
            const error = await response.json();
        }
    }

    function resetInputForm() {
        const form = document.forms["userForm"];
        form.reset();
        form.elements["id"].value = 0;
    }

    async function editUser(guid, firstName, lastName, age, birthDate) {
        const response = await fetch("/users", {
            method: "PUT",
            headers: {"Accept": "application/json", "Content-Type": "application/json"},
            body: JSON.stringify({
                Guid: guid,
                FirstName: firstName,
                LastName: lastName,
                Age: parseInt(age),
                BirthDate: birthDate
            })
        });
        if (response.ok) {
            const user = await response.json();
            resetInputForm();
            document.querySelector("tr[userID='" + user.guid + "']").replaceWith(addRow(user));
        } else {
            const error = await response.json();
            console.error(error.message);
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
        BirthDate.textContent = User.birthDate;
        tr.append(BirthDate);

        // создаем кнопку Изменить
        const bEdit = document.createElement("button");
        bEdit.classList.add("user_tb__button");
        bEdit.textContent = "Edit";
        bEdit.addEventListener("click", e => {
            e.preventDefault();
            GetUser(id);
        });
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

        return tr;
    }

    GetUsers();
});


../// Доделать GetUser(id) , RemoveUser(id)