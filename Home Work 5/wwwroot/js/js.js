window.addEventListener('load', () => {
    const libraries = document.querySelectorAll(".book__wrapper");
    libraries.forEach(book => {
        const divID = book.querySelector('#id');
        const id = divID.getAttribute("content");
        book.addEventListener('click', async (e) => {
            e.preventDefault();
            try {
                console.log(id)
                const response = await fetch(`/ByID?id=${id}`, {
                    method: "GET",
                    headers: {"Accept": "application/json"}
                });
            } catch (error) {
                console.error("Error:", error);
            }
        });
    });
});
