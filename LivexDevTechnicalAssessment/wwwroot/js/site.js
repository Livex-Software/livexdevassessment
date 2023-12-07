// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

//Override @Html.ActionLink to accommodate box-icons
const action = (action, controller, id) => {
    window.location.href = "/" + controller + "/" + action + "?id=" + id
}

//validate edit form

$(document).ready(function () {
    $('form[id="edit_form"]').validate({
        rules: {
            InventoryName: 'required',
            Sku: 'required'
        },
        messages: {
            InventoryName: 'This field is required',
            Sku: 'This field is required',
        },
        submitHandler: function (form) {
            form.submit();
        }
    });

    $('form[id="add_customer_form"]').validate({
        rules: {
            Name: 'required',
            emailAddress: {
                required: true,
                email: true,
            }
        },
        messages: {
            Name: 'This field is required',
            emailAddress: 'This field is required',
        },
        submitHandler: function (form) {
            form.submit();
        }
    });
});