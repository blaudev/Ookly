async function search(filter) {
    const url = searchUrl(filter);

    const data = await fetch(url).then((response) => response.json());
    return data;
}

function searchUrl(filter) {
    const url = new URL('api/search', window.location.origin);

    url.searchParams.set('country', country);
    url.searchParams.set('category', category);

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
    const filterElements = Array.from(document.querySelectorAll('.filters .filter'));

    const filter = filterElements.reduce((filter, element) => {
        if (element.value) {
            filter[element.name] = element.value;
        }

        return filter;
    }, {});

    const data = await search(filter);

    data.facets.forEach((facet) => {
        const element = filterElements.find(el => el.name == facet.filterId);
        updateSelect(element, facet.items);
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
document.querySelectorAll('.filters .filter').forEach((filter) => filter.addEventListener('change', onChangeFilter));
document.querySelector('.filters-dialog .close-button').addEventListener('click', hideFiltersDialog);
document.querySelector('.filters-dialog .remove-filters-button').addEventListener('click', removeFilters);
