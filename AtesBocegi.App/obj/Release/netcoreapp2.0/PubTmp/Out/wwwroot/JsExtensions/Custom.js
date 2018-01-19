function FillAjaxSelectBox(options) {
    $.ajax({
        url: options.url,
        type: options.type,
        data: options.data,
        success: function (data) {
            var selected = "";
            $.each(data, function (i, d) {
                selected = "";
                if (options.selected != null && d.value == options.selected )
                {
                    selected = "selected";
                }
                options.Dom.append('<option value="' + d.value + '" '+ selected +'>' + d.display + '</option>');
            });
        }
    });
};