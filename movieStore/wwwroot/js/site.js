// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function displayMovieInModal(title, description, imgUrl) {

    $('#movieTitle').html(title);
    $('#movieDescription').html(description);
    $('#movieImage').attr('src', imgUrl);

    $("#exampleModal").modal('show');
};

function hideModal()
{
    $("#exampleModal").modal('hide');
};

