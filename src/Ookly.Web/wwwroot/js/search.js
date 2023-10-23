async function search(filter) {
    const url = searchUrl(filter);

    const data = await fetch(url).then((response) => response.json());
    console.log(data);
    return data;
}

function searchUrl(filter) {
    const url = new URL('api/search', window.location.origin);

    url.searchParams.set('countryId', countryId);
    url.searchParams.set('categoryId', categoryId);

    Object.keys(filter).forEach((key) => {
        url.searchParams.set(key, filter[key]);
    });

    return url;
}

function updateHistory(filter) {
    window.history.replaceState({}, '', '/search' + searchUrl(filter).search);
}

function removeOptions(selectElement) {
    let index = selectElement.options.length - 1;

    if (index < 1) {
        return;
    }

    while (index--) {
        selectElement.remove(index + 1);
    }
}

function updateOptions(selectElement, items, selectedValue) {
    if (!items || items.length === 0) {
        selectElement.disabled = true;
        return;
    }

    items.forEach((item) => {
        const option = new Option(item.text, item.value, false, item.value === selectedValue);
        selectElement.add(option);
    });

    selectElement.disabled = false;
}

function updateSelect(selectElement, items) {
    const selectedValue = selectElement.value;
    removeOptions(selectElement);
    updateOptions(selectElement, items, selectedValue);
};

function updateCounter(count) {
    document.querySelector('.counter').innerText = count;
}

async function onChangeFilter() {
    const filterElements = Array.from(document.querySelectorAll('#filters .filter'));

    const filter = filterElements.reduce((filter, element) => {
        if (element.value) {
            filter[element.id] = element.value;
        }

        return filter;
    }, {});

    console.log(filter);
    const data = await search(filter);

    const selectIds = filterElements.reduce((ids, element) => {
        ids.push(element.id);
        return ids;
    }, [])

    console.log(selectIds);
    filterElements.forEach((element) => {
        const srcKey = element.id.replace('Id', '') + 's';
        updateSelect(element, data[srcKey]);
    });

    updateCounter(data.adCount);

    updateHistory(filter);
}

function hideFiltersDialog() {
    document.querySelector('.filters-dialog').classList.add('hidden');
}

function showFiltersDialog() {
    document.querySelector('.filters-dialog').removeAttribute('style');
    document.querySelector('.filters-dialog').classList.remove('hidden');
}

function removeFilters() {
    document.querySelectorAll('#filters .filter').forEach((filter) => {
        filter.value = '';
    });

    onChangeFilter();
}

document.querySelector('.filters-button').addEventListener('click', showFiltersDialog)
document.querySelectorAll('#filters .filter').forEach((filter) => filter.addEventListener('change', onChangeFilter));
document.querySelector('.filters-dialog .close-button').addEventListener('click', hideFiltersDialog);
document.querySelector('.filters-dialog .remove-filters-button').addEventListener('click', removeFilters);
