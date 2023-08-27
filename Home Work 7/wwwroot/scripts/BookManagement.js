document.addEventListener('DOMContentLoaded', () => {
    // добавляем событие для Button Edit Book
    const EditBookButtons = document.querySelectorAll('#editB');
    EditBookButtons.forEach(bEdit => {
        bEdit.addEventListener('click', () => {
            alert("WORk")
        });
    });
    // добавляем событие для Button Delete Book ( Удаление книги )
    const table = document.querySelector('.book__table__container table');
    table.addEventListener('click',(event)=>{
        const target = event.target;
        if (target.classList.contains('deleteB')) {
            const row = target.closest('tr');
            if (row) {
                const response = fetch(`/BookManagement?handler=Delete&bookName=${row.querySelector('td:first-child').textContent}`,
                    {
                        method: "GET",
                        headers: {
                            'Content-Type': 'application/json',
                            "Accept": "application/json"
                        }
                    });
                window.location.href = "/BookManagement";
            }
        }
    });
    // добавляем событие для Button Add New Book
    const AddNewBookButton = document.getElementById('bAddNewBook');
    AddNewBookButton.addEventListener('click', () => {
        alert("WORk")
    });
});