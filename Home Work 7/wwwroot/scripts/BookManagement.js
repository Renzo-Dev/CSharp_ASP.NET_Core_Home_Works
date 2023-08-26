document.addEventListener('DOMContentLoaded', () => {
    // добавляем событие для Button Edit Book
    const EditBookButtons = document.querySelectorAll('#editB');
    EditBookButtons.forEach(bEdit => {
        bEdit.addEventListener('click', () => {
            alert("WORk")
        });
    });
    // добавляем событие для Button Delete Book
    const DeleteBookButtons = document.querySelectorAll('#deleteB');
    DeleteBookButtons.forEach(bDelete => {
        bDelete.addEventListener('click', () => {
            alert("WORk")
        });
    });
    // добавляем событие для Button Add New Book
    const AddNewBookButton = document.getElementById('bAddNewBook');
    AddNewBookButton.addEventListener('click', () => {
        alert("WORk")
    });
});