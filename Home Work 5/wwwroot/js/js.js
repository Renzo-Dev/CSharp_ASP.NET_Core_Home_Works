window.addEventListener('load',()=> {
    const libraies = document.querySelectorAll(".book__wrapper");
    libraies.forEach(book => {
        book.addEventListener('click', (e) => {
            e.preventDefault();
        });
    })
});