document.addEventListener('DOMContentLoaded', () => {
    const filterPanel = document.querySelector(".filter__panel");

    filterPanel.addEventListener('change', (event) => {
        if (event.target.classList.contains('YearPublisher')) {
            const yearFrom = document.querySelector('.yearFrom').value;
            const yearTo = document.querySelector('.yearTo').value;
            if (yearTo > 0 || yearFrom > 0) {
                (async () => {
                    const response = await fetch(`/?handler=Year&YearFrom=${yearFrom}&YearTo=${yearTo}`, {
                        method: "GET",
                        headers: {
                            'Content-Type': 'application/json',
                            "Accept": "application/json"
                        }
                    });
                    if (response.ok) {
                        console.log(await response.json())
                        // ПОЛУЧАЕМ КНИГИ И РЕНДЕРИМ ИХ
                    }
                })()
            }
        }
    });
});