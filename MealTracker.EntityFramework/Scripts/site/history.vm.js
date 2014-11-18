$(function () {
    
    $('.summary-container').on('click', '.js-delete-meal', function (e) {
        e.preventDefault();

        var $mealRow = $(this).parents('tr'),
            id = $mealRow[0].children[0].innerText;

        $.post('delete-meal', {mealId : id}, function (response, status, xhr) {
            var $summaryPanel = $mealRow.parents('.summary-panel');

            if (response.calories === 0 && response.mealsAmt === 0) {
                $summaryPanel.remove();
                return;
            }

            $mealRow.remove();
            $summaryPanel.find('h1').text(response.calories);
        });
    });

});