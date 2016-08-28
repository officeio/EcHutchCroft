/// <reference path="jquery.min.js" />

$(function () {

    var _formElement = $("form#contactForm");
    var _successElement = $("#successAlert");
    var _submitButton = $("button#sendEmail", _formElement);
    var _submitButtonText = _submitButton.text();

    _submitButton.click(function onSubmit(e) {

        // Validate the required fields.
        if ($.trim($("[name=name]", _formElement).val()) == ''
            || $.trim($("[name=email]", _formElement).val()) == ''
            || $.trim($("[name=message]", _formElement).val()) == '') {
            alert("Please fill in all fields");
            e.preventDefault();
            return false;
        }

        // Get the trimmed email field to test.
        var email = $.trim($("[name=email]", _formElement).val());

        // Has put in a valid email address?
        var isEmailPattern = /^[_\w\.\-]+@[a-zA-Z_\-\.]+?\.[a-zA-Z]{2,3}$/;
        if (!isEmailPattern.test(email)) {
            alert("Please give a valid email address before continuing.");
            e.preventDefault();
            return false;
        }

        // Put loader into the button's content.
        _submitButton
            .html('<img src="images/loader.gif" style="width:16px; height:16px;" />')
            .attr("disabled", "disabled");

        // Perform a request over to the server.
        $.ajax({
            url: _formElement.attr("action"),
            data: _formElement.serialize(),
            type: 'post'
        })
            .done(function (data) {

                _formElement.hide();
                _successElement.show();

            })
            .fail(function (data) {

                alert("Error when sending post. Please email support@echutchcroft.com");

            })
            .always(function () {

                // Revert the submit button content.
                _submitButton
                    .text(_submitButtonText)
                    .removeAttr("disabled");

            });

    });

});