document.addEventListener('DOMContentLoaded', () => {
    const filterPanel = document.querySelector('.filter__panel');
    const yearFromInput = document.querySelector("#fYearFrom");
    const yearToInput = document.querySelector("#fYearTo");

    filterPanel.addEventListener('change', () => {
        const yearFrom = yearFromInput.value;
        const yearTo = yearToInput.value;
        window.location.href = `/?YearFrom=${yearFrom}&YearTo=${yearTo}`;
    });
});