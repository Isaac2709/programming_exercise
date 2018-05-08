var WordMatrix = (function () {
    var initialize = function () {
        $("span.word").on("click", searchWord);
    };

    var searchWord = function () {
        var wordToSearch = $(this).html();
        var data = JSON.stringify(wordToSearch);
        $.ajax({
            url: '/GetWord',
            type: 'POST',
            data: data,
            dataType: "json",
            contentType: 'application/json; charset=utf-8',
            success: function (response) {
                _drawWordInMatrix(response);
                alert(JSON.stringify(data));
            },
            error: function () {
                alert("Error consulting the service, please try again.");
            }
        });
    };

    var _drawWordInMatrix = function (wordFoundWithBreakdown) {
        wordFoundWithBreakdown.breakdown.forEach((item) => {
            var locator = "td.x" + item.row + "y" + item.column;
            $(locator).css("font-weight", "Bold");
        });
    };

    return {
        initialize: initialize,
        searchWord: searchWord
    };
}(WordMatrix));

/**
 * Start the application with the onclick events bind.
 */
$(document).ready(function () {
    WordMatrix.initialize();
});