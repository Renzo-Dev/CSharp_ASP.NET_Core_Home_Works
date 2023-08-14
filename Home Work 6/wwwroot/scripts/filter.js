window.addEventListener('load',()=> {
    // получаем список продуктов
    const products = document.querySelectorAll(".show__processor__container");
    // панелька фильтра
    const filter_panel = document.querySelector(".filter__panel__container");
    // получаем массив checkbox
    const checkboxes = filter_panel.querySelectorAll("input");
    const filter_names = filter_panel.querySelectorAll("span");
    let filters = [];

    checkboxes.forEach((chBox, index) => {
        chBox.addEventListener('change', () => {
            setFilter(chBox,index,filter_names,filters,products);
        });
    });

    // добавляем activeCheckBox в фильтр
    function setFilter(chBox,_index,filter_names, filters, products) {
        if (chBox.checked) {
            filters.push(filter_names[_index].textContent);
            console.log(filters)
        } else {
            filters.splice(filters.indexOf(filter_names[_index].textContent), 1);
        }
        
        // делаем новый список продуктов по фильтру
        renderProducts(filters, products);
    }

    function renderProducts(filters, products) {
        const product__container = document.querySelector(".products__container");
        while (product__container.firstChild) {
            product__container.removeChild(product__container.firstChild);
        }

        if (filters.length > 0) {
            filters.forEach(filter=>{
                products.forEach(product=>{
                    if (filter.toLowerCase() === product.querySelector(".socket").textContent.toLowerCase() || filter.toLowerCase() === product.querySelector(".manufacturer").textContent.toLowerCase() 
                        || filter.toLowerCase() === product.querySelector(".processorLine").textContent.toLowerCase()) {
                        product__container.appendChild(product);
                    }
                })
            })
        } else {
            products.forEach(product=>{
                product__container.appendChild(product);
            })
        }
    }
});