$(function () {
    var $foodName = $('#foodName'),
    $foodQuantity = $('#foodQuantity'),
    $foodCalories = $('#foodCalories'),
        $foodTable = $('#foodTable'),
        $noFoodRow,
    $foodTableBody = $('#foodTable tbody');

    function addFood(name, quantity, calories)
    {
        $noFoodRow = $('#foodTable .js-no-food');

        if ($noFoodRow.length > 0)
            $noFoodRow[0].remove();

        $foodTableBody.append('<tr>' +
            '<td class="id-col"></td>' +
            '<td>' + name + '</td>' +
            '<td>' + quantity + '</td>' +
            '<td>' + calories + '</td>' +
            '<td><button type="button" class="js-delete-food btn btn-default"><span class="glyphicon glyphicon-trash"></span></button></td>' +
            '</tr>');

    }

    $('#foodBtn').on('click', function (e) {
        addFood(
            $foodName.val(),
            $foodQuantity.val(),
            $foodCalories.val()
        );
    });

    $('#foodTable').on('click', '.js-delete-food', function (e) {
            
        $(this).parents('tr').remove();

        if ($('#foodTable tbody tr').length == 0)
            $foodTableBody.append('<tr class="js-no-food">' +
                '<td>No foods added</td>' +
                '<td></td>' +
                '<td></td>' +
                '<td></td>' +
                '</tr>');
    });

    $('#saveMeal').on('click', function (e) {
        var meal = {};

        meal.id = $('#mealId').val();
        meal.type = $('#mealType').val();
        meal.date = $('#mealDate').val();
        meal.time = $('#mealTime').val();
        
        meal.foodDtos = [];

        var $foods = $('#foodTable tbody tr');

        for (var i = 0; i < $foods.length; i++) {

            meal.foodDtos.push({
                id: $foods[i].children[0].innerText,
                name: $foods[i].children[1].innerText,
                quantity: $foods[i].children[2].innerText,
                calories: $foods[i].children[3].innerText,
            });

        }

        $.post('save-meal', meal, function (response, status, xhr) {

        });
    });

});