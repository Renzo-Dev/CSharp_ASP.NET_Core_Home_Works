window.addEventListener('load', () => {

    // получаем исходный список продуктов ( без последующих обращений к серверу, только если перезагрузим страницу )
    const SourceProducts = document.querySelectorAll(".show__processor__container");

    renderProducts();
    document.querySelectorAll(".filter__panel__container input").forEach(checkbox => {
        checkbox.addEventListener('change', () => {
            renderProducts();
        });
    });
    document.getElementById('sortingSelect').addEventListener('change', () => {
        renderProducts();
    });

    // функция сортировки по выбору ( от меньшего , от большего )
    function ProductSorted(products = []) {
        const selectedValue = document.getElementById('sortingSelect').value;
        products.sort((a, b) => {
            const priceA = parseInt(a.querySelector('.price span:nth-child(2)').textContent);
            const priceB = parseInt(b.querySelector('.price span:nth-child(2)').textContent);
            if (selectedValue === 'asc') {
                return priceA - priceB;
            } else {
                return priceB - priceA;
            }
        });

    }

    // функция фильтрации по выбору ( checkboxes )
    function ProductFilters(products = []) {
        // получаем массив checkboxes
        const checkboxes = document.querySelectorAll(".filter__panel__container input");
        // получаем массив названий checkboxes
        const filter_names = document.querySelectorAll(".filter__panel__container span");
        let filters = [];
        // получаем список выбранных checkbox-ов
        checkboxes.forEach((chBox, _index) => {
            if (chBox.checked) {
                // если стоит галочка добавляем в список фильтрации
                filters.push(filter_names[_index].textContent);
            }
        })
        if (filters.length > 0) {
            let newProducts = [];
            filters.forEach((filter) => {
                products.forEach(product => {
                    if (
                        filter.toLowerCase() === product.querySelector(".socket").textContent.toLowerCase() ||
                        filter.toLowerCase() === product.querySelector(".manufacturer").textContent.toLowerCase() ||
                        filter.toLowerCase() === product.querySelector(".processorLine").textContent.toLowerCase()
                    ) {
                        newProducts.push(product);
                    }
                });
            });
            products.length = 0;
            products.push(...newProducts);
        }
    }

    // функция рендеринга продуктов
    function renderProducts() {

        // получаем наш новый список продуктов ( с исходными данными )
        let products = Array.from(SourceProducts);
        // вызываем функцию сортировки
        ProductSorted(products);
        // вызываем функцию фильтрации
        ProductFilters(products);
        // очищаем таблицу продуктов
        const product__table = document.querySelector(".products__container");
        product__table.querySelectorAll(".show__processor__container").forEach(processor => {
            processor.remove();
        })
        products.forEach(product => {
            product__table.appendChild(product);
        })
    }
});