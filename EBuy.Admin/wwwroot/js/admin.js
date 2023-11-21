function clearSearch() {
    window.location.href = window.location.pathname + '?pn=1&ps=100'

}

function search() {
    let searchString = '';
    document.querySelectorAll('#searchGroup .form-group .form-control').forEach((element) => {
        searchString += `${searchString ? '&' : ''}${element.id}=${element.value}`
    });
    searchString = `?${searchString}${searchString ? '&' : ''}pn=1&ps=100`;
    console.log(searchString);

    window.location.href = `${window.location.pathname}${searchString}`;
}