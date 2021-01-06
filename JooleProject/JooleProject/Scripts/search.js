// get categories from database when loading into search page
$(document).ready(function () {
    // loading category from database
    $("#Category").change(function () {
        let url = "@Url.Action('SearchPage', 'Search')";
        window.location = url;
    });
});