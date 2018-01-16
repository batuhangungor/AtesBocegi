function FillAjaxSelectBox(options) {
    $.ajax({
        url: options.url,
        type: options.type,
        data: options.data,
        success: function (data) {
            $.each(data, function (i, d) {
                options.Dom.append('<option value="' + d.value + '">' + d.display + '</option>');
            });
        }
    });
};